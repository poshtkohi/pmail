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
using Mime.ASCII;
using Mime;
using Mime.MimeParser;
using Mime.MimeBuilder;
using FreeTextBoxControls;
using System.Text.RegularExpressions;

namespace Cyber.email.fa
{
	public class Compose : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Panel PanelShow2;
		protected System.Web.UI.WebControls.Panel PanelShow1;
		protected System.Web.UI.WebControls.ListBox ListBoxAttachments;
		protected System.Web.UI.WebControls.Button deattach;
		protected System.Web.UI.WebControls.Button attach;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.TextBox to;
		protected System.Web.UI.WebControls.TextBox cc;
		protected System.Web.UI.WebControls.TextBox bcc;
		protected System.Web.UI.WebControls.TextBox subject;
		protected System.Web.UI.WebControls.CheckBox IsSave;
		protected System.Web.UI.WebControls.Button send;
		protected System.Web.UI.WebControls.Button cancel;
		protected System.Web.UI.WebControls.Label ToError;
		protected System.Web.UI.WebControls.Label CcError;
		protected System.Web.UI.WebControls.Label BccError;
		protected System.Web.UI.WebControls.Label SubjectError;
		protected System.Web.UI.WebControls.Label MessageError;
		protected FreeTextBoxControls.FreeTextBox message;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		//------------------------------------------------------------------
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
				string ii = this.Request.QueryString["i"];
				if(ii != null && ii == "signout")
				{
					this.Session.Abandon();
					this.Response.Redirect("/", true);
					return ;
				}
				if(this.Request.Form["ListBoxAttachments"] ==  null || this.Request.Form["ListBoxAttachments"] ==  "")
				{
					ArrayList al = (ArrayList)this.Session["attachments"];
					if(al != null && al.Count != 0)
					{
						for(int i = 0 ; i < al.Count ; i++)
						{
							XmlSummary xml = new XmlSummary(new AsciiString((byte[])al[i]).ToString());
							this.ListBoxAttachments.Items.Add(new ListItem(xml.Attachments[0].Filename.ToUTF8String(), i.ToString()));
						}
					}
					else this.deattach.Enabled = false;
					if(this.Session["Content"] != null)
					{
						ArrayList all = (ArrayList) this.Session["Content"];
						this.to.Text = (string)all[0];
						this.cc.Text = (string)all[1];
						this.bcc.Text = (string)all[2];
						this.subject.Text = (string)all[3];
						this.message.Text = (string)all[4];
					}
				}
				else this.deattach.Enabled = false;
			}
		}
		//------------------------------------------------------------------
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
			this.deattach.Click += new System.EventHandler(this.deattach_Click);
			this.attach.Click += new System.EventHandler(this.attach_Click);
			this.send.Click += new System.EventHandler(this.send_Click);
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		//------------------------------------------------------------------
		private void attach_Click(object sender, System.EventArgs e)
		{
			if(this.Session["Content"] == null)
			{
				ArrayList al = new ArrayList();
				al.Add(this.Request.Form["to"]);         //0
				al.Add(this.Request.Form["cc"]);         //1
				al.Add(this.Request.Form["bcc"]);        //2
				al.Add(this.Request.Form["subject"]);    //3
				al.Add(this.Request.Form["message"]);    //4
				this.Session.Add("Content", al);
			}
			else
			{
				ArrayList al = (ArrayList) this.Session["Content"];
				al[0] = this.Request.Form["to"];         //0
				al[1] = this.Request.Form["cc"];         //1
				al[2] = this.Request.Form["bcc"];        //2
				al[3] = this.Request.Form["subject"];    //3
				al[4] = this.Request.Form["message"];    //4
			}
			if(this.Session["attachments"] == null)
			{
				this.Session.Add("attachments", new ArrayList());
				this.Session.Add("AttachmentBuffers", new ArrayList());
			}
			if(this.Session["AttachmentsSize"] == null)
				this.Session.Add("AttachmentsSize", 0);
			this.Response.Redirect("Attachment.aspx");
			return ;
		}
		//------------------------------------------------------------------
		private void deattach_Click(object sender, System.EventArgs e)
		{
			if(this.Session["attachments"] != null)
			{
				if( this.ListBoxAttachments.SelectedItem != null)
				{
					string id = this.ListBoxAttachments.SelectedItem.Value;
					if(id != null || id != "")
					{
						int index = Convert.ToInt32(id);
						ArrayList al1 = (ArrayList) this.Session["attachments"];
						ArrayList al2 = (ArrayList) this.Session["AttachmentBuffers"];
						XmlSummary xml = new XmlSummary(new AsciiString((byte[])al1[index]).ToString());
						int DecreasedLength = xml.Attachments[0].End - xml.Attachments[0].Start;
						this.Session["AttachmentsSize"] = (int)this.Session["AttachmentsSize"] - DecreasedLength;
						al1.RemoveAt(index);
						al2.RemoveAt(index);
						if(al1.Count == 0)
							this.deattach.Enabled = false;
						ArrayList al = (ArrayList) this.Session["Content"];
						al[0] = this.Request.Form["to"];         //0
						al[1] = this.Request.Form["cc"];         //1
						al[2] = this.Request.Form["bcc"];        //2
						al[3] = this.Request.Form["subject"];    //3
						al[4] = this.Request.Form["message"];    //4
						this.Response.Redirect("Compose.aspx", true);
						return ;
					}
				}
			}
			else
			{
				this.ListBoxAttachments.Items.Clear();
				this.deattach.Enabled = false;
			}
		}
		//------------------------------------------------------------------
		private void cancel_Click(object sender, System.EventArgs e)
		{
			this.Session.Remove("AttachmentBuffers");
			this.Session.Remove("Content");
			this.Session.Remove("attachments");
			this.Session.Remove("AttachmentsSize");
			this.Response.Redirect("?ShowFolder=Inbox", true);
		}
		//------------------------------------------------------------------
		private void send_Click(object sender, System.EventArgs e)
		{
			//-------validation----------------------
			string to = this.Request.Form["to"];
			if(to == null || to == "")
			{
				this.ToError.Text = ".خالی است To فیلد*";
				this.ToError.Visible = true;
				return ;
			}
			else
			{
				Regex rex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
				if(!rex.IsMatch(to))
				{
					this.ToError.Text = ".نامعتبر است To فیلد*";
					this.ToError.Visible = true;
					return ;
				}
				else
				{
					this.ToError.Visible = false;
				}
			}
			string cc = this.Request.Form["cc"];
			if(cc != null && cc != "")
			{
				Regex rex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
				if(!rex.IsMatch(cc))
				{
					this.CcError.Text = ".نامعتبر است Cc فیلد*";
					this.CcError.Visible = true;
					return ;
				}
				else
				{
					this.CcError.Visible = false;
				}
			}
			else
			{
				this.CcError.Visible = false;
			}
			if(cc == null) cc = "";
			string bcc = this.Request.Form["bcc"];
			if(bcc != null && bcc != "")
			{
				if(cc == null || cc == "")
				{
					this.CcError.Text = ".پر شود Cc اول باید فیلد*";
					this.CcError.Visible = true;
					this.bcc.Text = "";
					return ;
				}
				Regex rex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
				if(!rex.IsMatch(bcc))
				{
					this.BccError.Text = ".نامعتبر است Bcc فیلد*";
					this.BccError.Visible = true;
					return ;
				}
				else
				{
					this.BccError.Visible = false;
				}
			}
			else
			{
				this.CcError.Visible = false;
			}
			if(bcc == null) bcc = "";
			string subject = this.Request.Form["subject"];
			if(subject == null || subject == "")
			{
				this.SubjectError.Text = ".خالی است Subject فیلد*";
				this.SubjectError.Visible = true;
				return ;
			}
			else
			{
				this.SubjectError.Visible = false;
			}
			string message = this.Request.Form["message"];
			if(message == null || message == "")
			{
				this.MessageError.Text = ".متن پیام خالی است*";
				this.MessageError.Visible = true;
				return ;
			}
			else
			{
				if(message.Length > 500 * 1024)
				{
					this.MessageError.Text = ".پیام باید از پانصد کیلو بایت کمتر باشد*";
					this.MessageError.Visible = true;
					return ;
				}
				else 
				{
					this.MessageError.Visible = false;
				}
			}
			//---------------------------------------
			ArrayList al1 = (ArrayList) this.Session["attachments"];
			ArrayList al2 = (ArrayList) this.Session["AttachmentBuffers"];
			MessageBuilder mb = new MessageBuilder();
			if(al1 != null && al1.Count != 0)
			{
				for(int i = 0 ; i < al1.Count ; i++)
				{
					XmlSummary xml = new XmlSummary(new AsciiString((byte[])al1[i]).ToUTF8String());
					Attachment attachment = xml.Attachments[0];
					attachment.Source = Mime.EncoderDecoder.LineLengthCompatible(Mime.EncoderDecoder.Base64Encoder((byte[])al2[i]), 76);
					mb.AddAttachment(attachment);
				}
				this.Session.Remove("AttachmentBuffers");
				this.Session.Remove("Content");
				this.Session.Remove("attachments");
				this.Session.Remove("AttachmentsSize");
			}
			else this.Session.Remove("Content");
			Text text = new Text();
			message.Replace("\r\n.\r\n", "\r\n\r\n");
			//text.Source = Mime.EncoderDecoder.QuotedPrintableEncode(new AsciiString(message)); ///attention
			text.Source = Mime.EncoderDecoder.Base64Encoder(Mime.EncoderDecoder.StringToBinaryUTF8(message)); ///attention
			text.ContentTransferEncoding = Mime.Headrs.TransferEncoding.Base64;//.QuotedPrintable;
			text.Charset = Mime.Headrs.Charset.UTF8;
			text.Start = 0;
			text.End = text.Source.Length;
			text.ContentType = Mime.Headrs.ContentType.TextHtml;
			mb.AddText(text);
			mb.From = new AsciiString((string) Session["username"] + "@" + constants.MailDomain);
			mb.To = new AsciiString(to);
			mb.Cc = new AsciiString(cc);
			mb.Bcc = new AsciiString(bcc);
			subject.Replace("\r\n.\r\n", "\r\n\r\n");
			mb.Subject = new AsciiString(subject);
			mb.Date = DateTime.Now;
			AsciiString MimeData = mb.BuildMessageBody();
			EmailDatabase db = new EmailDatabase(constants.SqlServerAddressComposeDb, constants.ComposeDbName,
				constants.ComposeDbUsername, constants.ComposeDbPassword);
			int result = db.SaveMailToQueueTable((string) Session["username"], MimeData , to.Trim(), cc.Trim(), bcc.Trim());
			//if(result == -3)
			if(this.IsSave.Checked)
			{
				db = new EmailDatabase(constants.SqlServerAddressUsersMailDb, constants.UsersMailDbName,
					constants.UsersMailDbUsername, constants.UsersMailDbPassword);
				MessageParser mp = new MessageParser(MimeData);
				result = db.SaveMailToSentFolder((string) Session["username"], DateTime.Now, mp);
				//if(result == -3)
				db = new EmailDatabase(constants.SqlServerAddressAccountsDb, constants.AccountsDbName,
					constants.AccountsDbUsername, constants.AccountsDbPassword);
				result = db.UpdateCurrentBoxSize((string) Session["username"], mp.Source.Length);
				db.Dispose();
				//if(result == -3)
			}
			this.Response.Redirect("Result.aspx?i=SentToQueue", true);
		}
		//------------------------------------------------------------------
	}
}