using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickMon.Forms;

namespace QuickMon
{
    public static class AgentHelper
    {
        public static List<string> KnownRemoteHosts = new List<string>();
        public static int LastCreateAgentOption;

        #region Collectors
        public static CollectorEntry CreateNewCollector(CollectorEntry parentCollectorEntry = null)
        {
            CollectorEntry newCollectorEntry = null;
            SelectNewAgentType selectNewAgentType = new SelectNewAgentType();
            selectNewAgentType.InitialRegistrationName = "";
            if (selectNewAgentType.ShowCollectorSelection() == System.Windows.Forms.DialogResult.OK)
            {
                newCollectorEntry = new CollectorEntry();
                if (parentCollectorEntry != null)
                    newCollectorEntry.ParentCollectorId = parentCollectorEntry.UniqueId;
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
                        newCollectorEntry.Name = selectNewAgentType.SelectedPreset.Description;
                        newCollectorEntry.Collector.AgentConfig.ReadConfiguration(AgentPresetConfig.FormatVariables(selectNewAgentType.SelectedPreset.Config));
                    }
                }
                else
                {
                    newCollectorEntry.IsFolder = true;
                }
                newCollectorEntry.CollectorRegistrationDisplayName = ar.DisplayName;
                newCollectorEntry.CollectorRegistrationName = ar.Name;
            }
            return newCollectorEntry;
        }
        public static CollectorEntry CreateAndEditNewCollector(MonitorPack monitorPack, CollectorEntry parentCollectorEntry = null)
        {
            CollectorEntry newCollectorEntry = null;
            SelectNewAgentType selectNewAgentType = new SelectNewAgentType();
            selectNewAgentType.InitialRegistrationName = "";
            if (selectNewAgentType.ShowCollectorSelection() == System.Windows.Forms.DialogResult.OK)
            {
                newCollectorEntry = new CollectorEntry();
                if (parentCollectorEntry != null)
                    newCollectorEntry.ParentCollectorId = parentCollectorEntry.UniqueId;
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
                        newCollectorEntry.Name = selectNewAgentType.SelectedPreset.Description;
                        newCollectorEntry.Collector.AgentConfig.ReadConfiguration(AgentPresetConfig.FormatVariables(selectNewAgentType.SelectedPreset.Config));
                    }
                }
                else
                {
                    newCollectorEntry.IsFolder = true;
                }
                newCollectorEntry.CollectorRegistrationDisplayName = ar.DisplayName;
                newCollectorEntry.CollectorRegistrationName = ar.Name;

                QuickMon.Forms.EditCollectorConfig editCollectorEntry = new Forms.EditCollectorConfig();
                editCollectorEntry.SelectedEntry = newCollectorEntry;
                editCollectorEntry.KnownRemoteHosts = KnownRemoteHosts;

                editCollectorEntry.LaunchAddEntry = selectNewAgentType.SelectedPreset == null;
                editCollectorEntry.ShowRawEditOnStart = selectNewAgentType.ImportConfigAfterSelect;

                if (editCollectorEntry.ShowDialog(monitorPack) != System.Windows.Forms.DialogResult.OK)
                {
                    newCollectorEntry = null;
                }
            }
            return newCollectorEntry;
        }
        public static System.Windows.Forms.DialogResult EditCollectorEntry(CollectorEntry collectorEntry, MonitorPack monitorPack)
        {
            QuickMon.Forms.EditCollectorConfig editCollectorEntry = new Forms.EditCollectorConfig();
            editCollectorEntry.SelectedEntry = collectorEntry;
            editCollectorEntry.KnownRemoteHosts = KnownRemoteHosts;

            return editCollectorEntry.ShowDialog(monitorPack);
        } 
        #endregion

        #region Notifiers
        public static NotifierEntry CreateNewNotifier()
        {
            NotifierEntry newNotifierEntry = null;
            SelectNewAgentType selectNewAgentType = new SelectNewAgentType();
            selectNewAgentType.InitialRegistrationName = "";
            if (selectNewAgentType.ShowNotifierSelection() == System.Windows.Forms.DialogResult.OK)
            {
                newNotifierEntry = new NotifierEntry();
                RegisteredAgent ar = null;
                if (selectNewAgentType.SelectedPreset != null)
                {
                    ar = (from a in RegisteredAgentCache.Agents
                          where a.IsNotifier && a.ClassName.EndsWith(selectNewAgentType.SelectedPreset.AgentClassName)
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
                else
                {
                    INotifier n = NotifierEntry.CreateNotifierEntry(ar);
                    newNotifierEntry.Notifier = n;
                    if (selectNewAgentType.SelectedPreset == null)
                        newNotifierEntry.InitialConfiguration = n.GetDefaultOrEmptyConfigString();
                    else
                    {
                        newNotifierEntry.Name = selectNewAgentType.SelectedPreset.Description;
                        newNotifierEntry.Notifier.AgentConfig.ReadConfiguration(AgentPresetConfig.FormatVariables(selectNewAgentType.SelectedPreset.Config));
                    }
                }
                newNotifierEntry.NotifierRegistrationName = ar.Name;
            }
            return newNotifierEntry;
        }
        public static NotifierEntry CreateAndEditNewNotifier(MonitorPack monitorPack)
        {
            NotifierEntry newNotifierEntry = null;
            SelectNewAgentType selectNewAgentType = new SelectNewAgentType();
            selectNewAgentType.InitialRegistrationName = "";
            if (selectNewAgentType.ShowNotifierSelection() == System.Windows.Forms.DialogResult.OK)
            {
                newNotifierEntry = new NotifierEntry();
                RegisteredAgent ar = null;
                if (selectNewAgentType.SelectedPreset != null)
                {
                    ar = (from a in RegisteredAgentCache.Agents
                          where a.IsNotifier && a.ClassName.EndsWith(selectNewAgentType.SelectedPreset.AgentClassName)
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
                else
                {
                    INotifier n = NotifierEntry.CreateNotifierEntry(ar);
                    newNotifierEntry.Notifier = n;
                    if (selectNewAgentType.SelectedPreset == null)
                        newNotifierEntry.InitialConfiguration = n.GetDefaultOrEmptyConfigString();
                    else
                    {
                        newNotifierEntry.Name = selectNewAgentType.SelectedPreset.Description;
                        newNotifierEntry.InitialConfiguration = AgentPresetConfig.FormatVariables(selectNewAgentType.SelectedPreset.Config);
                        
                    }
                    newNotifierEntry.Notifier.AgentConfig.ReadConfiguration(newNotifierEntry.InitialConfiguration);
                }
                newNotifierEntry.NotifierRegistrationName = ar.Name;

                Management.EditNotifierEntry editNotifierEntry = new Management.EditNotifierEntry();
                editNotifierEntry.SelectedEntry = newNotifierEntry;
                editNotifierEntry.LaunchAddEntry = selectNewAgentType.SelectedPreset == null;
                editNotifierEntry.ShowRawEditOnStart = selectNewAgentType.ImportConfigAfterSelect;

                if (editNotifierEntry.ShowDialog(monitorPack) != System.Windows.Forms.DialogResult.OK)
                {
                    newNotifierEntry = null;
                }
            }
            return newNotifierEntry;
        }
        public static System.Windows.Forms.DialogResult EditNotifierEntry(NotifierEntry notifierEntry, MonitorPack monitorPack)
        {
            Management.EditNotifierEntry editNotifierEntry = new Management.EditNotifierEntry();
            editNotifierEntry.SelectedEntry = notifierEntry;
            return editNotifierEntry.ShowDialog(monitorPack);
        }
        #endregion
    }
}
