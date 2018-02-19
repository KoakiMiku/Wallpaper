using System;
using System.IO;
using System.Windows.Forms;

namespace wallpaper
{
    static class Program
    {
        [STAThread]

        static void Main(string[] args)
        {
            if (Control.isSingle("wallpaper"))
            {
                Application.EnableVisualStyles();
                Environment.CurrentDirectory = Application.StartupPath;
                Language.Initialize();
                if (!File.Exists("mpv.exe"))
                {
                    Message.MpvMessage();
                }
                else
                {
                    try
                    {
                        if (File.Exists(RegistryGet.GetSetting("videoLocation")))
                        {
                            Wallpaper.Run();
                            Application.Run();
                        }
                        else
                        {
                            Message.FileMessage();
                            Control.Setting();
                        }
                    }
                    catch (Exception)
                    {
                        Control.Setting();
                    }
                }
            }
        }
    }
}
