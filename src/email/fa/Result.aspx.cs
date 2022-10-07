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

namespace Cyber.email.fa
{
	public class Result : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		//--------------------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				if(this.Session["username"] == null || (string)this.Session["username"] == "")
				{
					this.Response.Redirect("/SignIn.aspx?i=signouted", true);
					return ;
				}
				/*if(this.Session["EmailSqlAddress"] == null || (string)this.Session["EmailSqlAddress"] == "")
				{
					this.Response.Redirect("ActivateEmail.aspx", true);
					return ;
				}*/
				string i = this.Request.QueryString["i"];
				if(i != null && i == "signout")
				{
					this.Session.Abandon();
					this.Response.Redirect("/", true);
					return ;
				}
				return ;
			}
		}
		//--------------------------------------------------------------------------------------------
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
