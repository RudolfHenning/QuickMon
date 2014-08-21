using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace QuickMon
{
    public partial class CollectorEntry
    {
        #region Create Collector Instance
        public void CreateAndConfigureEntry(string agentClassName, string overrideWithConfig = "", bool setAsInitialConfig = false, bool useConfigVars = true)
        {
            RegisteredAgent ra = null;
            if (agentClassName == "Folder")
                return;
            ra = RegisteredAgentCache.GetRegisteredAgentByClassName(agentClassName);
            if (ra == null) //in case agent is not loaded or available
                throw new Exception("Collector '" + Name + "' with type of '" + agentClassName + "' cannot be loaded! No Assembly of this Agent type found!");
            else
            {
                string appliedConfig = "";
                if (overrideWithConfig != null && overrideWithConfig.Trim().Length > 0)
                    appliedConfig = FormatUtils.N(overrideWithConfig);
                else
                    appliedConfig = FormatUtils.N(InitialConfiguration);
                //Create Collector instance
                Collector = CreateAndConfigureEntry(ra, appliedConfig, (useConfigVars ? ConfigVariables : null));
                if (setAsInitialConfig)
                {
                    if (overrideWithConfig != null && overrideWithConfig.Length > 0)
                        InitialConfiguration = overrideWithConfig;
                    else if (Collector != null)
                        InitialConfiguration = Collector.GetDefaultOrEmptyConfigString();
                }
                CollectorRegistrationDisplayName = ra.DisplayName;
                CollectorRegistrationName = ra.Name;
            }
        }
        private static ICollector CreateAndConfigureEntry(RegisteredAgent ra, string appliedConfig, List<ConfigVariable> configVariables)
        {
            ICollector newEntry = CreateCollectorEntry(ra);
            if (newEntry != null)
            {
                if (appliedConfig == null || appliedConfig.Length == 0)
                    appliedConfig = newEntry.GetDefaultOrEmptyConfigString();
                if (configVariables != null && configVariables.Count > 0)
                {
                    foreach (ConfigVariable vc in configVariables)
                        if (vc.Name.Length > 0)
                            appliedConfig = appliedConfig.Replace(vc.Name, vc.Value);
                }
                newEntry.AgentConfig.ReadConfiguration(appliedConfig);
            }
            return newEntry;
        }
        public void RefreshCollectorConfig(List<ConfigVariable> monitorPackVars = null)
        {
            if (!this.IsFolder && Collector != null)
            {
                List<ConfigVariable> allConfigVars = new List<ConfigVariable>();
                string appliedConfig = "";
                if (monitorPackVars != null)
                {
                    allConfigVars.AddRange(monitorPackVars.ToArray());
                }
                if (ConfigVariables != null)
                {
                    allConfigVars.AddRange(ConfigVariables.ToArray());
                }
                if (initialConfiguration != null && initialConfiguration.Length > 0)
                    appliedConfig = initialConfiguration;
                else
                    appliedConfig = Collector.GetDefaultOrEmptyConfigString();
                /***************** Now apply all config variables ****************/
                if (allConfigVars != null && allConfigVars.Count > 0)
                {
                    foreach (ConfigVariable vc in allConfigVars)
                        if (vc.Name.Length > 0)
                            appliedConfig = appliedConfig.Replace(vc.Name, vc.Value);
                }
                /***************** Apply all config ****************/
                Collector.AgentConfig.ReadConfiguration(appliedConfig);
            }
        }
        public void CreateAndConfigureEntry(RegisteredAgent ra, List<ConfigVariable> monitorPackVars)
        {
            List<ConfigVariable> allConfigVars = new List<ConfigVariable>();
            if (monitorPackVars != null)
            {
                allConfigVars.AddRange(monitorPackVars.ToArray());
            }
            if (ConfigVariables != null)
            {
                allConfigVars.AddRange(ConfigVariables.ToArray());
            }
            if (InitialConfiguration != null && InitialConfiguration.Length > 0)
                Collector = CreateAndConfigureEntry(ra, InitialConfiguration, allConfigVars);
            else
            {
                Collector = CreateAndConfigureEntry(ra, "", allConfigVars);
            }
            CollectorRegistrationDisplayName = ra.DisplayName;
        }
        /// <summary>
        /// Create a new instance of the collector agent
        /// </summary>
        /// <param name="ra">Agent registration type</param>
        /// <returns>Instance of ICollector</returns>
        public static ICollector CreateCollectorEntry(RegisteredAgent ra)
        {
            if (ra != null)
            {
                return CreateCollectorEntry(ra.AssemblyPath, ra.ClassName);
            }
            else
                return null;
        }
        /// <summary>
        /// Create a new instance of the collector agent
        /// </summary>
        /// <param name="assemblyPath">Path to Collector agent type</param>
        /// <param name="className">Class name of Collector agent type</param>
        /// <returns>Instance of ICollector</returns>
        private static ICollector CreateCollectorEntry(string assemblyPath, string className)
        {
            Assembly collectorEntryAssembly = Assembly.LoadFile(assemblyPath);
            ICollector newCollectorEntry = (ICollector)collectorEntryAssembly.CreateInstance(className);
            newCollectorEntry.Name = className.Replace("QuickMon.Collectors.", "");
            return newCollectorEntry;
        }
        #endregion
    }
}
