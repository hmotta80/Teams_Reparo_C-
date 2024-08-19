using System;
using System.IO;

namespace TeamsFix
{
    class Logger
    {
        private static readonly string FileName = "teams_fix.log";
        private static readonly string FilePath = $"{WorkDirectory.localAppData}";
        private static readonly string LogFile = $@"{FilePath}\{FileName}";

        public static void InsertInfo(string info)
        {
            string dateTime = DateTime.Now.ToString();
            string logString = $"{dateTime}: {info}\n";

            if (info == "")
            {
                File.AppendAllText(LogFile, $"{info}\n");
            }
            else
            {
                File.AppendAllText(LogFile, logString);
            }
        }
    }
}
