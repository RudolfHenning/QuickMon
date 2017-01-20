using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface IAgentConfig
    {
        void FromXml(string configurationString);
        /// <summary>
        /// Get the 'current' config of agent. 
        /// When using Config Variables this will give you the applied config (and not the initial config)
        /// </summary>
        /// <returns></returns>
        string ToXml();
        string GetDefaultOrEmptyXml();
        string ConfigSummary { get; }        
    }
    public interface INotifierConfig : IAgentConfig
    {
        
    }
    public interface ICollectorConfig : IAgentConfig
    {
        bool SingleEntryOnly { get; }
        List<ICollectorConfigEntry> Entries { get; set; }       
    }
    public interface IAgentConfigEntry
    {
        string Description { get; }
        string TriggerSummary { get; }
    }
    public interface ICollectorConfigEntry
    {
        string Description { get; }
        string TriggerSummary { get; }
        List<ICollectorConfigSubEntry> SubItems { get; set; }
        object CurrentAgentValue { get; set; }
        MonitorState GetCurrentState();
    }
    public interface ICollectorConfigSubEntry
    {
        string Description { get; }
    }

}
