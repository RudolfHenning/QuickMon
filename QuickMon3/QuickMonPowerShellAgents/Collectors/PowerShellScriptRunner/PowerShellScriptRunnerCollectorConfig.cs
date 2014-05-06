using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    public class PowerShellScriptRunnerCollectorConfig : ICollectorConfig
    {
        public PowerShellScriptRunnerCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }
        
        #region ICollectorConfig Members
        public List<ICollectorConfigEntry> Entries { get; set; }
        public ConfigEntryType ConfigEntryType { get { return QuickMon.ConfigEntryType.Multiple; } }
        public bool CanEdit { get { return true; } }
        #endregion        

        #region IAgentConfig Members
        public void ReadConfiguration(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            Entries.Clear();
            XmlElement root = config.DocumentElement;
            foreach (XmlElement powerShellScriptRunnerNode in root.SelectNodes("powerShellScripts/powerShellScriptRunner"))
            {
                PowerShellScriptRunnerEntry entry = new PowerShellScriptRunnerEntry();
                entry.Name = powerShellScriptRunnerNode.ReadXmlElementAttr("name", "");
                entry.ReturnCheckSequence = ReturnCheckSequenceTypeConverter.FromString(powerShellScriptRunnerNode.ReadXmlElementAttr("returnCheckSequence", "GWE"));

                XmlNode testScriptNode = powerShellScriptRunnerNode.SelectSingleNode("testScript");
                entry.TestScript = testScriptNode.InnerText;

                XmlNode goodScriptNode = powerShellScriptRunnerNode.SelectSingleNode("goodScript");
                entry.GoodResultMatchType = TextCompareMatchTypeConverter.FromString(goodScriptNode.ReadXmlElementAttr("resultMatchType", "match"));
                entry.GoodScriptText = goodScriptNode.InnerText;

                XmlNode warningScriptNode = powerShellScriptRunnerNode.SelectSingleNode("warningScript");
                entry.WarningResultMatchType = TextCompareMatchTypeConverter.FromString(warningScriptNode.ReadXmlElementAttr("resultMatchType", "match"));
                entry.WarningScriptText = warningScriptNode.InnerText;

                XmlNode errorScriptNode = powerShellScriptRunnerNode.SelectSingleNode("errorScript");
                entry.ErrorResultMatchType = TextCompareMatchTypeConverter.FromString(errorScriptNode.ReadXmlElementAttr("resultMatchType", "match"));
                entry.ErrorScriptText = errorScriptNode.InnerText;

                Entries.Add(entry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.PowerShellScriptRunnerDefaultConfig);
            XmlElement root = config.DocumentElement;

            XmlNode powerShellScriptsNode = root.SelectSingleNode("powerShellScripts");
            powerShellScriptsNode.InnerXml = "";

            foreach (PowerShellScriptRunnerEntry queryEntry in Entries)
            {
                XmlElement powerShellScriptNode = config.CreateElement("powerShellScriptRunner");
                powerShellScriptNode.SetAttributeValue("name", queryEntry.Name);
                powerShellScriptNode.SetAttributeValue("returnCheckSequence", queryEntry.ReturnCheckSequence.ToString());
                XmlNode testScriptNode = powerShellScriptNode.AppendElementWithText("testScript", queryEntry.TestScript);
                XmlNode goodScriptNode = powerShellScriptNode.AppendElementWithText("goodScript", queryEntry.GoodScriptText);
                goodScriptNode.SetAttributeValue("resultMatchType", queryEntry.GoodResultMatchType.ToString());
                XmlNode warningScriptNode = powerShellScriptNode.AppendElementWithText("warningScript", queryEntry.WarningScriptText);
                warningScriptNode.SetAttributeValue("resultMatchType", queryEntry.WarningResultMatchType.ToString());
                XmlNode errorScriptNode = powerShellScriptNode.AppendElementWithText("errorScript", queryEntry.ErrorScriptText);
                errorScriptNode.SetAttributeValue("resultMatchType", queryEntry.ErrorResultMatchType.ToString());
                powerShellScriptsNode.AppendChild(powerShellScriptNode);
            }
            return config.OuterXml;
        }
        #endregion
    }
}

