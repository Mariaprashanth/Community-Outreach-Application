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

public partial class POPUPSCREENS_OcularHistory : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
    private string studentid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            studentid = Request.QueryString["studentID"];
            ocularhistoryfetchdata();
        }
    }

    private void ocularhistoryfetchdata()
    {
        string stser = "SELECT * FROM ESO_CAMP_MR_OCULAR_HISTORY ";
        stser += "WHERE ECMO_STD_NUMBER = '" + studentid + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(stser, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);


        if (ds.Tables[0].Rows.Count >= 1)
        {
            Injury_drop.Text = ds.Tables[0].Rows[0]["ECMO_INJURY"].ToString().TrimEnd().TrimStart();

            cracker_pen.Text = ds.Tables[0].Rows[0]["ECMO_TYPE_OF_INJURY"].ToString().TrimEnd().TrimStart();
            Previous_treat.Text = ds.Tables[0].Rows[0]["ECOM_PREVIOUS_TREATMENT"].ToString().TrimEnd().TrimStart();
            Ocular_surgery.Text = ds.Tables[0].Rows[0]["ECOM_OCULAR_SURGERY"].ToString().TrimEnd().TrimStart();
            detail_surgery.Text = ds.Tables[0].Rows[0]["ECOM_DETAILS_OF_SURGERY"].ToString().TrimEnd().TrimStart();
            Previous_consul.Text = ds.Tables[0].Rows[0]["ECOM_PREVIOUS_CONSULTATION"].ToString().TrimEnd().TrimStart();
            under_treatment.Text = ds.Tables[0].Rows[0]["ECOM_CLT_UNDER_TREATMENT"].ToString().TrimEnd().TrimStart();
            information_collected_from.Text = ds.Tables[0].Rows[0]["ECOM_INFO_COL_FROM"].ToString().TrimEnd().TrimStart();
            SummaryLiteral.Text = ds.Tables[0].Rows[0]["ECOM_OCULAR_SUMMARY"].ToString().TrimEnd().TrimStart();


            ocular_save.Visible = false;

            ocular_modify_btn.Visible = true;

        }
        else
        {
            ocular_save.Visible = true;
        }


        con.Close();
    }

    protected void ocular_save_Click(object sender, EventArgs e)
    {
        string Injurydrop = Injury_drop.SelectedValue;
        string TypeofInjury = cracker_pen.Text;
        string Previoustreatment = Previous_treat.Text;
        string OcularSurgery = Ocular_surgery.SelectedValue;
        string Detailsofsurgery = detail_surgery.Text;
        string Previousconsultation = Previous_consul.Text;
        string Currentlyundertreatment = under_treatment.SelectedValue;
        string Informationcollectedfrom = information_collected_from.SelectedValue;


        StringBuilder htmlBuilder = new StringBuilder();
        htmlBuilder.AppendLine("<table cellspacing='1' cellpadding='1' border='0' width='50%'>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        htmlBuilder.AppendLine("<td colspan='4' align='center'> OCULAR HISTORY </td></tr>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        //htmlBuilder.AppendLine("<td><b>EYE</b></td><td><b>SPHERE</b></td><td><b>CYLINDER</b></td><td><b>AXIS</b></td><td>V/A</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Injury</td><td>" + Injurydrop + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Type of injury (Cracker/Pen/Needle/Stick/Stone/RTA/Chemical)</td><td>" + TypeofInjury + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Previous treatment</td><td>" + Previoustreatment + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Ocular surgery</td><td>" + OcularSurgery + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Details of surgery (Ptosis/Cataract/ strabismus)</td><td>" + Detailsofsurgery + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Previous consultation</td><td>" + Previousconsultation + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Currently under treatment</td><td colspan='3'>" + Currentlyundertreatment + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Information collected from</td><td colspan='3'>" + Informationcollectedfrom + "</td></tr>");

        htmlBuilder.AppendLine("</table>");

        // Set the generated HTML as the value of htmlsummary
        string generatedSummary = htmlBuilder.ToString();


        string studentid = Request.QueryString["studentID"];

        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        con.Open();

        string table = "INSERT INTO ESO_CAMP_MR_OCULAR_HISTORY (ECMO_STD_NUMBER,ECMO_INJURY, ECMO_TYPE_OF_INJURY, ECOM_PREVIOUS_TREATMENT,ECOM_OCULAR_SURGERY,ECOM_DETAILS_OF_SURGERY,ECOM_PREVIOUS_CONSULTATION,ECOM_CLT_UNDER_TREATMENT,ECOM_INFO_COL_FROM,ECOM_OCULAR_SUMMARY,ECOM_CRT_UID,ECOM_CRT_DT,ECOM_LAST_UPD_UID,ECOM_LAST_UPD_DT)";
        table += "VALUES(@studentid,@Injurydrop,@TypeofInjury,@Previoustreatment,@OcularSurgery,@Detailsofsurgery,@Previousconsultation,@Currentlyundertreatment,@Informationcollectedfrom,@ocularsummary,@currentuserid,GETDATE(),@currentuserid,GETDATE())";

        SqlCommand cmd = new SqlCommand(table, con);


        cmd.Parameters.AddWithValue("@studentid", studentid);
        cmd.Parameters.AddWithValue("@Injurydrop", Injurydrop);
        cmd.Parameters.AddWithValue("@TypeofInjury", TypeofInjury);
        cmd.Parameters.AddWithValue("@Previoustreatment", Previoustreatment);
        cmd.Parameters.AddWithValue("@OcularSurgery", OcularSurgery);
        cmd.Parameters.AddWithValue("@Detailsofsurgery", Detailsofsurgery);

        cmd.Parameters.AddWithValue("@Previousconsultation", Previousconsultation);
        cmd.Parameters.AddWithValue("@Currentlyundertreatment", Currentlyundertreatment);
        cmd.Parameters.AddWithValue("@Informationcollectedfrom", Informationcollectedfrom);
        cmd.Parameters.AddWithValue("@ocularsummary", generatedSummary);

        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);


        cmd.ExecuteNonQuery();

        con.Close();

        SummaryLiteral.Text = generatedSummary;

        ocular_save.Visible = false;

        ocular_modify_btn.Visible = true;
    }

    //ocular_modify_btn_Click


    protected void ocular_modify_btn_Click(object sender, EventArgs e)
    {
        string Injurydrop = Injury_drop.SelectedValue;
        string TypeofInjury = cracker_pen.Text;
        string Previoustreatment = Previous_treat.Text;
        string OcularSurgery = Ocular_surgery.SelectedValue;
        string Detailsofsurgery = detail_surgery.Text;
        string Previousconsultation = Previous_consul.Text;
        string Currentlyundertreatment = under_treatment.SelectedValue;
        string Informationcollectedfrom = information_collected_from.SelectedValue;


        StringBuilder htmlBuilder = new StringBuilder();
        htmlBuilder.AppendLine("<table cellspacing='1' cellpadding='1' border='0' width='50%'>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        htmlBuilder.AppendLine("<td colspan='4' align='center'> OCULAR HISTORY </td></tr>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        //htmlBuilder.AppendLine("<td><b>EYE</b></td><td><b>SPHERE</b></td><td><b>CYLINDER</b></td><td><b>AXIS</b></td><td>V/A</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Injury</td><td>" + Injurydrop + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Type of injury (Cracker/Pen/Needle/Stick/Stone/RTA/Chemical)</td><td>" + TypeofInjury + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Previous treatment</td><td>" + Previoustreatment + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Ocular surgery</td><td>" + OcularSurgery + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Details of surgery (Ptosis/Cataract/ strabismus)</td><td>" + Detailsofsurgery + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Previous consultation</td><td>" + Previousconsultation + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Currently under treatment</td><td colspan='3'>" + Currentlyundertreatment + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Information collected from</td><td colspan='3'>" + Informationcollectedfrom + "</td></tr>");

        htmlBuilder.AppendLine("</table>");

        // Set the generated HTML as the value of htmlsummary
        string generatedSummary = htmlBuilder.ToString();


        string studentid = Request.QueryString["studentID"];

        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        con.Open();

        string table = "UPDATE ESO_CAMP_MR_OCULAR_HISTORY  SET ECMO_INJURY=@Injurydrop,ECMO_TYPE_OF_INJURY=@TypeofInjury, ECOM_PREVIOUS_TREATMENT=@Previoustreatment,ECOM_OCULAR_SURGERY=@OcularSurgery,ECOM_DETAILS_OF_SURGERY=@Detailsofsurgery,";
        table += "ECOM_PREVIOUS_CONSULTATION = @Previousconsultation,ECOM_CLT_UNDER_TREATMENT = @Currentlyundertreatment,ECOM_INFO_COL_FROM = @Informationcollectedfrom,ECOM_OCULAR_SUMMARY = @ocularsummary,ECOM_LAST_UPD_UID = @currentuserid,ECOM_LAST_UPD_DT = GETDATE() WHERE ECMO_STD_NUMBER = @studentid";
        SqlCommand cmd = new SqlCommand(table, con);


        cmd.Parameters.AddWithValue("@studentid", studentid);
        cmd.Parameters.AddWithValue("@Injurydrop", Injurydrop);
        cmd.Parameters.AddWithValue("@TypeofInjury", TypeofInjury);
        cmd.Parameters.AddWithValue("@Previoustreatment", Previoustreatment);
        cmd.Parameters.AddWithValue("@OcularSurgery", OcularSurgery);
        cmd.Parameters.AddWithValue("@Detailsofsurgery", Detailsofsurgery);

        cmd.Parameters.AddWithValue("@Previousconsultation", Previousconsultation);
        cmd.Parameters.AddWithValue("@Currentlyundertreatment", Currentlyundertreatment);
        cmd.Parameters.AddWithValue("@Informationcollectedfrom", Informationcollectedfrom);
        cmd.Parameters.AddWithValue("@ocularsummary", generatedSummary);
        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);


        cmd.ExecuteNonQuery();

        con.Close();

        SummaryLiteral.Text = generatedSummary;
    }





}