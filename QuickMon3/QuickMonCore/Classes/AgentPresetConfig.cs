using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class AgentPresetConfig
    {
        public string AgentClassName { get; set; }
        public string Description { get; set; }
        public string AgentDefaultName { get; set; }        
        public string Config { get; set; }

        /// <summary>
        /// Agent can call this static method to get all presets stored in current directory (files with *.qps name)
        /// </summary>
        /// <param name="agentClass"></param>
        /// <returns></returns>
        public static List<AgentPresetConfig> GetPresetsForClass(string agentClass)
        {
            List<AgentPresetConfig> presets = new List<AgentPresetConfig>();

            return presets;
        }

        public static List<AgentPresetConfig> GetAllPresetsFromFile(string filePath)
        {
            List<AgentPresetConfig> presets = new List<AgentPresetConfig>();

            return presets;
        }

    }
}
