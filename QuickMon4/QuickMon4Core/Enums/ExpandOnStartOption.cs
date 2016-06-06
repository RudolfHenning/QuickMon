using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum ExpandOnStartOption
    {
        Auto,
        OnNonSuccess,
        OnSuccess,
        Never,
        Always
    }

    public static class ExpandOnStartOptionConverter
    {
        public static ExpandOnStartOption FromString(string s)
        {
            if (s.ToLower() == "onnonsuccess" || s.ToLower() == "false" || s == "0")
                return ExpandOnStartOption.OnNonSuccess;
            else if (s.ToLower() == "onsuccess")
                return ExpandOnStartOption.OnSuccess;
            else if (s.ToLower() == "never")
                return ExpandOnStartOption.Never;
            else if (s.ToLower() == "always")
                return ExpandOnStartOption.Always;
            else
                return ExpandOnStartOption.Auto;
        }
    }
}
