using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace QuickMon.UI
{    
    public class AgentUIThingies
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string AssemblyPath { get; set; }
        public string ClassName { get; set; }
        private bool isForCollectorUI = true;
        public bool IsForCollector { get { return isForCollectorUI; } set { isForCollectorUI = value; } }
        public bool IsForNotifier { get { return !isForCollectorUI; } set { isForCollectorUI = !value; } }

        public override string ToString()
        {
            return DisplayName;
        }
    }

    public static class RegisteredAgentUICache
    {
        private static string agentsPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string AgentsPath
        {
            get { return agentsPath; }
            set { agentsPath = value; }
        }
        private static bool cacheLoaded = false;
        private static List<AgentUIThingies> agents = new List<AgentUIThingies>();
        public static List<AgentUIThingies> Agents
        {
            get
            {
                if (!cacheLoaded)
                {
                    agents = RegistrationHelperForWinFormsUI.GetAllRegisteredAgentsByDirectory(agentsPath);
                    cacheLoaded = true;
                }
                return agents;
            }
        }
    }

    public class RegistrationHelperForWinFormsUI
    {

        public static List<AgentUIThingies> GetAllAvailableAgents()
        {
            return GetAllRegisteredAgentsByDirectory(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        public static List<AgentUIThingies> GetAllRegisteredAgentsByDirectory(string directoryPath)
        {
             List<AgentUIThingies> list = new List<AgentUIThingies>();

            //Check in dll's in directory
             foreach (string dllPath in Directory.GetFiles(directoryPath, "*.dll"))
             {
                 try
                 {
                     Assembly quickMonAssembly = Assembly.LoadFile(dllPath);
                     if (IsQuickMonWinFormsUIAssembly(quickMonAssembly))
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
                                             if (interfaceType.FullName == "QuickMon.IWinFormsUI")
                                             {
                                                 string className = type.FullName;
                                                 string name = className.Replace("QuickMon.", "");
                                                 name = name.Replace("Collectors.", "");
                                                 name = name.Replace("Notifiers.", "");
                                                 string displayName = name;
                                                 try
                                                 {
                                                     displayName = GetTypeDisplayName(type, name);
                                                 }
                                                 catch { }                                                 

                                                 AgentUIThingies agentRegistration = new AgentUIThingies();
                                                 agentRegistration.Name = name;
                                                 agentRegistration.DisplayName = displayName;
                                                 agentRegistration.AssemblyPath = dllPath;
                                                 agentRegistration.ClassName = className;
                                                 agentRegistration.IsForCollector = RegistrationHelperForWinFormsUI.IsCollectorClass(quickMonAssembly, className);
                                                 agentRegistration.IsForNotifier = !agentRegistration.IsForCollector;
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
             return list;
        }


        public static bool IsQuickMonWinFormsUIAssembly(Assembly quickMonAssembly)
        {
            Type[] types = quickMonAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (!type.IsInterface && !type.IsAbstract)
                {
                    foreach (Type interfaceType in type.GetInterfaces())
                    {
                        if (interfaceType.FullName == "QuickMon.IWinFormsUI")
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
                        if (interfaceType.FullName == "QuickMon.IWinFormsUI")
                            yield return type.FullName;
                    }
                }
            }
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
        public static bool IsCollectorClass(Assembly quickMonAssembly, string className)
        {
            Type[] types = quickMonAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.FullName == className)
                {
                    foreach (Type interfaceType in type.GetInterfaces())
                    {
                        if (interfaceType.FullName == "QuickMon.ICollectorUI")
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
