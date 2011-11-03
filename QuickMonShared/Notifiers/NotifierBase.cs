using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public abstract class NotifierBase : INotifier
    {
        #region INotifier Members
        public abstract void RecordMessage(AlertLevel alertLevel, string collectorType, string category, MonitorStates oldState, MonitorStates newState, CollectorMessage collectorMessage);
        public abstract void OpenViewer(string notifierName);
        #endregion

        #region IAgent Members
        public string Name { get; set; }
        public int LastError { get; set; }
        public string LastErrorMsg { get; set; }
        public abstract bool HasViewer { get ; }
        public abstract string ConfigureAgent(string config);
        public abstract string GetDefaultOrEmptyConfigString();
        public abstract void ReadConfiguration(XmlDocument configDoc);
        #endregion
    }
}
