using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickMon.Forms;

namespace QuickMon
{
    public class AgentSelectionSettings
    {
        public CollectorEntry SelectedCollectorEntry { get; set; }
        public NotifierEntry SelectedNotifierEntry { get; set; }
        public bool UsedPreset { get; set; }
        public bool RawEditAllowed { get; set; }
    }
    public static class AgentHelper
    {
        public static AgentSelectionSettings SelectNewCollector() //MonitorPack monitorPack)
        {
            AgentSelectionSettings agentSelectionSettings = new AgentSelectionSettings();
            CollectorEntry newCollectorEntry = null;
            SelectNewAgentType selectNewAgentType = new SelectNewAgentType();
            selectNewAgentType.InitialRegistrationName = "";
            if (selectNewAgentType.ShowCollectorSelection() == System.Windows.Forms.DialogResult.OK)
            {
                newCollectorEntry = new CollectorEntry();
                RegisteredAgent ar = null;
                if (selectNewAgentType.SelectedPreset != null)
                {
                    ar = (from a in RegisteredAgentCache.Agents
                          where a.IsCollector && a.ClassName.EndsWith(selectNewAgentType.SelectedPreset.AgentClassName)
                          orderby a.Name
                          select a).FirstOrDefault();
                }
                else if (selectNewAgentType.SelectedAgent != null)
                {
                    ar = selectNewAgentType.SelectedAgent;
                }
                else
                    return null;

                if (ar == null) //in case agent is not loaded or available
                    return null;
                else if (ar.ClassName != "QuickMon.Collectors.Folder")
                {
                    ICollector c = CollectorEntry.CreateCollectorEntry(ar);
                    newCollectorEntry.Collector = c;
                    if (selectNewAgentType.SelectedPreset == null)
                        newCollectorEntry.InitialConfiguration = c.GetDefaultOrEmptyConfigString();
                    else
                    {
                        newCollectorEntry.Name = selectNewAgentType.SelectedPreset.AgentDefaultName;
                        newCollectorEntry.Collector.AgentConfig.ReadConfiguration(AgentPresetConfig.FormatVariables(selectNewAgentType.SelectedPreset.Config));
                    }
                }
                else
                {
                    newCollectorEntry.IsFolder = true;
                }
                newCollectorEntry.CollectorRegistrationDisplayName = ar.DisplayName;
                newCollectorEntry.CollectorRegistrationName = ar.Name;
                agentSelectionSettings.SelectedCollectorEntry = newCollectorEntry;
                agentSelectionSettings.UsedPreset = selectNewAgentType.SelectedPreset != null;
                agentSelectionSettings.RawEditAllowed = selectNewAgentType.ImportConfigAfterSelect;
            }
            return agentSelectionSettings;
        }
    }
}
