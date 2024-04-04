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

public partial class POPUPSCREENS_InterMediateVision : System.Web.UI.Page
{
	SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
    private string studentid;

    protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{

            studentid = Request.QueryString["studentID"];

            Intermediat_vision_Type_of_chart();

			Intermediat_vision_OD_WithoutGlass();
			Intermediat_vision_OD_WithGlass();
			Intermediat_vision_OD_Contact_lens();

			Intermediat_vision_OS_WithoutGlass();
			Intermediat_vision_OS_WithGlass();
			Intermediat_vision_OS_Contact_lens();

			Intermediat_vision_OU_WithoutGlass();
			Intermediat_vision_OU_WithGlass();
			Intermediat_vision_OU_Contact_lens();

            intermediatfetchdata();

           
        }
	}


    private void intermediatfetchdata()
    {
        string stser = "SELECT * from ESO_INTERMEDIATE_VISION_REFRACTION ";
        stser += "WHERE ECIV_STD_NUMBER = '" + studentid + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(stser, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);


        if (ds.Tables[0].Rows.Count >= 1)
        {
            DD_IV_Type_of_chart.Text = ds.Tables[0].Rows[0]["ECIV_TYPE_OF_CHART"].ToString().TrimEnd().TrimStart();

            DD_IV_OD_WithoutGlass.Text = ds.Tables[0].Rows[0]["ECIV_OD_WITHOUT_GLASS_DD"].ToString().TrimEnd().TrimStart();
            txt_IV_OD_WithoutGlass.Text = ds.Tables[0].Rows[0]["ECIV_OD_WITHOUT_GLASS"].ToString().TrimEnd().TrimStart();
            DD_IV_OD_WithGlass.Text = ds.Tables[0].Rows[0]["ECIV_OD_WITH_GLASS_DD"].ToString().TrimEnd().TrimStart();
            txt_IV_OD_WithGlass.Text = ds.Tables[0].Rows[0]["ECIV_OD_WITH_GLASS"].ToString().TrimEnd().TrimStart();
            DD_IV_OD_Contact_lens.Text = ds.Tables[0].Rows[0]["ECIV_OD_CONTACT_LENS_DD"].ToString().TrimEnd().TrimStart();
            txt_IV_OD_Contact_lens.Text = ds.Tables[0].Rows[0]["ECIV_OD_CONTACT_LENS"].ToString().TrimEnd().TrimStart();

            DD_IV_OS_WithoutGlass.Text = ds.Tables[0].Rows[0]["ECIV_OS_WITHOUT_GLASS_DD"].ToString().TrimEnd().TrimStart();
            txt_IV_OS_WithoutGlass.Text = ds.Tables[0].Rows[0]["ECIV_OS_WITHOUT_GLASS"].ToString().TrimEnd().TrimStart();
            DD_IV_OS_WithGlass.Text = ds.Tables[0].Rows[0]["ECIV_OS_WITH_GLASS_DD"].ToString().TrimEnd().TrimStart();
            txt_IV_OS_WithGlass.Text = ds.Tables[0].Rows[0]["ECIV_OS_WITH_GLASS"].ToString().TrimEnd().TrimStart();
            DD_IV_OS_Contact_lens.Text = ds.Tables[0].Rows[0]["ECIV_OS_CONTACT_LENS_DD"].ToString().TrimEnd().TrimStart();
            txt_IV_OS_Contact_lens.Text = ds.Tables[0].Rows[0]["ECIV_OS_CONTACT_LENS"].ToString().TrimEnd().TrimStart();

            DD_IV_OU_WithoutGlass.Text = ds.Tables[0].Rows[0]["ECIV_OU_WITHOUT_GLASS_DD"].ToString().TrimEnd().TrimStart();
            txt_IV_OU_WithoutGlass.Text = ds.Tables[0].Rows[0]["ECIV_OU_WITHOUT_GLASS"].ToString().TrimEnd().TrimStart();
            DD_IV_OU_WithGlass.Text = ds.Tables[0].Rows[0]["ECIV_OU_WITH_GLASS_DD"].ToString().TrimEnd().TrimStart();
            txt_IV_OU_WithGlass.Text = ds.Tables[0].Rows[0]["ECIV_OU_WITH_GLASS"].ToString().TrimEnd().TrimStart();
            DD_IV_OU_Contact_lens.Text = ds.Tables[0].Rows[0]["ECIV_OU_CONTACT_LENS_DD"].ToString().TrimEnd().TrimStart();
            txt_IV_OU_Contact_lens.Text = ds.Tables[0].Rows[0]["ECIV_OU_CONTACT_LENS"].ToString().TrimEnd().TrimStart();

            InterMediateTet.Text = ds.Tables[0].Rows[0]["ECIV_REMARKS"].ToString().TrimEnd().TrimStart();

            SummaryLiteral.Text = ds.Tables[0].Rows[0]["ECIV_SUMMARY"].ToString().TrimEnd().TrimStart();


            SAVE_BTN.Visible = false;
            modify_btn.Visible = true;

        }
        else
        {
            SAVE_BTN.Visible = true;
        }

        con.Close();
    }

    private void Intermediat_vision_Type_of_chart()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='TYPECH' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		DD_IV_Type_of_chart.DataSource = dt;
		DD_IV_Type_of_chart.DataBind();
		DD_IV_Type_of_chart.DataTextField = "MPM_PARAMETER_VALUE";
		DD_IV_Type_of_chart.DataValueField = "MPM_PARAMETER_CD";
		DD_IV_Type_of_chart.DataBind();
		DD_IV_Type_of_chart.Items.Insert(0, new ListItem("---- Select ---- ", ""));


	}



	private void Intermediat_vision_OD_WithoutGlass()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		DD_IV_OD_WithoutGlass.DataSource = dt;
		DD_IV_OD_WithoutGlass.DataBind();
		DD_IV_OD_WithoutGlass.DataTextField = "MPM_PARAMETER_VALUE";
		DD_IV_OD_WithoutGlass.DataValueField = "MPM_PARAMETER_CD";
		DD_IV_OD_WithoutGlass.DataBind();
		DD_IV_OD_WithoutGlass.Items.Insert(0, new ListItem("---- Select ---- ", ""));


	}

	// DD_IV_OD_WithGlass  
	private void Intermediat_vision_OD_WithGlass()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		DD_IV_OD_WithGlass.DataSource = dt;
		DD_IV_OD_WithGlass.DataBind();
		DD_IV_OD_WithGlass.DataTextField = "MPM_PARAMETER_VALUE";
		DD_IV_OD_WithGlass.DataValueField = "MPM_PARAMETER_CD";
		DD_IV_OD_WithGlass.DataBind();
		DD_IV_OD_WithGlass.Items.Insert(0, new ListItem("---- Select ---- ", ""));


	}



	// DD_IV_OD_Contact_lens
	private void Intermediat_vision_OD_Contact_lens()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		DD_IV_OD_Contact_lens.DataSource = dt;
		DD_IV_OD_Contact_lens.DataBind();
		DD_IV_OD_Contact_lens.DataTextField = "MPM_PARAMETER_VALUE";
		DD_IV_OD_Contact_lens.DataValueField = "MPM_PARAMETER_CD";
		DD_IV_OD_Contact_lens.DataBind();
		DD_IV_OD_Contact_lens.Items.Insert(0, new ListItem("---- Select ---- ", ""));


	}

	//DD_IV_OS_WithoutGlass

	private void Intermediat_vision_OS_WithoutGlass()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		DD_IV_OS_WithoutGlass.DataSource = dt;
		DD_IV_OS_WithoutGlass.DataBind();
		DD_IV_OS_WithoutGlass.DataTextField = "MPM_PARAMETER_VALUE";
		DD_IV_OS_WithoutGlass.DataValueField = "MPM_PARAMETER_CD";
		DD_IV_OS_WithoutGlass.DataBind();
		DD_IV_OS_WithoutGlass.Items.Insert(0, new ListItem("---- Select ---- ", ""));


	}
	//  DD_IV_OS_WithGlass
	private void Intermediat_vision_OS_WithGlass()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		DD_IV_OS_WithGlass.DataSource = dt;
		DD_IV_OS_WithGlass.DataBind();
		DD_IV_OS_WithGlass.DataTextField = "MPM_PARAMETER_VALUE";
		DD_IV_OS_WithGlass.DataValueField = "MPM_PARAMETER_CD";
		DD_IV_OS_WithGlass.DataBind();
		DD_IV_OS_WithGlass.Items.Insert(0, new ListItem("---- Select ---- ", ""));


	}
	//      DD_IV_OS_Contact_lens   
	private void Intermediat_vision_OS_Contact_lens()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		DD_IV_OS_Contact_lens.DataSource = dt;
		DD_IV_OS_Contact_lens.DataBind();
		DD_IV_OS_Contact_lens.DataTextField = "MPM_PARAMETER_VALUE";
		DD_IV_OS_Contact_lens.DataValueField = "MPM_PARAMETER_CD";
		DD_IV_OS_Contact_lens.DataBind();
		DD_IV_OS_Contact_lens.Items.Insert(0, new ListItem("---- Select ---- ", ""));


	}

	//DD_IV_OU_WithoutGlass

	private void Intermediat_vision_OU_WithoutGlass()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		DD_IV_OU_WithoutGlass.DataSource = dt;
		DD_IV_OU_WithoutGlass.DataBind();
		DD_IV_OU_WithoutGlass.DataTextField = "MPM_PARAMETER_VALUE";
		DD_IV_OU_WithoutGlass.DataValueField = "MPM_PARAMETER_CD";
		DD_IV_OU_WithoutGlass.DataBind();
		DD_IV_OU_WithoutGlass.Items.Insert(0, new ListItem("---- Select ---- ", ""));


	}
	// DD_IV_OU_WithGlass  
	private void Intermediat_vision_OU_WithGlass()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		DD_IV_OU_WithGlass.DataSource = dt;
		DD_IV_OU_WithGlass.DataBind();
		DD_IV_OU_WithGlass.DataTextField = "MPM_PARAMETER_VALUE";
		DD_IV_OU_WithGlass.DataValueField = "MPM_PARAMETER_CD";
		DD_IV_OU_WithGlass.DataBind();
		DD_IV_OU_WithGlass.Items.Insert(0, new ListItem("---- Select ---- ", ""));


	}

	//DD_IV_OU_Contact_lens
	private void Intermediat_vision_OU_Contact_lens()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		DD_IV_OU_Contact_lens.DataSource = dt;
		DD_IV_OU_Contact_lens.DataBind();
		DD_IV_OU_Contact_lens.DataTextField = "MPM_PARAMETER_VALUE";
		DD_IV_OU_Contact_lens.DataValueField = "MPM_PARAMETER_CD";
		DD_IV_OU_Contact_lens.DataBind();
		DD_IV_OU_Contact_lens.Items.Insert(0, new ListItem("---- Select ---- ", ""));


	}

	protected void SaveDataToDatabase()
	{
		string IVTypeofchart = DD_IV_Type_of_chart.SelectedValue;
		string selectIVTypeofchart = DD_IV_Type_of_chart.SelectedItem.Text;
       
        if (selectIVTypeofchart == "---- Select ---- ")
        {
            selectIVTypeofchart = "";
        }

        // OD PART 
        string IVODWithoutGlass = DD_IV_OD_WithoutGlass.SelectedValue;
		string selectIVODWithoutGlass = DD_IV_OD_WithoutGlass.SelectedItem.Text;
        if (selectIVODWithoutGlass == "---- Select ---- ")
        {
            selectIVODWithoutGlass = "";
        }

        string IVODWithoutGlass_txt = txt_IV_OD_WithoutGlass.Text;

		string IVODWithGlass = DD_IV_OD_WithGlass.SelectedValue;
		string selectIVODWithGlass = DD_IV_OD_WithGlass.SelectedItem.Text;
        if (selectIVODWithGlass == "---- Select ---- ")
        {
            selectIVODWithGlass = "";
        }

        string IVODWithGlass_txt = txt_IV_OD_WithGlass.Text;

		string IVODContactlens = DD_IV_OD_Contact_lens.SelectedValue;
		string selectIVODContactlens = DD_IV_OD_Contact_lens.SelectedItem.Text;
        if (selectIVODContactlens == "---- Select ---- ")
        {
            selectIVODContactlens = "";
        }

        string IVODContactlens_txt = txt_IV_OD_Contact_lens.Text;

		// OS PART 
		string IVOSWithoutGlass = DD_IV_OS_WithoutGlass.SelectedValue;
		string selectIVOSWithoutGlass = DD_IV_OS_WithoutGlass.SelectedItem.Text;
        if (selectIVOSWithoutGlass == "---- Select ---- ")
        {
            selectIVOSWithoutGlass = "";
        }

        string IVOSWithoutGlass_txt = txt_IV_OS_WithoutGlass.Text;

		string IVOSWithGlass = DD_IV_OS_WithGlass.SelectedValue;
		string selectIVOSWithGlass = DD_IV_OS_WithGlass.SelectedItem.Text;
        if (selectIVOSWithGlass == "---- Select ---- ")
        {
            selectIVOSWithGlass = "";
        }

        string IVOSWithGlass_txt = txt_IV_OS_WithGlass.Text;

		string IVOSContact_lens = DD_IV_OS_Contact_lens.SelectedValue;
		string selectIVOSContact_lens = DD_IV_OS_Contact_lens.SelectedItem.Text;
        if (selectIVOSContact_lens == "---- Select ---- ")
        {
            selectIVOSContact_lens = "";
        }

        string IVOSContactlens_txt = txt_IV_OS_Contact_lens.Text;

		// OU PART 
		string IVOUWithoutGlass = DD_IV_OU_WithoutGlass.SelectedValue;
		string selectIVOUWithoutGlass = DD_IV_OU_WithoutGlass.SelectedItem.Text;
        if (selectIVOUWithoutGlass == "---- Select ---- ")
        {
            selectIVOUWithoutGlass = "";
        }

        string IVOUWithoutGlass_txt = txt_IV_OU_WithoutGlass.Text;

		string IVOUWithGlass = DD_IV_OU_WithGlass.SelectedValue;
		string selectIVOUWithGlass = DD_IV_OU_WithGlass.SelectedItem.Text;
        if (selectIVOUWithGlass == "---- Select ---- ")
        {
            selectIVOUWithGlass = "";
        }

        string IVOUWithGlass_txt = txt_IV_OU_WithGlass.Text;

		string IVOUContact_lens = DD_IV_OU_Contact_lens.SelectedValue;
		string selectIVOUContact_lens = DD_IV_OU_Contact_lens.SelectedItem.Text;
        if (selectIVOUContact_lens == "---- Select ---- ")
        {
            selectIVOUContact_lens = "";
        }

        string IVOUContact_lens_txt = txt_IV_OU_Contact_lens.Text;

		string IVREMARKS = InterMediateTet.Text;

        string VISITNO = "VT01";

		// Generate the HTML table summary
		StringBuilder htmlBuilder = new StringBuilder();
		htmlBuilder.AppendLine("<table cellspacing='1' cellpadding='1' border='0' width='50%'>");
		htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
		htmlBuilder.AppendLine("<td colspan='7' align='center'>Intermediate Vision</td></tr>");
		htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'></tr>");
		htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
		htmlBuilder.AppendLine("<td colspan='3' align='right'>Type of Chart</td><td colspan='4' align='left'>" + selectIVTypeofchart + "</td></tr>");
		htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 8pt; BACKGROUND-COLOR: #e5f4fb'>");
		htmlBuilder.AppendLine("<td><b>EYE</b></td><td colspan='2'><b>WITHOUT GLASS</b></td><td colspan='2'><b>WITH GLASS</b></td>");
		htmlBuilder.AppendLine("<td colspan='2'><b>WITH CL</b></td></tr>");
		htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
		htmlBuilder.AppendLine("<td>OD</td><td>" + selectIVODWithoutGlass + "</td><td>" + IVODWithoutGlass_txt + "</td><td>" + selectIVODWithGlass + "</td><td>" + IVODWithGlass_txt + "</td><td>" + selectIVODContactlens + "</td><td>" + IVODContactlens_txt + "</td></tr>");
		htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
		htmlBuilder.AppendLine("<td>OS</td><td>" + selectIVOSWithoutGlass + "</td><td>" + IVOSWithoutGlass_txt + "</td><td>" + selectIVOSWithGlass + "</td><td>" + IVOSWithGlass_txt + "</td><td>" + selectIVOSContact_lens + "</td><td>" + IVOSContactlens_txt + "</td></tr>");
		htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
		htmlBuilder.AppendLine("<td>OU</td><td>" + selectIVOUWithoutGlass + "</td><td>" + IVOUWithoutGlass_txt + "</td><td>" + selectIVOUWithGlass + "</td><td>" + IVOUWithGlass_txt + "</td><td>" + selectIVOUContact_lens + "</td><td>" + IVOUContact_lens_txt + "</td></tr>");
		htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
		htmlBuilder.AppendLine("<td>Remarks</td><td colspan='6'>" + IVREMARKS + "</td></tr>");
		htmlBuilder.AppendLine("</table>");

		// Set the generated HTML as the value of htmlsummary
		string generatedSummary = htmlBuilder.ToString();

        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];
        string studentid = Request.QueryString["studentID"];

        con.Open();


		string table = "INSERT INTO ESO_INTERMEDIATE_VISION_REFRACTION (ECIV_STD_NUMBER,ECIV_TYPE_OF_CHART, ECIV_OD_WITHOUT_GLASS_DD, ECIV_OD_WITHOUT_GLASS,ECIV_OD_WITH_GLASS_DD,ECIV_OD_WITH_GLASS,ECIV_OD_CONTACT_LENS_DD,";
		table += "ECIV_OD_CONTACT_LENS,ECIV_OS_WITHOUT_GLASS_DD,ECIV_OS_WITHOUT_GLASS,ECIV_OS_WITH_GLASS_DD,ECIV_OS_WITH_GLASS,ECIV_OS_CONTACT_LENS_DD,ECIV_OS_CONTACT_LENS,";
		table += "ECIV_OU_WITHOUT_GLASS_DD,ECIV_OU_WITHOUT_GLASS,ECIV_OU_WITH_GLASS_DD,ECIV_OU_WITH_GLASS,ECIV_OU_CONTACT_LENS_DD,ECIV_OU_CONTACT_LENS,ECIV_REMARKS,ECIV_SUMMARY,ECIV_VISIT_NO,ECIV_CRT_UID,ECIV_CRT_DT,ECIV_LAST_UPD_UID,ECIV_LAST_UPD_DT)";
		table += " VALUES(@studentid,@IVTypeofchart,@IVODWithoutGlass,@IVODWithoutGlass_txt,@IVODWithGlass,@IVODWithGlass_txt,@IVODContactlens,@IVODContactlens_txt,";
		table += "@IVOSWithoutGlass,@IVOSWithoutGlass_txt,@IVOSWithGlass,@IVOSWithGlass_txt,@IVOSContact_lens,@IVOSContactlens_txt,@IVOUWithoutGlass,@IVOUWithoutGlass_txt,@IVOUWithGlass,";
		table += "@IVOUWithGlass_txt,@IVOUContact_lens,@IVOUContact_lens_txt,@IVREMARKS,@intermediatesummary,@intvisit,@currentuserid,GETDATE(),@currentuserid,GETDATE())";


		SqlCommand cmd = new SqlCommand(table, con);

        cmd.Parameters.AddWithValue("@studentid", studentid);

        cmd.Parameters.AddWithValue("@IVTypeofchart", IVTypeofchart);
		cmd.Parameters.AddWithValue("@IVODWithoutGlass", IVODWithoutGlass);
		cmd.Parameters.AddWithValue("@IVODWithoutGlass_txt", IVODWithoutGlass_txt);
		cmd.Parameters.AddWithValue("@IVODWithGlass", IVODWithGlass);
		cmd.Parameters.AddWithValue("@IVODWithGlass_txt", IVODWithGlass_txt);
		cmd.Parameters.AddWithValue("@IVODContactlens", IVODContactlens);
		cmd.Parameters.AddWithValue("@IVODContactlens_txt", IVODContactlens_txt);

		cmd.Parameters.AddWithValue("@IVOSWithoutGlass", IVOSWithoutGlass);
		cmd.Parameters.AddWithValue("@IVOSWithoutGlass_txt", IVOSWithoutGlass_txt);
		cmd.Parameters.AddWithValue("@IVOSWithGlass", IVOSWithGlass);
		cmd.Parameters.AddWithValue("@IVOSWithGlass_txt", IVOSWithGlass_txt);
		cmd.Parameters.AddWithValue("@IVOSContact_lens", IVOSContact_lens);
		cmd.Parameters.AddWithValue("@IVOSContactlens_txt", IVOSContactlens_txt);


		cmd.Parameters.AddWithValue("@IVOUWithoutGlass", IVOUWithoutGlass);
		cmd.Parameters.AddWithValue("@IVOUWithoutGlass_txt", IVOUWithoutGlass_txt);
		cmd.Parameters.AddWithValue("@IVOUWithGlass", IVOUWithGlass);
		cmd.Parameters.AddWithValue("@IVOUWithGlass_txt", IVOUWithGlass_txt);
		cmd.Parameters.AddWithValue("@IVOUContact_lens", IVOUContact_lens);
		cmd.Parameters.AddWithValue("@IVOUContact_lens_txt", IVOUContact_lens_txt);

		cmd.Parameters.AddWithValue("@IVREMARKS", IVREMARKS);

		cmd.Parameters.AddWithValue("@intermediatesummary", generatedSummary);

        cmd.Parameters.AddWithValue("@intvisit", VISITNO);

        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);

        cmd.ExecuteNonQuery();

		con.Close();

		SummaryLiteral.Text = generatedSummary;

        SAVE_BTN.Visible = false;

        modify_btn.Visible = true;
    }




	protected void SAVE_BTN_Click(object sender, EventArgs e)
	{
		SaveDataToDatabase();
	}


    //modify_btn_Click


    protected void modify_btn_Click(object sender, EventArgs e)
    {
        string IVTypeofchart = DD_IV_Type_of_chart.SelectedValue;
        string selectIVTypeofchart = DD_IV_Type_of_chart.SelectedItem.Text;

        if (selectIVTypeofchart == "---- Select ---- ")
        {
            selectIVTypeofchart = "";
        }

        // OD PART 
        string IVODWithoutGlass = DD_IV_OD_WithoutGlass.SelectedValue;
        string selectIVODWithoutGlass = DD_IV_OD_WithoutGlass.SelectedItem.Text;
        if (selectIVODWithoutGlass == "---- Select ---- ")
        {
            selectIVODWithoutGlass = "";
        }

        string IVODWithoutGlass_txt = txt_IV_OD_WithoutGlass.Text;

        string IVODWithGlass = DD_IV_OD_WithGlass.SelectedValue;
        string selectIVODWithGlass = DD_IV_OD_WithGlass.SelectedItem.Text;
        if (selectIVODWithGlass == "---- Select ---- ")
        {
            selectIVODWithGlass = "";
        }

        string IVODWithGlass_txt = txt_IV_OD_WithGlass.Text;

        string IVODContactlens = DD_IV_OD_Contact_lens.SelectedValue;
        string selectIVODContactlens = DD_IV_OD_Contact_lens.SelectedItem.Text;
        if (selectIVODContactlens == "---- Select ---- ")
        {
            selectIVODContactlens = "";
        }

        string IVODContactlens_txt = txt_IV_OD_Contact_lens.Text;

        // OS PART 
        string IVOSWithoutGlass = DD_IV_OS_WithoutGlass.SelectedValue;
        string selectIVOSWithoutGlass = DD_IV_OS_WithoutGlass.SelectedItem.Text;
        if (selectIVOSWithoutGlass == "---- Select ---- ")
        {
            selectIVOSWithoutGlass = "";
        }

        string IVOSWithoutGlass_txt = txt_IV_OS_WithoutGlass.Text;

        string IVOSWithGlass = DD_IV_OS_WithGlass.SelectedValue;
        string selectIVOSWithGlass = DD_IV_OS_WithGlass.SelectedItem.Text;
        if (selectIVOSWithGlass == "---- Select ---- ")
        {
            selectIVOSWithGlass = "";
        }

        string IVOSWithGlass_txt = txt_IV_OS_WithGlass.Text;

        string IVOSContact_lens = DD_IV_OS_Contact_lens.SelectedValue;
        string selectIVOSContact_lens = DD_IV_OS_Contact_lens.SelectedItem.Text;
        if (selectIVOSContact_lens == "---- Select ---- ")
        {
            selectIVOSContact_lens = "";
        }

        string IVOSContactlens_txt = txt_IV_OS_Contact_lens.Text;

        // OU PART 
        string IVOUWithoutGlass = DD_IV_OU_WithoutGlass.SelectedValue;
        string selectIVOUWithoutGlass = DD_IV_OU_WithoutGlass.SelectedItem.Text;
        if (selectIVOUWithoutGlass == "---- Select ---- ")
        {
            selectIVOUWithoutGlass = "";
        }

        string IVOUWithoutGlass_txt = txt_IV_OU_WithoutGlass.Text;

        string IVOUWithGlass = DD_IV_OU_WithGlass.SelectedValue;
        string selectIVOUWithGlass = DD_IV_OU_WithGlass.SelectedItem.Text;
        if (selectIVOUWithGlass == "---- Select ---- ")
        {
            selectIVOUWithGlass = "";
        }

        string IVOUWithGlass_txt = txt_IV_OU_WithGlass.Text;

        string IVOUContact_lens = DD_IV_OU_Contact_lens.SelectedValue;
        string selectIVOUContact_lens = DD_IV_OU_Contact_lens.SelectedItem.Text;
        if (selectIVOUContact_lens == "---- Select ---- ")
        {
            selectIVOUContact_lens = "";
        }

        string IVOUContact_lens_txt = txt_IV_OU_Contact_lens.Text;

        string IVREMARKS = InterMediateTet.Text;

        // Generate the HTML table summary
        StringBuilder htmlBuilder = new StringBuilder();
        htmlBuilder.AppendLine("<table cellspacing='1' cellpadding='1' border='0' width='50%'>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        htmlBuilder.AppendLine("<td colspan='7' align='center'>Intermediate Vision</td></tr>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td colspan='3' align='right'>Type of Chart</td><td colspan='4' align='left'>" + selectIVTypeofchart + "</td></tr>");
        htmlBuilder.AppendLine("<tr style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 8pt; BACKGROUND-COLOR: #e5f4fb'>");
        htmlBuilder.AppendLine("<td><b>EYE</b></td><td colspan='2'><b>WITHOUT GLASS</b></td><td colspan='2'><b>WITH GLASS</b></td>");
        htmlBuilder.AppendLine("<td colspan='2'><b>WITH CL</b></td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>OD</td><td>" + selectIVODWithoutGlass + "</td><td>" + IVODWithoutGlass_txt + "</td><td>" + selectIVODWithGlass + "</td><td>" + IVODWithGlass_txt + "</td><td>" + selectIVODContactlens + "</td><td>" + IVODContactlens_txt + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>OS</td><td>" + selectIVOSWithoutGlass + "</td><td>" + IVOSWithoutGlass_txt + "</td><td>" + selectIVOSWithGlass + "</td><td>" + IVOSWithGlass_txt + "</td><td>" + selectIVOSContact_lens + "</td><td>" + IVOSContactlens_txt + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>OU</td><td>" + selectIVOUWithoutGlass + "</td><td>" + IVOUWithoutGlass_txt + "</td><td>" + selectIVOUWithGlass + "</td><td>" + IVOUWithGlass_txt + "</td><td>" + selectIVOUContact_lens + "</td><td>" + IVOUContact_lens_txt + "</td></tr>");
        htmlBuilder.AppendLine("<tr tabindex='0' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        htmlBuilder.AppendLine("<td>Remarks</td><td colspan='6'>" + IVREMARKS + "</td></tr>");
        htmlBuilder.AppendLine("</table>");

        // Set the generated HTML as the value of htmlsummary
        string generatedSummary = htmlBuilder.ToString();

        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];
        string studentid = Request.QueryString["studentID"];

        con.Open();


        string table = "UPDATE ESO_INTERMEDIATE_VISION_REFRACTION  SET ECIV_TYPE_OF_CHART=@IVTypeofchart,ECIV_OD_WITHOUT_GLASS_DD=@IVODWithoutGlass,ECIV_OD_WITHOUT_GLASS=@IVODWithoutGlass_txt,ECIV_OD_WITH_GLASS_DD=@IVODWithGlass,";
        table += "ECIV_OD_WITH_GLASS = @IVODWithGlass_txt,ECIV_OD_CONTACT_LENS_DD = @IVODContactlens,ECIV_OD_CONTACT_LENS = @IVODContactlens_txt,ECIV_OS_WITHOUT_GLASS_DD = @IVOSWithoutGlass,ECIV_OS_WITHOUT_GLASS = @IVOSWithoutGlass_txt,";
        table += "ECIV_OS_WITH_GLASS_DD = @IVOSWithGlass,ECIV_OS_WITH_GLASS = @IVOSWithGlass_txt,ECIV_OS_CONTACT_LENS_DD = @IVOSContact_lens,ECIV_OS_CONTACT_LENS = @IVOSContactlens_txt,ECIV_OU_WITHOUT_GLASS_DD = @IVOUWithoutGlass,ECIV_OU_WITHOUT_GLASS = @IVOUWithoutGlass_txt,";
        table += "ECIV_OU_WITH_GLASS_DD = @IVOUWithGlass,ECIV_OU_WITH_GLASS = @IVOUWithGlass_txt,ECIV_OU_CONTACT_LENS_DD = @IVOUContact_lens,ECIV_OU_CONTACT_LENS = @IVOUContact_lens_txt,ECIV_REMARKS = @IVREMARKS,ECIV_SUMMARY = @intermediatesummary,ECIV_LAST_UPD_UID = @currentuserid,ECIV_LAST_UPD_DT = GETDATE()";
        table += "WHERE ECIV_STD_NUMBER = @studentid";

        SqlCommand cmd = new SqlCommand(table, con);

        cmd.Parameters.AddWithValue("@studentid", studentid);

        cmd.Parameters.AddWithValue("@IVTypeofchart", IVTypeofchart);
        cmd.Parameters.AddWithValue("@IVODWithoutGlass", IVODWithoutGlass);
        cmd.Parameters.AddWithValue("@IVODWithoutGlass_txt", IVODWithoutGlass_txt);
        cmd.Parameters.AddWithValue("@IVODWithGlass", IVODWithGlass);
        cmd.Parameters.AddWithValue("@IVODWithGlass_txt", IVODWithGlass_txt);
        cmd.Parameters.AddWithValue("@IVODContactlens", IVODContactlens);
        cmd.Parameters.AddWithValue("@IVODContactlens_txt", IVODContactlens_txt);

        cmd.Parameters.AddWithValue("@IVOSWithoutGlass", IVOSWithoutGlass);
        cmd.Parameters.AddWithValue("@IVOSWithoutGlass_txt", IVOSWithoutGlass_txt);
        cmd.Parameters.AddWithValue("@IVOSWithGlass", IVOSWithGlass);
        cmd.Parameters.AddWithValue("@IVOSWithGlass_txt", IVOSWithGlass_txt);
        cmd.Parameters.AddWithValue("@IVOSContact_lens", IVOSContact_lens);
        cmd.Parameters.AddWithValue("@IVOSContactlens_txt", IVOSContactlens_txt);


        cmd.Parameters.AddWithValue("@IVOUWithoutGlass", IVOUWithoutGlass);
        cmd.Parameters.AddWithValue("@IVOUWithoutGlass_txt", IVOUWithoutGlass_txt);
        cmd.Parameters.AddWithValue("@IVOUWithGlass", IVOUWithGlass);
        cmd.Parameters.AddWithValue("@IVOUWithGlass_txt", IVOUWithGlass_txt);
        cmd.Parameters.AddWithValue("@IVOUContact_lens", IVOUContact_lens);
        cmd.Parameters.AddWithValue("@IVOUContact_lens_txt", IVOUContact_lens_txt);

        cmd.Parameters.AddWithValue("@IVREMARKS", IVREMARKS);

        cmd.Parameters.AddWithValue("@intermediatesummary", generatedSummary);

        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);

        cmd.ExecuteNonQuery();

        con.Close();

        SummaryLiteral.Text = generatedSummary;
    }








    }