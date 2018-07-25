using System;
using System.Diagnostics;

namespace wallpapersetting
{
    class Wallpaper
    {
        public static void Stop()
        {
            Process[] process = Process.GetProcesses();
            foreach (var item in process)
            {
                if (item.ProcessName == "wallpaper")
                {
                    item.Kill();
                }
            }
            IntPtr hwndShell = WindowsApi.GetShellWindow();
            IntPtr hwndWorkerW = WindowsApi.GetWindow(hwndShell, 3);
            IntPtr hwndMpv = WindowsApi.GetWindow(hwndWorkerW, 5);
            if (hwndMpv != IntPtr.Zero)
            {
                WindowsApi.SendMessage(hwndMpv, 0x0010, 0, 0);
            }
        }

        public static void Restart()
        {
            Stop();
            Process wallpaper = new Process();
            wallpaper.StartInfo.FileName = "wallpaper.exe";
            wallpaper.Start();
        }
    }
}
