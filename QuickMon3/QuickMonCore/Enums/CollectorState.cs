﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public enum CollectorState
    {
        NotAvailable,
        Good,
        Warning,
        Error,
        Disabled,
        ConfigurationError,
        Folder  //Only for use by placebo Folder containers that house other collectors
    }
}
