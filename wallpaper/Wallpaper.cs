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
            Process[] allProcess = Process.GetProcesses();
            int explorer = 0;
            int mpv = 0;
            int num = 0;
            List<string> list = new List<string>();
            foreach (var item in allProcess)
            {
                if (item.ProcessName == "explorer")
                {
                    explorer++;
                }
                else if (item.ProcessName == "mpv")
                {
                    mpv++;
                }
                else
                {
                    list.Add(item.ProcessName);
                }
            }
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
            if (explorer > 0 && mpv < 1 && num < 1)
            {
                timer.Enabled = false;
                string file = RegistryEdit.GetSetting("videoLocation");
                string args = " --no-input-default-bindings --no-config --no-osc --fs --loop-file=yes";
                if (RegistryEdit.GetSetting("mpvSwdec") == "False")
                {
                    args += " --hwdec=auto";
                }
                if (RegistryEdit.GetSetting("mpvAudio") == "False")
                {
                    args += " --ao=null";
                }
                Process mpvProcess = new Process();
                mpvProcess.StartInfo.FileName = "mpv.exe";
                mpvProcess.StartInfo.Arguments = file + args;
                mpvProcess.Start();
                int wait = Convert.ToInt32(RegistryEdit.GetSetting("waitLabel"));
                System.Threading.Thread.Sleep(wait);
                IntPtr hwndShell = WindowsApi.GetShellWindow();
                WindowsApi.SendMessageTimeout(hwndShell, 0x52c, IntPtr.Zero, IntPtr.Zero, 0, 1000, IntPtr.Zero);
                IntPtr hwndWorkerW = WindowsApi.GetWindow(hwndShell, 3);
                WindowsApi.SetParent(mpvProcess.MainWindowHandle, hwndWorkerW);
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
