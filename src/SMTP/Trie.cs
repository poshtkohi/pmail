/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;

namespace SMTP
{
	//----------------------------------------------------------
	public class Trie
	{
		private node root;
		private class node
		{
			public node next;
			public node first;
			public node last;
			public node father;
			public object data;
			public char c;
			//-------------
			public node()
			{
				this.first = null;
				this.last = null;
			}
			//-------------
			public node addSubNode(char c, object data)
			{
				node newPtr = new node();
				newPtr.data = data;
				newPtr.c = c;
				newPtr.next = null;
				if(newPtr != null)
				{
					if(first == null) first = last = newPtr;
					else 
					{
						last.next = newPtr;
						last = newPtr;
					}
					return last;
				}
				else return null;
			}
			//-------------
			public void delSubNode(char c)
			{
				node curPtr = this.first ;
				node nextPtr = this.first ;
				while(nextPtr != null)
				{
					if(c == nextPtr.c)
					{
						if(nextPtr == this.first)
						{
							first = first.next;
							//nextPtr.next = null;
							nextPtr = null;
							GC.Collect();
							break;
						}
						else
						{
							if(nextPtr == this.last)
							{
								this.last = curPtr;
							}
							curPtr.next = nextPtr.next;
							//nextPtr.next = null;
							nextPtr = null;
							GC.Collect();
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
			static public node FindNode(char c, node Node)
			{
				node curPtr = Node.first;
				while(curPtr != null)
				{
					if(curPtr.c == c)
						return curPtr;
					curPtr = curPtr.next;
				}
				return null;
			}
			//-------------
			public void travel(node Node)
			{
				if(Node.first != null)
				{
					node curPtr = Node.first;
					while(curPtr != null)
					{
						Console.Write(curPtr.c);
						travel(curPtr);
						curPtr = curPtr.next;
					}
				}
				return ;
			}
			//-------------
		}
		//----------------------------
		public Trie()
		{
			node nodeRoot = new node();
			nodeRoot.data = null;
			nodeRoot.father = null;
			this.root = nodeRoot;
			return ;
		}
		//----------------------------
		public bool AddUsernameAccount(string username, object data)
		{
			if(!this.FindCompleteUsername(username))
			{
				node n = this.root;
				node temp = n;
				int i = 0;
				for( ; i < username.Length ; i++)
				{
					n = Trie.node.FindNode(username[i], n);
					if(n == null)
					{
						break;
					}
					if(n != null && n.data == null && i == username.Length - 1)
					{
						n.data = data;
						return true;
					}
					temp = n;
				}
				node father = temp;
				for(int j = i ; j < username.Length ; j++)
				{
					if(j == username.Length - 1)
					{
						temp = temp.addSubNode(username[j], data);
						temp.father = father;
						break;
					}
					else
					{
						temp = temp.addSubNode(username[j], null);
						temp.father = father;
						father = temp;
					}
				}
				return true;
			}
			else return false;
		}
		//----------------------------
		public bool DeleteUsernameAccount(string username)
		{
			if(this.FindCompleteUsername(username))
			{
				node n = this.root;
				for(int i = 0 ; i < username.Length ; i++)
				{
					n = Trie.node.FindNode(username[i], n);
				}
				node temp = n;
				node father = null;
				for(int j = username.Length - 1 ; j  >= 0 ; j--)
				{
					if(temp.first == null)
					{
						father = temp.father;
						father.delSubNode(temp.c);
						temp = father;
					}
					else
					{
						if(j == username.Length - 1)
						{
							temp.data = null;
						}
						break;
					}
				}
				GC.Collect();
				return true;
			}
			else return false;
		}
		//----------------------------
		public void travel()
		{
			this.root.travel(this.root);
			return ;
		}
		//----------------------------
		public object FindAccountData(string username)
		{
			node n = this.root;
			for(int i = 0 ; i < username.Length ; i++)
			{
				n = Trie.node.FindNode(username[i], n);
				if(n == null)
				{
					return null;
				}
			}
			if(n.data == null) return null;
			else return n.data;
		}
		//----------------------------
		public void UpdateAccountData(string username, object data)
		{
			node n = this.root;
			for(int i = 0 ; i < username.Length ; i++)
			{
				n = Trie.node.FindNode(username[i], n);
				if(n == null)
				{
					return ;
				}
			}
			if(n.data != null)
			{
				n.data = data;
			}
			return ;
		}
		//----------------------------
		public bool FindCompleteUsername(string username)
		{
			node n = this.root;
			for(int i = 0 ; i < username.Length ; i++)
			{
				n = Trie.node.FindNode(username[i], n);
				if(n == null)
				{
					return false;
				}
			}
			if(n.data == null) return false;/////
			else return true;////
			//return true;
		}
		//----------------------------
	}
//----------------------------------------------------------
}