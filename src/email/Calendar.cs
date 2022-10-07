/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;

namespace Cyber.email
{
	public class Calendar
	{
		public Calendar()
		{
		}
		//-------------------------------------------------------------------------------------
		static public string CompleteStringTime(DateTime dt)
		{
			return String.Format("{0}, {1} {2}, {3} {4}", dt.DayOfWeek.ToString(),GeorgianIntMonthToStringComplete(dt.Month),
				                 dt.Day, dt.Year, PrintTime(dt));
		}
		//-------------------------------------------------------------------------------------
		static private string PrintTime(DateTime dt)
		{
			uint hour = (uint) dt.Hour;
			uint minute = (uint) dt.Minute;
			string time = "";
			if(hour == 0)
			{
				time += "12" + ":";
				if(minute < 10)
				{
					time += "0" + minute.ToString();
				}
				else
				{
					time += minute.ToString();
				}
				time += " AM";
			}
			if(hour == 12)
			{
				time += hour.ToString() + ":";
				if(minute < 10)
				{
					time += "0" + minute.ToString();
				}
				else
				{
					time += minute.ToString();
				}
				time += " PM";
			}
			else
			{
				if(hour >= 1 && hour < 12)
				{
					time += hour.ToString() + ":";
					if(minute < 10)
					{
						time += "0" + minute.ToString();
					}
					else
					{
						time += minute.ToString();
					}
					time += " AM";
				}
				if(hour > 12)
				{
					time += (hour - 12).ToString() + ":";
					if(minute < 10)
					{
						time += "0" + minute.ToString();
					}
					else
					{
						time += minute.ToString();
					}
					time += " PM";
				}
			}
			return time;
		}
		//-------------------------------------------------------------------------------------
		static public string GeorgianIntMonthToString(int MonthNumber)
		{
			switch(MonthNumber)
			{
				case 1: //January
				{
					return "Jan";
				}
				case 2: //February
				{
					return "Feb";
				}
				case 3: //March
				{
					return "Mar";
				}
				case 4: //April
				{
					return "Apr";
				}
				case 5: //May
				{
					return "May";
				}
				case 6: //June
				{
					return "Jun";
				}
				case 7: //July
				{
					return "Jul";
				}
				case 8: //August
				{
					return "Aug";
				}
				case 9: //September
				{
					return "Sep";
				}
				case 10: //October
				{
					return "Oct";
				}
				case 11: //November
				{
					return "Nov";
				}
				case 12: //December
				{
					return "Dec";
				}
				default: return "Jan";
			}
		}
		//-------------------------------------------------------------------------------------
		static public string GeorgianIntMonthToStringComplete(int MonthNumber)
		{
			switch(MonthNumber)
			{
				case 1: //January
				{
					return "January";
				}
				case 2: //February
				{
					return "February";
				}
				case 3: //March
				{
					return "March";
				}
				case 4: //April
				{
					return "April";
				}
				case 5: //May
				{
					return "May";
				}
				case 6: //June
				{
					return "June";
				}
				case 7: //July
				{
					return "July";
				}
				case 8: //August
				{
					return "August";
				}
				case 9: //September
				{
					return "September";
				}
				case 10: //October
				{
					return "October";
				}
				case 11: //November
				{
					return "November";
				}
				case 12: //December
				{
					return "December";
				}
				default: return "Jan";
			}
		}
		//-------------------------------------------------------------------------------------
		static private int GeorgianMonthHowMuchDays(int MonthNumber, int YearNumber)
		{
			int days = 28;
			switch(MonthNumber)
			{
				case 1: //January
				{
					days = 31;
					break;
				}
				case 2: //February
				{
					if(YearNumber%4 == 0)
					{
						days = 29;
					}
					else
					{
						days = 28;
					}
					break;
				}
				case 3: //March
				{
					days = 31;
					break;
				}
				case 4: //April
				{
					days = 30;
					break;
				}
				case 5: //May
				{
					days = 31;
					break;
				}
				case 6: //June
				{
					days = 30;
					break;
				}
				case 7: //July
				{
					days = 31;
					break;
				}
				case 8: //August
				{
					days = 31;
					break;
				}
				case 9: //September
				{
					days = 30;
					break;
				}
				case 10: //October
				{
					days = 31;
					break;
				}
				case 11: //November
				{
					days = 30;
					break;
				}
				case 12: //December
				{
					days = 31;
					break;
				}
			}
			return days;
		}
		//-------------------------------------------------------------------------------------
	}
}