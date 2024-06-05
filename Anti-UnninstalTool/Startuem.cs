using System;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Anti_UnninstalTool
{
   /******************************************
   *                                        *
   *  Created by NotAFrizik                 *
   *  Visit: https://github.com/NotAFrizik  *
   *                                        *
   ******************************************/

    internal class Startuem
    {
        static void Main(string[] args)
        {
            string driverPath = @"C:\Windows\System32\drivers\CisUtMonitor.sys";
            string serviceName = "CisUtMonitor";

            if (File.Exists(driverPath))
            {
                try
                {
                    using (RegistryKey key = Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\{serviceName}"))
                    {
                        string command = $"sc delete {serviceName}";
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
                        {
                            WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                            FileName = "cmd.exe",
                            Arguments = $"/c {command}",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };
                        process.StartInfo = startInfo;
                        process.Start();
                        process.WaitForExit();
                    }
 
                    File.Delete(driverPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
            }
            else
            {
                MessageBox.Show($"Драйвер {driverPath} не найден.");
            }
        }
    }
}
