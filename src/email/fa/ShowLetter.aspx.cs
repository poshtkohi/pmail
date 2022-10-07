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
	public class ShowLetter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Table TableTopTexts;
		protected System.Web.UI.WebControls.ImageButton trash;
		protected System.Web.UI.WebControls.Label TrashLabel;
		protected System.Web.UI.WebControls.ImageButton bulk;
		protected System.Web.UI.WebControls.Label BulkLabel;
		protected System.Web.UI.WebControls.ImageButton sent;
		protected System.Web.UI.WebControls.Label SentLabel;
		protected System.Web.UI.WebControls.ImageButton draft;
		protected System.Web.UI.WebControls.Label DraftLabel;
		protected System.Web.UI.WebControls.ImageButton inboxx;
		protected System.Web.UI.WebControls.Label InboxLabel;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Panel PanelTasks;
		protected System.Web.UI.WebControls.Panel PanelMain;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		//---------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack) 
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
				string mid = this.Request.QueryString["MID"];
				string position = this.Request.QueryString["p"];
				if(mid == null || mid == "")
				{
					this.Response.Redirect("?ShowFolder=Inbox");
					return ;
				}
				int MID = 0;
				try
				{
					MID = Convert.ToInt32(mid);
				}
				catch
				{
					this.Response.Redirect("?ShowFolder=Inbox");
					return ;
				}
				int result = 0;
				EmailDatabase db = new EmailDatabase(constants.SqlServerAddressUsersMailDb, constants.UsersMailDbName,
					constants.UsersMailDbUsername, constants.UsersMailDbPassword);
				if(position != null && position != "")
				{
					result = db.AttachmentDownload((string) Session["username"], MID , position, this);
					//if(result == -3)
					return ;
				}
				else
				{
					result = db.ShowLetter((string) Session["username"], MID , this.PanelMain, this);
					//if(result == -3)
					this.ViewState.Add("MSG_" + mid, null);
					return ;
				}
			}
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
			this.trash.Click += new System.Web.UI.ImageClickEventHandler(this.trash_Click);
			this.bulk.Click += new System.Web.UI.ImageClickEventHandler(this.bulk_Click);
			this.sent.Click += new System.Web.UI.ImageClickEventHandler(this.sent_Click);
			this.draft.Click += new System.Web.UI.ImageClickEventHandler(this.draft_Click);
			this.inboxx.Click += new System.Web.UI.ImageClickEventHandler(this.inboxx_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		//---------------------------------------------------------------------------
		private void draft_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int result = MoveToBox("Draft");
			//if(result == -3)
			this.Response.Redirect("/email/fa/?ShowFolder=Draft", true);
		}
		//---------------------------------------------------------------------------
		private void sent_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int result = MoveToBox("Sent");
			//if(result == -3)
			this.Response.Redirect("/email/fa/?ShowFolder=Sent", true);
		}
		//---------------------------------------------------------------------------
		private void bulk_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int result = MoveToBox("Bulk");
			//if(result == -3)
			this.Response.Redirect("/email/fa/?ShowFolder=Bulk", true);
		}
		//---------------------------------------------------------------------------
		private void trash_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int result = MoveToBox("Trash");
			//if(result == -3)
			this.Response.Redirect("/email/fa/?ShowFolder=Trash", true);
		}
		//---------------------------------------------------------------------------
		private void inboxx_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int result = MoveToBox("Inbox");
			//if(result == -3)
			this.Response.Redirect("/email/fa/?ShowFolder=Inbox", true);
		}
		//---------------------------------------------------------------------------
		private bool ValidateValidBox(ref string box)
		{
			if(box == null)
				return false;
			box = box.Trim();
			if(box != "" && (box == "Inbox" || box == "Draft" || box == "Bulk" || box == "Trash" || box == "Sent"))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		//---------------------------------------------------------------------------
		private int MoveToBox(string BoxName)
		{
			Hashtable htable = new Hashtable();
			System.Collections.IDictionaryEnumerator e = this.ViewState.GetEnumerator();
			while(e.MoveNext())
			{
				string MID = (string) e.Key;
				if(MID.IndexOf("MSG_") >= 0)
				{
					htable.Add(MID.Substring(4), null);
					break;
				}
			}
			int result = 0;
			EmailDatabase db = new EmailDatabase(constants.SqlServerAddressUsersMailDb, constants.UsersMailDbName,
				constants.UsersMailDbUsername, constants.UsersMailDbPassword);
			result = db.MoveToBox((string) Session["username"], BoxName, htable);
			return result;
		}
		//---------------------------------------------------------------------------
	}
}
