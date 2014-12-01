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
        ConfigurationError,
        None
        //, Folder  //Only for use by placebo Folder containers that house other collectors
    }
}
