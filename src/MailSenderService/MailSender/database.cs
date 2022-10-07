/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using Mime.ASCII;
using Mime.MimeParser;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;

namespace MailSender
{
	//----------------------------------------------------------------------------------------------------------
	public class Database
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
		public Database(string server, string dbName,string userAdmin, string passAdmin)
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
		~Database()      
		{
			Dispose(false);
		}
		//---------------------------------------------------------------------------
		public Queue LoadQueueTable()
		{
			Queue queue =  new Queue();
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.Connection = connection;
			command.CommandText = "SELECT MsgID FROM " + constants.QueueTableName + " ORDER BY RecieveDate ASC";
			SqlDataReader read = command.ExecuteReader();
			while(read.Read())
			{
				MessageQueuingInfo info = new MessageQueuingInfo();
				info.SqlQueueAddress = constants.SqlServerAddressComposeDb;
				info.MsgID = read.GetString(0);
				queue.Enqueue(info);
			}
			read.Close();
			connection.Close();
			command.Dispose();
			return queue;
		}
		//---------------------------------------------------------------------------
		public int SendUndeliveryMessage(string username, MessageParser mp)
		{
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.Connection = connection;
			command.CommandText =  "INSERT INTO " + username + " (date,box,MailFrom,subject,size,attachment,infos,MimeData)" +
				" VALUES(@date,@box,@MailFrom,@subject,@size,@attachment,@infos,@MimeData);";
			SqlParameter DateParam = new SqlParameter("@date", SqlDbType.DateTime);
			SqlParameter BoxParam = new SqlParameter("@box", SqlDbType.Char);
			SqlParameter MailFromParam = new SqlParameter("@MailFrom", SqlDbType.NVarChar);
			SqlParameter SubjectParam = new SqlParameter("@subject", SqlDbType.NVarChar);
			SqlParameter SizeParam = new SqlParameter("@size", SqlDbType.Int);
			SqlParameter AttachmentParam = new SqlParameter("@attachment", SqlDbType.Bit);
			SqlParameter InfosParam = new SqlParameter("@infos", SqlDbType.NText);
			SqlParameter MimeDataParam = new SqlParameter("@MimeData", SqlDbType.Image);
			DateParam.Value = DateTime.Now;;
			BoxParam.Value = '0';
			MailFromParam.Value = constants.MailServerName;
			if(mp.Subject == null)
				SubjectParam.Value = "";
			if(mp.Subject.Length <= 512)
				SubjectParam.Value = mp.Subject.ToUTF8String();
			else
				SubjectParam.Value = mp.Subject.Substring(0, 512);
			SizeParam.Value = mp.Source.Length;
			AttachmentParam.Value = 0;
			bool HasAttachment = false;
			InfosParam.Value = mp.GetXmlSummarize(ref HasAttachment);
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
			return 0;
		}
		//-----------------------------------------
		public SendingInfo GrabNewRowQueue(string MsgID)
		{
			//after reciveing mail form QueueTable we, must delete it.
			SendingInfo info = null;
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.Connection = connection;
			/*      0    1     2   3  4      5        */
			command.CommandText = String.Format("SELECT MsgID,[From],[To],Cc,Bcc,MimeData FROM {0} WHERE MsgID='{1}';DELETE FROM {0} WHERE MsgID='{1}'", constants.QueueTableName, MsgID);
			SqlDataReader read = command.ExecuteReader();//;DELETE FROM {0} WHERE MsgID='{1}'
			if(read.Read())
			{
				info = new SendingInfo();
				info.MsgID = read.GetString(0);
				info.From = read.GetString(1);
				info.To = read.GetString(2);
				info.Cc = read.GetString(3);
				info.Bcc = read.GetString(4);
				info.MimeData = new AsciiString((byte[])read.GetValue(5));
			}
			read.Close();
			connection.Close();
			command.Dispose();
			return info;
		}
		//---------------------------------------------------------------------------
	}
	//----------------------------------------------------------------------------------------------------------
	public class SqlTransaction
	{ // if in this class , we can connect to ComposeDb , we must end the MailSender Process
		private string userAdmin;
		private string passAdmin;
		private string server;
		private string dbName;
		private string ConnectString;
		SqlConnection connection;
		SqlCommand command;
		SqlDataReader read;
		System.Data.SqlClient.SqlTransaction transaction;
		private Component component = new Component();
		private bool disposed = false;
		//-----------------------------------------
		public SqlTransaction(string server, string dbName,string userAdmin, string passAdmin)
		{
			this.server = server;
			this.dbName = dbName;
			this.userAdmin = userAdmin;
			this.passAdmin = passAdmin;
			this.ConnectString="database=" + this.dbName + ";server=" + this.server +
				";User Id=" + this.userAdmin + ";Password=" + this.passAdmin +";Connect Timeout=30;";
			connection = new SqlConnection(this.ConnectString);
			connection.Open();
			command = connection.CreateCommand();
			transaction = connection.BeginTransaction();
			command.Connection = connection;
			command.Transaction = transaction;
		}
		//-----------------------------------------
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		//-----------------------------------------
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
		//-----------------------------------------
		~SqlTransaction()      
		{
			Dispose(false);
		}
		//-----------------------------------------
		public void count()
		{
			this.command.CommandText = "SELECT COUNT(*) FROM "+ constants.QueueTableName;
			read = this.command.ExecuteReader();
			read.Read();
			Console.WriteLine(read.GetInt32(0));
			read.Close();
			return;
		}
		//-----------------------------------------
		public SendingInfo GrabNewRowQueue(string MsgID)
		{
			//after reciveing mail form QueueTable we, must delete it.
			SendingInfo info = null;
			                              /*      0    1     2   3  4      5        */
			this.command.CommandText = String.Format("SELECT MsgID,[From],[To],Cc,Bcc,MimeData FROM {0} WHERE MsgID='{1}'", constants.QueueTableName, MsgID);
			read = this.command.ExecuteReader();//;DELETE FROM {0} WHERE MsgID='{1}'
			if(read.Read())
			{
				info = new SendingInfo();
				info.MsgID = read.GetString(0);
				info.From = read.GetString(1);
				info.To = read.GetString(2);
				info.Cc = read.GetString(3);
				info.Bcc = read.GetString(4);
				info.MimeData = new AsciiString((byte[])read.GetValue(5));
			}
			read.Close();
			this.command.CommandText = "DELETE FROM " + constants.QueueTableName + " WHERE MsgID=@MsgID";//String.Format("DELETE FROM {0} WHERE MsgID='{1}'", constants.QueueTableName, MsgID);
			SqlParameter MsgIDParam = new SqlParameter("@MsgID", SqlDbType.VarChar);
			MsgIDParam.Value = MsgID;
			command.Parameters.Add(MsgIDParam);
			this.command.ExecuteNonQuery();
			return info;
		}
		//-----------------------------------------
	}
	//----------------------------------------------------------------------------------------------------------
}