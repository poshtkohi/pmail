/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;

namespace Cyber.email
{
	public class constants
	{
		public const string MailDomain = "pmail.sharif.edu";
		public const int MaxNumRecipients = 10;
		public const int MuxNumLoopThreat = 100;
		public const int MaxLenRecieveData = 1024*1024*10; // Max 10 Meg data recieption
		//----------------------------------
		public const string MessageQueuingServerMailSenderAddress = "pmail.sharif.edu";//"169.254.25.129";
		public const int MessageQueuingServerMailSenderPort = 47012;
		public const string MessageQueuingPassword = "uFtr098VbhjuYMn045aK87CP4Wb";
		//--------
		public const string MessageQueuingServerSMTPAddress = "pmail.sharif.edu";//"169.254.25.129";
		public const int MessageQueuingServerSMTPPort = 47123;
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
		public const string AccountsTableName = "Accounts";
	   //---------------------------------
		public const string SqlServerAddressComposeDb = "localhost";
		public const string ComposeDbUsername = "Yh9Lkh0Dr";
		public const string ComposeDbPassword = "o69GhtgykKl25iiuTlQa";
		public const string ComposeDbName = "ComposeDb";
		public const string QueueTableName = "QueueTable";
		//---------------------------------
	}
}