﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public abstract class NotifierAgentBase : AgentBase, INotifier
    {
        #region INotifier Members
        public abstract void RecordMessage(AlertRaised alertRaised);
        public abstract AttendedOption AttendedRunOption { get; }
        #endregion
    }
}
