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
        public static string LoadAssemblyDescription(string assemblyFilePath)
        {
            Assembly quickAsshehe = Assembly.LoadFile(assemblyFilePath);
            AssemblyDescriptionAttribute desc = (AssemblyDescriptionAttribute)
           AssemblyDescriptionAttribute.GetCustomAttribute(
               quickAsshehe, typeof(AssemblyDescriptionAttribute));
            return desc.Description;
        }
        public static IEnumerable LoadQuickMonClasses(string assemblyFilePath)
        {
            Assembly quickAsshehe = Assembly.LoadFile(assemblyFilePath);
            Type[] types = quickAsshehe.GetTypes();
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
        public static bool IsQuickMonAssembly(string assemblyFilePath)
        {
            Assembly quickAsshehe = Assembly.LoadFile(assemblyFilePath);
            Type[] types = quickAsshehe.GetTypes();
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
        public static bool IsCollectorClass(string assemblyFilePath, string className)
        {
            Assembly quickAsshehe = Assembly.LoadFile(assemblyFilePath);
            Type[] types = quickAsshehe.GetTypes();
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
        public static List<AgentRegistration> CreateAgentRegistrationListByDirectory(string directoryPath)
        {
            List<AgentRegistration> importList = new List<AgentRegistration>();
            foreach (string dllPath in Directory.GetFiles(directoryPath, "*.dll"))
            {
                try
                {
                    if (RegistrationHelper.IsQuickMonAssembly(dllPath))
                    {
                        foreach (string className in RegistrationHelper.LoadQuickMonClasses(dllPath))
                        {
                            string name = className.Replace("QuickMon.", "");
                            AgentRegistration agentRegistration = new AgentRegistration();
                            agentRegistration.Name = name;
                            agentRegistration.AssemblyPath = dllPath;
                            agentRegistration.ClassName = className;
                            agentRegistration.IsCollector = RegistrationHelper.IsCollectorClass(dllPath, className);
                            agentRegistration.IsNotifier = !agentRegistration.IsCollector;
                            importList.Add(agentRegistration);
                        }
                    }
                }
                catch { }
            }
            return importList;
        }
    }
}
