using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum CollectorState
    {
        NotAvailable, //Default value
        Good,
        Warning,
        Error,
        Disabled,
        ConfigurationChanged,
        ConfigurationError,
        UpdateInProgress,
        NotInServiceWindow,
        None
    }
}
