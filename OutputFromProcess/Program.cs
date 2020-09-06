using System;
using System.Diagnostics;

namespace OutputFromProcess
{
	class Program
	{
		static void Main(string[] args)
		{
			ListProcesses();
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		private static void ListProcesses()
		{
			Process[] processCollection = Process.GetProcesses();
			int i = 0;
			foreach (Process p in processCollection)
			{
				i++;
				Console.WriteLine($"{i}\t{p.ProcessName}\t{p.MainWindowTitle}");
			}
		}
	}
}
