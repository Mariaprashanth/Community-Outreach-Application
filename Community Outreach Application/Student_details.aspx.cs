using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_details : System.Web.UI.Page
{

    static DataTable dt = new DataTable();

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());

    private string selectedSchoolValue;
    private string selectedClassValue;
    private string selectedSectionValue;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Checkcookie();
            schnamedropdown();
            classdropdown();
            secdropdown();
           schnamedropdown1();
            schnamedropdown_edit();
            classdropdown_edit();
            secdropdown_edit();

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

            if (RLCOD != "MEOPA" && RLCOD != "MEODEO")
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
        SEL_SCHOOL.DataSource = dt;
        SEL_SCHOOL.DataBind();
        SEL_SCHOOL.DataTextField = "ECSD_SCHOOL_NAME";
        SEL_SCHOOL.DataValueField = "ECSD_SCHOOL_NO";
        SEL_SCHOOL.DataBind();
        SEL_SCHOOL.Items.Insert(0, new ListItem("Select School Name", ""));
    }

    private void schnamedropdown1()
    {
        string com = " select a.ECSD_SCHOOL_NO ,a.ECSD_SCHOOL_NAME from  ESO_CAMP_SCH_DTLS a inner join  MR_ESO_OUTREACH_MASTER_HEADER b on a.ECSD_SCHOOL_DOC_NO=b.EOMH_DOCUCODE  where b.EOMH_STATUS='A' ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        SCH_DROPDOWN.DataSource = dt;
        SCH_DROPDOWN.DataBind();
        SCH_DROPDOWN.DataTextField = "ECSD_SCHOOL_NAME";
        SCH_DROPDOWN.DataValueField = "ECSD_SCHOOL_NO";
        SCH_DROPDOWN.DataBind();
        SCH_DROPDOWN.Items.Insert(0, new ListItem("Select School Name", ""));
    }

    private void classdropdown()
    {
        string com = "SELECT DISTINCT ECSM_STUDENT_CLASS FROM ESO_CAMP_STD_MASTER";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        SEL_CLASS.DataSource = dt;
        SEL_CLASS.DataBind();
        SEL_CLASS.DataTextField = "ECSM_STUDENT_CLASS";
        SEL_CLASS.DataValueField = "ECSM_STUDENT_CLASS";
        SEL_CLASS.DataBind();
        SEL_CLASS.Items.Insert(0, new ListItem("Select Class", ""));
    }

    private void secdropdown()
    {
        string com = " SELECT DISTINCT ECSM_STUDENT_SECTION FROM ESO_CAMP_STD_MASTER ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        SEL_SECTION.DataSource = dt;
        SEL_SECTION.DataBind();
        SEL_SECTION.DataTextField = "ECSM_STUDENT_SECTION";
        SEL_SECTION.DataValueField = "ECSM_STUDENT_SECTION";
        SEL_SECTION.DataBind();
        SEL_SECTION.Items.Insert(0, new ListItem("Select Section", ""));
    }




    private void schnamedropdown_edit()
    {
        string com = " select a.ECSD_SCHOOL_NO ,a.ECSD_SCHOOL_NAME from  ESO_CAMP_SCH_DTLS a inner join  MR_ESO_OUTREACH_MASTER_HEADER b on a.ECSD_SCHOOL_DOC_NO=b.EOMH_DOCUCODE  where b.EOMH_STATUS='A' ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        sch_name_edit.DataSource = dt;
        sch_name_edit.DataBind();
        sch_name_edit.DataTextField = "ECSD_SCHOOL_NAME";
        sch_name_edit.DataValueField = "ECSD_SCHOOL_NO";
        sch_name_edit.DataBind();
        sch_name_edit.Items.Insert(0, new ListItem("Select School Name", ""));
    }

    private void classdropdown_edit()
    {
        string com = "SELECT DISTINCT ECSM_STUDENT_CLASS FROM ESO_CAMP_STD_MASTER";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        std_cls_edit.DataSource = dt;
        std_cls_edit.DataBind();
        std_cls_edit.DataTextField = "ECSM_STUDENT_CLASS";
        std_cls_edit.DataValueField = "ECSM_STUDENT_CLASS";
        std_cls_edit.DataBind();
        std_cls_edit.Items.Insert(0, new ListItem("Select Class", ""));
    }

    private void secdropdown_edit()
    {
        string com = " SELECT DISTINCT ECSM_STUDENT_SECTION FROM ESO_CAMP_STD_MASTER ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        std_sec_edit.DataSource = dt;
        std_sec_edit.DataBind();
        std_sec_edit.DataTextField = "ECSM_STUDENT_SECTION";
        std_sec_edit.DataValueField = "ECSM_STUDENT_SECTION";
        std_sec_edit.DataBind();
        std_sec_edit.Items.Insert(0, new ListItem("Select Section", ""));
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


    protected void std_detail_add(object sender, EventArgs e)
    {


        SCH_DOC_ID.Visible = true;
        SCH_DROPDOWN.Visible = true;

        STD_FIRST_NAME_LB.Visible = true;
        STD_FIRST_NAME.Visible = true;

       
        STD_CLASS_LB.Visible = true;
        STD_CLASS.Visible = true;

        STD_SECTION_LB.Visible = true;
        STD_SECTION.Visible = true;

        STD_GENDER_LB.Visible = true;
        STD_GENDER_MALE.Visible = true;

        STD_GENDER_FEMALE.Visible = true;
      

        STD_AGE_LB.Visible = true;
        STD_AGE.Visible = true;

        STD_PH_NUM_LB.Visible = true;
        STD_PH_NUM.Visible = true;

        STD_DETAIL_SAVE.Visible = true;

        //stdImage.Visible = true;

        SEL_SCHOOL.Visible = false;
        SEL_CLASS.Visible = false;
        SEL_SECTION.Visible = false;
        STU_SEARCH.Visible = false;

        student_data_grid.Visible = false;


        //STD_DELETE_IMGS.Visible = false;
        schnamedropdown1();

        sch_name_edit.Visible = false;
        std_cls_edit.Visible = false;
        std_sec_edit.Visible = false;
        std_search_edit.Visible = false;


        //std_edit_imgs.Visible = false;
        GridView_Edit.Visible = false;

        txtStudentNameSearch.Visible = false;

        Student_search.Visible = false;
    }
    //std_detail_save_click

        
    protected void std_detail_save_click(object sender, EventArgs e)
    {
        try
        {
          


            string selectedSchoolNo = SCH_DROPDOWN.SelectedValue;
            string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];
           // HashSet<string> processedData = new HashSet<string>();


            string studnetID = "";
            string studentAttendancestatus = "";
            string studentFirstName = STD_FIRST_NAME.Text;
           
            string studentClass = STD_CLASS.Text;
            string studentSection = STD_SECTION.Text;
          
            string studentAgeStr = STD_AGE.Text;
            int studentAge;
            string studentPHnumber = STD_PH_NUM.Text;


            string studentGender = " ";

            if(STD_GENDER_MALE.Checked)
            {
                studentGender = "Male";
            }
            else if (STD_GENDER_FEMALE.Checked)
            {
                studentGender = "Female";
            }
            else
            {
                Response.Write("<script>alert('Please select a student gender. Data not saved.')</script>");
                return;
            }





            if (IsDataExists(selectedSchoolNo, studentFirstName, studentClass, studentSection, studentGender))
            {
                Response.Write("<script>alert('This Student Data Already Saved')</script>");
                return;
            }

            if (!int.TryParse(studentAgeStr, out studentAge))
            {
                Response.Write("<script>alert('Invalid student age format. Data not saved.')</script>");
                return;
            }

            if (string.IsNullOrEmpty(studentFirstName))
            {
                Response.Write("<script>alert(' student First Name is Empty. Data not saved.')</script>");
                return;
            }

           

            if (string.IsNullOrEmpty(studentClass))
            {
                Response.Write("<script>alert(' student Class is Empty. Data not saved.')</script>");
                return;
            }

            if (string.IsNullOrEmpty(studentSection))
            {
                Response.Write("<script>alert(' student Section is Empty. Data not saved.')</script>");
                return;
            }

            if (string.IsNullOrEmpty(studentGender))
            {
                Response.Write("<script>alert(' student Gender is Empty. Data not saved.')</script>");
                return;
            }


            SqlCommand updtcmd = new SqlCommand("ESO_STUDENT_UNIQUE_INSERT", con);
            updtcmd.CommandType = CommandType.StoredProcedure;
            updtcmd.Parameters.AddWithValue("@ECSM_SCHOOL_NO", selectedSchoolNo);
            updtcmd.Parameters.AddWithValue("@ECSM_STUDENT_ID", studnetID);
            updtcmd.Parameters.AddWithValue("@STU_FIRST_NAME", studentFirstName);
            
            updtcmd.Parameters.AddWithValue("@STU_CLASS", studentClass);
            updtcmd.Parameters.AddWithValue("@STU_SEC", studentSection);
            updtcmd.Parameters.AddWithValue("@STU_AGE", studentAge);
            updtcmd.Parameters.AddWithValue("@STU_GENDER", studentGender);
            
            updtcmd.Parameters.AddWithValue("@STU_CON_NO", studentPHnumber);

            updtcmd.Parameters.AddWithValue("@STU_CON_ATTEN", studentAttendancestatus);
    

            updtcmd.Parameters.AddWithValue("@CR_USER_ID", currentuserid);
           
            if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
            updtcmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open) { con.Close(); } else { }

            




            Response.Write("<script>alert('Saved Successfully')</script>");

            STD_FIRST_NAME.Text = null;

           
            STD_CLASS.Text = null;

            STD_SECTION.Text = null;

          

            STD_AGE.Text = null;

            STD_PH_NUM.Text= null;


            STD_GENDER_MALE.Checked = false;

            STD_GENDER_FEMALE.Checked = false;


            schnamedropdown1();
        }
        catch(Exception)
        {
            Response.Write("<script>alert('Student Data is Not Saved')</script>");
        }

        
    }




    

    public bool IsDataExists(string schoolNo, string firstName, string studentClass, string studentSection ,string studentGender)
    {

        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT COUNT(*) FROM ESO_CAMP_STD_MASTER WHERE ECSM_SCHOOL_NO = @SCL_NO AND ECSM_STUDENT_FIRST_NAME = @STU_FIRST_NAME ";
             query+= " AND ECSM_STUDENT_CLASS = @STU_CLASS AND ECSM_STUDENT_SECTION = @STU_SEC AND ECSM_STUDENT_GENDER=@STU_GENDER";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@SCL_NO", schoolNo));
            param.Add(new SqlParameter("@STU_FIRST_NAME", firstName));
           
            param.Add(new SqlParameter("@STU_CLASS", studentClass));
            param.Add(new SqlParameter("@STU_SEC", studentSection));
            param.Add(new SqlParameter("@STU_GENDER", studentGender));
           


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(param.ToArray());

            int count = 0;

            connection.Open();
            count = Convert.ToInt32(command.ExecuteScalar());

            return count > 0;
        }
    }






    protected void std_detail_delete(object sender, EventArgs e)
    {
        SCH_DOC_ID.Visible = false;
        SCH_DROPDOWN.Visible = false;

        STD_FIRST_NAME_LB.Visible = false;
        STD_FIRST_NAME.Visible = false;

       
        STD_CLASS_LB.Visible = false;
        STD_CLASS.Visible = false;

        STD_SECTION_LB.Visible = false;
        STD_SECTION.Visible = false;

        STD_GENDER_LB.Visible = false;
        STD_GENDER_MALE.Visible = false;

        STD_GENDER_FEMALE.Visible = false;
 


        STD_AGE_LB.Visible = false;
        STD_AGE.Visible = false;

        STD_PH_NUM_LB.Visible = false;
        STD_PH_NUM.Visible = false;

        STD_DETAIL_SAVE.Visible = false;

        //stdImage.Visible = false;

        SEL_SCHOOL.Visible = true;
        SEL_CLASS.Visible = true;
        SEL_SECTION.Visible = true;
        STU_SEARCH.Visible = true;

        student_data_grid.Visible = true;

        //STD_DELETE_IMGS.Visible = true;


        sch_name_edit.Visible = false;
        std_cls_edit.Visible = false;
        std_sec_edit.Visible = false;
        std_search_edit.Visible = false;

        //std_edit_imgs.Visible = false;

        GridView_Edit.Visible = false;

         txtStudentNameSearch.Visible = true;

        Student_search.Visible = false;

        secdropdown();

    }

    private void stu_search_delete_click()
    {
      
        string studentName = txtStudentNameSearch.Text.Trim();
        con.Open();

        string stser = "SELECT ECSM_SCHOOL_NO, ECSD_SCHOOL_NAME, ECSM_STUDENT_ID, ECSM_STUDENT_FIRST_NAME, ECSM_STUDENT_CLASS, ECSM_STUDENT_SECTION, ";
        stser += "ECSM_STUDENT_AGE, ECSM_STUDENT_GENDER, ECSM_STUDENT_PH_NUMBER FROM ESO_CAMP_STD_MASTER ";
        stser += "LEFT OUTER JOIN ESO_CAMP_SCH_DTLS ON ECSD_SCHOOL_NO = ECSM_SCHOOL_NO ";
        stser += "WHERE ECSD_SCHOOL_NO = '" + SEL_SCHOOL.SelectedValue + "'";

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
         
            HiddenField1.Value = schdt.Tables[0].Rows[0]["ECSM_SCHOOL_NO"].ToString().TrimEnd().TrimStart();
            HiddenField2.Value = schdt.Tables[0].Rows[0]["ECSM_STUDENT_ID"].ToString().TrimEnd().TrimStart();

        }
        ViewState["SelectedSchoolValue"] = SEL_SCHOOL.SelectedValue;
        ViewState["SelectedClassValue"] = SEL_CLASS.SelectedValue;
        ViewState["SelectedSectionValue"] = SEL_SECTION.SelectedValue;

        con.Close();

        string PATSTATUSCOUNT = "SELECT ECSM_STUDENT_STATUS_FLAG, ECSM_STUDENT_ID FROM ESO_CAMP_STD_MASTER WHERE ECSM_SCHOOL_NO='" + HiddenField1.Value + "'";
        SqlCommand STCOUNT = new SqlCommand(PATSTATUSCOUNT, con);
        SqlDataAdapter CTADT = new SqlDataAdapter(STCOUNT);
        DataSet CTSET = new DataSet();
        CTADT.Fill(CTSET);

        
        con.Close();

       
    }
    protected void STU_SEARCH_Click(object sender, EventArgs e)
    {
        txtStudentNameSearch.Visible = true;
        stu_search_delete_click();
        
    }
    protected void txtStudentNameSearch_TextChanged(object sender, EventArgs e)
    {
        string schoolValue = ViewState["SelectedSchoolValue"] as string;
        string classValue = ViewState["SelectedClassValue"] as string;
        string sectionValue = ViewState["SelectedSectionValue"] as string;

        string studentName = txtStudentNameSearch.Text.Trim();
        con.Open();
        
        string stser = "SELECT ECSM_SCHOOL_NO, ECSD_SCHOOL_NAME, ECSM_STUDENT_ID, ECSM_STUDENT_FIRST_NAME, ECSM_STUDENT_CLASS, ECSM_STUDENT_SECTION, ";
        stser += "ECSM_STUDENT_AGE, ECSM_STUDENT_GENDER, ECSM_STUDENT_PH_NUMBER FROM ESO_CAMP_STD_MASTER ";
        stser += "LEFT OUTER JOIN ESO_CAMP_SCH_DTLS ON ECSD_SCHOOL_NO = ECSM_SCHOOL_NO ";
        stser += "WHERE ECSD_SCHOOL_NO = '" + schoolValue + "'";

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

        con.Close();
    }
    //---------------------------------------- Delete Student Details ----------------------------------------

    protected void deletebtn_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton deleteButton = (ImageButton)sender;
        GridViewRow gridViewRow = (GridViewRow)deleteButton.NamingContainer;
        
        string schoolNo = student_data_grid.DataKeys[gridViewRow.RowIndex]["ECSM_SCHOOL_NO"].ToString();
        
        string studentID = gridViewRow.Cells[2].Text;
        
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
        con.Open();
        SqlCommand deleteCommand = new SqlCommand("DELETE FROM ESO_CAMP_STD_MASTER WHERE ECSM_SCHOOL_NO=@SchoolNo AND ECSM_STUDENT_ID = @StudentID", con);
         deleteCommand.Parameters.AddWithValue("@SchoolNo", schoolNo);
        deleteCommand.Parameters.AddWithValue("@StudentID", studentID);
       
        int rowsAffected = deleteCommand.ExecuteNonQuery();
        con.Close();

        
        Response.Write($"<script>alert('Student  data delete successfully')</script>");
        
        stu_search_delete_click();
        
    }

    //----------------------------------------------------- EDIT STUDENT DETAILS ----------------------------------------------------


    protected void std_detail_edit(object sender, EventArgs e)
    {

        SCH_DOC_ID.Visible = false;
        SCH_DROPDOWN.Visible = false;

        STD_FIRST_NAME_LB.Visible = false;
        STD_FIRST_NAME.Visible = false;

        STD_CLASS_LB.Visible = false;
        STD_CLASS.Visible = false;

        STD_SECTION_LB.Visible = false;
        STD_SECTION.Visible = false;

        STD_GENDER_LB.Visible = false;
        STD_GENDER_MALE.Visible = false;

        STD_GENDER_FEMALE.Visible = false;
        


        STD_AGE_LB.Visible = false;
        STD_AGE.Visible = false;

        STD_PH_NUM_LB.Visible = false;
        STD_PH_NUM.Visible = false;

        STD_DETAIL_SAVE.Visible = false;

        //stdImage.Visible = false;

        SEL_SCHOOL.Visible = false;
        SEL_CLASS.Visible = false;
        SEL_SECTION.Visible = false;
        STU_SEARCH.Visible = false;

        student_data_grid.Visible = false;

        //STD_DELETE_IMGS.Visible = false;



        sch_name_edit.Visible = true;
        std_cls_edit.Visible = true;
        std_sec_edit.Visible = true;
        std_search_edit.Visible = true;

        //std_edit_imgs.Visible = true;

        GridView_Edit.Visible = true;

        txtStudentNameSearch.Visible = false;

        Student_search.Visible = true;

    }

    private void searchfun()
    {
        con.Open();
        
        string stser = "SELECT ECSM_SCHOOL_NO, ECSD_SCHOOL_NAME, ECSM_STUDENT_ID, ECSM_STUDENT_FIRST_NAME , ECSM_STUDENT_CLASS, ECSM_STUDENT_SECTION, ";
        stser += "ECSM_STUDENT_AGE, ECSM_STUDENT_GENDER, ECSM_STUDENT_PH_NUMBER FROM ESO_CAMP_STD_MASTER ";
        stser += "LEFT OUTER JOIN ESO_CAMP_SCH_DTLS ON ECSD_SCHOOL_NO = ECSM_SCHOOL_NO ";
        stser += "WHERE ECSD_SCHOOL_NO = '" + sch_name_edit.SelectedValue + "'";

        
        if (!string.IsNullOrEmpty(std_cls_edit.SelectedValue))
        {
            stser += " AND ECSM_STUDENT_CLASS = '" + std_cls_edit.SelectedValue + "'";
        }

        if (!string.IsNullOrEmpty(std_sec_edit.SelectedValue))
        {
            stser += " AND ECSM_STUDENT_SECTION = '" + std_sec_edit.SelectedValue + "'";
        }
        
        SqlCommand schcmd = new SqlCommand(stser, con);
        SqlDataAdapter schadapt = new SqlDataAdapter(schcmd);
        DataSet schdt = new DataSet();
        schadapt.Fill(schdt);
        GridView_Edit.DataSource = schdt;
        GridView_Edit.DataBind();
        if (schdt.Tables[0].Rows.Count >= 1)
        {
            if (schdt.Tables[0].Rows.Count >= 1)
            {

                HiddenField3.Value = schdt.Tables[0].Rows[0]["ECSM_SCHOOL_NO"].ToString().TrimEnd().TrimStart();
                HiddenField4.Value = schdt.Tables[0].Rows[0]["ECSM_STUDENT_ID"].ToString().TrimEnd().TrimStart();

            }
            ViewState["SelectedSchoolValue"] = sch_name_edit.SelectedValue;
            ViewState["SelectedClassValue"] = std_cls_edit.SelectedValue;
            ViewState["SelectedSectionValue"] = std_sec_edit.SelectedValue;

            con.Close();

            string PATSTATUSCOUNT = "SELECT ECSM_STUDENT_STATUS_FLAG, ECSM_STUDENT_ID FROM ESO_CAMP_STD_MASTER WHERE ECSM_SCHOOL_NO='" + HiddenField3.Value + "'";
            SqlCommand STCOUNT = new SqlCommand(PATSTATUSCOUNT, con);
            SqlDataAdapter CTADT = new SqlDataAdapter(STCOUNT);
            DataSet CTSET = new DataSet();
            CTADT.Fill(CTSET);

           
        }

            con.Close();
    }


    protected void txtTextChanged(object sender, EventArgs e)
    {
        string schoolValue = ViewState["SelectedSchoolValue"] as string;
        string classValue = ViewState["SelectedClassValue"] as string;
        string sectionValue = ViewState["SelectedSectionValue"] as string;

        string studentName = Student_search.Text.Trim();
        con.Open();

        string stser = "SELECT ECSM_SCHOOL_NO, ECSD_SCHOOL_NAME, ECSM_STUDENT_ID, ECSM_STUDENT_FIRST_NAME, ECSM_STUDENT_CLASS, ECSM_STUDENT_SECTION, ";
        stser += "ECSM_STUDENT_AGE, ECSM_STUDENT_GENDER, ECSM_STUDENT_PH_NUMBER FROM ESO_CAMP_STD_MASTER ";
        stser += "LEFT OUTER JOIN ESO_CAMP_SCH_DTLS ON ECSD_SCHOOL_NO = ECSM_SCHOOL_NO ";
        stser += "WHERE ECSD_SCHOOL_NO = '" + schoolValue + "'";

        

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

        GridView_Edit.DataSource = schdt;
        GridView_Edit.DataBind();

        con.Close();
    }




    protected void STU_SEARCH_EDIT_Click(object sender, EventArgs e)
    {
        Student_search.Visible = true;
        searchfun();
    }

   


    protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView_Edit.Rows[e.RowIndex];
        string sclno = GridView_Edit.DataKeys[e.RowIndex].Values["ECSM_SCHOOL_NO"].ToString();
        string StdId = GridView_Edit.DataKeys[e.RowIndex].Values["ECSM_STUDENT_ID"].ToString();

        string StdFirstName= (row.FindControl("txt_first_name") as TextBox).Text;
       
        string StdClass = (row.FindControl("txt_Class") as TextBox).Text;
        string StdSection = (row.FindControl("txt_section") as TextBox).Text;
 
        int StdAge;
        string StdGender = (row.FindControl("txt_gender") as TextBox).Text;
        string StdPh= (row.FindControl("txt_Phno") as TextBox).Text;


        if (int.TryParse((row.FindControl("txt_age") as TextBox).Text, out StdAge))
        {
            int nextAge = StdAge + 1;
        }
        else
        {
            StdAge = 0;
        }

            string currentuserid = HttpContext.Current.Request.Cookies["COMM_OUTREACH"]["USERHMSID"];
       
        string query = "UPDATE ESO_CAMP_STD_MASTER SET ECSM_STUDENT_FIRST_NAME = @stdfirstname,ECSM_STUDENT_CLASS = @stdclass, ECSM_STUDENT_SECTION = @stdsection, ECSM_STUDENT_AGE = @stdage,";
        query += "ECSM_STUDENT_GENDER = @stdgender, ECSM_STUDENT_PH_NUMBER = @stdph, ECSM_STUDENT_ATTENDANCE_STATUS = 'A',ECSM_UPDATED_USER_ID = @UpdateUserId ,ECSM_UPDATED_TIME = GETDATE()";
        query += "WHERE ECSM_STUDENT_ID =@stdid AND ECSM_SCHOOL_NO=@sclno ";

        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;
  
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@stdid", StdId);
                command.Parameters.AddWithValue("@stdfirstname", StdFirstName);
              
                command.Parameters.AddWithValue("@stdclass", StdClass);
                command.Parameters.AddWithValue("@stdsection", StdSection);

                command.Parameters.AddWithValue("@stdage", StdAge);
                command.Parameters.AddWithValue("@stdgender", StdGender);
                command.Parameters.AddWithValue("@stdph", StdPh);

                command.Parameters.AddWithValue("@sclno", sclno);

                command.Parameters.AddWithValue("@UpdateUserId", currentuserid);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        GridView_Edit.EditIndex = -1;

        searchfun();


    }


    

    protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView_Edit.EditIndex = -1;
        searchfun();
        // BindGridView(sclno, StdClass, StdSection);
    }
   
    protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView_Edit.EditIndex = e.NewEditIndex;
        searchfun();
    }

   

    
}

    


