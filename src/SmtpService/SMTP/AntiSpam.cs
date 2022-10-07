/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;

namespace SMTP
{
	public class AntiSpam
	{
		public AntiSpam()
		{
			/*IPHostEntry hostInfo1 = Dns.Resolve("166.250.107.202.sbl.spamhaus.org",sbl-xbl.spamhaus.org");
			for(int i = 0; i < hostInfo1.AddressList.Length ; i++)
			{
				Console.WriteLine(hostInfo1.AddressList[i]);
			}
			Console.WriteLine("\n\n");
			try
			{
				IPHostEntry hostInfo2 = Dns.Resolve("213.163.197.66.sbl.spamhaus.org");
				if(hostInfo2 != null)
					for(int i = 0; i < hostInfo2.AddressList.Length ; i++)
					{
						Console.WriteLine(hostInfo2.AddressList[i]);
					}
			}
			catch
			{
				Console.WriteLine("no spam");
			}*/
			/*			127.0.0.2
			Unhandled Exception: System.Net.Sockets.SocketException: The requested name is v
			alid, but no data of the requested type was found
			   at System.Net.Dns.GetHostByName(String hostName)
			   at System.Net.Dns.Resolve(String hostName)
			   at SMTP.Class1.Main(String[] args) in f:\mail server project\smtp\class1.cs:l
			ine 20
			Press any key to continue*/
		}
	}
}