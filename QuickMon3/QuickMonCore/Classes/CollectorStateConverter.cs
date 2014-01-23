using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public static class CollectorStateConverter
    {
        public static CollectorState GetCollectorStateFromText(string collectorState)
        {
            if (collectorState.Length > 0)
            {
                switch (collectorState.ToLower())
                {
                    case "good":
                        return CollectorState.Good;
                    case "success":
                        return CollectorState.Good;
                    case "ok":
                        return CollectorState.Good;
                    case "warning":
                        return CollectorState.Warning;
                    case "error":
                        return CollectorState.Error;
                    case "disabled":
                        return CollectorState.Disabled;
                    case "configurationerror":
                        return CollectorState.ConfigurationError;
                    case "folder":
                        return CollectorState.Folder;

                }
                return CollectorState.NotAvailable;
            }
            else
                return CollectorState.NotAvailable;
        }
    }
}
