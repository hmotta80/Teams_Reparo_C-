using System.Net;

namespace TeamsFix.Actions
{
    class Download
    {
        private static readonly string TeamsExe = $@"{WorkDirectory.publicDocuments}\Teams_windows_x64.exe";
        private static readonly string Url = "https://go.microsoft.com/fwlink/p/?LinkID=869426&clcid=0x416&culture=pt-br&country=BR&lm=deeplink&lmsrc=groupChatMarketingPageWeb&cmpid=directDownloadWin64";

        public static void Run()
        {
            using (var client = new WebClient { Proxy = null })
            {
                MainWindow.Window.Message($"Baixando instalador...");
                client.DownloadFile(Url, TeamsExe);
                MainWindow.Window.Message($"Download concluído.");
            }
        }
    }
}