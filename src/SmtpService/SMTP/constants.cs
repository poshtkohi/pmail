/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using Mime.ASCII;

namespace SMTP
{
	public class constants
	{
		public const int MaxConnections = 100;
		public const string MailDomain = "pmail.sharif.edu";
		public const int MaxNumRecipients = 10;
		public const int MuxNumLoopThreat = 100;
		public const int MaxLenRecieveData = 1024*1024*10; // Max 10 Meg data recieption
		public const string SMTPServerAddress = "pmail.sharif.edu";//"169.254.25.129";
		//----------------------------------
		public const int MaxThreadsMessageQueuing = 100;
		public const string MessageQueuingServerAddress = "pmail.sharif.edu";//"169.254.25.129";
		public const int MessageQueuingServerPort = 47123;
		public const string MessageQueuingPassword = "uFtr098VbhjuYMn045aK87CP4Wb";
		//----------------------------------
		public const string SqlServerAddressUsersMailDb = "localhost";
		public const string UsersMailDbUsername = "Yh9Lkh0Dr";
		public const string UsersMailDbPassword = "o69GhtgykKl25iiuTlQa";
		public const string UsersMailDbName = "UsersMailDb";
		//---------------------------------
		public const string SqlServerAddressAccountsDb = "localhost";
		public const string AccountsDbUsername = "Yh9Lkh0Dr";
		public const string AccountsDbPassword = "o69GhtgykKl25iiuTlQa";
		public const string AccountsDbName = "AccountsDb";
		public const string MailAccountsTableName = "MailAccounts";
		public const string EmailsDbName = "AccountsDb";
		//---------------------------------
		public static readonly AsciiString SyntaxError = new AsciiString("500");
		public static readonly AsciiString ServiceReady = new AsciiString("220");
		public static readonly AsciiString  ServiceUnavailable = new AsciiString("421");
		public static readonly AsciiString RequestOkay = new AsciiString("250");
		public static readonly AsciiString UserNotLocal = new AsciiString("551");
		public static readonly AsciiString MailBoxUnavailable = new AsciiString("550");
		public static readonly AsciiString StartMailInput = new AsciiString("354");
		public static readonly AsciiString RequestedActionNotTaken = new AsciiString("452"); //insufficient system storage 
		public static readonly AsciiString RequestedMailActionAborted = new AsciiString("552"); //exceeded storage allocation or too much mail data.
		public static readonly AsciiString  ServiceClosingTransmissionChannel =  new AsciiString("221");
		public static readonly AsciiString CRLF = new AsciiString("\r\n");
		public static readonly AsciiString CRLF_CRLF = new AsciiString("\r\n"+ "." + "\r\n");
		//---------------------------------
	}
}