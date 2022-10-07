/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;

namespace MailSender
{
	public class constants
	{
		public const int MaxThreads = 100;
		public const string MailDomain = "pmail.sharif.edu";
		public const string MailServerName = "Cyber";
		//----------------------------------
		public const int MaxThreadsMessageQueuing = 100;
		public const string MessageQueuingServerAddress = "169.254.25.129";
		public const int MessageQueuingServerPort = 47012;
		public const string MessageQueuingPassword = "uFtr098VbhjuYMn045aK87CP4Wb";
		//----------------------------------
		public const string SqlServerAddressComposeDb = "localhost";
		public const string ComposeDbUsername = "Yh9Lkh0Dr";
		public const string ComposeDbPassword = "o69GhtgykKl25iiuTlQa";
		public const string ComposeDbName = "ComposeDb";
		public const string QueueTableName = "QueueTable";
		//----------------------------------
		public const string SqlServerAddressUsersMailDb = "localhost";
		public const string UsersMailDbUsername = "Yh9Lkh0Dr";
		public const string UsersMailDbPassword = "o69GhtgykKl25iiuTlQa";
		public const string UsersMailDbName = "UsersMailDb";
		//---------------------------------
		public static string SyntaxError = "500";
		public static string ServiceReady = "220";
		public static string ServiceUnavailable = "421";
		public static string RequestOkay = "250";
		public static string UserNotLocal = "551";
		public static string MailBoxUnavailable = "550";
		public static string StartMailInput = "354";
		public static string RequestedActionNotTaken = "452"; //insufficient system storage 
		public static string RequestedMailActionAborted = "552"; //exceeded storage allocation or too much mail data.
		public static string ServiceClosingTransmissionChannel =  "221";
		public static string CRLF = "\r\n";
		public static string CRLF_CRLF = "\r\n"+ "." + "\r\n";
		//---------------------------------
	}
}