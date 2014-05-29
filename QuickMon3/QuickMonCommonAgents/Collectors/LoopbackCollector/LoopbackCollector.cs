using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Loopback Collector"), Category("Test")]
    public class LoopbackCollector : CollectorBase
    {
        public LoopbackCollector()
        {
            AgentConfig = new LoopbackCollectorConfig();
        }
        public override MonitorState GetState()
        {
            MonitorState returnedState = new MonitorState();
            returnedState.State = ((LoopbackCollectorConfigEntry)((ICollectorConfig)AgentConfig).Entries[0]).ReturnState;
            returnedState.RawDetails = "Returning a test state of " + returnedState.State.ToString();
            return returnedState;
        }
        public override ICollectorDetailView GetCollectorDetailView()
        {
            return new LoopbackCollectorShowDetails();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.LoopbackCollectorDefaultConfig;
        }
        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new LoopbackCollectorEditConfig();
        }
        public override List<AgentPresetConfig> GetPresets()
        {
            return new List<AgentPresetConfig>();
        }
    }
}
