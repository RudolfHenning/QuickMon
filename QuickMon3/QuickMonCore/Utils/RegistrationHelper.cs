using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.IO;

namespace QuickMon
{
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

                                                try
                                                {
                                                    displayName = GetTypeDisplayName(type, name);
                                                }
                                                catch { }
                                                RegisteredAgent agentRegistration = new RegisteredAgent();
                                                agentRegistration.Name = name;
                                                agentRegistration.DisplayName = displayName;
                                                agentRegistration.AssemblyPath = dllPath;
                                                agentRegistration.ClassName = className;
                                                agentRegistration.IsCollector = RegistrationHelper.IsCollectorClass(quickMonAssembly, className);
                                                agentRegistration.IsNotifier = !agentRegistration.IsCollector;
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

                                try
                                {
                                    displayName = GetTypeDisplayName(type, name);
                                }
                                catch { }
                                RegisteredAgent agentRegistration = new RegisteredAgent();
                                agentRegistration.Name = name;
                                agentRegistration.DisplayName = displayName;
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
        public static string LoadAssemblyDescription(Assembly quickMonAssembly)
        {
            
            AssemblyDescriptionAttribute desc = (AssemblyDescriptionAttribute)
           AssemblyDescriptionAttribute.GetCustomAttribute(
               quickMonAssembly, typeof(AssemblyDescriptionAttribute));
            return desc.Description;
        }
    }
}
