/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.IO;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Collections;
using System.Net;
using System.Xml;
using System.Net.Sockets;
using Cyber.email.HtmlComponents;
using Mime;
using Mime.ASCII;
using Mime.MimeParser;

namespace Cyber.email
{
	public class EmailDatabase
	{
		//---------------------------------------------------------------------------
		private string userAdmin;
		private string passAdmin;
		private string server;
		private string dbName;
		private string ConnectString;
		private Component component = new Component();
		private bool disposed = false;
		//---------------------------------------------------------------------------
		public EmailDatabase(string server, string dbName,string userAdmin, string passAdmin)
		{
			this.server = server;
			this.dbName = dbName;
			this.userAdmin = userAdmin;
			this.passAdmin = passAdmin;
			this.ConnectString="database=" + this.dbName + ";server=" + this.server +
				";User Id=" + this.userAdmin + ";Password=" + this.passAdmin +";Connect Timeout=30;";
		}
		//---------------------------------------------------------------------------
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		//---------------------------------------------------------------------------
		private void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				if(disposing)
				{
					component.Dispose();
				} 
			}
			disposed = true;
		}
		//---------------------------------------------------------------------------
		~EmailDatabase()      
		{
			Dispose(false);
		}
		//---------------------------------------------------------------------------
		private string mark(string input)
		{
			return "'" + input +"'";
		}
		//---------------------------------------------------------------------------
		public int ActivateEmail(string username, string EmailSqlAddress, int MaxBoxSize)
		{
			/*try
			{*/
				SqlConnection connection = new SqlConnection(this.ConnectString);
				connection.Open();
				SqlCommand command = connection.CreateCommand();
				command.Connection = connection;
				command.CommandText = String.Format("INSERT INTO {0} (username,EmailSqlAddress,MaxBoxSize,DateActivate) VALUES(@username,@EmailSqlAddress,@MaxBoxSize,@DateActivate);UPDATE {1} SET EmailSqlAddress='{2}' WHERE username=@username", constants.MailAccountsTableName, constants.AccountsTableName, EmailSqlAddress);
				SqlParameter UsernameParam = new SqlParameter("@username", SqlDbType.VarChar);
				SqlParameter DateActivateParam = new SqlParameter("@DateActivate", SqlDbType.DateTime);
				SqlParameter MaxBoxSizeParam = new SqlParameter("@MaxBoxSize", SqlDbType.Int);
				SqlParameter EmailSqlAddressParam = new SqlParameter("@EmailSqlAddress", SqlDbType.VarChar);
				UsernameParam.Value = username;
				DateActivateParam.Value = DateTime.Now;
				MaxBoxSizeParam.Value = MaxBoxSize;
				EmailSqlAddressParam.Value = EmailSqlAddress;
				command.Parameters.Add(UsernameParam);
				command.Parameters.Add(DateActivateParam);
				command.Parameters.Add(MaxBoxSizeParam);
				command.Parameters.Add(EmailSqlAddressParam);
				command.ExecuteNonQuery();
				connection.Close();
				command.Dispose();
				return 0;
			/*}
			catch
			{
				return -3;
			}*/
		}
		//--------------------------------
		public int CreateTableUsersEmail(string username)
		{
			/*try
			{*/
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.Connection = connection;
			command.CommandText = "CREATE TABLE " + username + " (i int IDENTITY(1,1) PRIMARY KEY,date DATETIME NOT NULL,size INT NOT NULL, "+
					"box CHAR(1) NOT NULL default('0'),MailFrom NVARCHAR(512) NOT NULL,subject NVARCHAR(512) default(''),attachment BIT DEFAULT(0),visited BIT DEFAULT(0) NOT NULL,infos NTEXT DEFAULT('') NOT NULL,MimeData IMAGE);"+
					"GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON " + username + " TO [" + constants.UsersMailDbUsername+ "]";
			command.ExecuteNonQuery();
			return 0;
			/*}
			catch
			{
				return -3;
			}*/
		}
		//---------------------------------------------------------------------------
		public int ShowBoxContent(string username, string BoxName, Panel PanelMain, Page page, string Show)
		{
			//try{  
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			SqlTransaction transaction = connection.BeginTransaction();
			command.Connection = connection;
			command.Transaction = transaction;
			int box = GetIntBoxNameFrom(BoxName);
			if(Show == "none" || Show == "all")
				command.CommandText = String.Format("SELECT count(*) FROM {0} WHERE box='{1}'", username, box);
			if(Show == "unread")
				command.CommandText = String.Format("SELECT count(*) FROM {0} WHERE box='{1}' AND visited=0", username, box);
			SqlDataReader read = command.ExecuteReader();
			int NumEmails = 0;
			if(read.Read())
			{
				NumEmails = read.GetInt32(0);
			}
			if(NumEmails > 0)
			{
				PanelMain.Visible = true;
				Table TableTopTexts = (Table) PanelMain.FindControl("TableTopTexts");
				//TableTopTexts.FindControl("SelectAllColumn").Controls.Add(PanelMain.FindControl("SelectAll"));
				TableTopTexts.FindControl("FromColumn").Controls.Add(PanelMain.FindControl("PanelFrom"));
				TableTopTexts.FindControl("SubjectColumn").Controls.Add(PanelMain.FindControl("PanelSubject"));
				TableTopTexts.FindControl("DateColumn").Controls.Add(PanelMain.FindControl("PanelDate"));
				TableTopTexts.FindControl("SizeColumn").Controls.Add(PanelMain.FindControl("PanelSize"));
				PanelMain.Controls.Add(page.FindControl("PanelTasks"));
				if(BoxName == "Inbox")
				{
					page.FindControl("InboxLabel").Visible = false;
					page.FindControl("inboxx").Visible = false;
				}
				else
				{
					page.FindControl(BoxName + "Label").Visible = false;
					page.FindControl(BoxName.ToLower()).Visible = false;
				}
				/*      0   1   2      3        4         5       6   */
				/*command.CommandText = String.Format("SELECT i,date,size,MailFrom,subject,attachment,visited FROM {0} WHERE box" + 
					"='{1}'", username, box);*/
				if(Show == "none")
					command.CommandText = String.Format("SELECT TOP 16 i,date,size,MailFrom,subject,attachment,visited FROM {0} WHERE box" + 
						"='{1}' ORDER BY date DESC", username, box);
				if(Show == "all")
					command.CommandText = String.Format("SELECT i,date,size,MailFrom,subject,attachment,visited FROM {0} WHERE box" + 
						"='{1}' ORDER BY date DESC", username, box);
				if(Show == "unread")
					command.CommandText = String.Format("SELECT TOP 16 i,date,size,MailFrom,subject,attachment,visited FROM {0} WHERE box" + 
						"='{1}' AND visited=0 ORDER BY date DESC", username, box);
				read.Close();
				read = command.ExecuteReader();
				ArrayList infos = new ArrayList();
				while(read.Read())
				{
					EmailDataClass temp = new EmailDataClass();
					temp.ID = read.GetInt32(0);
					temp.DateRecieve = read.GetDateTime(1);
					temp.Size = read.GetInt32(2);
					temp.MailFrom = read.GetString(3);
					if(!read.IsDBNull(4))
						temp.Subject = read.GetString(4);
					temp.HasAttachment = read.GetBoolean(5);
					temp.Visited = read.GetBoolean(6);
					infos.Add(temp);
				}
				read.Close();
				transaction.Commit();
				connection.Close();
				command.Dispose();
				int numcells = 6;
				string SelectAllInput = "[";
				if(Show != "all")
				{
					int a = NumEmails / 16;
					int b = NumEmails % 16;
					if(a == 0 || (a == 1 && b == 0))
					{
						Panel PanelNext = (Panel)page.FindControl("PanelNext");
						PanelNext.Visible = false;
					}
					else
					{
						EmailDataClass temp = (EmailDataClass)infos[infos.Count - 1];
						HyperLink HyperLinkNext = (HyperLink)page.FindControl("HyperLinkNext");
						HyperLink HyperLinkPrevious = (HyperLink)page.FindControl("HyperLinkPrevious");
						HyperLinkPrevious.Enabled = false;                 /*    NumEmails_ID_Where -> Where-> Next=1, Previous=0   */
						HyperLinkNext.NavigateUrl = String.Format("?ShowFolder={0}&p={1}_{2}_1_2&Show={3}", BoxName, NumEmails, temp.ID, Show);
						//PanelNext.Visible = true;
					}
				}
				if(Show == "all")
				{
					Panel PanelNext = (Panel)page.FindControl("PanelNext");
					PanelNext.Visible = false;
				}
				for(int j = 0 ; j < infos.Count ; j++)
				{   
					EmailDataClass temp = (EmailDataClass)infos[j];
					string css = "Unvisited";
					if(temp.Visited)
						css = "visited";
					if(j == infos.Count - 1)
					{
						SelectAllInput += String.Format("[MSG{0},'{1}']", temp.ID, css.ToLower());
					}
					else
					{
						SelectAllInput += String.Format("[MSG{0},'{1}'],", temp.ID, css.ToLower());
					}
					TableRow r = new TableRow();
					r.ID =  "Td" + temp.ID.ToString();
					if(temp.Visited)
						r.Style.Add("background", "#dbeaf5");
					else
						r.Style.Add("background", "#fff7e5");
					for (int i = 0 ; i < numcells ; i++) 
					{
						TableCell c = new TableCell();
						//c.ID = "Td" + temp.ID.ToString();
						c.CssClass = css;
						if(i == 0) //checkbox field
						{
							CyberCheckBox checkbox = new CyberCheckBox();
							//checkbox.Value = "true";
							if(temp.Visited)
								checkbox.Event = String.Format("CheckBoxClick(MSG{0},'{1}');", temp.ID, "visited");
							else
								checkbox.Event = String.Format("CheckBoxClick(MSG{0},'{1}');", temp.ID, "unvisited");
							checkbox.ID = "MSG" + temp.ID.ToString();
							c.Controls.Add(checkbox);
						}
						if(i == 1) //attachment field 
						{
							if(temp.HasAttachment)
							{
								Image img = new Image();
								img.ImageUrl = "/email/images/attach.gif";
								c.Controls.Add(img);
							}
						}
						if(i == 2) //From field
						{
							string from = temp.MailFrom;
							Regex rex = new Regex(@"<|>");
							from = rex.Replace(from, "");
							CyberHyperLink hlink = new CyberHyperLink();
							hlink.Text = from;
							hlink.Target = "_self";
							hlink.Url = "ShowLetter.aspx?MID=" + temp.ID;
							c.Controls.Add(hlink);
						}
						if(i == 3) // Subject field
						{
							if(temp.Subject == null || temp.Subject == "")
								c.Controls.Add(new LiteralControl(("(None)")));
							else
								c.Controls.Add(new LiteralControl(temp.Subject));
						}
						if(i == 4) // Date field
						{
							c.Controls.Add(new LiteralControl(Calendar.GeorgianIntMonthToString(temp.DateRecieve.Month) + " " + temp.DateRecieve.Day));
						}
						if(i == 5) // Size field
						{
							int size = temp.Size / 1024;
							if(size == 0)
								c.Controls.Add(new LiteralControl(temp.Size + " Byte"));
							else
								c.Controls.Add(new LiteralControl(size + " KB"));
						}
						r.Cells.Add(c);
					}
					TableTopTexts.Rows.Add(r);
				}
				SelectAllInput += "]";
				CyberCheckBox SelectAll = new CyberCheckBox();
				SelectAll.Event = String.Format("SelectAllCheckBox({0});", SelectAllInput);
				SelectAll.ID = "SelectAllBoxes";
				TableTopTexts.FindControl("SelectAllColumn").Controls.Add(SelectAll);
				return 0;
			}
			else
			{
				read.Close();
				connection.Close();
				CyberEmptyBox emptybox = new CyberEmptyBox();
				emptybox.Box = GetBoxNameFromInt(box);
				PanelMain.Controls.Remove(PanelMain.FindControl("PanelFrom"));
				PanelMain.Controls.Remove(PanelMain.FindControl("PanelDate"));
				PanelMain.Controls.Remove(PanelMain.FindControl("PanelSubject"));
				PanelMain.Controls.Remove(PanelMain.FindControl("PanelSize"));
				PanelMain.Controls.Remove(PanelMain.FindControl("PanelFrom"));
				PanelMain.Controls.Remove(PanelMain.FindControl("TableTopTexts"));
				PanelMain.Controls.Remove(PanelMain.FindControl("SelectAll"));
				PanelMain.Controls.Remove(PanelMain.FindControl("PanelTasks"));
				page.FindControl("PanelShow1").Visible = false;
				page.FindControl("PanelShow2").Visible = false;
				Table TableTopTexts = new Table();
				TableRow r = new TableRow();
				TableCell c = new TableCell();
				c.Controls.Add(emptybox);
				c.Height = 200;
				c.Width = 400;
				r.Cells.Add(c);
				r.VerticalAlign = VerticalAlign.Middle;
				TableTopTexts.HorizontalAlign = HorizontalAlign.Center;
				TableTopTexts.Rows.Add(r);
				PanelMain.Controls.Add(TableTopTexts);
				return 0;
			}
		}
		//---------------------------------------------------------------------------
		public int ShowNext(string username, string BoxName, Panel PanelMain, Page page, int NumEmails, int ID, int Where, int WhichPage, string Show)
		{
			if(Show == "all")
				return ShowBoxContent(username, BoxName, PanelMain, page, Show);
			//try{  
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.Connection = connection;
			int box = GetIntBoxNameFrom(BoxName);
			PanelMain.Visible = true;
			Table TableTopTexts = (Table) PanelMain.FindControl("TableTopTexts");
			TableTopTexts.FindControl("FromColumn").Controls.Add(PanelMain.FindControl("PanelFrom"));
			TableTopTexts.FindControl("SubjectColumn").Controls.Add(PanelMain.FindControl("PanelSubject"));
			TableTopTexts.FindControl("DateColumn").Controls.Add(PanelMain.FindControl("PanelDate"));
			TableTopTexts.FindControl("SizeColumn").Controls.Add(PanelMain.FindControl("PanelSize"));
			PanelMain.Controls.Add(page.FindControl("PanelTasks"));
			if(BoxName == "Inbox")
			{
				page.FindControl("InboxLabel").Visible = false;
				page.FindControl("inboxx").Visible = false;
			}
			else
			{
				page.FindControl(BoxName + "Label").Visible = false;
				page.FindControl(BoxName.ToLower()).Visible = false;
			}
			/*      0   1   2      3        4         5       6   */
			/*command.CommandText = String.Format("SELECT i,date,size,MailFrom,subject,attachment,visited FROM {0} WHERE box" + 
					"='{1}'", username, box);*/
			if(Where == 1)  // Next
			{
				if(Show == "none")
					command.CommandText = String.Format("SELECT TOP 16 i,date,size,MailFrom,subject,attachment,visited FROM {0} WHERE box" + 
					    "='{1}' AND i<{2} ORDER BY date DESC", username, box, ID);
				if(Show == "unread")
					command.CommandText = String.Format("SELECT TOP 16 i,date,size,MailFrom,subject,attachment,visited FROM {0} WHERE box" + 
						"='{1}' AND i<{2} AND visited=0 ORDER BY date DESC", username, box, ID);
			}
			if(Where == 0)  // Previous
			{
				if(Show == "none")
					command.CommandText = String.Format("SELECT TOP 16 i,date,size,MailFrom,subject,attachment,visited FROM {0} WHERE box" + 
					    "='{1}' AND i>={2} ORDER BY date DESC", username, box, ID);
				if(Show == "unread")
					command.CommandText = String.Format("SELECT TOP 16 i,date,size,MailFrom,subject,attachment,visited FROM {0} WHERE box" + 
						"='{1}' AND i>={2} AND visited=0 ORDER BY date DESC", username, box, ID);
			}
			SqlDataReader read = command.ExecuteReader();
			if(read.HasRows)
			{
				EmailDataClass temp;
				ArrayList infos = new ArrayList();
				while(read.Read())
				{
					temp = new EmailDataClass();
					temp.ID = read.GetInt32(0);
					temp.DateRecieve = read.GetDateTime(1);
					temp.Size = read.GetInt32(2);
					temp.MailFrom = read.GetString(3);
					if(!read.IsDBNull(4))
						temp.Subject = read.GetString(4);
					temp.HasAttachment = read.GetBoolean(5);
					temp.Visited = read.GetBoolean(6);
					infos.Add(temp);
				}
				read.Close();
				connection.Close();
				command.Dispose();
				int numcells = 6;
				string SelectAllInput = "[";
				int a = NumEmails / 16;
				int b = NumEmails % 16;
				temp = (EmailDataClass)infos[infos.Count - 1];
				HyperLink HyperLinkNext = (HyperLink)page.FindControl("HyperLinkNext");
				HyperLink HyperLinkPrevious = (HyperLink)page.FindControl("HyperLinkPrevious");
				/*    NumEmails_ID_Where_WhichPage       */
				if(b == 0)
				{
					if(WhichPage * 16 == NumEmails)
						HyperLinkNext.Enabled = false;
					else
					{
						HyperLinkNext.Enabled = true;
						HyperLinkNext.NavigateUrl = String.Format("?ShowFolder={0}&p={1}_{2}_1_{3}&Show={4}", BoxName, NumEmails, temp.ID, WhichPage + 1, Show);
					}
				}
				else
				{
					if(16 * WhichPage < NumEmails)
					{
						HyperLinkNext.Enabled = true;
						HyperLinkNext.NavigateUrl = String.Format("?ShowFolder={0}&p={1}_{2}_1_{3}&Show={4}", BoxName, NumEmails, temp.ID, WhichPage + 1, Show);
					}
					else
					{
						HyperLinkNext.Enabled = false;
					}
				}
				if(WhichPage == 1)
					HyperLinkPrevious.Enabled = false;
				else
				{
					HyperLinkPrevious.Enabled = true;
					HyperLinkPrevious.NavigateUrl = String.Format("?ShowFolder={0}&p={1}_{2}_0_{3}&Show={4}", BoxName, NumEmails, temp.ID, WhichPage - 1, Show);
				}
				for(int j = 0 ; j < infos.Count ; j++)
				{   
					temp = (EmailDataClass)infos[j];
					string css = "Unvisited";
					if(temp.Visited)
						css = "visited";
					if(j == infos.Count - 1)
					{
						SelectAllInput += String.Format("[MSG{0},'{1}']", temp.ID, css.ToLower());
					}
					else
					{
						SelectAllInput += String.Format("[MSG{0},'{1}'],", temp.ID, css.ToLower());
					}
					TableRow r = new TableRow();
					r.ID =  "Td" + temp.ID.ToString();
					if(temp.Visited)
						r.Style.Add("background", "#dbeaf5");
					else
						r.Style.Add("background", "#fff7e5");
					for (int i = 0 ; i < numcells ; i++) 
					{
						TableCell c = new TableCell();
						//c.ID = "Td" + temp.ID.ToString();
						c.CssClass = css;
						if(i == 0) //checkbox field
						{
							CyberCheckBox checkbox = new CyberCheckBox();
							//checkbox.Value = "true";
							if(temp.Visited)
								checkbox.Event = String.Format("CheckBoxClick(MSG{0},'{1}');", temp.ID, "visited");
							else
								checkbox.Event = String.Format("CheckBoxClick(MSG{0},'{1}');", temp.ID, "unvisited");
							checkbox.ID = "MSG" + temp.ID.ToString();
							c.Controls.Add(checkbox);
						}
						if(i == 1) //attachment field 
						{
							if(temp.HasAttachment)
							{
								Image img = new Image();
								img.ImageUrl = "/email/images/attach.gif";
								c.Controls.Add(img);
							}
						}
						if(i == 2) //From field
						{
							string from = temp.MailFrom;
							Regex rex = new Regex(@"<|>");
							from = rex.Replace(from, "");
							CyberHyperLink hlink = new CyberHyperLink();
							hlink.Text = from;
							hlink.Target = "_self";
							hlink.Url = "ShowLetter.aspx?MID=" + temp.ID;
							c.Controls.Add(hlink);
						}
						if(i == 3) // Subject field
						{
							if(temp.Subject == null || temp.Subject == "")
								c.Controls.Add(new LiteralControl(("(None)")));
							else
								c.Controls.Add(new LiteralControl(temp.Subject));
						}
						if(i == 4) // Date field
						{
							c.Controls.Add(new LiteralControl(Calendar.GeorgianIntMonthToString(temp.DateRecieve.Month) + " " + temp.DateRecieve.Day));
						}
						if(i == 5) // Size field
						{
							int size = temp.Size / 1024;
							if(size == 0)
								c.Controls.Add(new LiteralControl(temp.Size + " Byte"));
							else
								c.Controls.Add(new LiteralControl(size + " KB"));
						}
						r.Cells.Add(c);
					}
					TableTopTexts.Rows.Add(r);
				}
				SelectAllInput += "]";
				CyberCheckBox SelectAll = new CyberCheckBox();
				SelectAll.Event = String.Format("SelectAllCheckBox({0});", SelectAllInput);
				SelectAll.ID = "SelectAllBoxes";
				TableTopTexts.FindControl("SelectAllColumn").Controls.Add(SelectAll);
				return 0;
			}
			else
			{
				read.Close();
				connection.Close();
				command.Dispose();
				return ShowBoxContent(username, BoxName, PanelMain, page, Show);
			}
		}
		//---------------------------------------------------------------------------
		public int ShowBoxAddressBook(string username, string BoxName, Panel PanelMain, Page page, string Show)
		{
			//try{  
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			SqlTransaction transaction = connection.BeginTransaction();
			command.Connection = connection;
			command.Transaction = transaction;
			int box = GetIntBoxNameFrom(BoxName);
			if(Show == "none" || Show == "all")
				command.CommandText = String.Format("SELECT count(*) FROM {0} WHERE box='{1}'", username, box);
			SqlDataReader read = command.ExecuteReader();
			int NumEmails = 0;
			if(read.Read())
			{
				NumEmails = read.GetInt32(0);
			}
			if(NumEmails > 0)
			{
				PanelMain.Visible = true;
				Table TableTopTexts = (Table) PanelMain.FindControl("TableTopTexts");
				TableTopTexts.FindControl("FromColumn").Controls.Add(PanelMain.FindControl("PanelFrom"));
				TableTopTexts.FindControl("SubjectColumn").Controls.Add(PanelMain.FindControl("PanelSubject"));
				TableTopTexts.FindControl("DateColumn").Controls.Add(PanelMain.FindControl("PanelDate"));
				TableTopTexts.FindControl("SizeColumn").Controls.Add(PanelMain.FindControl("PanelSize"));
				PanelMain.Controls.Add(page.FindControl("PanelTasks"));
				/*      0   1   2      3        4         5       6   */
				/*command.CommandText = String.Format("SELECT i,date,size,MailFrom,subject,attachment,visited FROM {0} WHERE box" + 
					"='{1}'", username, box);*/
				if(Show == "none")
					command.CommandText = String.Format("SELECT TOP 16 i,infos FROM {0} WHERE box" + 
						"='{1}' ORDER BY date DESC", username, box);
				if(Show == "all")
					command.CommandText = String.Format("SELECT i,infos FROM {0} WHERE box" + 
						"='{1}' ORDER BY date DESC", username, box);
				read.Close();
				read = command.ExecuteReader();
				ArrayList infos = new ArrayList();
				while(read.Read())
				{
					AddressBookDataClass temp = new AddressBookDataClass();
					temp.ID = read.GetInt32(0);
					temp.Infos = "<?xml version=\"1.0\" encoding=\"us-ascii\"?><Book>" + read.GetString(1) + "</Book>";
					infos.Add(temp);
				}
				read.Close();
				transaction.Commit();
				connection.Close();
				command.Dispose();
				string SelectAllInput = "[";
				if(Show != "all")
				{
					int a = NumEmails / 16;
					int b = NumEmails % 16;
					if(a == 0 || (a == 1 && b == 0))
					{
						Panel PanelNext = (Panel)page.FindControl("PanelNext");
						PanelNext.Visible = false;
					}
					else
					{
						AddressBookDataClass temp = (AddressBookDataClass)infos[infos.Count - 1];
						HyperLink HyperLinkNext = (HyperLink)page.FindControl("HyperLinkNext");
						HyperLink HyperLinkPrevious = (HyperLink)page.FindControl("HyperLinkPrevious");
						HyperLinkPrevious.Enabled = false;                 /*    NumEmails_ID_Where -> Where-> Next=1, Previous=0   */
						HyperLinkNext.NavigateUrl = String.Format("?ShowFolder={0}&p={1}_{2}_1_2&Show={3}", BoxName, NumEmails, temp.ID, Show);
						//PanelNext.Visible = true;
					}
				}
				if(Show == "all")
				{
					Panel PanelNext = (Panel)page.FindControl("PanelNext");
					PanelNext.Visible = false;
				}
				for(int j = 0 ; j < infos.Count ; j++)
				{   
					AddressBookDataClass temp = (AddressBookDataClass)infos[j];
					string css = "Unvisited";
					if(j == infos.Count - 1)
					{
						SelectAllInput += String.Format("[MSG{0},'{1}']", temp.ID, css.ToLower());
					}
					else
					{
						SelectAllInput += String.Format("[MSG{0},'{1}'],", temp.ID, css.ToLower());
					}
					TableRow r = new TableRow();
					r.ID =  "Td" + temp.ID.ToString();
					r.Style.Add("background", "#fff7e5");
					XmlTextReader readXml = new XmlTextReader(new StringReader(temp.Infos));
					while(readXml.Read())
					{
						if(readXml.NodeType == XmlNodeType.Element)
						{
							if(readXml.Name == "AddressBook")
							{
								//-----checkbox field-----
								TableCell c = new TableCell();
								c.CssClass = css;
								CyberCheckBox checkbox = new CyberCheckBox();
								checkbox.Event = String.Format("CheckBoxClick(MSG{0},'{1}');", temp.ID, "unvisited");
								checkbox.ID = "MSG" + temp.ID.ToString();
								c.Controls.Add(checkbox);
								r.Cells.Add(c);
								//-----Email field---------
								c = new TableCell();
								c.CssClass = css;
								readXml.MoveToAttribute("Email");
								c.Controls.Add(new LiteralControl(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(readXml.Value))));
								r.Cells.Add(c);
								//-----First Name field---
								c = new TableCell();
								c.CssClass = css;
								readXml.MoveToAttribute("FirstName");
								c.Controls.Add(new LiteralControl(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(readXml.Value))));
								r.Cells.Add(c);
								//-----Last Name field----
								c = new TableCell();
								c.CssClass = css;
								readXml.MoveToAttribute("LastName");
								c.Controls.Add(new LiteralControl(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(readXml.Value))));
								r.Cells.Add(c);
								//-----Phone field--------
								c = new TableCell();
								c.CssClass = css;
								readXml.MoveToAttribute("Phone");
								c.Controls.Add(new LiteralControl(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(readXml.Value))));
								r.Cells.Add(c);
								//-------------------------
							}
						}
					}
					readXml.Close();
					readXml = null;
					TableTopTexts.Rows.Add(r);
				}
				SelectAllInput += "]";
				CyberCheckBox SelectAll = new CyberCheckBox();
				SelectAll.Event = String.Format("SelectAllCheckBox({0});", SelectAllInput);
				SelectAll.ID = "SelectAllBoxes";
				TableTopTexts.FindControl("SelectAllColumn").Controls.Add(SelectAll);
				return 0;
			}
			else
			{
				read.Close();
				connection.Close();
				CyberEmptyBox emptybox = new CyberEmptyBox();
				emptybox.Box = GetBoxNameFromInt(box);
				PanelMain.Controls.Remove(PanelMain.FindControl("PanelFrom"));
				PanelMain.Controls.Remove(PanelMain.FindControl("PanelDate"));
				PanelMain.Controls.Remove(PanelMain.FindControl("PanelSubject"));
				PanelMain.Controls.Remove(PanelMain.FindControl("PanelSize"));
				PanelMain.Controls.Remove(PanelMain.FindControl("PanelFrom"));
				PanelMain.Controls.Remove(PanelMain.FindControl("TableTopTexts"));
				PanelMain.Controls.Remove(PanelMain.FindControl("SelectAll"));
				PanelMain.Controls.Remove(PanelMain.FindControl("PanelTasks"));
				page.FindControl("PanelShow1").Visible = false;
				Table TableTopTexts = new Table();
				TableRow r = new TableRow();
				TableCell c = new TableCell();
				c.Controls.Add(emptybox);
				c.Height = 200;
				c.Width = 400;
				r.Cells.Add(c);
				r.VerticalAlign = VerticalAlign.Middle;
				TableTopTexts.HorizontalAlign = HorizontalAlign.Center;
				TableTopTexts.Rows.Add(r);
				PanelMain.Controls.Add(TableTopTexts);
				return 0;
			}
		}
		//---------------------------------------------------------------------------
		public int ShowAdressBookNext(string username, string BoxName, Panel PanelMain, Page page, int NumEmails, int ID, int Where, int WhichPage, string Show)
		{
			if(Show == "all")
				return ShowBoxAddressBook(username, BoxName, PanelMain, page, Show);
			//try{  
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.Connection = connection;
			int box = GetIntBoxNameFrom(BoxName);
			PanelMain.Visible = true;
			Table TableTopTexts = (Table) PanelMain.FindControl("TableTopTexts");
			TableTopTexts.FindControl("FromColumn").Controls.Add(PanelMain.FindControl("PanelFrom"));
			TableTopTexts.FindControl("SubjectColumn").Controls.Add(PanelMain.FindControl("PanelSubject"));
			TableTopTexts.FindControl("DateColumn").Controls.Add(PanelMain.FindControl("PanelDate"));
			TableTopTexts.FindControl("SizeColumn").Controls.Add(PanelMain.FindControl("PanelSize"));
			PanelMain.Controls.Add(page.FindControl("PanelTasks"));
			/*      0   1   2      3        4         5       6   */
			/*command.CommandText = String.Format("SELECT i,date,size,MailFrom,subject,attachment,visited FROM {0} WHERE box" + 
					"='{1}'", username, box);*/
			if(Where == 1)  // Next
			{
				if(Show == "none")
					command.CommandText = String.Format("SELECT TOP 16 i,infos FROM {0} WHERE box" + 
						"='{1}' AND i<{2} ORDER BY date DESC", username, box, ID);
			}
			if(Where == 0)  // Previous
			{
				if(Show == "none")
					command.CommandText = String.Format("SELECT TOP 16 i,infos FROM {0} WHERE box" + 
						"='{1}' AND i>={2} ORDER BY date DESC", username, box, ID);
			}
			SqlDataReader read = command.ExecuteReader();
			if(read.HasRows)
			{
				AddressBookDataClass temp;
				ArrayList infos = new ArrayList();
				while(read.Read())
				{
					temp = new AddressBookDataClass();
					temp.ID = read.GetInt32(0);
					temp.Infos = "<?xml version=\"1.0\" encoding=\"us-ascii\"?><Book>" + read.GetString(1) + "</Book>";
					page.Response.Write(temp.Infos);
					infos.Add(temp);
				}
				read.Close();
				connection.Close();
				command.Dispose();
				string SelectAllInput = "[";
				int a = NumEmails / 16;
				int b = NumEmails % 16;
				temp = (AddressBookDataClass)infos[infos.Count - 1];
				HyperLink HyperLinkNext = (HyperLink)page.FindControl("HyperLinkNext");
				HyperLink HyperLinkPrevious = (HyperLink)page.FindControl("HyperLinkPrevious");
				/*    NumEmails_ID_Where_WhichPage       */
				if(b == 0)
				{
					if(WhichPage * 16 == NumEmails)
						HyperLinkNext.Enabled = false;
					else
					{
						HyperLinkNext.Enabled = true;
						HyperLinkNext.NavigateUrl = String.Format("?ShowFolder={0}&p={1}_{2}_1_{3}&Show={4}", BoxName, NumEmails, temp.ID, WhichPage + 1, Show);
					}
				}
				else
				{
					if(16 * WhichPage < NumEmails)
					{
						HyperLinkNext.Enabled = true;
						HyperLinkNext.NavigateUrl = String.Format("?ShowFolder={0}&p={1}_{2}_1_{3}&Show={4}", BoxName, NumEmails, temp.ID, WhichPage + 1, Show);
					}
					else
					{
						HyperLinkNext.Enabled = false;
					}
				}
				if(WhichPage == 1)
					HyperLinkPrevious.Enabled = false;
				else
				{
					HyperLinkPrevious.Enabled = true;
					HyperLinkPrevious.NavigateUrl = String.Format("?ShowFolder={0}&p={1}_{2}_0_{3}&Show={4}", BoxName, NumEmails, temp.ID, WhichPage - 1, Show);
				}
				for(int j = 0 ; j < infos.Count ; j++)
				{   
					temp = (AddressBookDataClass)infos[j];
					string css = "Unvisited";
					if(j == infos.Count - 1)
					{
						SelectAllInput += String.Format("[MSG{0},'{1}']", temp.ID, css.ToLower());
					}
					else
					{
						SelectAllInput += String.Format("[MSG{0},'{1}'],", temp.ID, css.ToLower());
					}
					TableRow r = new TableRow();
					r.ID =  "Td" + temp.ID.ToString();
					r.Style.Add("background", "#fff7e5");
					XmlTextReader readXml = new XmlTextReader(new StringReader(temp.Infos));
					while(readXml.Read())
					{
						if(readXml.NodeType == XmlNodeType.Element)
						{
							if(readXml.Name == "AddressBook")
							{
								//-----checkbox field-----
								TableCell c = new TableCell();
								c.CssClass = css;
								CyberCheckBox checkbox = new CyberCheckBox();
								checkbox.Event = String.Format("CheckBoxClick(MSG{0},'{1}');", temp.ID, "unvisited");
								checkbox.ID = "MSG" + temp.ID.ToString();
								c.Controls.Add(checkbox);
								r.Cells.Add(c);
								//-----Email field---------
								c = new TableCell();
								c.CssClass = css;
								readXml.MoveToAttribute("Email");
								c.Controls.Add(new LiteralControl(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(readXml.Value))));
								r.Cells.Add(c);
								//-----First Name field---
								c = new TableCell();
								c.CssClass = css;
								readXml.MoveToAttribute("FirstName");
								c.Controls.Add(new LiteralControl(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(readXml.Value))));
								r.Cells.Add(c);
								//-----Last Name field----
								c = new TableCell();
								c.CssClass = css;
								readXml.MoveToAttribute("LastName");
								c.Controls.Add(new LiteralControl(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(readXml.Value))));
								r.Cells.Add(c);
								//-----Phone field--------
								c = new TableCell();
								c.CssClass = css;
								readXml.MoveToAttribute("Phone");
								c.Controls.Add(new LiteralControl(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(readXml.Value))));
								r.Cells.Add(c);
								//-------------------------
							}
						}
					}
					readXml.Close();
					readXml = null;
					TableTopTexts.Rows.Add(r);
				}
				SelectAllInput += "]";
				CyberCheckBox SelectAll = new CyberCheckBox();
				SelectAll.Event = String.Format("SelectAllCheckBox({0});", SelectAllInput);
				SelectAll.ID = "SelectAllBoxes";
				TableTopTexts.FindControl("SelectAllColumn").Controls.Add(SelectAll);
				return 0;
			}
			else
			{
				read.Close();
				connection.Close();
				command.Dispose();
				return ShowBoxAddressBook(username, BoxName, PanelMain, page, Show);
			}
		}
		//---------------------------------------------------------------------------
		public int MoveToBox(string username, string BoxName, Hashtable MSG)
		{
			//try{
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			SqlTransaction transaction = connection.BeginTransaction();
			command.Connection = connection;
			int box = GetIntBoxNameFrom(BoxName);
			command.Transaction = transaction;
			IEnumerator ie  = MSG.Keys.GetEnumerator();
			while(ie.MoveNext())
			{
				string msg = (string) ie.Current;
				command.CommandText = String.Format("UPDATE {0} SET box='{1}' WHERE i='{2}'", username, box, msg);
				command.ExecuteNonQuery();
			}
			transaction.Commit();
			connection.Close();
			command.Dispose();
			return 0;
		}
		//---------------------------------------------------------------------------
		public int DeleteFromBox(string username, Hashtable MSG)
		{
			/*try
			{*/
				IEnumerator ie  = MSG.Keys.GetEnumerator();
			    string query = ""; 
				while(ie.MoveNext())
				{
					string msg = (string) ie.Current;
					query += String.Format("DELETE FROM {0} WHERE i={1};", username, msg);
				}
			    SqlConnection connection = new SqlConnection(this.ConnectString);
			    connection.Open();
			    SqlCommand command = connection.CreateCommand();
			    command.Connection = connection;
			    command.CommandText = query;
				command.ExecuteNonQuery();
			    connection.Close();
				command.Dispose();
				return 0;
			/*}
			catch
			{
				return -3;
			}*/
		}
		//---------------------------------------------------------------------------
		public int ShowLetter(string username, int MID, Panel PanelMain, Page page)
		{
			//try{
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			SqlTransaction transaction = connection.BeginTransaction();
			command.Connection = connection;
			command.Transaction = transaction;
			                                    /*       0     1      2       3         4        5      6  */
			command.CommandText = String.Format("SELECT date,size,MailFrom,subject,attachment,visited,infos  FROM {0} WHERE i='{1}'", username, MID);
			SqlDataReader read = command.ExecuteReader();
			if(read.Read())
			{
				EmailDataClass info = new EmailDataClass();
				info.ID = MID;
				info.DateRecieve = read.GetDateTime(0);
				info.Size = read.GetInt32(1);
				info.MailFrom = read.GetString(2);
				info.Subject = read.GetString(3);
				if(info.Subject == null || info.Subject == "")
					info.Subject = "(None)";
				info.HasAttachment = read.GetBoolean(4);
				info.Visited = read.GetBoolean(5);
				info.Infos = read.GetString(6);
				if(info.Subject == null)
				{
					read.Close();
					transaction.Commit();
					connection.Close(); // if the user accesses randomly, thus we redirect him to InboxFolder
					page.Response.Redirect("?ShowFolder=Inbox");
					return 0;
				}
				read.Close();
				if(!info.Visited)
				{
					command.CommandText = String.Format("UPDATE {0} SET visited='1' WHERE i='{1}'", username, info.ID);
					command.ExecuteNonQuery();
				}
				Table TableTopTexts = (Table) PanelMain.FindControl("TableTopTexts");
				//------Date------------
				TableCell Date_1 = (TableCell) TableTopTexts.FindControl("DateRow").FindControl("Date_1");
				Date_1.Text = Calendar.CompleteStringTime(info.DateRecieve);
				//------MailFrom--------
				// we must replace < or > tags in MailFrom with &lt;gt; till we can show it in HTML borwser
				TableCell MailFrom_1 = (TableCell) TableTopTexts.FindControl("EmailFromRow").FindControl("MailFrom_1");
				Regex rex1 = new Regex("<");
				Regex rex2 = new Regex(">");
				MailFrom_1.Text = rex1.Replace(info.MailFrom, "&lt;");
				MailFrom_1.Text = rex2.Replace(MailFrom_1.Text, "&gt;");
				//------Subject---------
				TableCell Subject_1 = (TableCell) TableTopTexts.FindControl("SubjectRow").FindControl("Subject_1");
				if(info.HasAttachment)
				{
					Image img = new Image();
				    img.ID = "ImageAttachment";
					img.ImageUrl = "/email/images/attach.gif";
					Subject_1.Controls.Add(img);
				}
				Label SubjectLabel = new Label();
				SubjectLabel.Text = info.Subject;
				Subject_1.Controls.Add(SubjectLabel);
				//---XmlSummary data---
				XmlSummary xml = new XmlSummary(info.Infos);
				//------To-------------
				TableCell To_1 = (TableCell) TableTopTexts.FindControl("ToRow").FindControl("To_1");
				To_1.Text = rex1.Replace(xml.To, "&lt;");
				To_1.Text = rex2.Replace(To_1.Text, "&gt;");
				//---------------------
				// this section find text data in email
				if(xml.Texts != null)
				{
					for(int i = 0 ; i < xml.Texts.Length ; i++)
					{
						command.CommandText = String.Format("DECLARE @ptr varbinary(16) SELECT @ptr = textptr(MimeData) FROM {0} WHERE i={1} READTEXT {0}.MimeData @ptr {2} {3}", username, info.ID, xml.Texts[i].Start, xml.Texts[i].End - xml.Texts[i].Start);
						read = command.ExecuteReader();
						read.Read();
						xml.Texts[i].Source = new AsciiString((byte[])read.GetValue(0));
						read.Close();
					}
				}
				transaction.Commit();
				connection.Close();
				//---------------------
				CyberEmailContentShower hmb = new CyberEmailContentShower();
				hmb.Attachments = xml.Attachments;
				hmb.Texts = xml.Texts;
				hmb.MID = info.ID;
				PanelMain.Controls.Add(hmb);
				return 0;
			}
			else
			{
				read.Close();
				transaction.Commit();
				connection.Close();
				page.Response.Redirect("?ShowFolder=Inbox");
			    return 0;
			}
		}
		//---------------------------------------------------------------------------
		public int AttachmentDownload(string username, int MID, string position, Page page)
		{
			/*try
			{*/
			int p = position.IndexOf('_');
			if(p <= 0)
				return -1;
			int start = 0, end = 0;
			try
			{
				start = Convert.ToInt32(position.Substring(0, p));
				end = Convert.ToInt32(position.Substring(p + 1));
			}
			catch
			{
				return -1;
			}
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			SqlTransaction transaction = connection.BeginTransaction();
			command.Connection = connection;
			command.Transaction = transaction;
			command.CommandText = String.Format("SELECT infos FROM {0} WHERE i='{1}'", username, MID);
			SqlDataReader read = command.ExecuteReader();
			if(read.Read())
			{
				XmlSummary xml = new XmlSummary(read.GetString(0));
				read.Close();
				if(xml.Attachments == null)
				{
					transaction.Commit();
					connection.Close();
					return -1;
				}
				Attachment attachment = null;
				for(int i = 0 ; i < xml.Attachments.Length ; i++)
					if(xml.Attachments[i].Start == start)
						if(xml.Attachments[i].End == end)
						{
							attachment = xml.Attachments[i];
							break;
						}
				if(attachment == null)
				{
					transaction.Commit();
					connection.Close();
					return -1;
				}
				page.Response.ContentType = attachment.ContentType.ToUTF8String();
				page.Response.AppendHeader("Content-Disposition"," attachment; filename=\"" + attachment.Name + "\"");
				command.CommandText = String.Format("DECLARE @ptr varbinary(16) SELECT @ptr = textptr(MimeData) FROM {0} WHERE i={1} READTEXT {0}.MimeData @ptr {2} {3}", username, MID, attachment.Start, attachment.End - attachment.Start);
				read = command.ExecuteReader();
				read.Read();
				attachment.Source = new AsciiString((byte[])read.GetValue(0));
				byte[] buffer = attachment.GetDecodedSource();
				page.Response.OutputStream.Write(buffer, 0, buffer.Length);
				page.Response.End();
				this.Dispose();
				return 0;
				/*int j = 0;
				while(true)
				{
					int value = fs.ReadByte();
					if(value == -1 || fs.Position == end)
						break;
					if(value != '\r' || value != '\n')
					{
						buffer[j] = (byte) value;
						if(j == 3)
						{
							j = 0;
							page.Response.OutputStream.Write(buffer, 0, buffer.Length);
						}
						else 
							j++;
					}
				}*/
			}
			else
			{
				read.Close();
				connection.Close();
				return -1;
			}
			//}
			/*catch
			{
				return -3;
			}*/
		}
		//---------------------------------------------------------------------------
		public int SaveMailToQueueTable(string username, AsciiString MimeData, string To, string Cc, string Bcc)
		{
			/*try
			{*/
				SqlConnection connection = new SqlConnection(this.ConnectString);
				connection.Open();
				SqlCommand command = connection.CreateCommand();
				command.Connection = connection;
			    string MsgID = RandomString.Generate(24); 
				command.CommandText = String.Format("INSERT INTO {0} (MsgID,[From],[To],Cc,Bcc,RecieveDate,MimeData) VALUES(@MsgID,@From,@To,@Cc,@Bcc,@RecieveDate,@MimeData)", constants.QueueTableName);
				SqlParameter MsgIDParam = new SqlParameter("@MsgID", SqlDbType.VarChar);
			    SqlParameter FromParam = new SqlParameter("@From", SqlDbType.VarChar);
				SqlParameter ToParam = new SqlParameter("@To", SqlDbType.VarChar);
				SqlParameter CcParam = new SqlParameter("@Cc", SqlDbType.VarChar);
				SqlParameter BccParam = new SqlParameter("@Bcc", SqlDbType.VarChar);
				SqlParameter RecieveDateParam = new SqlParameter("@RecieveDate", SqlDbType.DateTime);
				SqlParameter MimeDataParam = new SqlParameter("@MimeData", SqlDbType.Image);
			    MsgIDParam.Value = MsgID;
				FromParam.Value = username + "@" + constants.MailDomain;
			    if(Cc == null)
					Cc = "";
			    if(Bcc == null)
					Bcc = "";
				ToParam.Value = To;
				CcParam.Value = Cc;
				BccParam.Value = Bcc;
				RecieveDateParam.Value = DateTime.Now;
				MimeDataParam.Value = MimeData.BaseStream;
			    command.Parameters.Add(MsgIDParam);
				command.Parameters.Add(FromParam);
				command.Parameters.Add(ToParam);
				command.Parameters.Add(CcParam);
				command.Parameters.Add(BccParam);
				command.Parameters.Add(RecieveDateParam);
				command.Parameters.Add(MimeDataParam);
				command.ExecuteNonQuery();
				connection.Close();
				command.Dispose();
			    //---- here we inform MessageQueuingServer from new message---
			    try
			    {
				   Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				   IPHostEntry hostInfo = Dns.Resolve(constants.MessageQueuingServerMailSenderAddress);
				   IPEndPoint hostEndPoint = new IPEndPoint(hostInfo.AddressList[0], constants.MessageQueuingServerMailSenderPort);
				   sock.Connect(hostEndPoint);
				   if(sock.Connected)
				   {
					   byte[] buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(String.Format("<?xml version=\"1.0\" encoding=\"us-ascii\"?><message Password=\"{0}\" SqlQueueAddress=\"{1}\" MsgID=\"{2}\"/>", constants.MessageQueuingPassword, constants.SqlServerAddressComposeDb, MsgID));
					   sock.Send(buffer, 0, buffer.Length, 0);
				   }
				   sock.Close();
				   return 0;
			    }
			    catch
			    {
				   return 0;
			    }
			    //------------------------------------------------------------
			/*}
			catch
			{
				return -3;
			}*/
		}
		//---------------------------------------------------------------------------
		public int SaveMailToSentFolder(string username, DateTime dateRev, MessageParser mp)
		{
			/*try
			 {*/
			bool HasAttachment = false;
			string infos = mp.GetXmlSummarize(ref HasAttachment);
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.Connection = connection;
			command.CommandText =  "INSERT INTO " + username + " (date,box,MailFrom,subject,size,attachment,infos,MimeData) VALUES(@date,@box,@MailFrom,@subject,@size,@attachment,@infos,@MimeData)";
			SqlParameter DateParam = new SqlParameter("@date", SqlDbType.DateTime);
			SqlParameter BoxParam = new SqlParameter("@box", SqlDbType.Char);
			SqlParameter MailFromParam = new SqlParameter("@MailFrom", SqlDbType.NVarChar);
			SqlParameter SubjectParam = new SqlParameter("@subject", SqlDbType.NVarChar);
			SqlParameter SizeParam = new SqlParameter("@size", SqlDbType.Int);
			SqlParameter AttachmentParam = new SqlParameter("@attachment", SqlDbType.Bit);
			SqlParameter InfosParam = new SqlParameter("@infos", SqlDbType.NText);
			SqlParameter MimeDataParam = new SqlParameter("@MimeData", SqlDbType.Image);
			DateParam.Value = dateRev;
			BoxParam.Value = '2';
			MailFromParam.Value = username + "@" + constants.MailDomain;
			if(mp.Subject.Length <= 512)
				SubjectParam.Value = mp.Subject.ToUTF8String();
			else
				SubjectParam.Value = mp.Subject.Substring(0, 512);
			SizeParam.Value = mp.Source.Length;
			if(HasAttachment)
				AttachmentParam.Value = 1;
			else
				AttachmentParam.Value = 0;
			InfosParam.Value = infos;
			MimeDataParam.Value = mp.Source.BaseStream;
			MimeDataParam.Size = mp.Source.Length;
			command.Parameters.Add(DateParam);
			command.Parameters.Add(BoxParam);
			command.Parameters.Add(MailFromParam);
			command.Parameters.Add(SubjectParam);
			command.Parameters.Add(SizeParam);
			command.Parameters.Add(AttachmentParam);
			command.Parameters.Add(InfosParam);
			command.Parameters.Add(MimeDataParam);
			command.ExecuteNonQuery();
			connection.Close();
			return 0;
			/*}
			 catch
			 {
				 return -3;
			 }*/
		}
		//---------------------------------------------------------------------------
		public int UpdateCurrentBoxSize(string username, int Messagelength)
		{
			/*try
			 {*/
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.Connection = connection;
			command.CommandText = String.Format("UPDATE {0} SET CurrentBoxSize=CurrentBoxSize+{1} WHERE username='{2}'", constants.MailAccountsTableName, Messagelength, username);
			command.ExecuteNonQuery();
			connection.Close();
			command.Dispose();
			return 0;
			/*}
			 catch
			 {
				 return -3;
			 }*/
		}
		//---------------------------------------------------------------------------
		public int AddressBookSave(string username, string xml)
		{
			/*try
			{*/
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.Connection = connection;
			command.CommandText =  "INSERT INTO " + username + " (date,box,MailFrom,subject,size,attachment,infos,MimeData) VALUES(@date,@box,@MailFrom,@subject,@size,@attachment,@infos,@MimeData)";
			SqlParameter DateParam = new SqlParameter("@date", SqlDbType.DateTime);
			SqlParameter BoxParam = new SqlParameter("@box", SqlDbType.Char);
			SqlParameter MailFromParam = new SqlParameter("@MailFrom", SqlDbType.NVarChar);
			SqlParameter SubjectParam = new SqlParameter("@subject", SqlDbType.NVarChar);
			SqlParameter SizeParam = new SqlParameter("@size", SqlDbType.Int);
			SqlParameter AttachmentParam = new SqlParameter("@attachment", SqlDbType.Bit);
			SqlParameter InfosParam = new SqlParameter("@infos", SqlDbType.NText);
			SqlParameter MimeDataParam = new SqlParameter("@MimeData", SqlDbType.Image);
			DateParam.Value = DateTime.Now;
			BoxParam.Value = '5';
			MailFromParam.Value = "";
			SizeParam.Value = xml.Length;
			AttachmentParam.Value = 0;
			InfosParam.Value = xml;
			MimeDataParam.Value = System.Text.ASCIIEncoding.ASCII.GetBytes("");
			SubjectParam.Value = "";
			command.Parameters.Add(DateParam);
			command.Parameters.Add(BoxParam);
			command.Parameters.Add(MailFromParam);
			command.Parameters.Add(SubjectParam);
			command.Parameters.Add(SizeParam);
			command.Parameters.Add(AttachmentParam);
			command.Parameters.Add(InfosParam);
			command.Parameters.Add(MimeDataParam);
			command.ExecuteNonQuery();
			connection.Close();
			return 0;
			/*{
			}
			 catch
			 {
				 return -3;
			 }*/
		}
		//---------------------------------------------------------------------------
		public int DeleteTrashBox(string username)
		{
			/*try
			{*/
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.Connection = connection;
			command.CommandText =  String.Format("DELETE FROM {0} WHERE box='4'", username);
			command.ExecuteNonQuery();
			connection.Close();
			command.Dispose();
			return 0;
			/*{
			}
			 catch
			 {
				 return -3;
			 }*/
		}
		//---------------------------------------------------------------------------
		private static string GetBoxNameFromInt(int id)
		{
			switch(id)
			{
				case 0:
					return "Inbox";
				case 1:
					return "Draft";
				case 2:
					return "Sent";
				case 3:
					return "Bulk";
				case 4:
					return "Trash";
				case 5:
					return "AddressBook";
				default: return "Inbox";
			}
		}
		//---------------------------------------------------------------------------
		private static int GetIntBoxNameFrom(string name)
		{
			switch(name)
			{
				case "Inbox":
					return 0;
				case "Draft":
					return 1;
				case "Sent":
					return 2;
				case "Bulk":
					return 3;
				case "Trash":
					return 4;
				case "AddressBook":
					return 5;
				default: return 0;
			}
		}
		//---------------------------------------------------------------------------
	}
}