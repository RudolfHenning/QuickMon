using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class ActionScript
    {
        public string Name { get; set; }
        public ScriptType ScriptType { get; set; }
        public string Description { get; set; }
        public string Script { get; set; }

        public string ToXml()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<script />");
            xdoc.DocumentElement.SetAttributeValue("name", Name);
            xdoc.DocumentElement.SetAttributeValue("type", ScriptType.ToString());
            xdoc.DocumentElement.SetAttributeValue("description", Description);
            xdoc.DocumentElement.InnerText = Script;

            return xdoc.DocumentElement.OuterXml;
        }
        public static List<ActionScript> FromXml(string config)
        {
            List<ActionScript> scripts = new List<ActionScript>();
            if (config != null && config.Trim().Length > 0)
            {
                XmlDocument configXml = new XmlDocument();
                configXml.LoadXml(config);
                XmlElement root = configXml.DocumentElement;
                foreach (XmlNode scriptItem in root.SelectNodes("script"))
                {
                    try
                    {
                        ActionScript script = new ActionScript();
                        script.Name = scriptItem.ReadXmlElementAttr("name", "");
                        script.ScriptType = ScriptTypeConverter.FromString(scriptItem.ReadXmlElementAttr("type", "dos"));
                        script.Description = scriptItem.ReadXmlElementAttr("description", "");
                        script.Script = scriptItem.InnerText;
                        scripts.Add(script);
                    }
                    catch { }
                }
            }
            return scripts;
        }
    }

    
}
