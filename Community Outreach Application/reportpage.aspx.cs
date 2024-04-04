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


public partial class reportpage : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dockcodedropdown();
            schnamedropdown();
            USERACCESS();
        }

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

            if (RLCOD != "MEOPA")
            {
                Response.Redirect("Unauthorized.aspx");

            }



        }
        con.Close();
    }

    private void schnamedropdown()
    {
        string com = " select a.ECSD_SCHOOL_NO ,a.ECSD_SCHOOL_NAME from  ESO_CAMP_SCH_DTLS a inner join  MR_ESO_OUTREACH_MASTER_HEADER b on a.ECSD_SCHOOL_DOC_NO=b.EOMH_DOCUCODE  where b.EOMH_STATUS='A' ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        sch_no_rpt.DataSource = dt;
        sch_no_rpt.DataBind();
        sch_no_rpt.DataTextField = "ECSD_SCHOOL_NAME";
        sch_no_rpt.DataValueField = "ECSD_SCHOOL_NO";
        sch_no_rpt.DataBind();
        sch_no_rpt.Items.Insert(0, new ListItem("Select School Name", ""));
    }


    private void dockcodedropdown()
    {
        string com = " select EOMH_DOCUCODE,EOMH_DOC_DETAILS from  MR_ESO_OUTREACH_MASTER_HEADER  where  EOMH_STATUS='A' ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        sch_pro_rpt.DataSource = dt;
        sch_pro_rpt.DataBind();
        sch_pro_rpt.DataTextField = "EOMH_DOC_DETAILS";
        sch_pro_rpt.DataValueField = "EOMH_DOCUCODE";
        sch_pro_rpt.DataBind();
        sch_pro_rpt.Items.Insert(0, new ListItem("Select Project Name", ""));
    }


    protected void FETCH_BTN_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("ESO_CAMP_OVERALL_REPORT", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            // Set the parameters for the stored procedure
            cmd.Parameters.AddWithValue("@SCHOOL_NO", sch_no_rpt.SelectedValue); // Replace with actual values
            cmd.Parameters.AddWithValue("@PROJECTCODE", sch_pro_rpt.SelectedValue); // Replace with actual values

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Bind the DataTable to the GridView
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
    }

    protected void ECPORT_XL_Click(object sender, EventArgs e)
    {
        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=ESO_CAMP_OVERALL_DATA.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";

        this.EnableViewState = false;
        System.IO.StringWriter strW = new System.IO.StringWriter();
        HtmlTextWriter htmlWrite = new HtmlTextWriter(strW);
        strW.GetStringBuilder().Append("<table>");
        strW.GetStringBuilder().Append("<tr></tr>");
        PNL1.RenderControl(htmlWrite);
        strW.GetStringBuilder().Append("</table>");
        Response.Write(strW.ToString());
        Response.End();

    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}