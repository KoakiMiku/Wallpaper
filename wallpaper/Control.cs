using System;
using System.Diagnostics;

namespace wallpaper
{
    class Control
    {
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

        public static int ProcessNum(string name)
        {
            Process[] process = Process.GetProcessesByName(name);
            return process.Length;
        }

        public static void Setting()
        {
            Process setting = new Process();
            setting.StartInfo.FileName = "wallpapersetting.exe";
            setting.Start();
        }

        public static void Start(IntPtr handle)
        {
            string file = "\"" + RegistryGet.GetSetting("videoLocation") + "\"";
            string args = " --hwdec=auto --ao=null --loop-file=yes";
            Process newMpv = new Process();
            newMpv.StartInfo.FileName = "mpv.exe";
            newMpv.StartInfo.Arguments = file + args + " --wid=" + handle;
            newMpv.Start();
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
