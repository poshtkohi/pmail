/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Threading;

namespace Cyber.email
{
	public class RandomString
	{
		//---------------------------------------------------------------
		/// <summary>
		/// Build a random string with the DeisredLength
		/// </summary>
		/// <param name="DesiredLength"></param>
		/// <returns></returns>
		static public string Generate(int DesiredLength)
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