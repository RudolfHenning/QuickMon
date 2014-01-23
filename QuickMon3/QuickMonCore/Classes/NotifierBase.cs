using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers
{
    public abstract class NotifierBase : INotifier
    {
        #region INotifier Members
        public abstract void RecordMessage(AlertLevel alertLevel, CollectorEntry collectorEntry);
        public abstract void RecordMessage(AlertLevel alertLevel, string generalMessage);
        public abstract bool HasViewer { get; }
        public abstract INotivierViewer GetNotivierViewer();
        #endregion

        #region IAgent Members
        public string Name { get; set; }
        public int LastError { get; set; }
        public string LastErrorMsg { get; set; }
        public string ConfigurationString { get; set; }

        public abstract void EditConfiguration();
        public abstract string GetDefaultOrEmptyConfigString();
        public abstract void SetConfiguration();
        public virtual void Close()
        {

        }
        #endregion
    }
}
