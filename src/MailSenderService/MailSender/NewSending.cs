/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Net;
using System.Text;
using Mime.ASCII;
using Mime;
using Mime.MimeBuilder;
using Mime.MimeParser;
using System.Threading;
using System.Collections;
using System.Net.Sockets;
using System.ComponentModel;
using DnsUtils;

namespace MailSender
{
	//----------------------------------------------------------------------------------------------------------
	public class NewSending
	{
		private Thread thread;
		private Socket s = null;
		private byte[] buffer = null;
		private byte[] buff = null;
		private bool present = true;
		private SendingInfo info = null;
		//-----------------------------------------
		private class Response
		{
			public string field = null;
			public string ResponseString = null;
			public bool DnsResolvingSuccess = true;
			public string domain;
			public Response()
			{
			}
		}
		//-----------------------------------------
		public NewSending()
		{
		}
		//-----------------------------------------
		public bool IsPresentToNewSending
		{
			get
			{
				return this.present;
			}
		}
		//-----------------------------------------
		public void ThreadManager()
		{
			thread.Suspend();
			while(true)
			{
				this.ThreadProc();
			}
		}
		//-----------------------------------------
		public void Initialize(Thread thread)
		{
			this.thread = thread;
		}
		//-----------------------------------------
		public void ThreadResume(SendingInfo info)
		{
			this.present = false;
			this.info = info;
			this.thread.Resume();
		}
		//---------------------------------------------------------------
		private void ThreadExit()
		{
			info = null;
			buffer = buff = null;
			GC.Collect(GC.GetGeneration(this));
			this.present = true;
			this.thread.Suspend();
			return ;
		}
		//---------------------------------------------------------------
		private void ThreadProc()
		{
			string ToHost = FindMailServerHostname(this.info.To);
			string CcHost = null;
			string BccHost = null;
			if(this.info.Cc != null && this.info.Cc != "")
				CcHost = FindMailServerHostname(this.info.Cc);
			if(this.info.Bcc != null && this.info.Bcc != "")
				BccHost = FindMailServerHostname(this.info.Bcc);
			ArrayList To = new ArrayList();
			ArrayList Cc = null;
			ArrayList Bcc = null;
			if(CcHost != null)
				Cc = new ArrayList();
			if(BccHost != null)
				Bcc = new ArrayList();
			Response temp = new Response();
			temp.field = "to";
			temp.domain = this.info.To;
			To.Add(temp);
			if(CcHost != null)
			{
				temp = new Response();
				temp.field = "cc";
				temp.domain = this.info.Cc;
				if(CcHost == ToHost)
					To.Add(temp);
				if(BccHost != null && CcHost != ToHost)
					if(CcHost == BccHost)
						Bcc.Add(temp);
					else Cc.Add(temp);
			}
			if(BccHost != null)
			{
				temp = new Response();
				temp.domain = this.info.Bcc;
				temp.field = "bcc";
				if(BccHost == ToHost)
					To.Add(temp);
				if(CcHost != null && BccHost != ToHost)
					if(CcHost == BccHost)
						Cc.Add(temp);
					else Bcc.Add(temp);
			}
			SendMessage(ToHost, ref To);
			if(Cc != null)
				SendMessage(CcHost, ref Cc);
			if(Bcc != null)
				SendMessage(BccHost, ref Bcc);
			string body = null;
			for(int i = 0 ; i < To.Count ; i++)
			{
				temp = (Response)To[i];
				if(temp.ResponseString != null)
					body += String.Format("<p>{0} MailSender could not send your message to {1}.Error details: {2}</p>", constants.MailServerName, temp.domain, temp.ResponseString);
				if(!temp.DnsResolvingSuccess)
					body += String.Format("<p>{0} MailSender could not send your message to {1}.Error details: DNS Resolving Of Destination Server on {2} host.</p>", constants.MailServerName, temp.domain, FindMailServerHostname(temp.domain));
			}
			if(Cc != null)
			{
				for(int i = 0 ; i < Cc.Count ; i++)
				{
					temp = (Response)Cc[i];
					if(temp.ResponseString != null)
						body += String.Format("<p>{0} MailSender could not send your message to {1}.Error details: {2}</p>", constants.MailServerName, temp.domain, temp.ResponseString);
					if(!temp.DnsResolvingSuccess)
						body += String.Format("<p>{0} MailSender could not send your message to {1}.Error details: DNS Resolving Of Destination Server on {2} host.</p>", constants.MailServerName, temp.domain, FindMailServerHostname(temp.domain));
				}
			}
			if(Bcc != null)
			{
				for(int i = 0 ; i < Bcc.Count ; i++)
				{
					temp = (Response)Bcc[i];
					if(temp.ResponseString != null)
						body += String.Format("<p>{0} MailSender could not send your message to {1}.Error details: {2}</p>", constants.MailServerName, temp.domain, temp.ResponseString);
					if(!temp.DnsResolvingSuccess)
						body += String.Format("<p>{0} MailSender could not send your message to {1}.Error details: DNS Resolving Of Destination Server on {2} host.</p>", constants.MailServerName, temp.domain, FindMailServerHostname(temp.domain));
				}
			}
			ToHost = CcHost = BccHost = null;
			To = Cc = Bcc = null;
			temp = null;
			if(body != null) // meaning that at least one of the emails could not be sent.
			{
				MessageBuilder mb = new MessageBuilder();
				mb.From = new AsciiString(constants.MailServerName);
				mb.To = new AsciiString(info.From);
				mb.Date = DateTime.Now;
				mb.Subject = new AsciiString(String.Format("Undelivery Mail Message From {0} Mail Server.", constants.MailServerName));
				Text text = new Text();
				text.Charset = Mime.Headrs.Charset.UTF8;
				text.ContentTransferEncoding = Mime.Headrs.TransferEncoding.QuotedPrintable;
				text.Source = Mime.EncoderDecoder.QuotedPrintableEncode(new AsciiString(body));
				text.ContentType = Mime.Headrs.ContentType.TextHtml;
				mb.AddText(text);
				body = null;
				MessageParser mp = new MessageParser(mb.BuildMessageBody());
				try
				{
					Database db = new Database(constants.SqlServerAddressUsersMailDb, constants.UsersMailDbName,
						constants.UsersMailDbUsername, constants.UsersMailDbPassword);
					db.SendUndeliveryMessage(FindUsernameFromMailAddress(this.info.From), mp);
					db.Dispose();
					ThreadExit();
					return ;
				}
				catch
				{
					ThreadExit();
					return ;
				}
			}
			else
			{
				ThreadExit();
				return ;
			}
		}
		//-----------------------------------------
		private void SendMessage(string Host, ref ArrayList To)
		{
			ArrayList RecordsIP = MxRecordsIPHostEntry(Host);
			if(RecordsIP == null)
			{
				ArrayList to = new ArrayList();
				for(int i = 0 ; i < To.Count ; i++)
				{
					Response temp = (Response)To[i];
					temp.DnsResolvingSuccess = false;
					to.Add(temp);
				}
				To = to;
				return ;
			}
			bool first = true;
			IPAddress ip = ((IPHostEntry)RecordsIP[0]).AddressList[0];
		Start:
			s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint hostEndPointTo = new IPEndPoint(ip, 25);
			try
			{
				s.Connect(hostEndPointTo);
			}
			catch
			{
				if(RecordsIP.Count == 2 && first)
				{
					first = false;
					ip = ((IPHostEntry)RecordsIP[1]).AddressList[0];
					s.Close();
					goto Start;
				}
				else
				{
					ArrayList to = new ArrayList();
					for(int i = 0 ; i < To.Count ; i++)
					{
						Response temp = (Response)To[i];
						temp.ResponseString = String.Format("{0} MailSender Server could not connect and send your message to {1} Mail Server.", constants.MailServerName, Host) ;
						to.Add(temp);
					}
					To = to;
					s.Close();
					return ;
				}
			}
			buffer = new byte[4096];
			string response = "";
			ArrayList to1 = null;
			try
			{
				int n = s.Receive(buffer, 0, buffer.Length, 0);
				if(n == 0) {goto End;}
				response = BinaryToStringASCII(buffer, n);
				if(response.IndexOf(constants.ServiceClosingTransmissionChannel) >=0 || response.IndexOf(constants.ServiceUnavailable) >= 0) {n = 0; goto End;}
				if(response.IndexOf(constants.ServiceReady) < 0)
				{
					response = "The destination server told that its service is not ready.";
					goto End;
				}
				buff = StringToBinaryASCII("HELO " + constants.MailDomain.ToUpper() + "\r\n");
				n = s.Send(buff, 0, buff.Length, 0);
				if(n == 0) {goto End;}
				n = s.Receive(buffer, 0, buffer.Length, 0);
				if(n == 0) {goto End;}
				response = BinaryToStringASCII(buffer, n);
				if(response.IndexOf(constants.ServiceClosingTransmissionChannel) >=0 || response.IndexOf(constants.ServiceUnavailable) >= 0) {n = 0; goto End;}
				if(response.IndexOf(constants.RequestOkay) < 0)
				{
					response = String.Format("The {0} Mail Server told to {1} MailSender this error during sending your email: {2}", Host, constants.MailServerName, response);
					if(first && RecordsIP.Count == 2)
					{
						ip = ((IPHostEntry)RecordsIP[1]).AddressList[0];
						first = false;
						s.Close();
						goto Start; // here, we try a new connection , if there are second Mail Mx IP
					}
					goto End;
				}
				//---MAIL FROM---------------------------------------
				buff = StringToBinaryASCII(String.Format("MAIL FROM: <{0}>\r\n", this.info.From));
				n = s.Send(buff, 0, buff.Length, 0);
				if(n == 0) {goto End;}
				n = s.Receive(buffer, 0, buffer.Length, 0);
				if(n == 0) {goto End;}
				response = BinaryToStringASCII(buffer, n);
				if(response.IndexOf(constants.ServiceClosingTransmissionChannel) >=0 || response.IndexOf(constants.ServiceUnavailable) >= 0) {n = 0; goto End;}
				if(response.IndexOf(constants.RequestOkay) < 0)
				{
					response = String.Format("The {0} Mail Server told to {1} MailSender this error during sending your email: {2}", Host, constants.MailServerName, response);
					goto End;
				}
				//---RCPT TO-----------------------------------------
				int v = 0;
				for(int i = 0 ; i < To.Count ; i++)
				{
					Response r = (Response)To[i];
					buff = StringToBinaryASCII(String.Format("RCPT TO: <{0}>\r\n", r.domain));
					n = s.Send(buff, 0, buff.Length, 0);
					if(n == 0) {goto End;}
					n = s.Receive(buffer, 0, buffer.Length, 0);
					if(n == 0) {goto End;}
					response = BinaryToStringASCII(buffer, n);
					if(response.IndexOf(constants.ServiceClosingTransmissionChannel) >=0 || response.IndexOf(constants.ServiceUnavailable) >= 0) {n = 0; goto End;}
					if(response.IndexOf(constants.RequestOkay) < 0)
					{
						response = String.Format("The {0} Mail Server told to {1} MailSender this error during sending your email: {2}", Host, constants.MailServerName, response);
						to1 = new ArrayList();
						for(int j = 0 ; j < To.Count ; j++)
						{
							Response temp = (Response)To[j];
							if(temp.domain == r.domain)
								temp.ResponseString = response;
							to1.Add(temp);
						}
						To = to1;
						v++;
					}
				}
				//---DATA--------------------------------------------
				if(v == To.Count) { QuitHandle(); return; }
				buff = StringToBinaryASCII("DATA\r\n");
				n = s.Send(buff, 0, buff.Length, 0);
				if(n == 0) {goto End;}
				n = s.Receive(buffer, 0, buffer.Length, 0);
				if(n == 0) {goto End;}
				response = BinaryToStringASCII(buffer, n);
				if(response.IndexOf(constants.ServiceClosingTransmissionChannel) >=0 || response.IndexOf(constants.ServiceUnavailable) >= 0) {n = 0; goto End;}
				if(response.IndexOf(constants.StartMailInput) < 0)
				{
					response = String.Format("The {0} Mail Server told to {1} MailSender this error during sending your email: {2}", Host, constants.MailServerName, response);
					goto End;
				}
				if(this.info.MimeData.Length <= 4096)
				{
					n = s.Send(this.info.MimeData.BaseStream, 0, this.info.MimeData.Length, 0);
					if(n == 0) {goto End;}
				}
				else
				{
					int i = 0;
					int a = this.info.MimeData.Length / 4096;
					int q = this.info.MimeData.Length % 4096;
					while(true)
					{
						n = s.Send(this.info.MimeData.BaseStream, 4096*i, 4096, 0);
						if(n == 0) {goto End;}
						i++;
						if(q != 0 && i == a)
						{
							n = s.Send(this.info.MimeData.BaseStream, 4096*i, q, 0);
							if(n == 0) {goto End;}
							break;
						}
						if(q == 0 && i == a)
						{
							break;
						}
					}
				}
				buff = StringToBinaryASCII("\r\n.\r\n");
				n = s.Send(buff, 0, buff.Length, 0);
				if(n == 0) {goto End;}
				n = s.Receive(buffer, 0, buffer.Length, 0);
				if(n == 0) {goto End;}
				response = BinaryToStringASCII(buffer, n);
				if(response.IndexOf(constants.ServiceClosingTransmissionChannel) >=0 || response.IndexOf(constants.ServiceUnavailable) >= 0) {n = 0; goto End;}
				if(response.IndexOf(constants.RequestOkay) < 0)
				{
					response = String.Format("The {0} Mail Server told to {1} MailSender this error during sending your email: {2}", Host, constants.MailServerName, response);
					goto End;
				}
				//---QUIT--------------------------------------------
				QuitHandle();
				//s.Close();
				buffer = buff = null;
				RecordsIP = null;
				response = null;
				s = null;
				hostEndPointTo = null;
				to1 = null;
				return ;
				//---------------------------------------------------
			End:
				if(n != 0) {QuitHandle();}
				s.Close();
				if(n == 0)
					response = String.Format("{0} MailSender Server could not send your message to {1} Mail Server. Since the destination server closed the connection suddenly.", constants.MailServerName, Host);
				to1 = new ArrayList();
				for(int i = 0 ; i < To.Count ; i++)
				{
					Response temp = (Response)To[i];
					temp.ResponseString = response;
					to1.Add(temp);
				}
				To = to1;
				buffer = buff = null;
				RecordsIP = null;
				response = null;
				s = null;
				to1 = null;
				return ;
			}
			catch
			{
				s.Close();
				s = null;
				RecordsIP = null;
				buffer = buff = null;
				ip = null;
				hostEndPointTo = null;
				ArrayList to = new ArrayList();
				for(int i = 0 ; i < To.Count ; i++)
				{
					Response temp = (Response)To[i];
					temp.ResponseString = String.Format("{0} MailSender Server send your message to {1} Mail Server, since the destination server closed the connection.", constants.MailServerName, Host) ;
					to.Add(temp);
				}
				To = to;
				to = null;
				response = null;
				to1 = null;
				return ;
			}
		}
		//-----------------------------------------
		private void QuitHandle()
		{
			buff = StringToBinaryASCII("QUIT\r\n");
			int n = s.Send(buffer, 0, buffer.Length, 0);
			if(n != 0)  s.Receive(buffer, 0, buffer.Length, 0);
			s.Close();
			return ;
		}
		//-----------------------------------------
		private ArrayList MxRecordsIPHostEntry(string Host)
		{
			ArrayList HostExchange = new ArrayList();
			try
			{
				string[] results = DnsMx.GetMXRecords(Host);
				if(results != null)
				{
					for(int i = 0 ; i < results.Length && i < 2 ;i++) 
					{
						HostExchange.Add(results[i]);
						Console.WriteLine(results[i]);
					}
				}
				else
				{
					HostExchange.Add(Host);
				}
				results = null;
			}
			catch
			{
				HostExchange.Add(Host);
			}
			IPHostEntry hostInfo = null;
			ArrayList HostInfo = new ArrayList();
			try
			{
				hostInfo = Dns.Resolve((string)HostExchange[0]);
				HostInfo.Add(hostInfo);
				if(HostExchange.Count == 2)
				{
					try
					{
						hostInfo = Dns.Resolve((string)HostExchange[1]);
						HostInfo.Add(hostInfo);
						return HostInfo;
					}
					catch
					{
						return HostInfo;
					}
				}
				else
				{
					return HostInfo;
				}
			}
			catch
			{
				if(HostExchange.Count == 1)
				{
					HostExchange = null;
					return null;
				}
				else
				{
					try
					{
						hostInfo = Dns.Resolve((string)HostExchange[1]);
						HostInfo.Clear();
						HostInfo.Add(hostInfo);
						return HostInfo;
					}
					catch
					{
						HostExchange = null;
						return null;
					}
				}
			}
		}
		//-----------------------------------------
		private string FindUsernameFromMailAddress(string address)
		{
			int p = address.LastIndexOf('@');
			return address.Substring(0, p);
		}
		//-----------------------------------------
		private string FindMailServerHostname(string domain)
		{
			int p = domain.LastIndexOf('@');
			return domain.Substring(p + 1);
		}
		//-----------------------------------------
		private static string BinaryToStringASCII(byte[] buffer, int len)
		{
			ASCIIEncoding ascii = new ASCIIEncoding();
			return ascii.GetString(buffer, 0, len);
		}
		//-----------------------------------------
		private static byte[] StringToBinaryASCII(string buffer)
		{
			ASCIIEncoding ascii = new ASCIIEncoding();
			return ascii.GetBytes(buffer); 
		}
		//-----------------------------------------
	}
	//----------------------------------------------------------------------------------------------------------
}