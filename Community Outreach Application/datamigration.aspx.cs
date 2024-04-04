using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class datamigration : System.Web.UI.Page
{
    private string provalue;
    private string studentvalue;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            serverdropdown();
            prodropdown();
            schropdown();
            USERACCESS();
        }
    }

    private void serverdropdown()
    {
        string com = "select  distinct EOMH_SCHOOL_SERVER  from  MR_ESO_OUTREACH_MASTER_HEADER where EOMH_STATUS='A' ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        server_drop.DataSource = dt;
        server_drop.DataBind();
        server_drop.DataTextField = "EOMH_SCHOOL_SERVER";
        server_drop.DataValueField = "EOMH_SCHOOL_SERVER";
        server_drop.DataBind();
        server_drop.Items.Insert(0, new ListItem("Select Server Name", ""));

    }

    private void prodropdown()
    {
        string com = "select EOMH_DOCUCODE,EOMH_DOC_DETAILS from  MR_ESO_OUTREACH_MASTER_HEADER  where  EOMH_STATUS='A' ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        document_drop.DataSource = dt;
        document_drop.DataBind();
        document_drop.DataTextField = "EOMH_DOC_DETAILS";
        document_drop.DataValueField = "EOMH_DOCUCODE";
        document_drop.DataBind();
        document_drop.Items.Insert(0, new ListItem("Select project Name", ""));

    }

    private void schropdown()
    {
        string com = "select  a.ECSD_SCHOOL_NAME,a.ECSD_SCHOOL_NO from  ESO_CAMP_SCH_DTLS a inner join  MR_ESO_OUTREACH_MASTER_HEADER b on a.ECSD_SCHOOL_DOC_NO=b.EOMH_DOCUCODE  where b.EOMH_STATUS='A' ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        school_drop.DataSource = dt;
        school_drop.DataBind();
        school_drop.DataTextField = "ECSD_SCHOOL_NAME";
        school_drop.DataValueField = "ECSD_SCHOOL_NO";
        school_drop.DataBind();
        school_drop.Items.Insert(0, new ListItem("Select project Name", ""));

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


    //protected void server_drop_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // Get the selected school value
    //    string servername = server_drop.SelectedValue;

    //    if (!string.IsNullOrEmpty(servername))
    //    {
    //        // Load the sections based on the selected school
    //        projectname(servername);

    //        // Load the classes based on the selected school
    //        schoolname(servername);
    //    }
    //    else
    //    {
    //        // Clear the Section and Class dropdowns if no school is selected
    //        document_drop.Items.Clear();
    //        school_drop.Items.Clear();
    //    }
    //}


    //private void projectname(string servalue)
    //{
    //    // Construct and execute the query to load sections based on school
    //    string sectionQuery = "select EOMH_DOCUCODE,EOMH_DOC_DETAILS from  MR_ESO_OUTREACH_MASTER_HEADER  where  EOMH_STATUS='A' and EOMH_SCHOOL_SERVER= @servalue";
    //    using (SqlConnection connection = new SqlConnection(con.ConnectionString))
    //    {
    //        using (SqlCommand command = new SqlCommand(sectionQuery, connection))
    //        {
    //            command.Parameters.AddWithValue("@servalue", servalue);
    //            connection.Open();
    //            using (SqlDataReader reader = command.ExecuteReader())
    //            {
    //                document_drop.Items.Clear(); // Clear existing items
    //                document_drop.Items.Insert(0, new ListItem("Select Project Name", ""));
    //                while (reader.Read())
    //                {
    //                    string proname = reader["EOMH_DOC_DETAILS"].ToString();
    //                    string provalue = reader["EOMH_DOCUCODE"].ToString();
    //                    document_drop.Items.Add(new ListItem(proname, proname));

    //                    provalue = reader["EOMH_DOCUCODE"].ToString();
    //                }
    //            }
    //        }
    //    }
    //}

    //private void schoolname(string servalue)
    //{
    //    // Construct and execute the query to load classes based on school
    //    string classQuery = "select  a.ECSD_SCHOOL_NAME,a.ECSD_SCHOOL_NO from  ESO_CAMP_SCH_DTLS a inner join  MR_ESO_OUTREACH_MASTER_HEADER b on a.ECSD_SCHOOL_DOC_NO=b.EOMH_DOCUCODE  where b.EOMH_STATUS='A' and b.EOMH_SCHOOL_SERVER=@servalue";
    //    using (SqlConnection connection = new SqlConnection(con.ConnectionString))
    //    {
    //        using (SqlCommand command = new SqlCommand(classQuery, connection))
    //        {
    //            command.Parameters.AddWithValue("@servalue", servalue);
    //            connection.Open();
    //            using (SqlDataReader reader = command.ExecuteReader())
    //            {
    //                school_drop.Items.Clear(); // Clear existing items
    //                school_drop.Items.Insert(0, new ListItem("Select School Name", ""));
    //                while (reader.Read())
    //                {
    //                    string schoolname = reader["ECSD_SCHOOL_NAME"].ToString();
    //                    string studentvalue = reader["ECSD_SCHOOL_NO"].ToString();
    //                    school_drop.Items.Add(new ListItem(schoolname, schoolname));
    //                }
    //            }
    //        }
    //    }
    //}

    protected void migration_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString();

        if (server_drop.SelectedValue == null)
        {
            // Handle the case where provalue is not set
            Response.Write("<script>alert('serve   is not selected ')</script>");
            return;
        }

        if (document_drop.SelectedValue == null)
        {
            // Handle the case where provalue is not set
            Response.Write("<script>alert('project value is not selected')</script>");
            return;
        }

        if (school_drop.SelectedValue == null)
        {
            // Handle the case where provalue is not set
            Response.Write("<script>alert('school value is not selected')</script>");
            return;
        }

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            try
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("ESO_CAMP_DATA_MIGRATION", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add(new SqlParameter("@server", server_drop.SelectedValue));
                    command.Parameters.Add(new SqlParameter("@DOC_CODE", document_drop.SelectedValue));
                    command.Parameters.Add(new SqlParameter("@SCL_CODE", school_drop.SelectedValue));

                    // Execute the stored procedure
                    command.ExecuteNonQuery();

                    Response.Write("<script>alert('Data has been migrated successfully')</script>");
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL-specific exceptions
                Response.Write("<script>alert('An SQL error occurred: " + ex.Message + "')</script>");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Response.Write("<script>alert('An error occurred: " + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }
    }
}