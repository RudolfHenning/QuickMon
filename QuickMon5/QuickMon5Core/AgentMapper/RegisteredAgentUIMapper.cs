using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace QuickMon.UI
{
    public static class RegisteredAgentUIMapper
    {
        private class WinFormsUIEntry
        {
            public string UIClassName { get; set; }
            public string AgentClassName { get; set; }
            public Assembly ContainingAssembly { get; set; }
        }

        private static List<WinFormsUIEntry> agentsCache = new List<WinFormsUIEntry>();

        public static IWinFormsUI GetUIClass(IAgent agent)
        {
            IWinFormsUI uiClass = null;
            if (agentsCache == null || agentsCache.Count == 0)
            {
                LoadCache();
            }
            WinFormsUIEntry winFormsUIEntry = (from w in agentsCache
                                               where w.AgentClassName == agent.AgentClassName
                                               select w).FirstOrDefault();
            if (winFormsUIEntry != null)
            {
                uiClass = (IWinFormsUI)winFormsUIEntry.ContainingAssembly.CreateInstance(winFormsUIEntry.UIClassName);
            }
            return uiClass;
        }
        public static WinFormsUINotifierBase GetNotifierUIClass(INotifier agent)
        {
            WinFormsUINotifierBase uiClass = null;
            if (agentsCache == null || agentsCache.Count == 0)
            {
                LoadCache();
            }
            WinFormsUIEntry winFormsUIEntry = (from w in agentsCache
                                               where w.AgentClassName == agent.AgentClassName
                                               && w.UIClassName.ToLower().Contains("notifier")
                                               select w).FirstOrDefault();
            if (winFormsUIEntry != null)
            {
                uiClass = (WinFormsUINotifierBase)winFormsUIEntry.ContainingAssembly.CreateInstance(winFormsUIEntry.UIClassName);
            }
            return uiClass;
        }
        public static bool HasAgentViewer(INotifier agent)
        {
            WinFormsUINotifierBase ui = GetNotifierUIClass(agent);
            return ui == null ? false : ui.HasDetailView;
        }

        private static void LoadCache()
        {
            string directoryPath = System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(RegisteredAgentUIMapper)).Location);
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
                                            if (interfaceType.FullName == "QuickMon.UI.IWinFormsUI")
                                            {
                                                string className = type.FullName;

                                                WinFormsUIEntry winFormsUIEntry = new WinFormsUIEntry();
                                                winFormsUIEntry.UIClassName = className;

                                                IWinFormsUI uiInstance = (IWinFormsUI)quickMonAssembly.CreateInstance(className);
                                                winFormsUIEntry.AgentClassName = uiInstance.AgentType;

                                                winFormsUIEntry.ContainingAssembly = quickMonAssembly;

                                                agentsCache.Add(winFormsUIEntry);
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
                        if (interfaceType.FullName == "QuickMon.UI.IWinFormsUI")
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
