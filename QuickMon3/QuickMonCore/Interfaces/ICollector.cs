using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface ICollector : IAgent
    {
        MonitorState GetState();
        ICollectorDetailView GetCollectorDetailView();
        bool ShowEditEntry(ref ICollectorConfigEntry entry);
    }
    
}
