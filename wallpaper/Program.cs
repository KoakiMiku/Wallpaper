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
            Environment.CurrentDirectory = Application.StartupPath;
            Application.EnableVisualStyles();
            Language.Initialize();
            if (File.Exists("mpv.exe"))
            {
                try
                {
                    if (args[0] == "-setting")
                    {
                        Application.Run(new Setting());
                    }
                }
                catch (Exception)
                {
                    if (!RegistryEdit.CheckSetting())
                    {
                        Setup();
                        Environment.Exit(0);
                    }
                    if (File.Exists(RegistryEdit.GetSetting("videoLocation")))
                    {
                        Process[] process = Process.GetProcessesByName("wallpaper");
                        if (process.Length < 2)
                        {
                            Wallpaper.Run();
                            Application.Run();
                        }
                        else
                        {
                            Setup();
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        string fileMessage = Language.GetString("fileMessage");
                        string error = Language.GetString("error");
                        MessageBox.Show(fileMessage, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Setup();
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                string mpvMessage = Language.GetString("mpvMessage");
                string error = Language.GetString("error");
                MessageBox.Show(mpvMessage, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private static void Setup()
        {
            Process runas = new Process();
            runas.StartInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
            runas.StartInfo.Verb = "runas";
            runas.StartInfo.Arguments = "-setting";
            runas.Start();
        }
    }
}
