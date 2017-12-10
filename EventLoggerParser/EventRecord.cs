using System;
using System.Collections.Generic;
using System.Text;

namespace EvenLoggerParser
{
	class EventRecord
	{
		public string name;
		public DateTime dateTime;
		public bool isCorrect;

		public EventRecord() { }

		public EventRecord(string pLine)
		{
			string[] parts = pLine.Split(' ');
			if (parts.Length < 4)
			{
				//Console.WriteLine(pLine + " is not correct record");
				isCorrect = false;
				return;
			}
			string[] date = parts[0].Split('/');   // month/day/year
			string[] time = parts[1].Split(':');   // hour:minute:second

			dateTime = new DateTime(
				int.Parse(date[2]), int.Parse(date[0]), int.Parse(date[1]),
				int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
			name = parts[3];
			isCorrect = true;
		}

		public EventRecord Clone()
		{
			EventRecord er = new EventRecord();
			er.name = name;
			er.dateTime = dateTime;
			er.isCorrect = isCorrect;
			return er;
		}
	}
}
