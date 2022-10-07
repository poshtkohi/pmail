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

namespace SMTP
{
	public class GeneralDb
	{
		private string userAdmin;
		private string passAdmin;
		private string server;
		private string dbName;
		private string ConnectString;
		private Component component = new Component();
		private bool disposed = false;
		//-----------------------------------------------------------------------
		public GeneralDb(string server, string dbName,string userAdmin, string passAdmin)
		{
			this.server = server;
			this.dbName = dbName;
			this.userAdmin = userAdmin;
			this.passAdmin = passAdmin;
			this.ConnectString="database=" + this.dbName + ";server=" + this.server +
				";User Id=" + this.userAdmin + ";Password=" + this.passAdmin +";Connect Timeout=30;";
		}
		//-----------------------------------------------------------------------
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		//-----------------------------------------------------------------------
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
		//-----------------------------------------------------------------------
		~GeneralDb()      
		{
			Dispose(false);
		}
		//-----------------------------------------------------------------------
		private string mark(string input)
		{
			return "'" + input +"'";
		}
		//-----------------------------------------------------------------------
		static public int CreateEmailsTableForAnyClient(string TableName)
		{
			/*try
			{*/
				string query="CREATE TABLE " + TableName + " (i int IDENTITY(1,1) PRIMARY KEY,date DATETIME NOT NULL,size INT NOT NULL, "+
					"box CHAR(1) NOT NULL default('0'),MailFrom NVARCHAR(512) NOT NULL,subject NVARCHAR(512),attachment BIT DEFAULT(0),visited BIT DEFAULT(0) NOT NULL,infos NTEXT DEFAULT('') NOT NULL,MimeData IMAGE);"+
					"GRANT  REFERENCES ,  SELECT ,  UPDATE ,  INSERT ,  DELETE  ON " + TableName + " TO [" + constants.UsersMailDbUsername+ "]";
				GeneralDb db = new GeneralDb(constants.SqlServerAddressUsersMailDb, constants.UsersMailDbName,
					constants.UsersMailDbUsername, constants.UsersMailDbPassword);
				SqlConnection connection = new SqlConnection(db.ConnectString);
				connection.Open();
				SqlCommand command = new SqlCommand(query, connection);
				command.ExecuteNonQuery();
				connection.Close();
				command.Dispose();
			    db.Dispose();
				return 0;
			/*}
			catch
			{
				return -3;
			}*/
		}
		//-----------------------------------------------------------------------
	}
}