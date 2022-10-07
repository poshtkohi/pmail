/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/
using System;
using System.Text;
using System.Collections;

namespace DNS.Messages
{
	//---------------------------------------------------------------------------------------------------------
	public class Question
	{
		private ArrayList qname = null;
		private ArrayList qtype = null;
		private ArrayList qclass = null;
		private byte[] buffer = null;
		private Header header = null;
		private int EndPositonInBuffer = 0;
		//-----------------------------------
		/// <summary>
		/// an array of domain name represented as a sequence of labels, where
		/// each label consists of a length octet followed by that
		///	number of octets. The domain name terminates with the
		///	zero length octet for the null label of the root.  Note
		/// that this field may be an odd number of octets; no padding is used.
		/// </summary>
		public string[] QuestionName
		{
			get
			{
				if(this.qname != null)
					return (string[])this.qname.ToArray(typeof(string));
				else
					return null;
			}
		}
		//-----------------------------------
		/// <summary>
		/// an array of two octet code which specifies the type of the query.
		/// The values for this field include all codes valid for a
		///	TYPE field, together with some more general codes which
		///	can match more than one type of RR.
		/// </summary>
		public uint[] QuestionType
		{
			get
			{
				if(this.qtype != null)
					return (uint[])this.qtype.ToArray(typeof(uint));
				else
					return null;
			}
		}
		//-----------------------------------
		/// <summary>
		///  an array of two octet code that specifies the class of the query.
		///  For example, the QCLASS field is IN for the Internet.
		/// </summary>
		public uint[] QuestionClass
		{
			get
			{
				if(this.qclass != null)
					return (uint[])this.qclass.ToArray(typeof(uint));
				else
					return null;
			}
		}
		//-----------------------------------
		/// <summary>
		///  Construct a new Question class from DNS query.
		/// </summary>
		/// <param name="buffer">Network UDP buffer</param>
		/// <param name="h">Header class</param>
		public Question(byte[] buffer, Header h)
		{
			this.buffer = buffer;
			this.header = h;
			if(h.QuestionCount == 0)
				return ;
			this.qname = new ArrayList();
			this.qtype = new ArrayList();
			this.qclass = new ArrayList();
			int position = 12;
			for(uint i = 0 ; i < h.QuestionCount ; i++)
			{
				// find all domain parts(labels) in our buffer query
				// eg. microsfot.com = 2 labels, microsoft and com.
				// format = label.length + label(bytes)
				ArrayList lables = new ArrayList();
				while(buffer[position] != 0)
				{
					int length = buffer[position];
					position++;
					string temp = null;
					for(uint j = 0 ; j < length ; j++)
						temp += (char)buffer[position + j];
					lables.Add(temp);
					position += length;
				}
				string domain = null;
				for(int j = 0 ; j < lables.Count ; j++)
				{
					if(j == lables.Count - 1)
						domain += lables[j];
					else
						domain += lables[j] + ".";
				}
				this.qname.Add(domain);
				position++;
				this.qtype.Add((uint)(buffer[position + 1] | (buffer[position] << 8)));
				position += 2;
				this.qclass.Add((uint)(buffer[position + 1] | (buffer[position] << 8)));
				position += 2;
			}
			position--;
			EndPositonInBuffer = position;
		}
		//-----------------------------------
		/// <summary>
		/// Find bytes from section of Question in received buffer, if QuestionCount==0, null is returned..
		/// </summary>
		public byte[] QuestionBuffer
		{
			get
			{
				if(header.QuestionCount == 0)
					return null;
				else
				{
					byte[] question = new byte[this.EndPositonInBuffer - 12];
					for(int i = 0 ; i < question.Length ; i++)
						question[i] = this.buffer[i + 12];
					return question;
				}
			}
		}
		//-----------------------------------
		private static string BinaryToStringASCII(byte[] buffer, int start, int len)
		{
			ASCIIEncoding ascii = new ASCIIEncoding();
			return ascii.GetString(buffer, start, len);
		}
		//-----------------------------------
		private static byte[] StringToBinaryASCII(string buffer)
		{
			ASCIIEncoding ascii = new ASCIIEncoding();
			return ascii.GetBytes(buffer); 
		}
		//-----------------------------------
	}
	//---------------------------------------------------------------------------------------------------------
}