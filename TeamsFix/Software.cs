using Microsoft.Win32;
using System;

namespace TeamsFix
{
    class Software
    {
        public static bool CheckInstallation(string software)
        {
            bool installed = false;

            var HKLM64 = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Environment.MachineName, RegistryView.Registry64);
            RegistryKey softwaresKey64 = HKLM64.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");


            foreach (string soft in softwaresKey64.GetSubKeyNames())
            {
                try
                {
                    var key = softwaresKey64.OpenSubKey(soft);
                    var displayName = key.GetValue("DisplayName");

                    if (displayName.ToString() != "")
                    {
                        if (displayName.ToString().ToUpper().Contains(software.ToUpper()))
                        {
                            installed = true;
                            return installed;
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return installed;
        }
    }
}
