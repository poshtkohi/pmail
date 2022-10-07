/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;

namespace DNS.Messages
{
	//------------------------------------------------------------------------------------------------------------------
	public enum TYPE : uint {
		/// <summary>
		/// a host address.
		/// </summary>
		A=1,
		/// <summary>
		/// an authoritative name server.
		/// </summary>
		NS=2,
		/// <summary>
		/// a mail destination (Obsolete - use MX).
		/// </summary>
		MD=3,
		/// <summary>
		/// a mail forwarder (Obsolete - use MX).
		/// </summary>
		MF=4,
		/// <summary>
		/// the canonical name for an alias.
		/// </summary>
		CNAME=5,
		/// <summary>
		/// marks the start of a zone of authority.
		/// </summary>
		SOA=6,
		/// <summary>
		/// a mailbox domain name.
		/// </summary>
		MB=7,
		/// <summary>
		/// a mail group member.
		/// </summary>
		MG=8,
		/// <summary>
		/// a mail rename domain name.
		/// </summary>
		MR=9,
		/// <summary>
		/// a null Record Data(RR).
		/// </summary>
		NULL=10,
		/// <summary>
		/// a well known service description.
		/// </summary>
		WKS=11,
		/// <summary>
		/// a domain name pointer.
		/// </summary>
		PTR=12,
		/// <summary>
		/// host information.
		/// </summary>
		HINFO=13,
		/// <summary>
		/// mailbox or mail list information.
		/// </summary>
		MINFO=14,
		/// <summary>
		/// mail exchange.
		/// </summary>
		MX=15,
		/// <summary>
		/// text strings.
		/// </summary>
		TXT=16
	};
	//------------------------------------------------------------------------------------------------------------------
	public enum CLASS : uint 
	{
		/// <summary>
		/// the Internet.
		/// </summary>
		IN=1,
		/// <summary>
		/// the CSNET class (Obsolete - used only for examples in some obsolete RFCs).
		/// </summary>
		CS=2,
		/// <summary>
		/// the CHAOS class.
		/// </summary>
		CH=3,
		/// <summary>
		/// Hesiod [Dyer 87].
		/// </summary>
		HS=4
	};
	//------------------------------------------------------------------------------------------------------------------
}
