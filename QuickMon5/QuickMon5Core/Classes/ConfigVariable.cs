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
            config.LoadXml("<configVar><find/><replace/></configVar>");

            //config.LoadXml("<configVar find=\"\" replace=\"\" />");
            XmlElement root = config.DocumentElement;
            XmlNode findNode = root.SelectSingleNode("find");
            XmlNode replaceNode = root.SelectSingleNode("replace");
            findNode.InnerText = FindValue;
            replaceNode.InnerText = ReplaceValue;
            //root.SetAttributeValue("find", FindValue);
            //root.SetAttributeValue("replace", ReplaceValue);
            return config.OuterXml;
        }
        public static ConfigVariable FromXml(XmlNode configVarNode)
        {
            ConfigVariable newConfigVariable = new ConfigVariable();
            XmlNode findNode = configVarNode.SelectSingleNode("find");
            XmlNode replaceNode = configVarNode.SelectSingleNode("replace");
            if (findNode == null || replaceNode == null)
            {
                newConfigVariable.FindValue = configVarNode.ReadXmlElementAttr("find", "");
                newConfigVariable.ReplaceValue = configVarNode.ReadXmlElementAttr("replace", "");
            }
            else
            {
                newConfigVariable.FindValue = findNode.InnerText;
                newConfigVariable.ReplaceValue = replaceNode.InnerText;
            }
            return newConfigVariable;
        }
        public static ConfigVariable FromXml(string xmlStr)
        {
            ConfigVariable newConfigVariable = new ConfigVariable();
            XmlDocument config = new XmlDocument();
            config.LoadXml(xmlStr);
            newConfigVariable = FromXml(config.DocumentElement);
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
    public static class ConfigVariables
    {
        public static string ApplyOn(this List<ConfigVariable> configVars, string configStr)
        {
            string appliedConfig = configStr;
            if (configVars != null)
                foreach (ConfigVariable cv in configVars)
                    appliedConfig = cv.ApplyOn(appliedConfig);
            if (appliedConfig.IndexOf("%LocalHost%", StringComparison.CurrentCultureIgnoreCase) > -1)
                appliedConfig = appliedConfig.Replace("%LocalHost%", System.Net.Dns.GetHostName());
            return appliedConfig;
        }
    }
}
