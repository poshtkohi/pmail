/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/
using System;
using Mime.ASCII;
using System.Text;
using System.Collections;

namespace Mime
{
	internal sealed class EncoderDecoder
	{
		private readonly static char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7',
											  '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
		private readonly static char[] Bas64Alphabet = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X',
							  'Y','Z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x',
							  'y','z','0','1','2','3','4','5','6','7','8','9','+','/'};
		//-------------------------------------------------------------------------------------------------------------------
		public static string BinaryToStringUTF8(byte[] buffer, int len)
		{
			UTF8Encoding utf8 = new UTF8Encoding();
			return utf8.GetString(buffer, 0, len);
		}
		//------------------------------------------
		public static string BinaryToStringUTF8(byte[] buffer)
		{
			UTF8Encoding utf8 = new UTF8Encoding();
			return utf8.GetString(buffer);
		}
		//------------------------------------------
		public  static byte[] StringToBinaryUTF8(string buffer)
		{
			UTF8Encoding utf8 = new UTF8Encoding();
			return utf8.GetBytes(buffer); 
		}
		//------------------------------------------
		public static string BinaryToStringASCII(byte[] buffer, int len)
		{
			ASCIIEncoding ascii = new ASCIIEncoding();
			return ascii.GetString(buffer, 0, len);
		}
		//------------------------------------------
		public static string BinaryToStringASCII(byte[] buffer)
		{
			ASCIIEncoding ascii = new ASCIIEncoding();
			return ascii.GetString(buffer);
		}
		//------------------------------------------
		public static byte[] StringToBinaryASCII(string buffer)
		{
			ASCIIEncoding ascii = new ASCIIEncoding();
			return ascii.GetBytes(buffer); 
		}
		//------------------------------------------
		private static int ToHexNumber(byte buffer)
		{
			for(int i = 0 ; i < hexDigits.Length ; i++)
				if(buffer == hexDigits[i])
					return i;
			return -1;
		}
		//------------------------------------------
		private static char ToHexChar(int number)
		{
			if(number > hexDigits.Length - 1)
				return '0';
			else return hexDigits[number];
		}
		//-----------------------------------------
		/// <summary>
		/// this function do compabaility for MIME RFCs about length of any line in our messages.
		/// </summary>
		/// <param name="buffer">Input buffer for being compatible.</param>
		/// <param name="LineLength">Length of compatible line.</param>
		/// <returns></returns>
		public static AsciiString LineLengthCompatible(AsciiString buffer, int LineLength)
		{
			if(buffer.Length > LineLength)
			{
				int i = 0, j = 0, v = 0, index = 0, iLen = 0, aLen = 0;
				int a = buffer.Length / LineLength;
				int b = buffer.Length % LineLength;
				aLen = a * LineLength;
				byte[] buff = new byte[aLen + a * 2 + b];
				for(i = 0 ; i < a ; i++)
				{
					iLen = i * LineLength;
					for(j = 0 ; j < LineLength ; j++)	
					{
						index = iLen + j;
						buff[v] = buffer.GetValue(index);
						v++;
						if(j == LineLength - 1)
						{
							buff[v] = (byte) '\r';
							buff[v + 1] = (byte) '\n';
							v += 2;
						}
					}
				}
				if(b != 0)
				{
					index = aLen  + a * 2 ;
					for(i = 0 ; i < b ; i++)
						buff[i + index] = buffer.GetValue(aLen + i);
				}
				return new AsciiString(buff);
			}
			else
				return buffer;
		}
		//-----------------------------------------
		public static byte[] Base64Decoder(AsciiString input)
		{
			try
			{
				return Convert.FromBase64String(input.ToString());
			}
			catch
			{
				return null; // returened null is meaning that the Base64 data source is invalid;
			}
		}
		//-----------------------------------------
		public static AsciiString Base64Encoder(byte[] input)
		{
			try
			{
				return new AsciiString(Convert.ToBase64String(input));
				//return ToBase64(input);
			}
			catch
			{
				return null; // returened null is meaning that the Base64 data source is invalid;
			}
		}
		//-----------------------------------------
		public static AsciiString Base64Encoder(string input)
		{
			try
			{
				return new AsciiString(Convert.ToBase64String(StringToBinaryUTF8(input)));
				//return ToBase64(StringToBinaryUTF8(input));
			}
			catch
			{
				return null; // returened null is meaning that the Base64 data source is invalid;
			}
		}
		//------------------------------------------
		private static string ToBase64(byte[] buffer)
		{
			return ToBase64Internal(buffer, buffer.Length, false, false);
		}
		private static string ToBase64Internal(byte[] buffer, int n, bool recursive, bool recursive1)
		{
			if(n > buffer.Length)
			{
				throw new Exception("Out of buffer length.");
			}
			if(n == 0)
			{
				throw new Exception("Enter n > 0.");
			}
			int a = n / 3;
			int b = n % 3;
			string output = null;
			if(n == 1 || n == 2)
			{
				b = n;
				goto process;
			}
			if(a >= 1)
			{
				int c1=0, c2=0, c3=0, c4=0;
				for(int i = 0 ; i < a ; i++)
				{
					c1 = (buffer[3*i]&0xfc)>>2;
					output +=  Bas64Alphabet[c1];
					c2 = ((buffer[3*i]&0x3)<<4)|((buffer[3*i+1]&0xf0)>>4);
					output +=  Bas64Alphabet[c2];
					if(!recursive || recursive1)
					{
						c3 = ((buffer[3*i+2]&0xc0)>>6)|((buffer[3*i+1]&0xf)<<2);
						output +=  Bas64Alphabet[c3];
					}
					if(!recursive)
					{
						c4 = buffer[3*i+2]&0x3f;
						output +=  Bas64Alphabet[c4];
					}
				}
			}
			if(b==0)
			{
				return output;
			}
			process:
				if(b == 1)
				{
					byte[] buff= new byte[3];
					int p = 0;
					if(n > 3)
					{
						p = 3*a; 
					}
					buff[0] = buffer[p];
					buff[1] = 0;
					buff[2] =  0;
					output += ToBase64Internal(buff, 3, true, false);
					output += "==";
					return output;
				}
			if(b == 2)
			{
				byte[] buff= new byte[3];
				int p = 0;
				if(n > 3)
				{
					p = 3*a;
				}
				buff[0] = buffer[p];
				buff[1] = buffer[p+1];
				buff[2] =  0;
				output += ToBase64Internal(buff, 3, true, true);
				output += "=";
				return output;
			}
			else
			{
				return output;
			}
		}
		//-----------------------------------------
		public static string QuotedPrintableDecode(AsciiString input) // Attention: returned value string by this function is UTF8
		{
			ArrayList al = new ArrayList();
			int temp1 = 0, temp2 = 0;
			for(int i = 0 ; i < input.Length ; i++)
			{
				if(input.GetValue(i) == '=')
				{
					if(i != input.Length - 2)
					{
						temp1 =  ToHexNumber(input.GetValue(i + 1));
						if(temp1 != -1)
						{
							temp2 = ToHexNumber(input.GetValue(i + 2));
							if(temp2 != -1)
							{
								al.Add((temp1 << 4) | temp2);
								i += 2;
								continue;
							}
						}
					}
				}
				if(input.GetValue(i) != '=')
					al.Add((int)input.GetValue(i));
			}
			byte[] buffer = new byte[al.Count];
			for(int j = 0 ; j < buffer.Length ; j++)
				buffer[j] = (byte)((int)al[j]);
			al.Clear();
			al = null;
			return  BinaryToStringUTF8(buffer, buffer.Length);
		}
		//-----------------------------------------
		public static AsciiString QuotedPrintableEncode(AsciiString buffer) // Attention: returned value string by this function is ASCII
		{
			ArrayList al = new ArrayList();
			byte section1 = 0, section2 = 0;
			for(int i = 0 ; i < buffer.Length ; i++)
			{
				if(buffer.GetValue(i) == ' ')
				{
					if( i != buffer.Length - 1)
					{
						if(buffer.GetValue(i + 1) == '\r' )
						{
							al.Add((byte) ' ');
							al.Add((byte) '=');
						}
					}
				}
				if((buffer.GetValue(i) != '\r' && buffer.GetValue(i) != '\n' && buffer.GetValue(i) > 127) || buffer.GetValue(i) == '=')
				{
					section1 = (byte) ToHexChar(((buffer.GetValue(i) & 0x00F0) >> 4));
					section2 = (byte) ToHexChar(buffer.GetValue(i) & 0x000F);
					al.Add((byte) '=');
					al.Add(section1);
					al.Add(section2);
				}
				else
				{
					al.Add(buffer.GetValue(i));
				}
			}
			byte[] buff = new byte[al.Count];
			for(int j = 0 ; j < buff.Length ; j++)
				buff[j] = (byte)al[j];
			al.Clear();
			al = null;
			return new AsciiString(buff);
		}
		//-----------------------------------------
	}
}