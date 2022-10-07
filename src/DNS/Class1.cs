/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using DNS.Messages;

namespace DNS
{
	class Class1
	{
		//------------------------------------------------------------------------------------
		[STAThread]
		static void Main(string[] args)
		{
			Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			IPEndPoint hostEndPoint = new IPEndPoint(IPAddress.Any, 53);
			//sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
			sock.Bind(hostEndPoint);
			IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
			EndPoint Remote = (EndPoint) sender;
			byte[] buffer = new byte[512];
			int n = 0;
			int j = 0;
			while(true)
			{
				j++;
				n = sock.ReceiveFrom(buffer,0, buffer.Length, 0, ref Remote);
				if(n > 12) //minimum the header length
				{
					Header h = new Header(buffer);
					Question q = new Question(buffer, h);
					string[] data = new string[2]{"127.0.0.1", "127.0.0.2"};
					Answer a = new Answer(q.QuestionName[0], (TYPE)q.QuestionType[0], (CLASS)q.QuestionClass[0], 0, data);
					byte[] answer = a.AnswerBuffer;
					h.RecursionAvailable = false;
					h.QueryOrResponse = true;
					h.AnswerCount = (uint)data.Length;//
					h.ResponseCode = 0;
					h.QuestionCount = 0;
					h.ResponseCode = 0;
					byte[] b = new byte[512];
					byte[] headers = Header.GetBytesFromHeader(h);
					byte[] question = q.QuestionBuffer;
					for(int i = 0 ; i < 12 ; i++)
					{
						b[i] = headers[i];
					}
					for(int i = 0 ; i < answer.Length ; i++)
					{
						b[i + 12] = answer[i];
					}
					n = sock.SendTo(b, 0 , b.Length, 0, Remote);
					//Console.WriteLine(j);
				}
			}
		}
		//------------------------------------------------------------------------------------
	}
}