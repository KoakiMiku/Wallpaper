using System;
using System.Runtime.InteropServices;

namespace wallpapersetting
{
    class WindowsApi
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetShellWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageTimeout(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam, int fuFlags, int uTimeout, IntPtr lpdwResult);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, int nCmd);
        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
