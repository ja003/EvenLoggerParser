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

			/*int mCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Masturbation, records);
			DateTime mAverage = EventRecordAnalyzer.GetAverageTime(EventCode.Masturbation, records);


			int wakeCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.WakeUp, records);
			DateTime wakeAverage = EventRecordAnalyzer.GetAverageTime(EventCode.WakeUp, records);

			int sleepCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Sleep, records);
			DateTime sleepAverage = EventRecordAnalyzer.GetAverageTime(EventCode.Sleep, records);
			*/

			int sportCount = EventRecordAnalyzer.GetEventRecordCount(EventCode.Sport, records);

			Console.ReadLine();
		}
	}
}