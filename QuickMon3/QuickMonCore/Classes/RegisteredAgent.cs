using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace QuickMon
{
    public class RegisteredAgent
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string AssemblyPath { get; set; }
        public string ClassName { get; set; }
        public string CategoryName { get; set; }
        private bool isCollector = true;
        public bool IsCollector { get { return isCollector; } set { isCollector = value; } }
        public bool IsNotifier { get { return !isCollector; } set { isCollector = !value; } }

        public override string ToString()
        {
            return DisplayName;
        }
    }

    public static class RegisteredAgentCache
    {
        private static string agentsPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string AgentsPath
        {
            get { return agentsPath; }
            set { agentsPath = value; }
        }
        private static bool cacheLoaded = false;
        private static List<RegisteredAgent> agents = new List<RegisteredAgent>();
        public static List<RegisteredAgent> Agents
        {
            get
            {
                if (!cacheLoaded)
                {
                    agents = RegistrationHelper.GetAllRegisteredAgentsByDirectory(agentsPath);
                    cacheLoaded = true;
                }
                return agents;
            }
        }
        public static void LoadAgentsOverride(string agentsPath)
        {
            cacheLoaded = false;
            AgentsPath = agentsPath;
            agents = new List<RegisteredAgent>();
            agents = RegistrationHelper.GetAllRegisteredAgentsByDirectory(agentsPath);
        }
    }
}
