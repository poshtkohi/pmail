/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;

namespace DNS.Messages
{
	//------------------------------------------------------------------------------------------------------------
	public class Header
	{
		private uint id = 0;
		private bool qr = false;
		private byte opcode = 0;
		private bool aa = false;
		private bool tc = false;
		private bool rd = false;
		private bool ra = false;
		private byte z = 0;
		private byte rcode = 0;
		private uint qdcount = 0;
		private uint ancount = 0;
		private uint nscount = 0;
		private uint arcount = 0;
		//-------------------------------
		/// <summary>
		/// A 16 bit identifier assigned by the program that
		///generates any kind of query.  This identifier is copied
		///the corresponding reply and can be used by the requester	
		///to match up replies to outstanding queries.
		/// </summary>
		public uint ID
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}
		//-------------------------------
		/// <summary>
		/// A one bit field that specifies whether this message is a
		/// query (0), or a response (1).
		/// </summary>
		public bool QueryOrResponse
		{
			get
			{
				return this.qr;
			}
			set
			{
				this.qr = value;
			}
		}
		//-------------------------------
		/// <summary>
		/// A four bit field that specifies kind of query in this
		/// message.  This value is set by the originator of a query
		/// and copied into the response.  The values are:
		/// 0 a standard query (QUERY).
		/// 1 an inverse query (IQUERY).
		/// 2 a server status request (STATUS).
		/// 3-15 reserved for future use.
		/// </summary>
		public byte Opcode
		{
			get
			{
				return this.opcode;
			}
			set
			{
				this.opcode = value;
			}
		}
		//-------------------------------
		/// <summary>
		/// Authoritative Answer - this bit is valid in responses,
		/// and specifies that the responding name server is an
		///	authority for the domain name in question section.
		/// </summary>
		public bool AuthoritativeAnswer
		{
			get
			{
				return this.aa;
			}
			set
			{
				this.aa = value;
			}
		}
		//-------------------------------
		/// <summary>
		/// TrunCation - specifies that this message was truncated
		/// due to length greater than that permitted on the
		///	transmission channel.
		/// </summary>
		public bool TrunCation
		{
			get
			{
				return this.tc;
			}
			set
			{
				this.tc = value;
			}
		}
		//-------------------------------
		/// <summary>
		/// Recursion Desired - this bit may be set in a query and
		/// is copied into the response.  If RD is set, it directs
		///	the name server to pursue the query recursively.
		/// Recursive query support is optional.
		/// </summary>
		public bool RecursionDesired
		{
			get
			{
				return this.rd;
			}
			set
			{
				this.rd = value;
			}
		}
		//-------------------------------
		/// <summary>
		/// Recursion Available - this be is set or cleared in a
		/// response, and denotes whether recursive query support is
		/// available in the name server.
		/// </summary>
		public bool RecursionAvailable
		{
			get
			{
				return this.ra;
			}
			set
			{
				this.ra = value;
			}
		}
		//-------------------------------
		/// <summary>
		/// Reserved for future use.  Must be zero in all queries
		/// and responses.
		/// </summary>
		public byte Z
		{
			get
			{
				return this.z;
			}
			set
			{
				this.z = value;
			}
		}
		//-------------------------------
		/// <summary>
		/// Response code - this 4 bit field is set as part of
		/// responses.  The values have the following
		///									interpretation:
		/// 0 No error condition. 
		///	1 Format error - The name server was
		///	unable to interpret the query. 
		///	2 Server failure - The name server was
		///	unable to process this query due to a
		/// problem with the name server. 
		///	3 Name Error - Meaningful only for. 
		/// responses from an authoritative name
		///	server, this code signifies that the
		///	domain name referenced in the query does
		///	5 Refused - The name server refuses to
		///	perform the specified operation for
		/// policy reasons. For example, a name
		///	server may not wish to provide the
		///	information to the particular requester,
		///	or a name server may not wish to perform
		///	a particular operation (e.g., zone transfer) for particular data.
		///	6-15 Reserved for future use.
		/// </summary>
		public byte ResponseCode
		{
			get
			{
				return this.rcode;
			}
			set
			{
				this.rcode = value;
			}
		}
		//-------------------------------
		/// <summary>
		/// an unsigned 16 bit integer specifying the number of
		/// entries in the question section.
		/// </summary>
		public uint QuestionCount
		{
			get
			{
				return this.qdcount;
			}
			set
			{
				this.qdcount = value;
			}
		}
		//-------------------------------
		/// <summary>
		/// an unsigned 16 bit integer specifying the number of
		/// resource records in the answer section.
		/// </summary>
		public uint AnswerCount
		{
			get
			{
				return this.ancount;
			}
			set
			{
				this.ancount = value;
			}
		}
		//-------------------------------
		/// <summary>
		/// an unsigned 16 bit integer specifying the number of name
		/// server resource records in the authority records section.
		/// </summary>
		public uint AuthorityRecordsCount
		{
			get
			{
				return this.nscount;
			}
			set
			{
				this.nscount = value;
			}
		}
		//-------------------------------
		/// <summary>
		/// an unsigned 16 bit integer specifying the number of
		/// resource records in the additional records section.
		/// </summary>
		public uint AdditionalRecordsCount
		{
			get
			{
				return this.arcount;
			}
			set
			{
				this.arcount = value;
			}
		}
		//-------------------------------
		/// <summary>
		/// Construct a new Header class from DNS query;
		/// </summary>
		/// <param name="buffer"></param>
		public Header(byte[] buffer)
		{
			this.id = (uint)(buffer[1] | (buffer[0] << 0x0008));
			this.qr = Convert.ToBoolean((buffer[2] >> 0x0008) & 0x0001); //query (0), or a response (1).
			this.opcode = (byte)((buffer[2] >> 0x0003) & 0x000F);/*A four bit field that specifies kind of query in this
                                                               message.  This value is set by the originator of a query
                                                               and copied into the response.  The values are:
													           0               a standard query (QUERY)
                                                               1               an inverse query (IQUERY)
                                                               2               a server status request (STATUS)
                                                               3-15            reserved for future use*/
			this.aa = Convert.ToBoolean((buffer[2] >> 0x0002)& 0x0001);/*Authoritative Answer - this bit is valid in responses,
                                                                      and specifies that the responding name server is an
                                                                      authority for the domain name in question section.*/
			this.tc = Convert.ToBoolean((buffer[2] >> 0x0001) & 0x0001);/*TrunCation - specifies that this message was truncated
                                                  due to length greater than that permitted on the
												  transmission channel.*/
			this.rd = Convert.ToBoolean(buffer[2] & 0x0001);/*Recursion Desired - this bit may be set in a query and
                                                  is copied into the response.  If RD is set, it directs
                                                  the name server to pursue the query recursively.
                                                  Recursive query support is optional.*/
			this.ra = Convert.ToBoolean((buffer[3] >> 0x0008)& 0x0001);/*Recursion Available - this be is set or cleared in a
                                                  response, and denotes whether recursive query support is
                                                  available in the name server.*/
			this.z = (byte)((buffer[3] >> 0x0004) & 0x0007);/*Reserved for future use.  Must be zero in all queries
                                                 and responses.*/
			this.rcode = (byte)(buffer[3] & 0x000F);/*Response code - this 4 bit field is set as part of
                                                     responses.  The values have the following
                                                     interpretation:
                                                     0               No error condition
                                                     1               Format error - The name server was
                                                                     unable to interpret the query.
                                                     2               Server failure - The name server was
                                                                     unable to process this query due to a
                                                                     problem with the name server.

                                                     3               Name Error - Meaningful only for
                                                                     responses from an authoritative name
                                                                     server, this code signifies that the
                                                                     domain name referenced in the query does
                                                                     not exist.
                                                     4               Not Implemented - The name server does
                                                                     not support the requested kind of query.

                                                     5               Refused - The name server refuses to
                                                                     perform the specified operation for
                                                                     policy reasons.  For example, a name
                                                                     server may not wish to provide the
                                                                     information to the particular requester,
                                                                     or a name server may not wish to perform
                                                                     a particular operation (e.g., zone transfer) for particular data.
                                                     6-15            Reserved for future use.*/
			this.qdcount = (uint)(buffer[5] | (buffer[4] << 8));/* an unsigned 16 bit integer specifying the number of
                                                                           entries in the question section.*/
			this.ancount = (uint)(buffer[7] | (buffer[6] << 8));/*an unsigned 16 bit integer specifying the number of
                                                                          resource records in the answer section.*/
			this.nscount = (uint)(buffer[9] | (buffer[8] << 8));/*an unsigned 16 bit integer specifying the number of name
                                                                          server resource records in the authority records section.*/
			this.arcount = (uint)(buffer[11] | (buffer[10] << 8));/*an unsigned 16 bit integer specifying the number of
                                                                            resource records in the additional records section.*/
		}
		//-------------------------------
		/// <summary>
		/// Find 12 bytes of Header with the related settings.
		/// </summary>
		/// <param name="settings">Necessary parameter for building proper Header instance.</param>
		/// <returns></returns>
		public static byte[] GetBytesFromHeader(Header settings)
		{
			byte[] buffer = new byte[12];
			buffer[0] = (byte)((settings.ID & 0xFF00) >> 8); //ID
			buffer[1] = (byte)(settings.ID & 0x00FF);  //ID
			buffer[2] = (byte)( (Convert.ToByte(settings.QueryOrResponse) << 8) | //QR
				        ((settings.Opcode & 0x000F) << 3) | //Opcode
				        (Convert.ToByte(settings.AuthoritativeAnswer) << 2) | //AA
				        (Convert.ToByte(settings.TrunCation) << 1) | //TC
				        (Convert.ToByte(settings.RecursionDesired)) ); //RD
			buffer[3] = (byte)( (Convert.ToByte(settings.QueryOrResponse) << 8) | //RA
				        ((settings.Z & 0x0007) << 4) | //Z
				        ((settings.ResponseCode & 0x000F)) ); //RCODE
			buffer[4] = (byte)((settings.QuestionCount & 0xFF00) >> 8); //QDCOUNT 
			buffer[5] = (byte)(settings.QuestionCount & 0x00FF); //QDCOUNT
			buffer[6] = (byte)((settings.AnswerCount & 0xFF00) >> 8); //ANCOUNT 
			buffer[7] = (byte)(settings.AnswerCount & 0x00FF); //ANCOUNT 
			buffer[8] = (byte)((settings.AuthorityRecordsCount & 0xFF00) >> 8); //NSCOUNT
			buffer[9] = (byte)(settings.AuthorityRecordsCount & 0x00FF); //NSCOUNT
			buffer[10] = (byte)((settings.AdditionalRecordsCount & 0xFF00) >> 8); //ARCOUNT
			buffer[11] = (byte)(settings.AdditionalRecordsCount & 0x00FF); //ARCOUNT
			return buffer;
		}
		//-------------------------------
	}
	//------------------------------------------------------------------------------------------------------------
}