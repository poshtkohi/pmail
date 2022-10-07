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
using Mime;
using Mime.ASCII;

namespace Cyber.email.fa
{
	public class attachment : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label UploadError;
		protected System.Web.UI.WebControls.Button attach;
		protected System.Web.UI.WebControls.Button done;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.HtmlControls.HtmlInputFile file;
		//---------------------------------------------------------------------------------
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
				if(this.Session["AttachmentsSize"] == null)
					this.Response.Redirect("Compose.aspx", true);
				if((int)this.Session["AttachmentsSize"] > 1024 * 1000 * 1)
				{
					this.UploadError.Text = ".حجم کل فایل هایتان بیشتر از یک مگا بایت است*";
					this.file.Disabled = true;
					this.attach.Enabled = false;
					this.UploadError.Visible = true;
					return ;
				}
				this.UploadError.Visible = false;
				return ;
			}
		}
		//---------------------------------------------------------------------------------
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
			this.attach.Click += new System.EventHandler(this.attach_Click);
			this.done.Click += new System.EventHandler(this.done_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		//---------------------------------------------------------------------------------
		private void attach_Click(object sender, System.EventArgs e)
		{
			if(this.file.PostedFile != null)
			{
				if(this.file.PostedFile.ContentLength > 1024 * 1024 * 1 || (int)this.Session["AttachmentsSize"] > 1024 * 1000 * 1)
				{
					this.UploadError.Text = ".حجم کل فایل هایتان بیشتر از یک مگا بایت است*";
					this.file.Disabled = true;
					this.attach.Enabled = false;
					this.UploadError.Visible = true;
					return ;
				}
				if(this.file.PostedFile.FileName == null || this.file.PostedFile.FileName.Trim() == "")
				{
					this.UploadError.Text = ".باید یک فایل را از هارد دیسک انتخاب کنید*";
					this.UploadError.Visible = true;
					return ;
				}
				else
				{
					this.attach.Enabled = false;
					ArrayList al1 = (ArrayList) this.Session["attachments"];
					ArrayList al2 = (ArrayList) this.Session["AttachmentBuffers"];
					Attachment attachment = new Attachment();
					attachment.Start = 0;
					attachment.End = this.file.PostedFile.ContentLength;
					string filename = this.file.PostedFile.FileName;
					int p = filename.LastIndexOf(@"\");
					if(p > 0)
						filename = filename.Substring(p + 1);
					attachment.Filename = new AsciiString(filename);
					attachment.ContentType = new AsciiString(this.file.PostedFile.ContentType);
					attachment.Name = attachment.Filename;
					attachment.ContentTransferEncoding = Mime.Headrs.TransferEncoding.Base64;
					byte[] buffer = new byte[this.file.PostedFile.ContentLength];
					this.file.PostedFile.InputStream.Read(buffer, 0, buffer.Length);
					this.file.PostedFile.InputStream.Close();
					al1.Add(attachment.ToXmlBytes());
					al2.Add(buffer);
					this.Session["AttachmentsSize"] = (int)this.Session["AttachmentsSize"] + buffer.Length;
					this.Response.Redirect("Compose.aspx", true);
					return ;
				}
			}
			else
			{
				this.UploadError.Text = ".باید یک فایل را از هارد دیسک انتخاب کنید*";
				this.UploadError.Visible = true;
				return ;
			}
		}
		//---------------------------------------------------------------------------------
		private void done_Click(object sender, System.EventArgs e)
		{
			this.Response.Redirect("Compose.aspx", true);
		}
		//---------------------------------------------------------------------------------
	}
}
