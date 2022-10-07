/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;

namespace pmail
{
	//---------------------------------------------------------------------------
	public class SignUp : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox username;
		protected System.Web.UI.WebControls.TextBox password;
		protected System.Web.UI.WebControls.Label EmailError;
		protected System.Web.UI.WebControls.TextBox email;
		protected System.Web.UI.WebControls.Label UsernameError;
		protected System.Web.UI.WebControls.Label PasswordError;
		protected System.Web.UI.WebControls.Label ConfirmPasswordError;
		protected System.Web.UI.WebControls.TextBox ConfirmPassword;
		protected System.Web.UI.WebControls.RadioButton male;
		protected System.Web.UI.WebControls.RadioButton female;
		protected System.Web.UI.WebControls.Label CountryError;
		protected System.Web.UI.WebControls.DropDownList country;
		protected System.Web.UI.WebControls.Label ZipCodeError;
		protected System.Web.UI.WebControls.TextBox ZipCode;
		protected System.Web.UI.WebControls.DropDownList SecurityQuestion;
		protected System.Web.UI.WebControls.Label AnswerError;
		protected System.Web.UI.WebControls.TextBox answer;
		protected System.Web.UI.WebControls.Label BirthDateError;
		protected System.Web.UI.WebControls.DropDownList year;
		protected System.Web.UI.WebControls.DropDownList day;
		protected System.Web.UI.WebControls.DropDownList month;
		protected System.Web.UI.WebControls.Label PhoneError;
		protected System.Web.UI.WebControls.TextBox phone;
		protected System.Web.UI.WebControls.DropDownList profession;
		protected System.Web.UI.WebControls.Button submit;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	    //---------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			/*if(this.Session["Authorized"] == null || !(bool)this.Session["Authorized"])
			{
				this.Response.Redirect("/SignIn.aspx", true);
				return ;
			}*/
		}
		//---------------------------------------------------------------------------
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.submit.Click += new System.EventHandler(this.submit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		//---------------------------------------------------------------------------
		private void submit_Click(object sender, System.EventArgs e)
		{
			if(this.email.Text != null && this.email.Text != "")
			{
				if(this.email.Text.Length > 50)
				{
					this.EmailError.Text = ".ایمیل باید کمتر از 50 حرف باشد*";
					this.EmailError.Visible = true;
					return ;
				}
				Regex rex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
				if(!rex.IsMatch(this.email.Text))
				{
					this.EmailError.Text = ".ایمیل نا معتبر است*";
					this.EmailError.Visible = true;
					return ;
				}
				this.EmailError.Visible = false;
			}
			if(this.username.Text == null || this.username.Text == "")
			{
				this.UsernameError.Text = ".کلمه کاربری خالی است*";
				this.UsernameError.Visible = true;
				return ;
			}
			else
			{
				if(this.username.Text.Length > 50)
				{
					this.UsernameError.Text = ".کلمه کاربری باید کمتر از 50 حرف باشد*";
					this.UsernameError.Visible = true;
					return ;
				}
				this.UsernameError.Visible = false;
			}
			if(this.password.Text == null || this.password.Text == "")
			{
				this.PasswordError.Text = ".کلمه عبور خالی است*";
				this.PasswordError.Visible = true;
				return ;
			}
			else
			{
				if(this.password.Text.Length < 6)
				{
					this.PasswordError.Text = ".کلمه عبور باید حداقل 6 حرف باشد*";
					this.PasswordError.Visible = true;
					return ;
				}
				if(this.password.Text.Length > 50)
				{
					this.PasswordError.Text = ".کلمه کاربری باید کمتر از 50 حرف باشد*";
					this.PasswordError.Visible = true;
					return ;
				}
				this.PasswordError.Visible = false;
			}
			if(this.password.Text != this.ConfirmPassword.Text)
			{
				this.ConfirmPasswordError.Text = ".کلمه عبور وتکرار آن برابر نیستند*";
				this.ConfirmPasswordError.Visible = true;
				return ;
			}
			this.ConfirmPasswordError.Visible = false;
			if(this.Request.Form["country"] == "none")
			{
				this.CountryError.Text = ".کشورتان را انتخاب کنید*";
				this.CountryError.Visible = true;
				return;
			}
			else this.CountryError.Visible = false;
			if(this.ZipCode.Text == null || this.ZipCode.Text == "")
			{
				this.ZipCodeError.Text = ".کد پستی خالی است*";
				this.ZipCodeError.Visible = true;
				return ;
			}
			else
			{
				if(this.ZipCode.Text.Length > 50)
				{
					this.ZipCodeError.Text = ".کد پستی باید کمتر از 50 حرف باشد*";
					this.ZipCodeError.Visible = true;
					return ;
				}
				this.ZipCodeError.Visible = false;
			}
			if(this.answer.Text == null || this.answer.Text == "")
			{
				this.AnswerError.Text = ".جواب خالی است*";
				this.AnswerError.Visible = true;
				return ;
			}
			else
			{
				if(this.answer.Text.Length > 50)
				{
					this.AnswerError.Text = ".جواب باید کمتر از 50 حرف باشد*";
					this.AnswerError.Visible = true;
					return ;
				}
				this.AnswerError.Visible = false;
			}
			if(this.Request.Form["year"] == "none" || this.Request.Form["day"] == "none" || this.Request.Form["month"] == "none")
			{
				this.BirthDateError.Text = ".تاریخ تولدتان را انتخاب کنید*";
				this.BirthDateError.Visible = true;
				return;
			}
			else this.BirthDateError.Visible = false;
			if(this.phone.Text != null && this.phone.Text != "")
			{
				if(this.phone.Text.Length > 50)
				{
					this.PhoneError.Text = ".تلفن باید کمتر از 50 حرف باشد*";
					this.PhoneError.Visible = true;
					return ;
				}
			}
			else this.PhoneError.Visible = false;
			DateTime BirthDate = new DateTime(Convert.ToInt32(this.Request.Form["year"]), 
				Convert.ToInt32(this.Request.Form["month"]), Convert.ToInt32(this.Request.Form["day"]));
			bool sex = true; // true meaning male
			if(this.Request.Form["sex"] == "female")
				sex = false;
			SignUpInfo info = new SignUpInfo("", "",
				this.Request.Form["username"].Trim(), this.Request.Form["password"].Trim(), this.email.Text,
				BirthDate, sex, this.Request.Form["ZipCode"].Trim(), this.Request.Form["country"].Trim(), 
				this.Request.Form["answer"].Trim(), this.phone.Text , this.Request.Form["profession"].Trim(),
				Convert.ToInt32(this.Request.Form["SecurityQuestion"].Trim()));
			Database db = new Database(constants.SqlServerAddressAccountsDb, constants.AccountsDbName,
				constants.AccountsDbUsername, constants.AccountsDbPassword);
			int result = db.SignUpPage(info);
			db.Dispose();
			if(result == -1)
			{
				this.username.Text = "";
				this.UsernameError.Text = ".نام کاربری وجود دارد*";
				this.UsernameError.Visible = true;
				return ;
			}
			if(result == -3)
			{
				this.Response.Redirect("exception.aspx", true);
				return ;
			}
			this.Session["username"] = info.Username;
			this.Session["EmailSqlAddress"] = constants.SqlServerAddressAccountsDb;
			//this.Session["BlogSqlAddress"] = "";
			//+++++++++++++++++++Email Activation++++++++++++++++++++++++
			Cyber.email.EmailDatabase dbb = new Cyber.email.EmailDatabase(constants.SqlServerAddressAccountsDb, constants.AccountsDbName,
				constants.AccountsDbUsername, constants.AccountsDbPassword);
			result = dbb.ActivateEmail((string)this.Session["username"], Cyber.email.constants.SqlServerAddressUsersMailDb
				,1024*1000*10); //10 meg storage. here we must consider distributed sql servers address
			if(result == -3)
			{
				this.Response.Redirect("exception.aspx?error=SQL Server", true);
				return ;
			}
			dbb =  new Cyber.email.EmailDatabase(Cyber.email.constants.SqlServerAddressUsersMailDb, Cyber.email.constants.UsersMailDbName,
				Cyber.email.constants.UsersMailDbUsername, Cyber.email.constants.UsersMailDbPassword);
			result = dbb.CreateTableUsersEmail((string)this.Session["username"]);//here we must consider distributed sql servers address
			if(result == -3)
			{
				this.Response.Redirect("exception.aspx?error=SQL Server", true);
				return ;
			}
			this.Session["EmailSqlAddress"] = Cyber.email.constants.SqlServerAddressUsersMailDb;//here we must consider distributed sql servers address
			//here we must inform SMTP Server from our new user
			//---- here we inform MessageQueuingServer from new user---
			try
			{
				Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				IPHostEntry hostInfo = Dns.Resolve(Cyber.email.constants.MessageQueuingServerSMTPAddress);
				IPEndPoint hostEndPoint = new IPEndPoint(hostInfo.AddressList[0], Cyber.email.constants.MessageQueuingServerSMTPPort);
				sock.Connect(hostEndPoint);
				if(sock.Connected)
				{
					byte[] buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(String.Format("<?xml version=\"1.0\" encoding=\"us-ascii\"?><message Password=\"{0}\" SqlEmailAddress=\"{1}\" Username=\"{2}\" MaxBoxSize=\"{3}\"/>", Cyber.email.constants.MessageQueuingPassword, Cyber.email.constants.SqlServerAddressUsersMailDb, (string)this.Session["username"], 1024 * 1000 * 5));
					sock.Send(buffer, 0, buffer.Length, 0);
				}
				sock.Close();
				this.Response.Redirect("/email/fa/", true);
				return ;
			}
			catch
			{
				this.Response.Redirect("/email/fa/", true);
				return ;
			}
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		}
		//---------------------------------------------------------------------------
	}
}
