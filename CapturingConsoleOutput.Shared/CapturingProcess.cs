using System;
using System.Diagnostics;
using System.Linq;

namespace CapturingConsoleOutput.Shared
{
	public class CapturingProcess
	{
		public Process process { get; }

		public CapturingProcess()
		{

		}

		public CapturingProcess(int pid)
		{
			Process.GetProcessById(pid);
		}

		public void SetProcessID(int pid)
		{
			Process.GetProcessById(pid);
		}

		public void ShowRunningProcesses()
		{
			Process[] processCollection = Process.GetProcesses();
			ConsoleColumn[] header = new ConsoleColumn[] { new ConsoleColumn { Name = "PID", Width = 10 }, new ConsoleColumn { Name = "Name", Width = 50 } };
			ShowALine(header);
			ShowFixedColumn(header);
			ShowALine(header);
			foreach (Process p in processCollection)
			{
				ShowFixedColumn(new ConsoleColumn[]
				{
					new ConsoleColumn{Name=p.Id.ToString(), Width=10},
					new ConsoleColumn{Name=p.ProcessName, Width=50}
				});
			}
		}

		private void ShowFixedColumn(ConsoleColumn[] columns)
		{
			foreach (var col in columns)
			{
				Console.Write(col.Name.PadRight(col.Width, ' '));
			}
			Console.WriteLine();
		}

		private void ShowALine(ConsoleColumn[] columns)
		{
			Console.WriteLine(new string('=', columns.Sum(c => c.Width) + 1));
		}
	}
}
