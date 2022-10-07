/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.IO;
using System.Threading;
using System.Collections;

namespace MailSender
{
	class MailSender
	{
		private Thread thread;
		public MailSender()
		{
			this.thread = null;
		}
		public void Start()
		{
			this.thread = new Thread(new ThreadStart(this.ThreadProc));
			this.thread.Start();
		}
		//------------------------------------------------------------
		private void ThreadProc()
		{
			Database db = new Database(constants.SqlServerAddressComposeDb, constants.ComposeDbName,
				                      constants.ComposeDbUsername, constants.ComposeDbPassword);
			Queue queue = db.LoadQueueTable();
			db.Dispose();
			MessageQueuingServer mqs = new MessageQueuingServer(ref queue);
			mqs.ServerStart();
			NewSending[] connections = new NewSending[constants.MaxThreads];
			for(int i = 0 ; i < connections.Length ; i++)
			{
				connections[i] = new NewSending();
				Thread thread = new Thread(new ThreadStart(connections[i].ThreadManager));
				connections[i].Initialize(thread);
				thread.Start();
			}
			while(true)
			{
				if(queue.Count > 0)
				{
					for(int i = 0 ; i < connections.Length ; i++)
					{
						if(queue.Count == 0)
							break;
						if(connections[i].IsPresentToNewSending)
						{
							MessageQueuingInfo info = (MessageQueuingInfo)queue.Dequeue();
							if(info != null)
							{
								db = new Database(constants.SqlServerAddressComposeDb, constants.ComposeDbName,
									constants.ComposeDbUsername, constants.ComposeDbPassword);
								SendingInfo data = db.GrabNewRowQueue(info.MsgID);
								db.Dispose();
								if(data != null)
									connections[i].ThreadResume(data);
								info = null;
								//GC.Collect();
							}
						}
					}
				}
				Thread.Sleep(1);
			}
		}
		//----------------------------------------------------------
	}
}