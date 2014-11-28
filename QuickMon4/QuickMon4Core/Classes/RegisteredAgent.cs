using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        /// <summary>
        /// Force reload of all agents
        /// </summary>
        public static void LoadAgentsOverride()
        {
            LoadAgentsOverride(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }
        public static void LoadAgentsOverride(string agentsPath)
        {
            cacheLoaded = false;
            AgentsPath = agentsPath;
            agents = new List<RegisteredAgent>();
            agents = RegistrationHelper.GetAllRegisteredAgentsByDirectory(agentsPath);
        }
        public static RegisteredAgent GetRegisteredAgentByClassName(string className, bool collector = true)
        {
            return (from a in RegisteredAgentCache.Agents
                    where ((collector && a.IsCollector) || (!collector && a.IsNotifier)) && a.ClassName.ToLower().EndsWith(className.ToLower())
                    orderby a.Name
                    select a).FirstOrDefault();
        }
    }

    public static class RegistrationHelper
    {
        public static List<RegisteredAgent> GetAllAvailableAgents()
        {
            return GetAllRegisteredAgentsByDirectory(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }
        public static List<RegisteredAgent> GetAllRegisteredAgentsByDirectory(string directoryPath)
        {
            List<RegisteredAgent> list = new List<RegisteredAgent>();

            //Check in dll's in directory
            foreach (string dllPath in Directory.GetFiles(directoryPath, "*.dll"))
            {
                try
                {
                    Assembly quickMonAssembly = Assembly.LoadFile(dllPath);
                    if (IsQuickMonAssembly(quickMonAssembly))
                    {
                        Type[] types = quickMonAssembly.GetTypes();
                        foreach (Type type in types)
                        {
                            try
                            {
                                if (!type.IsInterface && !type.IsAbstract)
                                {
                                    foreach (Type interfaceType in type.GetInterfaces())
                                    {
                                        try
                                        {
                                            if (interfaceType.FullName == "QuickMon.IAgent")
                                            {
                                                string className = type.FullName;
                                                string name = className.Replace("QuickMon.", "");
                                                name = name.Replace("Collectors.", "");
                                                name = name.Replace("Notifiers.", "");
                                                string displayName = name;
                                                string categoryName = "General";
                                                try
                                                {
                                                    displayName = GetTypeDisplayName(type, name);
                                                }
                                                catch { }
                                                try
                                                {
                                                    categoryName = GetCategoryName(type);
                                                }
                                                catch { }

                                                RegisteredAgent agentRegistration = new RegisteredAgent();
                                                agentRegistration.Name = name;
                                                agentRegistration.DisplayName = displayName;
                                                agentRegistration.CategoryName = categoryName;
                                                agentRegistration.AssemblyPath = dllPath;
                                                agentRegistration.ClassName = className;
                                                agentRegistration.IsCollector = RegistrationHelper.IsCollectorClass(quickMonAssembly, className);
                                                agentRegistration.IsNotifier = RegistrationHelper.IsNotifierClass(quickMonAssembly, className);
                                                list.Add(agentRegistration);
                                            }
                                        }
                                        catch (Exception interfaceEx)
                                        {
                                            System.Diagnostics.Trace.WriteLine(interfaceEx.ToString());
                                        }
                                    }
                                }
                            }
                            catch (Exception isInterfaceEx)
                            {
                                System.Diagnostics.Trace.WriteLine(isInterfaceEx.ToString());
                            }
                        }
                    }
                }
                catch (Exception isQuickMonAssemblyEx)
                {
                    System.Diagnostics.Trace.WriteLine(isQuickMonAssemblyEx.ToString());
                }
            }

            //also check current executing Assembly
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            if (IsQuickMonAssembly(currentAssembly))
            {
                Type[] types = currentAssembly.GetTypes();
                foreach (Type type in types)
                {
                    if (!type.IsInterface && !type.IsAbstract)
                    {
                        foreach (Type interfaceType in type.GetInterfaces())
                        {
                            if (interfaceType.FullName == "QuickMon.IAgent")
                            {
                                string className = type.FullName;
                                string name = className.Replace("QuickMon.", "");
                                name = name.Replace("Collectors.", "");
                                name = name.Replace("Notifiers.", "");
                                string displayName = name;
                                string categoryName = "General";

                                try
                                {
                                    displayName = GetTypeDisplayName(type, name);
                                }
                                catch { }
                                try
                                {
                                    categoryName = GetCategoryName(type);
                                }
                                catch { }
                                RegisteredAgent agentRegistration = new RegisteredAgent();
                                agentRegistration.Name = name;
                                agentRegistration.DisplayName = displayName;
                                agentRegistration.CategoryName = categoryName;
                                agentRegistration.AssemblyPath = Assembly.GetExecutingAssembly().Location;
                                agentRegistration.ClassName = className;
                                agentRegistration.IsCollector = RegistrationHelper.IsCollectorClass(currentAssembly, className);
                                agentRegistration.IsNotifier = !agentRegistration.IsCollector;
                                list.Add(agentRegistration);
                            }
                        }
                    }
                }
            }

            return list;
        }

        private static string GetCategoryName(Type type)
        {
            string categoryName = "General";
            object[] atts = type.GetCustomAttributes(typeof(System.ComponentModel.CategoryAttribute), true);
            if (atts != null && atts.Length > 0)
            {
                object att1 = atts[0];
                categoryName = ((System.ComponentModel.CategoryAttribute)att1).Category;
            }
            return categoryName;
        }

        private static string GetTypeDisplayName(Type type, string defaultValue = "")
        {
            string displayName = defaultValue;
            object[] atts = type.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
            if (atts != null && atts.Length > 0)
            {
                object att1 = atts[0];
                displayName = ((System.ComponentModel.DescriptionAttribute)att1).Description;
            }

            return displayName;
        }
        public static bool IsQuickMonAssembly(Assembly quickMonAssembly)
        {
            Type[] types = quickMonAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (!type.IsInterface && !type.IsAbstract)
                {
                    foreach (Type interfaceType in type.GetInterfaces())
                    {
                        if (interfaceType.FullName == "QuickMon.IAgent")
                            return true;
                    }
                }
            }
            return false;
        }
        public static IEnumerable LoadQuickMonClassNames(Assembly quickMonAssembly)
        {
            Type[] types = quickMonAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (!type.IsInterface && !type.IsAbstract)
                {
                    foreach (Type interfaceType in type.GetInterfaces())
                    {
                        if (interfaceType.FullName == "QuickMon.IAgent")
                            yield return type.FullName;
                    }
                }
            }
        }
        public static bool IsCollectorClass(Assembly quickMonAssembly, string className)
        {
            Type[] types = quickMonAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.FullName == className)
                {
                    foreach (Type interfaceType in type.GetInterfaces())
                    {
                        if (interfaceType.FullName == "QuickMon.ICollector")
                            return true;
                    }
                    return false;
                }
            }
            return false;
        }
        public static bool IsNotifierClass(Assembly quickMonAssembly, string className)
        {
            Type[] types = quickMonAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.FullName == className)
                {
                    foreach (Type interfaceType in type.GetInterfaces())
                    {
                        if (interfaceType.FullName == "QuickMon.INotifier")
                            return true;
                    }
                    return false;
                }
            }
            return false;
        }
        public static string LoadAssemblyDescription(Assembly quickMonAssembly)
        {

            AssemblyDescriptionAttribute desc = (AssemblyDescriptionAttribute)
           AssemblyDescriptionAttribute.GetCustomAttribute(
               quickMonAssembly, typeof(AssemblyDescriptionAttribute));
            return desc.Description;
        }
    }
}
