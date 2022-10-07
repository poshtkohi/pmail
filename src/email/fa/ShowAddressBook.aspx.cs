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

namespace Cyber.email.fa
{
	public class ShowAddressBook : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox FirstName;
		protected System.Web.UI.WebControls.TextBox LastName;
		protected System.Web.UI.WebControls.TextBox Email;
		protected System.Web.UI.WebControls.TextBox Phone;
		protected System.Web.UI.WebControls.Button save;
		protected System.Web.UI.WebControls.Button cancel;
		protected System.Web.UI.WebControls.Label FirstNameError;
		protected System.Web.UI.WebControls.Label LastNameError;
		protected System.Web.UI.WebControls.Label EmailError;
		protected System.Web.UI.WebControls.Label PhoneError;
		protected System.Web.UI.WebControls.Image Image3;
		protected System.Web.UI.WebControls.Panel PanelSize;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Panel PanelDate;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Panel PanelSubject;
		protected System.Web.UI.WebControls.Image Attention;
		protected System.Web.UI.WebControls.Panel PanelFrom;
		protected System.Web.UI.WebControls.HyperLink HyperLinkNext;
		protected System.Web.UI.WebControls.HyperLink HyperLinkPrevious;
		protected System.Web.UI.WebControls.Panel PanelNext;
		protected System.Web.UI.WebControls.ImageButton delete;
		protected System.Web.UI.WebControls.Label DeleteLabel;
		protected System.Web.UI.WebControls.Panel PanelTasks;
		protected System.Web.UI.WebControls.Table TableTopTexts;
		protected System.Web.UI.WebControls.Panel PanelMain;
		protected System.Web.UI.WebControls.Panel PanelShow1;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		//---------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
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
				string ShowFolder = this.Request.QueryString["ShowFolder"];
				string Show = this.Request.QueryString["Show"];
				if(Show == null && Show == "")
					Show = "none";
				else if(Show != "unread" && Show != "none" && Show != "all")
					Show = "none";
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
					int result = db.ShowAdressBookNext((string) Session["username"], "AddressBook", this.PanelMain, this, NumEmails, ID, Where, WhichPage, Show);
					return ;
				}
			Continue:
				EmailDatabase db1 = new EmailDatabase(constants.SqlServerAddressUsersMailDb, constants.UsersMailDbName,
					constants.UsersMailDbUsername, constants.UsersMailDbPassword);
				int result1 = db1.ShowBoxAddressBook((string) Session["username"], "AddressBook" , this.PanelMain, this, Show);
				if(result1 == -3)
				{
					this.Response.Redirect("exception.aspx?error=SQL Server", true);
					return ;
				}
			}
		}
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
			this.delete.Click += new System.Web.UI.ImageClickEventHandler(this.delete_Click);
			this.save.Click += new System.EventHandler(this.save_Click);
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		//---------------------------------------------------------------------------------
		private void save_Click(object sender, System.EventArgs e)
		{
			if(this.FirstName.Text != null || this.FirstName.Text != "")
			{
				if(this.FirstName.Text.Length > 50)
				{
					this.FirstNameError.Text = ".نام بایستی کمتر از پنجاه کاراکتر باشد*";
					this.FirstNameError.Visible = true;
					return ;
				}
			}
			if(this.LastName.Text != null || this.LastName.Text != "")
			{
				if(this.LastName.Text.Length > 50)
				{
					this.LastNameError.Text = ".نام خانوادگی بایستی کمتر از پنجاه کاراکتر باشد*";
					this.LastNameError.Visible = true;
					this.PanelMain.Visible = false;
					return ;
				}
			}
			if(this.Email.Text == null || this.Email.Text == "")
			{
				this.EmailError.Text = ".آدرس ایمیل خالی است*";
				this.EmailError.Visible = true;
				this.PanelMain.Visible = false;
				return ;
			}
			if(this.Email.Text != null || this.Email.Text != "")
			{
				if(this.Email.Text.Length > 50)
				{
					this.EmailError.Text = ".آدرس ایمیل بایستی کمتر از پنجاه کاراکتر باشد*";
					this.Email.Visible = true;
					this.PanelMain.Visible = false;
					return ;
				}
				else
				{
					Regex rex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
					if(!rex.IsMatch(this.Email.Text))
					{
						this.EmailError.Text = ".حروف آدرس ایمیل نامعتبر است*";
						this.PanelMain.Visible = false;
						this.EmailError.Visible = true;
						return ;
					}
					else
					{
						this.EmailError.Visible = false;
					}
				}
			}
			if(this.Phone.Text != null || this.Phone.Text != "")
			{
				if(this.Phone.Text.Length > 50)
				{
					this.PhoneError.Text = ".تلفن بایستی کمتر از پنجاه کاراکتر باشد*";
					this.PhoneError.Visible = true;
					this.PanelMain.Visible = false;
					return ;
				}
			}
			byte[] FirstName = System.Text.UTF8Encoding.UTF8.GetBytes(this.FirstName.Text);
			byte[] LastName = System.Text.UTF8Encoding.UTF8.GetBytes(this.LastName.Text);
			byte[] Email = System.Text.UTF8Encoding.UTF8.GetBytes(this.Email.Text);
			byte[] Phone = System.Text.UTF8Encoding.UTF8.GetBytes(this.Phone.Text);
			string xml = String.Format("<AddressBook FirstName=\"{0}\" LastName=\"{1}\" Email=\"{2}\" Phone=\"{3}\"/>",
				Convert.ToBase64String(FirstName), Convert.ToBase64String(LastName),
				Convert.ToBase64String(Email), Convert.ToBase64String(Phone));
			FirstName = LastName = Email = Phone = null;
			EmailDatabase db = new EmailDatabase(constants.SqlServerAddressUsersMailDb, constants.UsersMailDbName,
				constants.UsersMailDbUsername, constants.UsersMailDbPassword);
			int result = db.AddressBookSave((string)this.Session["username"], xml);
			db.Dispose();
			if(result == -3)
			{
				this.Response.Redirect("exception.aspx?error=SQL Server", true);
				return ;
			}
			this.Response.Redirect("ShowAddressBook.aspx", true);
			return;
		}
		//---------------------------------------------------------------------------------
		private void cancel_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("ShowAddressBook.aspx", true);
			return;
		}
		//---------------------------------------------------------------------------------
		private void delete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Hashtable htable = FindMsgIDs();
			if(htable != null)
			{
				EmailDatabase db = new EmailDatabase(constants.SqlServerAddressUsersMailDb, constants.UsersMailDbName,
					constants.UsersMailDbUsername, constants.UsersMailDbPassword);
				int result = db.DeleteFromBox((string) Session["username"], htable);
				db.Dispose();
				if(result == -3)
				{
					this.Response.Redirect("exception.aspx", true);
					return ;
				}
				this.Response.Redirect("ShowAddressBook.aspx", true);
				return;
			}
			else
			{
				this.Response.Redirect("ShowAddressBook.aspx", true);
				return;
			}
		}
		//---------------------------------------------------------------------------------
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
		//---------------------------------------------------------------------------------
	}
}
