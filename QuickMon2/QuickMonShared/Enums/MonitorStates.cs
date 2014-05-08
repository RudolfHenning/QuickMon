using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum MonitorStates
    {
        NotAvailable,
        Good,
        Warning,
        Error,
        Disabled,
        ConfigurationError,
        Folder  //Only for use by placebo Folder containers that house other collectors
    }
    public static class MonitorStatesConverter
    {
        public static MonitorStates GetMonitorStateFromText(string monitorState)
        {
            if (monitorState.Length > 0)
            {
                switch (monitorState.Substring(0, 1).ToUpper())
                {
                    case "N":
                        return MonitorStates.NotAvailable;
                    case "0":
                        return MonitorStates.NotAvailable;
                    case "W":
                        return MonitorStates.Warning;
                    case "2":
                        return MonitorStates.Warning;
                    case "E":
                        return MonitorStates.Error;
                    case "3":
                        return MonitorStates.Error;
                    case "D":
                        return MonitorStates.Disabled;
                    case "4":
                        return MonitorStates.Disabled;
                    case "C":
                        return MonitorStates.ConfigurationError;
                    case "5":
                        return MonitorStates.ConfigurationError;
                    case "F":
                        return MonitorStates.Folder;
                    case "6":
                        return MonitorStates.Folder;
                }
                return MonitorStates.Good;
            }
            else
                return MonitorStates.ConfigurationError;
        }
    }
}
