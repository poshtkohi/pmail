/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Collections;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace SMTP
{
	class SMTP
	{
		private Thread thread;
		private Socket sock;
		ArrayList connections;
		public SMTP()
		{
			this.sock = null;
			this.thread = null;
			this.connections = new ArrayList();
		}
		public void Start()
		{
			this.thread = new Thread(new ThreadStart(this.ThreadProc));
			this.thread.Start();
		}
		//------------------------------------------------------------
		private void ThreadProc()
		{
			// if we can load the data from SQL thus we must exit SMTP and message a log
			UsersEmailAccountDB db = new UsersEmailAccountDB();
			Trie t = db.LoadUsersAccountFromDb();
			MessageQueuingServer mqs = new MessageQueuingServer(ref t);
			mqs.ServerStart();
			/*connections = new NewConnection[constants.MaxConnections];
			for(int i = 0 ; i < connections.Length ; i++)
			{
				connections[i] = new NewConnection();
				Thread thread = new Thread(new ThreadStart(connections[i].ThreadManager));
				connections[i].Initialize(ref t, null, thread);
				thread.Start();
			}*/
			sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			//IPHostEntry hostInfo = Dns.Resolve(constants.SMTPServerAddress);
			IPEndPoint hostEndPoint = new IPEndPoint(IPAddress.Any/*hostInfo.AddressList[0]*/, 25);
			//sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
			sock.Bind(hostEndPoint);
			sock.Listen(100);
			while(true)
			{
				Socket s = sock.Accept();
				if(s != null)
				{
					NewConnection temp = new NewConnection(s, ref t, ref connections);
				}
			}
		}
		//------------------------------------------------------------
	}
}