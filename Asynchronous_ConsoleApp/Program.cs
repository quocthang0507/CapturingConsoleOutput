using System;
using System.Diagnostics;
using System.IO;

namespace Asynchronous_ConsoleApp
{
	class Program
	{
		private const string path = "output.txt";
		private static StreamWriter writer;

		static void Main(string[] args)
		{
			// Create new file when running program
			if (File.Exists(path))
				File.Delete(path);
			writer = File.AppendText(path);
			// Run and wait until process has exited
			RunCommand();
			writer.Close();
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		private static void RunCommand()
		{
			//* Create your Process
			Process process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = "/c DIR",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true
				}
			};
			//* Set your output and error (asynchronous) handlers
			process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
			process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);

			//* Start process and handlers
			process.Start();
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();
			process.WaitForExit();
		}

		private static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
		{
			writer.WriteLine(outLine.Data);
		}
	}
}
