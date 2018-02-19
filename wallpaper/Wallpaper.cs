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
            timer.Tick += TimerTick;
            timer.Enabled = true;
        }

        private static void TimerTick(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcesses();
            List<string> list = new List<string>();
            foreach (var item in process)
            {
                list.Add(item.ProcessName);
            }
            int excludeNum = list.Intersect(exclude).Count();
            if (Control.ProcessNum("explorer") > 0 && Control.ProcessNum("mpv") < 1 && excludeNum < 1)
            {
                timer.Enabled = false;
                System.Threading.Thread.Sleep(1000);
                IntPtr hwndShell = WindowsApi.GetShellWindow();
                WindowsApi.SendMessageTimeout(hwndShell, 0x52c, IntPtr.Zero, IntPtr.Zero, 0, 1000, IntPtr.Zero);
                IntPtr hwndWorkerW = WindowsApi.GetWindow(hwndShell, 3);
                Control.Start(hwndWorkerW);
                isEnable = true;
                timer.Enabled = true;
            }
            else if (excludeNum > 0)
            {
                timer.Enabled = false;
                if (isEnable)
                {
                    Control.Stop();
                    isEnable = false;
                }
                timer.Enabled = true;
            }
        }
    }
}
