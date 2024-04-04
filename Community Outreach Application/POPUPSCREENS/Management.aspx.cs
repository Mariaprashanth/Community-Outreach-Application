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
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.Configuration;

public partial class POPUPSCREENS_Management : System.Web.UI.Page
{
    private string studentid;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
    protected void Page_Load(object sender, EventArgs e)
	{
        if (!IsPostBack)
        {
            studentid = Request.QueryString["studentID"];

            managemenrdatafetchdata();

        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedValue = DropDownList1.SelectedItem.Text;


        pnlNewGlasses.Visible = false;
        pnlGlassesAndReferral.Visible = false;
        PNLOTHER.Visible = false;


        if (selectedValue == "New glasses prescribed")
        {
            pnlNewGlasses.Visible = true;
        }
        else if (selectedValue == "Referral")
        {
            pnlGlassesAndReferral.Visible = true;
        }
        else if (selectedValue == "Others")
        {
            PNLOTHER.Visible = true;
        }
        else if (selectedValue == "Glasses prescribed and referral")
        {
            pnlNewGlasses.Visible = true;

            pnlGlassesAndReferral.Visible = true;

        }
    }


    private void managemenrdatafetchdata()
    {
        string stser = "select * from ESO_CAMP_MANAGEMENT ";
        stser += "WHERE ECM_STU_ID = '" + studentid + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(stser, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);


        if (ds.Tables[0].Rows.Count >= 1)
        {
            overallremarksTextBox.Text = ds.Tables[0].Rows[0]["ECM_OVER_ALL_REMARKS"].ToString().TrimEnd().TrimStart();

            DropDownList1.Text = ds.Tables[0].Rows[0]["ECM_CHOOSE_VALUE"].ToString().TrimEnd().TrimStart();

            chooseremark.Text = ds.Tables[0].Rows[0]["ECM_CHOOSE_OTHER_REMARKS"].ToString().TrimEnd().TrimStart();

            od_val_txt.Text = ds.Tables[0].Rows[0]["ECM_OD"].ToString().TrimEnd().TrimStart();

            os_val_txt.Text = ds.Tables[0].Rows[0]["ECM_OS"].ToString().TrimEnd().TrimStart();

            frame_size_txt.Text = ds.Tables[0].Rows[0]["ECM_FRAME_SIZE"].ToString().TrimEnd().TrimStart();

            frame_model_txt.Text = ds.Tables[0].Rows[0]["ECM_FRAME_MODEL"].ToString().TrimEnd().TrimStart();

            frame_color_txt.Text = ds.Tables[0].Rows[0]["ECM_COLOR"].ToString().TrimEnd().TrimStart();

            reasonforref.SelectedItem.Text = ds.Tables[0].Rows[0]["ECM_REASON_REFERAL"].ToString().TrimEnd().TrimStart();

            otherReasonTextBox.Text = ds.Tables[0].Rows[0]["ECM_REFERAL_OTHER_REMARKS"].ToString().TrimEnd().TrimStart();

            SummaryLiteral.Text = ds.Tables[0].Rows[0]["ECM_MANAGEMENT_SUMMARY"].ToString().TrimEnd().TrimStart();



            pnlNewGlasses.Visible = true;
            pnlGlassesAndReferral.Visible = true;
            //PNLOTHER.Visible = true;

            save_btn.Visible = false;

            ubdate_btn.Visible = true;

        }
        else
        {
            save_btn.Visible = true;
        }

        con.Close();

        
    }



    protected void save_btn_Click(object sender, EventArgs e)
    {
        string choosevalues = DropDownList1.SelectedItem.Text;

        string chossvalremark = chooseremark.Text;

        string odval = od_val_txt.Text;

        string osval = os_val_txt.Text;

      
        string framesize = frame_size_txt.Text;

        string framemodel = frame_model_txt.Text;

        string framecolor = frame_color_txt.Text;

        string resonforref = reasonforref.SelectedItem.Text;

        if (resonforref == "---select----")
        {
            resonforref = "";
        }

        string refotherreason = otherReasonTextBox.Text;


        string man_overallremark = overallremarksTextBox.Text;



        StringBuilder htmlBuilder = new StringBuilder();
        htmlBuilder.AppendLine("<table cellspacing='1' cellpadding='1' border='0' width='50%'>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        htmlBuilder.AppendLine("<td colspan='4' align='center'> MANAGEMENT </td></tr>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        //htmlBuilder.AppendLine("<td><b>EYE</b></td><td><b>SPHERE</b></td><td><b>CYLINDER</b></td><td><b>AXIS</b></td><td>V/A</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>CHOOSE ANY ONE</td><td>" + choosevalues + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>CHOOSE ANY ONE OTHER REMARK </td><td>" + chossvalremark + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>OD</td><td>" + odval + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>OS</td><td>" + osval + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>FRAME SIZE</td><td>" + framesize + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>FRAME MODEL</td><td>" + framemodel + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>FRAME COLOR</td><td colspan='3'>" + framecolor + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>REASON FOR REFERRAL</td><td colspan='3'>" + resonforref + "</td></tr>");

        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>REASON FOR REFERRAL REMARK </td><td colspan='3'>" + refotherreason + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td> OVER ALL REMARK </td><td colspan='3'>" + man_overallremark + "</td></tr>");

        htmlBuilder.AppendLine("</table>");

        string generatedSummary = htmlBuilder.ToString();



        con.Open();

      
        studentid = Request.QueryString["studentID"];

        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        string table = "INSERT INTO ESO_CAMP_MANAGEMENT (ECM_STU_ID ,ECM_CHOOSE_VALUE ,ECM_CHOOSE_OTHER_REMARKS,ECM_OD ,ECM_OS,ECM_FRAME_SIZE,ECM_FRAME_MODEL,ECM_COLOR,ECM_REASON_REFERAL ,ECM_REFERAL_OTHER_REMARKS ,ECM_OVER_ALL_REMARKS ,ECM_MANAGEMENT_SUMMARY,ECM_CRT_UID ,ECM_CRT_DT ,ECM_LAST_UPD_UID ,ECM_LAST_UPD_DT)";
        table += "VALUES(@studentid,@cmchoosevalue,@otherremarks,@od,@os,@framesize,@framemodel,@color,@reasonreferal,@reasonotherremarks,@overallremarks,@managemenrsummary,@currentuserid,GETDATE(),@currentuserid,GETDATE())";

        SqlCommand cmd = new SqlCommand(table, con);

        cmd.Parameters.AddWithValue("@studentid", studentid);

        cmd.Parameters.AddWithValue("@cmchoosevalue", choosevalues);

        cmd.Parameters.AddWithValue("@otherremarks", chossvalremark);
        cmd.Parameters.AddWithValue("@od", odval);
        cmd.Parameters.AddWithValue("@os", osval);
        cmd.Parameters.AddWithValue("@framesize", framesize);
        cmd.Parameters.AddWithValue("@framemodel", framemodel);

        cmd.Parameters.AddWithValue("@color", framecolor);
        cmd.Parameters.AddWithValue("@reasonreferal", resonforref);

        cmd.Parameters.AddWithValue("@reasonotherremarks", refotherreason);
        cmd.Parameters.AddWithValue("@overallremarks", man_overallremark);
        cmd.Parameters.AddWithValue("@managemenrsummary", generatedSummary);

        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);


        cmd.ExecuteNonQuery();

        con.Close();

        //Response.Write("<script>alert('Data has been Submitted successfully')</script>");

        SummaryLiteral.Text = generatedSummary;

        save_btn.Visible = false;


        ubdate_btn.Visible = true;


    }



    protected void ubdate_btn_Click(object sender, EventArgs e)
    {

        string choosevalues = DropDownList1.SelectedItem.Text;

        string chossvalremark = chooseremark.Text;

        string odval = od_val_txt.Text;

        string osval = os_val_txt.Text;


        string framesize = frame_size_txt.Text;

        string framemodel = frame_model_txt.Text;

        string framecolor = frame_color_txt.Text;

        string resonforref = reasonforref.SelectedItem.Text;

        string refotherreason = otherReasonTextBox.Text;

        string man_overallremark = overallremarksTextBox.Text;


        StringBuilder htmlBuilder = new StringBuilder();
        htmlBuilder.AppendLine("<table cellspacing='1' cellpadding='1' border='0' width='50%'>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        htmlBuilder.AppendLine("<td colspan='4' align='center'> MANAGEMENT </td></tr>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        //htmlBuilder.AppendLine("<td><b>EYE</b></td><td><b>SPHERE</b></td><td><b>CYLINDER</b></td><td><b>AXIS</b></td><td>V/A</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>CHOOSE ANY ONE</td><td>" + choosevalues + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>CHOOSE ANY ONE OTHER REMARK </td><td>" + chossvalremark + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>OD</td><td>" + odval + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>OS</td><td>" + osval + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>FRAME SIZE</td><td>" + framesize + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>FRAME MODEL</td><td>" + framemodel + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>FRAME COLOR</td><td colspan='3'>" + framecolor + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>REASON FOR REFERRAL</td><td colspan='3'>" + resonforref + "</td></tr>");

        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>REASON FOR REFERRAL REMARK </td><td colspan='3'>" + refotherreason + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td> OVER ALL REMARK </td><td colspan='3'>" + man_overallremark + "</td></tr>");

        htmlBuilder.AppendLine("</table>");

        string generatedSummary = htmlBuilder.ToString();


        con.Open();

        studentid = Request.QueryString["studentID"];

        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        string table = " update ESO_CAMP_MANAGEMENT set ECM_CHOOSE_VALUE=@cmchoosevalue,ECM_CHOOSE_OTHER_REMARKS=@otherremarks,ECM_OD=@od,ECM_OS=@os,ECM_FRAME_SIZE=@framesize,ECM_FRAME_MODEL=@framemodel,ECM_COLOR=@color,ECM_REASON_REFERAL=@reasonreferal,ECM_REFERAL_OTHER_REMARKS=@reasonotherremarks,ECM_OVER_ALL_REMARKS=@overallremarks,ECM_MANAGEMENT_SUMMARY=@managemenrsummary,ECM_LAST_UPD_UID=@currentuserid,ECM_LAST_UPD_DT=GETDATE() where ECM_STU_ID=@studentid";
        table += " ";

        SqlCommand cmd = new SqlCommand(table, con);

        cmd.Parameters.AddWithValue("@studentid", studentid);

        cmd.Parameters.AddWithValue("@cmchoosevalue", choosevalues);

        cmd.Parameters.AddWithValue("@otherremarks", chossvalremark);

        cmd.Parameters.AddWithValue("@od", odval);
        cmd.Parameters.AddWithValue("@os", osval);
        cmd.Parameters.AddWithValue("@framesize", framesize);
        cmd.Parameters.AddWithValue("@framemodel", framemodel);

        cmd.Parameters.AddWithValue("@color", framecolor);
        cmd.Parameters.AddWithValue("@reasonreferal", resonforref);

        cmd.Parameters.AddWithValue("@reasonotherremarks", refotherreason);
        cmd.Parameters.AddWithValue("@overallremarks", man_overallremark);

        cmd.Parameters.AddWithValue("@managemenrsummary", generatedSummary);

        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);


        cmd.ExecuteNonQuery();


        con.Close();

        SummaryLiteral.Text = generatedSummary;

        //Response.Write("<script>alert('Data has been updated successfully')</script>");
    }
}