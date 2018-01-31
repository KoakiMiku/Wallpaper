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

        public static void Run()
        {
            timer.Tick += TimerTick;
            timer.Enabled = true;
        }

        private static void TimerTick(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcesses();
            Process[] explorer = Process.GetProcessesByName("explorer");
            Process[] mpv = Process.GetProcessesByName("mpv");
            List<string> list = new List<string>();
            foreach (var item in process)
            {
                list.Add(item.ProcessName);
            }
            int num = 0;
            if (Convert.ToBoolean(RegistryEdit.GetSetting("wallpaperExclude")))
            {
                List<string> exclude = new List<string>();
                for (int i = 0; i < int.MaxValue; i++)
                {
                    try
                    {
                        string item = RegistryEdit.GetExcludeList(i.ToString());
                        exclude.Add(item);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                num = list.Intersect(exclude).Count();
            }
            if (explorer.Length > 0 && mpv.Length < 1 && num < 1)
            {
                timer.Enabled = false;
                System.Threading.Thread.Sleep(1000);
                string file = "\"" + RegistryEdit.GetSetting("videoLocation") + "\" --hwdec=auto --loop-file=yes";
                if (!Convert.ToBoolean(RegistryEdit.GetSetting("mpvAudio")))
                {
                    file += " --ao=null";
                }
                IntPtr hwndShell = WindowsApi.GetShellWindow();
                WindowsApi.SendMessageTimeout(hwndShell, 0x52c, IntPtr.Zero, IntPtr.Zero, 0, 1000, IntPtr.Zero);
                IntPtr hwndWorkerW = WindowsApi.GetWindow(hwndShell, 3);
                Process newMpv = new Process();
                newMpv.StartInfo.FileName = "mpv.exe";
                newMpv.StartInfo.Arguments = file + " --wid=" + hwndWorkerW;
                newMpv.Start();
                isEnable = true;
                timer.Enabled = true;
            }
            else if (num > 0)
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
