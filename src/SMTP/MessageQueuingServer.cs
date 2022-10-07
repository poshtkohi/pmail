/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Collections;

namespace SMTP
{
	//----------------------------------------------------------------------------------------------------------
	public class MessageQueuingServer
	{
		private Thread ServerThread;
		private Socket ServerSock;
		private Trie t;
		private ArrayList connections;
		//------------------------------------------------------------
		private class NewConnection
		{
			private Thread thread;
			private Socket s;
			private Trie t;
			private byte[] buffer = null;
			private ArrayList connections = null;
			//------------
			public NewConnection(Socket s, ref Trie t, ref ArrayList connections)
			{
				this.t = t;
				this.s = s;
				this.connections = connections;
				this.connections.Add(this);
				this.thread = new Thread(new ThreadStart(this.ThreadProc));
				this.thread.Start();
			}
			//------------
			private void ThreadProc()
			{
				try
				{
					s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
				}
				catch
				{
					ThreadExit();
					return ;
				}
				buffer = new byte[1024];
				int n = 0;
				try
				{
					n = s.Receive(buffer, 0, buffer.Length, 0);

				}
				catch
				{
					ThreadExit();
					return ;
				}
				if(n == 0)
				{
					ThreadExit();
					return ;
				}
				try
				{
					XmlTextReader read = new XmlTextReader(new StringReader(BinaryToStringASCII(buffer, n)));
					while(read.Read())
					{
						if(read.NodeType == XmlNodeType.Element)
						{
							if(read.Name == "message")
							{
								read.MoveToAttribute("Password");
								string password = read.Value;
								if(String.Compare(password, constants.MessageQueuingPassword) != 0)
								{
									password = null;
									break;
								}
								read.MoveToAttribute("EmailSqlAddress");
								string EmailSqlAddress = read.Value;
								read.MoveToAttribute("Username");
								string  Username = read.Value;
								read.MoveToAttribute("MaxBoxSize");
								int MaxBoxSize = Convert.ToInt32(read.Value);
								if(EmailSqlAddress != null && EmailSqlAddress != "" && Username != null && Username != "")
								{
									//MessageQueuingInfo info = new MessageQueuingInfo();
									UsersEmailInfo info = new UsersEmailInfo();
									info.CurrentBoxSize = 0;
									info.EmailSqlAddress = EmailSqlAddress;
									info.MaxBoxSize = MaxBoxSize;
									t.AddUsernameAccount(Username, info);
									info = null;
								}
								Username = null;
								password = null;
								EmailSqlAddress = null;
								break;
							}
						}
					}
					read.Close();
					read = null;
					ThreadExit();
				}
				catch
				{
					ThreadExit();
					return ;
				}
			}
			//------------
			private void ThreadExit()
			{
				buffer = null;
				this.s.Close();
				this.s = null;
				this.thread = null;
				this.connections.Remove(this);
				GC.Collect();
				return ;
			}
			//------------
			public void ThreadKill()
			{
				if(this.s != null)
				{
					this.s.Close();
					this.s = null;
					buffer = null;
				}
				this.thread.Abort();
			}
			//------------
			private static string BinaryToStringASCII(byte[] buffer, int len)
			{
				ASCIIEncoding ascii = new ASCIIEncoding();
				return ascii.GetString(buffer, 0, len);
			}
			//------------
		}
		//------------------------------------------------------------
		public MessageQueuingServer(ref Trie t)
		{
			this.t = t;
			this.connections = new ArrayList();
			this.ServerThread = new Thread(new ThreadStart(this.ServerThreadProc));
		}
		//------------------------------------------------------------
		public void ServerStart()
		{
			if(!this.ServerThread.IsAlive)
				this.ServerThread.Start();
		}
		//------------------------------------------------------------
		public void ServerExit()
		{
			if(this.connections.Count > 0)
			{
				for(int i = 0 ; i < connections.Count ; i++)
				{
					NewConnection temp = (NewConnection)connections[i];
					temp.ThreadKill();
				}
			}
			this.connections = null;
			this.ServerThread.Abort();
			return ;
		}
		//------------------------------------------------------------
		public void ServerResume()
		{
			this.ServerThread.Resume();
			return ;
		}
		//------------------------------------------------------------
		public void ServerPause()
		{
			if(this.connections.Count > 0)
			{
				for(int i = 0 ; i < connections.Count ; i++)
				{
					NewConnection temp = (NewConnection)connections[i];
					temp.ThreadKill();
				}
			}
			this.ServerThread.Suspend();
			return ;
		}
		//------------------------------------------------------------
		private void ServerThreadProc()
		{
			this.ServerSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPHostEntry hostInfo = Dns.Resolve(constants.MessageQueuingServerAddress);
			IPEndPoint hostEndPoint = new IPEndPoint(hostInfo.AddressList[0], constants.MessageQueuingServerPort);
			//sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
			this.ServerSock.Bind(hostEndPoint);
			this.ServerSock.Listen(5);
			while(true)
			{
				Socket s = this.ServerSock.Accept();
				if(s != null)
				{
					NewConnection temp = new NewConnection(s, ref t , ref connections);
				}
			}
		}
		//------------------------------------------------------------
	}
	//----------------------------------------------------------------------------------------------------------
}