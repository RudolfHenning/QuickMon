using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers
{
    public abstract class NotifierBase : AgentBase, INotifier
    {
        #region INotifier Members
        public abstract void RecordMessage(AlertRaised alertRaised);
        public abstract bool HasViewer { get; }
        public abstract INotivierViewer GetNotivierViewer();
        #endregion
    }
}
