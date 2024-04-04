using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class POPUPSCREENS_GovModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string docCode = Request.QueryString["DocCode"];
            if (!string.IsNullOrEmpty(docCode))
            {
                Label8.Text = docCode;
                BindGridViewData(docCode);
                BindGridViewData1(docCode);
            }

            DataTable data = FetchDataFromDatabase(docCode);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];

                
                txt_pro_name.Text = row["EOMH_DOC_DETAILS"].ToString();

                if (!string.IsNullOrEmpty(row["EOMH_VALID_FROM_DT"].ToString()))
                {
                    DateTime validityFromDate = Convert.ToDateTime(row["EOMH_VALID_FROM_DT"]);
                    date_vid_from.Text = validityFromDate.ToString("yyyy-MM-dd");
                }

                if (!string.IsNullOrEmpty(row["EOMH_VALID_TO_DT"].ToString()))
                {
                    DateTime validityToDate = Convert.ToDateTime(row["EOMH_VALID_TO_DT"]);
                    date_vid_to.Text = validityToDate.ToString("yyyy-MM-dd");
                }

                string isActiveStr = row["EOMH_STATUS"].ToString();
                bool isActive = isActiveStr.Equals("True", StringComparison.OrdinalIgnoreCase);

                rdt_Active.Checked = !isActive;
                rdt_Inactive.Checked = isActive;


                string eomhStatus = row["EOMH_STATUS"].ToString();
                if (eomhStatus == "Active")
                {
                    rdt_Active.Checked = true;
                }
                else if (eomhStatus == "Inactive")
                {
                    rdt_Inactive.Checked = true;
                }



            }

           

        }

        Checkcookie();
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


    private DataTable FetchDataFromDatabase(string docCode)
    {
        string connectionString1 = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;
        string query2 = "SELECT EOMH_DOCUCODE , EOMH_DOC_DETAILS  , EOMH_VALID_FROM_DT  , EOMH_VALID_TO_DT ,  EOMH_STATUS  FROM MR_ESO_OUTREACH_MASTER_HEADER WHERE EOMH_DOCUCODE = @DocCode";

        DataTable dataTable = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString1))
        {
            using (SqlCommand command = new SqlCommand(query2, connection))
            {
                command.Parameters.AddWithValue("@DocCode", docCode);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
            }
        }

        return dataTable;
    }

    

    private void BindGridViewData(string docCode)
    {
        string connectionString1 = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString1))
        {
            connection.Open();
            string selectQuery = "SELECT EOMH_DOCUCODE 'DOCUMENT CODE', EOMH_DOC_DETAILS 'DOCUMENT DETAILS' , convert(varchar(10),EOMH_VALID_FROM_DT,103) 'DOCUMENT VALIDITY FROM DATE' , convert(varchar(10),EOMH_VALID_TO_DT,103) 'DOCUMENT VALIDITY TO DATE', CASE WHEN EOMH_STATUS ='A' THEN 'Active' ELSE 'Inactive' END 'DOCUMENT STATUS'  FROM MR_ESO_OUTREACH_MASTER_HEADER WHERE EOMH_DOCUCODE = @DocCode  ORDER BY EOMH_STATUS, EOMH_VALID_FROM_DT DESC";

            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {

                command.Parameters.AddWithValue("@DocCode", docCode);

                SqlDataReader reader = command.ExecuteReader();
                gridViewData.DataSource = reader;
                gridViewData.DataBind();
            }
        }
    }
    protected void gridViewData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.CssClass = "gridview-font-small";
        }
    }
    protected void gridViewData_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            List<string> columnsToStyle = new List<string>
        {
            "DOCUMENT CODE",
            "DOCUMENT DETAILS",
            "DOCUMENT VALIDITY FROM DATE",
            "DOCUMENT VALIDITY TO DATE",
            "DOCUMENT STATUS"
        };

            foreach (TableCell cell in e.Row.Cells)
            {
                if (columnsToStyle.Contains(cell.Text.Trim()))
                {
                    cell.CssClass = "gridview-heading-small";
                }
            }
        }
    }




    private void BindGridViewData1(string docCode)
    {


        string connectionString1 = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString1))
        {
            connection.Open();
            string selectQuery = "select EOMD_DOCUCODE'DOCUMENT CODE',EOMD_DOC_REMARKS'DOCUMENT DETAILS',EOMD_DOC_FILENAME'FILE NAME' from MR_ESO_OUTREACH_MASTER_DETAIL WHERE  EOMD_DOCUCODE=@DocCode ";

            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@DocCode", docCode);

                SqlDataReader reader = command.ExecuteReader();
                gridViewData1.DataSource = reader;
                gridViewData1.DataBind();
            }
        }
    }


    protected void gridViewB_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the selected row
        GridViewRow row = gridViewData1.Rows[e.RowIndex];

        string docCode = row.Cells[1].Text;
        string filename = row.Cells[3].Text;


        DeleteData(docCode, filename);

        BindGridViewData1(docCode);

    }

    private void DeleteData(string docCode, string filename)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("DELETE FROM MR_ESO_OUTREACH_MASTER_DETAIL WHERE EOMD_DOCUCODE = @DocCode and EOMD_DOC_FILENAME=@Filename", connection);


            command.Parameters.AddWithValue("@DocCode", docCode);
            command.Parameters.AddWithValue("@Filename", filename);

            connection.Open();
            int a = command.ExecuteNonQuery();



            if (a > 0)
            {
                Response.Write("<script>alert('Data has been Deleted successfully')</script>");
            }
        }
    }




    protected void btn_FileSave_Click(object sender, EventArgs e)
    {

        if (GOV_ADD_DOC_FL_UP.HasFile)
        {
            

            string documentCode = Label8.Text;

            string remarks = GetRemarksFromTable(documentCode);


            string extension = String.Empty;

            extension = GOV_ADD_DOC_FL_UP.FileName.Substring(GOV_ADD_DOC_FL_UP.FileName.LastIndexOf("."));
            string fileName = GOV_ADD_DOC_FL_UP.FileName;


            string originalFilePath = HttpContext.Current.Server.MapPath("GOV_DOCUMENT/" + fileName);

            // Remove the "\POPUPSCREENS" segment from the file path
            string newFilePath = originalFilePath.Replace("\\POPUPSCREENS", "");

              GOV_ADD_DOC_FL_UP.SaveAs(newFilePath);

            SaveGridViewBData(documentCode, fileName, newFilePath, remarks);



            BindGridViewData1(documentCode);



        }

    }


    private string GetRemarksFromTable(string documentCode)
    {
        string remarks = string.Empty;


        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();


            string query = "SELECT EOMH_DOC_DETAILS FROM MR_ESO_OUTREACH_MASTER_HEADER WHERE EOMH_DOCUCODE = @DocumentCode";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DocumentCode", documentCode);


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        remarks = reader["EOMH_DOC_DETAILS"].ToString();
                    }
                }
            }

            connection.Close();
        }

        return remarks;
    }


    private void SaveGridViewBData(string documentCode, string fileName, string filePath, string remarks)
    {

        DataTable dataTableB = new DataTable();
        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        string connectionString1 = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString1))
        {
            connection.Open();


            string query = "INSERT INTO MR_ESO_OUTREACH_MASTER_DETAIL(EOMD_DOCUCODE,EOMD_DOC_FILENAME,EOMD_DOC_FILEPATH,EOMD_DOC_REMARKS,EOMD_CRT_UID,EOMD_CRT_DT,EOMD_UPD_UID,EOMD_UPD_DT) VALUES (@selectedDocuCode,@fileName,@filePath,@Remarks,@Create_User, GETDATE(),@Updated_User, GETDATE())";
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@SelectedDocuCode", documentCode);
                command.Parameters.AddWithValue("@fileName", fileName);
                command.Parameters.AddWithValue("@filePath", filePath);
                command.Parameters.AddWithValue("@Remarks", remarks);
                command.Parameters.AddWithValue("@Create_User", currentuserid);
                command.Parameters.AddWithValue("@Updated_User", currentuserid);
                int a = command.ExecuteNonQuery();


                if (a > 0)
                {
                    Response.Write("<script>alert('Data has been Submitted successfully')</script>");
                }
            }

            connection.Close();
        }

    }



    protected void Update_Click(object sender, EventArgs e)
    {
        string documentCode = Label8.Text;

        string Project_Name = txt_pro_name.Text;

        string valid_from_date = date_vid_from.Text;

        string valid_to_date = date_vid_to.Text;

        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        string Status = " ";

        if (rdt_Active.Checked)
        {
            Status = "A";
        }
        else if (rdt_Inactive.Checked)
        {
            Status = "I";
        }
        else
        {
            Response.Write("<script>alert('Please select a student gender. Data not saved.')</script>");
            return;
        }
        string query = "UPDATE MR_ESO_OUTREACH_MASTER_HEADER SET EOMH_DOC_DETAILS=@Details,EOMH_VALID_FROM_DT=@fromdate,EOMH_VALID_TO_DT=@ToDate,EOMH_STATUS=@Status,EOMH_UPD_UID=@currentuserid,EOMH_UPD_DT=GETDATE() where EOMH_DOCUCODE=@dOCCode ";

      
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@Details", Project_Name);
                command.Parameters.AddWithValue("@fromdate", valid_from_date);
                command.Parameters.AddWithValue("@ToDate", valid_to_date);
                command.Parameters.AddWithValue("@Status", Status);
                command.Parameters.AddWithValue("@dOCCode", documentCode);
                command.Parameters.AddWithValue("@currentuserid", currentuserid);

                command.ExecuteNonQuery();
            }


            connection.Close();

            
        }
        //update MR_ESO_OUTREACH_MASTER_HEADER set EOMH_DOC_DETAILS ='Sample doc' where EOMH_DOCUCODE='DOC0002'


        string query1 = "update MR_ESO_OUTREACH_MASTER_DETAIL set EOMD_DOC_REMARKS=@Details ,EOMD_UPD_UID=@currentuserid  , EOMD_UPD_DT=GETDATE()  where  EOMD_DOCUCODE=@dOCCode";
        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query1, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@Details", Project_Name);
                command.Parameters.AddWithValue("@dOCCode", documentCode);
                command.Parameters.AddWithValue("@currentuserid", currentuserid);

                int a = command.ExecuteNonQuery();


                if (a > 0)
                {
                    Response.Write("<script>alert('Data Updated successfully')</script>");
                }
            }


            connection.Close();


        }
        BindGridViewData(documentCode);
        BindGridViewData1(documentCode);
   
    }



    protected void delete_document(object sender, EventArgs e)
    {
        string documentCode = Label8.Text;
        try
        {
            
            string connectionString1 = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString1))
            {
                connection.Open();


                string query = "DELETE MR_ESO_OUTREACH_MASTER_HEADER WHERE EOMH_DOCUCODE =@SelectedDocuCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@SelectedDocuCode", documentCode);
                    int a = command.ExecuteNonQuery();


                    if (a > 0)
                    {
                        Response.Write("<script>alert('Data has been Submitted successfully')</script>");

                        Response.Write("<script>window.open('', '_self', ''); window.close();</script>");

                    }
                }

                connection.Close();
            }
            

        }
        catch(Exception)
        {
            Response.Write("<script>alert('Before deleting this document code , delete the uploaded document and delete the schools under this document code ')</script>");

        }
        
    }
    
}