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
                        
                    case "success":
                        
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
                    case "configurationchanged":
                        return CollectorState.ConfigurationChanged;
                    case "updateinprogress":
                        return CollectorState.UpdateInProgress;
                }
                return CollectorState.NotAvailable;
            }
            else
                return CollectorState.NotAvailable;
        }
    }
}
