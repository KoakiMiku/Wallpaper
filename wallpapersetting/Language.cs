using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace wallpapersetting
{
    class Language
    {
        static Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public static void Initialize()
        {
            string language = string.Empty;
            if (CultureInfo.InstalledUICulture.Name == "zh-CN")
            {
                language = Properties.Resources.zh_CN;
            }
            else
            {
                language = Properties.Resources.en_US;
            }
            StringReader stringReader = new StringReader(language);
            while (true)
            {
                string line = stringReader.ReadLine();
                if (line == null)
                {
                    break;
                }
                else if (line == string.Empty || line.StartsWith("#"))
                {
                    continue;
                }
                else
                {
                    string[] temp = line.Split('=');
                    dictionary.Add(temp[0], temp[1]);
                }
            }
            stringReader.Close();
        }

        public static string GetString(string value)
        {
            try
            {
                return dictionary[value];
            }
            catch (Exception)
            {
                return value;
            }
        }

        public static void GetText(System.Windows.Forms.Control control)
        {
            try
            {
                control.Text = dictionary[control.Name];
            }
            catch (Exception) { }
        }
    }
}
