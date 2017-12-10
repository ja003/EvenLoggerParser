using System;
using System.Collections.Generic;
using System.Text;

namespace EvenLoggerParser
{
	static class EventRecordAnalyzer
	{
		public static int GetEventRecordCount(string pName, List<EventRecord> pRecords)
		{
			int count = 0;
			foreach (EventRecord er in pRecords) { if (er.name == pName) { count++; } }
			Console.WriteLine("Count of " + pName + " is: " + count);
			return count;
		}

		public static DateTime GetAverageTime(string pName, List<EventRecord> pRecords)
		{
			int count = 0;
			long ticks = 0;
			foreach (EventRecord er in pRecords)
			{
				if (er.name == pName)
				{
					count++;
					EventRecord copy = er.Clone();
					copy.dateTime = new DateTime(1, 1, 1, copy.dateTime.Hour, copy.dateTime.Minute, copy.dateTime.Second);
					ticks += copy.dateTime.Ticks;
				}
			}
			DateTime dateTime = new DateTime(ticks / count);

			Console.WriteLine("Average time of " + pName + " is: " + dateTime.Hour + ":" + dateTime.Minute);

			return dateTime;
		}
	}
}
