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
using System.IO;

public partial class Final_Report : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
    private SqlConnection sqlConnection;
    private SqlDataAdapter[] sqlDataAdapters;
    private DataTable[] dataTables;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
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

    protected void ECPORT_XL_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Final_Report.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                // Export label and textbox values
                RenderLabelAndTextBoxes(hw);

                // Add a line break between sections
                hw.Write("<br /><br />");

                // Export GridView controls
                GridView8.RenderControl(hw);
                GridView9.RenderControl(hw);
                GridView10.RenderControl(hw);
                GridView11.RenderControl(hw);
                GridView12.RenderControl(hw);

                Response.Write(sw.ToString());
            }
        }

        Response.End();
    }

    private void RenderLabelAndTextBoxes(HtmlTextWriter hw)
    {
        // You can customize the styling here
       // hw.Write("<div style='font-weight: bold; margin-bottom: 10px;'>Label and TextBox Values</div>");
        hw.Write("<table>");
        AddRowToHtmlWriter(hw, sch_lbl.Text, sch_txt.Text);
        AddRowToHtmlWriter(hw, date_lbl.Text, date_txt.Text);
        AddRowToHtmlWriter(hw, no_children_lbl.Text, no_children_txt.Text);
        AddRowToHtmlWriter(hw, screened.Text, total_screened_txt.Text);
        AddRowToHtmlWriter(hw, spe_pre.Text, spe_pre_txt.Text);
        AddRowToHtmlWriter(hw, child_ref.Text, child_ref_txt.Text);
        AddRowToHtmlWriter(hw, continue_same.Text, continue_same_txt.Text);
        AddRowToHtmlWriter(hw, NSBVA.Text, NSBVA_txt.Text);
        AddRowToHtmlWriter(hw, deficiency.Text, deficiency_txt.Text);

        hw.Write("</table>");
    }

    private void AddRowToHtmlWriter(HtmlTextWriter hw, string label, string value)
    {
        hw.Write("<tr>");
        hw.Write($"<td>{label}</td>");
        hw.Write($"<td>{value}</td>");
        hw.Write("</tr>");
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void FETCH_BTN_Click(object sender, EventArgs e)
    {
        string selectedSchoolNumber = sch_no_rpt.SelectedValue;
        FetchAndBindData(selectedSchoolNumber);
    }

    private void FetchAndBindData(string schoolNumber)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString()))
        {
            con.Open();

            for (int i = 1; i <= 12; i++)
            {
                string storedProcedureName = "ESO_CAMP_FINAL_REPORT";  
                string parameterName = "@SCHOO_ID";

                using (SqlCommand sqlCommand = new SqlCommand(storedProcedureName, con))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(parameterName, schoolNumber);

                    SqlDataAdapter Da = new SqlDataAdapter(sqlCommand);
                    DataSet DS = new DataSet();  // Create a new DataSet for each iteration
                    Da.Fill(DS);

                    date_txt.Text = DS.Tables[0].Rows[0][0].ToString();
                    no_children_txt.Text = DS.Tables[1].Rows[0][0].ToString();
                    total_screened_txt.Text = DS.Tables[2].Rows[0][0].ToString();
                    spe_pre_txt.Text = DS.Tables[3].Rows[0][0].ToString();
                    child_ref_txt.Text = DS.Tables[4].Rows[0][0].ToString();
                    continue_same_txt.Text = DS.Tables[5].Rows[0][0].ToString();
                    NSBVA_txt.Text = DS.Tables[6].Rows[0][0].ToString();
                    deficiency_txt.Text = DS.Tables[7].Rows[0][0].ToString();
                    sch_txt.Text = DS.Tables[13].Rows[0][0].ToString();





                    switch (i)
                    {
                      
                        case 8:
                            GridView8.DataSource = DS.Tables[8];
                            GridView8.DataBind();
                            GridView8.Caption = " Children Prescribed With New Spectacles ";
                            break;
                        case 9:
                            GridView9.DataSource = DS.Tables[9];
                            GridView9.DataBind();
                            GridView9.Caption = " Number of children with continue same glasses ";
                            break;
                        case 10:
                            GridView10.DataSource = DS.Tables[10];
                            GridView10.DataBind();
                            GridView10.Caption = " Children Referred For Further Examination ";
                            break;
                        case 11:
                            GridView11.DataSource = DS.Tables[11];
                            GridView11.DataBind();
                            GridView11.Caption = " Number Of Children With Non Strabismic Binocular Vision Anomalies ";
                            break;
                        case 12:
                            GridView12.DataSource = DS.Tables[12];
                            GridView12.DataBind();
                            GridView12.Caption = " Number Of Children With Color Deficiency ";
                            break;
                    }
                }
            }
        }
    }

}





