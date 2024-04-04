


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;

public partial class LOGINPG : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
    string USERNAME = "";
    string USERHMSID = null;
    string ROLE = null;
    string USEREMPNUM = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["COMM_OUTREACH"] != null)
        {
            if (!IsPostBack) { /*username.Focus();*/ Checkcookie(); }
            else if (IsPostBack) { /*username.Focus(); */}
            else { Response.Cookies["COMM_OUTREACH"]["CookieAlive"] = "False"; Response.Cookies["COMM_OUTREACH"].Expires = DateTime.Now.AddDays(-1); }

        }
        else
        {
            if (!IsPostBack) { /*username.Focus();*/ }
        }

    }

    private void Checkcookie()
    {
        if (Request.Cookies["COMM_OUTREACH"] != null)
        {
            string Cookiecheck = Request.Cookies["COMM_OUTREACH"]["CookieAlive"];
            if (Cookiecheck == "False")
            {
                Sessioncheck.Value = "False";
                Response.Redirect("/COMMUNITY_OUTREACH/LOGINPG.aspx");
            }
            else if (Cookiecheck == "True")
            {
                DateTime CookieDateTime = DateTime.Now.AddDays(1);
                Sessioncheck.Value = "True";

                string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];
                string currentempid = Request.Cookies["COMM_OUTREACH"]["USEREMPNUM"];
                string currentesorocode = Request.Cookies["COMM_OUTREACH"]["USERROLECODE"];
                string currentcookiealive = Request.Cookies["COMM_OUTREACH"]["CookieAlive"];
                string currentusername = Request.Cookies["COMM_OUTREACH"]["USERNAME"];
                string currentexpire = Request.Cookies["COMM_OUTREACH"]["CookiesExpiryon"];

                Response.Cookies["COMM_OUTREACH"]["USERHMSID"] = currentuserid;
                Response.Cookies["COMM_OUTREACH"]["USEREMPNUM"] = currentempid;
                Response.Cookies["COMM_OUTREACH"]["USERROLECODE"] = currentesorocode;
                Response.Cookies["COMM_OUTREACH"]["CookieAlive"] = "True";
                Response.Cookies["COMM_OUTREACH"]["USERNAME"] = currentusername;
                Response.Cookies["COMM_OUTREACH"]["CookiesExpiryon"] = CookieDateTime.ToString("dd-MM-yyyy hh:mm:ss tt");
                Response.Cookies["COMM_OUTREACH"].Expires = CookieDateTime;
                //Response.Redirect("/UTSApplication/Login.aspx");
            }
            else
            {
                Sessioncheck.Value = "False";
                Response.Cookies["COMM_OUTREACH"]["CookieAlive"] = "False";
                Response.Cookies["COMM_OUTREACH"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("/SN_WAIVER_FORM/Login.aspx");
            }
        }
        else
        {
            Response.Redirect("/COMMUNITY_OUTREACH/LOGINPG.aspx");
        }
    }


    protected void lOGIN_BTN_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
        DateTime CookieDateTime = DateTime.Now.AddDays(1);
        USERHMSID = inputEmail.Text.ToString();

        Convertpassword();
        con.Open();
        SqlCommand cmd = new SqlCommand(" select top 1  HUM_USER_NAME as HUM_USER_NAME,HUM_USER_PASSWD,HUM_USER_ID,HUM_USER_ID,HUM_LOCATION_CD,MEOURS_ROLE_CODE from AS_USER_MASTER " +
            " inner join MR_ESO_ORC_USER_RIGHTS on MEOURS_EMP_NUM=HUM_EMP_NUM " +
            "where HUM_USER_ID=@UserHMSID   and HUM_USER_STATUS='A' order by HUM_LAST_SIGNEDIN_DT desc", con);
        cmd.Parameters.AddWithValue("@UserHMSID", USERHMSID.Trim());
        SqlDataAdapter reader = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        reader.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count == 1)
        {
            if (hashpass.Value == ds.Tables[0].Rows[0]["HUM_USER_PASSWD"].ToString())
            {
                ESOUSROLE.Value = ds.Tables[0].Rows[0]["MEOURS_ROLE_CODE"].ToString().TrimEnd().TrimStart();

                //string ROLEDLTS = "";
                //Response.Cookies["COMM_OUTREACH"]["MEOURS_ROLE_CODE"] = ROLEDLTS;
                Response.Cookies["COMM_OUTREACH"]["USERHMSID"] = ds.Tables[0].Rows[0]["HUM_USER_ID"].ToString();
                //Response.Cookies["COMM_OUTREACH"]["USEREMPNUM"] = ds.Tables[0].Rows[0]["EEM_EMP_NUM"].ToString();
                Response.Cookies["COMM_OUTREACH"]["CookieAlive"] = "True";
                Response.Cookies["COMM_OUTREACH"]["UserName"] = ds.Tables[0].Rows[0]["HUM_USER_NAME"].ToString();
                Response.Cookies["COMM_OUTREACH"]["CookiesExpiryon"] = CookieDateTime.ToString("dd-MM-yyyy hh:mm:ss tt");
                Response.Cookies["COMM_OUTREACH"].Expires = CookieDateTime;
                // Response.Redirect("TESTPG.aspx");
                if (ESOUSROLE.Value == "MEODEO")
                {

                    Response.Redirect("GovernmentDOC_Upload.aspx");
                }
                else if (ESOUSROLE.Value== "MEOSTU")
                {
                    Response.Redirect("Primaryscr.aspx");
                }
                else
                {
                    Response.Redirect("GovernmentDOC_Upload.aspx");
                }

            }
            else
            {
                Response.Cookies["COMM_OUTREACH"]["CookieAlive"] = "False";
                Response.Cookies["COMM_OUTREACH"].Expires = DateTime.Now.AddDays(-1);
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script type='text/javascript'>swal({title: 'Opps!',text: 'Invaild Password Please Try Again!',icon: 'warning',buttons: false })</script>");
                inputEmail.Text = "";
                inputPassword.Text = "";
                inputPassword.Focus();
            }
        }
        else
        {
            Response.Cookies["COMM_OUTREACH"]["CookieAlive"] = "False";
            Response.Cookies["COMM_OUTREACH"].Expires = DateTime.Now.AddDays(-1);
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script type='text/javascript'>swal({title: 'Opps!',text: 'Invaild User Please Try Again!',icon: 'warning',buttons: false })</script>");
            inputEmail.Text = "";
            inputPassword.Text = "";
            inputEmail.Focus();
        }
    }

    private void Convertpassword()
    {
        string userpwd = inputPassword.Text;
        var result = string.Empty;
        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] message = UE.GetBytes(userpwd);
        SHA512Managed hashString = new SHA512Managed();
        string hexNumber = "";
        byte[] hashValue = hashString.ComputeHash(message);
        foreach (byte x in hashValue) { hexNumber += string.Format("{0:x2}", x); }
        string hashData = BitConverter.ToString(hashValue);
        hashpass.Value = hashData;
    }
}