namespace QuickMon
{
    public enum AlertLevel
    {
        Debug = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        Crisis = 4
    }

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
                    case "C":
                        return AlertLevel.Crisis;
                    case "5":
                        return AlertLevel.Crisis;
                }
                return AlertLevel.Info;
            }
            else
                return AlertLevel.Debug;
        }
    }
}