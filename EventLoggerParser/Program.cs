using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace EventLoggerParser
{
	class Program
	{
		static void Main(string[] args)
		{
			EventRecordParser parser = new EventRecordParser();
			string solutionPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
			string file = solutionPath + "\\records\\" + "events_2017_12_28 - 2017_01_11.txt";
			List<EventRecord> records = parser.ParseFile(file);
			Console.WriteLine(file);


			/*int mCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Masturbation, records);
			DateTime mAverage = EventRecordAnalyzer.GetAverageTime(EventCode.Masturbation, records);


			int wakeCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.WakeUp, records);
			DateTime wakeAverage = EventRecordAnalyzer.GetAverageTime(EventCode.WakeUp, records);

			int sleepCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Sleep, records);
			DateTime sleepAverage = EventRecordAnalyzer.GetAverageTime(EventCode.Sleep, records);
			*/

			bool export = false;
			if (export)
			{
				List<EventRecord> poop = parser.ExtractRecordsOfName(records, EventCode.Poop);
				List<EventRecord> masturbation = parser.ExtractRecordsOfName(records, EventCode.Masturbation);
				List<EventRecord> sleep = parser.ExtractRecordsOfName(records, EventCode.Sleep);
				List<EventRecord> wakeUp = parser.ExtractRecordsOfName(records, EventCode.WakeUp);

				IEnumerable<EventRecord> allTogether = poop.Concat(masturbation).Concat(sleep).Concat(wakeUp);
				List<EventRecord> allTogetherList = allTogether.ToList();

				Console.WriteLine("exporting num of poop = " + poop.Count);
				DataExporter.ExportRecords(poop);
				Console.WriteLine("exporting num of sleep = " + sleep.Count);
				DataExporter.ExportRecords(sleep);
				Console.WriteLine("exporting num of masturbation = " + masturbation.Count);
				DataExporter.ExportRecords(masturbation);
				Console.WriteLine("exporting num of wakeUp = " + wakeUp.Count);
				DataExporter.ExportRecords(wakeUp);
				DataExporter.ExportRecords(allTogetherList, "All");
			}

			/*
			DateTime sleepAverage = EventRecordAnalyzer.GetAverageTime(EventCode.Sleep, records, new DateTime(1, 1, 1, 23, 59, 59));
			//TODO: make weighted average
			DateTime sleepAverage22 = EventRecordAnalyzer.GetAverageTime(EventCode.Sleep, records, new DateTime(1, 1, 1, 22, 59, 59));
			DateTime sleepAverage21 = EventRecordAnalyzer.GetAverageTime(EventCode.Sleep, records, new DateTime(1, 1, 1, 21, 59, 59));
			DateTime wakeAverage = EventRecordAnalyzer.GetAverageTime(EventCode.WakeUp, records);
			*/
			//zde upřesnit čas netřeba (udělá malý rozdíl)
			//DateTime wakeAverage = EventRecordAnalyzer.GetAverageTime(EventCode.WakeUp, records, new DateTime(1, 1, 1, 8, 0, 0));


			int sexCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Sex, records);
			int sexTerkaCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Sex, records, new DateTime(2017, 6, 1));

			int mCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Masturbation, records);
			int poopCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Poop, records);
			int sleepCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Sleep, records);
			int wakeUpCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.WakeUp, records);

			int sportCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Sport, records);
			int posilovaniCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Posilovani, records);
			
			Console.ReadLine();
		}
	}
}