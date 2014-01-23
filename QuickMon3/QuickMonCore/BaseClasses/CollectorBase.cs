using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public abstract class CollectorBase : AgentBase, ICollector
    {
        #region ICollector Members
        public abstract MonitorState GetState();
        public abstract ICollectorDetailView GetCollectorDetailView();
        #endregion

        //public new ICollectorConfig AgentConfig { get; set; }
        //public new virtual void SetConfigurationFromXmlString(string configurationString)
        //{
        //    AgentConfig.ReadConfiguration(configurationString);
        //}
    }
}
