using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public abstract class CollectorBase : ICollector
    {
        public CollectorBase()
        {
            LastError = 0;
            LastErrorMsg = "";
        }

        #region ICollector Members
        public abstract MonitorStates GetState();
        public abstract void ShowStatusDetails(string collectorName);
        public abstract ICollectorDetailView GetCollectorDetailView();
        #endregion

        #region IAgent Members
        public string Name { get; set; }
        public int LastError { get; set; }
        public string LastErrorMsg { get; set; }
        public CollectorMessage LastDetailMsg { get; set; }
        public abstract string ConfigureAgent(string config);
        public abstract string GetDefaultOrEmptyConfigString();
        public abstract void ReadConfiguration(XmlDocument configDoc);
        public virtual void Close()
        {
            
        }
        #endregion   
    }
}
