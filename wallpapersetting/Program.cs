using System;
using System.Windows.Forms;

namespace wallpapersetting
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if(Control.isSingle("wallpapersetting"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Environment.CurrentDirectory = Application.StartupPath;
                Language.Initialize();
                Application.Run(new Setting());
            }
            else
            {
                return;
            }
        }
    }
}
