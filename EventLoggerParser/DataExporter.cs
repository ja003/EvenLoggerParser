using System;
using System.Collections.Generic;
using System.IO;

namespace EventLoggerParser
{
	public static class DataExporter
	{
		public static void ExportRecords(List<EventRecord> pRecords)
		{
			EventRecord firstRecord = pRecords[0];
			string solutionPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
			string folder = "\\records\\" + firstRecord.Name;
			//string fullFilePath = solutionPath + "\\records\\" + firstRecord.name + "_" + DateTime.Now.ToString("hh:mm:ss") + ".txt";
			string fullFilePath = Path.Combine(solutionPath + folder, firstRecord.Name + "-"  + DateTime.Now.ToString("yyyy_MM_dd") + "-" + DateTime.Now.ToString("hh_mm_ss") + ".txt");
			Console.WriteLine("exporting to : " + fullFilePath);

			//System.IO.File.CreateText(file);
			using(System.IO.StreamWriter file = new System.IO.StreamWriter(@fullFilePath))
			//using(System.IO.StreamWriter file = 
			//	new System.IO.StreamWriter(@"C:\Users\Admin\Dropbox\Project\coding\EvenLoggerParser\EvenLoggerParser\EventLoggerParser\records\file1.txt"))
			{
				foreach (EventRecord r in pRecords)
				{
					file.WriteLine(r.ToString());
				}
			}
		}
	}
}