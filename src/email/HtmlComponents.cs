/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;
using Mime;
using Mime.ASCII;

namespace Cyber.email.HtmlComponents
{
	//---------------------------------------------------------------------------------
	public class CyberEmailContentShower : Control
	{
		private int id ;
		private Text[] texts = null;
		private Attachment[] attachments = null;
		//---------------------
		public int MID
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}
		//---------------------
		public Text[] Texts
		{
			get
			{
				return this.texts;
			}
			set
			{
				this.texts = value;
			}
		}
		//---------------------
		public Attachment[] Attachments
		{
			get
			{
				return this.attachments;
			}
			set
			{
				this.attachments = value;
			}
		}
		//---------------------
		public CyberEmailContentShower()
		{
		}
		//---------------------
		private string BuildHtmlAttachments()
		{
			if(attachments == null)
				return null;
			else
			{
				string temp = "<br><br><br><br><table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">" +
					"<tr><td width=\"100%\" height=\"21\" valign=\"top\" bgcolor=\"#CC6600\"><b>" +
					"<font face=\"Tahoma\" color=\"#FFCC66\">Attachments</font></b></td></tr>";
				for(int i = 0 ; i < attachments.Length ; i++)
				{
					string src = null;
					if(attachments[i].ContentType == null)
						src = "unknown";
					else src = AttachmentType(attachments[i].ContentType.ToString());
					temp += String.Format("<tr><td height=\"20\" valign=\"top\" bgcolor=\"#FFCC66\" class=\"attachments\">" +
						"<font face=\"Arial\"><img src=\"/email/AttachType/{0}.gif\" width=\"21\" height=\"20\"><a href=\"?MID={1}&p={3}\">{2}"+
						"</div></a></font></td></tr>", src, MID, attachments[i].Filename, attachments[i].Start + "_" + attachments[i].End);
				}
				temp += "</table>";
				return temp;
			}
		}
		//---------------------
		private string AttachmentType(string ContentType)
		{
			if(ContentType == null || ContentType == "")
				return "unknown";
			if(ContentType.IndexOf("text/") >= 0)
				return "text";
			if(ContentType.IndexOf("image/") >= 0)
				return "image";
			if(ContentType.IndexOf("audio/") >= 0)
				return "audio";
			if(ContentType.IndexOf("movie/") >= 0)
				return "movie";
			if(ContentType.IndexOf("application/zip") >= 0)
				return "zip";
			if(ContentType.IndexOf("application/rar") >= 0)
				return "zip";
			if(ContentType.IndexOf("application/pdf") >= 0)
				return "pdf";
			if(ContentType.IndexOf("application/word") >= 0)
				return "word";
			else return "unknown";
		}
		//---------------------
		private string FindAppropriateHtmlBody()
		{
			if(this.texts == null)
				return "There are no text in your this message.";
			string buffer = null;
			for(int i = 0 ; i < this.texts.Length ; i++)
			{
				string temp = this.Texts[i].GetDecodedSource();
				if(this.Texts[i].ContentType != null && (AsciiString.Compare(this.Texts[i].ContentType, Mime.Headrs.ContentType.TextEnriched) == 0 || AsciiString.Compare(this.Texts[i].ContentType, Mime.Headrs.ContentType.TextHtml) == 0))
				{
					int p1 = temp.IndexOf("<body");
					if(p1 < 0)
					{
						p1 = temp.IndexOf("<BODY");
					}
					if(p1 < 0)
					{
						//buffer += "<table width=100% border=0 cellpadding=0 cellspacing=0>" + temp + "</table>";
						buffer += temp;
						continue;
					}
					int p2 = temp.IndexOf(">", p1);
					if(p2 < 0)
					{
						//buffer += "<table width=100% border=0 cellpadding=0 cellspacing=0>" + temp + "</table>";
						buffer += temp;
						continue;
					}
					p1 = p2;
					p2 = 0;
					p2= temp.IndexOf("</body>");
					if(p2 == 0)
						return temp;
					if(p2 < 0)
						p2 = temp.IndexOf("</BODY>");
					if(p2 < 0)
					{
						//buffer += "<table width=100% border=0 cellpadding=0 cellspacing=0>" + temp + "</table>";
						buffer += temp;
						continue;
					}
					if(p2 < p1)
					{
						//buffer += "<table width=100% border=0 cellpadding=0 cellspacing=0>" + temp + "</table>";
						buffer += temp;
						continue;
					}
					//temp += "<table width=100% border=0 cellpadding=0 cellspacing=0>" + temp.Substring(p1 + 1, p2 - (p1 + 1)) + "</table>";
					//buffer += temp;
					temp += temp.Substring(p1 + 1, p2 - (p1 + 1));
				}
				if(this.Texts[i].ContentType != null && AsciiString.Compare(this.Texts[i].ContentType, Mime.Headrs.ContentType.TextPlain) == 0)
				{
					Regex rex1 = new Regex("<");
					Regex rex2 = new Regex(">");
					temp  = rex1.Replace(temp , "&lt;");
					temp = rex2.Replace(temp, "&gt;");
					//buffer += "<table width=100% border=0 cellpadding=0 cellspacing=0>" + temp + "</table>";
					buffer += temp;
				}
			}
			return buffer;
		}
		//---------------------
		[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
		protected override void Render(HtmlTextWriter output) 
		{
			output.Write("<DIV id=\"Layer1\" style=\"SCROLLBAR-FACE-COLOR: #ffffff;SCROLLBAR-HIGHLIGHT-COLOR: #FFCC66;OVERFLOW:scroll;WIDTH: 100%;SCROLLBAR-SHADOW-COLOR: #999900;color:#000000;SCROLLBAR-ARROW-COLOR: #ffffff;FONT-FAMILY: Tahoma;SCROLLBAR-BASE-COLOR: #000000;HEIGHT: 550px;scrollbar-3d-light-color: #ffffff;scrollbar-dark-shadow-color: #ffffff\">" + FindAppropriateHtmlBody() + BuildHtmlAttachments() + "</DIV>");
		}
		//---------------------
		
		//---------------------
	}
	//---------------------------------------------------------------------------------
	public class CyberEmptyBox : Control 
	{
		private string box = null;
		//---------------------
		public CyberEmptyBox()
		{
		}
		//---------------------
		public string Box
		{
			get
			{
				return this.box;
			}
			set
			{
				this.box = value;
			}
		}
		//---------------------
		[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
		protected override void Render(HtmlTextWriter output) 
		{
			output.Write("<div valign=\"middle\" align=\"center\" class=\"visited\" style=\"border-width:5px;border-style:solid;border-color:#0099FF\">There are no messages in your " + this.Box + " folder.</div>");
		}
		//---------------------
	}
	//---------------------------------------------------------------------------------
	public class CyberHyperLink : Control 
	{
		private string text = null;
		private string url = null;
		private string target = null;
		//---------------------
		public CyberHyperLink()
		{
		}
		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				this.text = value;
			}
		}
		//---------------------
		public  string Target
		{
			get
			{
				return this.Target;
			}
			set
			{
				this.target = value;
			}
		}
		//---------------------
		public  string Url
		{
			get
			{
				return this.url;
			}
			set
			{
				this.url = value;
			}
		}
		//---------------------
		[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
		protected override void Render(HtmlTextWriter output) 
		{
			output.Write(String.Format("<a href=\"{0}\" target=\"{1}\">{2}</a>", this.url, this.target, this.text));
		}
		//---------------------
	}
	//---------------------------------------------------------------------------------
	public class CyberCheckBox : Control 
	{
		private string CheckBoxValue ;
		private string e = null;
		public CyberCheckBox()
		{
			this.CheckBoxValue = null;
		}
		public CyberCheckBox(string Value)
		{
			this.CheckBoxValue = Value;
		}
		public string Value
		{
			get
			{
				return this.CheckBoxValue;
			}
			set
			{
				this.CheckBoxValue = value;
			}
		}
		public string Event
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}
		[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
		protected override void Render(HtmlTextWriter output)
		{
			if(e != null && e != "")
			{
				output.Write(String.Format("<input type=\"checkbox\" name=\"{0}\" id=\"{0}\" value=\"{1}\" onClick=\"{2}\">", this.ID, this.CheckBoxValue, this.e));
			}
			else
			{
				output.Write(String.Format("<input type=\"checkbox\" name=\"{0}\" id=\"{0}\" value=\"{1}\">", this.ID, this.CheckBoxValue));
			}
		}
	}
	//---------------------------------------------------------------------------------
}