using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class MasterPage : System.Web.UI.MasterPage
{
	SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConnectionIT"].ToString());
	protected void Page_Load(object sender, EventArgs e)
	{
		

		if (!IsPostBack) { Checkcookie(); }
		else if (IsPostBack) { }
		else { }
		Getuser();



	}

	private void Getuser()
	{
		string currentuserid = Request.Cookies["COMM_OUTREACH"]["USERHMSID"];

		string Q2 = " select top 1  HUM_USER_NAME as empusername from AS_USER_MASTER ";
		//Q2 += " inner join HR_EMPLOYEE_MASTER on EEM_EMP_NUM=HUM_EMP_NUM ";
		//Q2 += " inner join GA_PARAMETER_MASTER on GPM_PARAMETER_CD=EEM_EMP_TITLE ";
		Q2 += " WHERE HUM_USER_ID ='"+ currentuserid + "' ";
		con.Open();
		SqlDataAdapter adapt = new SqlDataAdapter(Q2, con);
		DataSet dt = new DataSet();
		adapt.Fill(dt);
		con.Close();
		if (dt.Tables[0].Rows.Count >= 1)
		{
			string Username = dt.Tables[0].Rows[0]["empusername"].ToString();
			usr_name.Text = Username;

		}

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
				string currentcookiealive = Request.Cookies["COMM_OUTREACH"]["CookieAlive"];
				string currentusername = Request.Cookies["COMM_OUTREACH"]["USERNAME"];
				string currentexpire = Request.Cookies["COMM_OUTREACH"]["CookiesExpiryon"];
				
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
				//Response.Redirect("/UTSApplication/Login.aspx");
			}
		}
		else
		{
			//Response.Redirect("/UTSApplication/Login.aspx");
		}
	}


}
