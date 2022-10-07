/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.IO;
using System.Xml;
using Mime;
using Mime.ASCII;
using System.Collections;

namespace Cyber.email
{
	//--------------------------------------------------------------------------------------------
	public class XmlSummary
	{
		private XmlTextReader read = null;
		private ArrayList texts = null;
		private ArrayList attachments = null;
		private Attachment[] attaches = null;
		private Text[] txts = null;
		private string to = null;
		//----------------------------------
		public XmlSummary(string buffer)
		{
			this.read = new XmlTextReader(new StringReader(buffer));
			GetItems();
		}
		//----------------------------------
		public Attachment[] Attachments
		{
			get
			{
				return this.attaches;
			}
		}
		//----------------------------------
		public Text[] Texts
		{
			get
			{
				return this.txts;
			}
		}
		//----------------------------------
		public string To
		{
			get
			{
				return this.to;
			}
		}
		//----------------------------------
		public void GetItems()
		{
			while(read.Read())
			{
				if(read.NodeType == XmlNodeType.Element)
				{
					if(read.Name == "To")
						this.to = Mime.EncoderDecoder.BinaryToStringUTF8(Convert.FromBase64String(read.ReadString()));
					if(read.Name == "text")
					{
						if(this.texts == null)
							this.texts = new ArrayList();
						Text text = new Text();
						read.MoveToAttribute("Charset");
						text.Charset = new AsciiString(read.Value);
						read.MoveToAttribute("TransferEncoding");
						text.ContentTransferEncoding = new AsciiString(read.Value);
						read.MoveToAttribute("ContentType");
						text.ContentType = new AsciiString(read.Value);
						read.MoveToAttribute("start");
						text.Start = Convert.ToInt32(read.Value);
						read.MoveToAttribute("end");
						text.End = Convert.ToInt32(read.Value);
						this.texts.Add(text);
					}
					if(read.Name == "attachment")
					{
						if(this.attachments == null)
							this.attachments = new ArrayList();
						Attachment attachment = new Attachment();
						read.MoveToAttribute("Filename");
						attachment.Filename = new AsciiString(read.Value);
						read.MoveToAttribute("TransferEncoding");
						attachment.ContentTransferEncoding = new AsciiString(read.Value);
						read.MoveToAttribute("ContentType");
						attachment.ContentType = new AsciiString(read.Value);
						read.MoveToAttribute("Name");
						attachment.Name = new AsciiString(read.Value);
						read.MoveToAttribute("start");
						attachment.Start = Convert.ToInt32(read.Value);
						read.MoveToAttribute("end");
						attachment.End = Convert.ToInt32(read.Value);
						this.attachments.Add(attachment);
					}
				}
			}
			if(this.texts != null)
			{
				this.txts = new Text[this.texts.Count];
				for(int i = 0 ; i < this.texts.Count ; i++)
					this.txts[i] = (Text) this.texts[i];
			}
			if(this.attachments != null)
			{
				this.attaches = new Attachment[this.attachments.Count];
				for(int i = 0 ; i < this.attachments.Count ; i++)
					this.attaches[i] = (Attachment) this.attachments[i];
			}
			read.Close();
			if(this.attachments != null)
			{
				this.attachments.Clear();
				this.attachments = null;
			}
			if(this.texts != null)
			{
			    this.texts.Clear();
				this.texts = null;
			}
			return ;
		}
		//----------------------------------
	}
	//--------------------------------------------------------------------------------------------
}