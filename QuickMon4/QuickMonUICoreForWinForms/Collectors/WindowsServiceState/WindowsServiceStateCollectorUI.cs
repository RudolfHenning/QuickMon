using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class WindowsServiceStateCollectorUI : WinFormsUICollectorBase
    {
        public override string AgentType { get { return "WindowsServiceStateCollector"; } }
        public override IAgentConfigEntryEditWindow DetailEditor { get { return new ServiceStateCollectorEditEntry(); } }
        //public string AgentType { get { return "WindowsServiceStateCollector"; } }
        //public string AgentName { get; set; }
        //public bool AgentEnabled { get; set; }
        //public string SelectedAgentConfig { get; set; }

        //public bool EditAgent()
        //{
        //    ICollector agent = CollectorHost.CreateCollectorFromClassName(AgentType);
        //    if (agent != null)
        //    {
        //        agent.Name = AgentName;
        //        agent.Enabled = AgentEnabled;
        //        EditCollectorAgentEntries editCollectorAgentEntries = new EditCollectorAgentEntries();
        //        editCollectorAgentEntries.ShowTreeView = true;
        //        agent.InitialConfiguration = SelectedAgentConfig;
        //        agent.AgentConfig.FromXml(SelectedAgentConfig);

        //        editCollectorAgentEntries.SelectedEntry = agent;
        //        editCollectorAgentEntries.DetailEditor = new ServiceStateCollectorEditEntry();
        //        if (editCollectorAgentEntries.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            agent = editCollectorAgentEntries.SelectedEntry;
        //            AgentName = agent.Name;
        //            AgentEnabled = agent.Enabled;
        //            SelectedAgentConfig = agent.AgentConfig.ToXml();
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public bool HasDetailView
        //{
        //    get { return true; }
        //}

        //public void ShowCurrentDetails()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
