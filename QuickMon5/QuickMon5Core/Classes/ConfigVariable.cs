using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class ConfigVariable
    {
        public string FindValue { get; set; }
        public string DislayValue
        {
            get
            {
                if (FindValue != null && FindValue.Length > 0)
                {
                    return FindValue.Trim('[', ']').TrimStart('!');
                }
                else
                    return "";
            }
        }
        public string ReplaceValue { get; set; }
        public bool Important { get; set; }

        public override string ToString()
        {
            return string.Format("(f:{0})(r:{1}){2}", FindValue, ReplaceValue, Important ? "!" : "");
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml("<configVar><find/><replace/></configVar>");

            //config.LoadXml("<configVar find=\"\" replace=\"\" />");
            XmlElement root = config.DocumentElement;
            XmlNode findNode = root.SelectSingleNode("find");
            XmlNode replaceNode = root.SelectSingleNode("replace");
            findNode.SetAttributeValue("important", Important);
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
                bool important = findNode.ReadXmlElementAttr("important", false);
                newConfigVariable.Important = important;
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
            string appliedConfig = configStr;
            if (appliedConfig == null)
                appliedConfig = "";

            if (appliedConfig.IndexOf("%LocalHost%", StringComparison.CurrentCultureIgnoreCase) > -1)
                appliedConfig = appliedConfig.ReplaceCaseInsensitive("%LocalHost%", System.Net.Dns.GetHostName());
            if (appliedConfig.IndexOf("%CurrentDate%", StringComparison.CurrentCultureIgnoreCase) > -1)
                appliedConfig = appliedConfig.ReplaceCaseInsensitive("%CurrentDate%", DateTime.Now.ToShortDateString());
            if (appliedConfig.IndexOf("%CurrentTime%", StringComparison.CurrentCultureIgnoreCase) > -1)
                appliedConfig = appliedConfig.ReplaceCaseInsensitive("%CurrentTime%", DateTime.Now.ToLongTimeString());

            if (FindValue.Length > 0 && appliedConfig.IndexOf(FindValue, StringComparison.CurrentCultureIgnoreCase) > -1)
                return appliedConfig.ReplaceCaseInsensitive(FindValue, ReplaceValue);
            else
                return appliedConfig;
        }
    }
    public static class ConfigVariables
    {
        public static string ApplyOn(this List<ConfigVariable> configVars, string configStr)
        {
            string appliedConfig = configStr;

            List<ConfigVariable> uniqueConfigVars = new List<ConfigVariable>();

            if (configVars == null)
            {
                configVars = new List<ConfigVariable>();
            }
            foreach (ConfigVariable cv in configVars)
            {
                ConfigVariable existingCV = (from ConfigVariable c in uniqueConfigVars
                                             where c.FindValue == cv.FindValue
                                             select c).FirstOrDefault();
                if (existingCV == null)
                {
                    uniqueConfigVars.Add(cv.Clone());
                }
            }
            if (uniqueConfigVars.Count == 0) //adds dummy entry so internal vars also get applied
            {
                uniqueConfigVars.Add(new ConfigVariable() { FindValue = DateTime.Now.Millisecond.ToString(), ReplaceValue = DateTime.Now.Millisecond.ToString() });
            }
            foreach (ConfigVariable cv in uniqueConfigVars)
                appliedConfig = cv.ApplyOn(appliedConfig);

            //if (configVars != null)
            //{
            //    if (configVars.Count == 0) //adds dummy entry so internal vars also get applied
            //    {
            //        configVars.Add(new ConfigVariable() { FindValue = DateTime.Now.Millisecond.ToString(), ReplaceValue = DateTime.Now.Millisecond.ToString() });
            //    }
            //    foreach (ConfigVariable cv in configVars)
            //        appliedConfig = cv.ApplyOn(appliedConfig);
            //}
            //if (appliedConfig.IndexOf("%LocalHost%", StringComparison.CurrentCultureIgnoreCase) > -1)
            //    appliedConfig = appliedConfig.Replace("%LocalHost%", System.Net.Dns.GetHostName());
            return appliedConfig;
        }
    }
}
