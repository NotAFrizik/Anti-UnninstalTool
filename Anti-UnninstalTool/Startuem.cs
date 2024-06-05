 using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string driverPath = @"C:\Windows\System32\drivers\CisUtMonitor.sys";
        string serviceName = "CisUtMonitor";

        try
        {
           string command = $"sc delete {serviceName}";
           ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
             };
             Process process = Process.Start(startInfo);
             process.WaitForExit();
           
            File.Delete(driverPath);
         }
      }
      catch {}
