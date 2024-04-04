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
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data.OleDb;

public partial class school_dtls : System.Web.UI.Page
{
    string extension;
    static DataTable dt = new DataTable();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Initially, show the ADD panel and hide the others.
            pnlAdd.Visible = false;
            pnlView.Visible = false;
            pnlUpload.Visible = false;
            pnlTempUpload.Visible = false;

            Checkcookie();
            USERACCESS();
            dociddropdown();
            schnamedropdown();
            Temp_schnamedropdown();
        }

    }

    private void schnamedropdown()
    {
        string com = " select ECSD_SCHOOL_NO ,ECSD_SCHOOL_NAME from  ESO_CAMP_SCH_DTLS ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        SCH_DROPLIST.DataSource = dt;
        SCH_DROPLIST.DataBind();
        SCH_DROPLIST.DataTextField = "ECSD_SCHOOL_NAME";
        SCH_DROPLIST.DataValueField = "ECSD_SCHOOL_NO";
        SCH_DROPLIST.DataBind();
        SCH_DROPLIST.Items.Insert(0, new ListItem("Select School Name", ""));
    }


    private void Temp_schnamedropdown()
    {
        string com = " select ECSD_SCHOOL_NO ,ECSD_SCHOOL_NAME from  ESO_CAMP_SCH_DTLS ";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        TEMP_SCL_DROPDOWN.DataSource = dt;
        TEMP_SCL_DROPDOWN.DataBind();
        TEMP_SCL_DROPDOWN.DataTextField = "ECSD_SCHOOL_NAME";
        TEMP_SCL_DROPDOWN.DataValueField = "ECSD_SCHOOL_NO";
        TEMP_SCL_DROPDOWN.DataBind();
        TEMP_SCL_DROPDOWN.Items.Insert(0, new ListItem("Select School Name", ""));
    }


    private void dociddropdown()
    {
        string com = "SELECT EOMH_DOCUCODE,EOMH_DOC_DETAILS FROM  MR_ESO_OUTREACH_MASTER_HEADER   WHERE  EOMH_STATUS='A'";
        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        DOCU_ID.DataSource = dt;
        DOCU_ID.DataBind();
        DOCU_ID.DataTextField = "EOMH_DOC_DETAILS";
        DOCU_ID.DataValueField = "EOMH_DOCUCODE";
        DOCU_ID.DataBind();
        DOCU_ID.Items.Insert(0, new ListItem("Select Project Name", ""));
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

    protected void SCH_INSERT_Click(object sender, EventArgs e)
    {
        pnlAdd.Visible = true;
        pnlView.Visible = false;
        pnlUpload.Visible = false;
        pnlTempUpload.Visible = false;
    }

    protected void SCH_VIEW_Click(object sender, EventArgs e)
    {
        pnlAdd.Visible = false;
        pnlView.Visible = true;
        pnlUpload.Visible = false;
        pnlTempUpload.Visible = false;

        con.Open();
        string rev = " select ECSD_SCHOOL_DOC_NO as schoolDocumentNo,ECSD_SCHOOL_NAME as SchoolName,ECSD_SCHOOL_HM as SchoolHeadName,ECSD_SCHOOL_MOB_NO SchoolMobileNo,ECSD_SCHOOL_EMAILID as schoolEmailid,ECSD_SCHOOL_ADDRESS as SchoolAddress   ";
        rev += " FROM  ESO_CAMP_SCH_DTLS ";
        SqlCommand schcmd = new SqlCommand(rev, con);
        SqlDataAdapter schadapt = new SqlDataAdapter(schcmd);
        DataSet schdt = new DataSet();
        schadapt.Fill(schdt);
        sch_detail_grd.DataSource = schdt;
        sch_detail_grd.DataBind();
        con.Close();
    }

    protected void SCH_UPLOAD_Click(object sender, EventArgs e)
    {
        pnlAdd.Visible = false;
        pnlView.Visible = false;
        pnlUpload.Visible = true;
        pnlTempUpload.Visible = false;
    }

    protected void SCH_TEMP_UPLOAD_Click(object sender, EventArgs e)
    {
        pnlAdd.Visible = false;
        pnlView.Visible = false;
        pnlUpload.Visible = false;
        pnlTempUpload.Visible = true;
    }




    





    public static DataTable ReadAsDataTable(string fileName)
    {
        DataTable dataTable = new DataTable();

        using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(HttpContext.Current.Server.MapPath("STUDENTDATA_EXCEL/" + fileName), false))
        {

            WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
            IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
            string relationshipId = sheets.First().Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
            Worksheet workSheet = worksheetPart.Worksheet;
            SheetData sheetData = workSheet.GetFirstChild<SheetData>();
            IEnumerable<Row> rows = sheetData.Descendants<Row>();

            List<int> errorRows = new List<int>();


            foreach (Cell cell in rows.ElementAt(0))
            {
                dataTable.Columns.Add(GetCellValue(spreadSheetDocument, cell));
            }
            foreach (Row row in rows)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                {
                    dataRow[i] = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i));
                }

                dataTable.Rows.Add(dataRow);
            }

        }
        dataTable.Rows.RemoveAt(0);

        return dataTable;

    }

    public bool IsDataExists(string schoolNo, string firstName, string studentClass, string studentSection)
    {

        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT COUNT(*) FROM ESO_CAMP_STD_MASTER WHERE ECSM_SCHOOL_NO = @SCL_NO AND ECSM_STUDENT_FIRST_NAME = @STU_FIRST_NAME  AND ECSM_STUDENT_CLASS = @STU_CLASS AND ECSM_STUDENT_SECTION = @STU_SEC";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@SCL_NO", schoolNo));
            param.Add(new SqlParameter("@STU_FIRST_NAME", firstName));
            
            param.Add(new SqlParameter("@STU_CLASS", studentClass));
            param.Add(new SqlParameter("@STU_SEC", studentSection));

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(param.ToArray());

            int count = 0;

            connection.Open();
            count = Convert.ToInt32(command.ExecuteScalar());

            return count > 0;
        }
    }

    protected void stu_detail_upload_Click(object sender, EventArgs e)
    {
        try
        {

            string selectedSchoolNo = SCH_DROPLIST.SelectedValue;

            if (selectedSchoolNo != "")
            {
                if (stu_data_upl.HasFile)
                {
                    string FileName = stu_data_upl.FileName;
                    stu_data_upl.SaveAs(HttpContext.Current.Server.MapPath("STUDENTDATA_EXCEL/" + FileName));
                    dt = ReadAsDataTable(FileName);

                    string studnetID = "";

                string studentAttendancestatus = "";



                    string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

                HashSet<string> processedData = new HashSet<string>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    string studentFirstName = dt.Rows[i][0].ToString();
                    
                    string studentClass = dt.Rows[i][1].ToString();
                    string studentSection = dt.Rows[i][2].ToString();
                    string studentGender = dt.Rows[i][3].ToString();
                    string studentAgeStr = dt.Rows[i][4].ToString();
                    int studentAge;

                   // string studentPHnumber = dt.Rows[i][5].ToString();

                    string studentKey = $"{studentFirstName}-{studentClass}-{studentSection}";

                    // Check if the data is already processed
                    if (processedData.Contains(studentKey))
                    {
                        continue; // Skip duplicate data
                    }

                    // Check if the data already exists in the database
                    if (IsDataExists(selectedSchoolNo, studentFirstName, studentClass, studentSection))
                    {
                        continue; // Skip inserting duplicate data
                    }

                    if (!int.TryParse(studentAgeStr, out studentAge))
                    {
                        // Throw an error and stop processing
                        throw new Exception("Invalid student age format in Excel. Data not saved.");
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

                    updtcmd.Parameters.AddWithValue("@STU_CON_NO", dt.Rows[i][5].ToString());

                    updtcmd.Parameters.AddWithValue("@STU_CON_ATTEN", studentAttendancestatus);


                    updtcmd.Parameters.AddWithValue("@CR_USER_ID", currentuserid);

                    if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
                    updtcmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open) { con.Close(); } else { }






                        processedData.Add(studentKey);

                    }
                    Response.Write("<script>alert('Saved Successfully')</script>");
                }
                else
                {
                    Response.Write($"<script>alert('Please upload the file')</script>");
                }
               
            }
            else
            {
                Response.Write($"<script>alert('Please select the school name')</script>");
            }
        }
      



        catch (Exception)
        {
            Response.Write($"<script>alert('Excel is Getting Error , Data is not Saved . Check the Excel in CHECK EXCEL UPLOAD')</script>");
        }
    }


      

    protected void SCH_DTL_SAVE_Click(object sender, EventArgs e)
    {

        string extension = Path.GetExtension(SCH_MEMO_UPL.FileName);
        if (extension != "")

        {
            string fileName = SCH_MEMO_UPL.FileName;
            string filePath = HttpContext.Current.Server.MapPath("SCL_MEMO/" + fileName);
            SCH_MEMO_UPL.SaveAs(filePath);


            string School_Document_name = DOCU_ID.SelectedValue;
            string School_Name = SCH_NAME.Text;
            string School_HM_Name = SCH_HM_TXT.Text;
            string School_Mobile_Number = SCH_CON_NO.Text;

            if (School_Document_name != "" && School_Name != "" && School_HM_Name != "" && School_Mobile_Number != "")
            {
                string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

                SqlCommand updtcmd = new SqlCommand("ESO_SCH_DTLS_INSERT", con);
                updtcmd.CommandType = CommandType.StoredProcedure;

                updtcmd.Parameters.AddWithValue("@ESO_SCH_DOC_NO", School_Document_name);
                updtcmd.Parameters.AddWithValue("@ESO_SCH_NAME", School_Name);
                updtcmd.Parameters.AddWithValue("@ESO_SCH_HM", School_HM_Name);
                updtcmd.Parameters.AddWithValue("@ESO_SCH_MOB_NO", School_Mobile_Number);
                updtcmd.Parameters.AddWithValue("@ESO_SCH_EMAIL_ID", SCH_EMAIL_ID.Text);
                updtcmd.Parameters.AddWithValue("@ESO_SCH_ADDRESS", SCH_ADDRESS.Text);

            updtcmd.Parameters.AddWithValue("@ECSD_SCH_DISTRICT", TEXT_SCH_DISTRICT.Text);
            updtcmd.Parameters.AddWithValue("@ECSD_SCH_STATE", TEXT_SCL_STATE.Text);



            updtcmd.Parameters.AddWithValue("@ECFU_SCHOOL_DOC_FILENAME", string.IsNullOrEmpty(fileName) ? DBNull.Value : (object)fileName);
            updtcmd.Parameters.AddWithValue("@ECFU_SCHOOL_DOC_FILEPATH", string.IsNullOrEmpty(filePath) ? DBNull.Value : (object)filePath);

            updtcmd.Parameters.AddWithValue("@ESO_CRT_UID", currentuserid);
            updtcmd.Parameters.AddWithValue("@ESO_LAST_UPT_UID", currentuserid);
            if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
            updtcmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open) { con.Close(); } else { }

                Response.Write("<script>alert(' Saved Successfully')</script>");

                DOCU_ID.Text = null;


                SCH_NAME.Text = null;


                SCH_HM_TXT.Text = null;


                SCH_CON_NO.Text = null;


                SCH_EMAIL_ID.Text = null;


                SCH_ADDRESS.Text = null;

                TEXT_SCH_DISTRICT.Text = null;

                TEXT_SCL_STATE.Text = null;

                Label2.Text = null;

                schnamedropdown();

                Temp_schnamedropdown();
            }
            else
            {
                Label2.Text = "Fill the data Correctly";
                Response.Write("<script>alert(' Data is Not Saved ')</script>");
            }

        }
        
        else
        {
            string fileName = " ";
            string filePath = " ";

            string School_Document_name = DOCU_ID.SelectedValue;
            string School_Name = SCH_NAME.Text;
            string School_HM_Name = SCH_HM_TXT.Text;
            string School_Mobile_Number = SCH_CON_NO.Text;

            if (School_Document_name != "" && School_Name != "" && School_HM_Name != "" && School_Mobile_Number != "")
            {
                string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

            SqlCommand updtcmd = new SqlCommand("ESO_SCH_DTLS_INSERT", con);
            updtcmd.CommandType = CommandType.StoredProcedure;
            updtcmd.Parameters.AddWithValue("@ESO_SCH_DOC_NO", School_Document_name);
            updtcmd.Parameters.AddWithValue("@ESO_SCH_NAME", School_Name);
            updtcmd.Parameters.AddWithValue("@ESO_SCH_HM", School_HM_Name);
            updtcmd.Parameters.AddWithValue("@ESO_SCH_MOB_NO", School_Mobile_Number);
            updtcmd.Parameters.AddWithValue("@ESO_SCH_EMAIL_ID", SCH_EMAIL_ID.Text);
            updtcmd.Parameters.AddWithValue("@ESO_SCH_ADDRESS", SCH_ADDRESS.Text);

            updtcmd.Parameters.AddWithValue("@ECSD_SCH_DISTRICT", TEXT_SCH_DISTRICT.Text);
            updtcmd.Parameters.AddWithValue("@ECSD_SCH_STATE", TEXT_SCL_STATE.Text);

            updtcmd.Parameters.AddWithValue("@ECFU_SCHOOL_DOC_FILENAME", fileName);
            updtcmd.Parameters.AddWithValue("@ECFU_SCHOOL_DOC_FILEPATH", filePath);


            updtcmd.Parameters.AddWithValue("@ESO_CRT_UID", currentuserid);
            updtcmd.Parameters.AddWithValue("@ESO_LAST_UPT_UID", currentuserid);
            if (con.State == ConnectionState.Open) { con.Close(); con.Open(); } else { con.Open(); }
            updtcmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open) { con.Close(); } else { }

            Response.Write("<script>alert(' Saved Successfully')</script>");





        DOCU_ID.Text = null;


        SCH_NAME.Text = null;


        SCH_HM_TXT.Text = null;


        SCH_CON_NO.Text = null;


        SCH_EMAIL_ID.Text = null;


        SCH_ADDRESS.Text = null;

            TEXT_SCH_DISTRICT.Text = null;

            TEXT_SCL_STATE.Text = null;

                Label2.Text = null;

            schnamedropdown();
            Temp_schnamedropdown();

            }
            else
            {
                Label2.Text = "Fill the data Correctly";
                Response.Write("<script>alert(' Data is Not Saved ')</script>");
            }

        }





       
    }





    //--------------------------------------    Temp_IsDataExists Method of  Temp_stu_detail_upload_Click ------------------------------------


    public bool Temp_IsDataExists(string schoolNo, string firstName, string studentClass, string studentSection)
    {

        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT COUNT(*) FROM TEMP_ESO_CAMP_STD_MASTER WHERE TEMP_ECSM_SCHOOL_NO = @SCL_NO AND TEMP_ECSM_STUDENT_FIRST_NAME = @STU_FIRST_NAME AND  TEMP_ECSM_STUDENT_CLASS = @STU_CLASS AND TEMP_ECSM_STUDENT_SECTION = @STU_SEC";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@SCL_NO", schoolNo));
            param.Add(new SqlParameter("@STU_FIRST_NAME", firstName));

            param.Add(new SqlParameter("@STU_CLASS", studentClass));
            param.Add(new SqlParameter("@STU_SEC", studentSection));

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(param.ToArray());

            int count = 0;

            connection.Open();
            count = Convert.ToInt32(command.ExecuteScalar());

            return count > 0;
        }
    }



    //--------------------------------------    Temp_ReadAsDataTable Method of  Temp_stu_detail_upload_Click ---------------------------------------

    public static DataTable Temp_ReadAsDataTable(string fileName)
    {
        DataTable dataTable = new DataTable();

        using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(HttpContext.Current.Server.MapPath("TEMP_STUDENTDATA_EXCEL/" + fileName), false))
        {

            WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
            IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
            string relationshipId = sheets.First().Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
            Worksheet workSheet = worksheetPart.Worksheet;
            SheetData sheetData = workSheet.GetFirstChild<SheetData>();
            IEnumerable<Row> rows = sheetData.Descendants<Row>();

            List<int> errorRows = new List<int>();


            foreach (Cell cell in rows.ElementAt(0))
            {
                dataTable.Columns.Add(GetCellValue(spreadSheetDocument, cell));
            }
            foreach (Row row in rows)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                {
                    dataRow[i] = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i));
                }

                dataTable.Rows.Add(dataRow);
            }

        }
        dataTable.Rows.RemoveAt(0);

        return dataTable;

    }


    //--------------------------------------------------GetCellValue method of Temp_ReadAsDataTable ---------------------------------
    private static string GetCellValue(SpreadsheetDocument document, Cell cell)
    {
        SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
        string value = cell.CellValue?.InnerXml ?? null;

        if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
        {
            int sharedStringIndex;
            if (int.TryParse(value, out sharedStringIndex))
            {
                return stringTablePart.SharedStringTable.ChildElements[sharedStringIndex].InnerText;
            }
        }

        return value;
    }
    //------------------------------------------------------TruncateTempESOCampStdMasterTable method of Temp_stu_detail_upload_Click----------------------------------
    private void TruncateTempESOCampStdMasterTable()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string truncateQuery = "TRUNCATE TABLE TEMP_ESO_CAMP_STD_MASTER";

            using (SqlCommand command = new SqlCommand(truncateQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }







    protected void temp_stu_detail_upload_Click(object sender, EventArgs e)
    {
        try
        {
            string selectedSchoolNo = TEMP_SCL_DROPDOWN.SelectedValue;

            if (selectedSchoolNo != "")
            {
                if (TEMP_FILE_UPLOAD.HasFile)
                {

                string FileName = TEMP_FILE_UPLOAD.FileName;
                TEMP_FILE_UPLOAD.SaveAs(HttpContext.Current.Server.MapPath("TEMP_STUDENTDATA_EXCEL/" + FileName));


                TruncateTempESOCampStdMasterTable();

                dt = Temp_ReadAsDataTable(FileName);
                TEMP_ESO_CAMP tcdata = new TEMP_ESO_CAMP();

                    
                    string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];


                List<int> errorRows = new List<int>();
                // errorRows = null;

                List<string> errorMessages = new List<string>();
                // errorMessages = null;

                HashSet<string> processedData = new HashSet<string>();


                errorGridView.DataSource = null;
                errorGridView.DataBind();

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string studentFirstName = dt.Rows[i][0].ToString();
              
                    string studentClass = dt.Rows[i][1].ToString();
                    string studentSection = dt.Rows[i][2].ToString();
                    string studentGender = dt.Rows[i][3].ToString();
                    int studentAge;

                    string studentKey = $"{studentFirstName}-{studentClass}-{studentSection}";


                    if (processedData.Contains(studentKey))
                    {
                        continue; // Skip duplicate data
                    }


                    if (Temp_IsDataExists(selectedSchoolNo, studentFirstName, studentClass, studentSection))
                    {
                        continue; // Skip inserting duplicate data
                    }

                    


                    if (!int.TryParse(dt.Rows[i][4].ToString(), out studentAge))
                    {

                        errorRows.Add(i + 1);
                        errorGridView.DataSource = errorRows.Select(row => new { RowNumber = row + 1, ErrorMessage = "ROW DATA IS GETTING ERROR , MODIFY THAT ERROR AND REUPLOAD THE EXCEL" });
                        errorGridView.DataBind();
                        foreach (GridViewRow row in errorGridView.Rows)
                        {
                            row.ForeColor = System.Drawing.Color.Red;
                        }

                        continue;
                    }

                    if (string.IsNullOrEmpty(studentFirstName))
                    {
                        errorRows.Add(i + 1);

                        errorGridView.DataSource = errorRows.Select(row => new { RowNumber = row + 1, ErrorMessage = "ROW DATA IS GETTING ERROR , MODIFY THAT ERROR AND REUPLOAD THE EXCEL" });
                        errorGridView.DataBind();
                        foreach (GridViewRow row in errorGridView.Rows)
                        {
                            row.ForeColor = System.Drawing.Color.Red;
                        }


                        continue;
                    }

                  

                    if (string.IsNullOrEmpty(studentClass))
                    {
                        errorRows.Add(i + 1);

                        errorGridView.DataSource = errorRows.Select(row => new { RowNumber = row + 1, ErrorMessage = "ROW DATA IS GETTING ERROR , MODIFY THAT ERROR AND REUPLOAD THE EXCEL" });
                        errorGridView.DataBind();
                        foreach (GridViewRow row in errorGridView.Rows)
                        {
                            row.ForeColor = System.Drawing.Color.Red;
                        }


                        continue;
                    }

                    if (string.IsNullOrEmpty(studentSection))
                    {
                        errorRows.Add(i + 1);

                        errorGridView.DataSource = errorRows.Select(row => new { RowNumber = row + 1, ErrorMessage = "ROW DATA IS GETTING ERROR , MODIFY THAT ERROR AND REUPLOAD THE EXCEL" });
                        errorGridView.DataBind();
                        foreach (GridViewRow row in errorGridView.Rows)
                        {
                            row.ForeColor = System.Drawing.Color.Red;
                        }


                        continue;
                    }


                    if (string.IsNullOrEmpty(studentGender))
                    {
                        errorRows.Add(i + 1);

                        errorGridView.DataSource = errorRows.Select(row => new { RowNumber = row + 1, ErrorMessage = "ROW DATA IS GETTING ERROR , MODIFY THAT ERROR AND REUPLOAD THE EXCEL" });
                        errorGridView.DataBind();
                        foreach (GridViewRow row in errorGridView.Rows)
                        {
                            row.ForeColor = System.Drawing.Color.Red;
                        }


                        continue;
                    }


                    tcdata.TEMP_ECSM_SCHOOL_NO = selectedSchoolNo;
                    tcdata.TEMP_ECSM_STUDENT_FIRST_NAME = studentFirstName;
                   
                    tcdata.TEMP_ECSM_STUDENT_CLASS = studentClass;
                    tcdata.TEMP_ECSM_STUDENT_SECTION = studentSection;
                    tcdata.TEMP_ECSM_STUDENT_AGE = studentAge;
                    tcdata.TEMP_ECSM_STUDENT_GENDER = studentGender;
                    tcdata.TEMP_ECSM_STUDENT_PH_NUMBER = dt.Rows[i][5].ToString();
                    tcdata.TEMP_ECSM_CREATED_USER_ID = currentuserid;
                    tcdata.Temp_Save_Data();

                    processedData.Add(studentKey);

                }
                if (errorRows.Count > 0)
                {
                    Response.Write("<script>alert('Some rows have errors. Please fix the errors and reupload the Excel.')</script>");
                }
                else
                {

                    Response.Write($"<script>alert(' Saved Successfully')</script>");
                }


                    Temp_schnamedropdown();
                    // Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {
                    Response.Write($"<script>alert('Please upload the file')</script>");
                }
            }
            else
            {
                Response.Write($"<script>alert('Please select the school name')</script>");
            }
        }
        catch (Exception)
        {

            Response.Write($"<script>alert('Excel data is not Saved . Some Excel data is not Filled , Fill the Excel data and reupload ')</script>");
        }

    }
}