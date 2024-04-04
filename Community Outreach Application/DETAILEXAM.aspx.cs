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

public partial class DETAILEXAM : System.Web.UI.Page
{
	SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
	protected void Page_Load(object sender, EventArgs e)
	{
		if(!IsPostBack)
		{
			schnamedropdown();
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

            if (RLCOD != "MEOSTU" && RLCOD != "MEOPA" && RLCOD != "MEODEO")
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
		DETAIL_EXAM_DROP.DataSource = dt;
		DETAIL_EXAM_DROP.DataBind();
		DETAIL_EXAM_DROP.DataTextField = "ECSD_SCHOOL_NAME";
		DETAIL_EXAM_DROP.DataValueField = "ECSD_SCHOOL_NO";
		DETAIL_EXAM_DROP.DataBind();
		DETAIL_EXAM_DROP.Items.Insert(0, new ListItem("Select School Name", ""));
	}



	protected void details_exam_search_Click(object sender, EventArgs e)
	{
		con.Open();
		string examload = " SELECT ECSD_SCHOOL_NAME,ECSM_STUDENT_ID,ECSM_STUDENT_FIRST_NAME,ECSM_STUDENT_CLASS, ECSM_STUDENT_SECTION,ECSM_STUDENT_AGE, ECSM_STUDENT_GENDER FROM ESO_CAMP_STD_CHECKUP_DTLS ";
		examload += " INNER JOIN  ESO_CAMP_STD_MASTER ON ECSCD_STUDENT_ID=ECSM_STUDENT_ID  ";
		examload += " INNER JOIN  ESO_CAMP_SCH_DTLS ON ECSD_SCHOOL_NO=ECSCD_SCHOOL_NO  ";
		examload += " WHERE ECSCD_DETAILS_EXAM_FLAG='Yes' AND  ECSCD_SCHOOL_NO ='" + DETAIL_EXAM_DROP.SelectedValue + "' ";
		//examload += " AND ECSCD_DS_TEST_OD='YES' AND ECSCD_DS_TEST_OS='YES' AND ECSCD_OCULAR_COMP='YES' ";
		//examload += " AND ECSCD_ABNORMAL_REMARKS_OD NOT IN ('BLEPHARITIS','MEIBOMITIS','CHALAZION','STYE','BLEPHARITIS & MEIBOMITIS') ";
		//examload += " AND ECSCD_ABNORMAL_REMARKS_OS NOT IN ('BLEPHARITIS','MEIBOMITIS','CHALAZION','STYE','BLEPHARITIS & MEIBOMITIS') ";
		//examload += " AND ECSCD_COVER_TEST NOT IN ('IDS-GOOD CONTROL','ORTHO','EXOPHORIA','ESOPHORIA') AND ECSCD_SCHOOL_NO ='" + DETAIL_EXAM_DROP .SelectedValue+ "' ";
		SqlCommand cmd = new SqlCommand(examload, con);
		SqlDataAdapter adapt = new SqlDataAdapter(cmd);
		DataSet dt = new DataSet();
		adapt.Fill(dt);
		detail_exam_load.DataSource = dt;
		detail_exam_load.DataBind();
		con.Close();





		//con.Open();
		//string examload = " SELECT ECSD_SCHOOL_NAME,ECSM_STUDENT_ID,ECSM_STUDENT_FIRST_NAME,ECSM_STUDENT_CLASS, ECSM_STUDENT_SECTION,ECSM_STUDENT_AGE, ECSM_STUDENT_GENDER FROM ESO_CAMP_STD_CHECKUP_DTLS ";
		//examload += " INNER JOIN  ESO_CAMP_STD_MASTER ON ECSCD_STUDENT_ID=ECSM_STUDENT_ID  ";
		//examload += " INNER JOIN  ESO_CAMP_SCH_DTLS ON ECSD_SCHOOL_NO=ECSCD_SCHOOL_NO  ";
		//examload += " WHERE ECSCD_USING_SPEC='YES' AND ECSCD_WITHOUT_SPEC_OD='NO' AND ECSCD_WITHOUT_SPEC_OS='NO' ";
		//examload += " AND ECSCD_DS_TEST_OD='YES' AND ECSCD_DS_TEST_OS='YES' AND ECSCD_OCULAR_COMP='YES' ";
		//examload += " AND ECSCD_ABNORMAL_REMARKS_OD NOT IN ('BLEPHARITIS','MEIBOMITIS','CHALAZION','STYE','BLEPHARITIS & MEIBOMITIS') ";
		//examload += " AND ECSCD_ABNORMAL_REMARKS_OS NOT IN ('BLEPHARITIS','MEIBOMITIS','CHALAZION','STYE','BLEPHARITIS & MEIBOMITIS') ";
		//examload += " AND ECSCD_COVER_TEST NOT IN ('IDS-GOOD CONTROL','ORTHO','EXOPHORIA','ESOPHORIA') AND ECSCD_SCHOOL_NO ='" + DETAIL_EXAM_DROP.SelectedValue + "' ";
		//SqlCommand cmd = new SqlCommand(examload, con);
		//SqlDataAdapter adapt = new SqlDataAdapter(cmd);
		//DataSet dt = new DataSet();
		//adapt.Fill(dt);
		//detail_exam_load.DataSource = dt;
		//detail_exam_load.DataBind();
		//con.Close();
	}
}