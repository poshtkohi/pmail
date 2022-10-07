
/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/
u
sing System;

namespace pmail
{
	//-----------------------------------------------------------------------------------------------------
	public class SignUpInfo
	{
		private string fname = null;
		private string lname = null;
		private string username = null;
		private string password = null;
		private string email = null;
		private DateTime birth;
		private bool sex = false;
		private string zipCode = null;
		private string country = null;
		private int securityQuestion = 0;
		private string answer = null;
		private string phone = null;
		private string profession = null;
		public SignUpInfo(string FirstName, string LastName, string username, string password, string email, DateTime BirthDate,
			              bool sex, string ZipCode, string country, string answer, string phone, string profession, int SeurityQuestion)
		{
			this.fname = FirstName;
			this.lname = LastName;
			this.username = username;
			this.password = password;
			this.email = email;
			this.birth = BirthDate;
			this.sex = sex;
			this.zipCode = ZipCode;
			this.country = country;
			this.answer = answer;
			this.phone = phone;
			this.profession = profession;
			this.securityQuestion = SecurityQuestion;
		}
		//--------------------
		public string FirstName
		{
			get
			{
				return this.fname;
			}
		}
		//--------------------
		public string LastName 
		{
			get
			{
				return this.lname;
			}
		}
		//--------------------
		public string Username
		{
			get
			{
				return this.username;
			}
		}
		//--------------------
		public string Password
		{
			get
			{
				return this.password;
			}
		}
		//--------------------
		public string Email
		{
			get
			{
				return this.email;
			}
		}
		//--------------------
		public bool Sex 
		{
			get
			{
				return this.sex;
			}
		}
		//--------------------
		public DateTime BirthDate
		{
			get
			{
				return this.birth;
			}
		}
		//--------------------
		public string ZipCode 
		{
			get
			{
				return this.zipCode;
			}
		}
		//--------------------
		public string Country 
		{
			get
			{
				return this.country;
			}
		}
		//--------------------
		public string Answer 
		{
			get
			{
				return this.answer;
			}
		}
		//--------------------
		public string Phone
		{
			get
			{
				return this.phone;
			}
		}
		//--------------------
		public string Profession 
		{
			get
			{
				return this.profession;
			}
		}
		//--------------------
		public int SecurityQuestion
		{
			get
			{
				return this.securityQuestion;
			}
		}
		//--------------------
	}
	//-----------------------------------------------------------------------------------------------------
}
