/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Collections;
using Mime.ASCII;
using System.ComponentModel;

namespace Mime.MimeParser
{
	//--------------------------------------------------------------------------------------------------------
	public class MessageParser
	{
		private AsciiString source;
		private ArrayList RootNodes = null;
		private ArrayList attachments = null;
		private ArrayList texts = null;
		private AsciiString from = null;
		private AsciiString to = null;
		private AsciiString cc = null;
		private AsciiString bcc = null;
		private AsciiString subject = null;
		private Component component = new Component();
		private bool disposed = false;
		//------------------------------
		private class BodyPart
		{
			public int start = 0;
			public int end = 0;
			public BodyPart()
			{
			}
		}
		//------------------------------
		public void Dispose()
		{
			this.attachments = null;
			this.texts = null;
			this.RootNodes = null;
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
		~MessageParser()      
		{
			Dispose(false);
		}
		//------------------------------
		public MessageParser(AsciiString source)
		{
			this.source = source;
			this.RootNodes = FindRootNodes();
			int p = this.source.IndexOf(new AsciiString("Mime-Version")); // if p < 0 meaning the body is absoloute ASCII US text
			AsciiString MainHeader = null;
			if(p <= 0)
				MainHeader = this.source;
			else
				MainHeader = this.source.Substring(0, p); //involoving from,....
			from = FindHeader(MainHeader, new AsciiString("From:"));
			to = FindHeader(MainHeader, new AsciiString("To:"));
			cc = FindHeader(MainHeader, new AsciiString("Cc:"));
			bcc = FindHeader(MainHeader, new AsciiString("Bcc:"));
			subject = FindHeader(MainHeader, new AsciiString("Subject:"));
			if(this.RootNodes != null)
			{
				BuildMimeTree(this.RootNodes);
				BuildAttachmentsTexts(this.RootNodes);
			}
			else
			{
				p = this.source.IndexOf(new AsciiString("Content-Type: "));
				if(p >= 0)
				{
					BodyPart bp = new BodyPart();
					bp.start = p;
					bp.end = this.source.Length;
					if(bp.start == bp.end)
						return ;
					int p1 = this.source.IndexOf(new AsciiString("Content-Disposition: attachment"), bp.start);
					if(p1 >= 0)
					{
						if(this.attachments == null)
							this.attachments = new ArrayList();
						Attachment attachment = new Attachment();
						attachment.ContentType = FindContentType(bp);
						attachment.Name = FindName(bp);
						attachment.Filename = FindFileName(bp);
						attachment.ContentTransferEncoding = FindContentTransferEncoding(bp);
						int start = this.source.IndexOf(new AsciiString("\r\n\r\n"), bp.start);
						if(start > 0)
							start += "\r\n\r\n".Length;
						else
							start = bp.start;
						attachment.StartPositionInBuffer = start;
						attachment.EndPositionInBuffer = bp.end;
						this.attachments.Add(attachment);
					}
					else
					{
						p1 = this.source.IndexOf(new AsciiString("Content-Type: text/"), bp.start);
						if(p1 >= 0)
						{
							if(this.texts == null)
								this.texts = new ArrayList();
							Text text = new Text();
							text.ContentType = FindContentType(bp);
							text.ContentTransferEncoding = FindContentTransferEncoding(bp);
							text.Charset = FindCharset(bp);
							int start = this.source.IndexOf(new AsciiString("\r\n\r\n"), bp.start);
							if(start > 0)
								start += "\r\n\r\n".Length;
							else
								start = bp.start;
							text.StartPositionInBuffer = start;
							text.EndPositionInBuffer = bp.end;
							this.texts.Add(text);
						}
					}
				}
			}
		}
		//------------------------------
		public AsciiString Source
		{
			get
			{
				return this.source;
			}
		}
		//------------------------------
		public AsciiString From
		{
			get
			{
				return this.from;
			}
		}
		//------------------------------
		public AsciiString To
		{
			get
			{
				return this.to;
			}
		}
		//------------------------------
		public AsciiString Cc
		{
			get
			{
				return this.cc;
			}
		}
		//------------------------------
		public AsciiString Bcc
		{
			get
			{
				return this.bcc;
			}
		}
		//------------------------------
		public AsciiString Subject
		{
			get
			{
				return this.subject;
			}
		}
		//------------------------------
		public Text[] Texts
		{
			get
			{
				if(this.texts == null)
					return null;
				else
				{
					Text[] texts = (Text[]) this.texts.ToArray(typeof(Text));
					for(int i = 0 ; i < texts.Length ; i++)
						texts[i].Source = this.source.Substring(texts[i].StartPositionInBuffer, 
							texts[i].EndPositionInBuffer - texts[i].StartPositionInBuffer);
					return texts;
				}
			}
		}
		//------------------------------
		private Text[] TextsWithoutSource
		{
			get
			{
				if(this.texts == null)
					return null;
				return (Text[]) this.texts.ToArray(typeof(Text));
			}
		}
		//------------------------------
		public Attachment[] Attachments
		{
			get
			{
				if(this.attachments == null)
					return null;
				else
				{
					Attachment[] attachments = (Attachment[]) this.attachments.ToArray(typeof(Attachment));
					for(int i = 0 ; i < attachments.Length ; i++)
						attachments[i].Source = this.source.Substring(attachments[i].StartPositionInBuffer, 
							attachments[i].EndPositionInBuffer - attachments[i].StartPositionInBuffer);
					return attachments;
				}
			}
		}
		//------------------------------
		private Attachment[] AttachmentsWithoutSource
		{
			get
			{
				if(this.attachments == null)
					return null;
				return (Attachment[]) this.attachments.ToArray(typeof(Attachment));
			}
		}
		//------------------------------
		private AsciiString FindHeader(AsciiString buffer, AsciiString match)
		{
			int p1 = buffer.IndexOf(match);
			if(p1 < 0)
				return null;
			int p2 = buffer.IndexOf(new AsciiString("\r\n"), p1);
			if(p2 < 0 || p1 >= p2)
				return null;
			return  buffer.Substring(p1 + match.Length, p2 - (p1 + match.Length)).Trim();
		}
		//------------------------------
		private void BuildAttachmentsTexts(ArrayList input)
		{
			for(int i = 0 ; i < input.Count ; i++)
			{
				if(input[i].ToString() != "System.Collections.ArrayList")
				{
					BodyPart bp = (BodyPart) input[i];
					int p1 = this.source.IndexOf(new AsciiString("Content-Disposition: attachment"), bp.start, bp.end - bp.start);
					if(p1 >= 0)
					{
						if(this.attachments == null)
							this.attachments = new ArrayList();
						Attachment attachment = new Attachment();
						attachment.ContentType = FindContentType(bp);
						attachment.Name = FindName(bp);
						attachment.Filename = FindFileName(bp);
						attachment.ContentTransferEncoding = FindContentTransferEncoding(bp);
						int start = this.source.IndexOf(new AsciiString("\r\n\r\n"), bp.start, bp.end - bp.start);
						if(start > 0)
							start += "\r\n\r\n".Length;
						else
							start = bp.start;
						attachment.StartPositionInBuffer = start;
						attachment.EndPositionInBuffer = bp.end;
						this.attachments.Add(attachment);
					}
					else
					{
						p1 = this.source.IndexOf(new AsciiString("Content-Type: text/"), bp.start, bp.end - bp.start);
						if(p1 >= 0)
						{
							if(this.texts == null)
								this.texts = new ArrayList();
							Text text = new Text();
							text.ContentType = FindContentType(bp);
							text.ContentTransferEncoding = FindContentTransferEncoding(bp);
							text.Charset = FindCharset(bp);
							int start = this.source.IndexOf(new AsciiString("\r\n\r\n"), bp.start, bp.end - bp.start);
							if(start > 0)
								start += "\r\n\r\n".Length;
							else
								start = bp.start;
							text.StartPositionInBuffer = start;
							text.EndPositionInBuffer = bp.end;
							this.texts.Add(text);
						}
					}
				}
				else if(input[i].ToString() == "System.Collections.ArrayList")
				{
					BuildAttachmentsTexts((ArrayList)input[i]);
				}
				else continue;
			}
			return ;
		}
		//------------------------------
		private AsciiString FindContentType(BodyPart bp)
		{
			int p1 = this.source.IndexOf(new AsciiString("Content-Type: "), bp.start);
			p1 += "Content-Type: ".Length;
			int p2 = this.source.IndexOf(new AsciiString(";"), p1 );
			if(p2 < 0)
			{
				p2 = this.source.IndexOf(new AsciiString("\r\n"), p1 );
				if(p2 < 0)
					return null;
			}
			return this.source.Substring(p1, p2 - p1);
		}
		//------------------------------
		private AsciiString FindContentId(BodyPart bp)
		{
			int p1 = this.source.IndexOf(new AsciiString("Content-ID: "), bp.start);
			if(p1 < 0)
				return null;
			p1 += "Content-ID: ".Length;
			int p2 = this.source.IndexOf(new AsciiString("\r\n"), p1 );
			if(p2 < 0)
				return null;
			return this.source.Substring(p1, p2 - p1).Trim().ToLower();
		}
		//------------------------------
		private AsciiString FindContentTransferEncoding(BodyPart bp)
		{
			int p1 = this.source.IndexOf(new AsciiString("Content-Transfer-Encoding: "), bp.start);
			if(p1 < 0)
				return null;
			p1 += "Content-Transfer-Encoding: ".Length;
			int p2 = this.source.IndexOf(new AsciiString("\r\n"), p1 );
			if(p2 < 0)
				return null;
			return this.source.Substring(p1, p2 - p1).Trim().ToLower();
		}
		//------------------------------
		private AsciiString FindFileName(BodyPart bp)
		{
			int p1 = this.source.IndexOf(new AsciiString("filename=\""), bp.start);
			if(p1 < 0)
				return null;
			p1 += "filename=\"".Length;
			int p2 = this.source.IndexOf(new AsciiString("\""), p1);
			if(p2 < 0)
				return null;
			return this.source.Substring(p1, p2 - p1).Trim();
		}
		//------------------------------
		private AsciiString FindName(BodyPart bp)
		{
			int p1 = this.source.IndexOf(new AsciiString("name=\""), bp.start);
			if(p1 < 0)
				return null;
			p1 += "name=\"".Length;
			int p2 = this.source.IndexOf(new AsciiString("\""), p1);
			if(p2 < 0)
				return null;
			return this.source.Substring(p1, p2 - p1).Trim();
		}
		//------------------------------
		private AsciiString FindCharset(BodyPart bp)
		{
			int p1 = this.source.IndexOf(new AsciiString("charset=\""), bp.start);
			if(p1 < 0)
				return null;
			p1 += "charset=\"".Length;
			int p2 = this.source.IndexOf(new AsciiString("\""), p1);
			if(p2 < 0)
				return null;
			return this.source.Substring(p1, p2 - p1).Trim();
		}
		//------------------------------
		private ArrayList FindRootNodes()
		{
			int p = this.source.IndexOf(new AsciiString("Content-Type: multipart/"));
			if(p >= 0)
			{
				int p1 = this.source.IndexOf(new AsciiString("boundary=\""), p);
				if(p1 < 0)
					return null;
				p1 += "boundary=\"".Length;
				int p2 = this.source.IndexOf(new AsciiString("\""), p1);
				if(p2 < 0)
					return null;
				AsciiString boundary = this.source.Substring(p1, p2 - p1);
				while(true)
				{
					if(p1 > p2 || p2 > this.source.Length)
						break;
					p1 = this.source.IndexOf(new AsciiString("--") + boundary, p2);
					if(p1 < 0)
						break;
					if(p1 >= 0)
					{
						p1 += ("--" + boundary).Length;
						p2 = this.source.IndexOf(new AsciiString("--") + boundary, p1);
						if(p2 > 0)
						{
							if(RootNodes == null)
								RootNodes = new ArrayList();
							BodyPart temp = new BodyPart();
							temp.start = p1;
							temp.end = p2;
							p2--;
							RootNodes.Add(temp);
							continue;
						}
					}
				}
				return RootNodes;
			}
			else
				return null;
		}
		//------------------------------
		private void BuildMimeTree(ArrayList input)
		{
			for(int i = 0 ; i < input.Count ; i++)
			{
				BodyPart bp = (BodyPart)input[i];
				int p = this.source.IndexOf(new AsciiString("Content-Type: multipart/"), bp.start, bp.end - bp.start);
				if(p >= 0)
				{
					int p1 = this.source.IndexOf(new AsciiString("boundary=\""), p);
					if(p1 < 0)
						continue;
					p1 += "boundary=\"".Length;
					int p2 = this.source.IndexOf(new AsciiString("\""), p1);
					if(p2 < 0)
						continue;
					AsciiString boundary = this.source.Substring(p1, p2 - p1);
					ArrayList Nodes = null;
					while(true)
					{
						if(p1 > p2 || p2 > this.source.Length)
							break;
						p1 = this.source.IndexOf(new AsciiString("--") + boundary, p2);
						if(p1 < 0)
							break;
						if(p1 >= 0)
						{
							p1 += ("--" + boundary).Length;
							p2 = this.source.IndexOf(new AsciiString("--") + boundary, p1);
							if(p2 > 0)
							{
								if(Nodes == null)
								{
									Nodes = new ArrayList();
								}
								BodyPart temp = new BodyPart();
								temp.start = p1;
								temp.end = p2;
								p2--;
								Nodes.Add(temp);
								continue;
							}
						}
					}
					if(Nodes != null)
					{
						input[i] = Nodes;
						BuildMimeTree((ArrayList)input[i]);
					}
					else continue;
				}
			}
			return ;
		}
		//------------------------------
		public void Travel()
		{
			if(this.RootNodes != null)
				travel(this.RootNodes);
		}
		//------------------------------
		public string GetXmlSummarize(ref bool HasAttachment)
		{
			string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><summary>";
			Text[] texts = this.Texts;
			Attachment[] attachments = this.Attachments;
			if(this.to == null)
				xml += "<To>" + Mime.EncoderDecoder.Base64Encoder("<None>").ToUTF8String() + "</To>";
			else
				xml += "<To>" + Mime.EncoderDecoder.Base64Encoder(this.to.BaseStream).ToUTF8String() + "</To>";
			xml += "<texts>";
			if(texts != null)
			{
				for(int i = 0 ; i < texts.Length; i++)
				{
					xml += "<text ";
					if(texts[i].Charset != null)
						xml += String.Format("Charset=\"{0}\" ", texts[i].Charset.ToUTF8String());
					else
						xml += String.Format("Charset=\"{0}\" ", "null");
					if(texts[i].ContentTransferEncoding != null)
						xml += String.Format("TransferEncoding=\"{0}\" ", texts[i].ContentTransferEncoding.ToUTF8String());
					else
						xml += String.Format("TransferEncoding=\"{0}\" ", "null");
					if(texts[i].ContentType != null)
						xml += String.Format("ContentType=\"{0}\" ", texts[i].ContentType.ToUTF8String());
					else
						xml += String.Format("ContentType=\"{0}\" ", "null");
					xml += String.Format("start=\"{0}\" end=\"{1}\"", texts[i].Start, texts[i].End);
					xml += "/>";
				}
			}
			xml += "</texts><attachments>";
			if(attachments != null)
			{
				HasAttachment = true;
				for(int i = 0 ; i < attachments.Length; i++)
				{
					xml += "<attachment ";
					if(attachments[i].Filename != null)
						xml += String.Format("Filename=\"{0}\" ", attachments[i].Filename.ToUTF8String());
					else
						xml += String.Format("Filename=\"{0}\" ", "null");
					if(attachments[i].ContentTransferEncoding != null)
						xml += String.Format("TransferEncoding=\"{0}\" ", attachments[i].ContentTransferEncoding.ToUTF8String());
					else
						xml += String.Format("TransferEncoding=\"{0}\" ", "null");
					if(attachments[i].ContentType != null)
						xml += String.Format("ContentType=\"{0}\" ", attachments[i].ContentType.ToUTF8String());
					else
						xml += String.Format("ContentType=\"{0}\" ", "null");
					if(attachments[i].Name != null)
						xml += String.Format("Name=\"{0}\" ", attachments[i].Name.ToUTF8String());
					else
						xml += String.Format("Name=\"{0}\" ", "null");
					xml += String.Format("start=\"{0}\" end=\"{1}\"", attachments[i].Start, attachments[i].End);
					xml += "/>";
				}
			}
			xml += "</attachments></summary>";
			attachments = null;
			texts = null;
			return xml;
		}
		//------------------------------
		private void travel(ArrayList input)
		{
			for(int i = 0 ; i < input.Count ; i++)
			{
				if(input[i].ToString() != "System.Collections.ArrayList")
				{
					BodyPart temp = (BodyPart)input[i];
					Console.WriteLine(this.source.Substring(temp.start, temp.end - temp.start));
				}
				else if(input[i].ToString() == "System.Collections.ArrayList")
				{
					travel((ArrayList)input[i]);
				}
				else continue;
			}
			return ;
		}
		//------------------------------
	}
	//--------------------------------------------------------------------------------------------------------
}