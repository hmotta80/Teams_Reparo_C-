using System;
using System.Diagnostics;

namespace TeamsFix
{
    class ProcessOperation
    {
        public static Process Create(string program, string args)
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $"{program}",
                    Arguments = $"{args}",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            return proc;
        }

        public static void Kill(string processName)
        {
            try
            {
                foreach (Process process in Process.GetProcessesByName(processName))
                {
                    process.Kill();
                }

                MainWindow.Window.Message($"Processo {processName} finalizado.");
            }
            catch (Exception)
            {
                MainWindow.Window.Message($"Ocorreu um erro para encerrar o processo {processName}.");
            }
        }
    }
}
