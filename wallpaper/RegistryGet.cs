using Microsoft.Win32;

namespace wallpaper
{
    class RegistryGet
    {
        static readonly string settingPath = @"Software\Wallpaper";

        public static string GetSetting(string name)
        {
            RegistryKey setting = Registry.CurrentUser.OpenSubKey(settingPath);
            return setting.GetValue(name).ToString();
        }
    }
}
