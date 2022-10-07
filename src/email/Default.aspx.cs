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
using System.Collections.Specialized;

namespace Cyber.email
{
	public class Default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Image Image3;
		protected System.Web.UI.WebControls.Panel PanelSize;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Panel PanelDate;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Panel PanelSubject;
		protected System.Web.UI.WebControls.Image Attention;
		protected System.Web.UI.WebControls.Panel PanelFrom;
		protected System.Web.UI.WebControls.Panel PanelTasks;
		protected System.Web.UI.WebControls.Table TableTopTexts;
		protected System.Web.UI.HtmlControls.HtmlForm inbox;
		protected System.Web.UI.WebControls.Label InboxLabel;
		protected System.Web.UI.WebControls.ImageButton inboxx;
		protected System.Web.UI.WebControls.Label DraftLabel;
		protected System.Web.UI.WebControls.ImageButton draft;
		protected System.Web.UI.WebControls.Label SentLabel;
		protected System.Web.UI.WebControls.ImageButton sent;
		protected System.Web.UI.WebControls.Label BulkLabel;
		protected System.Web.UI.WebControls.ImageButton bulk;
		protected System.Web.UI.WebControls.Label TrashLabel;
		protected System.Web.UI.WebControls.ImageButton trash;
		protected System.Web.UI.WebControls.HyperLink HyperLinkPrevious;
		protected System.Web.UI.WebControls.HyperLink HyperLinkNext;
		protected System.Web.UI.WebControls.Panel PanelNext;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Panel PanelShow2;
		protected System.Web.UI.WebControls.Panel PanelShow1;
		protected System.Web.UI.WebControls.Panel PanelMain;
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
				string EmptyTrash = this.Request.QueryString["EmptyTrash"];
				if(EmptyTrash != null && EmptyTrash != "" && EmptyTrash == "1")
				{
					EmailDatabase db1 = new EmailDatabase(constants.SqlServerAddressUsersMailDb, constants.UsersMailDbName,
						constants.UsersMailDbUsername, constants.UsersMailDbPassword);
					int result = db1.DeleteTrashBox((string) Session["username"]);
					db1.Dispose();
					if(result == -3)
					{
						this.Response.Redirect("exception.aspx", true);
						return ;
					}
					this.Response.Redirect("?ShowFolder=Trash", true);
					return ;
				}
				string ShowFolder = this.Request.QueryString["ShowFolder"];
				string Show = this.Request.QueryString["Show"];
				if(Show == null && Show == "")
					Show = "none";
				else if(Show != "unread" && Show != "none" && Show != "all")
					Show = "none";
				if(ValidateValidBox(ref ShowFolder))
				{
					string p = (string)this.Request.QueryString["p"];
					if(p != null && p != "")
					{
						int p1 = p.IndexOf('_');
						if(p1 < 0)
							goto Continue;
						int p2 = 0;
						try
						{
							p2 = p.IndexOf('_', p1 + 1);
						}
						catch
						{
							goto Continue;
						}
						if(p2 <= 0 || p1 > p2)
							goto Continue;
						int p3 = 0;
						try
						{
							p3 = p.IndexOf('_', p2 + 1);
						}
						catch
						{
							goto Continue;
						}
						if(p3 <= 0 || p2 > p3)
							goto Continue;
						int NumEmails = 0;
						int ID = 0;
						int Where = 0;
						int WhichPage = 0;
						try
						{
						    NumEmails = Convert.ToInt32(p.Substring(0, p1));
							ID = Convert.ToInt32(p.Substring(p1 + 1, p2 - p1 - 1));
							Where = Convert.ToInt32(p.Substring(p2 + 1, p3 - p2 - 1));
							WhichPage = Convert.ToInt32(p.Substring(p3 + 1));
							if(Where != 0 && Where != 1)
								goto Continue;
						}
						catch
						{
							goto Continue;
						}
						EmailDatabase db = new EmailDatabase(constants.SqlServerAddressUsersMailDb, constants.UsersMailDbName,
							constants.UsersMailDbUsername, constants.UsersMailDbPassword);
						int result = db.ShowNext((string) Session["username"], ShowFolder , this.PanelMain, this, NumEmails, ID, Where, WhichPage, Show);
						return ;
					}
				Continue:
					EmailDatabase db1 = new EmailDatabase(constants.SqlServerAddressUsersMailDb, constants.UsersMailDbName,
						constants.UsersMailDbUsername, constants.UsersMailDbPassword);
					int result2 = db1.ShowBoxContent((string) Session["username"], ShowFolder , this.PanelMain, this, Show);
					db1.Dispose();
					if(result2 == -3)
					{
						this.Response.Redirect("exception.aspx", true);
						return ;
					}
				}
				else
				{
					EmailDatabase db = new EmailDatabase(constants.SqlServerAddressUsersMailDb, constants.UsersMailDbName,
						constants.UsersMailDbUsername, constants.UsersMailDbPassword);
					int result = db.ShowBoxContent((string) Session["username"], "Inbox" , this.PanelMain, this, Show);
					db.Dispose();
					if(result == -3)
					{
						this.Response.Redirect("exception.aspx", true);
						return ;
					}
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
			this.inboxx.Click += new System.Web.UI.ImageClickEventHandler(this.inboxx_Click);
			this.draft.Click += new System.Web.UI.ImageClickEventHandler(this.draft_Click);
			this.sent.Click += new System.Web.UI.ImageClickEventHandler(this.sent_Click);
			this.bulk.Click += new System.Web.UI.ImageClickEventHandler(this.bulk_Click);
			this.trash.Click += new System.Web.UI.ImageClickEventHandler(this.trash_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		//---------------------------------------------------------------------------
		private void draft_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int result = MoveToBox("Draft");
			//if(result == -3)
			this.Response.Redirect("/email/?ShowFolder=Draft");
		}
		//---------------------------------------------------------------------------
		private void sent_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int result = MoveToBox("Sent");
			this.Response.Redirect("/email/?ShowFolder=Sent");
			//if(result == -3)
		}
		//---------------------------------------------------------------------------
		private void bulk_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int result = MoveToBox("Bulk");
			//if(result == -3)
			this.Response.Redirect("/email/?ShowFolder=Bulk");
		}
		//---------------------------------------------------------------------------
		private void trash_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int result = MoveToBox("Trash");
			//if(result == -3)
			this.Response.Redirect("/email/?ShowFolder=Trash");
		}
		//---------------------------------------------------------------------------
		private void inboxx_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int result = MoveToBox("Inbox");
			//if(result == -3)
			this.Response.Redirect("/email/?ShowFolder=Inbox");
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
			Hashtable htable = FindMsgIDs();
			int result = 0;
			if(htable != null)
			{
				EmailDatabase db = new EmailDatabase(constants.SqlServerAddressUsersMailDb, constants.UsersMailDbName,
					constants.UsersMailDbUsername, constants.UsersMailDbPassword);
				result = db.MoveToBox((string) Session["username"], BoxName, htable);
			}
			return result;
		}
		//---------------------------------------------------------------------------
		private Hashtable FindMsgIDs()
		{
			Hashtable htable = new Hashtable();
			bool find = false;
			for(int i = 0 ; i < this.Request.Form.Count ; i++)
			{
				string key = this.Request.Form.GetKey(i);
				if(key.IndexOf("MSG", 0, 3) >= 0)
				{
					htable.Add(key.Substring(3), null);
					find = true;
				}
			}
			if(find)
				return htable;
			else
			{
				htable = null;
				return null;
			}
		}
		//---------------------------------------------------------------------------
	}
}
