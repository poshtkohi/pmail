/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;

//comsider try , catches
namespace SMTP
{
	public class NewConnection
	{
		private Thread thread;
		private Socket s;
		private Trie t;
		private string DefaultProtcol = "ESMTP";
		private const string SyntaxError = "500";
		private const string ServiceReady = "220";
		private const string  ServiceUnavailable = "421";
		private const string RequestOkay = "250";
		private const string StartMailInput = "354";
		private const string  ServiceClosingTransmissionChannel =  "221";
		private const string CRLF = "\r\n";
		private const string CRLF_CRLF = "\r\n"+ "." + "\r\n";
		private byte[] buffer = new byte[4096];
		private byte[] buff = null;
		//---------------------------------------------------------------
		public NewConnection()
		{
			this.s = null;
			this.thread = null;
		}
		//---------------------------------------------------------------
		public void Initialize(Trie t, Socket s, Thread thread)
		{
			this.t = t;
			this.s = s;
			this.thread = thread;
			this.DefaultProtcol = this.DefaultProtcol;
		}
		//---------------------------------------------------------------
		public void ThreadProc()
		{
			/*try
			{*/
			int n = 0;
			/* consider in this section , can we accept new connection with now our system resources */
			buff = StringToBinaryASCII(ServiceReady + CRLF);
			n = s.Send(buff, 0, buff.Length, 0);
			if(n == 0) {goto End;}
			n = s.Receive(buffer, 0, buffer.Length, 0); // recieve HELO
			if(n == 0) {goto End;}
			ProtocolType(buffer); // Check HELO (cosnider protcol SMTP or ESMTP support here)
			CheckBadCRLF(buffer, n); // Check CRLF
			buff = StringToBinaryASCII(RequestOkay + " OK-MySoPlus Mail Server" + CRLF); //Respond with 250 OK
			n = s.Send(buff, 0, buff.Length, 0);
			if(n == 0) {goto End;}
			n = s.Receive(buffer, 0, buffer.Length, 0);// Recieve MAIL FROM (consider AntiSpam here and deny if spamming)
			if(n == 0) {goto End;}
			string mailfrom =  MailFromRCPTTO(buffer, n, true); // Extract MAIL FROM destination (consider if mailfrom is null or empty)
			buff = StringToBinaryASCII(RequestOkay + " OK" + CRLF);
			n = s.Send(buff, 0, buff.Length, 0);
			if(n == 0) {goto End;}
			Hashtable mailtos = new Hashtable();
			bool DataIsStarting = true;
			for(int i = 0, j = 0 ; ; i++)  // here we go in a loop for all RCPT TO (consider how many we can support in e session and are there the account on server?)
			{
				n = s.Receive(buffer, 0, buffer.Length, 0); // recieve one RCPT TO
				if(n == 0) {goto End;}
				string mailto =  MailFromRCPTTO(buffer, n, false);
				if(mailto != null && mailto != "")
				{

					//Console.WriteLine(mailto);
					mailtos.Add(j, mailto);
					buff = StringToBinaryASCII(RequestOkay + " OK" + CRLF); //Respond with 250 OK
					n = s.Send(buff, 0, buff.Length, 0);
					if(n == 0) {goto End;}
					j++;
				}
				if(mailto == null)
				{
					DataIsStarting = false;// meaning that the DATA is starting
					break;
				}
			}
			//after the RCPTTO loop, we recognize next Request from client meaning DATA(consider Maximum length for reciveing and the user Mail Box space length)
			DataHandle(n, DataIsStarting);
			//now we must recieve QUIT from client in this Scenario
			QuitHandle();
			return ;
		End:
			ThreadExit();
			return ;
		/*}
		 catch{}*/
		}
		//---------------------------------------------------------------
		private void ThreadExit()
		{
			this.s.Close();
			this.thread.Abort();
			return ;
		}
		//---------------------------------------------------------------
		private void QuitHandle()
		{
			int n = s.Receive(buffer, 0, buffer.Length, 0);
			if(n == 0) { ThreadExit(); return ;}
			string quit = BinaryToStringASCII(buffer, n);
			if(quit.IndexOf("QUIT", 0, 4) < 0) {goto End;}
			else goto End;
		End:
			buff = StringToBinaryASCII( ServiceClosingTransmissionChannel + CRLF);
			s.Send(buff, 0, buff.Length, 0);
			ThreadExit();
			return ;
		}
		//---------------------------------------------------------------
		private void DataHandle(int n, bool first)
		{
			if(first)
			{
				n = s.Receive(buffer, 0, buffer.Length, 0);
				if(n == 0) { ThreadExit(); return ;}
			}
			string DATA = BinaryToStringASCII(buffer, n);
			CheckBadCRLF(buffer, n);
			if(DATA.IndexOf("DATA" , 0, 4) < 0) {goto End;}
			buff = StringToBinaryASCII(StartMailInput + CRLF);
			n = s.Send(buff, 0, buff.Length, 0);
			if(n == 0) {goto End;}
			// now we must read the DATA buffer and consider CRLF.CRLF for quitting the read operation
			//(consider file exeptions (put proper Try Catches))
			FileStream fs = new FileStream(@"c:\mail.eml", FileMode.Create, FileAccess.Write, FileShare.None);
			int i = 0; // i is , if the data is broken in first reading or no
			while(true)
			{
				n = s.Receive(buffer, 0, buffer.Length, 0);
				if(n == 0){ break; }
				string clrf_clrf = BinaryToStringASCII(buffer, n);
				fs.Write(buffer, 0, n);
				i++;
				if(clrf_clrf.IndexOf(CRLF_CRLF) > 0) break;
			}
			fs.Close();
			//if(i == 0) File.Delete(@"c:\mail.eml"); // (consider in this case, we must not insert these file address on to our SQL Database)
			buff = StringToBinaryASCII(RequestOkay + " OK" + CRLF);
			n = s.Send(buff, 0, buff.Length, 0);
			if(n == 0) {goto End;}
			return ;
		End:
			buff = StringToBinaryASCII(SyntaxError + CRLF);
			s.Send(buff, 0, buff.Length, 0);
			ThreadExit();
			return ;
		}
		//---------------------------------------------------------------
		private string MailFromRCPTTO(byte[] buffer, int n, bool FromSession)
		{
			string mailfrom = BinaryToStringASCII(buffer, n);
			Console.WriteLine(mailfrom);
			CheckBadCRLF(buffer, n);
			if(FromSession) { if(mailfrom.IndexOf("MAIL FROM",0, 10 ) < 0) {goto End;} }
			else {if(mailfrom.IndexOf("RCPT TO", 0 ) < 0) {return null;} }
			mailfrom = EctractMailFrom(mailfrom);
			if(mailfrom == null) {goto End;}
			else return mailfrom;
		End:
				buff = StringToBinaryASCII(SyntaxError + CRLF);
				s.Send(buff, 0, buff.Length, 0);
			    if(FromSession) { ThreadExit(); return null; }
			    else return "";
		}
		//---------------------------------------------------------------
		private string EctractMailFrom(string buffer)
	    {
			//if(buffer.IndexOf("@") < 0) {return null;}
			int p1 = buffer.IndexOf("<");
			if(p1 < 0) {return null;}
			int p2 = buffer.IndexOf(">");
			if(p2 < 0 || p2 < p1) {return null;}
			return buffer.Substring(p1 + 1, p2 - p1 - 1);
		}
		//---------------------------------------------------------------
		private void CheckBadCRLF(byte[] buffer, int n)
		{
			string crlf = BinaryToStringASCII(buffer, n);
			if(crlf.IndexOf(CRLF) < 0)
			{
				buff = StringToBinaryASCII(SyntaxError + CRLF);
				s.Send(buff, 0, buff.Length, 0);
				ThreadExit();
				return ;
			}
			else return ;
		}
		//---------------------------------------------------------------
		private void ProtocolType(byte[] buffer)
		{
			string protocol = BinaryToStringASCII(buffer, 10);
			protocol = protocol.ToLower(); 
			if(protocol.IndexOf("ehlo") >= 0) {return ;}
			if(protocol.IndexOf("helo") >= 0)
			{
				DefaultProtcol = "SMTP";
				return ;
			}
			else
			{
				buff = StringToBinaryASCII(SyntaxError + CRLF);
				s.Send(buff, 0, buff.Length, 0);
				ThreadExit();
				return ;
			}
		}
		//---------------------------------------------------------------
		private string FindRemoteIP()
		{
			return ((IPEndPoint)s.RemoteEndPoint).Address.ToString();
		}
		//---------------------------------------------------------------
		private string FindLocalIP()
		{
			return ((IPEndPoint)s.LocalEndPoint).Address.ToString();
		}
		//---------------------------------------------------------------
		private static string BinaryToStringASCII(byte[] buffer, int len)
		{
			ASCIIEncoding ascii = new ASCIIEncoding();
			return ascii.GetString(buffer, 0, len);
		}
		//---------------------------------------------------------------
		private static byte[] StringToBinaryASCII(string buffer)
		{
			ASCIIEncoding ascii = new ASCIIEncoding();
			return ascii.GetBytes(buffer); 
		}
		//---------------------------------------------------------------
	}
}