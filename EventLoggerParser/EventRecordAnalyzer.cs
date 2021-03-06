﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EventLoggerParser
{
	static class EventRecordAnalyzer
	{

		public static int GetEventRecordCount(
			string pName,
			List<EventRecord> pRecords,
			DateTime? pFrom = null,
			DateTime? pTo = null)
		{
			int count = 0;
			foreach(EventRecord er in pRecords)
			{
				if(er.Name == pName || er.Additional.Contains(pName))
				{
					if (pFrom != null && er.DateTime < pFrom || pTo != null && er.DateTime > pTo)
					{

					}
					else
					{
						count++;
					}
				}
			}
			Console.WriteLine("Count of " + pName + " = " + count);
			return count;
		}

		public static DateTime GetAverageTime(string pName, List<EventRecord> pRecords, DateTime? pAverageTime = null)
		{
			int count = 0;
			long ticks = 0;
			if (pAverageTime == null)
			{
				pAverageTime = new DateTime(1, 1, 1, 0, 0, 0);
			}
			else
			{
				pAverageTime = new DateTime(1, 1, 1, 
					pAverageTime.Value.Hour, pAverageTime.Value.Minute, pAverageTime.Value.Second);
			}

			foreach(EventRecord er in pRecords)
			{
				if(er.Name == pName)
				{
					count++;
					EventRecord copy = er.Clone();
					copy.DateTime = new DateTime(1, 1, 1, copy.DateTime.Hour, copy.DateTime.Minute, copy.DateTime.Second);
					long erTicks = copy.DateTime.Ticks;
					if (erTicks < pAverageTime.Value.Ticks &&
					    (pAverageTime.Value.Ticks - erTicks) > pAverageTime.Value.Ticks / 2)
					{
						erTicks += pAverageTime.Value.Ticks;
					}
					ticks += erTicks;
				}
			}
			if (count == 0)
			{
				Console.WriteLine("No records of " + pName + " found.");
				return DateTime.MaxValue;
			}
			DateTime dateTime = new DateTime(ticks / count);

			Console.WriteLine("Average time of " + pName + " is: " + dateTime.Hour + ":" + dateTime.Minute);

			return dateTime;
		}
	}
}
