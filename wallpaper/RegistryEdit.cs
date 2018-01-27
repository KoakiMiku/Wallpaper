using Microsoft.Win32;
using System.Diagnostics;

namespace wallpaper
{
    class RegistryEdit
    {
        static readonly string settingPath = @"Software\Wallpaper";
        static readonly string excludeListPath = @"Software\Wallpaper\ExcludeList";
        static readonly string autorunPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
        static readonly string desktopPath = @"DesktopBackground\Shell\Wallpaper";
        static readonly string commandPath = @"DesktopBackground\Shell\Wallpaper\command";

        public static bool CheckSetting()
        {
            RegistryKey setting = Registry.CurrentUser.OpenSubKey(settingPath);
            if (setting == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static string GetSetting(string name)
        {
            RegistryKey setting = Registry.CurrentUser.OpenSubKey(settingPath);
            return setting.GetValue(name).ToString();
        }

        public static void SetSetting(string name, string value)
        {
            RegistryKey setting = Registry.CurrentUser.CreateSubKey(settingPath);
            setting.SetValue(name, value);
        }

        public static void RemoveSetting()
        {
            RegistryKey setting = Registry.CurrentUser;
            setting.DeleteSubKeyTree(settingPath, false);
            setting.Close();
        }

        public static string GetExcludeList(string name)
        {
            RegistryKey excludeList = Registry.CurrentUser.OpenSubKey(excludeListPath);
            return excludeList.GetValue(name).ToString();
        }

        public static void SetExcludeList(string name, string value)
        {
            RegistryKey excludeList = Registry.CurrentUser.CreateSubKey(excludeListPath);
            excludeList.SetValue(name, value);
        }

        public static void RemoveExcludeList()
        {
            RegistryKey excludeList = Registry.CurrentUser;
            excludeList.DeleteSubKeyTree(excludeListPath, false);
            excludeList.Close();
        }

        public static void SetAutorun()
        {
            RegistryKey autorun = Registry.CurrentUser.OpenSubKey(autorunPath, true);
            autorun.SetValue("Wallpaper", Process.GetCurrentProcess().MainModule.FileName);
            autorun.Close();
        }

        public static void SetDesktopMenu()
        {
            RegistryKey desktop = Registry.ClassesRoot.CreateSubKey(desktopPath);
            desktop.SetValue("", "Wallpaper(&Z)");
            desktop.SetValue("Icon", @"%systemroot%\system32\imageres.dll,105");
            desktop.SetValue("Position", "Bottom");
            desktop.Close();
            RegistryKey command = Registry.ClassesRoot.CreateSubKey(commandPath);
            command.SetValue("", Process.GetCurrentProcess().MainModule.FileName);
            command.Close();
        }

        public static void RemoveAutorun()
        {
            RegistryKey autoRun = Registry.CurrentUser.OpenSubKey(autorunPath, true);
            autoRun.DeleteValue("Wallpaper", false);
            autoRun.Close();
        }

        public static void RemoveDesktopMenu()
        {
            RegistryKey desktop = Registry.ClassesRoot;
            desktop.DeleteSubKeyTree(desktopPath, false);
            desktop.Close();
        }
    }
}
