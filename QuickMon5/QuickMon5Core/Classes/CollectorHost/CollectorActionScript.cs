using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuickMon
{
    public class CollectorActionScript
    {
        public CollectorActionScript()
        {
            Parameters = new List<ScriptParameter>();
        }
        public class ScriptParameter
        {
            public string Id { get; set; }
            public string Value { get; set; }
            public string ToXml()
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml("<parameter />");
                xdoc.DocumentElement.SetAttributeValue("id", Id);
                xdoc.DocumentElement.SetAttributeValue("value", Value);
                return xdoc.DocumentElement.OuterXml;
            }
            public XmlNode ToXmlNode()
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml("<parameter />");
                xdoc.DocumentElement.SetAttributeValue("id", Id);
                xdoc.DocumentElement.SetAttributeValue("value", Value);
                return xdoc.DocumentElement;
            }
            public static List<ScriptParameter> FromXml(XmlNode parametersNode)
            {
                List<ScriptParameter> parameters = new List<ScriptParameter>();
                if (parametersNode.OuterXml.StartsWith("<parameters"))
                {
                    ScriptParameter sp = new ScriptParameter() { Id = "" };
                    foreach (XmlNode parameterNode in parametersNode.SelectNodes("parameter"))
                    {
                        sp.Id = parameterNode.ReadXmlElementAttr("id", "");
                        sp.Value = parameterNode.ReadXmlElementAttr("value", "");
                        parameters.Add(sp);
                    }
                }
                return parameters;
            }
        }
        public string MPId { get; set; }
        public bool IsErrorCorrectiveScript { get; set; }
        public bool IsWarningCorrectiveScript { get; set; }
        public bool IsRestorationScript { get; set; }
        public List<ScriptParameter> Parameters { get; set; }

        public XmlNode ToXmlNode()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<actionScript><parameters /></actionScript>");
            xdoc.DocumentElement.SetAttributeValue("mpId", MPId);            
            xdoc.DocumentElement.SetAttributeValue("correctiveErrorScript", IsErrorCorrectiveScript);
            xdoc.DocumentElement.SetAttributeValue("correctiveWarningScript", IsWarningCorrectiveScript);
            xdoc.DocumentElement.SetAttributeValue("restorationScript", IsRestorationScript);
            XmlNode parametersNode = xdoc.DocumentElement.SelectSingleNode("parameters");
            foreach (ScriptParameter parameter in Parameters)
            {
                parametersNode.AppendChild(parameter.ToXmlNode());
            }

            return xdoc.DocumentElement;
        }
        public string ToXml()
        {
            return ToXmlNode().OuterXml;
        }
        public static List<CollectorActionScript> FromXml(string config)
        {
            List<CollectorActionScript> scripts = new List<CollectorActionScript>();
            if (config != null && config.Trim().Length > 0)
            {
                XmlDocument configXml = new XmlDocument();
                configXml.LoadXml(config);
                XmlElement root = configXml.DocumentElement;
                foreach (XmlNode scriptItem in root.SelectNodes("actionScript"))
                {
                    try
                    {
                        CollectorActionScript script = new CollectorActionScript();
                        script.MPId = scriptItem.ReadXmlElementAttr("mpId", "");
                        script.IsErrorCorrectiveScript = scriptItem.ReadXmlElementAttr("correctiveErrorScript", false);
                        script.IsWarningCorrectiveScript = scriptItem.ReadXmlElementAttr("correctiveWarningScript", false);
                        script.IsRestorationScript = scriptItem.ReadXmlElementAttr("restorationScript", false);
                        XmlNode parametersNode = scriptItem.SelectSingleNode("parameters");
                        if (parametersNode != null)
                        {
                            script.Parameters = ScriptParameter.FromXml(parametersNode);
                        }
                        scripts.Add(script);
                    }
                    catch { }
                }
            }
            return scripts;
        }
    }
}
