using CapturingConsoleOutput.Shared;
using System;
using System.Diagnostics;

namespace OutputFromProcess
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter PID number: ");
			int pid = Convert.ToInt32(Console.ReadLine());
			CapturingProcess capturing = new CapturingProcess(pid, "output.txt");
			//capturing.ShowRunningProcesses();
			capturing.CaptureAfterWaiting();
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}


	}
}
