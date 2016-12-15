using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum WindowSizeStyle
    {
        Normal = 0,
        Hidden = 1,
        Minimized = 2,
        Maximized = 3
    }

    public static class WindowSizeStyleConverter
    {
        public static WindowSizeStyle FromString(string s)
        {
            if (s.ToLower() == "normal")
                return WindowSizeStyle.Normal;
            else if (s.ToLower() == "hidden")
                return WindowSizeStyle.Hidden;
            else if (s.ToLower() == "minimized")
                return WindowSizeStyle.Minimized;
            else
                return WindowSizeStyle.Maximized;
        }
    }
}
