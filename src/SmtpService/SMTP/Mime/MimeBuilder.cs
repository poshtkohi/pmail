/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Collections;
using Mime;
using Mime.Headrs;
using Mime.ASCII;

namespace Mime.MimeBuilder
{
	//-------------------------------------------------------------------------------------------------------------------
	public class MessageBuilder
	{
		private ArrayList texts = null;
		private ArrayList attachments = null;
		private AsciiString from = null;
		private AsciiString to = null;
		private AsciiString cc = null;
		private AsciiString bcc = null;
		private AsciiString subject = null;
		private DateTime date = DateTime.Now;
		private Component component = new Component();
		private bool disposed = false;
		private static readonly string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private static readonly string Lower = "abcdefghijklmnopqrstuvwxyz";
		private static readonly string Numbers = "0123456789";
		//------------------------------
		public MessageBuilder()
		{
		}
		public AsciiString From
		{
			get
			{
				return this.from;
			}
			set
			{
				this.from = value;
			}
		}
		//------------------------------
		public int AttachmentLength
		{
			get
			{
				if(this.attachments == null)
					return 0;
				else
					return this.attachments.Count;
			}
		}
		//------------------------------
		public int TextLength
		{
			get
			{
				if(this.texts == null)
					return 0;
				else
					return this.texts.Count;
			}
		}
		//------------------------------
		public AsciiString To
		{
			get
			{
				return this.to;
			}
			set
			{
				this.to = value;
			}
		}
		//------------------------------
		public AsciiString Cc
		{
			get
			{
				return this.cc;
			}
			set
			{
				this.cc = value;
			}
		}
		//------------------------------
		public AsciiString Bcc
		{
			get
			{
				return this.bcc;
			}
			set
			{
				this.bcc = value; 
			}
		}
		//------------------------------
		public AsciiString Subject
		{
			get
			{
				return this.subject;
			}
			set
			{
				this.subject = value;
			}
		}
		//------------------------------
		public DateTime Date
		{
			get
			{
				return this.date;
			}
			set
			{
				this.date = value;
			}
		}
		//------------------------------
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		//------------------------------
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
		//------------------------------
		~MessageBuilder()      
		{
			Dispose(false);
		}
		//------------------------------
		/// <summary>
		/// Add an attachment array body to MessageCompose body.
		/// </summary>
		/// <param name="attachments">is an Attachment[] array class.</param>
		public void AddAttachment(Attachment[] attachments)
		{
			if(attachments != null)
			{
				if(this.attachments == null)
				{
					this.attachments = new ArrayList();
				}
				for(int i = 0 ; i < attachments.Length ; i++)
					if(attachments[i] != null)
						this.attachments.Add(attachments[i]);
				return ;
			}
			/*else
			{
				throw new Exception("Attachment body is empty.");
			}*/
		}
		//------------------------------
		/// <summary>
		/// Add an text array body to MessageCompose body.
		/// </summary>
		/// <param name="texts">is an Text[] array class.</param>
		public void AddText(Text[] texts)
		{
			if(texts != null)
			{
				if(this.texts == null)
				{
					this.texts = new ArrayList();
				}
				for(int i = 0 ; i < texts.Length ; i++)
					if(texts[i] != null)
						this.texts.Add(texts[i]);
				return ;
			}
			/*else
			{
				throw new Exception("Text body is empty.");
			}*/
		}
		//------------------------------
		/// <summary>
		/// Add an attachment body to MessageCompose body.
		/// </summary>
		/// <param name="attachment">is an Attachment class.</param>
		public void AddAttachment(Attachment attachment)
		{
			if(attachment != null)
			{
				if(this.attachments == null)
				{
					this.attachments = new ArrayList();
				}
				this.attachments.Add(attachment);
				return ;
			}
			else
			{
				throw new Exception("Attachment body is empty.");
			}
		}
		//------------------------------
		/// <summary>
		/// Add a text body to MessageCompose body.
		/// </summary>
		/// <param name="text">is an Text class.</param>
		public void AddText(Text text)
		{
			if(text != null)
			{
				if(this.texts == null)
				{
					this.texts = new ArrayList();
				}
				this.texts.Add(text);
				return ;
			}
			else
			{
				throw new Exception("Text body is empty.");
			}
		}
		//------------------------------
		/// <summary>
		/// builds message body with attention to available texts and attachments in this message
		/// </summary>
		/// <returns></returns>
		public AsciiString BuildMessageBody()
		{
			AsciiString body = null;
			body = body + BuildHeader(this.from, new AsciiString("From"));
			body = body + BuildHeader(this.to, new AsciiString("To"));
			body = body + BuildHeader(this.cc, new AsciiString("Cc"));
			body = body + BuildHeader(this.bcc, new AsciiString("Bcc"));
			body = body + BuildHeader(this.subject, new AsciiString("Subject"));
			body = body + BuildHeader(new AsciiString(date.ToString("r")), new AsciiString("Date"));
			body = body + BuildHeader(new AsciiString("1.0"), new AsciiString("MIME-Version"));
			if(this.texts != null && this.texts.Count == 1 && this.attachments == null)
			{
				body = body + BuildTextBody((Text)texts[0]);
				return body;
			}
			else
			{
				return AsciiString.Concat(body, BuildMultiPartMixed(texts, attachments));
			}
		}
		//------------------------------
		private AsciiString BuildMultiPartMixed(ArrayList texts, ArrayList attachments)
		{
			if(texts == null && attachments == null)
			{
				Text text = new Text();
				return new AsciiString("X-MimeMime: Produced By Mime MimeMime V1.0 (C)2005.Mr.Alireza Poshtkoohi.\r\n") + BuildTextBody(text);
			}
			AsciiString boundary = new AsciiString("----NextSection=") + RandomString(16) + new AsciiString("--");
			AsciiString body = AsciiString.Format(new AsciiString("Content-Type: multipart/mixed;\r\n\tboundary=\"{0}\"\r\nX-MimeMime: Produced By Mime MimeMime V1.0 (C)2005.Mr.Alireza Poshtkoohi.\r\n\r\nThis is a multi-part message in MIME format provided by Mr.Alireza Poshtkoohi.\r\n\r\n--{0}\r\n"), boundary);
			if(texts != null)
			{
				int len = texts.Count;
				for(int i = 0 ; i < len ; i++)
				{
					body = AsciiString.Format(new AsciiString("{0}{1}--{2}\r\n"),  body, BuildTextBody((Text)texts[i]), boundary);
				}
				if(attachments == null)
				{
					body = AsciiString.Format(new AsciiString("{0}--{1}--\r\n"),  body, boundary);
					return body;
				}
			}
			if(texts == null && attachments != null)
			{
				Text text = new Text();
				body = AsciiString.Format(new AsciiString("{0}{1}--{2}\r\n"),  body, BuildTextBody(text), boundary);
			}
			if(attachments != null)
			{
				int len = attachments.Count;
				for(int i = 0 ; i < len ; i++)
				{
					if(i == len - 1)
						body = AsciiString.Format(new AsciiString("{0}{1}--{2}--\r\n"),  body, BuildAttachMentBody((Attachment)attachments[i]), boundary);
					else
						body = AsciiString.Format(new AsciiString("{0}{1}--{2}\r\n"),  body, BuildAttachMentBody((Attachment)attachments[i]), boundary);
				}
			}
			return body;
		}
		//------------------------------
		private AsciiString BuildHeader(AsciiString content, AsciiString header)
		{
			if(content == null || AsciiString.Compare(content,new AsciiString("")) == 0)
				return null;
			else
				return AsciiString.Format(new AsciiString("{0}: {1}\r\n"), header, content);
		}
		//------------------------------
		private AsciiString BuildAttachMentBody(Attachment attachment)
		{
			AsciiString contentType = attachment.ContentType;
			AsciiString name = attachment.Name;
			AsciiString contentTransferEncoding = attachment.ContentTransferEncoding;
			AsciiString filename = attachment.Filename;
			if(contentType == null || AsciiString.Compare(contentType, new AsciiString("")) == 0)
				contentType = ContentType.TextHtml;
			if(name == null || AsciiString.Compare(name, new AsciiString("")) == 0)
			{
				if(filename == null || AsciiString.Compare(filename, new AsciiString("")) == 0)
					filename = RandomString(5);
				name = filename;
			}
			if(contentTransferEncoding == null || AsciiString.Compare(contentTransferEncoding, new AsciiString("")) == 0)
				contentTransferEncoding = TransferEncoding.Base64;
			if(filename == null || AsciiString.Compare(filename, new AsciiString("")) == 0)
				filename = name;
			return AsciiString.Format(new AsciiString("Content-Type: {0};\r\n\tname=\"{1}\"\r\nContent-Transfer-Encoding: {2}\r\nContent-Disposition: attachment;\r\n\tfilename=\"{3}\"\r\n\r\n{4}\r\n\r\n"), contentType, name, contentTransferEncoding, filename, attachment.Source);
		}
		//------------------------------
		private AsciiString BuildTextBody(Text text)
		{
			AsciiString contentType = text.ContentType;
			AsciiString charset = text.Charset;
			AsciiString contentTransferEncoding = text.ContentTransferEncoding;
			if(contentType == null || AsciiString.Compare(contentType, new AsciiString("")) == 0)
				contentType = ContentType.TextHtml;
			if(charset == null || AsciiString.Compare(charset, new AsciiString("")) == 0)
				charset = Charset.UTF8;
			if(contentTransferEncoding == null || AsciiString.Compare(contentTransferEncoding, new AsciiString("")) == 0)
				contentTransferEncoding = TransferEncoding.QuotedPrintable;
			return AsciiString.Format(new AsciiString("Content-Type: {0};\r\n\tcharset=\"{1}\"\r\nContent-Transfer-Encoding: {2}\r\n\r\n{3}\r\n\r\n"), contentType, charset, contentTransferEncoding, text.Source);
		}
		//------------------------------
		static private AsciiString RandomString(int DesiredLength)
		{
			if(DesiredLength == 0)
				DesiredLength += 1;
			AsciiString result = null;
			for(int i = 1 ; i <= DesiredLength ; i++)
			{
				result = result + new AsciiString(RandomChar(i, RandomChar(i + 1, i*(new Random(unchecked((int)DateTime.Now.Ticks*i))).Next(DateTime.Now.Millisecond*i*i*DesiredLength))).ToString());
				Thread.Sleep(1);
			}
			return result;
		}
		//------------------------------
		static private char RandomChar(int i, int C)
		{
			char[] c = new char[3];
			c[0] = Upper[(new Random(unchecked((int)DateTime.Now.Ticks * i * DateTime.Now.Month))).Next(26)];
			c[1] = Lower[(new Random(unchecked((int)DateTime.Now.Second * C* DateTime.Now.Day))).Next(26)];
			c[2] = Numbers[(new Random(unchecked((int)DateTime.Now.Millisecond * i * DateTime.Now.Year))).Next(10)];
			return  c[new Random(unchecked((int)(DateTime.Now.Ticks * C * i))).Next(3)]; 
		}
		//------------------------------
	}
	//-------------------------------------------------------------------------------------------------------------------
}