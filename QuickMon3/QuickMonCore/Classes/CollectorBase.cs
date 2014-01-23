using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public abstract class CollectorBase : ICollector
    {
        #region ICollector Members
        public abstract MonitorState GetState();
        public abstract ICollectorDetailView GetCollectorDetailView();
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
