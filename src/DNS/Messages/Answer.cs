/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Net;
using System.Collections;

namespace DNS.Messages
{
	// Attention: now, we only support TYPE of A, MX.
	//this version is only for ipv4, for modyfy and develop to ipv6, please change some codes that start with /*ipv4*/
	//----------------------------------------------------------------------------------------------------------------
	public class Answer
	{
		private string name = null;
		private uint type = 0;
		private uint cclass = 0;
		private int ttl = 0;
		private object rr = null;
		//-------------------------
		/// <summary>
		/// construct a proper Answer structure with the provided data.
		/// </summary>
		/// <param name="Name">a domain name to which this resource record pertains.</param>
		/// <param name="Type">two octets containing one of the RR type codes. This
		/// field specifies the meaning of the data in the RecordData field.
		/// </param>
		/// <param name="Class">two octets which specify the class of the data in the RecordData field.
		///	</param>
		/// <param name="Ttl">a 32 bit unsigned integer that specifies the time
		/// interval (in seconds) that the resource record may be
		///	cached before it should be discarded.  Zero values are
		///	interpreted to mean that the RR can only be used for the
		///	transaction in progress, and should not be cached.
		///	</param>
		///	<param name="Preference">A 16 bit integer which specifies the preference given to
		/// this RecordData among others at the same owner in the Mail Exchange Servers. Lower values are preferred.
		///	</param>
		/// <param name="RecordData">a variable length string of octets that describes the
		/// resource.  The format of this information varies
		///	according to the Type and Class of the resource record.
		/// For example, the if the Type is A and the Class is IN,
		/// the RecordData field is a 4 octet ARPA Internet address(Attention: in this sample we have for example: 127.0.0.1).
		///</param>
		public Answer(string Name, TYPE Type, CLASS Class, int Ttl, object RecordData)
		{
			this.name = Name;
			this.type = (uint)Type;
			this.cclass = (uint)Class;
			this.ttl = Ttl;
			this.rr = RecordData;
		}
		//-------------------------
		/// <summary>
		/// This property find bytes from this Answer instance.
		/// </summary>
		public byte[] AnswerBuffer
		{
			get
			{
				if(this.cclass == (uint)CLASS.IN)
				{
					//-------TYPE.A---------------
					if(this.type == (uint)TYPE.A)
					{
						int TotalBufferLength = 0;
						int MainDomainSize = 0;
						string[] rdata = (string[])this.rr;
						string[] labels = this.name.Split(new char[] {'.'});
						for(int i = 0 ; i < labels.Length ; i++)
							//format = label.length + label(bytes)
							MainDomainSize += labels[i].Length + 1;// 1 is for label.length field
						TotalBufferLength += rdata.Length * (MainDomainSize + 1); //for null in end of domain
						TotalBufferLength += (2 + 2 + 4 + 2) * rdata.Length; // TYPE + CLASS + TTL + RDLENGTH
						/*ipv4*/TotalBufferLength += 4 * rdata.Length;// 32 bit for ipv4
						byte[] buffer = new byte[TotalBufferLength];
						int position = 0;
						for(int k = 0 ; k < rdata.Length ; k++)
						{
							//+++++copy Name to buffer+++
							for(int i = 0 ; i < labels.Length ; i++)
							{
								if(labels[i].Length > 256)
									throw new Exception("Size of any domain must be fewer than 256, For example www in www.nytimes.com");
								buffer[position] = Convert.ToByte(labels[i].Length);
								position++;
								for(int j = 0 ; j < labels[i].Length ; j++)
								{
									buffer[position + j] =  Convert.ToByte(labels[i][j]);
								}
								position += labels[i].Length;
							}
							buffer[position] = 0; //for null in end of domain
							//+++++TYPE++++++++++++++++++
							position++;
							buffer[position] = (byte)((this.type & 0xFF00) >> 8);
							position++;
							buffer[position] = (byte)(this.type & 0x00FF);
							//+++++CLASS+++++++++++++++++
							position++;
							buffer[position] = (byte)((this.cclass & 0xFF00) >> 8);
							position++;
							buffer[position] = (byte)(this.cclass & 0x00FF);
							//+++++TTL+++++++++++++++++++
							position++;
							buffer[position] = (byte)((this.ttl & 0xFF000000) >> 24);
							position++;
							buffer[position] = (byte)((this.ttl & 0x00FF0000) >> 16);
							position++;
							buffer[position] = (byte)((this.ttl & 0x0000FF00) >> 8);
							position++;
							buffer[position] = (byte)(this.ttl & 0x000000FF);
							//+++++RDLENGTH++++++++++++++
							uint rdlength = 4;
							position++;
							buffer[position] = (byte)((rdlength & 0xFF00) >> 8);
							position++;
							buffer[position] = (byte)(rdlength & 0x00FF);
							//+++++RDATA+++++++++++++++++
							IPAddress addr = IPAddress.Parse(rdata[k]);
							long ip = addr.Address;
							/*ipv4*/position++;
							/*ipv4*/buffer[position] = (byte)(ip & 0x000000FF);
							/*ipv4*/position++;
							/*ipv4*/buffer[position] = (byte)((ip & 0x0000FF00) >> 8);
							/*ipv4*/position++;
							/*ipv4*/buffer[position] = (byte)((ip & 0x00FF0000) >> 16);
							/*ipv4*/position++;
							/*ipv4*/buffer[position] = (byte)((ip & 0xFF000000) >> 24);
							//+++++++++++++++++++++++++++
							position++;
						}
						return buffer;
					}
					//-------TYPE.MX--------------
					if(this.type == (uint)TYPE.MX)
					{
						MxRecord[] mxs = (MxRecord[]) this.rr;
						int TotalBufferLength = 0;
						int MainDomainSize = 0;
						string[] labels = this.name.Split(new char[] {'.'});
						for(int i = 0 ; i < labels.Length ; i++)
							//format = label.length + label(bytes)
							MainDomainSize += labels[i].Length + 1;// 1 is for label.length field
						TotalBufferLength += mxs.Length *(MainDomainSize + 1); //for null in end of domain
						ArrayList domains = new ArrayList();
						uint[] rdlength = new uint[mxs.Length];
						for(int i = 0 ; i < mxs.Length ; i++)
						{
							string[] llabels = mxs[i].Exchange.Split(new char[] {'.'});
							foreach(string label in llabels)
								rdlength[i] += (uint)label.Length + 1; // 1 is for label.length field
							rdlength[i] += 2 + 1; //PREFERENCE, null domain terminator
							domains.Add(llabels);
						}
						for(int i = 0 ; i < mxs.Length ; i++)
						{
							TotalBufferLength += 2 + 2 + 4 + 2; // TYPE + CLASS + TTL + RDLENGTH
							TotalBufferLength += (int)rdlength[i];
						}
						byte[] buffer = new byte[TotalBufferLength];
						int position = 0;
						//header.AnswerCount = (uint)this.preference.Length; // for multiple Mail Exchanege Servers
						for(int k = 0 ; k < domains.Count ; k++)
						{
							//+++++copy Name to buffer+++
							for(int i = 0 ; i < labels.Length ; i++)
							{
								if(labels[i].Length > 256)
									throw new Exception("Size of any domain must be fewer than 256, For example www in www.nytimes.com");
								buffer[position] = Convert.ToByte(labels[i].Length);
								position++;
								for(int j = 0 ; j < labels[i].Length ; j++)
								{
									buffer[position + j] =  Convert.ToByte(labels[i][j]);
								}
								position += labels[i].Length;
							}
							buffer[position] = 0; //for null in end of domain
							//+++++TYPE++++++++++++++++++
							position++;
							buffer[position] = (byte)((this.type & 0xFF00) >> 8);
							position++;
							buffer[position] = (byte)(this.type & 0x00FF);
							//+++++CLASS+++++++++++++++++
							position++;
							buffer[position] = (byte)((this.cclass & 0xFF00) >> 8);
							position++;
							buffer[position] = (byte)(this.cclass & 0x00FF);
							//+++++TTL+++++++++++++++++++
							position++;
							buffer[position] = (byte)((this.ttl & 0xFF000000) >> 24);
							position++;
							buffer[position] = (byte)((this.ttl & 0x00FF0000) >> 16);
							position++;
							buffer[position] = (byte)((this.ttl & 0x0000FF00) >> 8);
							position++;
							buffer[position] = (byte)(this.ttl & 0x000000FF);
							//+++++RDLENGTH++++++++++++++
							position++;
							buffer[position] = (byte)((rdlength[k] & 0xFF00) >> 8);
							position++;
							buffer[position] = (byte)(rdlength[k] & 0x00FF);
							//+++++RDATA+++++++++++++++++
							position++;
							string[] temp = (string[])domains[k];
							buffer[position] = (byte)((mxs[k].Preference & 0xFF00) >> 8); //PREFERENCE 
							position++; //PREFERENCE 
							buffer[position] = (byte)(mxs[k].Preference & 0x00FF); //PREFERENCE 
							position++; //PREFERENCE 
							for(int i = 0 ; i < temp.Length ; i++)
							{
								if(temp[i].Length > 256)
									throw new Exception("Size of any domain must be fewer than 256, For example www in www.nytimes.com");               
								buffer[position] = Convert.ToByte(temp[i].Length);
								position++;
								for(int j = 0 ; j < temp[i].Length ; j++)
								{
									buffer[position + j] =  Convert.ToByte(temp[i][j]);
								}
								position += temp[i].Length;
							}
							buffer[position] = 0; //for null in end of domain
							position++;
							//+++++++++++++++++++++++++++
						}
						return buffer;
					}
					//----------------------------
					else
					{
						throw new Exception("This DNS extension only supports TYPE.A and TYPE.MX"); //We can add other TYPE support here.
					}
					//----------------------------
				}
				else
				{
					throw new Exception("This DNS extension only supports CLASS.IN"); //We can add other CLASS support here.
				}
			}
		}
		//-------------------------
	}
	//----------------------------------------------------------------------------------------------------------------
}