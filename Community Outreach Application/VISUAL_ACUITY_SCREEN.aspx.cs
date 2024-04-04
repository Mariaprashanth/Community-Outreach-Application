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
using System.Web.Services;
using System.Web.UI;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Configuration;

public partial class VISUAL_ACUITY_SCREEN : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
   // string connectionString = "Data Source=SNDB;Initial Catalog=snliveit;User Id=snappuser;Password=$@NkaR@app;";

    private string studentid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

             studentid = Request.QueryString["studentID"];

            

            odwithoutglassdv();
            odwithoutglassnv();
            odwithglassdv();
            odwithglassnv();
            OdWithoutContactdv();
            OdWithoutContactnv();
            Withphod();
            oswithglassdv();
            oswithglassnv();
            osWithoutContactnv();
            osWithoutContactdv();
            oswithglassnv();
            oswithglassdv();
            oswithoutglassnv();
            oswithoutglassdv();
            Withphos();

            ouwithoutglassdv();
            ouwithoutglassnv();
            ouwithglassdv();
            ouwithglassnv();
            OuWithoutContactdv();
            OuWithoutContactnv();
            Withphou();

            Quality_of_Reflex_OD();

            Quality_of_Reflex_OS();

            Distance_Vision_BCVA_OD();
            ADD_BCVA_NV_OD();


            Distance_Vision_BCVA_OS();
            ADD_BCVA_NV_OS();

            Proposed_Prism_OD();
            Proposed1_Prism_OD();
            Proposed_Prism_OS();
            Proposed1_Prism_OS();

            Refining_Procedure_OD();
            Refining_Procedure_OS();

            Intermediate_Vision_OD();
            Intermediate_Vision_OS();

            Type_of_chart();
            Near_Vision_chart();

           

            AcceptanceADD_OS();
            AcceptanceDistanceVision_OS();
            AcceptanceADD_OD();
            AcceptanceDistanceVision_OD();


           

            
            BaseDirectionODvalue();
            BaseDirectionOS1();
            LensType_OD1();
            LensType_OS1();


            pgpfetchdata();

            pgfetchdata();


        }

    }

  

    private void pgfetchdata()
    {
        string stser = "select * from ESO_CAMP_MR_PG ";
        stser += "WHERE ECMPG_STD_NUMBER = '" + studentid + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(stser, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet d = new DataSet();
        da.Fill(d);


        //int rowIndex = 0;


        

        if (d.Tables[0].Rows.Count >= 1)
        {


            string ecmpgDate = d.Tables[0].Rows[0]["ECMPG_DATE"].ToString().TrimEnd().TrimStart();

            
            string[] dateComponents = ecmpgDate.Split('/');

            if (dateComponents.Length == 3)
            {
                
                string day = dateComponents[0];
                string month = dateComponents[1];
                string year = dateComponents[2];

                
                DayDropdown_OD.SelectedValue = day;
                monthDropdown_OD.SelectedValue = month;
                yearOD.Text = year;
            }

            Spherical_OD.Text = d.Tables[0].Rows[0]["ECMPG_SPHERICAL"].ToString().TrimEnd().TrimStart();
            Cylindrical_OD.Text = d.Tables[0].Rows[0]["ECMPG_CYLINDRICAL"].ToString().TrimEnd().TrimStart();
            Axis_OD.Text = d.Tables[0].Rows[0]["ECMPG_AXIS"].ToString().TrimEnd().TrimStart();
            Add_OD.Text = d.Tables[0].Rows[0]["ECMPG_ADD"].ToString().TrimEnd().TrimStart();
            Prism_OD.Text = d.Tables[0].Rows[0]["ECMPG_PRISM"].ToString().TrimEnd().TrimStart();
            BaseDirectionOD.SelectedValue = d.Tables[0].Rows[0]["ECMPG_MUSCLE_POWER"].ToString().TrimEnd().TrimStart();
            LensType_OD.Text = d.Tables[0].Rows[0]["ECMPG_LENS_TYPE"].ToString().TrimEnd().TrimStart();
            GlassStatus_OD.Text = d.Tables[0].Rows[0]["ECMPG_GLASS_STATUS_CODE"].ToString().TrimEnd().TrimStart();
            Remarks_OD.Text = d.Tables[0].Rows[0]["ECMPG_REMARKS"].ToString().TrimEnd().TrimStart();



            string ecmpgDate1 = d.Tables[0].Rows[1]["ECMPG_DATE"].ToString().TrimEnd().TrimStart();


            string[] dateComponents1 = ecmpgDate1.Split('/');

            if (dateComponents1.Length == 3)
            {

                string day1 = dateComponents1[0];
                string month1 = dateComponents1[1];
                string year1 = dateComponents1[2];


                DayDropdown_OS.SelectedValue = day1;
                MonthDropdown_OS.SelectedValue = month1;
                yearOS.Text = year1;
            }
            Spherical_OS.Text = d.Tables[0].Rows[1]["ECMPG_SPHERICAL"].ToString().TrimEnd().TrimStart();
            Cylindrical_OS.Text = d.Tables[0].Rows[1]["ECMPG_CYLINDRICAL"].ToString().TrimEnd().TrimStart();
            Axis_OS.Text = d.Tables[0].Rows[1]["ECMPG_AXIS"].ToString().TrimEnd().TrimStart();
            Add_OS.Text = d.Tables[0].Rows[1]["ECMPG_ADD"].ToString().TrimEnd().TrimStart();
            Prism_OS.Text = d.Tables[0].Rows[1]["ECMPG_PRISM"].ToString().TrimEnd().TrimStart();
            BaseDirectionOS.SelectedValue = d.Tables[0].Rows[1]["ECMPG_MUSCLE_POWER"].ToString().TrimEnd().TrimStart();
           LensType_OS.Text = d.Tables[0].Rows[1]["ECMPG_LENS_TYPE"].ToString().TrimEnd().TrimStart();
            GlassStatus_OS.Text = d.Tables[0].Rows[1]["ECMPG_GLASS_STATUS_CODE"].ToString().TrimEnd().TrimStart();
            Remarks_OS.Text = d.Tables[0].Rows[1]["ECMPG_REMARKS"].ToString().TrimEnd().TrimStart();


            btnSave8.Visible = false;
            btnmod.Visible = true;
        }
        else
        {
            btnSave8.Visible = true;
        }

    }

   


    private void BaseDirectionODvalue()
    {
        string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPMP' ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);


        BaseDirectionOD.DataSource = dt;
        BaseDirectionOD.DataTextField = "MPM_PARAMETER_VALUE";
        BaseDirectionOD.DataValueField = "MPM_PARAMETER_CD";
        BaseDirectionOD.DataBind();
        BaseDirectionOD.Items.Insert(0, new ListItem("---- Select ---- ", ""));

       




    }



    private void BaseDirectionOS1()
    {
        string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPMP' ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);


        BaseDirectionOS.DataSource = dt;
        BaseDirectionOS.DataTextField = "MPM_PARAMETER_VALUE";
        BaseDirectionOS.DataValueField = "MPM_PARAMETER_CD";
        BaseDirectionOS.DataBind();


        BaseDirectionOS.Items.Insert(0, new ListItem("---- Select ---- ", ""));


       
    }


    private void LensType_OD1()
    {
        string com = "SELECT MPM_PARAMETER_CD, MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1 WHERE MPM_PARAMETER_TYPE = 'TYPLEN'";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);

        // Bind data to the dropdown only once.
        LensType_OD.DataSource = dt;
        LensType_OD.DataTextField = "MPM_PARAMETER_VALUE";
        LensType_OD.DataValueField = "MPM_PARAMETER_CD";
        LensType_OD.DataBind();

        // Add the initial "Select" option.
        LensType_OD.Items.Insert(0, new ListItem("---- Select ---- ", ""));
    }

    private void LensType_OS1()
    {
        string com = "SELECT MPM_PARAMETER_CD, MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1 WHERE MPM_PARAMETER_TYPE = 'TYPLEN'";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);

        // Bind data to the dropdown only once.
        LensType_OS.DataSource = dt;
        LensType_OS.DataTextField = "MPM_PARAMETER_VALUE";
        LensType_OS.DataValueField = "MPM_PARAMETER_CD";
        LensType_OS.DataBind();

        // Add the initial "Select" option.
        LensType_OS.Items.Insert(0, new ListItem("---- Select ---- ", ""));
    }



    private void pgpfetchdata()
    {
        string stser = "select * from ESO_CAMP_MR_PGP ";
        stser += "WHERE ECMP_STD_NUMBER = '" + studentid + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(stser, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);


        if (ds.Tables[0].Rows.Count >= 1)
        {
            cmbVcOdWithoutGlass.Text = ds.Tables[0].Rows[0]["ECMP_VC_OD_WITHOUT_GLASS"].ToString().TrimEnd().TrimStart();
            cmbVcOdWithoutNearvision.Text = ds.Tables[0].Rows[0]["ECMP_VC_OD_WITHOUT_NEARVISION"].ToString().TrimEnd().TrimStart();
            txtVcOdWithoutDistance.Text = ds.Tables[0].Rows[0]["ECMP_VC_OD_WITHOUT_DISTANCE"].ToString().TrimEnd().TrimStart();
            cmbVcOdWithGlass.Text = ds.Tables[0].Rows[0]["ECMP_VC_OD_WITH_GLASS"].ToString().TrimEnd().TrimStart();
            cmbVcOdWithNearvision.Text = ds.Tables[0].Rows[0]["ECMP_VC_OD_WITH_NEARVISION"].ToString().TrimEnd().TrimStart();
            txtVcOdWithDistance.Text = ds.Tables[0].Rows[0]["ECMP_VC_OD_WITH_DISTANCE"].ToString().TrimEnd().TrimStart();
            cmbVcOdWithoutContact.Text = ds.Tables[0].Rows[0]["ECMP_OD_DISTANCE_CONTACT"].ToString().TrimEnd().TrimStart();
            cmbVcOdContact.Text = ds.Tables[0].Rows[0]["ECMP_OD_NEAR_CONTACT"].ToString().TrimEnd().TrimStart();
            txtVcOdContact.Text = ds.Tables[0].Rows[0]["ECMP_OD_DISTANCE_TEXT_CONTACT"].ToString().TrimEnd().TrimStart();
            cmbVcOdPinhole.Text = ds.Tables[0].Rows[0]["ECMP_VC_OD_PINHOLE"].ToString().TrimEnd().TrimStart();



            cmbVcOsWithoutGlass.Text = ds.Tables[0].Rows[0]["ECMP_VC_OS_WITHOUT_GLASS"].ToString().TrimEnd().TrimStart();
            cmbVcOsWithoutNearvision.Text = ds.Tables[0].Rows[0]["ECMP_VC_OS_WITHOUT_NEARVISION"].ToString().TrimEnd().TrimStart();
            txtVcOsWithoutDistance.Text = ds.Tables[0].Rows[0]["ECMP_VC_OS_WITHOUT_DISTANCE"].ToString().TrimEnd().TrimStart();
            cmbVcOsWithGlass.Text = ds.Tables[0].Rows[0]["ECMP_VC_OS_WITH_GLASS"].ToString().TrimEnd().TrimStart();
            cmbVcOsWithNearvision.Text = ds.Tables[0].Rows[0]["ECMP_VC_OS_WITH_NEARVISION"].ToString().TrimEnd().TrimStart();
            txtVcOsWithDistace.Text = ds.Tables[0].Rows[0]["ECMP_VC_OS_WITH_DISTANCE"].ToString().TrimEnd().TrimStart();
            cmbVcOsWithoutContact.Text = ds.Tables[0].Rows[0]["ECMP_OS_DISTANCE_CONTACT"].ToString().TrimEnd().TrimStart();
            cmbVcOsContact.Text = ds.Tables[0].Rows[0]["ECMP_OS_NEAR_CONTACT"].ToString().TrimEnd().TrimStart();
            txtVcOsContact.Text = ds.Tables[0].Rows[0]["ECMP_OS_DISTANCE_TEXT_CONTACT"].ToString().TrimEnd().TrimStart();
            cmbVcOsPinhole.Text = ds.Tables[0].Rows[0]["ECMP_VC_OS_PINHOLE"].ToString().TrimEnd().TrimStart();


            cmbVcOuWithoutGlass.Text = ds.Tables[0].Rows[0]["ECMP_VC_OU_WITHOUT_GLASS"].ToString().TrimEnd().TrimStart();
            cmbVcOuWithoutNearvision.Text = ds.Tables[0].Rows[0]["ECMP_VC_OU_WITHOUT_NEARVISION"].ToString().TrimEnd().TrimStart();
            txtVcOuWithoutDistance.Text = ds.Tables[0].Rows[0]["ECMP_VC_OU_WITHOUT_DISTANCE"].ToString().TrimEnd().TrimStart();
            cmbVcOuWithGlass.Text = ds.Tables[0].Rows[0]["ECMP_VC_OU_WITH_GLASS"].ToString().TrimEnd().TrimStart();
            cmbVcOuWithNearvision.Text = ds.Tables[0].Rows[0]["ECMP_VC_OU_WITH_NEARVISION"].ToString().TrimEnd().TrimStart();
            txtVcOuWithDistance.Text = ds.Tables[0].Rows[0]["ECMP_VC_OU_WITH_DISTANCE"].ToString().TrimEnd().TrimStart();
            cmbVcOuWithoutContact.Text = ds.Tables[0].Rows[0]["ECMP_OU_DISTANCE_CONTACT"].ToString().TrimEnd().TrimStart();
            cmbVcOuContact.Text = ds.Tables[0].Rows[0]["ECMP_OU_NEAR_CONTACT"].ToString().TrimEnd().TrimStart();
            txtVcOuContact.Text = ds.Tables[0].Rows[0]["ECMP_OU_DISTANCE_TEXT_CONTACT"].ToString().TrimEnd().TrimStart();
            cmbVcOuPinhole.Text = ds.Tables[0].Rows[0]["ECMP_VC_OU_PINHOLE"].ToString().TrimEnd().TrimStart();


            DD_Type_of_chart.Text = ds.Tables[0].Rows[0]["ECMP_TYPE_OF_CHART"].ToString().TrimEnd().TrimStart();
            DD_Near_vision_chart.Text = ds.Tables[0].Rows[0]["ECMP_NEAR_VISION_CHART"].ToString().TrimEnd().TrimStart();

            //--Refraction-- -

            txtRfOdSpherical.Text= ds.Tables[0].Rows[0]["ECMP_RF_OD_SPHERICAL"].ToString().TrimEnd().TrimStart();
            txtRfOdCylindrical.Text = ds.Tables[0].Rows[0]["ECMP_RF_OD_CYLINDRICAL"].ToString().TrimEnd().TrimStart();
            txtRfOdAxis.Text = ds.Tables[0].Rows[0]["ECMP_RF_OD_AXIS"].ToString().TrimEnd().TrimStart();
            cmbRfOdQuality.Text = ds.Tables[0].Rows[0]["ECMP_RF_OD_REFLEX"].ToString().TrimEnd().TrimStart();
            cmbRfOdCycloplegic.Text = ds.Tables[0].Rows[0]["ECMP_RF_OD_CYCLOPLEGIC"].ToString().TrimEnd().TrimStart();
            txtWetOdSpherical.Text = ds.Tables[0].Rows[0]["ECMP_RF_WET_OD_SPHERICAL"].ToString().TrimEnd().TrimStart();
            txtWetOdCylindrical.Text = ds.Tables[0].Rows[0]["ECMP_RF_WET_OD_CYLINDRICAL"].ToString().TrimEnd().TrimStart();
            txtWetOdAxis.Text = ds.Tables[0].Rows[0]["ECMP_RF_WET_OD_AXIS"].ToString().TrimEnd().TrimStart();




            txtRfOsSpherical.Text = ds.Tables[0].Rows[0]["ECMP_RF_OS_SPHERICAL"].ToString().TrimEnd().TrimStart();
            txtRfOsCylindrical.Text = ds.Tables[0].Rows[0]["ECMP_RF_OS_CYLINDRICAL"].ToString().TrimEnd().TrimStart();
            txtRfOsAxis.Text = ds.Tables[0].Rows[0]["ECMP_RF_OS_AXIS"].ToString().TrimEnd().TrimStart();
            cmbRfOsQuality.Text = ds.Tables[0].Rows[0]["ECMP_RF_OS_REFLEX"].ToString().TrimEnd().TrimStart();
            cmbRfOsCycloplegic.Text = ds.Tables[0].Rows[0]["ECMP_RF_OS_CYCLOPLEGIC"].ToString().TrimEnd().TrimStart();
            txtWetOsSpherical.Text = ds.Tables[0].Rows[0]["ECMP_RF_WET_OS_SPHERICAL"].ToString().TrimEnd().TrimStart();
            txtWetOsCylindrical.Text = ds.Tables[0].Rows[0]["ECMP_RF_WET_OS_CYLINDRICAL"].ToString().TrimEnd().TrimStart();
            txtWetOsAxis.Text = ds.Tables[0].Rows[0]["ECMP_RF_WET_OS_AXIS"].ToString().TrimEnd().TrimStart();

            //-- Acceptance ----


            txtAcOdDvSphericalOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OD_DV_SPHERICAL_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOdDvCylindricalOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OD_DV_CYLINDRICAL_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOdDvAxisOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OD_DV_AXIS_OPT"].ToString().TrimEnd().TrimStart();
            cmbAcOdDvBCVAOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OD_DV_BCVA_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOdAddSphericalOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OD_ADD_SPHERICAL_OPT"].ToString().TrimEnd().TrimStart();
            cmbAcOdAddBcvaOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OD_ADD_BCVA_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOdAddDistanceOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OD_ADD_DISTANCE_OPT"].ToString().TrimEnd().TrimStart();
            cmbAcOdPreferenceOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OD_PREFERENCE_OPT"].ToString().TrimEnd().TrimStart();



            txtAcOsDvSphericalOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OS_DV_SPHERICAL_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOsDvCylindricalOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OS_DV_CYLINDRICAL_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOsDvAxisOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OS_DV_AXIS_OPT"].ToString().TrimEnd().TrimStart();
            cmbAcOsDvBCVAOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OS_DV_BCVA_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOsAddSphericalOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OS_ADD_SPHERICAL_OPT"].ToString().TrimEnd().TrimStart();
            cmbAcOsAddBcvaOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OS_ADD_BCVA_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOsAddDistanceOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OS_ADD_DISTANCE_OPT"].ToString().TrimEnd().TrimStart();
            cmbAcOsPreferenceOpt.Text = ds.Tables[0].Rows[0]["ECMP_AC_OS_PREFERENCE_OPT"].ToString().TrimEnd().TrimStart();




            //-- Glass Prescription --
            txtAcOdDvSpherical.Text = ds.Tables[0].Rows[0]["ECMP_GP_OD_DV_SPHERICAL_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOdDvCylindrical.Text = ds.Tables[0].Rows[0]["ECMP_GP_OD_DV_CYLINDRICAL_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOdDvAxis.Text = ds.Tables[0].Rows[0]["ECMP_GP_OD_DV_AXIS_OPT"].ToString().TrimEnd().TrimStart();
            cmbAcOdDvBCVA.Text = ds.Tables[0].Rows[0]["ECMP_GP_OD_DV_BCVA_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOdAddSpherical.Text = ds.Tables[0].Rows[0]["ECMP_GP_OD_ADD_SPHERICAL_OPT"].ToString().TrimEnd().TrimStart();
            cmbAcOdAddBcva.Text = ds.Tables[0].Rows[0]["ECMP_GP_OD_ADD_BCVA_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOdAddDistance.Text = ds.Tables[0].Rows[0]["ECMP_GP_OD_ADD_DISTANCE_OPT"].ToString().TrimEnd().TrimStart();
            cmbAcOdPreference.Text = ds.Tables[0].Rows[0]["ECMP_GP_OD_PREFERENCE_OPT"].ToString().TrimEnd().TrimStart();



            txtAcOsDvSpherical.Text = ds.Tables[0].Rows[0]["ECMP_GP_OS_DV_SPHERICAL_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOsDvCylindrical.Text = ds.Tables[0].Rows[0]["ECMP_GP_OS_DV_CYLINDRICAL_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOsDvAxis.Text = ds.Tables[0].Rows[0]["ECMP_GP_OS_DV_AXIS_OPT"].ToString().TrimEnd().TrimStart();
            cmbAcOsDvBCVA.Text = ds.Tables[0].Rows[0]["ECMP_GP_OS_DV_BCVA_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOsAddSpherical.Text = ds.Tables[0].Rows[0]["ECMP_GP_OS_ADD_SPHERICAL_OPT"].ToString().TrimEnd().TrimStart();
            cmbAcOsAddBcva.Text = ds.Tables[0].Rows[0]["ECMP_GP_OS_ADD_BCVA_OPT"].ToString().TrimEnd().TrimStart();
            txtAcOsAddDistance.Text = ds.Tables[0].Rows[0]["ECMP_GP_OS_ADD_DISTANCE_OPT"].ToString().TrimEnd().TrimStart();
            cmbAcOsPreference.Text = ds.Tables[0].Rows[0]["ECMP_GP_OS_PREFERENCE_OPT"].ToString().TrimEnd().TrimStart();


            lblHtmlSummary1.Text = ds.Tables[0].Rows[0]["ECMP_SUMMARY"].ToString().TrimEnd().TrimStart();

            btnSave8.Visible = false;
            btnmod.Visible = true;
        }
        else
        {
            btnSave8.Visible = true;
        }

        con.Close();
    }



    




    private void InsertData(int serialNumber, string prescriptionDate, string textValue, string spherical, string cylindrical, string axis, string add, string prism, string baseDirection, string lensType, string glassStatus, string remarks)
    {
        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];
        string studentid = Request.QueryString["studentID"];

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        string insertQuery = "INSERT INTO ESO_CAMP_MR_PG (ECMPG_STD_NUMBER, ECMPG_DATE, ECMPG_EYE, ECMPG_SPHERICAL, ECMPG_CYLINDRICAL, ECMPG_AXIS, ECMPG_ADD, ECMPG_PRISM, ECMPG_MUSCLE_POWER, ECMPG_LENS_TYPE, ECMPG_GLASS_STATUS_CODE, ECMPG_REMARKS, ECMPG_VISIT_NO, ECMPG_CRT_UID, ECMPG_CRT_DT, ECMPG_LAST_UPD_UID, ECMPG_LAST_UPD_DT) " +
                             "VALUES (@studentid, @PrescriptionDate, @TextValue, @Spherical, @Cylindrical, @Axis, @Add, @Prism, @MusclePower, @LensType, @GlassStatus, @Remarks,'VT01',@currentuserid,GETDATE(),@currentuserid,GETDATE())";

        using (SqlCommand cmd = new SqlCommand(insertQuery, con))
        {
            cmd.Parameters.AddWithValue("@studentid", studentid);
            cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
            cmd.Parameters.AddWithValue("@PrescriptionDate", prescriptionDate);
            cmd.Parameters.AddWithValue("@TextValue", textValue);
            cmd.Parameters.AddWithValue("@Spherical", spherical);
            cmd.Parameters.AddWithValue("@Cylindrical", cylindrical);
            cmd.Parameters.AddWithValue("@Axis", axis);
            cmd.Parameters.AddWithValue("@Add", add);
            cmd.Parameters.AddWithValue("@Prism", prism);
            cmd.Parameters.AddWithValue("@MusclePower", baseDirection);
            cmd.Parameters.AddWithValue("@LensType", lensType);
            cmd.Parameters.AddWithValue("@GlassStatus", glassStatus);
            cmd.Parameters.AddWithValue("@Remarks", remarks);
            cmd.Parameters.AddWithValue("@currentuserid", currentuserid);

            cmd.ExecuteNonQuery();
        }

       
        con.Close();
    }






    private string GetBackgroundColorForCssClass(string cssClass)
    {
        switch (cssClass)
        {
            case "heading-row":
                return "#ebeeefe0"; // Light gray
            case "row-with-data":
                return "#ebeeefe0"; // Light green
            case "row-without-data":
                return "#ebeeefe0"; // Light red/pink
            default:
                return ""; // Default, no specific background color
        }
    }

    private string GenerateNonDataRow(string message, string cssClass)
    {
        StringBuilder htmlRow = new StringBuilder();
        htmlRow.AppendFormat("<tr class='{0}'>", cssClass);
        htmlRow.AppendFormat("<td colspan='12'>{0}</td>", message);
        htmlRow.Append("</tr>");
        return htmlRow.ToString();
    }







    public static string GetCellColorClass(string dataValue)
    {
        if (!string.IsNullOrEmpty(dataValue))
        {
            return "pink-cell"; 
        }
        else
        {
            return "black-cell"; 
        }
    }

    public static string GetCellColorClass1(string dataValue)
    {
        if (!string.IsNullOrEmpty(dataValue))
        {
            return "black-cell";
        }
        else
        {
            return "black-cell";
        }
    }


    protected void btnSave2_Click(object sender, EventArgs e)
    {

        var eyeod = "OD";
        var eyeos = "OS";
        var eyeou = "OU";

        
       

        //Visual Acuity
        string CmbVcOdWithoutGlass = cmbVcOdWithoutGlass.SelectedValue;
        string selectedCmbVcOdWithoutGlass = cmbVcOdWithoutGlass.SelectedItem.Text;
        if (selectedCmbVcOdWithoutGlass == "---- Select ---- ")
        {
            selectedCmbVcOdWithoutGlass = "";
        }
        string CmbVcOdWithoutNearvision = cmbVcOdWithoutNearvision.SelectedValue;

        string selectedCmbVcOdWithoutNearvision = cmbVcOdWithoutNearvision.SelectedItem.Text;
        if (selectedCmbVcOdWithoutNearvision == "---- Select ---- ")
        {
            selectedCmbVcOdWithoutNearvision = "";
        }
        string VcOdWithoutDistance = txtVcOdWithoutDistance.Text;
        string CmbVcOdWithGlass = cmbVcOdWithGlass.SelectedValue;

        string selectedCmbVcOdWithGlass = cmbVcOdWithGlass.SelectedItem.Text;
        if (selectedCmbVcOdWithGlass == "---- Select ---- ")
        {
            selectedCmbVcOdWithGlass = "";
        }
        string CmbVcOdWithNearvision = cmbVcOdWithNearvision.SelectedValue;

        string selectedCmbVcOdWithNearvision = cmbVcOdWithNearvision.SelectedItem.Text;
        if (selectedCmbVcOdWithNearvision == "---- Select ---- ")
        {
            selectedCmbVcOdWithNearvision = "";
        }
        string VcOdWithDistance = txtVcOdWithDistance.Text;
        string CmbVcOdWithoutContact = cmbVcOdWithoutContact.SelectedValue;

        string selectedCmbVcOdWithoutContact = cmbVcOdWithoutContact.SelectedItem.Text;
        if (selectedCmbVcOdWithoutContact == "---- Select ---- ")
        {
            selectedCmbVcOdWithoutContact = "";
        }
        string CmbVcOdContact = cmbVcOdContact.SelectedValue;

        string selectedCmbVcOdContact = cmbVcOdContact.SelectedItem.Text;
        if (selectedCmbVcOdContact == "---- Select ---- ")
        {
            selectedCmbVcOdContact = "";
        }
        string VcOdContact = txtVcOdContact.Text;
        string CmbVcOdPinhole = cmbVcOdPinhole.SelectedValue;

        string selectedCmbVcOdPinhole = cmbVcOdPinhole.SelectedItem.Text;
        if (selectedCmbVcOdPinhole == "---- Select ---- ")
        {
            selectedCmbVcOdPinhole = "";
        }





        string CmbVcOsWithoutGlass = cmbVcOsWithoutGlass.SelectedValue;

        string selectedCmbVcOsWithoutGlass = cmbVcOsWithoutGlass.SelectedItem.Text;
        if (selectedCmbVcOsWithoutGlass == "---- Select ---- ")
        {
            selectedCmbVcOsWithoutGlass = "";
        }

        string CmbVcOsWithoutNearvision = cmbVcOsWithoutNearvision.SelectedValue;

        string selectedCmbVcOsWithoutNearvision = cmbVcOsWithoutNearvision.SelectedItem.Text;
        if (selectedCmbVcOsWithoutNearvision == "---- Select ---- ")
        {
            selectedCmbVcOsWithoutNearvision = "";
        }

        string VcOsWithoutDistance = txtVcOsWithoutDistance.Text;
        string CmbVcOsWithGlass = cmbVcOsWithGlass.SelectedValue;

        string selectedCmbVcOsWithGlass = cmbVcOsWithGlass.SelectedItem.Text;
        if (selectedCmbVcOsWithGlass == "---- Select ---- ")
        {
            selectedCmbVcOsWithGlass = "";
        }

        string CmbVcOsWithNearvision = cmbVcOsWithNearvision.SelectedValue;
        string selectedCmbVcOsWithNearvision = cmbVcOsWithNearvision.SelectedItem.Text;
        if (selectedCmbVcOsWithNearvision == "---- Select ---- ")
        {
            selectedCmbVcOsWithNearvision = "";
        }
        string VcOsWithDistace = txtVcOsWithDistace.Text;
        string CmbVcOsWithoutContact = cmbVcOsWithoutContact.SelectedValue;
        string selectedCmbVcOsWithoutContact = cmbVcOsWithoutContact.SelectedItem.Text;
        if (selectedCmbVcOsWithoutContact == "---- Select ---- ")
        {
            selectedCmbVcOsWithoutContact = "";
        }
        string CmbVcOsContact = cmbVcOsContact.SelectedValue;
        string selectedCmbVcOsContact = cmbVcOsContact.SelectedItem.Text;
        if (selectedCmbVcOsContact == "---- Select ---- ")
        {
            selectedCmbVcOsContact = "";
        }
        string VcOsContact = txtVcOsContact.Text;
        string CmbVcOsPinhole = cmbVcOsPinhole.SelectedValue;
        string selectedCmbVcOsPinhole = cmbVcOsPinhole.SelectedItem.Text;
        if (selectedCmbVcOsPinhole == "---- Select ---- ")
        {
            selectedCmbVcOsPinhole = "";
        }





        string CmbVcOuWithoutGlass = cmbVcOuWithoutGlass.SelectedValue;

        string selectedCmbVcOuWithoutGlass = cmbVcOuWithoutGlass.SelectedItem.Text;
        if (selectedCmbVcOuWithoutGlass == "---- Select ---- ")
        {
            selectedCmbVcOuWithoutGlass = "";
        }
        

        string CmbVcOuWithoutNearvision = cmbVcOuWithoutNearvision.SelectedValue;

        string selectedCmbVcOuWithoutNearvision = cmbVcOuWithoutNearvision.SelectedItem.Text;
        if (selectedCmbVcOuWithoutNearvision == "---- Select ---- ")
        {
            selectedCmbVcOuWithoutNearvision = "";
        }
        string VcOuWithoutDistance = txtVcOuWithoutDistance.Text;
        string CmbVcOuWithGlass = cmbVcOuWithGlass.SelectedValue;
        string selectedCmbVcOuWithGlass = cmbVcOuWithGlass.SelectedItem.Text;
        if (selectedCmbVcOuWithGlass == "---- Select ---- ")
        {
            selectedCmbVcOuWithGlass = "";
        }

        string CmbVcOuWithNearvision = cmbVcOuWithNearvision.SelectedValue;
        string selectedCmbVcOuWithNearvision = cmbVcOuWithNearvision.SelectedItem.Text;
        if (selectedCmbVcOuWithNearvision == "---- Select ---- ")
        {
            selectedCmbVcOuWithNearvision = "";
        }

        string VcOuWithDistance = txtVcOuWithDistance.Text;
        string CmbVcOuWithoutContact = cmbVcOuWithoutContact.SelectedValue;

        string selectedCmbVcOuWithoutContact = cmbVcOuWithoutContact.SelectedItem.Text;
        if (selectedCmbVcOuWithoutContact == "---- Select ---- ")
        {
            selectedCmbVcOuWithoutContact = "";
        }


        string CmbVcOuContact = cmbVcOuContact.SelectedValue;

        string selectedCmbVcOuContact = cmbVcOuContact.SelectedItem.Text;
        if (selectedCmbVcOuContact == "---- Select ---- ")
        {
            selectedCmbVcOuContact = "";
        }




        string VcOuContact = txtVcOuContact.Text;
        string CmbVcOuPinhole = cmbVcOuPinhole.SelectedValue;

        string selectedCmbVcOuPinhole = cmbVcOuPinhole.SelectedItem.Text;
        if (selectedCmbVcOuPinhole == "---- Select ---- ")
        {
            selectedCmbVcOuPinhole = "";
        }



        string Type_of_Chart = DD_Type_of_chart.SelectedValue;

        string selectedType_of_Chart = DD_Type_of_chart.SelectedItem.Text;
        if (selectedType_of_Chart == "---- Select ---- ")
        {
            selectedType_of_Chart = "";
        }

        string Near_Vision_Chart = DD_Near_vision_chart.SelectedValue;
        string selectedNear_Vision_Chart = DD_Near_vision_chart.SelectedItem.Text;
        if (selectedNear_Vision_Chart == "---- Select ---- ")
        {
            selectedNear_Vision_Chart = "";
        }



        //Refraction

        string odSpherical = txtRfOdSpherical.Text;
        string odCylindrical = txtRfOdCylindrical.Text;
        string odAxis = txtRfOdAxis.Text;
        string odQuality = cmbRfOdQuality.SelectedValue;

        string selectedodQuality = cmbRfOdQuality.SelectedItem.Text;
        if (selectedodQuality == "---- Select ---- ")
        {
            selectedodQuality = "";
        }

        string odCycloplegic = cmbRfOdCycloplegic.SelectedValue;
        string selectedodCycloplegic = cmbRfOdCycloplegic.SelectedItem.Text;

        if (selectedodCycloplegic == "---- Select ---- ")
        {
            selectedodCycloplegic = "";
        }
        string odWetOdSpherical = txtWetOdSpherical.Text;
        string WetOdCylindrical = txtWetOdCylindrical.Text;
        string WetOdAxis = txtWetOdAxis.Text;





        string OsSpherical = txtRfOsSpherical.Text;
        string OsCylindrical = txtRfOsCylindrical.Text;
        string OsAxis = txtRfOsAxis.Text;
        string OsQuality = cmbRfOsQuality.SelectedValue;
        string selectedOsQuality = cmbRfOsQuality.SelectedItem.Text;
        if (selectedOsQuality == "---- Select ---- ")
        {
            selectedOsQuality = "";
        }
        string OsCycloplegic = cmbRfOsCycloplegic.SelectedValue;
        string selectedOsCycloplegic = cmbRfOsCycloplegic.SelectedItem.Text;
        if (selectedOsCycloplegic == "---- Select ---- ")
        {
            selectedOsCycloplegic = "";
        }
        string WetOsSpherical = txtWetOsSpherical.Text;
        string WetOsCylindrical = txtWetOsCylindrical.Text;
        string WetOsAxis = txtWetOsAxis.Text;




        //-- Acceptance ----


        string AcOdDvSpherical = txtAcOdDvSphericalOpt.Text;
        string AcOdDvCylindrical = txtAcOdDvCylindricalOpt.Text;
        string AcOdDvAxis = txtAcOdDvAxisOpt.Text;
        string CmbAcOdDvBCVA = cmbAcOdDvBCVAOpt.SelectedValue;
        string selectedCmbAcOdDvBCVA = cmbAcOdDvBCVAOpt.SelectedItem.Text;
        if (selectedCmbAcOdDvBCVA == "---- Select ---- ")
        {
            selectedCmbAcOdDvBCVA = ""; 
        }
        string AcOdAddSpherical = txtAcOdAddSphericalOpt.Text;
        string CmbAcOdAddBcva = cmbAcOdAddBcvaOpt.SelectedValue;
        string selectedCmbAcOdAddBcva = cmbAcOdAddBcvaOpt.SelectedItem.Text;
        if (selectedCmbAcOdAddBcva == "---- Select ---- ")
        {
            selectedCmbAcOdAddBcva = ""; 
        }
        string AcOdAddDistance = txtAcOdAddDistanceOpt.Text;
        string CmbAcOdPreference = cmbAcOdPreferenceOpt.SelectedValue;
        string selectedCmbAcOdPreference = cmbAcOdPreferenceOpt.SelectedItem.Text;
        if (selectedCmbAcOdPreference == "---- Select ---- ")
        {
            selectedCmbAcOdPreference = "";
        }

        string AcOsDvSpherical = txtAcOsDvSphericalOpt.Text;
        string AcOsDvCylindrical = txtAcOsDvCylindricalOpt.Text;
        string AcOsDvAxis = txtAcOsDvAxisOpt.Text;
        string CmbAcOsDvBCVA = cmbAcOsDvBCVAOpt.SelectedValue;
        string selectedCmbAcOsDvBCVA = cmbAcOsDvBCVAOpt.SelectedItem.Text;
        if (selectedCmbAcOsDvBCVA == "---- Select ---- ")
        {
            selectedCmbAcOsDvBCVA = "";
        }
        string AcOsAddSpherical = txtAcOsAddSphericalOpt.Text;
        string CmbAcOsAddBcva = cmbAcOsAddBcvaOpt.SelectedValue;
        string selectedCmbAcOsAddBcva = cmbAcOsAddBcvaOpt.SelectedItem.Text;
        if (selectedCmbAcOsAddBcva == "---- Select ---- ")
        {
            selectedCmbAcOsAddBcva = "";
        }
        string AcOsAddDistance = txtAcOsAddDistanceOpt.Text;
        string CmbAcOsPreference = cmbAcOsPreferenceOpt.SelectedValue;
        string selectedCmbAcOsPreference = cmbAcOsPreferenceOpt.SelectedItem.Text;
        if (selectedCmbAcOsPreference == "---- Select ---- ")
        {
            selectedCmbAcOsPreference = "";
        }





        //--Glass Prescription--

        

        string AcOdDvSpherical1 = txtAcOdDvSpherical.Text;
        string AcOdDvCylindrical1 = txtAcOdDvCylindrical.Text;
        string AcOdDvAxis1 = txtAcOdDvAxis.Text;
        string CmbAcOdDvBCVA1 = cmbAcOdDvBCVA.SelectedValue;
       
        string selectedCmbAcOdDvBCVA1 = cmbAcOdDvBCVA.SelectedItem.Text;
        if (selectedCmbAcOdDvBCVA1 == "---- Select ---- ")
        {
            selectedCmbAcOdDvBCVA1 = "";
        }
        string AcOdAddSpherical1 = txtAcOdAddSpherical.Text;
        string CmbAcOdAddBcva1 = cmbAcOdAddBcva.SelectedValue;
        string selectedCmbAcOdAddBcva1 = cmbAcOdAddBcva.SelectedItem.Text;
        if (selectedCmbAcOdAddBcva1 == "---- Select ---- ")
        {
            selectedCmbAcOdAddBcva1 = "";
        }

        string AcOdAddDistance1 = txtAcOdAddDistance.Text;
        string CmbAcOdPreference1 = cmbAcOdPreference.SelectedValue;
        string selectedCmbAcOdPreference1 = cmbAcOdPreference.SelectedItem.Text;
        if (selectedCmbAcOdPreference1 == "---- Select ---- ")
        {
            selectedCmbAcOdPreference1 = "";
        }



        string AcOsDvSpherical1 = txtAcOsDvSpherical.Text;
        string AcOsDvCylindrical1 = txtAcOsDvCylindrical.Text;
        string AcOsDvAxis1 = txtAcOsDvAxis.Text;
        string CmbAcOsDvBCVA1 = cmbAcOsDvBCVA.SelectedValue;
        string selectedCmbAcOsDvBCVA1 = cmbAcOsDvBCVA.SelectedItem.Text;
        if (selectedCmbAcOsDvBCVA1 == "---- Select ---- ")
        {
            selectedCmbAcOsDvBCVA1 = "";
        }
        string AcOsAddSpherical1 = txtAcOsAddSpherical.Text;
        string CmbAcOsAddBcva1 = cmbAcOsAddBcva.SelectedValue;
        string selectedCmbAcOsAddBcva1 = cmbAcOsAddBcva.SelectedItem.Text;
        if (selectedCmbAcOsAddBcva1 == "---- Select ---- ")
        {
            selectedCmbAcOsAddBcva1 = "";
        }
        string AcOsAddDistance1 = txtAcOsAddDistance.Text;
        string CmbAcOsPreference1 = cmbAcOsPreference.SelectedValue;
        string selectedCmbAcOsPreference1 = cmbAcOsPreference.SelectedItem.Text;
        if (selectedCmbAcOsPreference1 == "---- Select ---- ")
        {
            selectedCmbAcOsPreference1 = "";
        }


        //--Proposed Prism--
        string AcOdPrism1 = txtAcOdPrism1.Text;
        string CmdAcOdPrism1 = cmbAcOdPrism1.SelectedValue;
        string AcOsPrism1 = txtAcOsPrism1.Text;
        string CmdAcOsPrism1 = cmbAcOsPrism1.SelectedValue;
        string AcOdPrism2 = txtAcOdPrism2.Text;
        string CmbAcOdPrism2 = cmbAcOdPrism2.SelectedValue;
        string AcOsPrism2 = txtAcOsPrism2.Text;
        string CmbAcOsPrism2 = cmbAcOsPrism2.SelectedValue;


        //Refining Procedure

        string CmbAcOdRpRefining = cmbAcOdRpRefining.SelectedValue;
        string RadAcOdRpJCC = radAcOdRpJCC.SelectedValue;

        string RadAcOdRpFogging = radAcOdRpFogging.SelectedValue;

        string CmbAcOsRpRefining = cmbAcOsRpRefining.SelectedValue;

        string RadAcOsRpJCC = radAcOsRpJCC.SelectedValue;

        string RadAcOsRpFogging = radAcOsRpFogging.SelectedValue;



        //Intermediate Vision

        string AcOdIVision = txtAcOdIVision.Text;
        string AcOdIVRDistace = txtAcOdIVRDistace.Text;
        string AcOdPrismValue = txtAcOdPrismValue.Text;
        string CmbAcOdPrismType = cmbAcOdPrismType.SelectedValue;
        string AcOsIVision = txtAcOsIVision.Text;
        string AcOsIVRDistace = txtAcOsIVRDistace.Text;
        string AcOsPrismValue = txtAcOsPrismValue.Text;
        string CmbAcOsPrismType = cmbAcOsPrismType.SelectedValue;


        // Diagnosis Result

        string AcOdDiagnosis = txtAcOdDiagnosis.Text;
        string AcOsDiagnosis = txtAcOsDiagnosis.Text;





        string dayOD = DayDropdown_OD?.SelectedValue;
        string monthOD = monthDropdown_OD?.SelectedValue;
        string YearOD = yearOD?.Text;


        string prescriptionDateOD = $"{dayOD}/{monthOD}/{YearOD}";




        string textValueOD = lblEyeOD.Text;


        string sphericalOD = Spherical_OD.Text;


        string cylindricalOD = Cylindrical_OD.Text;


        string axisOD = Axis_OD.Text;


        string addOD = Add_OD.Text;


        string prismOD = Prism_OD.Text;
        

        string cmbbaseDirectionOD = BaseDirectionOD.SelectedValue;
        string selectedcmbbaseDirectionOD = BaseDirectionOD.SelectedItem.Text;
        if (selectedcmbbaseDirectionOD == "---- Select ---- ")
        {
            selectedcmbbaseDirectionOD = "";
        }


        string cmdlensTypeOD= LensType_OD.SelectedValue;
        string selectedcmbLensType_OD = LensType_OD.SelectedItem.Text;
        if (selectedcmbLensType_OD == "---- Select ---- ")
        {
            selectedcmbLensType_OD = "";
        }

        
        string selectedGlassStatusOD = GlassStatus_OD.Text;


        string remarksOD = Remarks_OD.Text;


        string dayOS = DayDropdown_OS.SelectedValue;
        string monthOS = MonthDropdown_OS.SelectedValue;
        string YearOS = yearOS?.Text;


        string prescriptionDateOS = $"{dayOS}/{monthOS}/{YearOS}"; // You might need to adjust the format




        string textValueOS = lbl_os.Text;


        string sphericalOS = Spherical_OS.Text;


        string cylindricalOS = Cylindrical_OS.Text;


        string axisOS = Axis_OS.Text;


        string addOS = Add_OS.Text;


        string prismOS = Prism_OS.Text;

        string cmbbaseDirectionOS = BaseDirectionOS.SelectedValue;
        string selectedcmbbaseDirectionOS = BaseDirectionOS.SelectedItem.Text;
        if (selectedcmbbaseDirectionOS == "---- Select ---- ")
        {
            selectedcmbbaseDirectionOS = "";
        }


        string cmdlensTypeOS = LensType_OS.SelectedValue;
        string selectedcmbLensType_OS = LensType_OS.SelectedItem.Text;
        if (selectedcmbLensType_OS == "---- Select ---- ")
        {
            selectedcmbLensType_OS = "";
        }

        string selectedGlassStatusOS = GlassStatus_OS.Text;


        string remarksOS = Remarks_OS.Text;

        int serialNumber = 1;


       
        InsertData( serialNumber, prescriptionDateOD, textValueOD, sphericalOD, cylindricalOD, axisOD, addOD, prismOD, cmbbaseDirectionOD, cmdlensTypeOD, selectedGlassStatusOD, remarksOD);


        InsertData( serialNumber, prescriptionDateOS, textValueOS, sphericalOS, cylindricalOS, axisOS, addOS, prismOS, cmbbaseDirectionOS, cmdlensTypeOS, selectedGlassStatusOS, remarksOS);


        // string cssStyles = @"<style> .pink-cell { background-color: #e7a7da94;  color: black; } .black-cell { background-color: #ebeeefe0;  color: black;  } </style>";



        // Generating Summary

        //<table class="summary-table" style="background-color: white; width: 1200px;" border="1"><tbody><tr style="background-color: #ace3dbb0;" class="heading-row"><th>Serial Number</th><th>Prescription Date</th><th>Eye</th><th>Spherical</th><th>Cylindrical</th><th>Axis</th><th>Add</th><th>Prism</th><th>Muscle Power</th><th>Lens Type</th><th>Glass Status</th><th>Remarks</th></tr><tr style="background-color: #ebeeefe0;"><td>1</td><td>00/00/3</td><td>OD</td><td>3</td><td>3</td><td>3</td><td>3</td><td></td><td></td><td></td><td></td><td></td></tr><tr style="background-color: #ebeeefe0;"><td>1</td><td>00/00/</td><td>OS</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr></tbody></table>

        string CssSummary = @"<style> .pink-cell { background-color: #e7a7da94;  color: black; } .black-cell { background-color: #ebeeefe0;  color: black;  } </style>";

        string summaryTable = "<table  class='summary-table' style='background-color: white; width: 1200px;'>";




        summaryTable += "<tr style='background-color: #e5f4fb;'><th colspan='1' style='padding-right: 10px;'>Prescription Datesr</th><th colspan='1'>Eye</th><th colspan='1'>Spherical</th><th colspan='1'>Cylindrical</th><th colspan='1'>Axis</th><th colspan='1'>Add</th><th colspan='1'>Prism</th><th colspan='1'>Base Direction</th><th colspan='1'>Lens Type</th><th colspan='1'>Glass Status</th><th colspan='1'>Remarks</th></tr>";


        summaryTable += "<tr><td class='" + GetCellColorClass1(prescriptionDateOD) + "'>" + prescriptionDateOD + "</td><td>" + textValueOD + "</td><td class='" + GetCellColorClass1(sphericalOD) + "'>" + sphericalOD + "</td><td class='" + GetCellColorClass1(cylindricalOD) + "'>" + cylindricalOD + "</td><td class='" + GetCellColorClass1(axisOD) + "'>" + axisOD + "</td><td class='" + GetCellColorClass1(addOD) + "'>" + addOD + "</td><td class='" + GetCellColorClass1(prismOD) + "'>" + prismOD + "</td><td class='" + GetCellColorClass1(selectedcmbbaseDirectionOD) + "'>" + selectedcmbbaseDirectionOD + "</td><td class='" + GetCellColorClass1(selectedcmbLensType_OD) + "'>" + selectedcmbLensType_OD + "</td><td class='" + GetCellColorClass1(selectedGlassStatusOD) + "'>" + selectedGlassStatusOD + "</td><td class='" + GetCellColorClass1(remarksOD) + "'>" + remarksOD + "</td></tr>";

        summaryTable += "<tr><td class='" + GetCellColorClass1(prescriptionDateOS) + "'>" + prescriptionDateOS + "</td><td>" + textValueOS + "</td><td class='" + GetCellColorClass1(sphericalOS) + "'>" + sphericalOS + "</td><td class='" + GetCellColorClass1(cylindricalOS) + "'>" + cylindricalOS + "</td><td class='" + GetCellColorClass1(axisOS) + "'>" + axisOS + "</td><td class='" + GetCellColorClass1(addOS) + "'>" + addOS + "</td><td class='" + GetCellColorClass1(prismOS) + "'>" + prismOS + "</td><td class='" + GetCellColorClass1(selectedcmbbaseDirectionOS) + "'>" + selectedcmbbaseDirectionOS + "</td><td class='" + GetCellColorClass1(selectedcmbLensType_OS) + "'>" + selectedcmbLensType_OS + "</td><td class='" + GetCellColorClass1(selectedGlassStatusOS) + "'>" + selectedGlassStatusOS + "</td><td class='" + GetCellColorClass1(remarksOS) + "'>" + remarksOS + "</td></tr>";
        



        summaryTable += "<tr style='background-color:#bd2020d4;'><th colspan='11' style='width: 300px; color:white;'>VISUAL ACUITY</th></tr>";


        summaryTable += "<tr style='background-color: #b498cf96;'><th colspan='4' style='padding-right: 10px;'>Without Glass</th><th colspan='3'>With Glass</th><th colspan='3'>Contact Lens</th><th colspan='1'>With PH</th></tr>";


        summaryTable += "<tr><td>" + eyeod + "</td><td class='" + GetCellColorClass(selectedCmbVcOdWithoutGlass) + "'>" + selectedCmbVcOdWithoutGlass + "</td><td class='" + GetCellColorClass(selectedCmbVcOdWithoutNearvision) + "'>" + selectedCmbVcOdWithoutNearvision + "</td><td class='" + GetCellColorClass(VcOdWithoutDistance) + "'>" + VcOdWithoutDistance + "</td><td class='" + GetCellColorClass(selectedCmbVcOdWithGlass ) + "'>" + selectedCmbVcOdWithGlass + "</td><td class='" + GetCellColorClass(selectedCmbVcOdWithNearvision) + "'>" + selectedCmbVcOdWithNearvision + "</td><td class='" + GetCellColorClass(VcOdWithDistance) + "'>" + VcOdWithDistance + "</td><td class='" + GetCellColorClass(selectedCmbVcOdWithoutContact) + "'>" + selectedCmbVcOdWithoutContact + "</td><td class='" + GetCellColorClass(selectedCmbVcOdContact) + "'>" + selectedCmbVcOdContact + "</td><td class='" + GetCellColorClass(VcOdContact) + "'>" + VcOdContact + "</td><td class='" + GetCellColorClass(selectedCmbVcOdPinhole) + "'>" + selectedCmbVcOdPinhole + "</td></tr>";

        summaryTable += "<tr><td>" + eyeos + "</td><td class='" + GetCellColorClass(selectedCmbVcOsWithoutGlass) + "'>" + selectedCmbVcOsWithoutGlass + "</td><td class='" + GetCellColorClass(selectedCmbVcOsWithoutNearvision) + "'>" + selectedCmbVcOsWithoutNearvision + "</td><td class='" + GetCellColorClass(VcOsWithoutDistance) + "'>" + VcOsWithoutDistance + "</td><td class='" + GetCellColorClass(selectedCmbVcOsWithGlass) + "'>" + selectedCmbVcOsWithGlass + "</td><td class='" + GetCellColorClass(selectedCmbVcOsWithNearvision) + "'>" + selectedCmbVcOsWithNearvision + "</td><td class='" + GetCellColorClass(VcOsWithDistace) + "'>" + VcOsWithDistace + "</td><td class='" + GetCellColorClass(selectedCmbVcOsWithoutContact) + "'>" + selectedCmbVcOsWithoutContact + "</td><td class='" + GetCellColorClass(selectedCmbVcOsContact) + "'>" + selectedCmbVcOsContact + "</td><td class='" + GetCellColorClass(VcOsContact) + "'>" + VcOsContact + "</td><td class='" + GetCellColorClass(selectedCmbVcOsPinhole) + "'>" + selectedCmbVcOsPinhole + "</td></tr>";

        summaryTable += "<tr><td>" + eyeou + "</td><td class='" + GetCellColorClass(selectedCmbVcOuWithoutGlass) + "'>" + selectedCmbVcOuWithoutGlass + "</td><td class='" + GetCellColorClass(selectedCmbVcOuWithoutNearvision) + "'>" + selectedCmbVcOuWithoutNearvision + "</td><td class='" + GetCellColorClass(VcOuWithoutDistance) + "'>" + VcOuWithoutDistance + "</td><td class='" + GetCellColorClass(selectedCmbVcOuWithGlass) + "'>" + selectedCmbVcOuWithGlass + "</td><td class='" + GetCellColorClass(selectedCmbVcOuWithNearvision) + "'>" + selectedCmbVcOuWithNearvision + "</td><td class='" + GetCellColorClass(VcOuWithDistance) + "'>" + VcOuWithDistance + "</td><td class='" + GetCellColorClass(selectedCmbVcOuWithoutContact) + "'>" + selectedCmbVcOuWithoutContact + "</td><td class='" + GetCellColorClass(selectedCmbVcOuContact) + "'>" + selectedCmbVcOuContact + "</td><td class='" + GetCellColorClass(VcOuContact) + "'>" + VcOuContact + "</td><td class='" + GetCellColorClass(selectedCmbVcOuPinhole) + "'>" + selectedCmbVcOuPinhole + "</td></tr>";



        summaryTable += "<tr><td><strong>Type of Chart:</strong></td><td class='" + GetCellColorClass(selectedType_of_Chart) + "'>" + selectedType_of_Chart + "</td><td><strong>Near Vision Chart:</strong></td><td class='" + GetCellColorClass(selectedNear_Vision_Chart) + "'>" + selectedNear_Vision_Chart + "</td></tr>";
      
        summaryTable += "<tr style='background-color: #bd2020d4;'><th colspan='10' style='width: 300px; color:white;'>REFRACTION</th></tr>";

        //summaryTable += "<tr style='background-color: #b498cf96;'><th colspan='10'>RatinoScopy, Quality of, Cycloplegic</th></tr>";

        summaryTable += "<tr style='background-color: #b498cf96;'><th colspan='4' style='padding-right: 10px;'>RatinoScopy</th><th colspan='1'>Quality of</th><th colspan='5'>Auto Refraction</ th></tr>";

        summaryTable += "<tr style='background-color: #b498cf96;'><th>EYE</th><th>DSPH</th><th>DCYL</th><th>AXIS</th><th>Reflex</th><th>Auto Refraction</th><th>EYE</ th><th>DSPH</th><th>DCYL</th><th>AXIS</th></tr>";
        //summaryTable += "<tr style='background-color: #b498cf96;'><th>EYE</th><th>DSPH</th><th>DCYL</th><th>AXIS</th><th>Reflex</th><th>Type</th><th>DSPH</th><th>DCYL</th><th>Axis</th></tr>";


        summaryTable += "<tr><td>" + eyeod + "</td><td class='" + GetCellColorClass(odSpherical) + "'>" + odSpherical + "</td><td class='" + GetCellColorClass(odCylindrical) + "'>" + odCylindrical + "</td><td class='" + GetCellColorClass(odAxis) + "'>" + odAxis + "</td><td class='" + GetCellColorClass(selectedodQuality) + "'>" + selectedodQuality + "</td><td class='" + GetCellColorClass(selectedodCycloplegic) + "'>" + selectedodCycloplegic + " </td><td>" + eyeod + "</td><td class='" + GetCellColorClass(odWetOdSpherical) + "'>" + odWetOdSpherical + "</td><td class='" + GetCellColorClass(WetOdCylindrical) + "'>" + WetOdCylindrical + "</td><td class='" + GetCellColorClass(WetOdAxis) + "'>" + WetOdAxis + "</td></tr>";

         summaryTable += "<tr><td>" + eyeos + "</td><td class='" + GetCellColorClass(OsSpherical) + "'>" + OsSpherical + "</td><td class='" + GetCellColorClass(OsCylindrical) + "'>" + OsCylindrical + "</td><td class='" + GetCellColorClass(OsAxis) + "'>" + OsAxis + "</td><td class='" + GetCellColorClass(selectedOsQuality) + "'>" + selectedOsQuality + "</td><td class='" + GetCellColorClass(selectedOsCycloplegic) + "'>" + selectedOsCycloplegic + "</td><td>" + eyeos + "</td><td class='" + GetCellColorClass(WetOsSpherical) + "'>" + WetOsSpherical + "</td><td class='" + GetCellColorClass(WetOsCylindrical) + "'>" + WetOsCylindrical + "</td><td class='" + GetCellColorClass(WetOsAxis) + "'>" + WetOsAxis + "</td></tr>";


        summaryTable += "<br />";
        summaryTable += "<br />";

        summaryTable += "<tr style='background-color: #bd2020d4;'><th colspan='10' style='width: 300px; color:white;'>ACCEPTANCE</th></tr>";


        summaryTable += "<tr style='background-color: #b498cf96;'><th>EYE</th><th>DSPH</th><th>DCYL</th><th>AXIS</th><th>BCVA</th><th>EYE</th><th>DSPH</th><th>BCVA</th><th>CM</th><th>Preference</th></tr>";


       

        summaryTable += "<tr><td>" + eyeod + "</td><td class='" + GetCellColorClass(AcOdDvSpherical) + "'>" + AcOdDvSpherical + "</td><td class='" + GetCellColorClass(AcOdDvCylindrical) + "'>" + AcOdDvCylindrical + "</td><td class='" + GetCellColorClass(AcOdDvAxis) + "'>" + AcOdDvAxis + "</td><td class='" + GetCellColorClass(selectedCmbAcOdDvBCVA) + "'>" + selectedCmbAcOdDvBCVA + "</td><td>" + eyeod + "</td><td class='" + GetCellColorClass(AcOdAddSpherical) + "'>" + AcOdAddSpherical + "</td><td class='" + GetCellColorClass(selectedCmbAcOdAddBcva) + "'>" + selectedCmbAcOdAddBcva + "</td><td class='" + GetCellColorClass(AcOdAddDistance) + "'>" + AcOdAddDistance + "</td><td class='" + GetCellColorClass(selectedCmbAcOdPreference) + "'>" + selectedCmbAcOdPreference + "</td></tr>";
        summaryTable += "<tr><td>" + eyeos + "</td><td class='" + GetCellColorClass(AcOsDvSpherical) + "'>" + AcOsDvSpherical + "</td><td class='" + GetCellColorClass(AcOsDvCylindrical) + "'>" + AcOsDvCylindrical + "</td><td class='" + GetCellColorClass(AcOsDvAxis) + "'>" + AcOsDvAxis + "</td><td class='" + GetCellColorClass(selectedCmbAcOsDvBCVA) + "'>" + selectedCmbAcOsDvBCVA + "</td><td>" + eyeos + "</td><td class='" + GetCellColorClass(AcOsAddSpherical) + "'>" + AcOsAddSpherical + "</td><td class='" + GetCellColorClass(selectedCmbAcOsAddBcva) + "'>" + selectedCmbAcOsAddBcva + "</td><td class='" + GetCellColorClass(AcOsAddDistance) + "'>" + AcOsAddDistance + "</td><td class='" + GetCellColorClass(selectedCmbAcOsPreference) + "'>" + selectedCmbAcOsPreference + "</td></tr>";



     
        summaryTable += "<br />";
        summaryTable += "<br />";



    
        summaryTable += "<tr style='background-color: #bd2020d4;'><th colspan='10' style='width: 300px; color:white;'>GLASS PRESCRIPTION </th></tr>";



        summaryTable += "<tr style='background-color: #b498cf96;'><th colspan='5' style='padding-right: 10px;'>Distance Vision</th><th colspan='4'>Add</th><th colspan='1'>Acceptance</th></tr>";


        summaryTable += "<tr style='background-color: #b498cf96;'><th>EYE</th><th>DSPH</th><th>DCYL</th><th>AXIS</th><th>BCVA</th><th>EYE</th><th>DSPH</th><th>BCVA</th><th>CM</th><th>Preference</th></tr>";



       
        summaryTable += "<tr><td>" + eyeod + "</td><td class='" + GetCellColorClass(AcOdDvSpherical1) + "'>" + AcOdDvSpherical1 + "</td><td class='" + GetCellColorClass(AcOdDvCylindrical1) + "'>" + AcOdDvCylindrical1 + "</td><td class='" + GetCellColorClass(AcOdDvAxis1) + "'>" + AcOdDvAxis1 + "</td><td class='" + GetCellColorClass(selectedCmbAcOdDvBCVA1) + "'>" + selectedCmbAcOdDvBCVA1 + "</td><td>" + eyeod + "</td><td class='" + GetCellColorClass(AcOdAddSpherical1) + "'>" + AcOdAddSpherical1 + "</td><td class='" + GetCellColorClass(selectedCmbAcOdAddBcva1) + "'>" + selectedCmbAcOdAddBcva1 + "</td><td class='" + GetCellColorClass(AcOdAddDistance1) + "'>" + AcOdAddDistance1 + "</td><td class='" + GetCellColorClass(selectedCmbAcOdPreference1) + "'>" + selectedCmbAcOdPreference1 + "</td></tr>";
        summaryTable += "<tr><td>" + eyeos + "</td><td class='" + GetCellColorClass(AcOsDvSpherical1) + "'>" + AcOsDvSpherical1 + "</td><td class='" + GetCellColorClass(AcOsDvCylindrical1) + "'>" + AcOsDvCylindrical1 + "</td><td class='" + GetCellColorClass(AcOsDvAxis1) + "'>" + AcOsDvAxis1 + "</td><td class='" + GetCellColorClass(selectedCmbAcOsDvBCVA1) + "'>" + selectedCmbAcOsDvBCVA1 + "</td><td>" + eyeos + "</td><td class='" + GetCellColorClass(AcOsAddSpherical1) + "'>" + AcOsAddSpherical1 + "</td><td class='" + GetCellColorClass(selectedCmbAcOsAddBcva1) + "'>" + selectedCmbAcOsAddBcva1 + "</td><td class='" + GetCellColorClass(AcOsAddDistance1) + "'>" + AcOsAddDistance1 + "</td><td class='" + GetCellColorClass(selectedCmbAcOsPreference1) + "'>" + selectedCmbAcOsPreference1 + "</td></tr>";


        summaryTable += "<br />";
        summaryTable += "<br />";

        summaryTable += "</table>";



        string Summary_pgp = summaryTable;



        lblHtmlSummary1.Text = Summary_pgp;




        string SummaryPGP = CssSummary + Summary_pgp;

       
        string Summary = SummaryPGP;

        Summary = Summary.Replace("<br />", "");


        string studentid = Request.QueryString["studentID"];
        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        con.Open();

        string table = "INSERT INTO ESO_CAMP_MR_PGP (ECMP_STD_NUMBER,ECMP_VC_OD_WITHOUT_GLASS,ECMP_VC_OD_WITHOUT_NEARVISION,ECMP_VC_OD_WITHOUT_DISTANCE,ECMP_VC_OD_WITH_GLASS,ECMP_VC_OD_WITH_NEARVISION";
        table += ",ECMP_VC_OD_WITH_DISTANCE,ECMP_OD_DISTANCE_CONTACT,ECMP_OD_NEAR_CONTACT,ECMP_OD_DISTANCE_TEXT_CONTACT,";
        table += "ECMP_VC_OD_PINHOLE,ECMP_VC_OS_WITHOUT_GLASS,ECMP_VC_OS_WITHOUT_NEARVISION,ECMP_VC_OS_WITHOUT_DISTANCE,ECMP_VC_OS_WITH_GLASS,ECMP_VC_OS_WITH_NEARVISION,";
        table += "ECMP_VC_OS_WITH_DISTANCE,ECMP_OS_DISTANCE_CONTACT,ECMP_OS_NEAR_CONTACT,ECMP_OS_DISTANCE_TEXT_CONTACT";
        table += ",ECMP_VC_OS_PINHOLE,ECMP_VC_OU_WITHOUT_GLASS,ECMP_VC_OU_WITHOUT_NEARVISION,ECMP_VC_OU_WITHOUT_DISTANCE,ECMP_VC_OU_WITH_GLASS,ECMP_VC_OU_WITH_NEARVISION,";

        table += "ECMP_VC_OU_WITH_DISTANCE,ECMP_OU_DISTANCE_CONTACT,ECMP_OU_NEAR_CONTACT,ECMP_OU_DISTANCE_TEXT_CONTACT,ECMP_VC_OU_PINHOLE,ECMP_TYPE_OF_CHART,ECMP_NEAR_VISION_CHART,ECMP_RF_OD_CYCLOPLEGIC, ECMP_RF_OS_CYCLOPLEGIC, ECMP_RF_OD_REFLEX,";
        table += " ECMP_RF_OS_REFLEX, ECMP_RF_OD_SPHERICAL,ECMP_RF_OD_CYLINDRICAL,ECMP_RF_OD_AXIS,ECMP_RF_OS_SPHERICAL,ECMP_RF_OS_CYLINDRICAL,";
        table += "ECMP_RF_OS_AXIS,ECMP_RF_WET_OD_SPHERICAL,ECMP_RF_WET_OD_CYLINDRICAL,ECMP_RF_WET_OD_AXIS,ECMP_RF_WET_OS_SPHERICAL,ECMP_RF_WET_OS_CYLINDRICAL,ECMP_RF_WET_OS_AXIS,ECMP_AC_OD_DV_SPHERICAL_OPT,ECMP_AC_OD_DV_CYLINDRICAL_OPT,ECMP_AC_OD_DV_AXIS_OPT,ECMP_AC_OD_DV_BCVA_OPT,ECMP_AC_OD_ADD_SPHERICAL_OPT ,ECMP_AC_OD_ADD_BCVA_OPT ,ECMP_AC_OD_ADD_DISTANCE_OPT,ECMP_AC_OD_PREFERENCE_OPT,";
        table += "ECMP_AC_OS_DV_SPHERICAL_OPT,ECMP_AC_OS_DV_CYLINDRICAL_OPT,ECMP_AC_OS_DV_AXIS_OPT,ECMP_AC_OS_DV_BCVA_OPT,ECMP_AC_OS_ADD_SPHERICAL_OPT,ECMP_AC_OS_ADD_BCVA_OPT,ECMP_AC_OS_ADD_DISTANCE_OPT,ECMP_AC_OS_PREFERENCE_OPT,";
         table += "ECMP_GP_OD_DV_SPHERICAL_OPT, ECMP_GP_OD_DV_CYLINDRICAL_OPT, ECMP_GP_OD_DV_AXIS_OPT,ECMP_GP_OD_DV_BCVA_OPT,ECMP_GP_OS_DV_SPHERICAL_OPT,ECMP_GP_OS_DV_CYLINDRICAL_OPT,";
        table += " ECMP_GP_OS_DV_AXIS_OPT,ECMP_GP_OS_DV_BCVA_OPT,ECMP_GP_OD_ADD_SPHERICAL_OPT,ECMP_GP_OD_ADD_BCVA_OPT,ECMP_GP_OD_ADD_DISTANCE_OPT,ECMP_GP_OS_ADD_SPHERICAL_OPT,ECMP_GP_OS_ADD_BCVA_OPT,";
        table += "ECMP_GP_OS_ADD_DISTANCE_OPT,ECMP_GP_OD_PREFERENCE_OPT,ECMP_GP_OS_PREFERENCE_OPT,ECMP_AC_OD_PRISM1, ECMP_AC_OD_PRISM_TYPE1, ECMP_AC_OS_PRISM1,ECMP_AC_OS_PRISM_TYPE1,ECMP_AC_OD_PRISM2,ECMP_AC_OD_PRISM_TYPE2,";
        table += " ECMP_AC_OS_PRISM2,ECMP_AC_OS_PRISM_TYPE2,ECMP_AC_OD_RP_REFINING,ECMP_AC_OD_RP_JCC,ECMP_AC_OD_RP_FOGGING,ECMP_AC_OS_RP_REFINING,ECMP_AC_OS_RP_JCC,ECMP_AC_OS_RP_FOGGING,ECMP_AC_OD_IVISION, ECMP_AC_OD_IVRDISTANCE, ECMP_AC_OD_PRISM_VALUE,ECMP_AC_OD_PRISM_TYPE,ECMP_AC_OS_IVISION,ECMP_AC_OS_IVRDISTANCE,";
        table += " ECMP_AC_OS_PRISM_VALUE,ECMP_AC_OS_PRISM_TYPE,ECMP_AC_OD_DIAGNOSIS,ECMP_AC_OS_DIAGNOSIS,ECMP_SUMMARY,ECMP_VISIT_NO,ECMP_CRT_ID,ECMP_CRT_DT,ECMP_LAST_UPD_ID,ECMP_LAST_UPD_DT)VALUES(@studentid,@CmbVcOdWithoutGlass,@CmbVcOdWithoutNearvision,";
        table += "@VcOdWithoutDistance,@CmbVcOdWithGlass,@CmbVcOdWithNearvision,@VcOdWithDistance,@CmbVcOdWithoutContact,@CmbVcOdContact,@VcOdContact,@CmbVcOdPinhole,";

        table += "@CmbVcOsWithoutGlass,@CmbVcOsWithoutNearvision,@VcOsWithoutDistance,@CmbVcOsWithGlass,@CmbVcOsWithNearvision,@VcOsWithDistace,@CmbVcOsWithoutContact,@CmbVcOsContact";
        table += ",@VcOsContact,@CmbVcOsPinhole,";

        table += "@CmbVcOuWithoutGlass,@CmbVcOuWithoutNearvision,@VcOuWithoutDistance,@CmbVcOuWithGlass,@CmbVcOuWithNearvision,@VcOuWithDistance,@CmbVcOuWithoutContact,@CmbVcOuContact";
        table += ",@VcOuContact,@CmbVcOuPinhole,@Type_of_Chart,@Near_Vision_Chart,@OdCycloplegic,@OsCycloplegic,@OdQuality,@OsQuality,@OdSpherical,@OdCylindrical,@OdAxis,@OsSpherical,@OsCylindrical,@OsAxis,@odWetOdSpherical,@WetOdCylindrical,";
        table += "@WetOdAxis,@WetOsSpherical,@WetOsCylindrical,@WetOsAxis,@AcOdDvSpherical,@AcOdDvCylindrical,@AcOdDvAxis,@CmbAcOdDvBCVA,@AcOdAddSpherical,@CmbAcOdAddBcva,";
        table += "@AcOdAddDistance,@CmbAcOdPreference,@AcOsDvSpherical,@AcOsDvCylindrical,@AcOsDvAxis,@CmbAcOsDvBCVA,@AcOsAddSpherical,@CmbAcOsAddBcva,@AcOsAddDistance,@CmbAcOsPreference,@AcOdDvSpherical1,@AcOdDvCylindrical1,@AcOdDvAxis1,@CmbAcOdDvBCVA1,@AcOsDvSpherical1,@AcOsDvCylindrical1,@AcOsDvAxis1,@CmbAcOsDvBCVA1,";
        table += "@AcOdAddSpherical1,@CmbAcOdAddBcva1,@AcOdAddDistance1,@AcOsAddSpherical1,@CmbAcOsAddBcva1,@AcOsAddDistance1,@CmbAcOdPreference1,@CmbAcOsPreference1,";

        table += "@AcOdPrism1,@CmdAcOdPrism1,@AcOsPrism1,@CmdAcOsPrism1,@AcOdPrism2,@CmbAcOdPrism2,@AcOsPrism2,@CmbAcOsPrism2,@CmbAcOdRpRefining,@RadAcOdRpJCC,@RadAcOdRpFogging,@CmbAcOsRpRefining,@RadAcOsRpJCC,";
        table += "@RadAcOsRpFogging,@AcOdIVision,@AcOdIVRDistace,@AcOdPrismValue,@CmbAcOdPrismType,@AcOsIVision,@AcOsIVRDistace,@AcOsPrismValue,@CmbAcOsPrismType,@AcOdDiagnosis,@AcOsDiagnosis,@Summary,'VT01',@currentuserid,getdate(),@currentuserid,getdate())";
        
        SqlCommand cmd = new SqlCommand(table, con);



        cmd.Parameters.AddWithValue("@studentid", studentid);


        //Visual Acuity

        cmd.Parameters.AddWithValue("@CmbVcOdWithoutGlass", CmbVcOdWithoutGlass);
        cmd.Parameters.AddWithValue("@CmbVcOdWithoutNearvision", CmbVcOdWithoutNearvision);
        cmd.Parameters.AddWithValue("@VcOdWithoutDistance", VcOdWithoutDistance);
        cmd.Parameters.AddWithValue("@CmbVcOdWithGlass", CmbVcOdWithGlass);
        cmd.Parameters.AddWithValue("@CmbVcOdWithNearvision", CmbVcOdWithNearvision);
        cmd.Parameters.AddWithValue("@VcOdWithDistance", VcOdWithDistance);
        cmd.Parameters.AddWithValue("@CmbVcOdWithoutContact", CmbVcOdWithoutContact);
        cmd.Parameters.AddWithValue("@CmbVcOdContact", CmbVcOdContact);
        cmd.Parameters.AddWithValue("@VcOdContact", VcOdContact);
        cmd.Parameters.AddWithValue("@CmbVcOdPinhole", CmbVcOdPinhole);


        cmd.Parameters.AddWithValue("@CmbVcOsWithoutGlass", CmbVcOsWithoutGlass);
        cmd.Parameters.AddWithValue("@CmbVcOsWithoutNearvision", CmbVcOsWithoutNearvision);
        cmd.Parameters.AddWithValue("@VcOsWithoutDistance", VcOsWithoutDistance);
        cmd.Parameters.AddWithValue("@CmbVcOsWithGlass", CmbVcOsWithGlass);
        cmd.Parameters.AddWithValue("@CmbVcOsWithNearvision", CmbVcOsWithNearvision);
        cmd.Parameters.AddWithValue("@VcOsWithDistace", VcOsWithDistace);
        cmd.Parameters.AddWithValue("@CmbVcOsWithoutContact", CmbVcOsWithoutContact);
        cmd.Parameters.AddWithValue("@CmbVcOsContact", CmbVcOsContact);
        cmd.Parameters.AddWithValue("@VcOsContact", VcOsContact);
        cmd.Parameters.AddWithValue("@CmbVcOsPinhole", CmbVcOsPinhole);





        cmd.Parameters.AddWithValue("@CmbVcOuWithoutGlass", CmbVcOuWithoutGlass);
        cmd.Parameters.AddWithValue("@CmbVcOuWithoutNearvision", CmbVcOuWithoutNearvision);
        cmd.Parameters.AddWithValue("@VcOuWithoutDistance", VcOuWithoutDistance);
        cmd.Parameters.AddWithValue("@CmbVcOuWithGlass", CmbVcOuWithGlass);
        cmd.Parameters.AddWithValue("@CmbVcOuWithNearvision", CmbVcOuWithNearvision);
        cmd.Parameters.AddWithValue("@VcOuWithDistance", VcOuWithDistance);
        cmd.Parameters.AddWithValue("@CmbVcOuWithoutContact", CmbVcOuWithoutContact);
        cmd.Parameters.AddWithValue("@CmbVcOuContact", CmbVcOuContact);
        cmd.Parameters.AddWithValue("@VcOuContact", VcOuContact);
        cmd.Parameters.AddWithValue("@CmbVcOuPinhole", CmbVcOuPinhole);

        cmd.Parameters.AddWithValue("@Type_of_Chart", Type_of_Chart);
        cmd.Parameters.AddWithValue("@Near_Vision_Chart", Near_Vision_Chart);



        //Refraction

        cmd.Parameters.AddWithValue("@OdSpherical", odSpherical);
        cmd.Parameters.AddWithValue("@OdCylindrical", odCylindrical);
        cmd.Parameters.AddWithValue("@OdAxis", odAxis);
        cmd.Parameters.AddWithValue("@OdQuality", odQuality);
        cmd.Parameters.AddWithValue("@OdCycloplegic", odCycloplegic);
        cmd.Parameters.AddWithValue("@odWetOdSpherical", odWetOdSpherical);
        cmd.Parameters.AddWithValue("@WetOdCylindrical", WetOdCylindrical);
        cmd.Parameters.AddWithValue("@WetOdAxis", WetOdAxis);
        cmd.Parameters.AddWithValue("@OsSpherical", OsSpherical);
        cmd.Parameters.AddWithValue("@OsCylindrical", OsCylindrical);
        cmd.Parameters.AddWithValue("@OsAxis", OsAxis);
        cmd.Parameters.AddWithValue("@OsQuality", OsQuality);
        cmd.Parameters.AddWithValue("@OsCycloplegic", OsCycloplegic);
        cmd.Parameters.AddWithValue("@WetOsSpherical", WetOsSpherical);
        cmd.Parameters.AddWithValue("@WetOsCylindrical", WetOsCylindrical);
        cmd.Parameters.AddWithValue("@WetOsAxis", WetOsAxis);





        //-- Acceptance ----
        

        cmd.Parameters.AddWithValue("@AcOdDvSpherical", AcOdDvSpherical);
        cmd.Parameters.AddWithValue("@AcOdDvCylindrical", AcOdDvCylindrical);
        cmd.Parameters.AddWithValue("@AcOdDvAxis", AcOdDvAxis);
        cmd.Parameters.AddWithValue("@CmbAcOdDvBCVA", CmbAcOdDvBCVA);
        cmd.Parameters.AddWithValue("@AcOdAddSpherical", AcOdAddSpherical);
        cmd.Parameters.AddWithValue("@CmbAcOdAddBcva", CmbAcOdAddBcva);
        cmd.Parameters.AddWithValue("@AcOdAddDistance", AcOdAddDistance);
        cmd.Parameters.AddWithValue("@CmbAcOdPreference", CmbAcOdPreference);




        cmd.Parameters.AddWithValue("@AcOsDvSpherical", AcOsDvSpherical);
        cmd.Parameters.AddWithValue("@AcOsDvCylindrical", AcOsDvCylindrical);
        cmd.Parameters.AddWithValue("@AcOsDvAxis", AcOsDvAxis);
        cmd.Parameters.AddWithValue("@CmbAcOsDvBCVA", CmbAcOsDvBCVA);
        cmd.Parameters.AddWithValue("@AcOsAddSpherical", AcOsAddSpherical);
        cmd.Parameters.AddWithValue("@CmbAcOsAddBcva", CmbAcOsAddBcva);
        cmd.Parameters.AddWithValue("@AcOsAddDistance", AcOsAddDistance);
        cmd.Parameters.AddWithValue("@CmbAcOsPreference", CmbAcOsPreference);


        //-- Glass Prescription --

        cmd.Parameters.AddWithValue("@AcOdDvSpherical1", AcOdDvSpherical1);
        cmd.Parameters.AddWithValue("@AcOdDvCylindrical1", AcOdDvCylindrical1);
        cmd.Parameters.AddWithValue("@AcOdDvAxis1", AcOdDvAxis1);
        cmd.Parameters.AddWithValue("@CmbAcOdDvBCVA1", CmbAcOdDvBCVA1);
        cmd.Parameters.AddWithValue("@AcOdAddSpherical1", AcOdAddSpherical1);
        cmd.Parameters.AddWithValue("@CmbAcOdAddBcva1", CmbAcOdAddBcva1);
        cmd.Parameters.AddWithValue("@AcOdAddDistance1", AcOdAddDistance1);
        cmd.Parameters.AddWithValue("@CmbAcOdPreference1", CmbAcOdPreference1);




        cmd.Parameters.AddWithValue("@AcOsDvSpherical1", AcOsDvSpherical1);
        cmd.Parameters.AddWithValue("@AcOsDvCylindrical1", AcOsDvCylindrical1);
        cmd.Parameters.AddWithValue("@AcOsDvAxis1", AcOsDvAxis1);
        cmd.Parameters.AddWithValue("@CmbAcOsDvBCVA1", CmbAcOsDvBCVA1);
        cmd.Parameters.AddWithValue("@AcOsAddSpherical1", AcOsAddSpherical1);
        cmd.Parameters.AddWithValue("@CmbAcOsAddBcva1", CmbAcOsAddBcva1);
        cmd.Parameters.AddWithValue("@AcOsAddDistance1", AcOsAddDistance1);
        cmd.Parameters.AddWithValue("@CmbAcOsPreference1", CmbAcOsPreference1);



        //--Proposed Prism--

        cmd.Parameters.AddWithValue("@AcOdPrism1", AcOdPrism1);
        cmd.Parameters.AddWithValue("@CmdAcOdPrism1", CmdAcOdPrism1);
        cmd.Parameters.AddWithValue("@AcOsPrism1", AcOsPrism1);
        cmd.Parameters.AddWithValue("@CmdAcOsPrism1", CmdAcOsPrism1);
        cmd.Parameters.AddWithValue("@AcOdPrism2", AcOdPrism2);

        cmd.Parameters.AddWithValue("@CmbAcOdPrism2", CmbAcOdPrism2);
        cmd.Parameters.AddWithValue("@AcOsPrism2", AcOsPrism2);
        cmd.Parameters.AddWithValue("@CmbAcOsPrism2", CmbAcOsPrism2);




        //Refining Procedure

        cmd.Parameters.AddWithValue("@CmbAcOdRpRefining", CmbAcOdRpRefining);
        cmd.Parameters.AddWithValue("@RadAcOdRpJCC", RadAcOdRpJCC);
        cmd.Parameters.AddWithValue("@RadAcOdRpFogging", RadAcOdRpFogging);
        cmd.Parameters.AddWithValue("@CmbAcOsRpRefining", CmbAcOsRpRefining);
        cmd.Parameters.AddWithValue("@RadAcOsRpJCC", RadAcOsRpJCC);
        cmd.Parameters.AddWithValue("@RadAcOsRpFogging", RadAcOsRpFogging);


        //Intermediate Vision

        cmd.Parameters.AddWithValue("@AcOdIVision", AcOdIVision);
        cmd.Parameters.AddWithValue("@AcOdIVRDistace", AcOdIVRDistace);
        cmd.Parameters.AddWithValue("@AcOdPrismValue", AcOdPrismValue);
        cmd.Parameters.AddWithValue("@CmbAcOdPrismType", CmbAcOdPrismType);
        cmd.Parameters.AddWithValue("@AcOsIVision", AcOsIVision);
        cmd.Parameters.AddWithValue("@AcOsIVRDistace", AcOsIVRDistace);
        cmd.Parameters.AddWithValue("@AcOsPrismValue", AcOsPrismValue);
        cmd.Parameters.AddWithValue("@CmbAcOsPrismType", CmbAcOsPrismType);


        // Diagnosis Result
        cmd.Parameters.AddWithValue("@AcOdDiagnosis", AcOdDiagnosis);
        cmd.Parameters.AddWithValue("@AcOsDiagnosis", AcOsDiagnosis);


        // Summary

        cmd.Parameters.AddWithValue("@Summary", Summary);

        //currentuserid
        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);
       

        cmd.ExecuteNonQuery();

        con.Close();


        //SaveDataToDatabase();
        //GenerateHtmlSummary();

        btnSave8.Visible = false;
        btnmod.Visible = true;

    }
    
   
    private void Updatedata( string prescriptionDateOD, string textValueOD, string sphericalOD, string cylindricalOD, string axisOD, string addOD, string prismOD, string baseDirectionOD, string lensTypeOD, string selectedGlassStatusOD, string remarksOD)
    {
        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];
        string studentid = Request.QueryString["studentID"];

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        string UpdateQuery = "UPDATE ESO_CAMP_MR_PG SET ECMPG_DATE=@PrescriptionDate,ECMPG_SPHERICAL=@Spherical,ECMPG_CYLINDRICAL=@Cylindrical,ECMPG_AXIS=@Axis,ECMPG_ADD= @Add,ECMPG_PRISM=@Prism,ECMPG_MUSCLE_POWER=@MusclePower,ECMPG_LENS_TYPE=@LensType,ECMPG_GLASS_STATUS_CODE=@GlassStatus,";
        UpdateQuery  += "ECMPG_REMARKS = @Remarks,ECMPG_VISIT_NO = 'VT01',ECMPG_LAST_UPD_UID = @currentuserid,ECMPG_LAST_UPD_DT = GETDATE() WHERE ECMPG_STD_NUMBER = @studentid and ECMPG_EYE=@TextValue";


        using (SqlCommand cmd = new SqlCommand(UpdateQuery, con))
        {
            cmd.Parameters.AddWithValue("@studentid", studentid);
          //  cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
            cmd.Parameters.AddWithValue("@PrescriptionDate", prescriptionDateOD);
            cmd.Parameters.AddWithValue("@TextValue", textValueOD);
            cmd.Parameters.AddWithValue("@Spherical", sphericalOD);
            cmd.Parameters.AddWithValue("@Cylindrical", cylindricalOD);
            cmd.Parameters.AddWithValue("@Axis", axisOD);
            cmd.Parameters.AddWithValue("@Add", addOD);
            cmd.Parameters.AddWithValue("@Prism", prismOD);
            cmd.Parameters.AddWithValue("@MusclePower", baseDirectionOD);
            cmd.Parameters.AddWithValue("@LensType", lensTypeOD);
            cmd.Parameters.AddWithValue("@GlassStatus", selectedGlassStatusOD);
            cmd.Parameters.AddWithValue("@Remarks", remarksOD);
            cmd.Parameters.AddWithValue("@currentuserid", currentuserid);

            cmd.ExecuteNonQuery();
        }
        con.Close();
    }

    //Updatedata1(connection, serialNumber, prescriptionDateOS, textValueOS, sphericalOS, cylindricalOS, axisOS, addOS, prismOS, baseDirectionOS, lensTypeOS, selectedGlassStatusOS, remarksOS);


    private void Updatedata1(  string prescriptionDateOS, string textValueOS, string sphericalOS, string cylindricalOS, string axisOS, string addOS, string prismOS, string baseDirectionOS, string lensTypeOS, string selectedGlassStatusOS, string remarksOS)
    {
        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];
        string studentid = Request.QueryString["studentID"];


        string UpdateQuery = "UPDATE ESO_CAMP_MR_PG SET ECMPG_DATE=@PrescriptionDate,ECMPG_SPHERICAL=@Spherical,ECMPG_CYLINDRICAL=@Cylindrical,ECMPG_AXIS=@Axis,ECMPG_ADD= @Add,ECMPG_PRISM=@Prism,ECMPG_MUSCLE_POWER=@MusclePower,ECMPG_LENS_TYPE=@LensType,ECMPG_GLASS_STATUS_CODE=@GlassStatus,";
        UpdateQuery += "ECMPG_REMARKS = @Remarks,ECMPG_VISIT_NO = 'VT01',ECMPG_LAST_UPD_UID = @currentuserid,ECMPG_LAST_UPD_DT = GETDATE() WHERE ECMPG_STD_NUMBER = @studentid and ECMPG_EYE=@TextValue";


        using (SqlCommand cmd = new SqlCommand(UpdateQuery, con))
        {
            cmd.Parameters.AddWithValue("@studentid", studentid);
           // cmd.Parameters.AddWithValue("@SerialNumber", serialNumber);
            cmd.Parameters.AddWithValue("@PrescriptionDate", prescriptionDateOS);
            cmd.Parameters.AddWithValue("@TextValue", textValueOS);
            cmd.Parameters.AddWithValue("@Spherical", sphericalOS);
            cmd.Parameters.AddWithValue("@Cylindrical", cylindricalOS);
            cmd.Parameters.AddWithValue("@Axis", axisOS);
            cmd.Parameters.AddWithValue("@Add", addOS);
            cmd.Parameters.AddWithValue("@Prism", prismOS);
            cmd.Parameters.AddWithValue("@MusclePower", baseDirectionOS);
            cmd.Parameters.AddWithValue("@LensType", lensTypeOS);
            cmd.Parameters.AddWithValue("@GlassStatus", selectedGlassStatusOS);
            cmd.Parameters.AddWithValue("@Remarks", remarksOS);
            cmd.Parameters.AddWithValue("@currentuserid", currentuserid);

            cmd.ExecuteNonQuery();
        }
    }
    protected void btnmodify_Click(object sender, EventArgs e)
    {
        var eyeod = "OD";
        var eyeos = "OS";
        var eyeou = "OU";




        //Visual Acuity
        string CmbVcOdWithoutGlass = cmbVcOdWithoutGlass.SelectedValue;
        string selectedCmbVcOdWithoutGlass = cmbVcOdWithoutGlass.SelectedItem.Text;
        if (selectedCmbVcOdWithoutGlass == "---- Select ---- ")
        {
            selectedCmbVcOdWithoutGlass = "";
        }
        string CmbVcOdWithoutNearvision = cmbVcOdWithoutNearvision.SelectedValue;

        string selectedCmbVcOdWithoutNearvision = cmbVcOdWithoutNearvision.SelectedItem.Text;
        if (selectedCmbVcOdWithoutNearvision == "---- Select ---- ")
        {
            selectedCmbVcOdWithoutNearvision = "";
        }
        string VcOdWithoutDistance = txtVcOdWithoutDistance.Text;
        string CmbVcOdWithGlass = cmbVcOdWithGlass.SelectedValue;

        string selectedCmbVcOdWithGlass = cmbVcOdWithGlass.SelectedItem.Text;
        if (selectedCmbVcOdWithGlass == "---- Select ---- ")
        {
            selectedCmbVcOdWithGlass = "";
        }
        string CmbVcOdWithNearvision = cmbVcOdWithNearvision.SelectedValue;

        string selectedCmbVcOdWithNearvision = cmbVcOdWithNearvision.SelectedItem.Text;
        if (selectedCmbVcOdWithNearvision == "---- Select ---- ")
        {
            selectedCmbVcOdWithNearvision = "";
        }
        string VcOdWithDistance = txtVcOdWithDistance.Text;
        string CmbVcOdWithoutContact = cmbVcOdWithoutContact.SelectedValue;

        string selectedCmbVcOdWithoutContact = cmbVcOdWithoutContact.SelectedItem.Text;
        if (selectedCmbVcOdWithoutContact == "---- Select ---- ")
        {
            selectedCmbVcOdWithoutContact = "";
        }
        string CmbVcOdContact = cmbVcOdContact.SelectedValue;

        string selectedCmbVcOdContact = cmbVcOdContact.SelectedItem.Text;
        if (selectedCmbVcOdContact == "---- Select ---- ")
        {
            selectedCmbVcOdContact = "";
        }
        string VcOdContact = txtVcOdContact.Text;
        string CmbVcOdPinhole = cmbVcOdPinhole.SelectedValue;

        string selectedCmbVcOdPinhole = cmbVcOdPinhole.SelectedItem.Text;
        if (selectedCmbVcOdPinhole == "---- Select ---- ")
        {
            selectedCmbVcOdPinhole = "";
        }





        string CmbVcOsWithoutGlass = cmbVcOsWithoutGlass.SelectedValue;

        string selectedCmbVcOsWithoutGlass = cmbVcOsWithoutGlass.SelectedItem.Text;
        if (selectedCmbVcOsWithoutGlass == "---- Select ---- ")
        {
            selectedCmbVcOsWithoutGlass = "";
        }

        string CmbVcOsWithoutNearvision = cmbVcOsWithoutNearvision.SelectedValue;

        string selectedCmbVcOsWithoutNearvision = cmbVcOsWithoutNearvision.SelectedItem.Text;
        if (selectedCmbVcOsWithoutNearvision == "---- Select ---- ")
        {
            selectedCmbVcOsWithoutNearvision = "";
        }

        string VcOsWithoutDistance = txtVcOsWithoutDistance.Text;
        string CmbVcOsWithGlass = cmbVcOsWithGlass.SelectedValue;

        string selectedCmbVcOsWithGlass = cmbVcOsWithGlass.SelectedItem.Text;
        if (selectedCmbVcOsWithGlass == "---- Select ---- ")
        {
            selectedCmbVcOsWithGlass = "";
        }

        string CmbVcOsWithNearvision = cmbVcOsWithNearvision.SelectedValue;
        string selectedCmbVcOsWithNearvision = cmbVcOsWithNearvision.SelectedItem.Text;
        if (selectedCmbVcOsWithNearvision == "---- Select ---- ")
        {
            selectedCmbVcOsWithNearvision = "";
        }
        string VcOsWithDistace = txtVcOsWithDistace.Text;
        string CmbVcOsWithoutContact = cmbVcOsWithoutContact.SelectedValue;
        string selectedCmbVcOsWithoutContact = cmbVcOsWithoutContact.SelectedItem.Text;
        if (selectedCmbVcOsWithoutContact == "---- Select ---- ")
        {
            selectedCmbVcOsWithoutContact = "";
        }
        string CmbVcOsContact = cmbVcOsContact.SelectedValue;
        string selectedCmbVcOsContact = cmbVcOsContact.SelectedItem.Text;
        if (selectedCmbVcOsContact == "---- Select ---- ")
        {
            selectedCmbVcOsContact = "";
        }
        string VcOsContact = txtVcOsContact.Text;
        string CmbVcOsPinhole = cmbVcOsPinhole.SelectedValue;
        string selectedCmbVcOsPinhole = cmbVcOsPinhole.SelectedItem.Text;
        if (selectedCmbVcOsPinhole == "---- Select ---- ")
        {
            selectedCmbVcOsPinhole = "";
        }





        string CmbVcOuWithoutGlass = cmbVcOuWithoutGlass.SelectedValue;

        string selectedCmbVcOuWithoutGlass = cmbVcOuWithoutGlass.SelectedItem.Text;
        if (selectedCmbVcOuWithoutGlass == "---- Select ---- ")
        {
            selectedCmbVcOuWithoutGlass = "";
        }


        string CmbVcOuWithoutNearvision = cmbVcOuWithoutNearvision.SelectedValue;

        string selectedCmbVcOuWithoutNearvision = cmbVcOuWithoutNearvision.SelectedItem.Text;
        if (selectedCmbVcOuWithoutNearvision == "---- Select ---- ")
        {
            selectedCmbVcOuWithoutNearvision = "";
        }
        string VcOuWithoutDistance = txtVcOuWithoutDistance.Text;
        string CmbVcOuWithGlass = cmbVcOuWithGlass.SelectedValue;
        string selectedCmbVcOuWithGlass = cmbVcOuWithGlass.SelectedItem.Text;
        if (selectedCmbVcOuWithGlass == "---- Select ---- ")
        {
            selectedCmbVcOuWithGlass = "";
        }

        string CmbVcOuWithNearvision = cmbVcOuWithNearvision.SelectedValue;
        string selectedCmbVcOuWithNearvision = cmbVcOuWithNearvision.SelectedItem.Text;
        if (selectedCmbVcOuWithNearvision == "---- Select ---- ")
        {
            selectedCmbVcOuWithNearvision = "";
        }

        string VcOuWithDistance = txtVcOuWithDistance.Text;
        string CmbVcOuWithoutContact = cmbVcOuWithoutContact.SelectedValue;

        string selectedCmbVcOuWithoutContact = cmbVcOuWithoutContact.SelectedItem.Text;
        if (selectedCmbVcOuWithoutContact == "---- Select ---- ")
        {
            selectedCmbVcOuWithoutContact = "";
        }


        string CmbVcOuContact = cmbVcOuContact.SelectedValue;

        string selectedCmbVcOuContact = cmbVcOuContact.SelectedItem.Text;
        if (selectedCmbVcOuContact == "---- Select ---- ")
        {
            selectedCmbVcOuContact = "";
        }




        string VcOuContact = txtVcOuContact.Text;
        string CmbVcOuPinhole = cmbVcOuPinhole.SelectedValue;

        string selectedCmbVcOuPinhole = cmbVcOuPinhole.SelectedItem.Text;
        if (selectedCmbVcOuPinhole == "---- Select ---- ")
        {
            selectedCmbVcOuPinhole = "";
        }



        string Type_of_Chart = DD_Type_of_chart.SelectedValue;

        string selectedType_of_Chart = DD_Type_of_chart.SelectedItem.Text;
        if (selectedType_of_Chart == "---- Select ---- ")
        {
            selectedType_of_Chart = "";
        }

        string Near_Vision_Chart = DD_Near_vision_chart.SelectedValue;
        string selectedNear_Vision_Chart = DD_Near_vision_chart.SelectedItem.Text;
        if (selectedNear_Vision_Chart == "---- Select ---- ")
        {
            selectedNear_Vision_Chart = "";
        }



        //Refraction

        string odSpherical = txtRfOdSpherical.Text;
        string odCylindrical = txtRfOdCylindrical.Text;
        string odAxis = txtRfOdAxis.Text;
        string odQuality = cmbRfOdQuality.SelectedValue;

        string selectedodQuality = cmbRfOdQuality.SelectedItem.Text;
        if (selectedodQuality == "---- Select ---- ")
        {
            selectedodQuality = "";
        }

        string odCycloplegic = cmbRfOdCycloplegic.SelectedValue;
        string selectedodCycloplegic = cmbRfOdCycloplegic.SelectedItem.Text;

        if (selectedodCycloplegic == "---- Select ---- ")
        {
            selectedodCycloplegic = "";
        }
        string odWetOdSpherical = txtWetOdSpherical.Text;
        string WetOdCylindrical = txtWetOdCylindrical.Text;
        string WetOdAxis = txtWetOdAxis.Text;





        string OsSpherical = txtRfOsSpherical.Text;
        string OsCylindrical = txtRfOsCylindrical.Text;
        string OsAxis = txtRfOsAxis.Text;
        string OsQuality = cmbRfOsQuality.SelectedValue;
        string selectedOsQuality = cmbRfOsQuality.SelectedItem.Text;
        if (selectedOsQuality == "---- Select ---- ")
        {
            selectedOsQuality = "";
        }
        string OsCycloplegic = cmbRfOsCycloplegic.SelectedValue;
        string selectedOsCycloplegic = cmbRfOsCycloplegic.SelectedItem.Text;
        if (selectedOsCycloplegic == "---- Select ---- ")
        {
            selectedOsCycloplegic = "";
        }
        string WetOsSpherical = txtWetOsSpherical.Text;
        string WetOsCylindrical = txtWetOsCylindrical.Text;
        string WetOsAxis = txtWetOsAxis.Text;




        //-- Acceptance ----


        string AcOdDvSpherical = txtAcOdDvSphericalOpt.Text;
        string AcOdDvCylindrical = txtAcOdDvCylindricalOpt.Text;
        string AcOdDvAxis = txtAcOdDvAxisOpt.Text;
        string CmbAcOdDvBCVA = cmbAcOdDvBCVAOpt.SelectedValue;
        string selectedCmbAcOdDvBCVA = cmbAcOdDvBCVAOpt.SelectedItem.Text;
        if (selectedCmbAcOdDvBCVA == "---- Select ---- ")
        {
            selectedCmbAcOdDvBCVA = "";
        }
        string AcOdAddSpherical = txtAcOdAddSphericalOpt.Text;
        string CmbAcOdAddBcva = cmbAcOdAddBcvaOpt.SelectedValue;
        string selectedCmbAcOdAddBcva = cmbAcOdAddBcvaOpt.SelectedItem.Text;
        if (selectedCmbAcOdAddBcva == "---- Select ---- ")
        {
            selectedCmbAcOdAddBcva = "";
        }
        string AcOdAddDistance = txtAcOdAddDistanceOpt.Text;
        string CmbAcOdPreference = cmbAcOdPreferenceOpt.SelectedValue;
        string selectedCmbAcOdPreference = cmbAcOdPreferenceOpt.SelectedItem.Text;
        if (selectedCmbAcOdPreference == "---- Select ---- ")
        {
            selectedCmbAcOdPreference = "";
        }

        string AcOsDvSpherical = txtAcOsDvSphericalOpt.Text;
        string AcOsDvCylindrical = txtAcOsDvCylindricalOpt.Text;
        string AcOsDvAxis = txtAcOsDvAxisOpt.Text;
        string CmbAcOsDvBCVA = cmbAcOsDvBCVAOpt.SelectedValue;
        string selectedCmbAcOsDvBCVA = cmbAcOsDvBCVAOpt.SelectedItem.Text;
        if (selectedCmbAcOsDvBCVA == "---- Select ---- ")
        {
            selectedCmbAcOsDvBCVA = "";
        }
        string AcOsAddSpherical = txtAcOsAddSphericalOpt.Text;
        string CmbAcOsAddBcva = cmbAcOsAddBcvaOpt.SelectedValue;
        string selectedCmbAcOsAddBcva = cmbAcOsAddBcvaOpt.SelectedItem.Text;
        if (selectedCmbAcOsAddBcva == "---- Select ---- ")
        {
            selectedCmbAcOsAddBcva = "";
        }
        string AcOsAddDistance = txtAcOsAddDistanceOpt.Text;
        string CmbAcOsPreference = cmbAcOsPreferenceOpt.SelectedValue;
        string selectedCmbAcOsPreference = cmbAcOsPreferenceOpt.SelectedItem.Text;
        if (selectedCmbAcOsPreference == "---- Select ---- ")
        {
            selectedCmbAcOsPreference = "";
        }





        //--Glass Prescription--



        string AcOdDvSpherical1 = txtAcOdDvSpherical.Text;
        string AcOdDvCylindrical1 = txtAcOdDvCylindrical.Text;
        string AcOdDvAxis1 = txtAcOdDvAxis.Text;
        string CmbAcOdDvBCVA1 = cmbAcOdDvBCVA.SelectedValue;

        string selectedCmbAcOdDvBCVA1 = cmbAcOdDvBCVA.SelectedItem.Text;
        if (selectedCmbAcOdDvBCVA1 == "---- Select ---- ")
        {
            selectedCmbAcOdDvBCVA1 = "";
        }
        string AcOdAddSpherical1 = txtAcOdAddSpherical.Text;
        string CmbAcOdAddBcva1 = cmbAcOdAddBcva.SelectedValue;
        string selectedCmbAcOdAddBcva1 = cmbAcOdAddBcva.SelectedItem.Text;
        if (selectedCmbAcOdAddBcva1 == "---- Select ---- ")
        {
            selectedCmbAcOdAddBcva1 = "";
        }

        string AcOdAddDistance1 = txtAcOdAddDistance.Text;
        string CmbAcOdPreference1 = cmbAcOdPreference.SelectedValue;
        string selectedCmbAcOdPreference1 = cmbAcOdPreference.SelectedItem.Text;
        if (selectedCmbAcOdPreference1 == "---- Select ---- ")
        {
            selectedCmbAcOdPreference1 = "";
        }



        string AcOsDvSpherical1 = txtAcOsDvSpherical.Text;
        string AcOsDvCylindrical1 = txtAcOsDvCylindrical.Text;
        string AcOsDvAxis1 = txtAcOsDvAxis.Text;
        string CmbAcOsDvBCVA1 = cmbAcOsDvBCVA.SelectedValue;
        string selectedCmbAcOsDvBCVA1 = cmbAcOsDvBCVA.SelectedItem.Text;
        if (selectedCmbAcOsDvBCVA1 == "---- Select ---- ")
        {
            selectedCmbAcOsDvBCVA1 = "";
        }
        string AcOsAddSpherical1 = txtAcOsAddSpherical.Text;
        string CmbAcOsAddBcva1 = cmbAcOsAddBcva.SelectedValue;
        string selectedCmbAcOsAddBcva1 = cmbAcOsAddBcva.SelectedItem.Text;
        if (selectedCmbAcOsAddBcva1 == "---- Select ---- ")
        {
            selectedCmbAcOsAddBcva1 = "";
        }
        string AcOsAddDistance1 = txtAcOsAddDistance.Text;
        string CmbAcOsPreference1 = cmbAcOsPreference.SelectedValue;
        string selectedCmbAcOsPreference1 = cmbAcOsPreference.SelectedItem.Text;
        if (selectedCmbAcOsPreference1 == "---- Select ---- ")
        {
            selectedCmbAcOsPreference1 = "";
        }


        //--Proposed Prism--
        string AcOdPrism1 = txtAcOdPrism1.Text;
        string CmdAcOdPrism1 = cmbAcOdPrism1.SelectedValue;
        string AcOsPrism1 = txtAcOsPrism1.Text;
        string CmdAcOsPrism1 = cmbAcOsPrism1.SelectedValue;
        string AcOdPrism2 = txtAcOdPrism2.Text;
        string CmbAcOdPrism2 = cmbAcOdPrism2.SelectedValue;
        string AcOsPrism2 = txtAcOsPrism2.Text;
        string CmbAcOsPrism2 = cmbAcOsPrism2.SelectedValue;


        //Refining Procedure

        string CmbAcOdRpRefining = cmbAcOdRpRefining.SelectedValue;
        string RadAcOdRpJCC = radAcOdRpJCC.SelectedValue;

        string RadAcOdRpFogging = radAcOdRpFogging.SelectedValue;

        string CmbAcOsRpRefining = cmbAcOsRpRefining.SelectedValue;

        string RadAcOsRpJCC = radAcOsRpJCC.SelectedValue;

        string RadAcOsRpFogging = radAcOsRpFogging.SelectedValue;



        //Intermediate Vision

        string AcOdIVision = txtAcOdIVision.Text;
        string AcOdIVRDistace = txtAcOdIVRDistace.Text;
        string AcOdPrismValue = txtAcOdPrismValue.Text;
        string CmbAcOdPrismType = cmbAcOdPrismType.SelectedValue;
        string AcOsIVision = txtAcOsIVision.Text;
        string AcOsIVRDistace = txtAcOsIVRDistace.Text;
        string AcOsPrismValue = txtAcOsPrismValue.Text;
        string CmbAcOsPrismType = cmbAcOsPrismType.SelectedValue;


        // Diagnosis Result

        string AcOdDiagnosis = txtAcOdDiagnosis.Text;
        string AcOsDiagnosis = txtAcOsDiagnosis.Text;






        string dayOD = DayDropdown_OD?.SelectedValue;
        string monthOD = monthDropdown_OD?.SelectedValue;
        string YearOD = yearOD?.Text;


        string prescriptionDateOD = $"{dayOD}/{monthOD}/{YearOD}";




        string textValueOD = lblEyeOD.Text;


        string sphericalOD = Spherical_OD.Text;


        string cylindricalOD = Cylindrical_OD.Text;


        string axisOD = Axis_OD.Text;


        string addOD = Add_OD.Text;


        string prismOD = Prism_OD.Text;


        string cmbbaseDirectionOD = BaseDirectionOD.SelectedValue;
        string selectedcmbbaseDirectionOD = BaseDirectionOD.SelectedItem.Text;
        if (selectedcmbbaseDirectionOD == "---- Select ---- ")
        {
            selectedcmbbaseDirectionOD = "";
        }


        string cmdlensTypeOD = LensType_OD.SelectedValue;
        string selectedcmbLensType_OD = LensType_OD.SelectedItem.Text;
        if (selectedcmbLensType_OD == "---- Select ---- ")
        {
            selectedcmbLensType_OD = "";
        }


        string selectedGlassStatusOD = GlassStatus_OD.Text;


        string remarksOD = Remarks_OD.Text;


        string dayOS = DayDropdown_OS.SelectedValue;
        string monthOS = MonthDropdown_OS.SelectedValue;
        string YearOS = yearOS?.Text;


        string prescriptionDateOS = $"{dayOS}/{monthOS}/{YearOS}"; // You might need to adjust the format




        string textValueOS = lbl_os.Text;


        string sphericalOS = Spherical_OS.Text;


        string cylindricalOS = Cylindrical_OS.Text;


        string axisOS = Axis_OS.Text;


        string addOS = Add_OS.Text;


        string prismOS = Prism_OS.Text;

        string cmbbaseDirectionOS = BaseDirectionOS.SelectedValue;
        string selectedcmbbaseDirectionOS = BaseDirectionOS.SelectedItem.Text;
        if (selectedcmbbaseDirectionOS == "---- Select ---- ")
        {
            selectedcmbbaseDirectionOS = "";
        }


        string cmdlensTypeOS = LensType_OS.SelectedValue;
        string selectedcmbLensType_OS = LensType_OS.SelectedItem.Text;
        if (selectedcmbLensType_OS == "---- Select ---- ")
        {
            selectedcmbLensType_OS = "";
        }

        string selectedGlassStatusOS = GlassStatus_OS.Text;


        string remarksOS = Remarks_OS.Text;

      



        Updatedata( prescriptionDateOD, textValueOD, sphericalOD, cylindricalOD, axisOD, addOD, prismOD, cmbbaseDirectionOD, cmdlensTypeOD, selectedGlassStatusOD, remarksOD);


        Updatedata( prescriptionDateOS, textValueOS, sphericalOS, cylindricalOS, axisOS, addOS, prismOS, cmbbaseDirectionOS, cmdlensTypeOS, selectedGlassStatusOS, remarksOS);







        string cssStyles = @"<style> .pink-cell { background-color: #e7a7da94;  color: black; } .black-cell { background-color: #ebeeefe0;  color: black;  } </style>";



        // Generating Summary

        string summaryTable = "<table style='background-color: white; width: 1200px;'>";





        summaryTable += "<tr style='background-color: #e5f4fb;'><th colspan='1' style='padding-right: 10px;'>Prescription Datesr</th><th colspan='1'>Eye</th><th colspan='1'>Spherical</th><th colspan='1'>Cylindrical</th><th colspan='1'>Axis</th><th colspan='1'>Add</th><th colspan='1'>Prism</th><th colspan='1'>Base Direction</th><th colspan='1'>Lens Type</th><th colspan='1'>Glass Status</th><th colspan='1'>Remarks</th></tr>";


        summaryTable += "<tr><td class='" + GetCellColorClass1(prescriptionDateOD) + "'>" + prescriptionDateOD + "</td><td>" + textValueOD + "</td><td class='" + GetCellColorClass1(sphericalOD) + "'>" + sphericalOD + "</td><td class='" + GetCellColorClass1(cylindricalOD) + "'>" + cylindricalOD + "</td><td class='" + GetCellColorClass1(axisOD) + "'>" + axisOD + "</td><td class='" + GetCellColorClass1(addOD) + "'>" + addOD + "</td><td class='" + GetCellColorClass1(prismOD) + "'>" + prismOD + "</td><td class='" + GetCellColorClass1(selectedcmbbaseDirectionOD) + "'>" + selectedcmbbaseDirectionOD + "</td><td class='" + GetCellColorClass1(selectedcmbLensType_OD) + "'>" + selectedcmbLensType_OD + "</td><td class='" + GetCellColorClass1(selectedGlassStatusOD) + "'>" + selectedGlassStatusOD + "</td><td class='" + GetCellColorClass1(remarksOD) + "'>" + remarksOD + "</td></tr>";

        summaryTable += "<tr><td class='" + GetCellColorClass1(prescriptionDateOS) + "'>" + prescriptionDateOS + "</td><td>" + textValueOS + "</td><td class='" + GetCellColorClass1(sphericalOS) + "'>" + sphericalOS + "</td><td class='" + GetCellColorClass1(cylindricalOS) + "'>" + cylindricalOS + "</td><td class='" + GetCellColorClass1(axisOS) + "'>" + axisOS + "</td><td class='" + GetCellColorClass1(addOS) + "'>" + addOS + "</td><td class='" + GetCellColorClass1(prismOS) + "'>" + prismOS + "</td><td class='" + GetCellColorClass1(selectedcmbbaseDirectionOS) + "'>" + selectedcmbbaseDirectionOS + "</td><td class='" + GetCellColorClass1(selectedcmbLensType_OS) + "'>" + selectedcmbLensType_OS + "</td><td class='" + GetCellColorClass1(selectedGlassStatusOS) + "'>" + selectedGlassStatusOS + "</td><td class='" + GetCellColorClass1(remarksOS) + "'>" + remarksOS + "</td></tr>";



        summaryTable += "<tr style='background-color:#bd2020d4;'><th colspan='11' style='width: 300px; color:white;'>VISUAL ACUITY</th></tr>";


        summaryTable += "<tr style='background-color: #b498cf96;'><th colspan='4' style='padding-right: 10px;'>Without Glass</th><th colspan='3'>With Glass</th><th colspan='3'>Contact Lens</th><th colspan='1'>With PH</th></tr>";


        summaryTable += "<tr><td>" + eyeod + "</td><td class='" + GetCellColorClass(selectedCmbVcOdWithoutGlass) + "'>" + selectedCmbVcOdWithoutGlass + "</td><td class='" + GetCellColorClass(selectedCmbVcOdWithoutNearvision) + "'>" + selectedCmbVcOdWithoutNearvision + "</td><td class='" + GetCellColorClass(VcOdWithoutDistance) + "'>" + VcOdWithoutDistance + "</td><td class='" + GetCellColorClass(selectedCmbVcOdWithGlass) + "'>" + selectedCmbVcOdWithGlass + "</td><td class='" + GetCellColorClass(selectedCmbVcOdWithNearvision) + "'>" + selectedCmbVcOdWithNearvision + "</td><td class='" + GetCellColorClass(VcOdWithDistance) + "'>" + VcOdWithDistance + "</td><td class='" + GetCellColorClass(selectedCmbVcOdWithoutContact) + "'>" + selectedCmbVcOdWithoutContact + "</td><td class='" + GetCellColorClass(selectedCmbVcOdContact) + "'>" + selectedCmbVcOdContact + "</td><td class='" + GetCellColorClass(VcOdContact) + "'>" + VcOdContact + "</td><td class='" + GetCellColorClass(selectedCmbVcOdPinhole) + "'>" + selectedCmbVcOdPinhole + "</td></tr>";

        summaryTable += "<tr><td>" + eyeos + "</td><td class='" + GetCellColorClass(selectedCmbVcOsWithoutGlass) + "'>" + selectedCmbVcOsWithoutGlass + "</td><td class='" + GetCellColorClass(selectedCmbVcOsWithoutNearvision) + "'>" + selectedCmbVcOsWithoutNearvision + "</td><td class='" + GetCellColorClass(VcOsWithoutDistance) + "'>" + VcOsWithoutDistance + "</td><td class='" + GetCellColorClass(selectedCmbVcOsWithGlass) + "'>" + selectedCmbVcOsWithGlass + "</td><td class='" + GetCellColorClass(selectedCmbVcOsWithNearvision) + "'>" + selectedCmbVcOsWithNearvision + "</td><td class='" + GetCellColorClass(VcOsWithDistace) + "'>" + VcOsWithDistace + "</td><td class='" + GetCellColorClass(selectedCmbVcOsWithoutContact) + "'>" + selectedCmbVcOsWithoutContact + "</td><td class='" + GetCellColorClass(selectedCmbVcOsContact) + "'>" + selectedCmbVcOsContact + "</td><td class='" + GetCellColorClass(VcOsContact) + "'>" + VcOsContact + "</td><td class='" + GetCellColorClass(selectedCmbVcOsPinhole) + "'>" + selectedCmbVcOsPinhole + "</td></tr>";

        summaryTable += "<tr><td>" + eyeou + "</td><td class='" + GetCellColorClass(selectedCmbVcOuWithoutGlass) + "'>" + selectedCmbVcOuWithoutGlass + "</td><td class='" + GetCellColorClass(selectedCmbVcOuWithoutNearvision) + "'>" + selectedCmbVcOuWithoutNearvision + "</td><td class='" + GetCellColorClass(VcOuWithoutDistance) + "'>" + VcOuWithoutDistance + "</td><td class='" + GetCellColorClass(selectedCmbVcOuWithGlass) + "'>" + selectedCmbVcOuWithGlass + "</td><td class='" + GetCellColorClass(selectedCmbVcOuWithNearvision) + "'>" + selectedCmbVcOuWithNearvision + "</td><td class='" + GetCellColorClass(VcOuWithDistance) + "'>" + VcOuWithDistance + "</td><td class='" + GetCellColorClass(selectedCmbVcOuWithoutContact) + "'>" + selectedCmbVcOuWithoutContact + "</td><td class='" + GetCellColorClass(selectedCmbVcOuContact) + "'>" + selectedCmbVcOuContact + "</td><td class='" + GetCellColorClass(VcOuContact) + "'>" + VcOuContact + "</td><td class='" + GetCellColorClass(selectedCmbVcOuPinhole) + "'>" + selectedCmbVcOuPinhole + "</td></tr>";



        summaryTable += "<tr><td><strong>Type of Chart:</strong></td><td class='" + GetCellColorClass(selectedType_of_Chart) + "'>" + selectedType_of_Chart + "</td><td><strong>Near Vision Chart:</strong></td><td class='" + GetCellColorClass(selectedNear_Vision_Chart) + "'>" + selectedNear_Vision_Chart + "</td></tr>";

        summaryTable += "<tr style='background-color: #bd2020d4;'><th colspan='10' style='width: 300px; color:white;'>REFRACTION</th></tr>";

        //summaryTable += "<tr style='background-color: #b498cf96;'><th colspan='10'>RatinoScopy, Quality of, Cycloplegic</th></tr>";

        summaryTable += "<tr style='background-color: #b498cf96;'><th colspan='4' style='padding-right: 10px;'>RatinoScopy</th><th colspan='1'>Quality of</th><th colspan='5'>Auto Refraction</ th></tr>";

        summaryTable += "<tr style='background-color: #b498cf96;'><th>EYE</th><th>DSPH</th><th>DCYL</th><th>AXIS</th><th>Reflex</th><th>Auto Refraction</th><th>EYE</ th><th>DSPH</th><th>DCYL</th><th>AXIS</th></tr>";
        //summaryTable += "<tr style='background-color: #b498cf96;'><th>EYE</th><th>DSPH</th><th>DCYL</th><th>AXIS</th><th>Reflex</th><th>Type</th><th>DSPH</th><th>DCYL</th><th>Axis</th></tr>";


        summaryTable += "<tr><td>" + eyeod + "</td><td class='" + GetCellColorClass(odSpherical) + "'>" + odSpherical + "</td><td class='" + GetCellColorClass(odCylindrical) + "'>" + odCylindrical + "</td><td class='" + GetCellColorClass(odAxis) + "'>" + odAxis + "</td><td class='" + GetCellColorClass(selectedodQuality) + "'>" + selectedodQuality + "</td><td class='" + GetCellColorClass(selectedodCycloplegic) + "'>" + selectedodCycloplegic + " </td><td>" + eyeod + "</td><td class='" + GetCellColorClass(odWetOdSpherical) + "'>" + odWetOdSpherical + "</td><td class='" + GetCellColorClass(WetOdCylindrical) + "'>" + WetOdCylindrical + "</td><td class='" + GetCellColorClass(WetOdAxis) + "'>" + WetOdAxis + "</td></tr>";

        summaryTable += "<tr><td>" + eyeos + "</td><td class='" + GetCellColorClass(OsSpherical) + "'>" + OsSpherical + "</td><td class='" + GetCellColorClass(OsCylindrical) + "'>" + OsCylindrical + "</td><td class='" + GetCellColorClass(OsAxis) + "'>" + OsAxis + "</td><td class='" + GetCellColorClass(selectedOsQuality) + "'>" + selectedOsQuality + "</td><td class='" + GetCellColorClass(selectedOsCycloplegic) + "'>" + selectedOsCycloplegic + "</td><td>" + eyeos + "</td><td class='" + GetCellColorClass(WetOsSpherical) + "'>" + WetOsSpherical + "</td><td class='" + GetCellColorClass(WetOsCylindrical) + "'>" + WetOsCylindrical + "</td><td class='" + GetCellColorClass(WetOsAxis) + "'>" + WetOsAxis + "</td></tr>";


        summaryTable += "<br />";
        summaryTable += "<br />";

        summaryTable += "<tr style='background-color: #bd2020d4;'><th colspan='10' style='width: 300px; color:white;'>ACCEPTANCE</th></tr>";


        summaryTable += "<tr style='background-color: #b498cf96;'><th>EYE</th><th>DSPH</th><th>DCYL</th><th>AXIS</th><th>BCVA</th><th>EYE</th><th>DSPH</th><th>BCVA</th><th>CM</th><th>Preference</th></tr>";




        summaryTable += "<tr><td>" + eyeod + "</td><td class='" + GetCellColorClass(AcOdDvSpherical) + "'>" + AcOdDvSpherical + "</td><td class='" + GetCellColorClass(AcOdDvCylindrical) + "'>" + AcOdDvCylindrical + "</td><td class='" + GetCellColorClass(AcOdDvAxis) + "'>" + AcOdDvAxis + "</td><td class='" + GetCellColorClass(selectedCmbAcOdDvBCVA) + "'>" + selectedCmbAcOdDvBCVA + "</td><td>" + eyeod + "</td><td class='" + GetCellColorClass(AcOdAddSpherical) + "'>" + AcOdAddSpherical + "</td><td class='" + GetCellColorClass(selectedCmbAcOdAddBcva) + "'>" + selectedCmbAcOdAddBcva + "</td><td class='" + GetCellColorClass(AcOdAddDistance) + "'>" + AcOdAddDistance + "</td><td class='" + GetCellColorClass(selectedCmbAcOdPreference) + "'>" + selectedCmbAcOdPreference + "</td></tr>";
        summaryTable += "<tr><td>" + eyeos + "</td><td class='" + GetCellColorClass(AcOsDvSpherical) + "'>" + AcOsDvSpherical + "</td><td class='" + GetCellColorClass(AcOsDvCylindrical) + "'>" + AcOsDvCylindrical + "</td><td class='" + GetCellColorClass(AcOsDvAxis) + "'>" + AcOsDvAxis + "</td><td class='" + GetCellColorClass(selectedCmbAcOsDvBCVA) + "'>" + selectedCmbAcOsDvBCVA + "</td><td>" + eyeos + "</td><td class='" + GetCellColorClass(AcOsAddSpherical) + "'>" + AcOsAddSpherical + "</td><td class='" + GetCellColorClass(selectedCmbAcOsAddBcva) + "'>" + selectedCmbAcOsAddBcva + "</td><td class='" + GetCellColorClass(AcOsAddDistance) + "'>" + AcOsAddDistance + "</td><td class='" + GetCellColorClass(selectedCmbAcOsPreference) + "'>" + selectedCmbAcOsPreference + "</td></tr>";




        summaryTable += "<br />";
        summaryTable += "<br />";




        summaryTable += "<tr style='background-color: #bd2020d4;'><th colspan='10' style='width: 300px; color:white;'>GLASS PRESCRIPTION </th></tr>";



        summaryTable += "<tr style='background-color: #b498cf96;'><th colspan='5' style='padding-right: 10px;'>Distance Vision</th><th colspan='4'>Add</th><th colspan='1'>Acceptance</th></tr>";


        summaryTable += "<tr style='background-color: #b498cf96;'><th>EYE</th><th>DSPH</th><th>DCYL</th><th>AXIS</th><th>BCVA</th><th>EYE</th><th>DSPH</th><th>BCVA</th><th>CM</th><th>Preference</th></tr>";




        summaryTable += "<tr><td>" + eyeod + "</td><td class='" + GetCellColorClass(AcOdDvSpherical1) + "'>" + AcOdDvSpherical1 + "</td><td class='" + GetCellColorClass(AcOdDvCylindrical1) + "'>" + AcOdDvCylindrical1 + "</td><td class='" + GetCellColorClass(AcOdDvAxis1) + "'>" + AcOdDvAxis1 + "</td><td class='" + GetCellColorClass(selectedCmbAcOdDvBCVA1) + "'>" + selectedCmbAcOdDvBCVA1 + "</td><td>" + eyeod + "</td><td class='" + GetCellColorClass(AcOdAddSpherical1) + "'>" + AcOdAddSpherical1 + "</td><td class='" + GetCellColorClass(selectedCmbAcOdAddBcva1) + "'>" + selectedCmbAcOdAddBcva1 + "</td><td class='" + GetCellColorClass(AcOdAddDistance1) + "'>" + AcOdAddDistance1 + "</td><td class='" + GetCellColorClass(selectedCmbAcOdPreference1) + "'>" + selectedCmbAcOdPreference1 + "</td></tr>";
        summaryTable += "<tr><td>" + eyeos + "</td><td class='" + GetCellColorClass(AcOsDvSpherical1) + "'>" + AcOsDvSpherical1 + "</td><td class='" + GetCellColorClass(AcOsDvCylindrical1) + "'>" + AcOsDvCylindrical1 + "</td><td class='" + GetCellColorClass(AcOsDvAxis1) + "'>" + AcOsDvAxis1 + "</td><td class='" + GetCellColorClass(selectedCmbAcOsDvBCVA1) + "'>" + selectedCmbAcOsDvBCVA1 + "</td><td>" + eyeos + "</td><td class='" + GetCellColorClass(AcOsAddSpherical1) + "'>" + AcOsAddSpherical1 + "</td><td class='" + GetCellColorClass(selectedCmbAcOsAddBcva1) + "'>" + selectedCmbAcOsAddBcva1 + "</td><td class='" + GetCellColorClass(AcOsAddDistance1) + "'>" + AcOsAddDistance1 + "</td><td class='" + GetCellColorClass(selectedCmbAcOsPreference1) + "'>" + selectedCmbAcOsPreference1 + "</td></tr>";


        summaryTable += "<br />";
        summaryTable += "<br />";

        summaryTable += "</table>";


        string Summary_pgp = summaryTable;



        lblHtmlSummary1.Text = Summary_pgp;

        string SummaryPGP = cssStyles + Summary_pgp;

     
        string Summary =  SummaryPGP;

        Summary = Summary.Replace("<br />", "");


        string studentid = Request.QueryString["studentID"];


        string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

        con.Open();


        string table = "UPDATE ESO_CAMP_MR_PGP SET ECMP_VC_OD_WITHOUT_GLASS = @CmbVcOdWithoutGlass, ECMP_VC_OD_WITHOUT_NEARVISION = @CmbVcOdWithoutNearvision, ECMP_VC_OD_WITHOUT_DISTANCE = @VcOdWithoutDistance, ECMP_VC_OD_WITH_GLASS = @CmbVcOdWithGlass, ECMP_VC_OD_WITH_NEARVISION = @CmbVcOdWithNearvision,";
        table += "ECMP_VC_OD_WITH_DISTANCE = @VcOdWithDistance, ECMP_OD_DISTANCE_CONTACT = @CmbVcOdWithoutContact, ECMP_OD_NEAR_CONTACT = @CmbVcOdContact, ECMP_OD_DISTANCE_TEXT_CONTACT = @VcOdContact, ECMP_VC_OD_PINHOLE = @CmbVcOdPinhole, ECMP_VC_OS_WITHOUT_GLASS = @CmbVcOsWithoutGlass,";
        table += "ECMP_VC_OS_WITHOUT_NEARVISION = @CmbVcOsWithoutNearvision, ECMP_VC_OS_WITHOUT_DISTANCE = @VcOsWithoutDistance, ECMP_VC_OS_WITH_GLASS = @CmbVcOsWithGlass, ECMP_VC_OS_WITH_NEARVISION = @CmbVcOsWithNearvision, ECMP_VC_OS_WITH_DISTANCE = @VcOsWithDistace, ECMP_OS_DISTANCE_CONTACT = @CmbVcOsWithoutContact,";
        table += "ECMP_OS_NEAR_CONTACT = @CmbVcOsContact, ECMP_OS_DISTANCE_TEXT_CONTACT = @VcOsContact, ECMP_VC_OS_PINHOLE = @CmbVcOsPinhole, ECMP_VC_OU_WITHOUT_GLASS = @CmbVcOuWithoutGlass, ECMP_VC_OU_WITHOUT_NEARVISION = @CmbVcOuWithoutNearvision,";
        table += "ECMP_VC_OU_WITHOUT_DISTANCE = @VcOuWithoutDistance, ECMP_VC_OU_WITH_GLASS = @CmbVcOuWithGlass, ECMP_VC_OU_WITH_NEARVISION = @CmbVcOuWithNearvision, ECMP_VC_OU_WITH_DISTANCE = @VcOuWithDistance, ECMP_OU_DISTANCE_CONTACT = @CmbVcOuWithoutContact, ECMP_OU_NEAR_CONTACT = @CmbVcOuContact, ECMP_OU_DISTANCE_TEXT_CONTACT = @VcOuContact,";
        table += "ECMP_VC_OU_PINHOLE = @CmbVcOuPinhole, ECMP_TYPE_OF_CHART = @Type_of_Chart, ECMP_NEAR_VISION_CHART = @Near_Vision_Chart,";
        table += "ECMP_RF_OD_CYCLOPLEGIC = @OdCycloplegic, ECMP_RF_OS_CYCLOPLEGIC = @OsCycloplegic, ECMP_RF_OD_REFLEX = @OdQuality, ECMP_RF_OS_REFLEX = @OsQuality, ECMP_RF_OD_SPHERICAL = @OdSpherical, ECMP_RF_OD_CYLINDRICAL = @OdCylindrical, ECMP_RF_OD_AXIS = @OdAxis, ECMP_RF_OS_SPHERICAL = @OsSpherical, ECMP_RF_OS_CYLINDRICAL = @OsCylindrical,";
        table += "ECMP_RF_OS_AXIS = @OsAxis, ECMP_RF_WET_OD_SPHERICAL = @odWetOdSpherical, ECMP_RF_WET_OD_CYLINDRICAL = @WetOdCylindrical, ECMP_RF_WET_OD_AXIS = @WetOdAxis, ECMP_RF_WET_OS_SPHERICAL = @WetOsSpherical, ECMP_RF_WET_OS_CYLINDRICAL = @WetOsCylindrical, ECMP_RF_WET_OS_AXIS = @WetOsAxis,";
        table += "ECMP_AC_OD_DV_SPHERICAL_OPT = @AcOdDvSpherical, ECMP_AC_OD_DV_CYLINDRICAL_OPT = @AcOdDvCylindrical, ECMP_AC_OD_DV_AXIS_OPT = @AcOdDvAxis, ECMP_AC_OD_DV_BCVA_OPT = @CmbAcOdDvBCVA, ECMP_AC_OS_DV_SPHERICAL_OPT = @AcOsDvSpherical, ECMP_AC_OS_DV_CYLINDRICAL_OPT = @AcOsDvCylindrical,";
        table += "ECMP_AC_OS_DV_AXIS_OPT = @AcOsDvAxis, ECMP_AC_OS_DV_BCVA_OPT = @CmbAcOsDvBCVA, ECMP_AC_OD_ADD_SPHERICAL_OPT = @AcOdAddSpherical, ECMP_AC_OD_ADD_BCVA_OPT = @CmbAcOdAddBcva,";
        table += "ECMP_AC_OD_ADD_DISTANCE_OPT = @AcOdAddDistance, ECMP_AC_OS_ADD_SPHERICAL_OPT = @AcOsAddSpherical, ECMP_AC_OS_ADD_BCVA_OPT = @CmbAcOsAddBcva,";
        table += "ECMP_AC_OS_ADD_DISTANCE_OPT = @AcOsAddDistance, ECMP_AC_OD_PREFERENCE_OPT = @CmbAcOdPreference, ECMP_AC_OS_PREFERENCE_OPT = @CmbAcOsPreference,";
        table += "ECMP_GP_OD_DV_SPHERICAL_OPT = @AcOdDvSpherical1, ECMP_GP_OD_DV_CYLINDRICAL_OPT = @AcOdDvCylindrical1, ECMP_GP_OD_DV_AXIS_OPT = @AcOdDvAxis1, ECMP_GP_OD_DV_BCVA_OPT = @CmbAcOdDvBCVA1, ECMP_GP_OS_DV_SPHERICAL_OPT = @AcOsDvSpherical1,";
        table += "ECMP_GP_OS_DV_CYLINDRICAL_OPT = @AcOsDvCylindrical1, ECMP_GP_OS_DV_AXIS_OPT = @AcOsDvAxis1, ECMP_GP_OS_DV_BCVA_OPT = @CmbAcOsDvBCVA1,";
        table += "ECMP_GP_OD_ADD_SPHERICAL_OPT = @AcOdAddSpherical1, ECMP_GP_OD_ADD_BCVA_OPT = @CmbAcOdAddBcva1, ECMP_GP_OD_ADD_DISTANCE_OPT = @AcOdAddDistance1, ECMP_GP_OS_ADD_SPHERICAL_OPT = @AcOsAddSpherical1,";
        table += "ECMP_GP_OS_ADD_BCVA_OPT = @CmbAcOsAddBcva1, ECMP_GP_OS_ADD_DISTANCE_OPT = @AcOsAddDistance1, ECMP_GP_OD_PREFERENCE_OPT = @CmbAcOdPreference1, ECMP_GP_OS_PREFERENCE_OPT = @CmbAcOsPreference1,";
        table += "ECMP_AC_OD_PRISM1 = @AcOdPrism1, ECMP_AC_OD_PRISM_TYPE1 = @CmdAcOdPrism1, ECMP_AC_OS_PRISM1 = @AcOsPrism1, ECMP_AC_OS_PRISM_TYPE1 = @CmdAcOsPrism1, ECMP_AC_OD_PRISM2 = @AcOdPrism2, ECMP_AC_OD_PRISM_TYPE2 = @CmbAcOdPrism2, ECMP_AC_OS_PRISM2 = @AcOsPrism2, ECMP_AC_OS_PRISM_TYPE2 = @CmbAcOsPrism2,";
        table += "ECMP_AC_OD_RP_REFINING = @CmbAcOdRpRefining, ECMP_AC_OD_RP_JCC = @RadAcOdRpJCC, ECMP_AC_OD_RP_FOGGING = @RadAcOdRpFogging, ECMP_AC_OS_RP_REFINING = @CmbAcOsRpRefining, ECMP_AC_OS_RP_JCC = @RadAcOsRpJCC, ECMP_AC_OS_RP_FOGGING = @RadAcOsRpFogging,";
        table += "ECMP_AC_OD_IVISION = @AcOdIVision, ECMP_AC_OD_IVRDISTANCE = @AcOdIVRDistace, ECMP_AC_OD_PRISM_VALUE = @AcOdPrismValue, ECMP_AC_OD_PRISM_TYPE = @CmbAcOdPrismType, ECMP_AC_OS_IVISION = @AcOsIVision,";
        table += "ECMP_AC_OS_IVRDISTANCE = @AcOsIVRDistace, ECMP_AC_OS_PRISM_VALUE = @AcOsPrismValue, ECMP_AC_OS_PRISM_TYPE = @CmbAcOsPrismType, ECMP_AC_OD_DIAGNOSIS = @AcOdDiagnosis, ECMP_AC_OS_DIAGNOSIS = @AcOsDiagnosis,";
        table += "ECMP_SUMMARY = @Summary, ECMP_VISIT_NO = 'VT01', ECMP_LAST_UPD_ID = @currentuserid, ECMP_LAST_UPD_DT= getdate()";
        table += "WHERE ECMP_STD_NUMBER = @studentid";
        SqlCommand cmd = new SqlCommand(table, con);



        cmd.Parameters.AddWithValue("@studentid", studentid);


        //Visual Acuity

        cmd.Parameters.AddWithValue("@CmbVcOdWithoutGlass", CmbVcOdWithoutGlass);
        cmd.Parameters.AddWithValue("@CmbVcOdWithoutNearvision", CmbVcOdWithoutNearvision);
        cmd.Parameters.AddWithValue("@VcOdWithoutDistance", VcOdWithoutDistance);
        cmd.Parameters.AddWithValue("@CmbVcOdWithGlass", CmbVcOdWithGlass);
        cmd.Parameters.AddWithValue("@CmbVcOdWithNearvision", CmbVcOdWithNearvision);
        cmd.Parameters.AddWithValue("@VcOdWithDistance", VcOdWithDistance);
        cmd.Parameters.AddWithValue("@CmbVcOdWithoutContact", CmbVcOdWithoutContact);
        cmd.Parameters.AddWithValue("@CmbVcOdContact", CmbVcOdContact);
        cmd.Parameters.AddWithValue("@VcOdContact", VcOdContact);
        cmd.Parameters.AddWithValue("@CmbVcOdPinhole", CmbVcOdPinhole);


        cmd.Parameters.AddWithValue("@CmbVcOsWithoutGlass", CmbVcOsWithoutGlass);
        cmd.Parameters.AddWithValue("@CmbVcOsWithoutNearvision", CmbVcOsWithoutNearvision);
        cmd.Parameters.AddWithValue("@VcOsWithoutDistance", VcOsWithoutDistance);
        cmd.Parameters.AddWithValue("@CmbVcOsWithGlass", CmbVcOsWithGlass);
        cmd.Parameters.AddWithValue("@CmbVcOsWithNearvision", CmbVcOsWithNearvision);
        cmd.Parameters.AddWithValue("@VcOsWithDistace", VcOsWithDistace);
        cmd.Parameters.AddWithValue("@CmbVcOsWithoutContact", CmbVcOsWithoutContact);
        cmd.Parameters.AddWithValue("@CmbVcOsContact", CmbVcOsContact);
        cmd.Parameters.AddWithValue("@VcOsContact", VcOsContact);
        cmd.Parameters.AddWithValue("@CmbVcOsPinhole", CmbVcOsPinhole);





        cmd.Parameters.AddWithValue("@CmbVcOuWithoutGlass", CmbVcOuWithoutGlass);
        cmd.Parameters.AddWithValue("@CmbVcOuWithoutNearvision", CmbVcOuWithoutNearvision);
        cmd.Parameters.AddWithValue("@VcOuWithoutDistance", VcOuWithoutDistance);
        cmd.Parameters.AddWithValue("@CmbVcOuWithGlass", CmbVcOuWithGlass);
        cmd.Parameters.AddWithValue("@CmbVcOuWithNearvision", CmbVcOuWithNearvision);
        cmd.Parameters.AddWithValue("@VcOuWithDistance", VcOuWithDistance);
        cmd.Parameters.AddWithValue("@CmbVcOuWithoutContact", CmbVcOuWithoutContact);
        cmd.Parameters.AddWithValue("@CmbVcOuContact", CmbVcOuContact);
        cmd.Parameters.AddWithValue("@VcOuContact", VcOuContact);
        cmd.Parameters.AddWithValue("@CmbVcOuPinhole", CmbVcOuPinhole);

        cmd.Parameters.AddWithValue("@Type_of_Chart", Type_of_Chart);
        cmd.Parameters.AddWithValue("@Near_Vision_Chart", Near_Vision_Chart);



        //Refraction

        cmd.Parameters.AddWithValue("@OdSpherical", odSpherical);
        cmd.Parameters.AddWithValue("@OdCylindrical", odCylindrical);
        cmd.Parameters.AddWithValue("@OdAxis", odAxis);
        cmd.Parameters.AddWithValue("@OdQuality", odQuality);
        cmd.Parameters.AddWithValue("@OdCycloplegic", odCycloplegic);
        cmd.Parameters.AddWithValue("@odWetOdSpherical", odWetOdSpherical);
        cmd.Parameters.AddWithValue("@WetOdCylindrical", WetOdCylindrical);
        cmd.Parameters.AddWithValue("@WetOdAxis", WetOdAxis);
        cmd.Parameters.AddWithValue("@OsSpherical", OsSpherical);
        cmd.Parameters.AddWithValue("@OsCylindrical", OsCylindrical);
        cmd.Parameters.AddWithValue("@OsAxis", OsAxis);
        cmd.Parameters.AddWithValue("@OsQuality", OsQuality);
        cmd.Parameters.AddWithValue("@OsCycloplegic", OsCycloplegic);
        cmd.Parameters.AddWithValue("@WetOsSpherical", WetOsSpherical);
        cmd.Parameters.AddWithValue("@WetOsCylindrical", WetOsCylindrical);
        cmd.Parameters.AddWithValue("@WetOsAxis", WetOsAxis);





        //-- Acceptance ----


        cmd.Parameters.AddWithValue("@AcOdDvSpherical", AcOdDvSpherical);
        cmd.Parameters.AddWithValue("@AcOdDvCylindrical", AcOdDvCylindrical);
        cmd.Parameters.AddWithValue("@AcOdDvAxis", AcOdDvAxis);
        cmd.Parameters.AddWithValue("@CmbAcOdDvBCVA", CmbAcOdDvBCVA);
        cmd.Parameters.AddWithValue("@AcOdAddSpherical", AcOdAddSpherical);
        cmd.Parameters.AddWithValue("@CmbAcOdAddBcva", CmbAcOdAddBcva);
        cmd.Parameters.AddWithValue("@AcOdAddDistance", AcOdAddDistance);
        cmd.Parameters.AddWithValue("@CmbAcOdPreference", CmbAcOdPreference);




        cmd.Parameters.AddWithValue("@AcOsDvSpherical", AcOsDvSpherical);
        cmd.Parameters.AddWithValue("@AcOsDvCylindrical", AcOsDvCylindrical);
        cmd.Parameters.AddWithValue("@AcOsDvAxis", AcOsDvAxis);
        cmd.Parameters.AddWithValue("@CmbAcOsDvBCVA", CmbAcOsDvBCVA);
        cmd.Parameters.AddWithValue("@AcOsAddSpherical", AcOsAddSpherical);
        cmd.Parameters.AddWithValue("@CmbAcOsAddBcva", CmbAcOsAddBcva);
        cmd.Parameters.AddWithValue("@AcOsAddDistance", AcOsAddDistance);
        cmd.Parameters.AddWithValue("@CmbAcOsPreference", CmbAcOsPreference);


        //-- Glass Prescription --

        cmd.Parameters.AddWithValue("@AcOdDvSpherical1", AcOdDvSpherical1);
        cmd.Parameters.AddWithValue("@AcOdDvCylindrical1", AcOdDvCylindrical1);
        cmd.Parameters.AddWithValue("@AcOdDvAxis1", AcOdDvAxis1);
        cmd.Parameters.AddWithValue("@CmbAcOdDvBCVA1", CmbAcOdDvBCVA1);
        cmd.Parameters.AddWithValue("@AcOdAddSpherical1", AcOdAddSpherical1);
        cmd.Parameters.AddWithValue("@CmbAcOdAddBcva1", CmbAcOdAddBcva1);
        cmd.Parameters.AddWithValue("@AcOdAddDistance1", AcOdAddDistance1);
        cmd.Parameters.AddWithValue("@CmbAcOdPreference1", CmbAcOdPreference1);




        cmd.Parameters.AddWithValue("@AcOsDvSpherical1", AcOsDvSpherical1);
        cmd.Parameters.AddWithValue("@AcOsDvCylindrical1", AcOsDvCylindrical1);
        cmd.Parameters.AddWithValue("@AcOsDvAxis1", AcOsDvAxis1);
        cmd.Parameters.AddWithValue("@CmbAcOsDvBCVA1", CmbAcOsDvBCVA1);
        cmd.Parameters.AddWithValue("@AcOsAddSpherical1", AcOsAddSpherical1);
        cmd.Parameters.AddWithValue("@CmbAcOsAddBcva1", CmbAcOsAddBcva1);
        cmd.Parameters.AddWithValue("@AcOsAddDistance1", AcOsAddDistance1);
        cmd.Parameters.AddWithValue("@CmbAcOsPreference1", CmbAcOsPreference1);



        //--Proposed Prism--

        cmd.Parameters.AddWithValue("@AcOdPrism1", AcOdPrism1);
        cmd.Parameters.AddWithValue("@CmdAcOdPrism1", CmdAcOdPrism1);
        cmd.Parameters.AddWithValue("@AcOsPrism1", AcOsPrism1);
        cmd.Parameters.AddWithValue("@CmdAcOsPrism1", CmdAcOsPrism1);
        cmd.Parameters.AddWithValue("@AcOdPrism2", AcOdPrism2);

        cmd.Parameters.AddWithValue("@CmbAcOdPrism2", CmbAcOdPrism2);
        cmd.Parameters.AddWithValue("@AcOsPrism2", AcOsPrism2);
        cmd.Parameters.AddWithValue("@CmbAcOsPrism2", CmbAcOsPrism2);




        //Refining Procedure

        cmd.Parameters.AddWithValue("@CmbAcOdRpRefining", CmbAcOdRpRefining);
        cmd.Parameters.AddWithValue("@RadAcOdRpJCC", RadAcOdRpJCC);
        cmd.Parameters.AddWithValue("@RadAcOdRpFogging", RadAcOdRpFogging);
        cmd.Parameters.AddWithValue("@CmbAcOsRpRefining", CmbAcOsRpRefining);
        cmd.Parameters.AddWithValue("@RadAcOsRpJCC", RadAcOsRpJCC);
        cmd.Parameters.AddWithValue("@RadAcOsRpFogging", RadAcOsRpFogging);


        //Intermediate Vision

        cmd.Parameters.AddWithValue("@AcOdIVision", AcOdIVision);
        cmd.Parameters.AddWithValue("@AcOdIVRDistace", AcOdIVRDistace);
        cmd.Parameters.AddWithValue("@AcOdPrismValue", AcOdPrismValue);
        cmd.Parameters.AddWithValue("@CmbAcOdPrismType", CmbAcOdPrismType);
        cmd.Parameters.AddWithValue("@AcOsIVision", AcOsIVision);
        cmd.Parameters.AddWithValue("@AcOsIVRDistace", AcOsIVRDistace);
        cmd.Parameters.AddWithValue("@AcOsPrismValue", AcOsPrismValue);
        cmd.Parameters.AddWithValue("@CmbAcOsPrismType", CmbAcOsPrismType);


        // Diagnosis Result
        cmd.Parameters.AddWithValue("@AcOdDiagnosis", AcOdDiagnosis);
        cmd.Parameters.AddWithValue("@AcOsDiagnosis", AcOsDiagnosis);


        // Summary

        cmd.Parameters.AddWithValue("@Summary", Summary);

        //currentuserid
        cmd.Parameters.AddWithValue("@currentuserid", currentuserid);


        cmd.ExecuteNonQuery();

        con.Close();


        //SaveDataToDatabase1();
        //GenerateHtmlSummary1();




    }



    

	private void odwithoutglassdv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOdWithoutGlass.DataSource = dt;
		cmbVcOdWithoutGlass.DataBind();
		cmbVcOdWithoutGlass.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOdWithoutGlass.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOdWithoutGlass.DataBind();
		cmbVcOdWithoutGlass.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void odwithoutglassnv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOdWithoutNearvision.DataSource = dt;
		cmbVcOdWithoutNearvision.DataBind();
		cmbVcOdWithoutNearvision.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOdWithoutNearvision.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOdWithoutNearvision.DataBind();
		cmbVcOdWithoutNearvision.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void odwithglassdv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOdWithGlass.DataSource = dt;
		cmbVcOdWithGlass.DataBind();
		cmbVcOdWithGlass.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOdWithGlass.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOdWithGlass.DataBind();
		cmbVcOdWithGlass.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void odwithglassnv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOdWithNearvision.DataSource = dt;
		cmbVcOdWithNearvision.DataBind();
		cmbVcOdWithNearvision.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOdWithNearvision.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOdWithNearvision.DataBind();
		cmbVcOdWithNearvision.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void OdWithoutContactdv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOdWithoutContact.DataSource = dt;
		cmbVcOdWithoutContact.DataBind();
		cmbVcOdWithoutContact.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOdWithoutContact.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOdWithoutContact.DataBind();
		cmbVcOdWithoutContact.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void OdWithoutContactnv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOdContact.DataSource = dt;
		cmbVcOdContact.DataBind();
		cmbVcOdContact.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOdContact.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOdContact.DataBind();
		cmbVcOdContact.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void Withphod()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOdPinhole.DataSource = dt;
		cmbVcOdPinhole.DataBind();
		cmbVcOdPinhole.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOdPinhole.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOdPinhole.DataBind();
		cmbVcOdPinhole.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void oswithoutglassdv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOsWithoutGlass.DataSource = dt;
		cmbVcOsWithoutGlass.DataBind();
		cmbVcOsWithoutGlass.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOsWithoutGlass.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOsWithoutGlass.DataBind();
		cmbVcOsWithoutGlass.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}



	private void oswithoutglassnv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOsWithoutNearvision.DataSource = dt;
		cmbVcOsWithoutNearvision.DataBind();
		cmbVcOsWithoutNearvision.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOsWithoutNearvision.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOsWithoutNearvision.DataBind();
		cmbVcOsWithoutNearvision.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void oswithglassdv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOsWithGlass.DataSource = dt;
		cmbVcOsWithGlass.DataBind();
		cmbVcOsWithGlass.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOsWithGlass.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOsWithGlass.DataBind();
		cmbVcOsWithGlass.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void oswithglassnv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOsWithNearvision.DataSource = dt;
		cmbVcOsWithNearvision.DataBind();
		cmbVcOsWithNearvision.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOsWithNearvision.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOsWithNearvision.DataBind();
		cmbVcOsWithNearvision.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void osWithoutContactdv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOsWithoutContact.DataSource = dt;
		cmbVcOsWithoutContact.DataBind();
		cmbVcOsWithoutContact.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOsWithoutContact.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOsWithoutContact.DataBind();
		cmbVcOsWithoutContact.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void osWithoutContactnv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOsContact.DataSource = dt;
		cmbVcOsContact.DataBind();
		cmbVcOsContact.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOsContact.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOsContact.DataBind();
		cmbVcOsContact.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void Withphos()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOsPinhole.DataSource = dt;
		cmbVcOsPinhole.DataBind();
		cmbVcOsPinhole.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOsPinhole.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOsPinhole.DataBind();
		cmbVcOsPinhole.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}






	private void ouwithoutglassdv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOuWithoutGlass.DataSource = dt;
		cmbVcOuWithoutGlass.DataBind();
		cmbVcOuWithoutGlass.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOuWithoutGlass.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOuWithoutGlass.DataBind();
		cmbVcOuWithoutGlass.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void ouwithoutglassnv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOuWithoutNearvision.DataSource = dt;
		cmbVcOuWithoutNearvision.DataBind();
		cmbVcOuWithoutNearvision.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOuWithoutNearvision.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOuWithoutNearvision.DataBind();
		cmbVcOuWithoutNearvision.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void ouwithglassdv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOuWithGlass.DataSource = dt;
		cmbVcOuWithGlass.DataBind();
		cmbVcOuWithGlass.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOuWithGlass.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOuWithGlass.DataBind();
		cmbVcOuWithGlass.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void ouwithglassnv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOuWithNearvision.DataSource = dt;
		cmbVcOuWithNearvision.DataBind();
		cmbVcOuWithNearvision.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOuWithNearvision.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOuWithNearvision.DataBind();
		cmbVcOuWithNearvision.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void OuWithoutContactdv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOuWithoutContact.DataSource = dt;
		cmbVcOuWithoutContact.DataBind();
		cmbVcOuWithoutContact.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOuWithoutContact.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOuWithoutContact.DataBind();
		cmbVcOuWithoutContact.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void OuWithoutContactnv()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOuContact.DataSource = dt;
		cmbVcOuContact.DataBind();
		cmbVcOuContact.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOuContact.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOuContact.DataBind();
		cmbVcOuContact.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void Withphou()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbVcOuPinhole.DataSource = dt;
		cmbVcOuPinhole.DataBind();
		cmbVcOuPinhole.DataTextField = "MPM_PARAMETER_VALUE";
		cmbVcOuPinhole.DataValueField = "MPM_PARAMETER_CD";
		cmbVcOuPinhole.DataBind();
		cmbVcOuPinhole.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void Quality_of_Reflex_OD()
	{
		string com = " SELECT MPM_PARAMETER_CD, MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE = 'REFQUA' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbRfOdQuality.DataSource = dt;
		cmbRfOdQuality.DataBind();
		cmbRfOdQuality.DataTextField = "MPM_PARAMETER_VALUE";
		cmbRfOdQuality.DataValueField = "MPM_PARAMETER_CD";
		cmbRfOdQuality.DataBind();
		cmbRfOdQuality.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}



    //private void Cycloplegic_Refraction_OD()
    //{
    //	string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='PWCR' ";
    //	SqlDataAdapter adpt = new SqlDataAdapter(com, con);
    //	DataTable dt = new DataTable();
    //	adpt.Fill(dt);
    //	cmbRfOdCycloplegic.DataSource = dt;
    //	cmbRfOdCycloplegic.DataBind();
    //	cmbRfOdCycloplegic.DataTextField = "MPM_PARAMETER_VALUE";
    //	cmbRfOdCycloplegic.DataValueField = "MPM_PARAMETER_CD";
    //	cmbRfOdCycloplegic.DataBind();
    //	cmbRfOdCycloplegic.Items.Insert(0, new ListItem("---- Select ---- ", ""));
    //}


	private void Quality_of_Reflex_OS()
	{
		string com = " SELECT MPM_PARAMETER_CD, MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE = 'REFQUA' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbRfOsQuality.DataSource = dt;
		cmbRfOsQuality.DataBind();
		cmbRfOsQuality.DataTextField = "MPM_PARAMETER_VALUE";
		cmbRfOsQuality.DataValueField = "MPM_PARAMETER_CD";
		cmbRfOsQuality.DataBind();
		cmbRfOsQuality.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}



    //private void Cycloplegic_Refraction_OS()
    //{
    //	string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE='PWCR' ";
    //	SqlDataAdapter adpt = new SqlDataAdapter(com, con);
    //	DataTable dt = new DataTable();
    //	adpt.Fill(dt);
    //	cmbRfOsCycloplegic.DataSource = dt;
    //	cmbRfOsCycloplegic.DataBind();
    //	cmbRfOsCycloplegic.DataTextField = "MPM_PARAMETER_VALUE";
    //	cmbRfOsCycloplegic.DataValueField = "MPM_PARAMETER_CD";
    //	cmbRfOsCycloplegic.DataBind();
    //	cmbRfOsCycloplegic.Items.Insert(0, new ListItem("---- Select ---- ", ""));
    //}


	private void Distance_Vision_BCVA_OD()
	{
		string com = " SELECT MPM_PARAMETER_CD, MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE = 'GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOdDvBCVA.DataSource = dt;
		cmbAcOdDvBCVA.DataBind();
		cmbAcOdDvBCVA.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOdDvBCVA.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOdDvBCVA.DataBind();
		cmbAcOdDvBCVA.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void ADD_BCVA_NV_OD()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOdAddBcva.DataSource = dt;
		cmbAcOdAddBcva.DataBind();
		cmbAcOdAddBcva.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOdAddBcva.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOdAddBcva.DataBind();
		cmbAcOdAddBcva.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}



    //private void Preference_OD()
    //{
    //	string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='ACCPRE' ";
    //	SqlDataAdapter adpt = new SqlDataAdapter(com, con);
    //	DataTable dt = new DataTable();
    //	adpt.Fill(dt);
    //	cmbAcOdPreference.DataSource = dt;
    //	cmbAcOdPreference.DataBind();
    //	cmbAcOdPreference.DataTextField = "MPM_PARAMETER_VALUE";
    //	cmbAcOdPreference.DataValueField = "MPM_PARAMETER_CD";
    //	cmbAcOdPreference.DataBind();
    //	cmbAcOdPreference.Items.Insert(0, new ListItem("---- Select ---- ", ""));
    //}


	private void Distance_Vision_BCVA_OS()
	{
		string com = " SELECT MPM_PARAMETER_CD, MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE MPM_PARAMETER_TYPE = 'GPDV1' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOsDvBCVA.DataSource = dt;
		cmbAcOsDvBCVA.DataBind();
		cmbAcOsDvBCVA.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOsDvBCVA.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOsDvBCVA.DataBind();
		cmbAcOsDvBCVA.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void ADD_BCVA_NV_OS()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPNV' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOsAddBcva.DataSource = dt;
		cmbAcOsAddBcva.DataBind();
		cmbAcOsAddBcva.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOsAddBcva.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOsAddBcva.DataBind();
		cmbAcOsAddBcva.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}



    //private void Preference_OS()
    //{
    //	string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='ACCPRE' ";
    //	SqlDataAdapter adpt = new SqlDataAdapter(com, con);
    //	DataTable dt = new DataTable();
    //	adpt.Fill(dt);
    //	cmbAcOsPreference.DataSource = dt;
    //	cmbAcOsPreference.DataBind();
    //	cmbAcOsPreference.DataTextField = "MPM_PARAMETER_VALUE";
    //	cmbAcOsPreference.DataValueField = "MPM_PARAMETER_CD";
    //	cmbAcOsPreference.DataBind();
    //	cmbAcOsPreference.Items.Insert(0, new ListItem("---- Select ---- ", ""));
    //}




	private void Proposed_Prism_OD()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPMP' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOdPrism1.DataSource = dt;
		cmbAcOdPrism1.DataBind();
		cmbAcOdPrism1.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOdPrism1.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOdPrism1.DataBind();
		cmbAcOdPrism1.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void Proposed1_Prism_OD()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPMP' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOdPrism2.DataSource = dt;
		cmbAcOdPrism2.DataBind();
		cmbAcOdPrism2.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOdPrism2.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOdPrism2.DataBind();
		cmbAcOdPrism2.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void Proposed_Prism_OS()
	{
		string com = " SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPMP' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOsPrism1.DataSource = dt;
		cmbAcOsPrism1.DataBind();
		cmbAcOsPrism1.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOsPrism1.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOsPrism1.DataBind();
		cmbAcOsPrism1.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void Proposed1_Prism_OS()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPMP' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOsPrism2.DataSource = dt;
		cmbAcOsPrism2.DataBind();
		cmbAcOsPrism2.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOsPrism2.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOsPrism2.DataBind();
		cmbAcOsPrism2.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}


	//SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPRP'

	//Refining Procedure
	private void Refining_Procedure_OD()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPRP' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOdRpRefining.DataSource = dt;
		cmbAcOdRpRefining.DataBind();
		cmbAcOdRpRefining.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOdRpRefining.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOdRpRefining.DataBind();
		cmbAcOdRpRefining.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}



	private void Refining_Procedure_OS()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPRP' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOsRpRefining.DataSource = dt;
		cmbAcOsRpRefining.DataBind();
		cmbAcOsRpRefining.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOsRpRefining.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOsRpRefining.DataBind();
		cmbAcOsRpRefining.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}




	private void Intermediate_Vision_OD()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPMP' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOdPrismType.DataSource = dt;
		cmbAcOdPrismType.DataBind();
		cmbAcOdPrismType.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOdPrismType.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOdPrismType.DataBind();
		cmbAcOdPrismType.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}


	private void Intermediate_Vision_OS()
	{
		string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPMP' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		cmbAcOsPrismType.DataSource = dt;
		cmbAcOsPrismType.DataBind();
		cmbAcOsPrismType.DataTextField = "MPM_PARAMETER_VALUE";
		cmbAcOsPrismType.DataValueField = "MPM_PARAMETER_CD";
		cmbAcOsPrismType.DataBind();
		cmbAcOsPrismType.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

    //DD_Type_of_chart
    private void Type_of_chart()
    {
        string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='TYPECH' ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        DD_Type_of_chart.DataSource = dt;
        DD_Type_of_chart.DataBind();
        DD_Type_of_chart.DataTextField = "MPM_PARAMETER_VALUE";
        DD_Type_of_chart.DataValueField = "MPM_PARAMETER_CD";
        DD_Type_of_chart.DataBind();
        DD_Type_of_chart.Items.Insert(0, new ListItem("---- Select ---- ", ""));


    }

    //DD_Near_vision_chart

    private void Near_Vision_chart()
    {
        string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='NEVSCH' ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        DD_Near_vision_chart.DataSource = dt;
        DD_Near_vision_chart.DataBind();
        DD_Near_vision_chart.DataTextField = "MPM_PARAMETER_VALUE";
        DD_Near_vision_chart.DataValueField = "MPM_PARAMETER_CD";
        DD_Near_vision_chart.DataBind();
        DD_Near_vision_chart.Items.Insert(0, new ListItem("---- Select ---- ", ""));


    }


    //DD_IV_Typr_of_chart


   




    //cmbAcOdDvBCVAOpt




    private void AcceptanceDistanceVision_OD()
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

    //cmbAcOdAddBcvaOpt

    
    private void AcceptanceADD_OD()
    {
        string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPNV' ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        cmbAcOdAddBcvaOpt.DataSource = dt;
        cmbAcOdAddBcvaOpt.DataBind();
        cmbAcOdAddBcvaOpt.DataTextField = "MPM_PARAMETER_VALUE";
        cmbAcOdAddBcvaOpt.DataValueField = "MPM_PARAMETER_CD";
        cmbAcOdAddBcvaOpt.DataBind();
        cmbAcOdAddBcvaOpt.Items.Insert(0, new ListItem("---- Select ---- ", ""));


    }


    //cmbAcOsDvBCVAOpt


    private void AcceptanceDistanceVision_OS()
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



    //cmbAcOsAddBcvaOpt

    private void AcceptanceADD_OS()
    {
        string com = "SELECT MPM_PARAMETER_CD,MPM_PARAMETER_VALUE FROM MR_PARAMETER_MASTER1  WHERE   MPM_PARAMETER_TYPE ='GPNV' ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        cmbAcOsAddBcvaOpt.DataSource = dt;
        cmbAcOsAddBcvaOpt.DataBind();
        cmbAcOsAddBcvaOpt.DataTextField = "MPM_PARAMETER_VALUE";
        cmbAcOsAddBcvaOpt.DataValueField = "MPM_PARAMETER_CD";
        cmbAcOsAddBcvaOpt.DataBind();
        cmbAcOsAddBcvaOpt.Items.Insert(0, new ListItem("---- Select ---- ", ""));


    }


}