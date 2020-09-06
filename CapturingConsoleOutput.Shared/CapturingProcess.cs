using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace CapturingConsoleOutput.Shared
{
	public class CapturingProcess
	{
		public Process Process { get { return _process; } }
		public string Path { get; }

		private StreamWriter writer;
		private Process _process;

		public CapturingProcess(int pid, string path_to_text)
		{
			SetProcessID(pid);
			Path = path_to_text;
		}

		public void SetProcessID(int pid)
		{
			try
			{
				_process = Process.GetProcessById(pid);
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
				return;
			}
			_process.WaitForExit();
			if (File.Exists(Path))
				File.Delete(Path);
			writer = File.AppendText(Path);
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

		public void CaptureAfterWaiting()
		{
			SetForegroundWindow(_process.MainWindowHandle);
			SendKeys.Send("^A");
		}

		[DllImport("user32.dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);

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
