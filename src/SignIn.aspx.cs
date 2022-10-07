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

namespace pmail
{
	public class SignIn : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox username;
		protected System.Web.UI.WebControls.Button enter;
		protected System.Web.UI.WebControls.Label SigninError;
		protected System.Web.UI.WebControls.Label Signout;
		protected System.Web.UI.WebControls.TextBox password;
		//------------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				string i = this.Request.QueryString["i"];
				if(i != null && i == "signouted")
				{
					this.Signout.Visible = true;
					return ;
				}
			}
		}
		//------------------------------------------------------------------------------------
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
			this.enter.Click += new System.EventHandler(this.enter_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		//------------------------------------------------------------------------------------
		private void enter_Click(object sender, System.EventArgs e)
		{
			Database db = new Database(constants.SqlServerAddressAccountsDb, constants.AccountsDbName,
				constants.AccountsDbUsername, constants.AccountsDbPassword);
			int result = db.SignInPage(this.Request.Form["username"] + "", this.Request.Form["password"] + "", this);
			db.Dispose();
			if(result == -1)
			{
				this.username.Text = "";
				this.password.Text = "";
				this.SigninError.Text = ".کلمه کاربری یا کلمه عبور اشتباه است*";
				this.SigninError.Visible = true;
				return ;
			}
			if(result == -3)
			{
				this.Response.Redirect("exception.aspx", true);
				return ;
			}
			this.Response.Redirect("/email/fa/", true);
			return ;
		}
		//------------------------------------------------------------------------------------
	}
}
