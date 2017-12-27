using System;
using System.Collections.Generic;
using System.Text;

namespace EventLoggerParser
{
	public class EventRecord
	{
		public string name;
		public DateTime dateTime;
		public bool isCorrect;
		public bool isAdditional;
		public List<string> additional;

		public EventRecord() { }

		public EventRecord(string pLine)
		{
			string[] parts = pLine.Split(' ');
			isCorrect = false;
			additional = new List<string>();

			if(parts.Length < 4)
			{
				if (parts[0] == "-")
				{
					isAdditional = true;
					string s = "";
					for (int i = 1; i < parts.Length; i++)
					{
						s += parts[i];
						if (i < parts.Length - 1)
						{
							s += " ";
						}
					}
					additional.Add(s);
					//Console.WriteLine(pLine + " is additional | " + s);
				}
				//Console.WriteLine(pLine + " is not correct record");
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

		public void AddAdditional(EventRecord additionalEvent)
		{
			additional.Add(additionalEvent.additional[0]);
		}

		public EventRecord Clone()
		{
			EventRecord er = new EventRecord();
			er.name = name;
			er.dateTime = dateTime;
			er.isCorrect = isCorrect;
			er.isAdditional = isAdditional;
			er.additional = additional;
			return er;
		}
	}
}
