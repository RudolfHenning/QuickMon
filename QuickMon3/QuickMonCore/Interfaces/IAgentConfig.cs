using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface IAgentConfig
    {
        void ReadConfiguration(string configurationString);
        string ToConfig();        
    }
    public interface INotifierConfig : IAgentConfig
    {
        string ConfigSummary { get; }  
    }
    public interface ICollectorConfig : IAgentConfig
    {
        List<ICollectorConfigEntry> Entries { get; set; }
        /// <summary>
        /// If set to Single the Collector can/must support only one entry. No Adding/deleting allowed.
        /// </summary>
        ConfigEntryType ConfigEntryType { get; }
        /// <summary>
        /// Can existing entries be edited? If not then Adding/deleting are the only options
        /// </summary>
        bool CanEdit { get; }

    }
    public interface ICollectorConfigEntry
    {
        string Description { get; }
        string TriggerSummary { get; }
        List<ICollectorConfigSubEntry> SubItems { get; set; }
    }
    public interface ICollectorConfigSubEntry
    {
        string Description { get; }
    }
    public enum ConfigEntryType
    {
        Single,
        Multiple,
        Tree
    }
}
