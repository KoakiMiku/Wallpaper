using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace wallpapersetting
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Process[] process = Process.GetProcessesByName("wallpapersetting");
            if (process.Length > 1)
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Environment.CurrentDirectory = Application.StartupPath;
            Language.Initialize();
            Application.Run(new Setting());
        }
    }
}
