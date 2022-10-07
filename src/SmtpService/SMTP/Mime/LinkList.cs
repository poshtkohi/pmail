/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.ComponentModel;

namespace MIME
{
	//----------------------------------------------------------------------------------
	public class LinkList
	{
		private node first;
		private node last;
		private Component component = new Component();
		private bool disposed = false;
		//-----------------------------------------
		private class node
		{
			public node next;
			public object data;
			private Component component = new Component();
			private bool disposed = false;
			//-------------
			public node()
			{
			}
			//------------
			public void Dispose()
			{
				data = null;
				next = null;
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			//-------------
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
			//-------------
			~node()      
			{
				Dispose(false);
			}
			//-------------
		}
		//-----------------------------------------
		public LinkList()
		{
			this.first = null;
			this.last = null;
		}
		//-------------
		public void Add(object data)
		{
			node newPtr = new node();
			if(newPtr != null)
			{
				newPtr.data = data;
				newPtr.next = null;
				if(first == null) 
					first = last = newPtr;
				else 
				{
					last.next = newPtr;
					last = newPtr;
				}
				return ;
			}
			else return ;
		}
		//-------------
		public void Delete(object data)
		{
			node curPtr = this.first ;
			node nextPtr = this.first ;
			while(nextPtr != null)
			{
				if(data == nextPtr.data)
				{
					if(nextPtr == this.first)
					{
						first = first.next;
						nextPtr.Dispose();
						nextPtr = null;
						//GC.Collect();
						break;
					}
					else
					{
						if(nextPtr == this.last)
						{
							this.last = curPtr;
						}
						curPtr.next = nextPtr.next;
						nextPtr.Dispose();
						nextPtr = null;
						//GC.Collect();
						break;
					}
				}
				else
				{
					curPtr = nextPtr;
					nextPtr = nextPtr.next;
				}
			}
		}
		//-------------
		private node FindNode(object data)
		{
			node curPtr = first;
			while(curPtr != null)
			{
				if(curPtr.data == data)
					return curPtr;
				curPtr = curPtr.next;
			}
			return null;
		}
		//-------------
		private void travel()
		{
			node curPtr = first;
			while(curPtr != null)
			{
				//Console.Write(curPtr.data);
				curPtr = curPtr.next;
			}
			return ;
		}
		//-------------
		private void DeleteAll()
		{
			node curPtr = first ;
			node temp ;
			while(curPtr != null)
			{
				temp = curPtr;
				curPtr = curPtr.next;
				temp.Dispose();
				temp  = null;
			}
			GC.Collect();
			return ;
		}
		//------------
		public void Dispose()
		{
			DeleteAll();
			Dispose(true);
			GC.SuppressFinalize(this);
			//GC.Collect();
		}
		//-------------
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
		//-------------
		~LinkList()      
		{
			Dispose(false);
		}
		//-------------
	}
	//----------------------------------------------------------------------------------
}
