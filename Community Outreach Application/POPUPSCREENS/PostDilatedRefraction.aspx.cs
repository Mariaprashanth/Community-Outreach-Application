using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Configuration;

public partial class POPUPSCREENS_PostDilatedRefraction : System.Web.UI.Page
{
	SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
    private string studentid;

    protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
            studentid = Request.QueryString["studentID"];

            postDilatedRefraction_OD();
			postDilatedRefraction_OS();
		}
			
	}


	private void postDilatedRefraction_OD()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOdDvBCVAOpt.DataSource = dt;
		cmbAcOdDvBCVAOpt.DataBind();
		cmbAcOdDvBCVAOpt.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOdDvBCVAOpt.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOdDvBCVAOpt.DataBind();
		cmbAcOdDvBCVAOpt.Items.Insert(0, new ListItem("---- Select ---- ", ""));

	}

	private void postDilatedRefraction_OS()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOsDvBCVAOpt.DataSource = dt;
		cmbAcOsDvBCVAOpt.DataBind();
		cmbAcOsDvBCVAOpt.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOsDvBCVAOpt.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOsDvBCVAOpt.DataBind();
		cmbAcOsDvBCVAOpt.Items.Insert(0, new ListItem("---- Select ---- ", ""));

	}

	protected void save_btn_Click(object sender, EventArgs e)
	{
		// Post Dilated Refraction
		string postRefraction_OD = txtodsph.Text;
		string postRefraction_OD_DS = txtodcyl.Text;
		string postRefraction_OD_DC = txtodaxi.Text;

		string postRefraction_OD_Axis = cmbAcOdDvBCVAOpt.SelectedValue;
		string selectpostRefraction_OD_Axis = cmbAcOdDvBCVAOpt.SelectedItem.Text;
        if (selectpostRefraction_OD_Axis == "---- Select ---- ")
        {
            selectpostRefraction_OD_Axis = "";
        }

        string postRefraction_OS = txtossph.Text;
		string postRefraction_OS_DS = txtoscyl.Text;
		string postRefraction_OS_DC = txtosaxi.Text;

		string postRefraction_OS_Axis = cmbAcOsDvBCVAOpt.SelectedValue;
		string selectpostRefraction_OS_Axis = cmbAcOsDvBCVAOpt.SelectedItem.Text;
        if (selectpostRefraction_OS_Axis == "---- Select ---- ")
        {
            selectpostRefraction_OS_Axis = "";
        }

        string postRefraction_Remarks = txtRemarks.InnerText;

		StringBuilder htmlBuilder = new StringBuilder();
		htmlBuilder.AppendLine("<table cellspacing='1' cellpadding='1' border='0' width='50%'>");
		htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
		htmlBuilder.AppendLine("<td colspan='4' align='center'>Post Dilated Refraction</td></tr>");
		htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
		htmlBuilder.AppendLine("<td><b>EYE</b></td><td><b>SPHERE</b></td><td><b>CYLINDER</b></td><td><b>AXIS</b></td><td>V/A</td></tr>");
		htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
		htmlBuilder.AppendLine("<td>OD</td><td>" + postRefraction_OD + "</td><td>" + postRefraction_OD_DS + "</td><td>" + postRefraction_OD_DC + "</td><td>" + selectpostRefraction_OD_Axis + "</td></tr>");
		htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
		htmlBuilder.AppendLine("<td>OS</td><td>" + postRefraction_OS + "</td><td>" + postRefraction_OS_DS + "</td><td>" + postRefraction_OS_DC + "</td><td>" + selectpostRefraction_OS_Axis + "</td></tr>");
		htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
		htmlBuilder.AppendLine("<td>Remarks</td><td colspan='3'>" + postRefraction_Remarks + "</td></tr>");
		htmlBuilder.AppendLine("</table>");

		// Set the generated HTML as the value of htmlsummary
		string generatedSummary = htmlBuilder.ToString();

        string studentid = Request.QueryString["studentID"];

        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        con.Open();

		string table = "INSERT INTO ESO_POSTDILATED_REFRACTION(ECPDR_STD_NUMBER,ECPDR_OD, ECPDR_OD_DS, ECPDR_OD_DC,ECPDR_OD_AXIS,ECPDR_OS,ECPDR_OS_DS,ECPDR_OS_DC,ECPDR_OS_AXIS,ECPDR_REMARKS,ECPDR_SUMMARY,ECPDR_CRT_UID,ECPDR_CRT_DT,ECPDR_LAST_UPD_UID,ECPDR_LAST_UPD_DT)";
		table += "VALUES(@studentid,@postRefraction_OD,@postRefraction_OD_DS,@postRefraction_OD_DC,@postRefraction_OD_Axis,@postRefraction_OS,@postRefraction_OS_DS,@postRefraction_OS_DC,@postRefraction_OS_Axis,@postRefraction_Remarks,@postrefsummary,@currentuserid,GETDATE(),@currentuserid,GETDATE())";

		SqlCommand cmd = new SqlCommand(table, con);

        // Post Dilated Refraction
        cmd.Parameters.AddWithValue("@studentid", studentid);

        cmd.Parameters.AddWithValue("@postRefraction_OD", postRefraction_OD);
		cmd.Parameters.AddWithValue("@postRefraction_OD_DS", postRefraction_OD_DS);
		cmd.Parameters.AddWithValue("@postRefraction_OD_DC", postRefraction_OD_DC);
		cmd.Parameters.AddWithValue("@postRefraction_OD_Axis", postRefraction_OD_Axis);
		cmd.Parameters.AddWithValue("@postRefraction_OS", postRefraction_OS);
		cmd.Parameters.AddWithValue("@postRefraction_OS_DS", postRefraction_OS_DS);
		cmd.Parameters.AddWithValue("@postRefraction_OS_DC", postRefraction_OS_DC);
		cmd.Parameters.AddWithValue("@postRefraction_OS_Axis", postRefraction_OS_Axis);
		cmd.Parameters.AddWithValue("@postRefraction_Remarks", postRefraction_Remarks);
		cmd.Parameters.AddWithValue("@postrefsummary", generatedSummary);

        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);

        cmd.ExecuteNonQuery();

		con.Close();

		SummaryLiteral.Text = generatedSummary;

	
	}

    protected void modify_btn_Click(object sender, EventArgs e)
    {
        string postRefraction_OD = txtodsph.Text;
        string postRefraction_OD_DS = txtodcyl.Text;
        string postRefraction_OD_DC = txtodaxi.Text;

        string postRefraction_OD_Axis = cmbAcOdDvBCVAOpt.SelectedValue;
        string selectpostRefraction_OD_Axis = cmbAcOdDvBCVAOpt.SelectedItem.Text;
        if (selectpostRefraction_OD_Axis == "---- Select ---- ")
        {
            selectpostRefraction_OD_Axis = "";
        }

        string postRefraction_OS = txtossph.Text;
        string postRefraction_OS_DS = txtoscyl.Text;
        string postRefraction_OS_DC = txtosaxi.Text;

        string postRefraction_OS_Axis = cmbAcOsDvBCVAOpt.SelectedValue;
        string selectpostRefraction_OS_Axis = cmbAcOsDvBCVAOpt.SelectedItem.Text;
        if (selectpostRefraction_OS_Axis == "---- Select ---- ")
        {
            selectpostRefraction_OS_Axis = "";
        }

        string postRefraction_Remarks = txtRemarks.InnerText;

        StringBuilder htmlBuilder = new StringBuilder();
        htmlBuilder.AppendLine("<table cellspacing='1' cellpadding='1' border='0' width='50%'>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        htmlBuilder.AppendLine("<td colspan='4' align='center'>Post Dilated Refraction</td></tr>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        htmlBuilder.AppendLine("<td><b>EYE</b></td><td><b>SPHERE</b></td><td><b>CYLINDER</b></td><td><b>AXIS</b></td><td>V/A</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>OD</td><td>" + postRefraction_OD + "</td><td>" + postRefraction_OD_DS + "</td><td>" + postRefraction_OD_DC + "</td><td>" + selectpostRefraction_OD_Axis + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>OS</td><td>" + postRefraction_OS + "</td><td>" + postRefraction_OS_DS + "</td><td>" + postRefraction_OS_DC + "</td><td>" + selectpostRefraction_OS_Axis + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Remarks</td><td colspan='3'>" + postRefraction_Remarks + "</td></tr>");
        htmlBuilder.AppendLine("</table>");

        // Set the generated HTML as the value of htmlsummary
        string generatedSummary = htmlBuilder.ToString();

        string studentid = Request.QueryString["studentID"];

        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        con.Open();

        string table = "UPDATE ESO_POSTDILATED_REFRACTION SET ECPDR_OD = @postRefraction_OD,ECPDR_OD_DS = @postRefraction_OD_DS,ECPDR_OD_DC = @postRefraction_OD_DC,ECPDR_OD_AXIS = @postRefraction_OD_Axis,ECPDR_OS = @postRefraction_OS,ECPDR_OS_DS = @postRefraction_OS_DS,ECPDR_OS_DC = @postRefraction_OS_DC,ECPDR_OS_AXIS = @postRefraction_OS_Axis,";
        table += "ECPDR_REMARKS = @postRefraction_Remarks,ECPDR_SUMMARY = @postrefsummary,ECPDR_CRT_UID = @currentuserid,ECPDR_CRT_DT = GETDATE(),ECPDR_LAST_UPD_UID = @currentuserid,ECPDR_LAST_UPD_DT = GETDATE() WHERE ECPDR_STD_NUMBER = @studentid";

        SqlCommand cmd = new SqlCommand(table, con);

        // Post Dilated Refraction
        cmd.Parameters.AddWithValue("@studentid", studentid);

        cmd.Parameters.AddWithValue("@postRefraction_OD", postRefraction_OD);
        cmd.Parameters.AddWithValue("@postRefraction_OD_DS", postRefraction_OD_DS);
        cmd.Parameters.AddWithValue("@postRefraction_OD_DC", postRefraction_OD_DC);
        cmd.Parameters.AddWithValue("@postRefraction_OD_Axis", postRefraction_OD_Axis);
        cmd.Parameters.AddWithValue("@postRefraction_OS", postRefraction_OS);
        cmd.Parameters.AddWithValue("@postRefraction_OS_DS", postRefraction_OS_DS);
        cmd.Parameters.AddWithValue("@postRefraction_OS_DC", postRefraction_OS_DC);
        cmd.Parameters.AddWithValue("@postRefraction_OS_Axis", postRefraction_OS_Axis);
        cmd.Parameters.AddWithValue("@postRefraction_Remarks", postRefraction_Remarks);
        cmd.Parameters.AddWithValue("@postrefsummary", generatedSummary);

        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);

        cmd.ExecuteNonQuery();

        con.Close();

        SummaryLiteral.Text = generatedSummary;


    }



}