/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;

namespace Cyber.email
{
	//----------------------------------------------------------------------------------------------------
	public class EmailDataClass
	{
		private int i;
		private DateTime date;
		private int size;
		private string mailfrom;
		private string subject;
		private bool attachment;
		private bool visited;
		private string infos;
		//---------------------
		public EmailDataClass()
		{
			this.i = 0;
			this.size = 0;
			this.MailFrom = null;
			this.subject = null;
			this.HasAttachment = false;
			this.visited = false;
			this.infos = null;
		}
		//---------------------
		public int ID
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}
		//---------------------
		public DateTime DateRecieve
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
		//---------------------
		public int Size
		{
			get
			{
				return this.size;
			}
			set
			{
				this.size = value;
			}
		}
		//---------------------
		public string MailFrom
		{
			get
			{
				return this.mailfrom;
			}
			set
			{
				this.mailfrom = value;
			}
		}
		//---------------------
		public string Subject
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
		//---------------------
		public bool HasAttachment
		{
			get
			{
				return this.attachment;
			}
			set
			{
				this.attachment = value;
			}
		}
		//---------------------
		public bool Visited
		{
			get
			{
				return this.visited;
			}
			set
			{
				this.visited = value;
			}
		}
		//---------------------
		public string Infos
		{
			get
			{
				return this.infos;
			}
			set
			{
				this.infos = value;
			}
		}
		//---------------------
	}
	//----------------------------------------------------------------------------------------------------
	public class AddressBookDataClass
	{
		private int i;
		private string infos;
		//---------------------
		public AddressBookDataClass()
		{
			this.i = 0;
			this.infos = null;
		}
		//---------------------
		public int ID
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}
		//---------------------
		public string Infos
		{
			get
			{
				return this.infos;
			}
			set
			{
				this.infos = value;
			}
		}
		//---------------------
	}
	//----------------------------------------------------------------------------------------------------
}