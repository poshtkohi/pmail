/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.IO;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Collections;
using Mime.MimeBuilder;
using Mime.MimeParser;
using Mime;

namespace SMTP
{
	//----------------------------------------------------------------------------------------------------------------
	public class UsersEmailInfo
	{
		public UsersEmailInfo(){}
		//public string username = null;
		public int CurrentBoxSize = 0;
		public int MaxBoxSize = 0;
		public string EmailSqlAddress = null;
	}
	//----------------------------------------------------------------------------------------------------------------
	public class UsersMailDb
	{
		private string userAdmin;
		private string passAdmin;
		private string server;
		private string dbName;
		private string ConnectString;
		private Component component = new Component();
		private bool disposed = false;
		//--------------------------------
		public UsersMailDb()
		{
			this.server = constants.SqlServerAddressUsersMailDb;
			this.dbName = constants.UsersMailDbName;
			this.userAdmin = constants.UsersMailDbUsername;
			this.passAdmin = constants.UsersMailDbPassword;
			this.ConnectString="database=" + this.dbName + ";server=" + this.server +
				";User Id=" + this.userAdmin + ";Password=" + this.passAdmin +";Connect Timeout=30;";
		}
		//--------------------------------
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		//--------------------------------
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
		//--------------------------------
		~UsersMailDb()      
		{
			Dispose(false);
		}
		//--------------------------------
		private string mark(string input)
		{
			return "'" + input +"'";
		}
		//--------------------------------
		public int SaveMailInfoToDb(Hashtable mailtos, DateTime dateRev, string from, MessageParser mp)
		{
			/*try
			{*/
			    int DataLength = 0;
			    bool HasAttachment = false;
			    string infos = mp.GetXmlSummarize(ref HasAttachment);
				//in this section, we use from Transact-SQL transaction // then we must update here AccountDb
				IDictionaryEnumerator ide = mailtos.GetEnumerator();
			    DataLength = mp.Source.Length;
				while(ide.MoveNext())
				{
					UsersEmailInfo info = (UsersEmailInfo)ide.Value;
					//info.username = (string)ide.Key;
					/*try
					{*/
						/*FileStream fs = new FileStream(CompleteFilename((string)ide.Key,info.MailRoot, filename) , FileMode.Create, FileAccess.Write,FileShare.None);
						fs.Write(mp.Buffer.BaseStream, 0, mp.Buffer.Length);
						fs.Close();*/
					/*}
					catch
					{
						continue;
					}*/
					SqlConnection connection = new SqlConnection(this.ConnectString);
					connection.Open();
					SqlCommand command = connection.CreateCommand();
					command.Connection = connection;
					command.CommandText =  "INSERT INTO " + ide.Key + " (date,box,MailFrom,subject,size,attachment,infos,MimeData)" +
						" VALUES(@date,@box,@MailFrom,@subject,@size,@attachment,@infos,@MimeData)";
					SqlParameter DateParam = new SqlParameter("@date", SqlDbType.DateTime);
					// we afterwards must consider Bulk or Inbox here DECLARE @ptrval VARBINARY(16) SELECT @ptrval=TEXTPTR(MimeData) FROM " + ide.Key + " WHERE filename=@filename WRITETEXT "+ ide.Key +".MimeData @ptrval @MimeData
					SqlParameter BoxParam = new SqlParameter("@box", SqlDbType.Char);
					SqlParameter MailFromParam = new SqlParameter("@MailFrom", SqlDbType.NVarChar);
					SqlParameter SubjectParam = new SqlParameter("@subject", SqlDbType.NVarChar);
					SqlParameter SizeParam = new SqlParameter("@size", SqlDbType.Int);
					SqlParameter AttachmentParam = new SqlParameter("@attachment", SqlDbType.Bit);
					SqlParameter InfosParam = new SqlParameter("@infos", SqlDbType.NText);
					SqlParameter MimeDataParam = new SqlParameter("@MimeData", SqlDbType.Image);
					DateParam.Value = dateRev;
					BoxParam.Value = '0';
					if(from.Length <= 512)
					   MailFromParam.Value = from;
					else
						MailFromParam.Value = from.Substring(0, 512);
					if(mp.Subject == null)
						SubjectParam.Value = "";
					if(mp.Subject.Length <= 512)
						SubjectParam.Value = mp.Subject.ToUTF8String();
					else
						SubjectParam.Value = mp.Subject.Substring(0, 512);
					SizeParam.Value = DataLength;
					if(HasAttachment)
					    AttachmentParam.Value = 1;
					else
						AttachmentParam.Value = 0;
					InfosParam.Value = infos;
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
					connection.Close();
				}
			    //transaction.Commit();
			    //transaction.Dispose();
			    //command.Dispose();
				return DataLength;
			/*}
			catch
			{
				return -3;
			}*/
		}
		//--------------------------------
		private string CompleteFilename(string username, string MailRoot, string filename)
		{
			return String.Format(@"{0}\{1}\{2}.eml", MailRoot, username, filename);
		}
		//--------------------------------
	}
	//----------------------------------------------------------------------------------------------------------------
	public class UsersEmailAccountDB
	{
		private string userAdmin;
		private string passAdmin;
		private string server;
		private string dbName;
		private string ConnectString;
		/*private Component component = new Component();
		private bool disposed = false;*/
		//--------------------------------
		public UsersEmailAccountDB()
		{
			this.server = constants.SqlServerAddressAccountsDb;
			this.dbName = constants.AccountsDbName;
			this.userAdmin = constants.AccountsDbUsername;
			this.passAdmin = constants.AccountsDbPassword;
			this.ConnectString="database=" + this.dbName + ";server=" + this.server +
				";User Id=" + this.userAdmin + ";Password=" + this.passAdmin +";Connect Timeout=30;";
		}
		/*--------------------------------
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		//--------------------------------
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
		//--------------------------------
		~UsersEmailAccountDB()      
		{
			Dispose(false);
		}*/
		//--------------------------------
		private string mark(string input)
		{
			return "'" + input +"'";
		}
		//--------------------------------
		public Trie LoadUsersAccountFromDb()
		{
			string query = "SELECT username,EmailSqlAddress,CurrentBoxSize,MaxBoxSize FROM " + constants.MailAccountsTableName + " WHERE Active=1";
			SqlConnection connection = new SqlConnection(this.ConnectString);
			SqlCommand command = new SqlCommand(query, connection);
			connection.Open();
			SqlDataReader read = command.ExecuteReader();
			if(!read.HasRows)
			{
				read.Close();
				connection.Close();
				connection.Dispose();
				command.Dispose();
				return null;
			}
			Trie trie = new Trie();
			while(read.Read())
			{
				UsersEmailInfo ueinfo = new UsersEmailInfo();
				string username = read.GetString(0);
				ueinfo.EmailSqlAddress = read.GetString(1);
				ueinfo.CurrentBoxSize = read.GetInt32(2);
				ueinfo.MaxBoxSize = read.GetInt32(3);
				trie.AddUsernameAccount(username, ueinfo);
			}
			read.Close();
			connection.Close();
			connection.Dispose();
			command.Dispose();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			return trie;
		}
		//--------------------------------
		public int UpdateUsersAccountDb(ref Trie t, Hashtable mailtos, int DataLength)
		{
			/*try
			{*/
			//in this section, we use from Transact-SQL transaction // then we must update here AccountDb
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			SqlTransaction transaction = connection.BeginTransaction();
			command.Connection = connection;
			command.Transaction = transaction;
			IDictionaryEnumerator ide = mailtos.GetEnumerator();
			while(ide.MoveNext())
			{
				UsersEmailInfo info = (UsersEmailInfo)ide.Value;
				//info.username = (string)ide.Key;
				command.CommandText = "Update " + constants.MailAccountsTableName + " SET CurrentBoxSize=CurrentBoxSize+@DataLength WHERE username=@username";
				SqlParameter DataLengthParam = new SqlParameter("@DataLength", SqlDbType.Int);
				SqlParameter UsernameParam = new SqlParameter("@username", SqlDbType.VarChar);
				DataLengthParam.Value = DataLength;
				UsernameParam.Value = ide.Key;
				command.Parameters.Add(DataLengthParam);
				command.Parameters.Add(UsernameParam);
				command.ExecuteNonQuery();
				info.CurrentBoxSize += DataLength;
				t.UpdateAccountData((string) ide.Key, info); 
			}
			transaction.Commit();
			connection.Close();
			transaction.Dispose();
			command.Dispose();
			return 0;
			/*}
			catch
			{
				return -3;
			}*/
		}
		//--------------------------------
	}
	//----------------------------------------------------------------------------------------------------------------
}