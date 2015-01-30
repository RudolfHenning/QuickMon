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

        public static List<QuickMonTemplate> GetAllTemplates()
        {
            List<QuickMonTemplate> list = new List<QuickMonTemplate>();
            foreach (string directoryPath in TemplateDirectories())
            {
                if (System.IO.Directory.Exists(directoryPath))
                {
                    foreach (string filePath in System.IO.Directory.GetFiles(directoryPath, "*.qmtemplate"))
                    {
                        list.AddRange(GetTemplatesInFile(filePath));
                    }
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

        private static List<QuickMonTemplate> GetTemplatesInFile(string filePath)
        {
            List<QuickMonTemplate> list = new List<QuickMonTemplate>();
            string fileContents = System.IO.File.ReadAllText(filePath);
            if (fileContents.StartsWith("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n"))
                fileContents = fileContents.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n", "");
            if (fileContents.StartsWith("<quickMonTemplate>") && fileContents.EndsWith("</quickMonTemplate>"))
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
                catch { }
            }
            return list;
        }

        private static List<string> TemplateDirectories()
        {
            List<string> directories = new List<string>();
            directories.Add(MonitorPack.GetQuickMonAppDataDirectory());
            directories.Add(MonitorPack.GetQuickMonUserDataDirectory());
            return directories;
        }
    }
}
