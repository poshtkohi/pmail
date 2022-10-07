/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

namespace DnsUtils
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Runtime.InteropServices;

	public class DnsMx
	{        
		public DnsMx()
		{
		}
		[DllImport("dnsapi", EntryPoint="DnsQuery_W", CharSet=CharSet.Unicode, SetLastError=true, ExactSpelling=true)]
		private static extern int DnsQuery([MarshalAs(UnmanagedType.VBByRefStr)]ref string pszName, QueryTypes wType, QueryOptions options, int aipServers, ref IntPtr ppQueryResults, int pReserved);

		[DllImport("dnsapi", CharSet=CharSet.Auto, SetLastError=true)]
		private static extern void DnsRecordListFree(IntPtr pRecordList, int FreeType);

		public static string[] GetMXRecords(string domain)
		{
      
			IntPtr ptr1=IntPtr.Zero ;
			IntPtr ptr2=IntPtr.Zero ;
			MXRecord recMx;
			if (Environment.OSVersion.Platform != PlatformID.Win32NT)
			{
				throw new NotSupportedException();
			}
			ArrayList list1 = new ArrayList();
			int num1 = DnsMx.DnsQuery(ref domain, QueryTypes.DNS_TYPE_MX, QueryOptions.DNS_QUERY_BYPASS_CACHE, 0, ref ptr1, 0);
			if (num1 != 0)
			{
				throw new Win32Exception(num1);
			}
			for (ptr2 = ptr1; !ptr2.Equals(IntPtr.Zero); ptr2 = recMx.pNext)
			{
				recMx = ( MXRecord) Marshal.PtrToStructure(ptr2, typeof(MXRecord));
				if (recMx.wType == 15)
				{
					string text1 = Marshal.PtrToStringAuto(recMx.pNameExchange);
					list1.Add(text1);
				}
			}
			DnsMx.DnsRecordListFree(ptr2, 0);
			return (string[]) list1.ToArray(typeof(string));
		}

		private enum QueryOptions
		{         
			DNS_QUERY_ACCEPT_TRUNCATED_RESPONSE = 1,
			DNS_QUERY_BYPASS_CACHE = 8,
			DNS_QUERY_DONT_RESET_TTL_VALUES = 0x100000,
			DNS_QUERY_NO_HOSTS_FILE = 0x40,
			DNS_QUERY_NO_LOCAL_NAME = 0x20,
			DNS_QUERY_NO_NETBT = 0x80,
			DNS_QUERY_NO_RECURSION = 4,
			DNS_QUERY_NO_WIRE_QUERY = 0x10,
			DNS_QUERY_RESERVED = -16777216,
			DNS_QUERY_RETURN_MESSAGE = 0x200,
			DNS_QUERY_STANDARD = 0,
			DNS_QUERY_TREAT_AS_FQDN = 0x1000,
			DNS_QUERY_USE_TCP_ONLY = 2,
			DNS_QUERY_WIRE_ONLY = 0x100
		}

		private enum QueryTypes
		{
			DNS_TYPE_MX = 15
		}

		[StructLayout(LayoutKind.Sequential)]
			private struct MXRecord
		{
			public IntPtr pNext;
			public string pName;
			public short wType;
			public short wDataLength;
			public int flags;
			public int dwTtl;
			public int dwReserved;
			public IntPtr pNameExchange;
			public short wPreference;
			public short Pad;
		}
	}
}
/*using System;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Collections;

namespace DnsMX {

	public class MXRecord {

		public int preference = -1;
		public string exchange = null;

		public override string ToString() {

			return "Preference : " + preference + " Exchange : " + exchange;
		}

	}
	public class DnsLite {

		private byte[] data;
		private int position, id, length;
		private string name;
		private ArrayList dnsServers;

		private static int DNS_PORT = 53;

		Encoding ASCII = Encoding.ASCII;

		public DnsLite() {

			id = DateTime.Now.Millisecond * 60;
			dnsServers = new ArrayList();

		}

		public void setDnsServers(ArrayList dnsServers) {

			this.dnsServers = dnsServers;

		}
		public ArrayList getMXRecords(string host) {

			ArrayList mxRecords = null;

			for(int i=0; i < dnsServers.Count; i++) {

				try {

					mxRecords = getMXRecords(host,(string)dnsServers[i]);
					break;

				}catch(IOException) {
					continue;
				}

			}

			return mxRecords;
		}

  		private int getNewId() {

			//return a new id
    		return ++id;
  		}

		public ArrayList getMXRecords(string host,string serverAddress) {

			//opening the UDP socket at DNS server
			//use UDPClient, if you are still with Beta1
			UdpClient dnsClient = new UdpClient(serverAddress, DNS_PORT);

			//preparing the DNS query packet.
			makeQuery(getNewId(),host);

			//send the data packet
			dnsClient.Send(data,data.Length);

			IPEndPoint endpoint = null;
			//receive the data packet from DNS server
			data = dnsClient.Receive(ref endpoint);

    		length = data.Length;
			dnsClient.Close();
    		//un pack the byte array & makes an array of MXRecord objects.
    		return makeResponse();

		}

		//for packing the information to the format accepted by server
		public void makeQuery(int id,String name) {

			data = new byte[512];

			for(int i = 0; i < 512; ++i) {
				data[i] = 0;
    		}

			data[0]	 = (byte) (id >> 8);
			data[1]  = (byte) (id & 0xFF );
			data[2]  = (byte) 1; data[3] = (byte) 0;
			data[4]  = (byte) 0; data[5] = (byte) 1;
			data[6]  = (byte) 0; data[7] = (byte) 0;
	    	data[8]  = (byte) 0; data[9] = (byte) 0;
    		data[10] = (byte) 0; data[11] = (byte) 0;

    		string[] tokens = name.Split(new char[] {'.'});
	  		string label;

  			position = 12;

  			for(int j=0; j<tokens.Length; j++) {

				label = tokens[j];
				data[position++] = (byte) (label.Length & 0xFF);
				byte[] b = ASCII.GetBytes(label);

				for(int k=0; k < b.Length; k++) {
					data[position++] = b[k];
				}

 			}

			data[position++] = (byte) 0 ; data[position++] = (byte) 0;
			data[position++] = (byte) 15; data[position++] = (byte) 0 ;
			data[position++] = (byte) 1 ;

		}

		//for un packing the byte array
		public ArrayList makeResponse() {

			ArrayList mxRecords = new ArrayList();
			MXRecord mxRecord;

			//NOTE: we are ignoring the unnecessary fields.
			//		and takes only the data required to build
			//		MX records.

    		int qCount = ((data[4] & 0xFF) << 8) | (data[5] & 0xFF);
		    if (qCount < 0) {
      			throw new IOException("invalid question count");
    		}

    		int aCount = ((data[6] & 0xFF) << 8) | (data[7] & 0xFF);
	    	if (aCount < 0) {
    			throw new IOException("invalid answer count");
    		}

	    	position=12;

    		for( int i=0;i<qCount; ++i) {
				name = "";
	    		position = proc(position);
	    		position += 4;
			}

    		for (int i = 0; i < aCount; ++i) {

				name = "";
				position = proc(position);

      			position+=10;

				int pref = (data[position++] << 8) | (data[position++] & 0xFF);

				name="";
				position = proc(position);

				mxRecord = new MXRecord();

				mxRecord.preference = pref;
				mxRecord.exchange = name;

				mxRecords.Add(mxRecord);

			}

			return mxRecords;
		}

		private int proc(int position) {

			int len = (data[position++] & 0xFF);

    		if(len == 0) {
      			return position;
    		}

    		int offset;

    		do {
      			if ((len & 0xC0) == 0xC0) {
        			if (position >= length) {
          				return -1;
        			}
	        		offset = ((len & 0x3F) << 8) | (data[position++] & 0xFF);
		        	proc(offset);
	        		return position;
      			} else {
        			if ((position + len) > length) {
          				return -1;
        			}
        			name += ASCII.GetString(data, position, len);
        			position += len;
      			}

      			if (position > length) {
        			return -1;
      			}

				len = data[position++] & 0xFF;

      			if (len != 0) {
	        		name += ".";
      			}
    		}while (len != 0);

	    	return position;
		}
	}
}*/