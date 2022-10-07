/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using Mime.ASCII;

namespace MailSender
{
	//----------------------------------------------------------------------------------------------------------
	public class SendingInfo
	{
		//-----------------------------------------
		private string to = null;
		private string from = null;
		private string cc = null;
		private string bcc = null;
		private AsciiString mimeData = null;
		private string msgID = null;
		//-----------------------------------------
		public SendingInfo()
		{
		}
		//-----------------------------------------
		public string To
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
		//-----------------------------------------
		public string From
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
		//-----------------------------------------
		public string Cc
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
		//-----------------------------------------
		public string Bcc
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
		//-----------------------------------------
		public AsciiString MimeData
		{
			get
			{
				return this.mimeData;
			}
			set
			{
				this.mimeData = value;
			}
		}
		//-----------------------------------------
		public string MsgID
		{
			get
			{
				return this.msgID;
			}
			set
			{
				this.msgID = value;
			}
		}
		//-----------------------------------------
	}
	//----------------------------------------------------------------------------------------------------------
}
