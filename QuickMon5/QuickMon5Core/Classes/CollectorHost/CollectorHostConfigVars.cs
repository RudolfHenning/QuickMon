using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon
{
    public partial class CollectorHost
    {
        public List<ConfigVariable> GetAllParentConfigVars()
        {
            List<ConfigVariable> allConfigVars = new List<ConfigVariable>();
            if (ParentMonitorPack != null)
            {
                //apply static/hardcoded monitor pack variables
                allConfigVars.Add(new ConfigVariable() { FindValue = "$QMScripts", ReplaceValue = ParentMonitorPack.ScriptsRepositoryDirectory });
                allConfigVars.Add(new ConfigVariable() { FindValue = "$QMVersion", ReplaceValue = ParentMonitorPack.Version });
                allConfigVars.Add(new ConfigVariable() { FindValue = "$QMCoreVersion", ReplaceValue = System.Reflection.Assembly.GetAssembly(typeof(MonitorPack)).GetName().Version.ToString() });

                foreach (CollectorHost parentCollector in ParentMonitorPack.GetParentCollectorHostTree(this))
                {
                    foreach (ConfigVariable cv in parentCollector.ConfigVariables)
                    {
                        ConfigVariable existingCV = (from ConfigVariable c in allConfigVars
                                                     where c.FindValue == cv.FindValue
                                                     select c).FirstOrDefault();
                        if (existingCV == null)
                        {
                            allConfigVars.Add(cv.Clone());
                        }
                    }
                }
                //then applying parent monitor pack variables
                foreach (ConfigVariable cv in ParentMonitorPack.ConfigVariables)
                {
                    ConfigVariable existingCV = (from ConfigVariable c in allConfigVars
                                                 where c.FindValue == cv.FindValue
                                                 select c).FirstOrDefault();
                    if (existingCV == null)
                    {
                        allConfigVars.Add(cv.Clone());
                    }
                }
            }
            return allConfigVars;
        }
        private List<ConfigVariable> GetConfigVarsNow()
        {
            List<ConfigVariable> allConfigVars = new List<ConfigVariable>();
            //applying its own first
            foreach (ConfigVariable cv in ConfigVariables)
            {
                ConfigVariable existingCV = (from ConfigVariable c in allConfigVars
                                             where c.FindValue == cv.FindValue
                                             select c).FirstOrDefault();
                if (existingCV == null)
                {
                    allConfigVars.Add(cv.Clone());
                }
            }
            //then applying parent Collector Host variables
            if (ParentMonitorPack != null)
            {
                foreach (ConfigVariable cv in GetAllParentConfigVars())
                {
                    ConfigVariable existingCV = (from ConfigVariable c in allConfigVars
                                                 where c.FindValue == cv.FindValue
                                                 select c).FirstOrDefault();
                    if (existingCV == null)
                    {
                        allConfigVars.Add(cv.Clone());
                    }
                }
            }
            return allConfigVars;
        }
        public string ApplyConfigVarsOnString(string rawString)
        {
            if (currentConfigVars != null && currentConfigVars.Count > 0)
                return currentConfigVars.ApplyOn(rawString);
            else
                return rawString;
        }
        public void ApplyConfigVarsNow()
        {
            currentConfigVars = GetConfigVarsNow();// new List<ConfigVariable>();
            ////applying its own first
            //foreach (ConfigVariable cv in ConfigVariables)
            //{
            //    ConfigVariable existingCV = (from ConfigVariable c in allConfigVars
            //                                 where c.FindValue == cv.FindValue
            //                                 select c).FirstOrDefault();
            //    if (existingCV == null)
            //    {
            //        allConfigVars.Add(cv.Clone());
            //    }
            //}
            ////then applying parent Collector Host variables
            //if (ParentMonitorPack != null)
            //{
            //    foreach (ConfigVariable cv in GetAllParentConfigVars())
            //    {
            //        ConfigVariable existingCV = (from ConfigVariable c in allConfigVars
            //                                     where c.FindValue == cv.FindValue
            //                                     select c).FirstOrDefault();
            //        if (existingCV == null)
            //        {
            //            allConfigVars.Add(cv.Clone());
            //        }
            //    }
            //}

            foreach (IAgent agent in CollectorAgents)
            {
                string appliedConfig = agent.InitialConfiguration;
                System.Diagnostics.Trace.WriteLine($"{agent.Name}:{agent.InitialConfiguration}");
                appliedConfig = currentConfigVars.ApplyOn(appliedConfig);
                //only reapply if it is different from existing
                if (agent.ActiveConfiguration != appliedConfig)
                {
                    agent.ActiveConfiguration = appliedConfig;
                    agent.AgentConfig.FromXml(appliedConfig);
                }
            }

            nameFormatted = currentConfigVars.ApplyOn(Name);
            remoteAgentHostAddressFormatted = currentConfigVars.ApplyOn(RemoteAgentHostAddress);
            overrideRemoteAgentHostAddressFormatted = currentConfigVars.ApplyOn(OverrideRemoteAgentHostAddress);
        }

        private List<ConfigVariable> currentConfigVars = new List<ConfigVariable>();

        private string nameFormatted = "";
        public string NameFormatted
        {
            get
            {
                if (nameFormatted == "")
                    return Name;
                else
                    return nameFormatted;
            }
        }
        private string remoteAgentHostAddressFormatted = "";
        public string RemoteAgentHostAddressFormatted
        {
            get
            {
                if (remoteAgentHostAddressFormatted == "")
                    return RemoteAgentHostAddress;
                else
                    return remoteAgentHostAddressFormatted;
            }
        }
        private string overrideRemoteAgentHostAddressFormatted = "";
        public string OverrideRemoteAgentHostAddressFormatted
        {
            get
            {
                if (overrideRemoteAgentHostAddressFormatted == "")
                    return OverrideRemoteAgentHostAddress;
                else
                    return overrideRemoteAgentHostAddressFormatted;
            }
        }
    }
}
