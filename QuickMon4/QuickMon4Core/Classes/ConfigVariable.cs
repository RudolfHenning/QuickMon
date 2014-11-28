using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class ConfigVariable
    {
        public string FindValue { get; set; }
        public string ReplaceValue { get; set; }

        public override string ToString()
        {
            return string.Format("(f:{0})(r:{1})", FindValue, ReplaceValue);
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml("<configVar find=\"\" replace=\"\" />");
            XmlElement root = config.DocumentElement;
            root.SetAttributeValue("find", FindValue);
            root.SetAttributeValue("replace", ReplaceValue);
            return config.OuterXml;
        }
        public static ConfigVariable FromXml(string xmlStr)
        {
            ConfigVariable newConfigVariable = new ConfigVariable();
            XmlDocument config = new XmlDocument();
            config.LoadXml(xmlStr);
            XmlElement root = config.DocumentElement;
            newConfigVariable.FindValue = root.ReadXmlElementAttr("find", "");
            newConfigVariable.ReplaceValue = root.ReadXmlElementAttr("replace", "");
            return newConfigVariable;
        }
        public ConfigVariable Clone()
        {
            return FromXml(ToXml());
        }
        public string ApplyOn(string configStr)
        {
            if (FindValue.Length > 0 && configStr.IndexOf(FindValue) > -1)
                return configStr.Replace(FindValue, ReplaceValue);
            else
                return configStr;
        }
    }
}
