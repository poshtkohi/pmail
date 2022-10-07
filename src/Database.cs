/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.IO;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Collections;
using System.Net;
using System.Xml;
using System.Net.Sockets;
using Cyber.email.HtmlComponents;

namespace pmail
{
	//--------------------------------------------------------------------------------------------------------
	public class Database
	{
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
		public int AuthorizationPage(int code, int cert, Page page)
		{
			/*try
			{*/
				SqlConnection connection = new SqlConnection(this.ConnectString);
				connection.Open();
				SqlCommand command = connection.CreateCommand();
				command.Connection = connection;
				command.CommandText = String.Format("SELECT code FROM {0} WHERE code={1} AND cert='{2}'", constants.StudentsTableName, code, cert);
				SqlDataReader read = command.ExecuteReader();
				if(read.HasRows)
				{
					read.Close();
					connection.Close();
					command.Dispose();
					page.Session.Add("Authorized", true);
					return 0;
				}
				else
				{
					read.Close();
					connection.Close();
					command.Dispose();
					return -1;
				}
			/*}
			catch
			{
				return -3;
			}*/
		}
		//---------------------------------------------------------------------------
		public int SignUpPage(SignUpInfo info)
		{
			/*try
			{*/
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.Connection = connection;
			command.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE username='{1}'", constants.AccountsTableName, info.Username);
			SqlDataReader read = command.ExecuteReader();
			read.Read();
			int count = read.GetInt32(0);
			if(count == 1)
			{
				read.Close();
				connection.Close();
				command.Dispose();
				return -1;
			}
			read.Close();
			connection.Close();
			connection = new SqlConnection(this.ConnectString);
			connection.Open();
			command = connection.CreateCommand();
			command.Connection = connection;
			command.CommandText = String.Format("INSERT INTO {0} (FirstName,LastName,username,password,email,country,profession,sex,EmailSqlAddress,BlogSqlAddress,GroupsSqlAddress,OpenSourceSqlAddress,BirthDate,ZipCode,SecurityQuestion,answer,phone) VALUES(@FirstName,@LastName,@username,@password,@email,@country,@profession,@sex,@EmailSqlAddress,@BlogSqlAddress,@GroupsSqlAddress,@OpenSourceSqlAddress,@BirthDate,@ZipCode,@SecurityQuestion,@answer,@phone)", constants.AccountsTableName);
			SqlParameter FirstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar);
			SqlParameter LastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar);
			SqlParameter usernameParam = new SqlParameter("@username", SqlDbType.VarChar);
			SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.VarChar);
			SqlParameter emailParam = new SqlParameter("@email", SqlDbType.VarChar);
			SqlParameter countryParam = new SqlParameter("@country", SqlDbType.VarChar);
			SqlParameter professionParam = new SqlParameter("@profession", SqlDbType.VarChar);
			SqlParameter sexParam = new SqlParameter("@sex", SqlDbType.Bit);
			SqlParameter EmailSqlAddressParam = new SqlParameter("@EmailSqlAddress", SqlDbType.VarChar);
			SqlParameter BlogSqlAddressParam = new SqlParameter("@BlogSqlAddress", SqlDbType.VarChar);
			SqlParameter GroupsSqlAddressParam = new SqlParameter("@GroupsSqlAddress", SqlDbType.VarChar);
			SqlParameter OpenSourceSqlAddressParam = new SqlParameter("@OpenSourceSqlAddress", SqlDbType.VarChar);
			SqlParameter BirthDateParam = new SqlParameter("@BirthDate", SqlDbType.DateTime);
			SqlParameter ZipCodeParam = new SqlParameter("@ZipCode", SqlDbType.VarChar);
			SqlParameter SecurityQuestionParam = new SqlParameter("@SecurityQuestion", SqlDbType.VarChar);
			SqlParameter answerParam = new SqlParameter("@answer", SqlDbType.NVarChar);
			SqlParameter phoneParam = new SqlParameter("@phone", SqlDbType.VarChar);
			FirstNameParam.Value = info.FirstName;
			LastNameParam.Value = info.LastName;
			usernameParam.Value = info.Username;
			passwordParam.Value = info.Password;
			emailParam.Value = info.Email;
			countryParam.Value = info.Country;
			professionParam.Value = info.Profession;
			sexParam.Value = info.Sex;
			EmailSqlAddressParam.Value = "";
			BlogSqlAddressParam.Value = "";
			GroupsSqlAddressParam.Value = "";
			OpenSourceSqlAddressParam.Value = "";
			BirthDateParam.Value = info.BirthDate;
			ZipCodeParam.Value = info.ZipCode;
			SecurityQuestionParam.Value = info.SecurityQuestion;
			answerParam.Value = info.Answer;
			phoneParam.Value = info.Phone;
			command.Parameters.Add(FirstNameParam);
			command.Parameters.Add(LastNameParam);
			command.Parameters.Add(usernameParam);
			command.Parameters.Add(passwordParam);
			command.Parameters.Add(emailParam);
			command.Parameters.Add(countryParam);
			command.Parameters.Add(professionParam);
			command.Parameters.Add(sexParam);
			command.Parameters.Add(EmailSqlAddressParam);
			command.Parameters.Add(BlogSqlAddressParam);
			command.Parameters.Add(GroupsSqlAddressParam);
			command.Parameters.Add(OpenSourceSqlAddressParam);
			command.Parameters.Add(BirthDateParam);
			command.Parameters.Add(ZipCodeParam);
			command.Parameters.Add(SecurityQuestionParam);
			command.Parameters.Add(answerParam);
			command.Parameters.Add(phoneParam);
			command.ExecuteNonQuery();
			connection.Close();
			command.Dispose();
			return 0;
			/*}
			catch
			{
				return -3;
			}*/
		}
		//---------------------------------------------------------------------------
		public int SignInPage(string username, string password, Page page)
		{
			/*try
			{*/
			SqlConnection connection = new SqlConnection(this.ConnectString);
			connection.Open();
			SqlCommand command = connection.CreateCommand();
			command.Connection = connection;
			command.CommandText = String.Format("SELECT i,EmailSqlAddress,BlogSqlAddress FROM {0} WHERE username='{1}' AND password='{2}'", constants.AccountsTableName, username, password);
			SqlDataReader read = command.ExecuteReader();
			if(read.HasRows)
			{
				read.Read();
				page.Session["iAccounts"] = read.GetInt64(0).ToString();
				page.Session["EmailSqlAddress"] = read.GetString(1);
				page.Session["BlogSqlAddress"] = read.GetString(2);
				read.Close();
				connection.Close();
				command.Dispose();
				page.Session["username"] = username;
				return 0;
			}
			else
			{
				read.Close();
				connection.Close();
				command.Dispose();
				return -1;
			}
			/*}
			catch
			{
				return -3;
			}*/
		}
		//---------------------------------------------------------------------------
		//---------------------------------------------------------------------------
		//---------------------------------------------------------------------------
	}
	//--------------------------------------------------------------------------------------------------------
}