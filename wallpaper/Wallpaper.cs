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
        static bool isEnable = false;
        static List<string> exclude = new List<string>();

        public static void Run()
        {
            if (Convert.ToBoolean(RegistryGet.GetSetting("wallpaperExclude")))
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    try
                    {
                        string item = RegistryGet.GetExcludeList(i.ToString());
                        exclude.Add(item);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
            timer.Interval = 1000;
            timer.Tick += TimerTick;
            timer.Enabled = true;
        }

        private static void TimerTick(object sender, EventArgs e)
        {
            Process[] explorer = Process.GetProcessesByName("explorer");
            Process[] mpv = Process.GetProcessesByName("mpv");
            Process[] process = Process.GetProcesses();
            List<string> list = new List<string>();
            foreach (var item in process)
            {
                list.Add(item.ProcessName);
            }
            int excludeNum = list.Intersect(exclude).Count();
            if (explorer.Length > 0 && mpv.Length < 1 && excludeNum < 1)
            {
                timer.Enabled = false;
                System.Threading.Thread.Sleep(1000);
                IntPtr hwndShell = WindowsApi.GetShellWindow();
                WindowsApi.SendMessageTimeout(hwndShell, 0x52c, IntPtr.Zero, IntPtr.Zero, 0, 1000, IntPtr.Zero);
                IntPtr hwndWorkerW = WindowsApi.GetWindow(hwndShell, 3);
                string file = "\"" + RegistryGet.GetSetting("videoLocation") + "\"";
                string args = " --hwdec=auto --ao=null --loop-file=yes";
                Process newMpv = new Process();
                newMpv.StartInfo.FileName = "mpv.exe";
                newMpv.StartInfo.Arguments = file + args + " --wid=" + hwndWorkerW;
                newMpv.Start();
                isEnable = true;
                timer.Enabled = true;
            }
            else if (excludeNum > 0)
            {
                timer.Enabled = false;
                if (isEnable)
                {
                    Stop();
                    isEnable = false;
                }
                timer.Enabled = true;
            }
        }

        public static void Stop()
        {
            IntPtr hwndShell = WindowsApi.GetShellWindow();
            IntPtr hwndWorkerW = WindowsApi.GetWindow(hwndShell, 3);
            IntPtr hwndMpv = WindowsApi.GetWindow(hwndWorkerW, 5);
            WindowsApi.SendMessage(hwndMpv, 0x0010, 0, 0);
        }
    }
}
