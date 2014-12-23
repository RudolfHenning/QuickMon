using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public abstract class WinFormsUICollectorBase : IWinFormsUI
    {

        public abstract string AgentType { get; }
        public string AgentName { get; set; }
        public bool AgentEnabled { get; set; }
        public string SelectedAgentConfig { get; set; }
        public abstract IAgentConfigEntryEditWindow DetailEditor { get; }

        public bool EditAgent()
        {
            ICollector agent = CollectorHost.CreateCollectorFromClassName(AgentType);
            if (agent != null)
            {
                agent.Name = AgentName;
                agent.Enabled = AgentEnabled;
                EditCollectorAgentEntries editCollectorAgentEntries = new EditCollectorAgentEntries();
                agent.InitialConfiguration = SelectedAgentConfig;
                agent.AgentConfig.FromXml(SelectedAgentConfig);

                editCollectorAgentEntries.SelectedEntry = agent;
                //Type detailEditorType = DetailEditor.GetType();
                editCollectorAgentEntries.DetailEditor = DetailEditor;
                if (editCollectorAgentEntries.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    agent = editCollectorAgentEntries.SelectedEntry;
                    AgentName = agent.Name;
                    AgentEnabled = agent.Enabled;
                    SelectedAgentConfig = agent.AgentConfig.ToXml();
                    return true;
                }
            }
            return false;
        }

        public bool HasDetailView
        {
            get { throw new NotImplementedException(); }
        }

        public void ShowCurrentDetails()
        {
            throw new NotImplementedException();
        }
    }
}
