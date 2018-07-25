using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace wallpaper
{
    static class Program
    {
        [STAThread]

        static void Main(string[] args)
        {
            Process[] process = Process.GetProcessesByName("wallpaper");
            if (process.Length > 1)
            {
                return;
            }
            Application.EnableVisualStyles();
            Environment.CurrentDirectory = Application.StartupPath;
            Language.Initialize();
            if (!File.Exists("mpv.exe"))
            {
                MessageBox.Show(Language.GetString("mpvMessage"), Language.GetString("error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show(Language.GetString("fileMessage"), Language.GetString("error"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    Process setting = new Process();
                    setting.StartInfo.FileName = "wallpapersetting.exe";
                    setting.Start();
                }
            }
        }
    }
}
