using System;

namespace TeamsFix
{
    class WorkDirectory
    {
        public static string publicDocuments = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
        public static string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string roamingAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    }
}