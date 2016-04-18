using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Linux
{
    public static class Parsers
    {
        public static long ParseLong(string strVal, long defaultValue = 0)
        {
            long result = 0;
            if (strVal.Trim().Length == 0 || !long.TryParse(strVal, out result))
            {
                result = defaultValue;
            }
            return result;
        }
        public static double ParseDouble(string strVal, double defaultValue = 0.0)
        {
            double result = defaultValue;
            if (strVal.Trim().Length > 0)
            {
                try
                {
                    result = double.Parse(strVal, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                }
            }
            return result;
        }
    }
}
