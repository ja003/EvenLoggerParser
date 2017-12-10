using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace EvenLoggerParser
{
	class Program
	{
		static void Main(string[] args)
		{
			EventRecordParser parser = new EventRecordParser();
			List<EventRecord> records = parser.ParseFile(
				//"D:\\ja004\\Dropbox\\Project\\coding\\EvenLoggerParser\\events_test.txt");
				"D:\\ja004\\Dropbox\\Project\\coding\\EvenLoggerParser\\events_2017_12_10 - 2017_01_11.txt");

			/*int mCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Masturbation, records);
			DateTime mAverage = EventRecordAnalyzer.GetAverageTime(EventCode.Masturbation, records);


			int wakeCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.WakeUp, records);
			DateTime wakeAverage = EventRecordAnalyzer.GetAverageTime(EventCode.WakeUp, records);

			int sleepCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Sleep, records);
			DateTime sleepAverage = EventRecordAnalyzer.GetAverageTime(EventCode.Sleep, records);
			*/

			DateTime sleepAverage = EventRecordAnalyzer.GetAverageTime(EventCode.Sleep, records, new DateTime(1, 1, 1, 23, 59, 59));
			//TODO: make weighted average
			DateTime sleepAverage22 = EventRecordAnalyzer.GetAverageTime(EventCode.Sleep, records, new DateTime(1, 1, 1, 22, 59, 59));
			DateTime sleepAverage21 = EventRecordAnalyzer.GetAverageTime(EventCode.Sleep, records, new DateTime(1, 1, 1, 21, 59, 59));
			DateTime wakeAverage = EventRecordAnalyzer.GetAverageTime(EventCode.WakeUp, records);
			//zde upřesnit čas netřeba (udělá malý rozdíl)
			//DateTime wakeAverage = EventRecordAnalyzer.GetAverageTime(EventCode.WakeUp, records, new DateTime(1, 1, 1, 8, 0, 0));

			int sexTerkaCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Sex, records, new DateTime(2017, 6, 1));

			int mCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Masturbation, records);
			DateTime mAverage = EventRecordAnalyzer.GetAverageTime(EventCode.Masturbation, records);

			/*int sexCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Sex, records);
			int sexTerkaCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Sex, records, new DateTime(2017, 6, 1));


			int sportCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Sport, records);
			int posilovaniCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Posilovani, records);
			*/
			Console.ReadLine();
		}
	}
}