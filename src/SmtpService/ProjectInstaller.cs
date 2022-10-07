/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

namespace SmtpService
{
	/// <summary>
	/// Summary description for ProjectInstaller.
	/// </summary>
	[RunInstaller(true)]
	public class ProjectInstaller : System.Configuration.Install.Installer
	{
		private System.ServiceProcess.ServiceProcessInstaller SmtpServerProcess;
		private System.ServiceProcess.ServiceInstaller SmtpServer;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ProjectInstaller()
		{
			// This call is required by the Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SmtpServerProcess = new System.ServiceProcess.ServiceProcessInstaller();
			this.SmtpServer = new System.ServiceProcess.ServiceInstaller();
			// 
			// SmtpServerProcess
			// 
			this.SmtpServerProcess.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.SmtpServerProcess.Password = null;
			this.SmtpServerProcess.Username = null;
			// 
			// SmtpServer
			// 
			this.SmtpServer.DisplayName = "SMTP Server(All rights reserved to Mr. Alireza Poshtkoohi(C)2005.)";
			this.SmtpServer.ServiceName = "SmtpServer";
			this.SmtpServer.ServicesDependedOn = new string[] {
																  "MSSQLSERVER"};
			this.SmtpServer.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
																					  this.SmtpServerProcess,
																					  this.SmtpServer});

		}
		#endregion
	}
}
