using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class ConfigVariable
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Name + ":" + Value;
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml("<configVar name=\"\" value=\"\" />");
            XmlElement root = config.DocumentElement;
            root.SetAttributeValue("name", Name);
            root.SetAttributeValue("value", Value);
            return config.OuterXml;
        }
        public static ConfigVariable FromXml(string xmlStr)
        {
            ConfigVariable newConfigVariable = new ConfigVariable();
            XmlDocument config = new XmlDocument();
            config.LoadXml(xmlStr);
            XmlElement root = config.DocumentElement;            
            newConfigVariable.Name = root.ReadXmlElementAttr("name", "");
            newConfigVariable.Value = root.ReadXmlElementAttr("value", "");
            return newConfigVariable;
        }
        public ConfigVariable Clone()
        {
            return FromXml(ToXml());
        }
    }
}
