/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;

namespace MailSender
{
	//----------------------------------------------------------------------------------------------------------
	public class MessageQueuingInfo
	{
		private string sqlQueueAddress = null;
		private string msgID = null;
		//------------------------------------------------------------
		public MessageQueuingInfo()
		{
		}
		//------------------------------------------------------------
		public string SqlQueueAddress
		{
			get
			{
				return this.sqlQueueAddress;
			}
			set
			{
				this.sqlQueueAddress = value;
			}
		}
		//------------------------------------------------------------
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
		//------------------------------------------------------------
	}
	//----------------------------------------------------------------------------------------------------------
}
