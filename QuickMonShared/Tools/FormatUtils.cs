using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public static class FormatUtils
    {
        public static string N(object anyValue, string defaultValue = "")
        {
            if (anyValue == null)
                return defaultValue;
            else if (anyValue == DBNull.Value)
                return defaultValue;
            else
                return anyValue.ToString();
        }
        public static bool IsInteger(this string s)
        {
            if (s == null || s.Length == 0)
                return false;
            else
            {
                int tmp = 0;
                if (int.TryParse(s, out tmp))
                    return true;
                else
                    return false;
            }
        }
        public static bool IsLong(this string s)
        {
            if (s == null || s.Length == 0)
                return false;
            else
            {
                long tmp = 0;
                if (long.TryParse(s, out tmp))
                    return true;
                else
                    return false;
            }
        }
        public static bool IsIntegerTypeNumber(this object o)
        {
            if (o == null)
                return false;
            else
            {
                return o.ToString().IsLong();
            }
        }
    }
}
