using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace EvenLoggerParser
{
	class Program
	{
		static void Main(string[] args)
		{

			List<EventRecord> records = EventRecordParser.ParseFile(
				"D:\\ja004\\Dropbox\\Project\\coding\\EvenLoggerParser\\events_2017_12_10 - 2017_01_11.txt");

			int mCount = EventRecordAnalyzer.GetEventRecordCount("M", records);
			DateTime mAverage = EventRecordAnalyzer.GetAverageTime("M", records);


			int wakeCount = EventRecordAnalyzer.GetEventRecordCount("Wake", records);
			DateTime wakeAverage = EventRecordAnalyzer.GetAverageTime("Wake", records);

			int sleepCount = EventRecordAnalyzer.GetEventRecordCount("Sleep", records);
			DateTime sleepAverage = EventRecordAnalyzer.GetAverageTime("Sleep", records);


			Console.ReadLine();
		}
	}
}