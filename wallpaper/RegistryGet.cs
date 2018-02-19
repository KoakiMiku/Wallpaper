using Microsoft.Win32;

namespace wallpaper
{
    class RegistryGet
    {
        static readonly string settingPath = @"Software\Wallpaper";
        static readonly string excludeListPath = @"Software\Wallpaper\ExcludeList";

        public static string GetSetting(string name)
        {
            RegistryKey setting = Registry.CurrentUser.OpenSubKey(settingPath);
            return setting.GetValue(name).ToString();
        }

        public static string GetExcludeList(string name)
        {
            RegistryKey excludeList = Registry.CurrentUser.OpenSubKey(excludeListPath);
            return excludeList.GetValue(name).ToString();
        }
    }
}
