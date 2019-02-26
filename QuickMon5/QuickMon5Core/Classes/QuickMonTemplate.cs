using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class QuickMonTemplate
    {
        public TemplateType TemplateType { get; set; }
        public string Name { get; set; }
        public string ForClass { get; set; }
        public string Description { get; set; }
        public string Config { get; set; }
        public static string LastError { get; set; } = "";

        #region Get Template lists
        public static List<QuickMonTemplate> GetAllTemplates()
        {
            List<QuickMonTemplate> list = new List<QuickMonTemplate>();
            string fileContents = System.IO.File.ReadAllText(MonitorPack.GetQuickMonUserDataTemplatesFile());
            if (fileContents.Contains("<quickMonTemplate>") && fileContents.Contains("</quickMonTemplate>"))
            {
                try
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(fileContents);
                    XmlElement root = xdoc.DocumentElement;
                    foreach (XmlNode templateNode in root.SelectNodes("template"))
                    {
                        try
                        {
                            QuickMonTemplate newTemplate = new QuickMonTemplate();
                            newTemplate.Name = templateNode.ReadXmlElementAttr("name", "");
                            newTemplate.TemplateType = TemplateTypeConverter.FromText(templateNode.ReadXmlElementAttr("type", "MonitorPack"));
                            newTemplate.ForClass = templateNode.ReadXmlElementAttr("class", "");
                            newTemplate.Description = templateNode.ReadXmlElementAttr("description", "");
                            newTemplate.Config = templateNode.InnerXml;
                            list.Add(newTemplate);
                        }
                        catch { }
                    }
                }
                catch(Exception ex)
                {
                    LastError = ex.Message;
                }
            }
            return list;
        }
        public static List<QuickMonTemplate> GetMonitorPackTemplates()
        {
            return (from t in GetAllTemplates()
                    where t.TemplateType == TemplateType.MonitorPack
                    select t).ToList();
        }
        public static List<QuickMonTemplate> GetCollectorHostTemplates()
        {
            return (from t in GetAllTemplates()
                    where t.TemplateType == TemplateType.CollectorHost
                    select t).ToList();
        }
        public static List<QuickMonTemplate> GetCollectorAgentTemplates()
        {
            return (from t in GetAllTemplates()
                    where t.TemplateType == TemplateType.CollectorAgent
                    select t).ToList();
        }
        public static List<QuickMonTemplate> GetNotifierHostTemplates()
        {
            return (from t in GetAllTemplates()
                    where t.TemplateType == TemplateType.NotifierHost
                    select t).ToList();
        }
        public static List<QuickMonTemplate> GetNotifierAgentTemplates()
        {
            return (from t in GetAllTemplates()
                    where t.TemplateType == TemplateType.NotifierAgent
                    select t).ToList();
        } 
        #endregion

        #region Reset templates
        public static void ResetTemplates()
        {
            string path = MonitorPack.GetQuickMonUserDataTemplatesFile();
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(path)))
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
            System.IO.File.WriteAllText(path, Properties.Resources.QuickMon5DefaultTemplate);
        } 
        #endregion
        
        #region Saving
        public static void SaveTemplates(List<QuickMonTemplate> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.AppendLine("<quickMonTemplate>");
            //MonitorPacks
            foreach (QuickMonTemplate template in (from t in list
                                                   where t.TemplateType == TemplateType.MonitorPack
                                                   orderby t.Name
                                                   select t))
            {
                sb.AppendLine(GetTemplateXmlString(template.Name, "MonitorPack", "MonitorPack", template.Description, template.Config));
            }
            //CollectorHosts
            foreach (QuickMonTemplate template in (from t in list
                                                   where t.TemplateType == TemplateType.CollectorHost
                                                   orderby t.Name
                                                   select t))
            {
                sb.AppendLine(GetTemplateXmlString(template.Name, "CollectorHost", "CollectorHost", template.Description, template.Config));
            }
            //CollectorAgent
            foreach (QuickMonTemplate template in (from t in list
                                                   where t.TemplateType == TemplateType.CollectorAgent
                                                   orderby t.Name
                                                   select t))
            {
                sb.AppendLine(GetTemplateXmlString(template.Name, "CollectorAgent", template.ForClass, template.Description, template.Config));
            }
            //NotifierHosts
            foreach (QuickMonTemplate template in (from t in list
                                                   where t.TemplateType == TemplateType.NotifierHost
                                                   orderby t.Name
                                                   select t))
            {
                sb.AppendLine(GetTemplateXmlString(template.Name, "NotifierHost", "NotifierHost", template.Description, template.Config));
            }
            //NotifierAgents
            foreach (QuickMonTemplate template in (from t in list
                                                   where t.TemplateType == TemplateType.NotifierAgent
                                                   orderby t.Name
                                                   select t))
            {
                sb.AppendLine(GetTemplateXmlString(template.Name, "NotifierAgent", template.ForClass, template.Description, template.Config));
            }
            sb.AppendLine("</quickMonTemplate>");
            if (System.IO.File.Exists(MonitorPack.GetQuickMonUserDataTemplatesFile() + ".bak"))
            {
                System.IO.File.SetAttributes(MonitorPack.GetQuickMonUserDataTemplatesFile() + ".bak", System.IO.FileAttributes.Normal);
                System.IO.File.Delete(MonitorPack.GetQuickMonUserDataTemplatesFile() + ".bak");

            }
            if (System.IO.File.Exists(MonitorPack.GetQuickMonUserDataTemplatesFile()))
            {
                System.IO.File.Move(MonitorPack.GetQuickMonUserDataTemplatesFile(), MonitorPack.GetQuickMonUserDataTemplatesFile() + ".bak");
            }
            System.IO.File.WriteAllText(MonitorPack.GetQuickMonUserDataTemplatesFile(), sb.ToString().BeautifyXML());
        }
        private static string GetTemplateXmlString(string name, string typeName, string className, string description, string config)
        {
            return string.Format("<template name=\"{0}\" type=\"{1}\" class=\"{2}\" description=\"{3}\">\r\n{4}\r\n</template>",
                name.EscapeXml(), typeName.EscapeXml(), className.EscapeXml(), description.EscapeXml(), config);
        } 
        #endregion
    }
}
