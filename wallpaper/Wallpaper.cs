using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace wallpaper
{
    class Wallpaper
    {
        static Timer timer = new Timer();
        static string video = string.Empty;
        static List<string> list = new List<string>();

        public static void Run()
        {
            video = RegistryGet.GetSetting("videoLocation");
            if (Convert.ToBoolean(RegistryGet.GetSetting("wallpaperExclude")) &&
                !string.IsNullOrWhiteSpace(RegistryGet.GetSetting("excludeList")))
            {
                list = RegistryGet.GetSetting("excludeList").Split('|').ToList();
            }
            timer.Interval = 1000;
            timer.Tick += TimerTick;
            timer.Enabled = true;
        }

        private static void TimerTick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            bool power = SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online;
            bool screen = Screen.AllScreens.Count() == 1;
            int explorer = Process.GetProcessesByName("explorer").Length;
            int mpv = Process.GetProcessesByName("mpv").Length;
            int exclude = Process.GetProcesses().Select(item => item.ProcessName).Intersect(list).Count();
            if (power && screen && explorer != 0 && mpv == 0 && exclude == 0)
            {
                System.Threading.Thread.Sleep(1000);
                IntPtr hwndShell = WindowsApi.GetShellWindow();
                WindowsApi.SendMessageTimeout(hwndShell, 0x52c, IntPtr.Zero, IntPtr.Zero, 0, 1000, IntPtr.Zero);
                System.Threading.Thread.Sleep(1000);
                IntPtr hwndWorkerW = WindowsApi.GetWindow(hwndShell, 3);
                Process newMpv = new Process();
                newMpv.StartInfo.FileName = "mpv.exe";
                newMpv.StartInfo.Arguments = $"\"{video}\" --wid={hwndWorkerW} --loop-file=yes --hwdec=auto --ao=null";
                newMpv.Start();
            }
            else if ((!power || !screen || exclude > 0) && mpv != 0)
            {
                IntPtr hwndShell = WindowsApi.GetShellWindow();
                IntPtr hwndWorkerW = WindowsApi.GetWindow(hwndShell, 3);
                IntPtr hwndMpv = WindowsApi.GetWindow(hwndWorkerW, 5);
                WindowsApi.SendMessage(hwndMpv, 0x0010, 0, 0);
            }
            timer.Enabled = true;
        }
    }
}
