﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.UI
{


    public abstract class WinFormsUIBase : IWinFormsUI
    {

        public abstract string AgentType { get; }
        public string AgentName { get; set; }
        public bool AgentEnabled { get; set; }
        public string SelectedAgentConfig { get; set; }
        public abstract IAgentDetailWindow DetailViewWindow { get; }
        public abstract bool EditAgent();
        public abstract bool HasDetailView { get; }
        public virtual void ShowAgentDetails(IAgent agent, bool remoteAgentHostEnabled, string remoteAgentHostAddress, int remoteAgentHostPort)
        {
            if (HasDetailView && DetailViewWindow != null && agent != null)
            {
                DetailViewWindow.SelectedAgent = agent;
                DetailViewWindow.RemoteAgentHostEnabled = remoteAgentHostEnabled;
                DetailViewWindow.RemoteAgentHostAddress = remoteAgentHostAddress;
                DetailViewWindow.RemoteAgentHostPort = remoteAgentHostPort;
                DetailViewWindow.ShowDetailWindow();
            }
        }
    }
    public abstract class WinFormsUICollectorBase : WinFormsUIBase
    {
        public abstract ICollectorConfigEntryEditWindow DetailEditor { get; }

        public override bool EditAgent()
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

        public override bool HasDetailView
        {
            get { return true; }
        }
    }

    public abstract class WinFormsUINotifierBase : WinFormsUIBase
    {
        public abstract IAgentConfigEntryEditWindow DetailEditor { get; }

        public override bool EditAgent()
        {
            INotifier agent = NotifierHost.CreateNotifierFromClassName(AgentType);
            if (agent != null)
            {
                agent.Name = AgentName;
                agent.Enabled = AgentEnabled;
                EditNotifierAgentEntry editNotifierAgentEntry = new EditNotifierAgentEntry();
                agent.InitialConfiguration = SelectedAgentConfig;
                agent.AgentConfig.FromXml(SelectedAgentConfig);
                editNotifierAgentEntry.SelectedEntry = agent;
                editNotifierAgentEntry.DetailEditor = DetailEditor;
                if (editNotifierAgentEntry.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    agent = editNotifierAgentEntry.SelectedEntry;
                    AgentName = agent.Name;
                    AgentEnabled = agent.Enabled;
                    SelectedAgentConfig = agent.AgentConfig.ToXml();
                    return true;
                }
            }
            return false;
        }

        public override bool HasDetailView
        {
            get { return false; }
        }
    }
}
