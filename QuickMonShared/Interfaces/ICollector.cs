using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface ICollector : IAgent
    {
        CollectorMessage LastDetailMsg { get; set; }
        MonitorStates GetState();
        void ShowStatusDetails(string collectorName);
    }
}
