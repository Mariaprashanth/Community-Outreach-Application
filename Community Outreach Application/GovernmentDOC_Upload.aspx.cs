using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;

public partial class GovernmentDOC_Upload : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
       
		Checkcookie();
        USERACCESS();

    }

    private void USERACCESS()
    {
        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];
        con.Open();
        string rev = " select MEOURS_ROLE_CODE from  MR_ESO_ORC_USER_RIGHTS  WHERE MEOURS_EMP_NUM='" + currentuserid + "' ";

        SqlCommand cmd = new SqlCommand(rev, con);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        adapt.Fill(dt);
        if (dt.Tables[0].Rows.Count >= 1)
        {
            string RLCOD = dt.Tables[0].Rows[0]["MEOURS_ROLE_CODE"].ToString().TrimEnd().TrimStart();

            if (RLCOD != "MEOPA" && RLCOD != "MEODEO")
            {
                Response.Redirect("Unauthorized.aspx");

            }



        }
        con.Close();
    }

    private void Checkcookie()
	{
		if (Request.Cookies["COMM_OUTREACH"] != null)
		{
			string Cookiecheck = Request.Cookies["COMM_OUTREACH"]["CookieAlive"];
			if (Cookiecheck == "False")
			{

				Response.Redirect("/COMMUNITY_OUTREACH/LOGINPG.aspx");
			}
			else if (Cookiecheck == "True")
			{
				DateTime CookieDateTime = DateTime.Now.AddDays(1);

				string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];
				string currentempid = Request.Cookies["COMM_OUTREACH"]["USEREMPNUM"];
				string currentesorocode = Request.Cookies["COMM_OUTREACH"]["USERROLECODE"];
				string currentcookiealive = Request.Cookies["COMM_OUTREACH"]["CookieAlive"];
				string currentusername = Request.Cookies["COMM_OUTREACH"]["USERNAME"];
				string currentexpire = Request.Cookies["COMM_OUTREACH"]["CookiesExpiryon"];
				Response.Cookies["COMM_OUTREACH"]["USERLOCATION"] = currentesorocode;
				Response.Cookies["COMM_OUTREACH"]["USERHMSID"] = currentuserid;
				Response.Cookies["COMM_OUTREACH"]["USEREMPNUM"] = currentempid;
				Response.Cookies["COMM_OUTREACH"]["CookieAlive"] = "True";
				Response.Cookies["COMM_OUTREACH"]["USERNAME"] = currentusername;
				Response.Cookies["COMM_OUTREACH"]["CookiesExpiryon"] = CookieDateTime.ToString("dd-MM-yyyy hh:mm:ss tt");
				Response.Cookies["COMM_OUTREACH"].Expires = CookieDateTime;

			}
			else
			{

				Response.Cookies["COMM_OUTREACH"]["CookieAlive"] = "False";
				Response.Cookies["COMM_OUTREACH"].Expires = DateTime.Now.AddDays(-1);
				Response.Redirect("/COMMUNITY_OUTREACH /LOGINPG.aspx");
			}
		}
		else
		{

			Response.Redirect("/COMMUNITY_OUTREACH/LOGINPG.aspx");
		}

	}

    //-------------------------------------- btnView_Click(View button) -------------------------------------
    protected void btnView_Click(object sender, EventArgs e)
    {
        
        GridViewCommandEventArgs args = new GridViewCommandEventArgs(null, new CommandEventArgs("Modify", null));
        gridView_RowCommand(sender, args);

        gridViewData.Visible = true;

        txtInput.Visible = false;
        txtToDate.Visible = false;
        txtFromDate.Visible = false;

        LBL_VFD.Visible = false;
        LBL_DOC.Visible = false;
        LBL_VTD.Visible = false;


        GOV_DOC_FL_UP.Visible = false;
        LBL_DOC_FL_UP.Visible = false;

        btnSave.Visible = false;
       

    }
    
    //-----------------------------------------  gridView_RowCommand() method for  btnView_Click(VIEW button) -----------------------------------
    protected void gridView_RowCommand(object sender, EventArgs e)
    {

        string connectionString1 = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString1))
        {
            connection.Open();
            string selectQuery = "SELECT EOMH_DOCUCODE 'PROJECT CODE' ,EOMH_DOC_DETAILS 'PROJECT DETAILS' ,convert(varchar(10),EOMH_VALID_FROM_DT,103) 'DOCUMENT VALIDITY FROM DATE'  ,convert(varchar(10),EOMH_VALID_TO_DT,103) 'DOCUMENT VALIDITY TO DATE' , case when EOMH_STATUS ='A' then 'Active' else 'Inactive' end 'STATUS' FROM MR_ESO_OUTREACH_MASTER_HEADER order by EOMH_STATUS,EOMH_VALID_FROM_DT DESC";
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                gridViewData.DataSource = reader;
                gridViewData.DataBind();
              
            }
        }
    }

    //---------------------------------------------- btnAdd_Click(ADD button)-------------------------------------------------------------------
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        txtInput.Visible = true;
        LBL_DOC.Visible = true;   // Show the Label
        
        txtInput.Text = ""; // Show the textbox

        btnSave.Visible = true;
        
        txtFromDate.Visible = true;  // Show the TextBox
        LBL_VFD.Visible = true;
        
        txtFromDate.Text = "";
        
        txtToDate.Visible = true;  // Show the TextBox
        LBL_VTD.Visible = true;
        
        txtToDate.Text = "";

        LBL_DOC_FL_UP.Visible = true;
        GOV_DOC_FL_UP.Visible = true;
       
        gridViewData.Visible = false;
        
        

      
    }




    protected void gridViewData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modify")
        {
            string docCode = e.CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenPopupScript", "openPopup('" + docCode + "');", true);
        }
    }





    //---------------------------------------------- btnSave_Click() method  for    btnAdd_Click(ADD button)-------------------------------------------------------------------

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (GOV_DOC_FL_UP.HasFile)
        {

            string inputText = txtInput.Text;
            DateTime fromDate = DateTime.Parse(txtFromDate.Text);
            DateTime toDate = DateTime.Parse(txtToDate.Text);

            DateTime currentDate = DateTime.Now;
            DateTime tenDaysBeforeFromDate = fromDate.AddDays(-10);
            DateTime tenDaysAfterToDate = toDate.AddDays(10);


            string connectionString1 = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString1))
            {
                connection.Open();

				string extension = String.Empty;
				extension = GOV_DOC_FL_UP.FileName.Substring(GOV_DOC_FL_UP.FileName.LastIndexOf("."));
				string fileName = GOV_DOC_FL_UP.FileName;
				string filePath = HttpContext.Current.Server.MapPath("GOV_DOCUMENT/" + fileName);
                GOV_DOC_FL_UP.SaveAs(filePath);

				string querycode = "SELECT MAX(EOMH_DOCUCODE) FROM MR_ESO_OUTREACH_MASTER_HEADER";
				SqlCommand commandcode = new SqlCommand(querycode, connection);
				object result = commandcode.ExecuteScalar();

				string generatedCode = "DOC0001";
				if (result != DBNull.Value)
				{
					string maxCode = result.ToString();
					int codeNumber = int.Parse(maxCode.Substring(3)) + 1;
					generatedCode = "DOC" + codeNumber.ToString("D4");
				}

                string status = (currentDate >= tenDaysBeforeFromDate && currentDate <= tenDaysAfterToDate) ? "A" : "I";

                string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

				string query = "INSERT INTO MR_ESO_OUTREACH_MASTER_HEADER(EOMH_DOCUCODE,EOMH_DOC_DETAILS,EOMH_VALID_FROM_DT,EOMH_VALID_TO_DT,EOMH_STATUS,EOMH_CRT_UID,EOMH_CRT_DT,EOMH_UPD_UID,EOMH_UPD_DT) VALUES (@fileid, @Details, @FromDate, @ToDate, @Status, @currentuserid, GETDATE(),@uptuserid, GETDATE())";
                // Create an SQL command with the query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
					// Add a parameter for the input text
					command.Parameters.AddWithValue("@fileid", generatedCode);
					command.Parameters.AddWithValue("@Details", inputText);
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);
                    command.Parameters.AddWithValue("@Status", status);
					command.Parameters.AddWithValue("@currentuserid", currentuserid);
					command.Parameters.AddWithValue("@uptuserid", currentuserid);
					
					command.ExecuteNonQuery();
                }

               
				string query1 = "INSERT INTO MR_ESO_OUTREACH_MASTER_DETAIL(EOMD_DOCUCODE,EOMD_DOC_FILENAME,EOMD_DOC_FILEPATH,EOMD_DOC_REMARKS,EOMD_CRT_UID,EOMD_CRT_DT,EOMD_UPD_UID,EOMD_UPD_DT) VALUES (@fileid,@fileName,@filePath,@rmkDetails,@currentuserid, GETDATE(), @uptuserid, GETDATE())";
                
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
					// Add a parameter for the input text
					command.Parameters.AddWithValue("@fileid", generatedCode);
					command.Parameters.AddWithValue("@fileName", fileName);
                    command.Parameters.AddWithValue("@filePath", filePath);
					
					command.Parameters.AddWithValue("@rmkDetails", inputText);
					command.Parameters.AddWithValue("@currentuserid", currentuserid);
					command.Parameters.AddWithValue("@uptuserid", currentuserid);
					
					int a = command.ExecuteNonQuery();


                    if (a > 0)
                    {
                        Response.Write("<script>alert('Data has been Submitted successfully')</script>");
                    }
                }


                connection.Close();
            }

            txtInput.Visible = false;
            txtToDate.Visible = false;
            txtFromDate.Visible = false;

            LBL_VFD.Visible = false;
            LBL_DOC.Visible = false;
            LBL_VTD.Visible = false;
         
            LBL_DOC_FL_UP.Visible = false;
            GOV_DOC_FL_UP.Visible = false;// Hide the textbox after saving the text
            btnSave.Visible = false;

           
          
            gridView_RowCommand(sender, e);

        }
    }

    
    
}



