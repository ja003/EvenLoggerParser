using System;
using System.Collections.Generic;

namespace EvenLoggerParser
{
	class Program
	{
		static void Main(string[] args)
		{

			List<EventRecord> records = EventRecordParser.ParseFile("C:\\Users\\ja004\\Dropbox\\Project\\coding\\EvenLoggerParser\\events_2017_06_24.txt");

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