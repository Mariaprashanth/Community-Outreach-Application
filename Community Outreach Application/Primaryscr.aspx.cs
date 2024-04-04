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
using System.Web.Services;

public partial class Primaryscr : System.Web.UI.Page
{
	SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
	//string connectionString = "Data Source=SNDB;Initial Catalog=snliveit;User Id=snappuser;Password=$@NkaR@app;";

	private string selectedSchoolValue;
	private string selectedClassValue;
	private string selectedSectionValue;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{

			Checkcookie();
			ALL_DROPDOWN();
			USERACCESS();



		}

	}





	private void ALL_DROPDOWN()
	{
		schnamedropdown();
		//classdropdown();
		//secdropdown();

		ABNORMALOD();
		ABNORMALOS();
		COVERTEST();
		MIMDROP();
		NPCDROP();
		ACCOMMODATIVE();
		SYSPTOMS_DROP();
		COLORVIS_DALTON();
		COLORVIS_ISHIHARA();


		
	}

	

	private void ABNORMALOD()
	{
		string com = " SELECT ECV_ABNORMAL_OD FROM ESO_CHECKUP_VAL_ABL_REMARKS   WHERE  ECV_ABNORMAL_OD_STATUS='A' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		ABNORMAL_DROPOD.DataSource = dt;
		ABNORMAL_DROPOD.DataBind();
		ABNORMAL_DROPOD.DataTextField = "ECV_ABNORMAL_OD";
		ABNORMAL_DROPOD.DataValueField = "ECV_ABNORMAL_OD";
		ABNORMAL_DROPOD.DataBind();
		ABNORMAL_DROPOD.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}


	private void ABNORMALOS()
	{
		string com = " SELECT ECV_ABNORMAL_OS FROM ESO_CHECKUP_VAL_ABL_REMARKS  WHERE  ECV_ABNORMAL_OS_STATUS='A' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		ABNORMAL_DROPOS.DataSource = dt;
		ABNORMAL_DROPOS.DataBind();
		ABNORMAL_DROPOS.DataTextField = "ECV_ABNORMAL_OS";
		ABNORMAL_DROPOS.DataValueField = "ECV_ABNORMAL_OS";
		ABNORMAL_DROPOS.DataBind();
		ABNORMAL_DROPOS.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void COVERTEST()
	{
		string com = " SELECT ECV_COVERTEST FROM ESO_CHECKUP_VAL_COVERTEST WHERE ECV_ECV_COVERTEST_STATUS='A' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		covertest.DataSource = dt;
		covertest.DataBind();
		covertest.DataTextField = "ECV_COVERTEST";
		covertest.DataValueField = "ECV_COVERTEST";
		covertest.DataBind();
		covertest.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void MIMDROP()
	{
		string com = "SELECT TOP 50 ECV_MIM FROM ESO_CHECKUP_VAL_MIM WHERE ECV_MIM_STATUS='A' AND TRY_CAST(ECV_MIM AS INT) IS NOT NULL ORDER BY TRY_CAST(ECV_MIM AS INT) ASC";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		// You can remove the unnecessary DataBind() calls
		STD_MIM_DROP_DOWN.DataSource = dt;
		STD_MIM_DROP_DOWN.DataTextField = "ECV_MIM";
		STD_MIM_DROP_DOWN.DataValueField = "ECV_MIM";
		STD_MIM_DROP_DOWN.DataBind();
		STD_MIM_DROP_DOWN.Items.Insert(0, new ListItem("---- Select ----", ""));
	}




	private void NPCDROP()
	{
		string com = " SELECT ECV_NPC FROM ESO_CHECKUP_VAL_NPC WHERE ECV_NPC_STATUS='A' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		NPC_DROP_DOWN.DataSource = dt;
		NPC_DROP_DOWN.DataBind();
		NPC_DROP_DOWN.DataTextField = "ECV_NPC";
		NPC_DROP_DOWN.DataValueField = "ECV_NPC";
		NPC_DROP_DOWN.DataBind();
		NPC_DROP_DOWN.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void ACCOMMODATIVE()
	{
		string com = " SELECT ECV_ACCOMMODATIVE_FACILITY FROM ESO_CHECKUP_VAL_ACCOM_FAC WHERE ECV_ACCOMMODATIVE_FACILITY_STATUS='A' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		STD_ACCOM_FA_DROP_DOWN.DataSource = dt;
		STD_ACCOM_FA_DROP_DOWN.DataBind();
		STD_ACCOM_FA_DROP_DOWN.DataTextField = "ECV_ACCOMMODATIVE_FACILITY";
		STD_ACCOM_FA_DROP_DOWN.DataValueField = "ECV_ACCOMMODATIVE_FACILITY";
		STD_ACCOM_FA_DROP_DOWN.DataBind();
		STD_ACCOM_FA_DROP_DOWN.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void SYSPTOMS_DROP()
	{
		string com = " SELECT ECV_SYMPTOMS FROM ESO_CHECKUP_VAL_SYMPTOMS WHERE ECV_SYMPTOMS_STATUS='A' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		STD_SYSP_DROP_DOWN.DataSource = dt;
		STD_SYSP_DROP_DOWN.DataBind();
		STD_SYSP_DROP_DOWN.DataTextField = "ECV_SYMPTOMS";
		STD_SYSP_DROP_DOWN.DataValueField = "ECV_SYMPTOMS";
		STD_SYSP_DROP_DOWN.DataBind();
		STD_SYSP_DROP_DOWN.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void COLORVIS_DALTON()
	{
		string com = "SELECT ECV_COLOR_VISION_DALTON FROM ESO_CHECKUP_VAL_COL_VI_DALTON WHERE ECV_COLOR_VISION_DALTON_STATUS='A' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		STD_CL_VSD_DROP_DOWN.DataSource = dt;
		STD_CL_VSD_DROP_DOWN.DataBind();
		STD_CL_VSD_DROP_DOWN.DataTextField = "ECV_COLOR_VISION_DALTON";
		STD_CL_VSD_DROP_DOWN.DataValueField = "ECV_COLOR_VISION_DALTON";
		STD_CL_VSD_DROP_DOWN.DataBind();
		STD_CL_VSD_DROP_DOWN.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}

	private void COLORVIS_ISHIHARA()
	{
		string com = "SELECT ECV_COLOR_VISION_ISHIHARA FROM ESO_CHECKUP_VAL_COL_VI_ISHI WHERE ECV_COLOR_VISION_ISHIHARA_STATUS='A' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		STD_CL_VSI_DROP_DOWN.DataSource = dt;
		STD_CL_VSI_DROP_DOWN.DataBind();
		STD_CL_VSI_DROP_DOWN.DataTextField = "ECV_COLOR_VISION_ISHIHARA";
		STD_CL_VSI_DROP_DOWN.DataValueField = "ECV_COLOR_VISION_ISHIHARA";
		STD_CL_VSI_DROP_DOWN.DataBind();
		STD_CL_VSI_DROP_DOWN.Items.Insert(0, new ListItem("---- Select ---- ", ""));
	}


	private void schnamedropdown()
	{
		string com = " select a.ECSD_SCHOOL_NO ,a.ECSD_SCHOOL_NAME from  ESO_CAMP_SCH_DTLS a inner join  MR_ESO_OUTREACH_MASTER_HEADER b on a.ECSD_SCHOOL_DOC_NO=b.EOMH_DOCUCODE  where b.EOMH_STATUS='A' ";
		SqlDataAdapter adpt = new SqlDataAdapter(com, con);
		DataTable dt = new DataTable();
		adpt.Fill(dt);
		SEL_SCHOOL.DataSource = dt;
		SEL_SCHOOL.DataBind();
		SEL_SCHOOL.DataTextField = "ECSD_SCHOOL_NAME";
		SEL_SCHOOL.DataValueField = "ECSD_SCHOOL_NO";
		SEL_SCHOOL.DataBind();
		SEL_SCHOOL.Items.Insert(0, new ListItem("Select School Name", ""));
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

            if (RLCOD != "MEOSTU" && RLCOD != "MEOPA" && RLCOD != "MEODEO")
            {
                Response.Redirect("Unauthorized.aspx");

            }



        }
        con.Close();
    }

    private void Checkcookie()
	{
		if (Request.Cookies["COMM_OUTREACH"] != null)
		{
			string Cookiecheck = Request.Cookies["COMM_OUTREACH"]["CookieAlive"];
			if (Cookiecheck == "False")
			{

				Response.Redirect("/COMMUNITY_OUTREACH/LOGINPG.aspx");
			}
			else if (Cookiecheck == "True")
			{
				DateTime CookieDateTime = DateTime.Now.AddDays(1);

				string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];
				string currentempid = Request.Cookies["COMM_OUTREACH"]["USEREMPNUM"];
				string currentesorocode = Request.Cookies["COMM_OUTREACH"]["USERROLECODE"];
				string currentcookiealive = Request.Cookies["COMM_OUTREACH"]["CookieAlive"];
				string currentusername = Request.Cookies["COMM_OUTREACH"]["USERNAME"];
				string currentexpire = Request.Cookies["COMM_OUTREACH"]["CookiesExpiryon"];
				Response.Cookies["COMM_OUTREACH"]["USERLOCATION"] = currentesorocode;
				Response.Cookies["COMM_OUTREACH"]["USERHMSID"] = currentuserid;
				Response.Cookies["COMM_OUTREACH"]["USEREMPNUM"] = currentempid;
				Response.Cookies["COMM_OUTREACH"]["CookieAlive"] = "True";
				Response.Cookies["COMM_OUTREACH"]["USERNAME"] = currentusername;
				Response.Cookies["COMM_OUTREACH"]["CookiesExpiryon"] = CookieDateTime.ToString("dd-MM-yyyy hh:mm:ss tt");
				Response.Cookies["COMM_OUTREACH"].Expires = CookieDateTime;

			}
			else
			{

				Response.Cookies["COMM_OUTREACH"]["CookieAlive"] = "False";
				Response.Cookies["COMM_OUTREACH"].Expires = DateTime.Now.AddDays(-1);
				Response.Redirect("/COMMUNITY_OUTREACH /LOGINPG.aspx");
			}
		}
		else
		{

			Response.Redirect("/COMMUNITY_OUTREACH/LOGINPG.aspx");
		}

	}


	protected void txtStudentNameSearch_TextChanged(object sender, EventArgs e)
	{
		string schoolValue = ViewState["SelectedSchoolValue"] as string;
		string classValue = ViewState["SelectedClassValue"] as string;
		string sectionValue = ViewState["SelectedSectionValue"] as string;

		string studentName = txtStudentNameSearch.Text.Trim();
		con.Open();
		string stser = "SELECT ECSD_SCHOOL_NO, ECSD_SCHOOL_NAME, ECSM_STUDENT_ID, ECSM_STUDENT_FIRST_NAME, ECSM_STUDENT_CLASS, ECSM_STUDENT_SECTION, ";
		stser += "ECSM_STUDENT_AGE, ECSM_STUDENT_GENDER, ECSM_STUDENT_STATUS_FLAG FROM ESO_CAMP_STD_MASTER ";
		stser += "LEFT OUTER JOIN ESO_CAMP_SCH_DTLS ON ECSD_SCHOOL_NO = ECSM_SCHOOL_NO ";
		stser += "WHERE ECSM_SCHOOL_NO = '" + schoolValue + "'";

		if (!string.IsNullOrEmpty(classValue))
		{
			stser += " AND ECSM_STUDENT_CLASS = '" + classValue + "'";
		}

		if (!string.IsNullOrEmpty(sectionValue))
		{
			stser += " AND ECSM_STUDENT_SECTION = '" + sectionValue + "'";
		}

		if (!string.IsNullOrEmpty(studentName))
		{
			stser += " AND ECSM_STUDENT_FIRST_NAME LIKE '%" + studentName + "%' OR ECSM_STUDENT_ID LIKE '%" + studentName + "%' ";
		}

		SqlCommand schcmd = new SqlCommand(stser, con);
		SqlDataAdapter schadapt = new SqlDataAdapter(schcmd);
		DataSet schdt = new DataSet();
		schadapt.Fill(schdt);

		student_data_grid.DataSource = schdt;
		student_data_grid.DataBind();

		


        //yescount.Visible = false;

        //nocount.Visible = false;

        //studentIdcount.Visible = false;

   

        int yesCount = 0;
        int noCount = 0;
        int studentIdCount = 0; // Initialize a variable to count ECSM_STUDENT_ID.

        if (schdt.Tables[0].Rows.Count >= 1)
        {
            foreach (DataRow row in schdt.Tables[0].Rows)
            {
                string statusFlag = row["ECSM_STUDENT_STATUS_FLAG"].ToString();
                string studentId = row["ECSM_STUDENT_ID"].ToString(); // Get the student ID from the row.

                if (statusFlag == "Y")
                {
                    yesCount++;
                }
                else if (statusFlag == "N")
                {
                    noCount++;
                }

                // Check if the student ID is not empty to count it.
                if (!string.IsNullOrEmpty(studentId))
                {
                    studentIdCount++;
                }
            }
        }

        yescount.Text = "Total Number Of entry's: " + yesCount;
        nocount.Text = "Total Number of Absent: " + noCount;
        studentIdcount.Text = "Total Number of Student's: " + studentIdCount; // Display the student ID count.

        con.Close();
    }


    protected void SEL_SCHOOL_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the selected school value
        string selectedSchoolNo = SEL_SCHOOL.SelectedValue;

        if (!string.IsNullOrEmpty(selectedSchoolNo))
        {
            // Load the sections based on the selected school
            LoadSections(selectedSchoolNo);

            // Load the classes based on the selected school
            LoadClasses(selectedSchoolNo);
        }
        else
        {
            // Clear the Section and Class dropdowns if no school is selected
            SEL_SECTION.Items.Clear();
            SEL_CLASS.Items.Clear();
        }
    }

    private void LoadSections(string schoolNo)
    {
        // Construct and execute the query to load sections based on school
        string sectionQuery = "SELECT DISTINCT ECSM_STUDENT_SECTION FROM ESO_CAMP_STD_MASTER WHERE ECSM_SCHOOL_NO = @SchoolNo";
        using (SqlConnection connection = new SqlConnection(con.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(sectionQuery, connection))
            {
                command.Parameters.AddWithValue("@SchoolNo", schoolNo);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    SEL_SECTION.Items.Clear(); // Clear existing items
                    SEL_SECTION.Items.Insert(0, new ListItem("Select Class", ""));
                    while (reader.Read())
                    {
                        string section = reader["ECSM_STUDENT_SECTION"].ToString();
                        SEL_SECTION.Items.Add(new ListItem(section, section));
                    }
                }
            }
        }
    }

    private void LoadClasses(string schoolNo)
    {
        // Construct and execute the query to load classes based on school
        string classQuery = "SELECT DISTINCT ECSM_STUDENT_CLASS FROM ESO_CAMP_STD_MASTER WHERE ECSM_SCHOOL_NO = @SchoolNo";
        using (SqlConnection connection = new SqlConnection(con.ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(classQuery, connection))
            {
                command.Parameters.AddWithValue("@SchoolNo", schoolNo);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    SEL_CLASS.Items.Clear(); // Clear existing items
                    SEL_CLASS.Items.Insert(0, new ListItem("Select Class", ""));
                    while (reader.Read())
                    {
                        string studentClass = reader["ECSM_STUDENT_CLASS"].ToString();
                        SEL_CLASS.Items.Add(new ListItem(studentClass, studentClass));
                    }
                }
            }
        }
    }


    protected void STU_SEARCH_Click(object sender, EventArgs e)
	{
		string studentName = txtStudentNameSearch.Text.Trim();
		con.Open();
		string stser = "SELECT ECSD_SCHOOL_NO, ECSD_SCHOOL_NAME, ECSM_STUDENT_ID, ECSM_STUDENT_FIRST_NAME, ECSM_STUDENT_CLASS, ECSM_STUDENT_SECTION, ";
		stser += "ECSM_STUDENT_AGE, ECSM_STUDENT_GENDER, ECSM_STUDENT_STATUS_FLAG FROM ESO_CAMP_STD_MASTER ";
		stser += "LEFT OUTER JOIN ESO_CAMP_SCH_DTLS ON ECSD_SCHOOL_NO = ECSM_SCHOOL_NO ";
		stser += "WHERE ECSM_SCHOOL_NO = '" + SEL_SCHOOL.SelectedValue + "'";

		if (!string.IsNullOrEmpty(SEL_CLASS.SelectedValue))
		{
			stser += " AND ECSM_STUDENT_CLASS = '" + SEL_CLASS.SelectedValue + "'";
		}

		if (!string.IsNullOrEmpty(SEL_SECTION.SelectedValue))
		{
			stser += " AND ECSM_STUDENT_SECTION = '" + SEL_SECTION.SelectedValue + "'";
		}

		if (!string.IsNullOrEmpty(studentName))
		{
			stser += " AND ECSM_STUDENT_FIRST_NAME LIKE '%" + studentName + "%' OR ECSM_STUDENT_ID LIKE '%" + studentName + "%' ";
		}

		SqlCommand schcmd = new SqlCommand(stser, con);
		SqlDataAdapter schadapt = new SqlDataAdapter(schcmd);
		DataSet schdt = new DataSet();
		schadapt.Fill(schdt);

		student_data_grid.DataSource = schdt;
		student_data_grid.DataBind();

		if (schdt.Tables[0].Rows.Count >= 1)
		{
			SCHOOL_NO.Value = schdt.Tables[0].Rows[0]["ECSD_SCHOOL_NO"].ToString().TrimEnd().TrimStart();
			STU_ID_HID.Value = schdt.Tables[0].Rows[0]["ECSM_STUDENT_ID"].ToString().TrimEnd().TrimStart();
		}

		ViewState["SelectedSchoolValue"] = SEL_SCHOOL.SelectedValue;
		ViewState["SelectedClassValue"] = SEL_CLASS.SelectedValue;
		ViewState["SelectedSectionValue"] = SEL_SECTION.SelectedValue;

		con.Close();

		string PATSTATUSCOUNT = "SELECT ECSM_STUDENT_STATUS_FLAG, ECSM_STUDENT_ID FROM ESO_CAMP_STD_MASTER WHERE ECSM_SCHOOL_NO='" + SCHOOL_NO.Value + "'";
		SqlCommand STCOUNT = new SqlCommand(PATSTATUSCOUNT, con);
		SqlDataAdapter CTADT = new SqlDataAdapter(STCOUNT);
		DataSet CTSET = new DataSet();
		CTADT.Fill(CTSET);

		int yesCount = 0;
		int noCount = 0;
		int studentIdCount = 0; // Initialize a variable to count ECSM_STUDENT_ID.

		if (CTSET.Tables[0].Rows.Count >= 1)
		{
			foreach (DataRow row in CTSET.Tables[0].Rows)
			{
				string statusFlag = row["ECSM_STUDENT_STATUS_FLAG"].ToString();
				string studentId = row["ECSM_STUDENT_ID"].ToString(); // Get the student ID from the row.

				if (statusFlag == "Y")
				{
					yesCount++;
				}
				else if (statusFlag == "N")
				{
					noCount++;
				}

				// Check if the student ID is not empty to count it.
				if (!string.IsNullOrEmpty(studentId))
				{
					studentIdCount++;
				}
			}
		}

		yescount.Text = "Total Number Of entry's: " + yesCount;
		nocount.Text = "Total Number of Absent: " + noCount;
		studentIdcount.Text = "Total Number of Student's: " + studentIdCount; // Display the student ID count.

		con.Close();

		txtStudentNameSearch.Visible = true;
	}






	protected void student_data_grid_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			// Assuming the status flag is in the second column (index 1)
			string status = e.Row.Cells[8].Text;
			if (status == "Y")
			{
				e.Row.BackColor = System.Drawing.Color.FromArgb(16, 176, 75); // Change the row color to green
																			  // You can modify other properties of the row, such as font color, etc., as needed
			}
			else if (status == "N")
			{
				e.Row.BackColor = System.Drawing.Color.FromArgb(215, 52, 41);
			}

			else
			{
				e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
			}
		}
	}



	protected void student_data_grid_RowCommand(object sender, GridViewCommandEventArgs e)
	{



		if (e.CommandName == "SELECT")
		{
			int rowIndex = Convert.ToInt32(e.CommandArgument);
			sch_name_lbl.Text = student_data_grid.Rows[rowIndex].Cells[1].Text;
			stu_id.Text = student_data_grid.Rows[rowIndex].Cells[2].Text;
			STU_NAME.Text = student_data_grid.Rows[rowIndex].Cells[3].Text;
			STU_CLASS.Text = student_data_grid.Rows[rowIndex].Cells[4].Text;
			stu_sec.Text = student_data_grid.Rows[rowIndex].Cells[5].Text;
            STU_GEN.Text= student_data_grid.Rows[rowIndex].Cells[7].Text;

            stucheckupdtlsload();
		}

		if (e.CommandName == "ABSENT")
		{
			int rowIndex = Convert.ToInt32(e.CommandArgument);
			preandsbcstuis.Value = student_data_grid.Rows[rowIndex].Cells[2].Text;
		}

	}






	protected void Mkentrybtn_Click(object sender, ImageClickEventArgs e)
	{

		string studenthidval = STU_ID_HID.Value;

		string script = @"<script type='text/javascript'>
                        $(document).ready(function () {                            
                            $('#modalTitle1').text('PRIMARY SCREENING');  
                            $('#myModal1').modal('show');
                          
                        }); 

                    </script>";

		ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);

		stucheckupdtlsload();

	}

	private void stucheckupdtlsload()
	{
		string checkupdata = "SELECT ECSCD_STUDENT_NRL_CASE,ECSCD_USING_SPEC,ECSCD_WITHOUT_SPEC_OD,ECSCD_WITHOUT_SPEC_OS, ";
		checkupdata += " ECSCD_DS_TEST_OD,ECSCD_DS_TEST_OS,ECSCD_OCULAR_COMP,ECSCD_TL_EXAM_OD,ECSCD_TL_EXAM_OS,ECSCD_ABNORMAL_REMARKS_OD,ECSCD_ABNORMAL_REMARKS_OS, ";
		checkupdata += " ECSCD_COVER_TEST,ECSCD_MIM,ECSCD_NPC,ECSCD_ACCOM_FACILITY,ECSCD_SYMPTOM,ECSCD_COL_VIS_DALTON,ECSCD_COL_VIS_ISHIHARA,ECSCD_DETAILS_EXAM_FLAG  ";
		checkupdata += "  FROM  ESO_CAMP_STD_CHECKUP_DTLS  WHERE   ECSCD_SCHOOL_NO='" + SCHOOL_NO.Value + "' AND ECSCD_STUDENT_ID='" + stu_id.Text + "' ";
		con.Open();
		SqlCommand cmd = new SqlCommand(checkupdata, con);
		SqlDataAdapter da = new SqlDataAdapter(cmd);
		DataSet ds = new DataSet();
		da.Fill(ds);
		con.Close();

		if (ds.Tables[0].Rows.Count >= 1)
		{





			HIDE_VAL.Value = ds.Tables[0].Rows[0]["ECSCD_STUDENT_NRL_CASE"].ToString().TrimEnd().TrimStart();

			if (HIDE_VAL.Value == "Normal Case")
			{
				Nrl_cs.Checked = true;
			}
			else
			{
				if (HIDE_VAL.Value == "")
				{
					Nrl_cs.Checked = false;
				}

			}



			spcradio.Text = ds.Tables[0].Rows[0]["ECSCD_USING_SPEC"].ToString().TrimEnd().TrimStart();


			WITHOUT_ODRE.Text = ds.Tables[0].Rows[0]["ECSCD_WITHOUT_SPEC_OD"].ToString().TrimEnd().TrimStart();
			WITHOUT_OSLE.Text = ds.Tables[0].Rows[0]["ECSCD_WITHOUT_SPEC_OD"].ToString().TrimEnd().TrimStart();

			//WITH_ODRE.Text = ds.Tables[0].Rows[0]["ECSCD_WITH_SPEC_OD"].ToString().TrimEnd().TrimStart();
			//WITH_OSLE.Text = ds.Tables[0].Rows[0]["ECSCD_WITH_SPEC_OS"].ToString().TrimEnd().TrimStart();

			VALTST_ODRE.Text = ds.Tables[0].Rows[0]["ECSCD_DS_TEST_OD"].ToString().TrimEnd().TrimStart();
			VALTST_OSLE.Text = ds.Tables[0].Rows[0]["ECSCD_DS_TEST_OS"].ToString().TrimEnd().TrimStart();

			TLEEXAM_ODRE.Text = ds.Tables[0].Rows[0]["ECSCD_TL_EXAM_OD"].ToString().TrimEnd().TrimStart();
			TLEEXAM_OSLE.Text = ds.Tables[0].Rows[0]["ECSCD_TL_EXAM_OS"].ToString().TrimEnd().TrimStart();


			occomplain.Text = ds.Tables[0].Rows[0]["ECSCD_OCULAR_COMP"].ToString().TrimEnd().TrimStart();


			ABNORMAL_DROPOD.Text = ds.Tables[0].Rows[0]["ECSCD_ABNORMAL_REMARKS_OD"].ToString().TrimEnd().TrimStart();
			ABNORMAL_DROPOS.Text = ds.Tables[0].Rows[0]["ECSCD_ABNORMAL_REMARKS_OS"].ToString().TrimEnd().TrimStart();

			covertest.Text = ds.Tables[0].Rows[0]["ECSCD_COVER_TEST"].ToString().TrimEnd().TrimStart();

			STD_MIM_DROP_DOWN.Text = ds.Tables[0].Rows[0]["ECSCD_MIM"].ToString().TrimEnd().TrimStart();
			NPC_DROP_DOWN.Text = ds.Tables[0].Rows[0]["ECSCD_NPC"].ToString().TrimEnd().TrimStart();


			STD_ACCOM_FA_DROP_DOWN.Text = ds.Tables[0].Rows[0]["ECSCD_ACCOM_FACILITY"].ToString().TrimEnd().TrimStart();
			STD_SYSP_DROP_DOWN.Text = ds.Tables[0].Rows[0]["ECSCD_SYMPTOM"].ToString().TrimEnd().TrimStart();

			STD_CL_VSD_DROP_DOWN.Text = ds.Tables[0].Rows[0]["ECSCD_COL_VIS_DALTON"].ToString().TrimEnd().TrimStart();
			STD_CL_VSI_DROP_DOWN.Text = ds.Tables[0].Rows[0]["ECSCD_COL_VIS_ISHIHARA"].ToString().TrimEnd().TrimStart();

			Detailexam.Text = ds.Tables[0].Rows[0]["ECSCD_DETAILS_EXAM_FLAG"].ToString().TrimEnd().TrimStart();

			STU_CHECKUP_DTLS.Visible = false;

            SV_BTN.Visible = false;


            stu_checkup_update.Visible = true;
		}

		else
		{
			CHECKUPDATACLEAR();
			STU_CHECKUP_DTLS.Visible = true;
			SV_BTN.Visible = true;
			stu_checkup_update.Visible = false;
		}
	}


	private void studentcheckupdtld()
	{
		if (spcradio.SelectedValue != "")
		{
			if (WITHOUT_ODRE.SelectedValue != "")
			{
				if (WITHOUT_OSLE.SelectedValue != "")
				{

					if (VALTST_ODRE.SelectedValue != "")
					{
						if (VALTST_OSLE.SelectedValue != "")
						{
							if (occomplain.SelectedValue != "")
							{
								if (TLEEXAM_ODRE.SelectedValue != "")
								{
									if (TLEEXAM_OSLE.SelectedValue != "")
									{

										if (covertest.SelectedValue != "")
										{

											if (STD_MIM_DROP_DOWN.SelectedValue != "")
											{
												if (NPC_DROP_DOWN.SelectedValue != "")
												{

													if (STD_SYSP_DROP_DOWN.SelectedValue != "")
													{
														if (STD_CL_VSD_DROP_DOWN.SelectedValue != "")
														{
															if (STD_CL_VSI_DROP_DOWN.SelectedValue != "")
															{
																if (Detailexam.SelectedValue != "")
																{

																	String NORMALCASE = "";

																	if (Nrl_cs.Checked)
																	{
																		NORMALCASE = Nrl_cs.Text.ToString();
																	}
																	else
																	{
																		NORMALCASE = "";
																	}


																	string ABNORMALOD = "";
																	if (ABNORMAL_DROPOD.SelectedValue == "")
																	{
																		ABNORMALOD = "Inactive";
																	}
																	else
																	{
																		ABNORMALOD = ABNORMAL_DROPOD.SelectedValue;
																	}

																	string ABNORMALOS = "";
																	if (ABNORMAL_DROPOS.SelectedValue == "")
																	{
																		ABNORMALOS = "Inactive";
																	}
																	else
																	{
																		ABNORMALOS = ABNORMAL_DROPOS.SelectedValue;
																	}




																	string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

																	SqlCommand chekupinsert = new SqlCommand("ESO_STU_CHECKUP_INSERT", con);
																	chekupinsert.CommandType = CommandType.StoredProcedure;

																	chekupinsert.Parameters.AddWithValue("@ESCI_STU_NRL_CASE", NORMALCASE);

																	chekupinsert.Parameters.AddWithValue("@ESCI_SCHOOL_NO", SCHOOL_NO.Value);

																	chekupinsert.Parameters.AddWithValue("@ESCI_STU_ID", stu_id.Text);

																	chekupinsert.Parameters.AddWithValue("@ESCI_USING_SPEC", spcradio.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_WITHOUT_SPEC_OD", WITHOUT_ODRE.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_WITHOUT_SPEC_OS", WITHOUT_OSLE.SelectedValue);



																	chekupinsert.Parameters.AddWithValue("@ESCI_DS_TEST_OD", VALTST_ODRE.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_DS_TEST_OS", VALTST_OSLE.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_OCULAR_COMPLAIN", occomplain.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_TL_EXAM_OD", TLEEXAM_ODRE.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_TL_EXAM_OS", TLEEXAM_OSLE.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_ABNORMAL_RMK_OD", ABNORMALOD);

																	chekupinsert.Parameters.AddWithValue("@ESCI_ABNORMAL_RMK_OS", ABNORMALOS);

																	chekupinsert.Parameters.AddWithValue("@ESCI_COVER_TEST", covertest.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_MIM", STD_MIM_DROP_DOWN.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_NPC", NPC_DROP_DOWN.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_ACCOM_FACILITY", STD_ACCOM_FA_DROP_DOWN.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_SYMTOM", STD_SYSP_DROP_DOWN.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_CALVISITION_DALTON", STD_CL_VSD_DROP_DOWN.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_CALVISITION_ISHIHARA", STD_CL_VSI_DROP_DOWN.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_DETAILS_EXAM", Detailexam.SelectedValue);

																	chekupinsert.Parameters.AddWithValue("@ESCI_CRT_USR_ID", currentuserid);



																	if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
																	chekupinsert.ExecuteNonQuery();
																	if (con.State == ConnectionState.Open) { con.Close(); } else { }

																	Response.Write("<script>alert(' Saved Successfully')</script>");

																	try
																	{



																		con.Open();
																		string query = "  UPDATE ESO_CAMP_STD_MASTER SET ECSM_STUDENT_STATUS_FLAG='Y'  WHERE ECSM_SCHOOL_NO=@schnoactcmd  AND ECSM_STUDENT_ID=@stuidactcmd ";
																		SqlCommand cmd = new SqlCommand(query, con);
																		cmd.Parameters.AddWithValue("@schnoactcmd", SCHOOL_NO.Value);
																		cmd.Parameters.AddWithValue("@stuidactcmd", stu_id.Text);

																		int rowsAffected = cmd.ExecuteNonQuery();

																		con.Close();

																		DATACLEAR();
																	}
																	catch (Exception ex)
																	{
																		Response.Write($"<script>alert('Student  Status Flag  Not updated ')</script>");
																	}

																	string postBackScript = Page.ClientScript.GetPostBackEventReference(STU_SEARCH, string.Empty);
																	string script = "<script>setTimeout(function() { " + postBackScript + "; }, 100);</script>";
																	Page.ClientScript.RegisterStartupScript(this.GetType(), "TriggerSearchButtonClick", script);

																}

																else
																{
																	string script = @"<script type='text/javascript'>
													             $(document).ready(function () {                            
													                 $('#modalTitle1').text('PRIMARY SCREENING');  
													                 $('#myModal1').modal('show');
													                 alert('Please select Detailed examination required.'); // You can customize the error message here
													             }); 
													         </script>";

																	ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);
																}


															}
															else
															{
																string script = @"<script type='text/javascript'>
													             $(document).ready(function () {                            
													                 $('#modalTitle1').text('PRIMARY SCREENING');  
													                 $('#myModal1').modal('show');
													                 alert('Please select Color vision Ishihara.'); // You can customize the error message here
													             }); 
													         </script>";

																ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);
															}
														}
														else
														{
															string script = @"<script type='text/javascript'>
													             $(document).ready(function () {                            
													                 $('#modalTitle1').text('PRIMARY SCREENING');  
													                 $('#myModal1').modal('show');
													                 alert('Please select Color vision Dalton'); // You can customize the error message here
													             }); 
													         </script>";

															ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);
														}
													}
													else
													{
														string script = @"<script type='text/javascript'>
													             $(document).ready(function () {                            
													                 $('#modalTitle1').text('PRIMARY SCREENING');  
													                 $('#myModal1').modal('show');
													                 alert('Please select Sysptoms.'); // You can customize the error message here
													             }); 
													         </script>";

														ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);
													}



												}
												else
												{
													string script = @"<script type='text/javascript'>
													             $(document).ready(function () {                            
													                 $('#modalTitle1').text('PRIMARY SCREENING');  
													                 $('#myModal1').modal('show');
													                 alert('Please select NPC.'); // You can customize the error message here
													             }); 
													         </script>";

													ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);
												}
											}
											else
											{
												string script = @"<script type='text/javascript'>
													             $(document).ready(function () {                            
													                 $('#modalTitle1').text('PRIMARY SCREENING');  
													                 $('#myModal1').modal('show');
													                 alert('Please select MIM.'); // You can customize the error message here
													             }); 
													         </script>";

												ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);
											}

										}
										else
										{
											string script = @"<script type='text/javascript'>
                            $(document).ready(function () {                            
                                $('#modalTitle1').text('PRIMARY SCREENING');  
                                $('#myModal1').modal('show');
                                alert('Please select Cover Teat.'); // You can customize the error message here
                            }); 
                        </script>";

											ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);
										}



									}
									else
									{
										string script = @"<script type='text/javascript'>
													             $(document).ready(function () {                            
													                 $('#modalTitle1').text('PRIMARY SCREENING');  
													                 $('#myModal1').modal('show');
													                 alert('Please select Torch light Examination OS'); // You can customize the error message here
													             }); 
													         </script>";

										ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);
									}

								}

								else
								{
									string script = @"<script type='text/javascript'>
													             $(document).ready(function () {                            
													                 $('#modalTitle1').text('PRIMARY SCREENING');  
													                 $('#myModal1').modal('show');
													                 alert('Please select Torch light Examination OD'); // You can customize the error message here
													             }); 
													         </script>";

									ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);
								}

							}
							else
							{
								string script = @"<script type='text/javascript'>
                            $(document).ready(function () {                            
                                $('#modalTitle1').text('PRIMARY SCREENING');  
                                $('#myModal1').modal('show');
                                alert('Please select Ocular Complaint.'); // You can customize the error message here
                            }); 
                        </script>";

								ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);
							}

						}
						else
						{
							string script = @"<script type='text/javascript'>
                            $(document).ready(function () {                            
                                $('#modalTitle1').text('PRIMARY SCREENING');  
                                $('#myModal1').modal('show');
                                alert('Please select +1.50 TEST OS.'); // You can customize the error message here
                            }); 
                        </script>";

							ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);
						}

					}
					else
					{
						string script = @"<script type='text/javascript'>
                            $(document).ready(function () {                            
                                $('#modalTitle1').text('PRIMARY SCREENING');  
                                $('#myModal1').modal('show');
                                alert('Please select +1.50 TEST OD.'); // You can customize the error message here
                            }); 
                        </script>";

						ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);
					}




				}
				else
				{
					string script = @"<script type='text/javascript'>
                            $(document).ready(function () {                            
                                $('#modalTitle1').text('PRIMARY SCREENING');  
                                $('#myModal1').modal('show');
                                alert('Please select Does the child read 0.20 logMAR? OS.'); // You can customize the error message here
                            }); 
                        </script>";

					ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);

				}

			}
			else
			{
				string script = @"<script type='text/javascript'>
                            $(document).ready(function () {                            
                                $('#modalTitle1').text('PRIMARY SCREENING');  
                                $('#myModal1').modal('show');
                                alert('Please select Does the child read 0.20 logMAR? OD.'); // You can customize the error message here
                            }); 
                        </script>";

				ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);

			}
		}
		else
		{
			string script = @"<script type='text/javascript'>
                            $(document).ready(function () {                            
                                $('#modalTitle1').text('PRIMARY SCREENING');  
                                $('#myModal1').modal('show');
                                alert('Please select Without Using Spectacles .'); // You can customize the error message here
                            }); 
                        </script>";

			ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);

		}

	}

	protected void SV_BTN_Click(object sender, EventArgs e)
	{
		studentcheckupdtld();
	}

	protected void STU_CHECKUP_DTLS_Click(object sender, EventArgs e)
	{

		studentcheckupdtld();


	}

	protected void stu_checkup_update_Click(object sender, EventArgs e)
	{

		String NORMALCASE = "";

		if (Nrl_cs.Checked)
		{
			NORMALCASE = Nrl_cs.Text.ToString();
		}
		else
		{
			NORMALCASE = "";
		}




		string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

		SqlCommand updtcmd = new SqlCommand("ESO_STU_CHECKUP_UPDATE", con);
		updtcmd.CommandType = CommandType.StoredProcedure;

		updtcmd.Parameters.AddWithValue("@ESCI_STU_NRL_CASE", NORMALCASE);

		updtcmd.Parameters.AddWithValue("@ESCI_SCHOOL_NO", SCHOOL_NO.Value);

		updtcmd.Parameters.AddWithValue("@ESCI_STU_ID", stu_id.Text);

		updtcmd.Parameters.AddWithValue("@ESCI_USING_SPEC", spcradio.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_WITHOUT_SPEC_OD", WITHOUT_ODRE.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_WITHOUT_SPEC_OS", WITHOUT_OSLE.SelectedValue);

		//updtcmd.Parameters.AddWithValue("@ESCI_WITH_SPEC_OD", WITH_ODRE.SelectedValue);

		//updtcmd.Parameters.AddWithValue("@ESCI_WITH_SPEC_OS", WITH_OSLE.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_DS_TEST_OD", VALTST_ODRE.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_DS_TEST_OS", VALTST_OSLE.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_OCULAR_COMPLAIN", occomplain.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_TL_EXAM_OD", TLEEXAM_ODRE.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_TL_EXAM_OS", TLEEXAM_OSLE.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_ABNORMAL_RMK_OD", ABNORMAL_DROPOD.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_ABNORMAL_RMK_OS", ABNORMAL_DROPOS.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_COVER_TEST", covertest.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_MIM", STD_MIM_DROP_DOWN.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_NPC", NPC_DROP_DOWN.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_ACCOM_FACILITY", STD_ACCOM_FA_DROP_DOWN.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_SYMTOM", STD_SYSP_DROP_DOWN.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_CALVISITION_DALTON", STD_CL_VSD_DROP_DOWN.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_CALVISITION_ISHIHARA", STD_CL_VSI_DROP_DOWN.SelectedValue);

		updtcmd.Parameters.AddWithValue("@ESCI_DETAILS_EXAM", Detailexam.SelectedValue);



		updtcmd.Parameters.AddWithValue("@ESCI_UPT_USRIS", currentuserid);

		if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
		updtcmd.ExecuteNonQuery();
		if (con.State == ConnectionState.Open) { con.Close(); } else { }



		Response.Write("<script>alert(' Student Checkup Details updated Successfully')</script>");


		string postBackScript = Page.ClientScript.GetPostBackEventReference(STU_SEARCH, string.Empty);
		string script = "<script>setTimeout(function() { " + postBackScript + "; }, 100);</script>";
		Page.ClientScript.RegisterStartupScript(this.GetType(), "TriggerSearchButtonClick", script);

	}


	private void CHECKUPDATACLEAR()
	{
		Nrl_cs.Checked = false;

		spcradio.ClearSelection();

		WITHOUT_ODRE.ClearSelection();

		WITHOUT_OSLE.ClearSelection();

		//WITH_ODRE.ClearSelection();

		//WITH_OSLE.ClearSelection();

		VALTST_ODRE.ClearSelection();

		VALTST_OSLE.ClearSelection();

		occomplain.ClearSelection();

		TLEEXAM_ODRE.ClearSelection();

		TLEEXAM_OSLE.ClearSelection();

		ABNORMAL_DROPOD.ClearSelection();

		ABNORMAL_DROPOS.ClearSelection();

		covertest.ClearSelection();

		STD_MIM_DROP_DOWN.ClearSelection();

		NPC_DROP_DOWN.ClearSelection();

		STD_ACCOM_FA_DROP_DOWN.ClearSelection();

		STD_SYSP_DROP_DOWN.ClearSelection();

		STD_CL_VSD_DROP_DOWN.ClearSelection();

		STD_CL_VSI_DROP_DOWN.ClearSelection();

		Detailexam.ClearSelection();
	}

	private void DATACLEAR()
	{

		SCHOOL_NO.Value = string.Empty;

		stu_id.Text = string.Empty;

		STU_NAME.Text = string.Empty;

		STU_CLASS.Text = string.Empty;

		Nrl_cs.Checked = false;




		spcradio.ClearSelection();

		WITHOUT_ODRE.ClearSelection();

		WITHOUT_OSLE.ClearSelection();

		//WITH_ODRE.ClearSelection();

		//WITH_OSLE.ClearSelection();

		VALTST_ODRE.ClearSelection();

		VALTST_OSLE.ClearSelection();

		occomplain.ClearSelection();

		TLEEXAM_ODRE.ClearSelection();

		TLEEXAM_OSLE.ClearSelection();

		ABNORMAL_DROPOD.ClearSelection();

		ABNORMAL_DROPOS.ClearSelection();

		covertest.ClearSelection();

		STD_MIM_DROP_DOWN.ClearSelection();

		NPC_DROP_DOWN.ClearSelection();

		STD_ACCOM_FA_DROP_DOWN.ClearSelection();

		STD_SYSP_DROP_DOWN.ClearSelection();

		STD_CL_VSD_DROP_DOWN.ClearSelection();

		STD_CL_VSI_DROP_DOWN.ClearSelection();

		Detailexam.ClearSelection();

	}




	protected void absentButton_Click(object sender, ImageClickEventArgs e)
	{

		string script = @"<script type='text/javascript'>
                        $(document).ready(function () {                            
                            $('#modalTitle1').text('PRIMARY SCREENING');  
                            $('#myModal2').modal('show');
							 
                        });
                    </script>";

		ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", script, false);

	}

	protected void deletebtn_Click(object sender, ImageClickEventArgs e)
	{
		ImageButton deleteButton = (ImageButton)sender;
		GridViewRow gridViewRow = (GridViewRow)deleteButton.NamingContainer;
		//  string schoolNo = gridViewRow.Cells[0].Text; // Assuming school number is in the first cell
		string studentID = gridViewRow.Cells[2].Text;

		string SCHOOLNUMBER = SCHOOL_NO.Value;

		SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
		con.Open();
		SqlCommand deleteCommand = new SqlCommand(" DELETE FROM ESO_CAMP_STD_CHECKUP_DTLS WHERE ECSCD_SCHOOL_NO=@SCHOOLNUM AND ECSCD_STUDENT_ID = @StudentID", con);

		// deleteCommand.Parameters.AddWithValue("@SchoolNo", schoolNo);
		deleteCommand.Parameters.AddWithValue("@StudentID", studentID);
		deleteCommand.Parameters.AddWithValue("@SCHOOLNUM", SCHOOLNUMBER);
		int rowsAffected = deleteCommand.ExecuteNonQuery();
		con.Close();

		Response.Write($"<script>alert('Student Checkup data delete successfully')</script>");


		con.Open();
		string querydel = "  UPDATE ESO_CAMP_STD_MASTER SET ECSM_STUDENT_STATUS_FLAG=NULL  WHERE ECSM_SCHOOL_NO=@schnoactcmddel  AND ECSM_STUDENT_ID=@stuidactcmddel ";
		SqlCommand cmddel = new SqlCommand(querydel, con);
		cmddel.Parameters.AddWithValue("@schnoactcmddel", SCHOOLNUMBER);
		cmddel.Parameters.AddWithValue("@stuidactcmddel", studentID);

		int rowsAffectedel = cmddel.ExecuteNonQuery();

		con.Close();



		string postBackScript = Page.ClientScript.GetPostBackEventReference(STU_SEARCH, string.Empty);
		string script = "<script>setTimeout(function() { " + postBackScript + "; }, 100);</script>";
		Page.ClientScript.RegisterStartupScript(this.GetType(), "TriggerSearchButtonClick", script);
	}

	protected void confirmBtn_Click(object sender, EventArgs e)
	{

		try
		{

			string schnoupt = SCHOOL_NO.Value;
			//string stuidupt = preandsbcstuis.Value;

			con.Open();
			string query = "  UPDATE ESO_CAMP_STD_MASTER SET ECSM_STUDENT_ATTENDANCE_STATUS='A',ECSM_STUDENT_STATUS_FLAG=NULL  WHERE ECSM_SCHOOL_NO=@schnoactcmd  AND ECSM_STUDENT_ID=@stuidactcmd ";
			SqlCommand cmd = new SqlCommand(query, con);
			cmd.Parameters.AddWithValue("@schnoactcmd", schnoupt);
			cmd.Parameters.AddWithValue("@stuidactcmd", preandsbcstuis.Value);

			int rowsAffected = cmd.ExecuteNonQuery();

			con.Close();

			string postBackScript = Page.ClientScript.GetPostBackEventReference(STU_SEARCH, string.Empty);
			string script = "<script>setTimeout(function() { " + postBackScript + "; }, 100);</script>";
			Page.ClientScript.RegisterStartupScript(this.GetType(), "TriggerSearchButtonClick", script);
		}
		catch (Exception ex)
		{
			Response.Write($"<script>alert('Student  Attendance Details Not Saved')</script>");
		}

	}

	protected void cancelBtn_Click(object sender, EventArgs e)
	{
		try
		{


			string schnouptinact = SCHOOL_NO.Value;
			//string stuiduptinact = preandsbcstuis.Value;

			con.Open();
			string query = "  UPDATE ESO_CAMP_STD_MASTER SET ECSM_STUDENT_ATTENDANCE_STATUS='I',ECSM_STUDENT_STATUS_FLAG='N'  WHERE ECSM_SCHOOL_NO=@schnoinactcmd  AND ECSM_STUDENT_ID=@stuidinactcmd ";
			SqlCommand cmd = new SqlCommand(query, con);
			cmd.Parameters.AddWithValue("@schnoinactcmd", schnouptinact);
			cmd.Parameters.AddWithValue("@stuidinactcmd", preandsbcstuis.Value);

			int rowsAffected = cmd.ExecuteNonQuery();

			con.Close();

			string postBackScript = Page.ClientScript.GetPostBackEventReference(STU_SEARCH, string.Empty);
			string script = "<script>setTimeout(function() { " + postBackScript + "; }, 100);</script>";
			Page.ClientScript.RegisterStartupScript(this.GetType(), "TriggerSearchButtonClick", script);
		}
		catch (Exception ex)
		{
			Response.Write($"<script>alert('Student  Attendance Details Not Saved')</script>");
		}

	}

	protected void closeBtn_Click(object sender, EventArgs e)
	{
		// Hide the modal dialog using JavaScript
		ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal2Hide", "$('#myModal2').modal('hide');", true);
	}




	protected void modelclose_Click(object sender, EventArgs e)
	{
		ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal2Hide", "$('#myModal1').modal('hide');", true);
	}


}