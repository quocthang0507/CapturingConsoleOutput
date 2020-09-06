using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp
{
	class Program
	{
		private const string Path = "output.txt";

		static void Main(string[] args)
		{
			var proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = @"C:\Windows\system32\cmd.exe",
					Arguments = "/c ipconfig",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true
				}
			};
			proc.Start();
			if (File.Exists(Path))
				File.Create(Path);
			using (StreamWriter writer = File.AppendText(Path))
			{
				while (!proc.StandardOutput.EndOfStream)
				{
					string line = proc.StandardOutput.ReadLine();
					// do something with line
					writer.WriteLine(line);
				}
			}
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}
