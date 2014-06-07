using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class AgentPresetConfig
    {
        public string AgentClassName { get; set; }
        public string Description { get; set; }
        public string AgentDefaultName { get; set; }        
        public string Config { get; set; }

        public override string ToString()
        {
            return AgentClassName + "-" + AgentDefaultName + "-" + Description;
        }
        public static List<AgentPresetConfig> GetAllPresets()
        {
            List<AgentPresetConfig> presets = new List<AgentPresetConfig>();
            string progDataPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Hen IT\\QuickMon 3");

            foreach (AgentPresetConfig apc in ReadPresetsFromDirectory(progDataPath))
            {
                if ((from p in presets
                     where p.AgentDefaultName == apc.AgentDefaultName && p.Description == apc.Description
                     select p).FirstOrDefault() == null)
                    presets.Add(apc);
            }

            //search current directory as well
            string presetPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            foreach (AgentPresetConfig apc in ReadPresetsFromDirectory(presetPath))
            {
                if ((from p in presets
                     where p.AgentDefaultName == apc.AgentDefaultName && p.Description == apc.Description
                     select p).FirstOrDefault() == null)
                    presets.Add(apc);
            }
            return presets;
        }
        /// <summary>
        /// Agent can call this static method to get all presets stored in current directory (files with *.qps name)
        /// </summary>
        /// <param name="agentClass"></param>
        /// <returns></returns>
        public static List<AgentPresetConfig> GetPresetsForClass(string agentClass)
        {
            List<AgentPresetConfig> presets = new List<AgentPresetConfig>();
            string progDataPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Hen IT\\QuickMon 3");
            
            foreach (AgentPresetConfig apc in ReadPresetsFromDirectory(progDataPath))
            {
                if (apc.AgentClassName == agentClass)
                    if ((from p in presets
                         where p.AgentClassName == agentClass && p.AgentDefaultName == apc.AgentDefaultName && p.Description == apc.Description
                         select p).FirstOrDefault() == null)
                        presets.Add(apc);
            }

            //search current directory as well
            string presetPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            foreach (AgentPresetConfig apc in ReadPresetsFromDirectory(presetPath))
            {
                if (apc.AgentClassName == agentClass)
                    if ((from p in presets
                         where p.AgentClassName == agentClass && p.AgentDefaultName == apc.AgentDefaultName && p.Description == apc.Description
                         select p).FirstOrDefault() == null)
                    presets.Add(apc);
            }
            return presets;
        }
        public static void SavePresetsToFile(string filePath, List<AgentPresetConfig> list )
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine("<qmpresets>");
            foreach(AgentPresetConfig preset in list)
            {
                try
                {
                    sb.Append("<preset ");
                    sb.Append("class=\"" + XmlFormattingUtils.EscapeXml(preset.AgentClassName) + "\" ");
                    sb.Append("name=\"" + XmlFormattingUtils.EscapeXml(preset.AgentDefaultName) + "\" ");
                    sb.Append("description=\"" + XmlFormattingUtils.EscapeXml(preset.Description) + "\"");
                    sb.AppendLine(">");

                    //assumption is made that <config> is valid xml
                    sb.AppendLine(preset.Config);

                    sb.AppendLine("</preset>");
                }
                catch (Exception nodeEx)
                {
                    System.Diagnostics.Trace.WriteLine("Error write preset: " + preset.ToString() + "\r\n" + nodeEx.ToString());
                }
            }
            sb.AppendLine("</qmpresets>");

            System.IO.File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
        public static List<AgentPresetConfig> ReadPresetsFromFile(string filePath)
        {
            List<AgentPresetConfig> presets = new List<AgentPresetConfig>();
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    XmlDocument presetDoc = new XmlDocument();
                    presetDoc.Load(filePath);
                    XmlElement root = presetDoc.DocumentElement;
                    if (root.Name == "qmpresets")
                    {
                        foreach(XmlElement presetNode in root.SelectNodes("preset"))
                        {
                            try
                            {
                                AgentPresetConfig apc = new AgentPresetConfig();
                                apc.AgentClassName = presetNode.ReadXmlElementAttr("class", "");
                                apc.AgentDefaultName = presetNode.ReadXmlElementAttr("name", "");
                                apc.Description = presetNode.ReadXmlElementAttr("description", "");
                                apc.Config = presetNode.InnerXml; //all of it e.g. <config>...</config>
                                //to nmake sure only 'available' agents get loaded
                                if ((from r in RegistrationHelper.GetAllAvailableAgents()
                                     where r.ClassName.EndsWith(apc.AgentClassName)
                                     select r).Count() > 0)
                                    presets.Add(apc);
                            }
                            catch (Exception nodeEx)
                            {
                                System.Diagnostics.Trace.WriteLine("Error reading preset: " +  nodeEx.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
            return presets;
        }
        public static List<AgentPresetConfig> ReadPresetsFromDirectory(string filePath)
        {
            List<AgentPresetConfig> presets = new List<AgentPresetConfig>();
            if (System.IO.Directory.Exists(filePath))
            {
                foreach(string presetfile in System.IO.Directory.GetFiles(filePath, "*.qps"))
                { 
                    foreach(AgentPresetConfig apc in ReadPresetsFromFile(presetfile))
                    {
                        presets.Add(apc);
                    }
                }
            }
            return presets;
        }

        public static string FormatVariables(string input)
        {
            return input.Replace("%LocalHost%", System.Net.Dns.GetHostName()
                .Replace("%IPAddress%", FormatUtils.N((from adr in System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())
                                             where adr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork
                                             select adr).FirstOrDefault(), "Err getting IP"))
                .Replace("%DateTime%", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .Replace("%Date%", DateTime.Today.ToShortDateString())
                .Replace("%Year%", DateTime.Now.Year.ToString())
                .Replace("%Month%", DateTime.Now.Month.ToString())
                .Replace("%Day%", DateTime.Now.Day.ToString())
                .Replace("%Hour%", DateTime.Now.Hour.ToString())
                .Replace("%Minute%", DateTime.Now.Minute.ToString())
                .Replace("%Second%", DateTime.Now.Second.ToString())
                );
        }
    }
}
