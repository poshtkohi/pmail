/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.ComponentModel;
using System.Collections;

namespace Mime.ASCII
{
	//----------------------------------------------------------------------------------------------------
	public class AsciiString //: IEnumerator, IEnumerable
	{
		//----------------------------------------------------
		private byte[] bytes = null;
		/// <summary>
		/// AsciiString class constructure that instansiate from an UTF8 String buffer.
		/// </summary>
		/// <param name="buffer">Input buffer.</param>
		public AsciiString(byte[] buffer)
		{
			this.bytes = buffer;
		}
		public AsciiString(byte[] buffer, int Size)
		{
			this.bytes = new byte[Size];
			for(int i = 0 ; i < this.bytes.Length ; i++)
				this.bytes[i] = buffer[i];
		}
		//----------------------------------------------------
		/// <summary>
		/// Get Byte[] of this AsciiStream instance.
		/// </summary>
		public byte[] BaseStream
		{
			get
			{
				return this.bytes;
			}
		}
		//----------------------------------------------------
		/// <summary>
		/// AsciiString class constructure that instansiate from an UTF8 String buffer.
		/// </summary>
		/// <param name="buffer">Input buffer.</param>
		public AsciiString(string buffer)
		{
			this.bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(buffer);
		}
		//----------------------------------------------------
		/// <summary>
		/// Get value in index.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public byte GetValue(int index)
		{
			return this.bytes[index];
		}
		//----------------------------------------------------
		/// <summary>
		/// Find the length of this instance.
		/// </summary>
		public int Length
		{
			get
			{
				if(bytes == null)
					return 0;
				else
					return this.bytes.Length;
			}
		}
		//----------------------------------------------------
		/// <summary>
		/// Replaces all occurrences of a specified AsciiString in this instance, with another specified AsciiString.
		/// </summary>
		/// <param name="oldValue"></param>
		/// <param name="newValue"></param>
		/// <returns></returns>
		public AsciiString Replace(AsciiString oldValue,AsciiString newValue)
		{
			ArrayList al = new ArrayList();
			int p1 = 0;
			while(true)
			{
				if(p1 < this.Length)
				{
					p1 = this.IndexOf(oldValue, p1);
					if(p1 >= 0)
					{
						
						al.Add(p1);
						p1 += oldValue.Length;
					}
					else break;
				}
				else 
					break;
			}
			if(al.Count == 0)
			{
				al = null;
				return this;
			}
			else
			{
				AsciiString str = null;
				for(int i = 0 ; i < al.Count ; i++)
				{
					if(i == 0)
						str = this.Substring(0, (int)al[i]) + newValue;
					else
						str = str + this.Substring((int)al[i - 1] + oldValue.Length, (int)al[i] - (int)al[i - 1] - oldValue.Length) + newValue;
				}
				if((int)al[al.Count - 1] + oldValue.Length < this.Length)
					str = str + this.Substring((int)al[al.Count - 1] + oldValue.Length);
				al.Clear();
				al = null;
				return str;
			}
		}
		//----------------------------------------------------
		/// <summary>
		/// Replaces the format item in a specified AsciiString with the text equivalent of the value of a corresponding AsciiString instance in a specified array.
		/// </summary>
		/// <param name="format"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public static AsciiString Format(AsciiString format, params AsciiString[] args)
		{
			ArrayList al = new ArrayList();
			int p1 = 0, p2 = 0;
			while(true)
			{
				if(p1 < format.Length)
				{
					p1 = format.IndexOf(new AsciiString("{"), p1);
					if(p1 >= 0)
					{
						p2 = format.IndexOf(new AsciiString("}"), p1);
						if(p2 > 0)
						{
							int f;
							string val = format.Substring(p1 + 1, p2 - p1 - 1).ToString();
							try
							{
								f = Convert.ToInt32(val);
							}
							catch
							{
								al = null;
								throw new Exception("{" + val + "} has not Int32 format.");
							}
							al.Add(f);
						}
						p1++;
					}
					else 
						break;
				}
				else 
					break;
			}
			if(al.Count == 0)
			{
				al = null;
				return format;
			}
			else
			{
				AsciiString newStr = format;
				for(int i = 0 ; i < al.Count ; i++)
				{
					int f = (int)al[i];
					newStr = newStr.Replace(new AsciiString("{" + f + "}"), args[f]);
				}
				al.Clear();
				al = null;
				return newStr;
			}
		}
		//----------------------------------------------------
		/// <summary>
		/// Removes all occurrences of white space characters from the beginning and end of this instance.
		/// </summary>
		/// <returns></returns>
		public AsciiString Trim()
		{
			int startIndex = -1, endIndex = -1;
			for(int i = 0 ; i < this.Length ; i++)
			{
				if(this.bytes[i] == ' ')
				{
					startIndex = i;
					continue;
				}
				else
				{
					if(i < this.Length - 1)
					{
						if(startIndex != this.Length -1)
						{
							for(int j = this.Length - 1 ; j >= 0; j--)
							{
								if(this.bytes[j] == ' ')
								{
									endIndex = j;
									continue;
								}
								else 
									break;
							}
						}
					}
					break;
				}
			}
			if(startIndex >= 0 && endIndex > 0)
			{
				int len = endIndex - (startIndex + 1);
				byte[] newBuffer = new byte[len];
				for(int i = startIndex + 1 , j = 0; i < endIndex ; i++, j++)
					newBuffer[j] =  this.bytes[i];
				return new AsciiString(newBuffer);
			}
			if(startIndex >= 0 && endIndex == -1)
			{
				int len = this.Length - (startIndex + 1);
				byte[] newBuffer = new byte[len];
				for(int i = startIndex + 1 , j = 0; i < this.Length ; i++, j++)
					newBuffer[j] =  this.bytes[i];
				return new AsciiString(newBuffer);
			}
			if(startIndex == -1 && endIndex > 0)
			{
				byte[] newBuffer = new byte[endIndex];
				for(int i = 0 , j = 0; i < endIndex ; i++, j++)
					newBuffer[j] =  this.bytes[i];
				return new AsciiString(newBuffer);
			}
			else return this;
		}
		//----------------------------------------------------
		public string ToUTF8String()
		{
			return System.Text.UTF8Encoding.UTF8.GetString(this.bytes);
		}
		/// <summary>
		///  Convert this AsciiString instance to .NET System.Text.ASCIIEncoding.ASCII class string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return System.Text.ASCIIEncoding.ASCII.GetString(this.bytes);
		}
		public override int GetHashCode()
		{ 
			return this.GetHashCode(); 
		}
		/*public override bool Equals(object o)
		{
			if(this == o)
				return true;
			else
				return false;
		}*/
		//----------------------------------------------------
		/// <summary>
		/// The substring starts at a specified character position.Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
		/// </summary>
		/// <param name="startIndex"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public AsciiString Substring(int startIndex,int count)
		{
			byte[] buffer = new byte[count];
			for(int i = 0 ; i < count ; i++)
				buffer[i] = this.GetValue(startIndex + i);
			return new AsciiString(buffer);
		}
		//----------------------------------------------------
		/// <summary>
		/// Concatenates two specified instances of AsciiString.
		/// </summary>
		/// <param name="str0"></param>
		/// <param name="str1"></param>
		/// <returns></returns>
		public static AsciiString Concat(AsciiString str0, AsciiString str1)
		{
			return str0 + str1;
		}
		//----------------------------------------------------
		/// <summary>
		/// Retrieves a substring from this instance.
		/// </summary>
		/// <param name="startIndex"></param>
		/// <returns></returns>
		public AsciiString Substring(int startIndex)
		{
			return this.Substring(startIndex, this.Length - startIndex);
		}
		//----------------------------------------------------
		/// <summary>
		/// Reports the index position of the last occurrence of a specified AsciiString within this instance. The search starts at a specified character position.
		/// </summary>
		/// <param name="search"></param>
		/// <param name="startIndex"></param>
		/// <returns></returns>
		public int LastIndexOf(AsciiString search, int startIndex)
		{
			bool first = false, last = false ;
			int n = this.Length;
			int m = search.Length;
			if(m > n)
				return -1;
			if(startIndex >= n)
				throw new Exception("Index was out of range.");
			int start = 0, end = 0;//, end = 0, temp = 0;
			for(int i = startIndex ; i < n  ; i++)
			{
				if(this.GetValue(i) == search.GetValue(0))
				{
					if(search.Length == 1)
					{
						if(first == false)
						{
							first = true;
							start = i;
						}
						if(last == false)
						{
							last = true;
						}
						end = i;
					}
					else
					{
						for(int j = 1 ; j < search.Length ; j++)
						{
							if(i + j >= n) 
								return -1;
							if(this.GetValue(i + j) != search.GetValue(j))
							{
								if(!last)
									last = true;
								break;
							}
							if(j == search.Length - 1)
							{
								if(first == false)
								{
									first = true;
									start = i;
								}
								if(last == false)
								{
									last = true;
								}
								end = i;
							}
						}
					}
				}
			}
			if(last) 
				return end;
			else if(first)
				return start;
			else return -1;
		}
		/// <summary>
		/// Reports the index position of the last occurrence of a specified AsciiString within this instance.
		/// </summary>
		/// <param name="search"></param>
		/// <returns></returns>
		public int LastIndexOf(AsciiString search)
		{
			return this.LastIndexOf(search, 0);
		}
		/// <summary>
		/// Reports the index position of the last occurrence of a specified AsciiString within this instance. The search starts at a specified character position and examines a specified number of character positions.
		/// </summary>
		/// <param name="search"></param>
		/// <param name="startIndex"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public int LastIndexOf(AsciiString search, int startIndex, int count)
		{
			bool first = false, last = false ;
			int n = this.Length;
			int m = search.Length;
			if(m > n) 
				return -1;
			if(startIndex >= n)
				throw new Exception("Index was out of range.");
			int start = 0, end = 0;//, end = 0, temp = 0;
			for(int i = startIndex ; i < startIndex + count ; i++)
			{
				if(this.GetValue(i) == search.GetValue(0))
				{
					if(search.Length == 1)
					{
						if(first == false)
						{
							first = true;
							start = i;
						}
						if(last == false)
						{
							last = true;
						}
						end = i;
					}
					else
					{
						for(int j = 1 ; j < search.Length ; j++)
						{
							if(i + j >= n) 
								return -1;
							if(this.GetValue(i + j) != search.GetValue(j))
							{
								if(!last)
									last = true;
								break;
							}
							if(j == search.Length - 1)
							{
								if(first == false)
								{
									first = true;
									start = i;
								}
								if(last == false)
								{
									last = true;
								}
								end = i;
							}
						}
					}
				}
			}
			if(last) 
				return end;
			else if(first)
				return start;
			else return -1;
			/*for(int i = startIndex ; i < count + startIndex && i < n  ; i++)
			{
				if(this.GetValue(i) == search.GetValue(temp))
				{
					if(temp == 0)
						start = i;
					if(temp == m - 1) 
					{
						stable = start;
						end = i;
						find = true;
						continue;
					}
					temp++;
				}
				else 
					temp = 0;
			}
			if(find) 
				return stable;*/
		}
		//----------------------------------------------------
		/// <summary>
		/// Returns a copy of this AsciiString in uppercase, using the casing rules of the ASCII US.
		/// </summary>
		/// <returns></returns>
		public AsciiString ToUpper()
		{
			byte[] buffer = this.bytes;
			for(int i = 0 ; i < buffer.Length ; i++)
				if(buffer[i] >= 'a' && buffer[i] <= 'z')
					buffer[i] -= 32;
			return new AsciiString(buffer);
		}
		//----------------------------------------------------
		/// <summary>
		/// Returns a copy of this AsciiString in lowercase, using the casing rules of the ASCII US
		/// </summary>
		/// <returns></returns>
		public AsciiString ToLower()
		{
			byte[] buffer = this.bytes;
			for(int i = 0 ; i < buffer.Length ; i++)
				if(buffer[i] >= 'A' && buffer[i] <= 'Z')
					buffer[i] += 32;
			return new AsciiString(buffer);
		}
		//----------------------------------------------------
		/// <summary>
		/// Reports the index of the first occurrence of the specified AsciiString in this instance. The search starts at a specified character position.
		/// </summary>
		/// <param name="search">The AsciiString for searching in this instance.</param>
		/// <returns></returns>
		public int IndexOf(AsciiString search, int startIndex)
		{
			bool find = false;
			int n = this.Length;
			int m = search.Length;
			if(m > n) 
				return -1;
			if(startIndex >= n)
				throw new Exception("Index was out of range.");
			int start = 0;//, end = 0, temp = 0;
			for(int i = startIndex ; i < n  ; i++)
			{
				if(this.GetValue(i) == search.GetValue(0))
				{
					if(search.Length == 1)
						return i;
					for(int j = 1 ; j < search.Length ; j++)
					{
						if(i + j >= n) 
							return -1;
						if(this.GetValue(i + j) != search.GetValue(j))
						{
							find = false;
							//i++;
							break;
						}
						if(j == search.Length - 1)
						{
							find = true;
							start = i;
							goto Exit;
						}
					}
					
				}
			}
			Exit:
			if(find) 
				return start; 
			else return -1;
		}
		/// <summary>
		/// Reports the index of the first occurrence of the specified AsciiString in this instance.
		/// </summary>
		/// <param name="search">The AsciiString for searching in this instance.</param>
		/// <returns></returns>
		public int IndexOf(AsciiString search)
		{
			return IndexOf(search, 0);
		}
		/// <summary>
		/// Reports the index of the first occurrence of the specified AsciiString in this instance. The search starts at a specified character position and examines a specified number of character positions.
		/// </summary>
		/// <param name="search">The AsciiString for searching in this instance.</param>
		/// <returns></returns>
		public int IndexOf(AsciiString search, int startIndex, int count)
		{
			bool find = false;
			int n = this.Length;
			int m = search.Length;
			if(m > n) 
				return -1;
			if(count + startIndex  >= n)
				throw new Exception("Index was out of range.");
			int start = 0;//, end = 0, temp = 0;
			for(int i = startIndex ; i < startIndex + count ; i++)
			{
				if(this.GetValue(i) == search.GetValue(0))
				{
					if(search.Length == 1)
						return i;
					for(int j = 1 ; j < search.Length ; j++)
					{
						if(i + j >= n) 
							return -1;
						if(this.GetValue(i + j) != search.GetValue(j))
						{
							find = false;
							//i++;
							break;
						}
						if(j == search.Length - 1)
						{
							find = true;
							start = i;
							goto Exit;
						}
					}
					
				}
			}
			/*for(int i = startIndex ; i < count + startIndex && i < n  ; i++)
			{
				if(this.GetValue(i) == search.GetValue(temp))
				{
					if(temp == 0) 
						start = i;
					if(temp == m - 1) 
					{
						end = i;
						find = true;
						break;
					}
					temp++;
				}
				else 
					temp = 0;
			}*/
			Exit:
			if(find) 
				return start; 
			else return -1;
		}
		//----------------------------------------------------
		/// <summary>
		/// Compares two specified String objects.
		/// </summary>
		/// <param name="StrA"></param>
		/// <param name="StrB"></param>
		/// <returns></returns>
		public static int Compare(AsciiString StrA, AsciiString StrB)
		{
			if(AsciiString.Equals(null, StrA) && AsciiString.Equals(null, StrB))
				return 0;
			if(AsciiString.Equals(null, StrA) && !AsciiString.Equals(null, StrB))
				return -1;
			if(!AsciiString.Equals(null, StrA) && AsciiString.Equals(null, StrB))
				return -1;
			else
			{
				if(StrA.Length == 0 && StrB.Length > 0)
					return -1;
				if(StrB.Length == 0 && StrA.Length > 0)
					return 1;
				if(StrA.Length > StrB.Length)
					return 1;
				if(StrA.Length < StrB.Length)
					return -1;
				else
				{
					for(int i = 0 ; i < StrA.Length ; i++)
						if(StrA.GetValue(i) != StrB.GetValue(i))
						{
							if(StrA.GetValue(i) > StrB.GetValue(i))
								return 1;
							else
								return -1;
						}
					return 0;
				}
			}
		}
		//----------------------------------------------------
		/*public static bool operator ==(AsciiString StrA, AsciiString StrB)
		{
			if(AsciiString.Compare(StrA, StrB) == 0)
				return true;
			else
				return false;
		}
		public static bool operator !=(AsciiString StrA, AsciiString StrB)
		{
			if(AsciiString.Compare(StrA, StrB) == 0)
				return false;
			else
				return true;
		}*/
		//----------------------------------------------------
		public static AsciiString operator+(AsciiString StrA, AsciiString StrB)
		{
			if(Compare(StrB, null) == 0)
				return StrA;
			if(Compare(StrA, null) == 0)
				return StrB;
			byte[] b = new byte[StrA.Length + StrB.Length];
			int index = StrB.Length + (StrA.Length - StrB.Length);
			for(int i = 0 ; i < b.Length ; i++)
			{
				if(i < StrA.Length)
					b[i] = StrA.GetValue(i);
				if(i >= StrA.Length)
					b[i] = StrB.GetValue(i - index);
			}
			return new AsciiString(b);
		}
		//----------------------------------------------------
	}
	//----------------------------------------------------------------------------------------------------
	public class AsciiStreamWriter : CollectionBase//, IDisposable
	{
		private int StreamSize = 0;
		//private Component component = new Component();
		//private bool disposed = false;
		/// <summary>
		/// Initializes a new instance of the  AsciiStreamWriter class.
		/// </summary>
		public AsciiStreamWriter()
		{
		}
		//--------------------------------
		public int Length
		{
			get
			{
				return this.StreamSize;
			}
		}
		//--------------------------------
		/*public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		//--------------------------------
		private void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				if(disposing)
				{
					component.Dispose();
				} 
			}
			disposed = true;         
		}
		//--------------------------------
		~AsciiStreamWriter()      
		{
			Dispose(false);
		}*/
		//----------------------------------------------------
		/// <summary>
		/// Convert these stream to an AsciiString instance.
		/// </summary>
		/// <returns></returns>
		public AsciiString toString()
		{
			int read = 0;
			byte[] buffer = new byte[this.StreamSize];
			for(int i = 0 ; i < this.Count ; i++)
			{
				AsciiString temp = this[i];
				for(int j = 0 ; j < temp.Length ; j++)
					buffer[read + j] = temp.GetValue(j);
				read += temp.Length;
			}
			return new AsciiString(buffer);
		}
		//----------------------------------------------------
		/// <summary>
		///  Writes to this instance of the AsciiString
		/// </summary>
		/// <returns></returns>
		public void Write(AsciiString value)
		{
			this.StreamSize += value.Length;
			this.Add(value);
		}
		public void Close()
		{
			this.StreamSize = 0;
			this.Clear();
			//GC.Collect(GC.GetGeneration(this));
			//return ;
		}
		//----------------------------------------------------
		private AsciiString this[int index] 
		{
			get  
			{
				return((AsciiString)List[index]);
			}
			set  
			{
				List[index] = value;
			}
		}
		//----------------------------------------------------
		private int Add(AsciiString value) 
		{
			return(List.Add(value));
		}
		//----------------------------------------------------
		private int IndexOf(AsciiString value) 
		{
			return(List.IndexOf(value));
		}
		//----------------------------------------------------
		private void Insert(int index, AsciiString value)
		{
			List.Insert(index, value);
		}
		//----------------------------------------------------
		private void Remove(AsciiString value)  
		{
			List.Remove(value);
		}
		//----------------------------------------------------
		private bool Contains(AsciiString value)  
		{
			// If value is not of type Int16, this will return false.
			return(List.Contains(value));
		}
		//----------------------------------------------------
	}
	//----------------------------------------------------------------------------------------------------
}