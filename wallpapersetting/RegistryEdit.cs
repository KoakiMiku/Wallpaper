using Microsoft.Win32;
using System;

namespace wallpapersetting
{
    class RegistryEdit
    {
        static readonly string settingPath = @"Software\Wallpaper";
        static readonly string excludeListPath = @"Software\Wallpaper\ExcludeList";
        static readonly string autorunPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
        static readonly string desktopPath = @"DesktopBackground\Shell\Wallpaper";
        static readonly string shellPath = @"DesktopBackground\Shell\Wallpaper\Shell";
        static readonly string openPath = @"DesktopBackground\Shell\Wallpaper\Shell\Open";
        static readonly string openCmdPath = @"DesktopBackground\Shell\Wallpaper\Shell\Open\command";
        static readonly string setupPath = @"DesktopBackground\Shell\Wallpaper\Shell\Setting";
        static readonly string setupCmdPath = @"DesktopBackground\Shell\Wallpaper\Shell\Setting\command";

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
            autorun.SetValue("Wallpaper", Environment.CurrentDirectory + @"\wallpaper.exe");
            autorun.Close();
        }

        public static void RemoveAutorun()
        {
            RegistryKey autoRun = Registry.CurrentUser.OpenSubKey(autorunPath, true);
            autoRun.DeleteValue("Wallpaper", false);
            autoRun.Close();
        }

        public static void SetDesktopMenu()
        {
            RegistryKey desktop = Registry.ClassesRoot.CreateSubKey(desktopPath);
            desktop.SetValue("MUIVerb", "Wallpaper(&Z)");
            desktop.SetValue("Position", "Bottom");
            desktop.SetValue("SubCommands", "");
            desktop.Close();
            RegistryKey shell = Registry.ClassesRoot.CreateSubKey(shellPath);
            shell.Close();
            RegistryKey open = Registry.ClassesRoot.CreateSubKey(openPath);
            open.SetValue("", Language.GetString("Open") + "(&O)");
            open.Close();
            RegistryKey openCmd = Registry.ClassesRoot.CreateSubKey(openCmdPath);
            openCmd.SetValue("", Environment.CurrentDirectory + @"\wallpaper.exe");
            openCmd.Close();
            RegistryKey setup = Registry.ClassesRoot.CreateSubKey(setupPath);
            setup.SetValue("", Language.GetString("Setting") + "(&Z)");
            setup.Close();
            RegistryKey setupCmd = Registry.ClassesRoot.CreateSubKey(setupCmdPath);
            setupCmd.SetValue("", Environment.CurrentDirectory + @"\wallpapersetting.exe");
            setupCmd.Close();
        }

        public static void RemoveDesktopMenu()
        {
            RegistryKey desktop = Registry.ClassesRoot;
            desktop.DeleteSubKeyTree(desktopPath, false);
            desktop.Close();
        }
    }
}
