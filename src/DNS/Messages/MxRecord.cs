/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;

namespace DNS.Messages
{
	//--------------------------------------------------------------------------------------------
	public class MxRecord
	{
		private string  exchange;
		private uint preference;
		//--------------------------
		/// <summary>
		/// Constructor MxRecord
		/// </summary>
		/// <param name="Exchange">A 16 bit integer which specifies the preference given to
		/// this RR among others at the same owner.  Lower values
		///	are preferred.</param>
		/// <param name="Preference">A <domain-name> which specifies a host willing to act as
		/// a mail exchange for the owner name.</param>
		public MxRecord(string Exchange, uint Preference)
		{
			this.exchange = Exchange;
			this.preference = Preference;
		}
		//--------------------------
		/// <summary>
		///	A domain-name which specifies a host willing to act as
		/// a mail exchange for the owner name.
		/// </summary>
		public string Exchange
		{
			get
			{
				return this.exchange;
			}
		}
		//--------------------------
		/// <summary>
		/// A 16 bit integer which specifies the preference given to
		/// this RR among others at the same owner.  Lower values
		///	are preferred.
		/// </summary>
		public uint Preference
		{
			get
			{
				return this.preference;
			}
		}
		//--------------------------
	}
	//--------------------------------------------------------------------------------------------
}