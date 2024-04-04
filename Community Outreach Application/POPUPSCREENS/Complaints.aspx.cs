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

public partial class POPUPSCREENS_Complaints : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
    private string studentid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            studentid = Request.QueryString["studentID"];

            complainfetchdata();

        }

    }

    private void complainfetchdata()
    {
        string stser = "select * from ESO_CAMP_MR_COMPLAINTS ";
        stser += "WHERE ECMC_STD_NUMBER = '" + studentid + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(stser, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);


        if (ds.Tables[0].Rows.Count >= 1)
        {
            Diminision_vision.Text = ds.Tables[0].Rows[0]["ECMC_DIMI_OF_VISION"].ToString().TrimEnd().TrimStart();

            Watering_eye.Text = ds.Tables[0].Rows[0]["ECMC_WATER_OF_EYES"].ToString().TrimEnd().TrimStart();
            red_itc_irrita.Text = ds.Tables[0].Rows[0]["ECMC_REDNESS"].ToString().TrimEnd().TrimStart();
            Sustained_swell.Text = ds.Tables[0].Rows[0]["ECMC_SUSTAINED_LIDS"].ToString().TrimEnd().TrimStart();
            complain_other.Text = ds.Tables[0].Rows[0]["ECMC_OTHER"].ToString().TrimEnd().TrimStart();

            SummaryLiteral.Text = ds.Tables[0].Rows[0]["ECMC_COMPLAINTS_SUMMARY"].ToString().TrimEnd().TrimStart();

            complaint_save.Visible = false;

            modify_btn.Visible = true;


        }
        else
        {
            complaint_save.Visible = true;
        }

        con.Close();
    }

    protected void complaint_save_Click(object sender, EventArgs e)
    {
        string Diminisionvision = Diminision_vision.SelectedValue;
        string WateringEye = Watering_eye.SelectedValue;
        string Redness = red_itc_irrita.SelectedValue;
        string Sustained = Sustained_swell.SelectedValue;
        string Other = complain_other.Text;

        StringBuilder htmlBuilder = new StringBuilder();
        htmlBuilder.AppendLine("<table cellspacing='1' cellpadding='1' border='0' width='50%'>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        htmlBuilder.AppendLine("<td colspan='4' align='center'> COMPLAINTS  </td></tr>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        //htmlBuilder.AppendLine("<td><b>EYE</b></td><td><b>SPHERE</b></td><td><b>CYLINDER</b></td><td><b>AXIS</b></td><td>V/A</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Diminision of vision</td><td>" + Diminisionvision + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Watering of eyes</td><td>" + WateringEye + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Redness/ Itching/ Irritation</td><td>" + Redness + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Sustained swelling on lids</td><td>" + Sustained + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Others</td><td>" + Other + "</td></tr>");

        htmlBuilder.AppendLine("</table>");

        // Set the generated HTML as the value of htmlsummary
        string generatedSummary = htmlBuilder.ToString();


        string studentid = Request.QueryString["studentID"];

        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];


        con.Open();

        string table = "INSERT INTO ESO_CAMP_MR_COMPLAINTS (ECMC_STD_NUMBER,ECMC_DIMI_OF_VISION, ECMC_WATER_OF_EYES, ECMC_REDNESS,ECMC_SUSTAINED_LIDS,ECMC_OTHER,ECMC_COMPLAINTS_SUMMARY,ECMC_CRT_UID,ECMC_CRT_DT,ECMC_LAST_UPD_UID,ECMC_LAST_UPD_DT)";
        table += "VALUES(@studentid,@Diminisionvision,@WateringEye,@Redness,@Sustained,@Other,@complaintsummary,@currentuserid,GETDATE(),@currentuserid,GETDATE())";

        SqlCommand cmd = new SqlCommand(table, con);

        cmd.Parameters.AddWithValue("@studentid", studentid);

        cmd.Parameters.AddWithValue("@Diminisionvision", Diminisionvision);
        cmd.Parameters.AddWithValue("@WateringEye", WateringEye);
        cmd.Parameters.AddWithValue("@Redness", Redness);
        cmd.Parameters.AddWithValue("@Sustained", Sustained);
        cmd.Parameters.AddWithValue("@Other", Other);
        cmd.Parameters.AddWithValue("@complaintsummary", generatedSummary);
        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);


        cmd.ExecuteNonQuery();

        con.Close();

        SummaryLiteral.Text = generatedSummary;

        complaint_save.Visible = false;

        modify_btn.Visible = true;
    }


    //complaint_modify_Click

    protected void complaint_modify_Click(object sender, EventArgs e)
    {
        string Diminisionvision = Diminision_vision.SelectedValue;
        string WateringEye = Watering_eye.SelectedValue;
        string Redness = red_itc_irrita.SelectedValue;
        string Sustained = Sustained_swell.SelectedValue;
        string Other = complain_other.Text;

        StringBuilder htmlBuilder = new StringBuilder();
        htmlBuilder.AppendLine("<table cellspacing='1' cellpadding='1' border='0' width='50%'>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        htmlBuilder.AppendLine("<td colspan='4' align='center'> COMPLAINTS  </td></tr>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        //htmlBuilder.AppendLine("<td><b>EYE</b></td><td><b>SPHERE</b></td><td><b>CYLINDER</b></td><td><b>AXIS</b></td><td>V/A</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Diminision of vision</td><td>" + Diminisionvision + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Watering of eyes</td><td>" + WateringEye + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Redness/ Itching/ Irritation</td><td>" + Redness + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Sustained swelling on lids</td><td>" + Sustained + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Others</td><td>" + Other + "</td></tr>");

        htmlBuilder.AppendLine("</table>");

        // Set the generated HTML as the value of htmlsummary
        string generatedSummary = htmlBuilder.ToString();


        string studentid = Request.QueryString["studentID"];

        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];


        con.Open();

        string table = "UPDATE ESO_CAMP_MR_COMPLAINTS SET ECMC_DIMI_OF_VISION=@Diminisionvision,ECMC_WATER_OF_EYES=@WateringEye, ECMC_REDNESS=@Redness,";
        table += "ECMC_SUSTAINED_LIDS = @Sustained,ECMC_OTHER = @Other,ECMC_COMPLAINTS_SUMMARY = @complaintsummary,ECMC_LAST_UPD_UID = @currentuserid,ECMC_LAST_UPD_DT = GETDATE() WHERE ECMC_STD_NUMBER = @studentid";
        SqlCommand cmd = new SqlCommand(table, con);

        cmd.Parameters.AddWithValue("@studentid", studentid);

        cmd.Parameters.AddWithValue("@Diminisionvision", Diminisionvision);
        cmd.Parameters.AddWithValue("@WateringEye", WateringEye);
        cmd.Parameters.AddWithValue("@Redness", Redness);
        cmd.Parameters.AddWithValue("@Sustained", Sustained);
        cmd.Parameters.AddWithValue("@Other", Other);
        cmd.Parameters.AddWithValue("@complaintsummary", generatedSummary);
        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);


        cmd.ExecuteNonQuery();

        con.Close();

        SummaryLiteral.Text = generatedSummary;
    }




}