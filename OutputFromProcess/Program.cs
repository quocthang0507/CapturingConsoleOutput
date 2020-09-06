using CapturingConsoleOutput.Shared;
using System;
using System.Diagnostics;

namespace OutputFromProcess
{
	class Program
	{
		static void Main(string[] args)
		{
			CapturingProcess capturing = new CapturingProcess();
			capturing.ShowRunningProcesses();
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}


	}
}
