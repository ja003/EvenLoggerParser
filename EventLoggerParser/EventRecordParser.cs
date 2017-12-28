using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EventLoggerParser
{
	public class EventRecordParser
	{
		private EventRecord lastCorrectRecord;

		public List<EventRecord> ParseFile(string pFile)
		{
			int counter = 0;
			string line;

			List<EventRecord> records = new List<EventRecord>();

			// Read the file and display it line by line.
			var filestream = new System.IO.FileStream(pFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			StreamReader file = new StreamReader(filestream);
			while((line = file.ReadLine()) != null)
			{
				//Console.WriteLine(line);
				EventRecord er = new EventRecord(line);
				if(er.IsCorrect)
				{
					records.Add(er);
					lastCorrectRecord = er;
				}
				else if(er.IsAdditional)
				{
					lastCorrectRecord.AddAdditional(er);
				}
				counter++;
			}
			return records;
		}

		public List<EventRecord> ExtractRecordsOfName(List<EventRecord> pRecords, string pName)
		{
			List<EventRecord> records = new List<EventRecord>();
			foreach(EventRecord r in pRecords)
			{
				if (r.Name == pName)
				{
					records.Add(r.Clone());
				}
			}
			return records;
		}
	}
}
