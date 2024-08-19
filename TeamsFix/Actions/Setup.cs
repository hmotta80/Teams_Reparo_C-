using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace TeamsFix.Actions
{
    class Setup
    {

        public static void Repair()
        {
            try
            {
                Teams.KillProcesses();
                Teams.Repair();
                MainWindow.Window.Message("Processo de reparo do Microsoft Teams concluído.");
                Thread.Sleep(5000);
                MainWindow.Window.Message("");
            }
            catch (Exception ex)
            {
                MainWindow.Window.Message("Ocorreu um erro no reparo do Teams.");
                Logger.InsertInfo(ex.ToString());
                throw;
            }
        }

        public static void Reinstall()
        {
            try
            {
                Teams.KillProcesses();
                Teams.Uninstall();
                Teams.Install();
                MainWindow.Window.Message("Processo de reinstalação do Microsoft Teams concluído.");
                Thread.Sleep(5000);
                MainWindow.Window.Message("");
            }
            catch (Exception ex)
            {
                MainWindow.Window.Message("Ocorreu um erro na reinstalação do Teams.");
                Logger.InsertInfo(ex.ToString());
                throw;
            }

        }
    }
}
