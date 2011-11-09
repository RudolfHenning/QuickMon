using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace QuickMon
{
    public class AgentRegistration
    {
        public string Name { get; set; }
        public string AssemblyPath { get; set; }
        public string ClassName { get; set; }
        private bool isCollector = true;
        public bool IsCollector { get { return isCollector; } set { isCollector = value; } }
        public bool IsNotifier { get { return ! isCollector; } set { isCollector = !value; } }

        public override string ToString()
        {
            string versionInfo = "";
            try
            {
                if (System.IO.File.Exists(AssemblyPath))
                {
                    Assembly a = Assembly.LoadFrom(AssemblyPath);
                    versionInfo = a.GetName().Version.ToString();
                    a = null;
                }
            }
            catch { }
            return string.Format("{0} ( {1}{2} )", Name, ClassName, versionInfo.Length > 0 ? " - " + versionInfo : "");
        }
    }
}
