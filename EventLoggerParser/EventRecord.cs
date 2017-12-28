using System;
using System.Collections.Generic;

namespace EventLoggerParser
{
	public class EventRecord
	{
		private static string SEPARATOR = ",";
		
		public string Name;
		public DateTime DateTime;
		public bool IsCorrect;
		public bool IsAdditional;
		public List<string> Additional;

		public EventRecord() { }

		public EventRecord(string pLine)
		{
			string[] parts = pLine.Split(' ');
			IsCorrect = false;
			Additional = new List<string>();

			if(parts.Length < 4)
			{
				if (parts[0] == "-")
				{
					IsAdditional = true;
					string s = "";
					for (int i = 1; i < parts.Length; i++)
					{
						s += parts[i];
						if (i < parts.Length - 1)
						{
							s += " ";
						}
					}
					Additional.Add(s);
					//Console.WriteLine(pLine + " is additional | " + s);
				}
				//Console.WriteLine(pLine + " is not correct record");
				return;
			}
			string[] date = parts[0].Split('/');   // month/day/year
			string[] time = parts[1].Split(':');   // hour:minute:second

			DateTime = new DateTime(
				int.Parse(date[2]), int.Parse(date[0]), int.Parse(date[1]),
				int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
			Name = parts[3];
			IsCorrect = true;
		}

		public void AddAdditional(EventRecord additionalEvent)
		{
			Additional.Add(additionalEvent.Additional[0]);
		}

		public EventRecord Clone()
		{
			EventRecord er = new EventRecord();
			er.Name = Name;
			er.DateTime = DateTime;
			er.IsCorrect = IsCorrect;
			er.IsAdditional = IsAdditional;
			er.Additional = Additional;
			return er;
		}

		public override string ToString()
		{
			string result = Name + SEPARATOR + DateTime.ToString("dd-MM-yyyy") + SEPARATOR + DateTime.ToString("HH:mm:ss");
			//Console.WriteLine(DateTime + " to " + result);
			return result;
		}
	}
}
