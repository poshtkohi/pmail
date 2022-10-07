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
	public class Authorization : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox code;
		protected System.Web.UI.WebControls.Button submit;
		protected System.Web.UI.WebControls.Label AuthorizationError;
		protected System.Web.UI.WebControls.TextBox cert;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		//-----------------------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
		}
		//-----------------------------------------------------------------------------------------------
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
		//-----------------------------------------------------------------------------------------------
		private void submit_Click(object sender, System.EventArgs e)
		{
			if(this.code.Text == null || this.code.Text == "")
			{
				this.AuthorizationError.Text = ".کد دانشجویی خالی است*";
				this.AuthorizationError.Visible = true;
				return ;
			}
			if(this.cert.Text == null || this.cert.Text == "")
			{
				this.AuthorizationError.Text = ".شماره شناسنامه خالی است*";
				this.AuthorizationError.Visible = true;
				return ;
			}
			int code = 0, cert = 0;
			try
			{
				code = Convert.ToInt32(this.code.Text);
			}
			catch
			{
				this.AuthorizationError.Text = ".کد دانشجویی باید به صورت عددی باشد*";
				this.AuthorizationError.Visible = true;
				return ;
			}
			try
			{
				cert = Convert.ToInt32(this.cert.Text);
			}
			catch
			{
				this.AuthorizationError.Text = ".شماره شناسنامه باید به صورت عددی باشد*";
				this.AuthorizationError.Visible = true;
				return ;
			}
			Database db = new Database(constants.SqlServerAddressAccountsDb, constants.AccountsDbName,
				constants.AccountsDbUsername, constants.AccountsDbPassword);
			int result = db.AuthorizationPage(code , cert, this);
			db.Dispose();
			if(result == -1)
			{
				this.code.Text = "";
				this.cert.Text = "";
				this.AuthorizationError.Text = ".کد دانشجویی یا شماره شناسنامه اشتباه است*";
				this.AuthorizationError.Visible = true;
				return ;
			}
			if(result == -3)
			{
				this.Response.Redirect("exception.aspx", true);
				return ;
			}
			this.Response.Redirect("/SignUp.aspx", true);
			return ;
		}
		//-----------------------------------------------------------------------------------------------
	}
}
