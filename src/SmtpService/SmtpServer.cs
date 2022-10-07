/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using SMTP;

namespace SmtpService
{
	public class SmtpServer : System.ServiceProcess.ServiceBase
	{
		private System.ComponentModel.Container components = null;
		private SMTP.SMTP smtp = new SMTP.SMTP();
		public SmtpServer()
		{
		}
		//----------------------------------------------------------------
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			// More than one user Service may run within the same process. To add
			// another service to this process, change the following line to
			// create a second service object. For example,
			//
			//   ServicesToRun = new System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new SmtpServer() };

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}
		private void InitializeComponent()
		{
			// 
			// SmtpServer
			// 
			this.ServiceName = "SmtpServer";

		}
		//----------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		//----------------------------------------------------------------
		protected override void OnStart(string[] args)
		{
			this.smtp.Start();
		}
		//----------------------------------------------------------------
		protected override void OnStop()
		{
		}
		//----------------------------------------------------------------
	}
}
