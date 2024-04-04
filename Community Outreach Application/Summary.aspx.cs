using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class POPUPSCREENS_Summary : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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

            if (RLCOD != "MEOSTU")
            {
                Response.Redirect("Unauthorized.aspx");

            }



        }
        con.Close();
    }

    private void studentdetailsfetch()
	{
		string stser = "SELECT ECSD_SCHOOL_NO, ECSD_SCHOOL_NAME, ECSM_STUDENT_ID, ECSM_STUDENT_FIRST_NAME, ECSM_STUDENT_CLASS, ECSM_STUDENT_SECTION, ";
		stser += "ECSM_STUDENT_AGE, ECSM_STUDENT_GENDER, ECSM_STUDENT_STATUS_FLAG FROM ESO_CAMP_STD_MASTER ";
		stser += "LEFT OUTER JOIN ESO_CAMP_SCH_DTLS ON ECSD_SCHOOL_NO = ECSM_SCHOOL_NO ";
		stser += "WHERE ECSM_STUDENT_ID = '" + Textbox.Text + "'";
		con.Open();
		SqlCommand cmd = new SqlCommand(stser, con);
		SqlDataAdapter da = new SqlDataAdapter(cmd);
		DataSet ds = new DataSet();
		da.Fill(ds);
	

		if (ds.Tables[0].Rows.Count >= 1)
		{
            school_name.Text = ds.Tables[0].Rows[0]["ECSD_SCHOOL_NAME"].ToString().TrimEnd().TrimStart();
            stu_name.Text = ds.Tables[0].Rows[0]["ECSM_STUDENT_FIRST_NAME"].ToString().TrimEnd().TrimStart();
			stu_age.Text = ds.Tables[0].Rows[0]["ECSM_STUDENT_AGE"].ToString().TrimEnd().TrimStart();
			stu_class.Text = ds.Tables[0].Rows[0]["ECSM_STUDENT_CLASS"].ToString().TrimEnd().TrimStart();
			stu_sec.Text = ds.Tables[0].Rows[0]["ECSM_STUDENT_SECTION"].ToString().TrimEnd().TrimStart();
            

        }

        con.Close();
    }


    //Visual Acuity
    protected void VisualAcuity_CheckedChanged(object sender, EventArgs e)
    {
        if (vacheck.Checked)
        {
            VAlabel.Text = ""; // Clear the label if the checkbox is checked
            SummaryLabel.Text = "";
        }
        else
        {
            string std_text = Textbox.Text;
            string VisualAcuitySummary = string.Empty;


            //Visual Acuity/Refraction
            string sqlQuery = "SELECT ECMP_SUMMARY FROM ESO_CAMP_MR_PGP WHERE ECMP_STD_NUMBER=@std_text";



            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.Parameters.AddWithValue("@std_text", std_text);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    VisualAcuitySummary = reader["ECMP_SUMMARY"].ToString();


                    VAlabel.Text = "Visual Acuity/Refraction : ";
                    SummaryLabel.Text = VisualAcuitySummary;
                }
                else
                {
                    VAlabel.Text = "";
                    SummaryLabel.Text = "";
                }
            }
            catch (Exception ex)
            {

                SummaryLabel.Text = "An error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        
    }



    protected void IntermediateVision_CheckedChanged(object sender, EventArgs e)
    {
        if (ivcheck.Checked)
        {
            IVLabel.Text = ""; // Clear the label if the checkbox is checked
            IVSummaryLabel.Text = "";
        }
        else
        {
            string std_text = Textbox.Text;
            string VisualAcuitySummary = string.Empty;
            string query = "SELECT ECIV_SUMMARY FROM ESO_INTERMEDIATE_VISION_REFRACTION WHERE ECIV_STD_NUMBER=@std_text1";



            SqlCommand cmd1 = new SqlCommand(query, con);
            cmd1.Parameters.AddWithValue("@std_text1", std_text);

            try
            {
                con.Open();
                SqlDataReader reader2 = cmd1.ExecuteReader();

                if (reader2.Read())
                {

                    string Summary = reader2["ECIV_SUMMARY"].ToString();
                    IVLabel.Text = "Intermediate Vision : ";
                    IVSummaryLabel.Text = Summary;
                }
                else
                {
                    IVLabel.Text = "";
                    IVSummaryLabel.Text = "";
                }
            }
            catch (Exception ex)
            {

                IVSummaryLabel.Text = "An error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

        }

    }

    protected void COMPLAINTS_CheckedChanged(object sender, EventArgs e)
    {
        if (compcheck.Checked)
        {
            ComLabel.Text = ""; // Clear the label if the checkbox is checked
            ComSummaryLabel.Text = "";
        }
        else
        {
            string std_text = Textbox.Text;
            string VisualAcuitySummary = string.Empty;
            string query3 = "SELECT ECMC_COMPLAINTS_SUMMARY FROM ESO_CAMP_MR_COMPLAINTS WHERE ECMC_STD_NUMBER=@std_text1";



            SqlCommand cmd4 = new SqlCommand(query3, con);
            cmd4.Parameters.AddWithValue("@std_text1", std_text);

            try
            {
                con.Open();
                SqlDataReader reader5 = cmd4.ExecuteReader();

                if (reader5.Read())
                {

                    string Summary = reader5["ECMC_COMPLAINTS_SUMMARY"].ToString();
                    ComLabel.Text = "Complaints : ";
                    ComSummaryLabel.Text = Summary;
                }
                else
                {
                    ComLabel.Text = "";
                    ComSummaryLabel.Text = "";
                }
            }
            catch (Exception ex)
            {

                ComSummaryLabel.Text = "An error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void OCULAR_HISTORY_CheckedChanged(object sender, EventArgs e)
    {
        if (ochcheck.Checked)
        {
            OHLabel.Text = ""; // Clear the label if the checkbox is checked
            OHSummaryLabel.Text = "";
        }
        else
        {
            string std_text = Textbox.Text;
            string VisualAcuitySummary = string.Empty;

            string query2 = "SELECT ECOM_OCULAR_SUMMARY FROM ESO_CAMP_MR_OCULAR_HISTORY WHERE ECMO_STD_NUMBER=@std_text1";



            SqlCommand cmd3 = new SqlCommand(query2, con);
            cmd3.Parameters.AddWithValue("@std_text1", std_text);

            try
            {
                con.Open();
                SqlDataReader reader4 = cmd3.ExecuteReader();

                if (reader4.Read())
                {

                    string Summary = reader4["ECOM_OCULAR_SUMMARY"].ToString();
                    OHLabel.Text = "OCULAR HISTORY : ";
                    OHSummaryLabel.Text = Summary;
                }
                else
                {
                    OHLabel.Text = "";
                    OHSummaryLabel.Text = "";
                }
            }
            catch (Exception ex)
            {

                OHSummaryLabel.Text = "An error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

    }


    // DBR
    protected void DBR_CheckedChanged(object sender, EventArgs e)
    {
        if (dbrcheck.Checked)
        {
            DBRLabel.Text = ""; // Clear the label if the checkbox is checked
            DBRSummaryLabel.Text = "";
        }
        else
        {
            string std_text = Textbox.Text;
            string query4 = "SELECT ECMD_SUMMARY FROM ESO_CAMP_MR_DBR WHERE ECMD_MR_STU_ID=@std_text1";


            SqlCommand cmd5 = new SqlCommand(query4, con);
            cmd5.Parameters.AddWithValue("@std_text1", std_text);

            try
            {
                con.Open();
                SqlDataReader reader5 = cmd5.ExecuteReader();

                if (reader5.Read())
                {

                    string Summary = reader5["ECMD_SUMMARY"].ToString();
                    DBRLabel.Text = "DBR  : ";
                    DBRSummaryLabel.Text = Summary;
                }
                else
                {
                    DBRLabel.Text = "";
                    DBRSummaryLabel.Text = "";
                }
            }
            catch (Exception ex)
            {

                ComSummaryLabel.Text = "An error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

        }

    }

    //Covertest

    protected void Covertest_CheckedChanged(object sender, EventArgs e)
    {
        if (covertestcheck.Checked)
        {
            CovertestLabel.Text = ""; // Clear the label if the checkbox is checked
            CovertestSummaryLabel.Text = "";
        }
        else
        {
            string std_text = Textbox.Text;
            string query5 = "SELECT ECT_SUMMARY FROM ESO_COVER_TEST WHERE ECT_STUDENT_ID=@std_text1";


            SqlCommand cmd6 = new SqlCommand(query5, con);
            cmd6.Parameters.AddWithValue("@std_text1", std_text);

            try
            {
                con.Open();
                SqlDataReader reader5 = cmd6.ExecuteReader();

                if (reader5.Read())
                {

                    string Summary = reader5["ECT_SUMMARY"].ToString();
                    CovertestLabel.Text = "Cover test  : ";
                    CovertestSummaryLabel.Text = Summary;
                }
                else
                {
                    CovertestLabel.Text = "";
                    CovertestSummaryLabel.Text = "";
                }
            }
            catch (Exception ex)
            {

                ComSummaryLabel.Text = "An error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

        }

    }


    protected void SearchButton(object sender, EventArgs e)
    {

       

            string std_text = Textbox.Text;
            string VisualAcuitySummary = string.Empty;


            //Visual Acuity/Refraction
            string sqlQuery = "SELECT ECMP_SUMMARY FROM ESO_CAMP_MR_PGP WHERE ECMP_STD_NUMBER=@std_text";



            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.Parameters.AddWithValue("@std_text", std_text);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    VisualAcuitySummary = reader["ECMP_SUMMARY"].ToString();


                VAlabel.Text = "Visual Acuity/Refraction : ";
                SummaryLabel.Text = VisualAcuitySummary;
            }
            else
            {
                VAlabel.Text = "";
                SummaryLabel.Text = "";
            }
        }
        catch (Exception ex)
        {

            SummaryLabel.Text = "An error occurred: " + ex.Message;
        }
        finally
        {
            con.Close();
        }


        //Intermediate Vision

        string query = "SELECT ECIV_SUMMARY FROM ESO_INTERMEDIATE_VISION_REFRACTION WHERE ECIV_STD_NUMBER=@std_text1";



        SqlCommand cmd1 = new SqlCommand(query, con);
        cmd1.Parameters.AddWithValue("@std_text1", std_text);

        try
        {
            con.Open();
            SqlDataReader reader2 = cmd1.ExecuteReader();

            if (reader2.Read())
            {

                string Summary = reader2["ECIV_SUMMARY"].ToString();
                IVLabel.Text = "Intermediate Vision : ";
                IVSummaryLabel.Text = Summary;
            }
            else
            {
                IVLabel.Text = "";
                IVSummaryLabel.Text = "";
            }
        }
        catch (Exception ex)
        {

            IVSummaryLabel.Text = "An error occurred: " + ex.Message;
        }
        finally
        {
            con.Close();
        }


            //---Post Dilated Refraction --



            //    string query1 = "SELECT ECPDR_SUMMARY FROM ESO_POSTDILATED_REFRACTION WHERE ECPDR_STD_NUMBER=@std_text1";



            //SqlCommand cmd2 = new SqlCommand(query1, con);
            //cmd2.Parameters.AddWithValue("@std_text1", std_text);

            //try
            //{
            //    con.Open();
            //    SqlDataReader reader3 = cmd2.ExecuteReader();

            //    if (reader3.Read())
            //    {

            //        string Summary = reader3["ECPDR_SUMMARY"].ToString();
            //        PDRLabel.Text = "Post Dilated Refraction : ";
            //        PDRSummarylabel.Text = Summary;
            //    }
            //    else
            //    {
            //        PDRLabel.Text = " ";
            //        PDRSummarylabel.Text = "";
            //    }
            //}
            //catch (Exception ex)
            //{

            //    PDRSummarylabel.Text = "An error occurred: " + ex.Message;
            //}
            //finally
            //{
            //    con.Close();
            //}



            //-- OCULAR HISTORY      




            string query2 = "SELECT ECOM_OCULAR_SUMMARY FROM ESO_CAMP_MR_OCULAR_HISTORY WHERE ECMO_STD_NUMBER=@std_text1";



            SqlCommand cmd3 = new SqlCommand(query2, con);
            cmd3.Parameters.AddWithValue("@std_text1", std_text);

            try
            {
                con.Open();
                SqlDataReader reader4 = cmd3.ExecuteReader();

                if (reader4.Read())
                {

                    string Summary = reader4["ECOM_OCULAR_SUMMARY"].ToString();
                    OHLabel.Text = "OCULAR HISTORY : ";
                    OHSummaryLabel.Text = Summary;
                }
                else
                {
                    OHLabel.Text = "";
                    OHSummaryLabel.Text = "";
                }
            }
            catch (Exception ex)
            {

                OHSummaryLabel.Text = "An error occurred: " + ex.Message;
            }
            finally
            {
                con.Close();
            }


        // ----- Complaints



        string query3 = "SELECT ECMC_COMPLAINTS_SUMMARY FROM ESO_CAMP_MR_COMPLAINTS WHERE ECMC_STD_NUMBER=@std_text1";



        SqlCommand cmd4 = new SqlCommand(query3, con);
        cmd4.Parameters.AddWithValue("@std_text1", std_text);

        try
        {
            con.Open();
            SqlDataReader reader5 = cmd4.ExecuteReader();

            if (reader5.Read())
            {

                string Summary = reader5["ECMC_COMPLAINTS_SUMMARY"].ToString();
                ComLabel.Text = "Complaints : ";
                ComSummaryLabel.Text = Summary;
            }
            else
            {
                ComLabel.Text = "";
                ComSummaryLabel.Text = "";
            }
        }
        catch (Exception ex)
        {

            ComSummaryLabel.Text = "An error occurred: " + ex.Message;
        }
        finally
        {
            con.Close();
        }



        

        //DBR 

        string query4 = "SELECT ECMD_SUMMARY FROM ESO_CAMP_MR_DBR WHERE ECMD_MR_STU_ID=@std_text1";


        SqlCommand cmd5 = new SqlCommand(query4, con);
        cmd5.Parameters.AddWithValue("@std_text1", std_text);

        try
        {
            con.Open();
            SqlDataReader reader5 = cmd5.ExecuteReader();

            if (reader5.Read())
            {

                string Summary = reader5["ECMD_SUMMARY"].ToString();
                DBRLabel.Text = "DBR  : ";
                DBRSummaryLabel.Text = Summary;
            }
            else
            {
                DBRLabel.Text = "";
                DBRSummaryLabel.Text = "";
            }
        }
        catch (Exception ex)
        {

            ComSummaryLabel.Text = "An error occurred: " + ex.Message;
        }
        finally
        {
            con.Close();
        }


        //Cover test



        string query5 = "SELECT ECT_SUMMARY FROM ESO_COVER_TEST WHERE ECT_STUDENT_ID=@std_text1";


        SqlCommand cmd6 = new SqlCommand(query5, con);
        cmd6.Parameters.AddWithValue("@std_text1", std_text);

        try
        {
            con.Open();
            SqlDataReader reader5 = cmd6.ExecuteReader();

            if (reader5.Read())
            {

                string Summary = reader5["ECT_SUMMARY"].ToString();
                CovertestLabel.Text = "Cover test  : ";
                CovertestSummaryLabel.Text = Summary;
            }
            else
            {
                CovertestLabel.Text = "";
                CovertestSummaryLabel.Text = "";
            }
        }
        catch (Exception ex)
        {

            ComSummaryLabel.Text = "An error occurred: " + ex.Message;
        }
        finally
        {
            con.Close();
        }


        studentdetailsfetch();


	}

    protected void RedirectButton_Click(object sender, EventArgs e)
    {
        // Redirect to a new URL when the button is clicked
        Response.Redirect("/COMMUNITY_OUTREACH/DETAILEXAM.aspx");
    }

}