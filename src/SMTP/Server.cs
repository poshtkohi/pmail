/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Net;
using System.Text;
using Mime.ASCII;
using Mime.MimeParser;
using System.Threading;
using System.Collections;
using System.Net.Sockets;
using System.ComponentModel;

//consider try , catches
namespace SMTP
{
	public class NewConnection
	{
		private Thread thread;
		private Socket s;
		private Trie t;// coider t for much connections
		private string DefaultProtcol = "ESMTP";
		private byte[] buffer = null;
		private byte[] buff = null;
		private ArrayList connections = null;
		private Component component = new Component();
		private bool disposed = false;
		//---------------------------------------------------------------
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		//---------------------------------------------------------------
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
		//---------------------------------------------------------------
		~NewConnection()      
		{
			Dispose(false);
		}
		//---------------------------------------------------------------
		public NewConnection(Socket client, ref Trie t,ref ArrayList connections)
		{
			this.connections = connections;
			this.connections.Add(this);
			this.t = t;
			this.s = client;
			this.thread = new Thread(new ThreadStart(this.ThreadProc));
			this.thread.Start();
			this.DefaultProtcol = this.DefaultProtcol;
		}
		//---------------------------------------------------------------
		private void ThreadProc()
		{
			/*try
			{*/
			buffer = new byte[4096];
			int n = 0;
			/* consider in this section , can we accept new connection with now our system resources */
			buff = (constants.ServiceReady + constants.CRLF).BaseStream;
			try
			{
				n = s.Send(buff, 0, buff.Length, 0);
			}
			catch
			{
				goto End;
			}
			if(n == 0) {goto End;}
			try
			{
				n = s.Receive(buffer, 0, buffer.Length, 0); // recieve HELO
			}
			catch
			{
				goto End;
			}
			if(n == 0) {goto End;}
			ProtocolType(buffer); // Check HELO (cosnider protcol SMTP or ESMTP support here)
			CheckBadCRLF(buffer, n); // Check CRLF
			buff = (constants.RequestOkay + new AsciiString(" OK-Mime Mail Server(C)2005.Mr.Alireza Poshtkoohi.") + constants.CRLF).BaseStream; //Respond with 250 OK
			try
			{
				n = s.Send(buff, 0, buff.Length, 0);
			}
			catch
			{
				goto End;
			}
			if(n == 0) {goto End;}
			try
			{
				n = s.Receive(buffer, 0, buffer.Length, 0);// Recieve MAIL FROM (consider AntiSpam here and deny if spamming)
			}
			catch
			{
				goto End;
			}
			if(n == 0) {goto End;}
			string from = null; // complete MAIL FROM header for showing in web based application to user
			string mailfrom =  MailFromRCPTTO(buffer, n, true, ref from); // Extract MAIL FROM destination (consider if mailfrom is null or empty)
			buff = (constants.RequestOkay + new AsciiString(" OK") + constants.CRLF).BaseStream;
			try
			{
				n = s.Send(buff, 0, buff.Length, 0);
			}
			catch
			{
				goto End;
			}
			if(n == 0) {goto End;}
			Hashtable mailtos = new Hashtable(); //mailtos, sum of MailTo 
			bool DataIsStarting = true;
			for(int i = 0, j = 0 ; ; i++)  // here we go in a loop for all RCPT TO (consider how many we can support in e session and are there the account on server?)
			{
				if(i >= constants.MuxNumLoopThreat)
				{
					/////here consider logging who attack to us more than MuxNumLoopThreat TCP/IP packet sending
					buff = (constants.ServiceClosingTransmissionChannel + constants.CRLF).BaseStream; //Respond with 221 ServiceClosingTransmissionChannel  
					try
					{
						s.Send(buff, 0, buff.Length, 0);
					}
					catch
					{
						goto End;
					}
					goto End;
				}
				try
				{
					n = s.Receive(buffer, 0, buffer.Length, 0); // recieve one RCPT TO
				}
				catch
				{
					goto End;
				}
				if(n == 0) {goto End;}
				string mailto =  MailFromRCPTTO(buffer, n, false, ref from);
				if(mailto != null && mailto != "")
				{
					int p = mailto.IndexOf("@");
					if(p < 0)
					{
						buff = (constants.SyntaxError + constants.CRLF).BaseStream; //Respond 500 since MAILTO havent @
						try
						{
							n = s.Send(buff, 0, buff.Length, 0);
						}
						catch
						{
							goto End;
						}
						goto End;
					}
					string server = mailto.Substring(p + 1);
					string username = mailto.Substring(0, p);
					if(server!= constants.MailDomain)
					{
						buff = (constants.MailBoxUnavailable + constants.CRLF).BaseStream; //Respond 550 MailBoxUnavailable
						try
						{
							n = s.Send(buff, 0, buff.Length, 0);
						}
						catch
						{
							goto End;
						}
						if(n == 0) {goto End;}
						continue;
					}
					if(mailtos.ContainsKey(username))
						continue;
					if(t.FindCompleteUsername(username))
					{
						/* we investigate that is empty mail box of the account  */
						UsersEmailInfo data = (UsersEmailInfo) t.FindAccountData(username);
						if(data.MaxBoxSize <= data.CurrentBoxSize)
						{
							////Console.WriteLine("out of box size.");//////
							buff = (constants.RequestedActionNotTaken + constants.CRLF).BaseStream; //Respond with 452 insufficient system storage
							try
							{
								n = s.Send(buff, 0, buff.Length, 0);
							}
							catch
							{
								goto End;
							}
							if(n == 0) {goto End;}
							continue;
						}
						mailtos.Add(username, data);
						buff = (constants.RequestOkay + new AsciiString(" OK") + constants.CRLF).BaseStream; //Respond with 250 OK
						try
						{
							n = s.Send(buff, 0, buff.Length, 0);
						}
						catch
						{
							goto End;
						}
						if(n == 0) {goto End;}
						if(j == constants.MaxNumRecipients + 1)
						{
							buff = (constants.RequestedActionNotTaken + constants.CRLF).BaseStream; //Respond with 452 Too many recipients  
							try
							{
								n = s.Send(buff, 0, buff.Length, 0);
							}
							catch
							{
								goto End;
							}
							if(n == 0) {goto End;}
							continue;
						}
					    else j++;
					}
					else
					{
						buff = (constants.UserNotLocal + constants.CRLF).BaseStream; //Respond 551 User not local; please try <forward-path>
						try
						{
							n = s.Send(buff, 0, buff.Length, 0);
						}
						catch
						{
							goto End;
						}
						if(n == 0) {goto End;}
						continue;
					}
				}
				if(mailto == null)
				{
					DataIsStarting = false;// meaning that the DATA is starting
					break;
				}
			}
			Console.WriteLine("data startin");//
			//after the RCPTTO loop, we recognize next Request from client meaning DATA(consider Maximum length for reciveing and the user Mail Box space length)
			DataHandle(mailtos, from, n, DataIsStarting);
			//now we must recieve QUIT from client in this Scenario
			QuitHandle();
			return ;
		End:
			mailtos = null;
			from = null ; 
			mailfrom = null;
			ThreadExit();
			return ;
		/*}
		 catch{}*/
		}
		//---------------------------------------------------------------
		private void ThreadExit()
		{
			//this.s.Shutdown(SocketShutdown.Both);
			this.s.Close();
			this.s = null;
			this.buffer = this.buff = null;
			this.thread = null;
			this.connections.Remove(this);
			GC.Collect();
			return ;
		}
		//---------------------------------------------------------------
		private void QuitHandle()
		{
			Console.WriteLine("QQQQ");
			int n = 0 ;
			try
			{
				n = s.Receive(buffer, 0, buffer.Length, 0);
			}
			catch
			{
				ThreadExit();
				return ;
			}
			if(n == 0) { ThreadExit(); return ;}
			string quit = BinaryToStringASCII(buffer, n);
			if(quit.IndexOf("QUIT") < 0) {goto End;}
			else goto End;
		End:
			buff = (constants.ServiceClosingTransmissionChannel + constants.CRLF).BaseStream;
			try
			{
				s.Send(buff, 0, buff.Length, 0);
				ThreadExit();
				return ;
			}
			catch
			{
				ThreadExit();
				return ;
			}
		}
		//---------------------------------------------------------------
		private void DataHandle(Hashtable mailtos ,string from, int n, bool first)
		{
			if(first)
			{
				n = s.Receive(buffer, 0, buffer.Length, 0);
				if(n == 0) { ThreadExit(); return ;}
			}
			string DATA = BinaryToStringASCII(buffer, n);
			CheckBadCRLF(buffer, n);
			if(DATA.IndexOf("DATA") < 0) {goto End;}
			buff = (constants.StartMailInput + constants.CRLF).BaseStream;
			try
			{
				n = s.Send(buff, 0, buff.Length, 0);
			}
			catch
			{
				ThreadExit();
				return ;
			}
			if(n == 0) { ThreadExit(); return ;}
			Console.WriteLine("data is starting DATA HANDLE");
			CopyToInboxOrBulk(mailtos, from);
			return ;
		End:
			DATA = null;
			buff = (constants.SyntaxError + constants.CRLF).BaseStream;
			try
			{
				s.Send(buff, 0, buff.Length, 0);
				ThreadExit();
				return ;
			}
			catch
			{
				ThreadExit();
				return ;
			}
		}
		//---------------------------------------------------------------
		private void CopyToInboxOrBulk(Hashtable mailtos, string from)
		{
			///////consider stroring to Inbox or Bulk
			///////consider try and catch
			IDictionaryEnumerator ide = mailtos.GetEnumerator();
			int i = 0;
			DateTime dt = DateTime.Now;
			int LenRecieve = 0, n = 0;
			i = 0;
			AsciiStreamWriter sw = new AsciiStreamWriter();
			while(true)
			{
				try
				{
					n = s.Receive(buffer, 0, buffer.Length, 0);
				}
				catch
				{
					sw.Close();
					ThreadExit();
					return ;
				}
				if(n == 0)
				{
					sw.Close();
					ThreadExit();////exit here since the connection was closed improperlly
					return ;
				}
				LenRecieve += n;
				if(LenRecieve >= constants.MaxLenRecieveData)
				{
					sw.Close();
					buff = (constants.RequestedMailActionAborted + constants.CRLF).BaseStream;
					try
					{
						s.Send(buff, 0, buff.Length, 0);
						ThreadExit();
						return ;
					}
					catch
					{
						ThreadExit();
						return ;
					}
				}
				AsciiString clrf_clrf = new AsciiString(buffer, n);
				int p = clrf_clrf.IndexOf(constants.CRLF_CRLF);
				if(p >= 0)
				{
					//Console.WriteLine(new AsciiString(buffer, p));
					sw.Write(new AsciiString(buffer, p));
					i++;
					break;
				}
				else
				{
					//Console.WriteLine(new AsciiString(buffer, n));
					sw.Write(new AsciiString(buffer, n));
				}
				i++;
			}
			if(i == 0)
			{
				goto End;  // no data recieption, we must not store none in our database update section, then goto End
			}
			buff = (constants.RequestOkay + new AsciiString(" OK") + constants.CRLF).BaseStream;
			try
			{
				n = s.Send(buff, 0, buff.Length, 0);
			}
			catch
			{
				goto End;
			}
			if(n == 0) {goto End;}
			///////update all database tables//// consider try and catch for the db///update Trie// we can insert this methods after closing client connection for optimum work
			//LenRecieve = LenRecieve - CRLF_CRLF.Length
			//AsciiString source =(String) sw.ToString();sw.Close();
			MessageParser mp = new MessageParser(sw.toString());
			sw.Close();
			sw = null;
			UsersMailDb db = new UsersMailDb();
			int DataLength = 0;
			try
			{
				DataLength = db.SaveMailInfoToDb(mailtos, dt, from, mp);
			}
			catch
			{
				goto End;
			}
			db.Dispose();
			if(DataLength < 0)
				goto End;
			UsersEmailAccountDB d = new UsersEmailAccountDB();//in this function, CurrentBoxSize in our Trie is updated.
			try
			{
				int result = d.UpdateUsersAccountDb(ref this.t, mailtos, DataLength);
			}
			catch
			{
				goto End;
			}
			//d.Dispose();
			d = null;
			mp.Dispose();
			mp = null;
			ide = null;
			return; // if result is -3 , we must here place a log file to report admin
			////////////////////////////////////
		End:
			sw.Close();
			sw = null;
			ide = null;
			buff = (constants.SyntaxError + constants.CRLF).BaseStream;
			try
			{
				s.Send(buff, 0, buff.Length, 0);
				ThreadExit();
				return ;
			}
			catch
			{
				ThreadExit();
				return ;
			}
			//////large data   update trie////////////////////
			////conider here for updating database
		}
		//---------------------------------------------------------------
		private string MailFromRCPTTO(byte[] buffer, int n, bool FromSession, ref string from)
		{
			string mailfrom = BinaryToStringASCII(buffer, n);
			if(mailfrom.IndexOf("RSET") >= 0) // this section is for if the cilent want to close conversation in during MAIL FROM section
			{
				Console.WriteLine("Quit is ok");
				buff = (constants.RequestOkay + new AsciiString(" OK") + constants.CRLF).BaseStream; //Respond with 250 OK + CRLF;
				int m  = 0 ;
				try
				{
					m = s.Send(buff, 0, buff.Length, 0);
				}
				catch
				{
					ThreadExit();
					return null;
				}
				if(m == 0)
				{
					ThreadExit();
					return null;
				}
				QuitHandle();
				//return null;
			}
			Console.WriteLine(mailfrom);/////
			CheckBadCRLF(buffer, n);
			if(FromSession) { if(mailfrom.IndexOf("MAIL FROM",0, 10 ) < 0) {goto End;} }
			else {if(mailfrom.IndexOf("RCPT TO", 0 ) < 0) {return null;} }
			if(FromSession)
			{
				int p = mailfrom.IndexOf(":");
				if(p > 0)
				{
					from = mailfrom.Substring(p + 1).Trim();
				}
				else
				   from = mailfrom;
			}
			mailfrom = ExtractMailFrom(mailfrom);
			if(mailfrom == null) {goto End;}
			else return mailfrom;
		End:
			buff = (constants.SyntaxError + constants.CRLF).BaseStream;
			try
			{
				s.Send(buff, 0, buff.Length, 0);
			}
			catch
			{
				ThreadExit(); 
				return null;
			}
			if(FromSession) { ThreadExit(); return null; }
			else return "";
		}
		//---------------------------------------------------------------
		private string ExtractMailFrom(string buffer)
	    {
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
			if(crlf.IndexOf("\r\n") < 0)
			{
				crlf = null;
				buff = (constants.SyntaxError + constants.CRLF).BaseStream;
				try
				{
					s.Send(buff, 0, buff.Length, 0);
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
				crlf = null;
				return ;
			}
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
				protocol = null;
				return ;
			}
			else
			{
				buff = (constants.SyntaxError + constants.CRLF).BaseStream;
				try
				{
					s.Send(buff, 0, buff.Length, 0);
					protocol = null;
					ThreadExit();
					return ;
				}
				catch
				{
					protocol = null;
					ThreadExit();
					return ;
				}
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
		static private string RandomString(int DesiredLength)
		{
			if(DesiredLength == 0)
				DesiredLength += 1;
			string result = null;
			for(int i = 1 ; i <= DesiredLength ; i++)
			{
				result += RandomChar(i, RandomChar(i + 1, i*(new Random(unchecked((int)DateTime.Now.Ticks*i))).Next(DateTime.Now.Millisecond*i*i*DesiredLength)));
				Thread.Sleep(1);
			}
			return result;
		}
		//---------------------------------------------------------------
		static private char RandomChar(int i, int C)
		{
			const string Upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			const string Lower = "abcdefghijklmnopqrstuvwxyz";
			const string Numbers = "0123456789";
			char[] c = new char[3];
			c[0] = Upper[(new Random(unchecked((int)DateTime.Now.Ticks * i * DateTime.Now.Month))).Next(26)];
			c[1] = Lower[(new Random(unchecked((int)DateTime.Now.Second * C* DateTime.Now.Day))).Next(26)];
			c[2] = Numbers[(new Random(unchecked((int)DateTime.Now.Millisecond * i * DateTime.Now.Year))).Next(10)];
			return  c[(new Random(unchecked((int)(DateTime.Now.Ticks * C * i)))).Next(3)]; 
		}
		//---------------------------------------------------------------
	}
}