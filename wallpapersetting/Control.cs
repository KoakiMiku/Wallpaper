using System;
using System.Diagnostics;

namespace wallpapersetting
{
    class Control
    {
        private static bool isStart(string name)
        {
            Process[] process = Process.GetProcessesByName(name);
            if (process.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isSingle(string name)
        {
            Process[] process = Process.GetProcessesByName(name);
            if (process.Length > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void Kill(string name)
        {
            Process[] process = Process.GetProcesses();
            foreach (var item in process)
            {
                if (item.ProcessName == name)
                {
                    item.Kill();
                }
            }
        }

        public static void Stop()
        {
            Kill("wallpaper");
            IntPtr hwndShell = WindowsApi.GetShellWindow();
            IntPtr hwndWorkerW = WindowsApi.GetWindow(hwndShell, 3);
            IntPtr hwndMpv = WindowsApi.GetWindow(hwndWorkerW, 5);
            WindowsApi.SendMessage(hwndMpv, 0x0010, 0, 0);
        }

        public static void Restart()
        {
            if (isStart("wallpaper"))
            {
                Stop();
                Process process = new Process();
                process.StartInfo.FileName = "wallpaper.exe";
                process.Start();
            }
        }
    }
}
