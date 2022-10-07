/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace Cyber 
{
	public class Global : System.Web.HttpApplication
	{
		private System.ComponentModel.IContainer components = null;
		public Global()
		{
			InitializeComponent();
		}
		//---------------------------------------------------------------------------------------------
		protected void Application_Start(Object sender, EventArgs e)
		{
		}
		//---------------------------------------------------------------------------------------------
		protected void Session_Start(Object sender, EventArgs e)
		{
			if(Session["username"] == null)
			{
				Session["username"] = "";
			}
			if(Session["EmailSqlAddress"] == null)
			{
				Session["EmailSqlAddress"] = "";
			}
			/*if(Session["BlogSqlAddress"] == null)
			{
				Session["BlogSqlAddress"] = "";
			}*/
			if(Session["CurrentBoxSize"] == null)
			{
				Session["CurrentBoxSize"] = 0;
			}
			/*if(Session["acknowledge"] == null)
			{
				Session["acknowledge"] = "";
			}*/
			if(Session["iAccounts"] == null)
			{
				Session["iAccounts"] = "";
			}
			/*if(Session["iBlog"] == null)
			{
				Session["iBlog"] = "";
			}*/
			if(Session["iEmail"] == null)
			{
				Session["iEmail"] = "";
			}
		}
		//---------------------------------------------------------------------------------------------
		protected void Application_End(Object sender, EventArgs e)
		{
		}
		//---------------------------------------------------------------------------------------------
		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
		}
		//---------------------------------------------------------------------------------------------
		protected void Application_EndRequest(Object sender, EventArgs e)
		{
		}
		//---------------------------------------------------------------------------------------------
		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
		}
		//---------------------------------------------------------------------------------------------
		protected void Application_Error(Object sender, EventArgs e)
		{
		}
		//---------------------------------------------------------------------------------------------
		protected void Session_End(Object sender, EventArgs e)
		{
		}
		//---------------------------------------------------------------------------------------------
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

