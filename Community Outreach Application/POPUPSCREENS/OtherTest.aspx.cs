using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class POPUPSCREENS_OtherTest : System.Web.UI.Page
{
    private string studentid;
    bool DataExist = false;
	SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
            studentid = Request.QueryString["studentID"];

            //Initially show only the first panel
            pnlScreen1.Visible = false;
			pnlScreen2.Visible = false;
			pnlScreen3.Visible = false;

            Hirschberg();
            CoverTestDistance();
            CoverTestNear();
            OcularMotilityod();
            OcularMotilityos();




            dbrdatafetchdata();
            covertestfetchdata();
            oculardatafetch();

        }
	}


    private void Hirschberg()
    {
        string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1 WITH (NOLOCK) WHERE MPM_PARAMETER_STATUS = 'A' AND MPM_PARAMETER_TYPE = 'SEHIRS' ORDER BY MPM_PARAMETER_VALUE  ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        chklstHirschbergTest.DataSource = dt;
        chklstHirschbergTest.DataBind();
        chklstHirschbergTest.DataTextField = "MPM_PARAMETER_VALUE";
        chklstHirschbergTest.DataValueField = "MPM_PARAMETER_CD";
        chklstHirschbergTest.DataBind();
        //chklstHirschbergTest.Items.Insert(0, new ListItem("---- Select ---- ", ""));

    }

    private void CoverTestDistance ()
    {
        string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1 WITH (NOLOCK) WHERE MPM_PARAMETER_STATUS = 'A' AND MPM_PARAMETER_TYPE = 'SECTNR'  ORDER BY MPM_PARAMETER_VALUE  ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        chklstDistance.DataSource = dt;
        chklstDistance.DataBind();
        chklstDistance.DataTextField = "MPM_PARAMETER_VALUE";
        chklstDistance.DataValueField = "MPM_PARAMETER_CD";
        chklstDistance.DataBind();
        //chklstDistance.Items.Insert(0, new ListItem("---- Select ---- ", ""));

    }

    private void CoverTestNear()
    {
        string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1 WITH (NOLOCK) WHERE MPM_PARAMETER_STATUS = 'A' AND MPM_PARAMETER_TYPE = 'SECTNR'  ORDER BY MPM_PARAMETER_VALUE  ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        chklstNear.DataSource = dt;
        chklstNear.DataBind();
        chklstNear.DataTextField = "MPM_PARAMETER_VALUE";
        chklstNear.DataValueField = "MPM_PARAMETER_CD";
        chklstNear.DataBind();
        //chklstNear.Items.Insert(0, new ListItem("---- Select ---- ", ""));

    }

    private void OcularMotilityod()
    {
        string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1 WITH (NOLOCK) WHERE MPM_PARAMETER_STATUS = 'A' AND MPM_PARAMETER_TYPE = 'EOM'  ORDER BY MPM_PARAMETER_VALUE ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        chklstODOcularMotility.DataSource = dt;
        chklstODOcularMotility.DataBind();
        chklstODOcularMotility.DataTextField = "MPM_PARAMETER_VALUE";
        chklstODOcularMotility.DataValueField = "MPM_PARAMETER_CD";
        chklstODOcularMotility.DataBind();
        //chklstNear.Items.Insert(0, new ListItem("---- Select ---- ", ""));

    }

    private void OcularMotilityos()
    {
        string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1 WITH (NOLOCK) WHERE MPM_PARAMETER_STATUS = 'A' AND MPM_PARAMETER_TYPE = 'EOM'  ORDER BY MPM_PARAMETER_VALUE ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        chklstOSOcularMotility.DataSource = dt;
        chklstOSOcularMotility.DataBind();
        chklstOSOcularMotility.DataTextField = "MPM_PARAMETER_VALUE";
        chklstOSOcularMotility.DataValueField = "MPM_PARAMETER_CD";
        chklstOSOcularMotility.DataBind();
        //chklstNear.Items.Insert(0, new ListItem("---- Select ---- ", ""));

    }


    protected void btnScreen1_Click(object sender, EventArgs e)
	{
		pnlScreen1.Visible = true;
		pnlScreen2.Visible = false;
		pnlScreen3.Visible = false;
	}

	protected void btnScreen2_Click(object sender, EventArgs e)
	{
		pnlScreen1.Visible = false;
		pnlScreen2.Visible = true;
		pnlScreen3.Visible = false;
	}

	protected void btnScreen3_Click(object sender, EventArgs e)
	{
		pnlScreen1.Visible = false;
		pnlScreen2.Visible = false;
		pnlScreen3.Visible = true;
	}

    private void dbrdatafetchdata()
    {
        string stser = "select * from ESO_CAMP_MR_DBR ";
        stser += " where ECMD_MR_STU_ID= '" + studentid + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(stser, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);


        if (ds.Tables[0].Rows.Count >= 1)
        {
            txtAxialLengthOD.Text = ds.Tables[0].Rows[0]["ECMD_AXIAL_LENGTH_OD"].ToString().TrimEnd().TrimStart();

            txtAxialLengthOS.Text = ds.Tables[0].Rows[0]["ECMD_AXIAL_LENGTH_OS"].ToString().TrimEnd().TrimStart();

            txtKeratometryODK1.Text = ds.Tables[0].Rows[0]["ECMD_KERATOMETRY_K1OD1"].ToString().TrimEnd().TrimStart();

            txtKeratometryOD2.Text = ds.Tables[0].Rows[0]["ECMD_KERATOMETRY_K1OD2"].ToString().TrimEnd().TrimStart();

            txtKeratometryOSK1.Text = ds.Tables[0].Rows[0]["ECMD_KERATOMETRY_K1OS1"].ToString().TrimEnd().TrimStart();

            txtKeratometryOS2.Text = ds.Tables[0].Rows[0]["ECMD_KERATOMETRY_K1OS2"].ToString().TrimEnd().TrimStart();

            txtKeratometryODK2.Text = ds.Tables[0].Rows[0]["ECMD_KERATOMETRY_K2OD1"].ToString().TrimEnd().TrimStart();

            txtKeratometryODk22.Text = ds.Tables[0].Rows[0]["ECMD_KERATOMETRY_K2OD2"].ToString().TrimEnd().TrimStart();

            txtKeratometryOSK2.Text = ds.Tables[0].Rows[0]["ECMD_KERATOMETRY_K2OS1"].ToString().TrimEnd().TrimStart();

            txtKeratometryOSk22.Text = ds.Tables[0].Rows[0]["ECMD_KERATOMETRY_K2OS2"].ToString().TrimEnd().TrimStart();
            
            radODKeratometryMethod.Text = ds.Tables[0].Rows[0]["ECMD_KERATOMETRY_METHOD_OD"].ToString().TrimEnd().TrimStart();
            
            radOSKeratometryMethod.Text = ds.Tables[0].Rows[0]["ECMD_KERATOMETRY_METHOD_OS"].ToString().TrimEnd().TrimStart();


            AnteriorChambeDepthod.Text = ds.Tables[0].Rows[0]["ECMD_ANTERIOR_CHAMBER_DEPTH_OD"].ToString().TrimEnd().TrimStart();

            AnteriorChambeDepthos.Text = ds.Tables[0].Rows[0]["ECMD_ANTERIOR_CHAMBER_DEPTH_OS"].ToString().TrimEnd().TrimStart();

            lensthicknessod.Text = ds.Tables[0].Rows[0]["ECMD_LENS_THICKNESS_OD"].ToString().TrimEnd().TrimStart();

            lensthicknessos.Text = ds.Tables[0].Rows[0]["ECMD_LENS_THICKNESS_OS"].ToString().TrimEnd().TrimStart();


            txtDBRRemarks.Text = ds.Tables[0].Rows[0]["ECMD_COMMENTS"].ToString().TrimEnd().TrimStart();




            Summaryfordbr.Text = ds.Tables[0].Rows[0]["ECMD_SUMMARY"].ToString().TrimEnd().TrimStart();


            CmdSave.Visible = false;
            update_btn.Visible = true;

        }
        else
        {
            CmdSave.Visible = true;
        }

        con.Close();
    }


    protected void CmdSave_Click(object sender, EventArgs e)
    {
        //string valdbrmrdno = "";
        //string dbrreqno = "";
        //string dbrsummary = "";
        string dbrvisitno = "VT01";

        string axixlengthOD = txtAxialLengthOD.Text;
        string axixlengthOS = txtAxialLengthOS.Text;

        string keratometryODK1 = txtKeratometryODK1.Text;
        string keratometryODK = txtKeratometryOD2.Text;

        string keratometryOSK1 = txtKeratometryOSK1.Text;
        string keratometryOSK = txtKeratometryOS2.Text;

        string keratometryODK2 = txtKeratometryODK2.Text;
        string keratometryODK22 = txtKeratometryODk22.Text;

        string keratometryOSK2 = txtKeratometryOSK2.Text;
        string keratometryOSK22 = txtKeratometryOSk22.Text;


        string KeratoMETHODOD = radODKeratometryMethod.SelectedValue;
        string KeratoMETHODOS = radOSKeratometryMethod.SelectedValue;


        string AnteriorChamberod = AnteriorChambeDepthod.Text;
        string AnteriorChamberos = AnteriorChambeDepthos.Text;

        string lensThicknessod = lensthicknessod.Text;
        string lensThicknessos = lensthicknessos.Text;



        string valdbrremark = txtDBRRemarks.Text;



        string Select_KeratoMETHODOD = KeratoMETHODOD;

        if(Select_KeratoMETHODOD=="A")
        {
            Select_KeratoMETHODOD = "Auto";
        }
        else if(Select_KeratoMETHODOD == "M")
        {
            Select_KeratoMETHODOD = "Manual";
        }
        else
        {
            Select_KeratoMETHODOD = "";
        }



        string Select_KeratoMETHODOS = KeratoMETHODOS;

        if (Select_KeratoMETHODOS == "A")
        {
            Select_KeratoMETHODOS = "Auto";
        }
        else if (Select_KeratoMETHODOS == "M")
        {
            Select_KeratoMETHODOS = "Manual";
        }
        else
        {
            Select_KeratoMETHODOS = "";
        }


        StringBuilder summaryHtml = new StringBuilder();
        summaryHtml.Append("<TABLE WIDTH='60%' CELLPADDING='0' CELLSPACING='1'>");
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        summaryHtml.Append("<TD colspan='5' align='center'>Digital Biometry Reader</TD></TR>");
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        summaryHtml.Append("<TD width='20%'></TD><TD width='30%'>OD</TD><TD width='40%'>OS</TD></TR>");

        // Insert Axial Length values
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<TD width='20%'><B>Axial Length</B></TD><TD>").Append(axixlengthOD).Append("<B>  mm</B></TD><TD>").Append(axixlengthOS).Append("<B>  mm</B></TD></TR>");

        // Insert K1 Reading values
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<TD width='20%'><B>K1 Reading(in Dioptres)</B></TD><TD width='30%'>").Append(keratometryODK1).Append("<B> D @ </B>").Append(keratometryODK).Append("</TD><TD width='40%'>").Append(keratometryOSK1).Append("<B> D @ </B>").Append(keratometryOSK).Append("</TD></TR>");

        // Insert K2 Reading values
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<TD width='20%'><B>K2 Reading(in Dioptres)</B></TD><TD width='30%'>").Append(keratometryODK2).Append("<B> D @ </B>").Append(keratometryODK22).Append("</TD><TD width='40%'>").Append(keratometryOSK2).Append("<B> D @ </B>").Append(keratometryOSK22).Append("</TD></TR>");

        // Insert Method values
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<TD width='20%'><B>Method</B></TD><TD width='35%' style='background-color:#F2CEFB'>").Append(Select_KeratoMETHODOD).Append("</TD><TD width='35%' style='background-color:#F2CEFB'>").Append(Select_KeratoMETHODOS).Append("</TD></TR>");

        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<TD width='20%'><B>Anterior Chamber Depth</B></TD><TD>").Append(AnteriorChamberod).Append("<B>  mm</B></TD><TD>").Append(AnteriorChamberos).Append("<B>  mm</B></TD></TR>");

        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<TD width='20%'><B>Anterior Chamber Depth</B></TD><TD>").Append(lensThicknessod).Append("<B>  mm</B></TD><TD>").Append(lensThicknessos).Append("<B>  mm</B></TD></TR>");

        // Add more rows as needed
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<td>Remarks</td><td colspan='3'>" + valdbrremark + "</td></tr>");

        summaryHtml.Append("</TABLE>");



        con.Open();
        studentid = Request.QueryString["studentID"];
        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        string table = "INSERT INTO ESO_CAMP_MR_DBR (ECMD_MR_STU_ID,ECMD_AXIAL_LENGTH_OD,ECMD_AXIAL_LENGTH_OS,ECMD_KERATOMETRY_K1OD1,ECMD_KERATOMETRY_K1OD2,ECMD_KERATOMETRY_K1OS1,ECMD_KERATOMETRY_K1OS2,ECMD_KERATOMETRY_K2OD1,ECMD_KERATOMETRY_K2OD2,ECMD_KERATOMETRY_K2OS1,ECMD_KERATOMETRY_K2OS2,ECMD_KERATOMETRY_METHOD_OD,ECMD_KERATOMETRY_METHOD_OS,ECMD_ANTERIOR_CHAMBER_DEPTH_OD,ECMD_ANTERIOR_CHAMBER_DEPTH_OS,ECMD_LENS_THICKNESS_OD,ECMD_LENS_THICKNESS_OS,ECMD_COMMENTS,ECMD_VISIT_NO,ECMD_SUMMARY,ECMD_CRT_UID,ECMD_CRT_DT,ECMD_LAST_UPD_UID,ECMD_LAST_UPD_DT)";
        table += "VALUES(@dbrstudentid,@axislenod,@axislenos,@keratometerk1od1,@keratometerk1od2,@keratometerk1os1,@keratometerk1os2,@keratometerk2od1,@keratometerk2od2,@keratometerk2os1,@keratometerk2os2,@keratometermethodod,@keratometermethodos,@anteriordepthod,@anteriordepthos,@lensthicknessod,@lensthicknessos,@dbrremark,@dbrvisitno,@summaryHtml,@currentuserid,GETDATE(),@currentuserid,GETDATE())";
        SqlCommand cmd = new SqlCommand(table, con);

        cmd.Parameters.AddWithValue("@dbrstudentid", studentid);

        //cmd.Parameters.AddWithValue("@dbrmrdno", valdbrmrdno);
        //cmd.Parameters.AddWithValue("@dbrreqestno", valdbrreqno);

        cmd.Parameters.AddWithValue("@axislenod", axixlengthOD);
        cmd.Parameters.AddWithValue("@axislenos", axixlengthOS);

        cmd.Parameters.AddWithValue("@keratometerk1od1", keratometryODK1);
        cmd.Parameters.AddWithValue("@keratometerk1od2", keratometryODK);

        cmd.Parameters.AddWithValue("@keratometerk1os1", keratometryOSK1);
        cmd.Parameters.AddWithValue("@keratometerk1os2", keratometryOSK);

        cmd.Parameters.AddWithValue("@keratometerk2od1", keratometryODK2);
        cmd.Parameters.AddWithValue("@keratometerk2od2", keratometryODK22);

        cmd.Parameters.AddWithValue("@keratometerk2os1", keratometryOSK2);
        cmd.Parameters.AddWithValue("@keratometerk2os2", keratometryOSK22);

        cmd.Parameters.AddWithValue("@keratometermethodod", KeratoMETHODOD);
        cmd.Parameters.AddWithValue("@keratometermethodos", KeratoMETHODOS);

        cmd.Parameters.AddWithValue("@anteriordepthod", AnteriorChamberod);
        cmd.Parameters.AddWithValue("@anteriordepthos", AnteriorChamberos);

        cmd.Parameters.AddWithValue("@lensthicknessod", lensThicknessod);
        cmd.Parameters.AddWithValue("@lensthicknessos", lensThicknessos);


        cmd.Parameters.AddWithValue("@dbrremark", valdbrremark);

        cmd.Parameters.AddWithValue("@dbrvisitno", dbrvisitno);

        cmd.Parameters.AddWithValue("@summaryHtml", summaryHtml.ToString());

        //cmd.Parameters.AddWithValue("@dbrsummary", valdbrsummary);


        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);


        cmd.ExecuteNonQuery();

        con.Close();

        Summaryfordbr.Text = summaryHtml.ToString();

        CmdSave.Visible = false;
        update_btn.Visible = true;
    }

    protected void update_btn_Click(object sender, EventArgs e)
    {
        //string valdbrmrdno = "";
        //string dbrreqno = "";
        //string dbrsummary = "";
        //string dbrvisitno = "";

        string axixlengthOD = txtAxialLengthOD.Text;
        string axixlengthOS = txtAxialLengthOS.Text;

        string keratometryODK1 = txtKeratometryODK1.Text;
        string keratometryODK = txtKeratometryOD2.Text;

        string keratometryOSK1 = txtKeratometryOSK1.Text;
        string keratometryOSK = txtKeratometryOS2.Text;

        string keratometryODK2 = txtKeratometryODK2.Text;
        string keratometryODK22 = txtKeratometryODk22.Text;

        string keratometryOSK2 = txtKeratometryOSK2.Text;
        string keratometryOSK22 = txtKeratometryOSk22.Text;



        string KeratoMETHODOD = radODKeratometryMethod.SelectedValue;
        string Select_KeratoMETHODOD = KeratoMETHODOD;

        if (Select_KeratoMETHODOD == "A")
        {
            Select_KeratoMETHODOD = "Auto";
        }
        else if (Select_KeratoMETHODOD == "M")
        {
            Select_KeratoMETHODOD = "Manual";
        }
        else
        {
            Select_KeratoMETHODOD = "";
        }


        string KeratoMETHODOS = radOSKeratometryMethod.SelectedValue;

        string Select_KeratoMETHODOS = KeratoMETHODOS;

        if (Select_KeratoMETHODOS == "A")
        {
            Select_KeratoMETHODOS = "Auto";
        }
        else if (Select_KeratoMETHODOS == "M")
        {
            Select_KeratoMETHODOS = "Manual";
        }
        else
        {
            Select_KeratoMETHODOS = "";
        }


        

        string AnteriorChamberod = AnteriorChambeDepthod.Text;
        string AnteriorChamberos = AnteriorChambeDepthos.Text;

        string lensThicknessod = lensthicknessod.Text;
        string lensThicknessos = lensthicknessos.Text;



        string valdbrremark = txtDBRRemarks.Text;

        StringBuilder summaryHtml = new StringBuilder();
        summaryHtml.Append("<TABLE WIDTH='60%' CELLPADDING='0' CELLSPACING='1'>");
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        summaryHtml.Append("<TD colspan='5' align='center'>Digital Biometry Reader</TD></TR>");
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 10pt; BACKGROUND-COLOR: #e5f4fb'>");
        summaryHtml.Append("<TD width='20%'></TD><TD width='30%'>OD</TD><TD width='40%'>OS</TD></TR>");

        // Insert Axial Length values
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<TD width='20%'><B>Axial Length</B></TD><TD>").Append(axixlengthOD).Append("<B>  mm</B></TD><TD>").Append(axixlengthOS).Append("<B>  mm</B></TD></TR>");

        // Insert K1 Reading values
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<TD width='20%'><B>K1 Reading(in Dioptres)</B></TD><TD width='30%'>").Append(keratometryODK1).Append("<B> D @ </B>").Append(keratometryODK).Append("</TD><TD width='40%'>").Append(keratometryOSK1).Append("<B> D @ </B>").Append(keratometryOSK).Append("</TD></TR>");

        // Insert K2 Reading values
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<TD width='20%'><B>K2 Reading(in Dioptres)</B></TD><TD width='30%'>").Append(keratometryODK2).Append("<B> D @ </B>").Append(keratometryODK22).Append("</TD><TD width='40%'>").Append(keratometryOSK2).Append("<B> D @ </B>").Append(keratometryOSK22).Append("</TD></TR>");

        // Insert Method values
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<TD width='20%'><B>Method</B></TD><TD width='35%' style='background-color:#F2CEFB'>").Append(Select_KeratoMETHODOD).Append("</TD><TD width='35%' style='background-color:#F2CEFB'>").Append(Select_KeratoMETHODOS).Append("</TD></TR>");


        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<TD width='20%'><B>Anterior Chamber Depth</B></TD><TD>").Append(AnteriorChamberod).Append("<B>  mm</B></TD><TD>").Append(AnteriorChamberos).Append("<B>  mm</B></TD></TR>");

        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<TD width='20%'><B>Anterior Chamber Depth</B></TD><TD>").Append(lensThicknessod).Append("<B>  mm</B></TD><TD>").Append(lensThicknessos).Append("<B>  mm</B></TD></TR>");

        // Add more rows as needed
        summaryHtml.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtml.Append("<td>Remarks</td><td colspan='3'>" + valdbrremark + "</td></tr>");

        summaryHtml.Append("</TABLE>");



        con.Open();

        studentid = Request.QueryString["studentID"];
        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];


        string table = "update  ESO_CAMP_MR_DBR set ECMD_AXIAL_LENGTH_OD=@axislenod, ECMD_AXIAL_LENGTH_OS=@axislenos, ECMD_KERATOMETRY_K1OD1=@keratometerk1od1, ECMD_KERATOMETRY_K1OD2=@keratometerk1od2, ECMD_KERATOMETRY_K1OS1=@keratometerk1os1,";
        table += " ECMD_KERATOMETRY_K1OS2=@keratometerk1os2, ECMD_KERATOMETRY_K2OD1=@keratometerk2od1, ECMD_KERATOMETRY_K2OD2=@keratometerk2od2, ECMD_KERATOMETRY_K2OS1=@keratometerk2os1,ECMD_KERATOMETRY_K2OS2=@keratometerk2os2,";
        table += " ECMD_KERATOMETRY_METHOD_OD=@keratometermethodod,ECMD_KERATOMETRY_METHOD_OS=@keratometermethodos,ECMD_ANTERIOR_CHAMBER_DEPTH_OD=@anteriordepthod,ECMD_ANTERIOR_CHAMBER_DEPTH_OS=@anteriordepthos,ECMD_LENS_THICKNESS_OD=@lensthicknessod,ECMD_LENS_THICKNESS_OS=@lensthicknessos,ECMD_COMMENTS=@dbrremark,ECMD_SUMMARY=@summaryHtml,ECMD_LAST_UPD_UID=@currentuserid,ECMD_LAST_UPD_DT=GETDATE() WHERE ECMD_MR_STU_ID=@dbrstudentid ";
       
        SqlCommand cmd = new SqlCommand(table, con);

        cmd.Parameters.AddWithValue("@dbrstudentid", studentid);

        //cmd.Parameters.AddWithValue("@dbrmrdno", valdbrmrdno);
        //cmd.Parameters.AddWithValue("@dbrreqestno", valdbrreqno);

        cmd.Parameters.AddWithValue("@axislenod", axixlengthOD);
        cmd.Parameters.AddWithValue("@axislenos", axixlengthOS);

        cmd.Parameters.AddWithValue("@keratometerk1od1", keratometryODK1);
        cmd.Parameters.AddWithValue("@keratometerk1od2", keratometryODK);

        cmd.Parameters.AddWithValue("@keratometerk1os1", keratometryOSK1);
        cmd.Parameters.AddWithValue("@keratometerk1os2", keratometryOSK);

        cmd.Parameters.AddWithValue("@keratometerk2od1", keratometryODK2);
        cmd.Parameters.AddWithValue("@keratometerk2od2", keratometryODK22);

        cmd.Parameters.AddWithValue("@keratometerk2os1", keratometryOSK2);
        cmd.Parameters.AddWithValue("@keratometerk2os2", keratometryOSK22);

        cmd.Parameters.AddWithValue("@keratometermethodod", KeratoMETHODOD);
        cmd.Parameters.AddWithValue("@keratometermethodos", KeratoMETHODOS);

        cmd.Parameters.AddWithValue("@anteriordepthod", AnteriorChamberod);
        cmd.Parameters.AddWithValue("@anteriordepthos", AnteriorChamberos);

        cmd.Parameters.AddWithValue("@lensthicknessod", lensThicknessod);
        cmd.Parameters.AddWithValue("@lensthicknessos", lensThicknessos);


        cmd.Parameters.AddWithValue("@dbrremark", valdbrremark);
        cmd.Parameters.AddWithValue("@summaryHtml", summaryHtml.ToString());

        //cmd.Parameters.AddWithValue("@dbrsummary", valdbrsummary);
        //cmd.Parameters.AddWithValue("@dbrvisitno", dbrvisitno);

        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);


        cmd.ExecuteNonQuery();

        con.Close();

        Summaryfordbr.Text = summaryHtml.ToString();
    }


    protected void covertest_btn_Click(object sender, EventArgs e)
    {

        string NEARPTACC = "";
        string NEARPTACCOS = "";
        string NEARPTACCOU = "";
        string NEARPTCON = "";
        string VISITNO = "VT01";



        string ectHirschbergTest = chklstHirschbergTest.SelectedValue;

        string ectHirschbergTestsum = "";

        if (chklstHirschbergTest.SelectedValue == "")
        {
            ectHirschbergTestsum = null;
        }
        else
        {
            ectHirschbergTestsum = chklstHirschbergTest.SelectedItem.Text;
        }


        string ectDistance = chklstDistance.SelectedValue;

        string ectDistancesum = "";

        if (chklstDistance.SelectedValue == "")
        {
            ectDistancesum = null;
        }
        else
        {
            ectDistancesum = chklstDistance.SelectedItem.Text;
        }




        string ectNear = chklstNear.SelectedValue;


        string ectNearsum = "";

        if (chklstNear.SelectedValue == "")
        {
            ectNearsum = null;
        }
        else
        {
            ectNearsum = chklstNear.SelectedItem.Text;
        }




        string ectBobiTest = cmb4BOBI.SelectedValue;

        //string ectBobiTestsum = cmb4BOBI.SelectedItem.Text;
        if (ectBobiTest == "sel")
        {
            ectBobiTest = "";
        }




        string ectOdOcularMotility = chklstODOcularMotility.SelectedValue;

        string ectOdOcularMotilitysum = "";

        if (chklstODOcularMotility.SelectedValue == "")
        {
            ectOdOcularMotilitysum = null;
        }
        else
        {
            ectOdOcularMotilitysum = chklstODOcularMotility.SelectedItem.Text;
        }


        string ectOsOcularMotility = chklstOSOcularMotility.SelectedValue;

        string ectOsOcularMotilitysum = "";

        if (chklstOSOcularMotility.SelectedValue == "")
        {
            ectOsOcularMotilitysum = null;
        }
        else
        {
            ectOsOcularMotilitysum = chklstOSOcularMotility.SelectedItem.Text;
        }




        StringBuilder summaryHtmlcover = new StringBuilder();

        // Start of Cover Test section
        summaryHtmlcover.Append("<TABLE WIDTH='60%' CELLPADDING='0' CELLSPACING='1'>");
        summaryHtmlcover.Append("<TR WIDTH='100%' style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 8pt; BACKGROUND-COLOR: IndianRed'>");
        summaryHtmlcover.Append("<TD colspan='3' align='center'>Cover Test</TD></TR>");
        summaryHtmlcover.Append("<TR></TR>");

        // Hirschberg Test
        summaryHtmlcover.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial ;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtmlcover.Append("<TD align='left' colspan='2' width='20%'><B>Hirschberg</B></TD><TD width='20%' colspan='1'>").Append(ectHirschbergTestsum).Append(" </TD></TR>");

        // CoverTestDistance
        summaryHtmlcover.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial ;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtmlcover.Append("<TD align='left' colspan='2' width='20%'><B>CoverTestDistance</B></TD><TD width='20%' colspan='1'>").Append(ectDistancesum).Append(" </TD></TR>");

        // CoverTestNear
        summaryHtmlcover.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial ;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtmlcover.Append("<TD align='left' colspan='2' width='20%'><B>CoverTestNear</B></TD><TD width='20%' colspan='1'>").Append(ectNearsum).Append(" </TD></TR>");

        // End of Cover Test section
        summaryHtmlcover.Append("</TABLE>");

        // Start of Ocular Movement section
        summaryHtmlcover.Append("<TABLE WIDTH='60%' CELLPADDING='0' CELLSPACING='1'>");
        summaryHtmlcover.Append("<TR WIDTH='100%' style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 8pt; BACKGROUND-COLOR: IndianRed'>");
        summaryHtmlcover.Append("<TD colspan='3' align='center'>Ocular Movement</TD></TR>");
        summaryHtmlcover.Append("<TR></TR>");

        // OcularMotility OD
        summaryHtmlcover.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial ;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtmlcover.Append("<TD align='left' colspan='2' width='20%'><B>OcularMotility OD</B></TD><TD width='20%' colspan='1'>").Append(ectOdOcularMotilitysum).Append(" </TD></TR>");

        // OcularMotility OS
        summaryHtmlcover.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial ;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtmlcover.Append("<TD align='left' colspan='2' width='20%'><B>OcularMotility OS</B></TD><TD width='20%' colspan='1'>").Append(ectOsOcularMotilitysum).Append(" </TD></TR>");

        // End of Ocular Movement section
        summaryHtmlcover.Append("</TABLE>");


        con.Open();
        studentid = Request.QueryString["studentID"];
        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        string table2 = "INSERT INTO ESO_COVER_TEST (ECT_STUDENT_ID,ECT_HIRSCHBERG_TEST,ECT_DISTANCE,ECT_NEAR,ECT_BOBI_TEST,ECT_OD_OCULAR_MOTILITY,ECT_OS_OCULAR_MOTILITY,ECT_NEAR_PT_ACC,ECT_NEAR_PT_ACC_OS,ECT_NEAR_PT_ACC_OU,ECT_NEAR_PT_CON,ECT_SUMMARY,ECT_VISIT_NO,ECT_CRT_UID,ECT_CRT_DT,ECT_LAST_UPD_UID,ECT_LAST_UPD_DT)";
        table2 += "VALUES(@ECT_STUDENT_ID,@ECT_HIRSCHBERG_TEST, @ECT_DISTANCE, @ECT_NEAR, @ECT_BOBI_TEST, @ECT_OD_OCULAR_MOTILITY, @ECT_OS_OCULAR_MOTILITY,@ECT_NEAR_PT_ACC,@ECT_NEAR_PT_ACC_OS,@ECT_NEAR_PT_ACC_OU,@ECT_NEAR_PT_CON,@ECT_SUMMARY,@ECT_VISIT_NO,@ECT_CRT_UID,GETDATE(),@ECT_CRT_UID,GETDATE())";
        SqlCommand cmd2 = new SqlCommand(table2, con);

        cmd2.Parameters.AddWithValue("@ECT_STUDENT_ID", studentid);

        cmd2.Parameters.AddWithValue("@ECT_HIRSCHBERG_TEST", ectHirschbergTest);
        cmd2.Parameters.AddWithValue("@ECT_DISTANCE", ectDistance);

        cmd2.Parameters.AddWithValue("@ECT_NEAR", ectNear);
        cmd2.Parameters.AddWithValue("@ECT_BOBI_TEST", ectBobiTest);

        cmd2.Parameters.AddWithValue("@ECT_OD_OCULAR_MOTILITY", ectOdOcularMotility);
        cmd2.Parameters.AddWithValue("@ECT_OS_OCULAR_MOTILITY", ectOsOcularMotility);




        cmd2.Parameters.AddWithValue("@ECT_NEAR_PT_ACC", NEARPTACC);
        cmd2.Parameters.AddWithValue("@ECT_NEAR_PT_ACC_OS", NEARPTACCOS);
        cmd2.Parameters.AddWithValue("@ECT_NEAR_PT_ACC_OU", NEARPTACCOU);
        cmd2.Parameters.AddWithValue("@ECT_NEAR_PT_CON", NEARPTCON);

        cmd2.Parameters.AddWithValue("@ECT_SUMMARY", summaryHtmlcover.ToString());

        cmd2.Parameters.AddWithValue("@ECT_VISIT_NO", VISITNO);

        cmd2.Parameters.AddWithValue("@ECT_CRT_UID", currentuserid);


        cmd2.ExecuteNonQuery();

        con.Close();

        summaryforcovertest.Text = summaryHtmlcover.ToString();

        covertest_btn.Visible = false;

        covertest_upt.Visible = true;
    }




    protected void covertest_upt_Click(object sender, EventArgs e)
    {
       




        string NEARPTACC = "";
        string NEARPTACCOS = "";
        string NEARPTACCOU = "";
        string NEARPTCON = "";
        string VISITNO = "VT01";



        string ectHirschbergTest = chklstHirschbergTest.SelectedValue;

        string ectHirschbergTestsum = "";

        if (chklstHirschbergTest.SelectedValue == "")
        {
            ectHirschbergTestsum = null;
        }
        else
        {
            ectHirschbergTestsum = chklstHirschbergTest.SelectedItem.Text;
        }


        string ectDistance = chklstDistance.SelectedValue;

        string ectDistancesum = "";

        if (chklstDistance.SelectedValue == "")
        {
            ectDistancesum = null;
        }
        else
        {
            ectDistancesum = chklstDistance.SelectedItem.Text;
        }




        string ectNear = chklstNear.SelectedValue;


        string ectNearsum = "";

        if (chklstNear.SelectedValue == "")
        {
            ectNearsum = null;
        }
        else
        {
            ectNearsum = chklstNear.SelectedItem.Text;
        }




        string ectBobiTest = cmb4BOBI.SelectedValue;

        //string ectBobiTestsum = cmb4BOBI.SelectedItem.Text;
        if (ectBobiTest == "sel")
        {
            ectBobiTest = "";
        }




        string ectOdOcularMotility = chklstODOcularMotility.SelectedValue;

        string ectOdOcularMotilitysum = "";

        if (chklstODOcularMotility.SelectedValue == "")
        {
            ectOdOcularMotilitysum = null;
        }
        else
        {
            ectOdOcularMotilitysum = chklstODOcularMotility.SelectedItem.Text;
        }


        string ectOsOcularMotility = chklstOSOcularMotility.SelectedValue;

        string ectOsOcularMotilitysum = "";

        if (chklstOSOcularMotility.SelectedValue == "")
        {
            ectOsOcularMotilitysum = null;
        }
        else
        {
            ectOsOcularMotilitysum = chklstOSOcularMotility.SelectedItem.Text;
        }


        StringBuilder summaryHtmlcover = new StringBuilder();

        // Start of Cover Test section
        summaryHtmlcover.Append("<TABLE WIDTH='60%' CELLPADDING='0' CELLSPACING='1'>");
        summaryHtmlcover.Append("<TR WIDTH='100%' style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 8pt; BACKGROUND-COLOR: IndianRed'>");
        summaryHtmlcover.Append("<TD colspan='3' align='center'>Cover Test</TD></TR>");
        summaryHtmlcover.Append("<TR></TR>");

        // Hirschberg Test
        summaryHtmlcover.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial ;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtmlcover.Append("<TD align='left' colspan='2' width='20%'><B>Hirschberg</B></TD><TD width='20%' colspan='1'>").Append(ectHirschbergTestsum).Append(" </TD></TR>");

        // CoverTestDistance
        summaryHtmlcover.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial ;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtmlcover.Append("<TD align='left' colspan='2' width='20%'><B>CoverTestDistance</B></TD><TD width='20%' colspan='1'>").Append(ectDistancesum).Append(" </TD></TR>");

        // CoverTestNear
        summaryHtmlcover.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial ;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtmlcover.Append("<TD align='left' colspan='2' width='20%'><B>CoverTestNear</B></TD><TD width='20%' colspan='1'>").Append(ectNearsum).Append(" </TD></TR>");

        // End of Cover Test section
        summaryHtmlcover.Append("</TABLE>");

        // Start of Ocular Movement section
        summaryHtmlcover.Append("<TABLE WIDTH='60%' CELLPADDING='0' CELLSPACING='1'>");
        summaryHtmlcover.Append("<TR WIDTH='100%' style='COLOR: black; FONT-FAMILY: Arial Black;FONT-SIZE: 8pt; BACKGROUND-COLOR: IndianRed'>");
        summaryHtmlcover.Append("<TD colspan='3' align='center'>Ocular Movement</TD></TR>");
        summaryHtmlcover.Append("<TR></TR>");

        // OcularMotility OD
        summaryHtmlcover.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial ;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtmlcover.Append("<TD align='left' colspan='2' width='20%'><B>OcularMotility OD</B></TD><TD width='20%' colspan='1'>").Append(ectOdOcularMotilitysum).Append(" </TD></TR>");

        // OcularMotility OS
        summaryHtmlcover.Append("<TR tabindex='1' style='COLOR: black; FONT-FAMILY: Arial ;FONT-SIZE: 8pt; BACKGROUND-COLOR: #f2f2f2'>");
        summaryHtmlcover.Append("<TD align='left' colspan='2' width='20%'><B>OcularMotility OS</B></TD><TD width='20%' colspan='1'>").Append(ectOsOcularMotilitysum).Append(" </TD></TR>");

        // End of Ocular Movement section
        summaryHtmlcover.Append("</TABLE>");


        con.Open();
        studentid = Request.QueryString["studentID"];
        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        string table2 = " update  ESO_COVER_TEST   set  ECT_HIRSCHBERG_TEST=@ECT_HIRSCHBERG_TEST,ECT_DISTANCE=@ECT_DISTANCE,ECT_NEAR=@ECT_NEAR,ECT_BOBI_TEST=@ECT_BOBI_TEST,ECT_OD_OCULAR_MOTILITY=@ECT_OD_OCULAR_MOTILITY,ECT_OS_OCULAR_MOTILITY=@ECT_OS_OCULAR_MOTILITY,";
        table2 += "ECT_NEAR_PT_ACC=@ECT_NEAR_PT_ACC,ECT_NEAR_PT_ACC_OS=@ECT_NEAR_PT_ACC_OS,ECT_NEAR_PT_ACC_OU=@ECT_NEAR_PT_ACC_OU,ECT_NEAR_PT_CON=@ECT_NEAR_PT_CON,ECT_SUMMARY=@ECT_SUMMARY,ECT_LAST_UPD_UID=@ECT_CRT_UID,ECT_LAST_UPD_DT=getdate() ";
        SqlCommand cmd2 = new SqlCommand(table2, con);

        cmd2.Parameters.AddWithValue("@ECT_STUDENT_ID", studentid);

        cmd2.Parameters.AddWithValue("@ECT_HIRSCHBERG_TEST", ectHirschbergTest);
        cmd2.Parameters.AddWithValue("@ECT_DISTANCE", ectDistance);

        cmd2.Parameters.AddWithValue("@ECT_NEAR", ectNear);
        cmd2.Parameters.AddWithValue("@ECT_BOBI_TEST", ectBobiTest);

        cmd2.Parameters.AddWithValue("@ECT_OD_OCULAR_MOTILITY", ectOdOcularMotility);
        cmd2.Parameters.AddWithValue("@ECT_OS_OCULAR_MOTILITY", ectOsOcularMotility);




        cmd2.Parameters.AddWithValue("@ECT_NEAR_PT_ACC", NEARPTACC);
        cmd2.Parameters.AddWithValue("@ECT_NEAR_PT_ACC_OS", NEARPTACCOS);
        cmd2.Parameters.AddWithValue("@ECT_NEAR_PT_ACC_OU", NEARPTACCOU);
        cmd2.Parameters.AddWithValue("@ECT_NEAR_PT_CON", NEARPTCON);

        cmd2.Parameters.AddWithValue("@ECT_SUMMARY", summaryHtmlcover.ToString());

        cmd2.Parameters.AddWithValue("@ECT_VISIT_NO", VISITNO);

        cmd2.Parameters.AddWithValue("@ECT_CRT_UID", currentuserid);


        cmd2.ExecuteNonQuery();

        con.Close();

        summaryforcovertest.Text = summaryHtmlcover.ToString();
    }



    private void covertestfetchdata()
    {
        string stser = " SELECT * FROM  ESO_COVER_TEST ";
        stser += " where ECT_STUDENT_ID= '" + studentid + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(stser, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);


        if (ds.Tables[0].Rows.Count >= 1)
        {
            chklstHirschbergTest.Text = ds.Tables[0].Rows[0]["ECT_HIRSCHBERG_TEST"].ToString().TrimEnd().TrimStart();

            chklstDistance.Text = ds.Tables[0].Rows[0]["ECT_DISTANCE"].ToString().TrimEnd().TrimStart();

            chklstNear.Text = ds.Tables[0].Rows[0]["ECT_NEAR"].ToString().TrimEnd().TrimStart();

            cmb4BOBI.Text = ds.Tables[0].Rows[0]["ECT_BOBI_TEST"].ToString().TrimEnd().TrimStart();

            chklstODOcularMotility.Text = ds.Tables[0].Rows[0]["ECT_OD_OCULAR_MOTILITY"].ToString().TrimEnd().TrimStart();

            chklstOSOcularMotility.Text = ds.Tables[0].Rows[0]["ECT_OS_OCULAR_MOTILITY"].ToString().TrimEnd().TrimStart();


            summaryforcovertest.Text = ds.Tables[0].Rows[0]["ECT_SUMMARY"].ToString().TrimEnd().TrimStart();


            covertest_btn.Visible = false;

            covertest_upt.Visible = true;

        }
        else
        {
            covertest_btn.Visible =true;
        }

        con.Close();
    }


    protected void OCULAR_BTN_Click(object sender, EventArgs e)
    {
        string ocularvalue = ocular_txt.Text;

        con.Open();
        studentid = Request.QueryString["studentID"];
        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        string table = "INSERT INTO ESO_CAMP_OCULAR_FINDINGS (ECOF_STUDENT_ID,ECOF_OCULAR_FINDINGS,ECOF_CRT_UID,ECOF_CRT_DT,ECOF_LAST_UPD_UID,ECOF_LAST_UPD_DT)";
        table += "VALUES(@ECOF_STUDENT_ID,@ECOF_OCULAR_FINDINGS,@ECOF_CRT_UID,GETDATE(),@ECOF_CRT_UID,GETDATE())";
        SqlCommand cmd = new SqlCommand(table, con);

        cmd.Parameters.AddWithValue("@ECOF_STUDENT_ID", studentid);


        cmd.Parameters.AddWithValue("@ECOF_OCULAR_FINDINGS", ocularvalue);
        
        cmd.Parameters.AddWithValue("@ECOF_CRT_UID", currentuserid);


        cmd.ExecuteNonQuery();

        con.Close();

        Response.Write("<script>alert('Data has been Submitted successfully')</script>");


        OCULAR_BTN.Visible = false;

        ocular_update_btn.Visible = true;

    }

    protected void ocular_update_btn_Click(object sender, EventArgs e)
    {
        string ocularvalue = ocular_txt.Text;

        con.Open();
        studentid = Request.QueryString["studentID"];
        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        string table = " UPDATE  ESO_CAMP_OCULAR_FINDINGS  SET  ECOF_OCULAR_FINDINGS=@ECOF_OCULAR_FINDINGS,ECOF_LAST_UPD_UID=@ECOF_CRT_UID,ECOF_LAST_UPD_DT=GETDATE() WHERE ECOF_STUDENT_ID=@ECOF_STUDENT_ID ";
       
        SqlCommand cmd = new SqlCommand(table, con);

        cmd.Parameters.AddWithValue("@ECOF_STUDENT_ID", studentid);


        cmd.Parameters.AddWithValue("@ECOF_OCULAR_FINDINGS", ocularvalue);

        cmd.Parameters.AddWithValue("@ECOF_CRT_UID", currentuserid);


        cmd.ExecuteNonQuery();

        con.Close();

        Response.Write("<script>alert('Data has been updated successfully')</script>");
    }


    private void oculardatafetch ()
    {
        string stser = " SELECT * FROM ESO_CAMP_OCULAR_FINDINGS  ";
        stser += " where ECOF_STUDENT_ID= '" + studentid + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(stser, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);


        if (ds.Tables[0].Rows.Count >= 1)
        {
            ocular_txt.Text = ds.Tables[0].Rows[0]["ECOF_OCULAR_FINDINGS"].ToString().TrimEnd().TrimStart();


            OCULAR_BTN.Visible = false;

            ocular_update_btn.Visible = true;



        }
        else
        {
            OCULAR_BTN.Visible = true;
        }

        con.Close();
    }
}