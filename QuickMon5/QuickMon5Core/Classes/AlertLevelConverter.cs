using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public static class AlertLevelConverter
    {
        public static AlertLevel GetAlertLevelFromText(string alertLevel)
        {
            if (alertLevel.Length > 0)
            {
                switch (alertLevel.Substring(0, 1).ToUpper())
                {
                    case "D":
                        return AlertLevel.Debug;
                    case "0":
                        return AlertLevel.Debug;
                    case "W":
                        return AlertLevel.Warning;
                    case "2":
                        return AlertLevel.Warning;
                    case "E":
                        return AlertLevel.Error;
                    case "3":
                        return AlertLevel.Error;                    
                }
                return AlertLevel.Info;
            }
            else
                return AlertLevel.Debug;
        }
    }
}
