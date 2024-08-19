using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace TeamsFix.Actions
{
    class Teams
    {
        private static readonly string InstallCmd = $@"/C {WorkDirectory.publicDocuments}\Teams_windows_x64.exe -s";
        private static readonly string UninstallCmd = $@"/C {WorkDirectory.localAppData}\Microsoft\Teams\Update.exe --uninstall -s";

        public static void KillProcesses()
        {
            ProcessOperation.Kill("OUTLOOK");
            ProcessOperation.Kill("TEAMS");
        }

        public static void Open()
        {
            MainWindow.Window.Message("Abrindo o Microsoft Teams...");
            string openCmd = $@"/C 'START 'APP' '{WorkDirectory.localAppData}\Microsoft\Teams\current\Teams.exe''".Replace("'", "\""); ;
            Process runTeams = ProcessOperation.Create("cmd.exe", openCmd);
            runTeams.Start();
            runTeams.WaitForExit();
        }

        public static void Install()
        {
            Download.Run();

            try
            {
                MainWindow.Window.Message("Executando a instalação do Microsoft Teams...");
                Process installTeams = ProcessOperation.Create("cmd.exe", InstallCmd);
                installTeams.Start();
                installTeams.WaitForExit();
                MainWindow.Window.Message("Instalação do Teams concluída.");
                Open();
            }
            catch (Exception ex)
            {
                MainWindow.Window.Message("Ocorreu um erro na instalação do Teams.");
                Logger.InsertInfo(ex.ToString());
            }
        }

        public static void Uninstall()
        {
            MainWindow.Window.Message("Executando a desinstalação do Microsoft Teams...");

            try
            {
                Process uninstallTeams = ProcessOperation.Create("cmd.exe", UninstallCmd);
                uninstallTeams.Start();
                uninstallTeams.WaitForExit();
                MainWindow.Window.Message("Desinstalação do Teams concluída.");
            }
            catch (Exception ex)
            {
                MainWindow.Window.Message("Ocorreu um erro na desinstalação do Teams.");
                Logger.InsertInfo(ex.ToString());
            }
        }

        public static void Repair()
        {
            MainWindow.Window.Message($@"Executando o reparo do Microsoft Teams.");
            try
            {
                Directory.Delete($@"{WorkDirectory.roamingAppData}\Microsoft\Teams", true);
                MainWindow.Window.Message($@"Arquivos em {WorkDirectory.roamingAppData}\Microsoft\Teams removidos.");
                Open();
            }
            catch (DirectoryNotFoundException ex)
            {
                MainWindow.Window.Message($"Pasta de configuração do Microsoft Teams inexistente.");
                Logger.InsertInfo(ex.ToString());
            }
        }
    }
}
