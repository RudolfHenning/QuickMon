using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Directory Services Query Collector"), Category("Directory Services")]
    public class DirectoryServicesQueryCollector : CollectorAgentBase
    {
        public DirectoryServicesQueryCollector()
        {
            AgentConfig = new DirectoryServicesQueryCollectorConfig();
        }

        public override MonitorState RefreshState()
        {
            MonitorState returnState = new MonitorState();
            string lastAction = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;

            try
            {
                DirectoryServicesQueryCollectorConfig currentConfig = (DirectoryServicesQueryCollectorConfig)AgentConfig;
                returnState.RawDetails = string.Format("Running {0} queries", currentConfig.Entries.Count);
                returnState.HtmlDetails = string.Format("<b>Running {0} queries</b>", currentConfig.Entries.Count);
                foreach (DirectoryServicesQueryCollectorConfigEntry entry in currentConfig.Entries)
                {
                    CollectorState currentState = CollectorState.NotAvailable;
                    object output = "N/A";
                    try
                    {
                        lastAction = "Running query " + entry.Name;
                        output = entry.RunQuery();
                        lastAction = "Checking states of " + entry.Name;
                        currentState = entry.GetState(output);
                        lastAction = output.ToString();
                    }
                    catch (Exception wsException)
                    {
                        currentState = CollectorState.Error;
                        lastAction = wsException.Message;
                        output = wsException.Message;
                    }
                    if (output == null)
                        output = "N/A";
                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                ForAgent = entry.Name,
                                State = CollectorState.Error,
                                CurrentValue = output,
                                RawDetails = string.Format("'{0}' (Error)", output),
                                HtmlDetails = string.Format("'{0}' (<b>Error</b>)", output)
                            });
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                ForAgent = entry.Name,
                                State = CollectorState.Warning,
                                CurrentValue = output,
                                RawDetails = string.Format("'{0}' (Warning)", output),
                                HtmlDetails = string.Format("'{0}' (<b>Warning</b>)", output)
                            });
                    }
                    else
                    {
                        success++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                ForAgent = entry.Name,
                                State = CollectorState.Good,
                                CurrentValue = output,
                                RawDetails = string.Format("'{0}'", output),
                                HtmlDetails = string.Format("'{0}'", output)
                            });
                    }
                }
                //returnState.CurrentValue = pingTotalTime;

                if (errors > 0 && warnings == 0 && success == 0) // any errors
                    returnState.State = CollectorState.Error;
                else if (errors > 0 || warnings > 0) //any warnings
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;
            }
            catch (Exception ex)
            {
                returnState.RawDetails = ex.Message;
                returnState.HtmlDetails = string.Format("<p><b>Last action:</b> {0}</p><blockquote>{1}</blockquote>", lastAction, ex.Message);
                returnState.State = CollectorState.Error;
            }
            return returnState;
        }
        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            throw new NotImplementedException();
        }
    }

    public class DirectoryServicesQueryCollectorConfig : ICollectorConfig
    {
        public DirectoryServicesQueryCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement queryNode in root.SelectNodes("directoryServices/query"))
            {
                DirectoryServicesQueryCollectorConfigEntry dirSrvsQryEntry = new DirectoryServicesQueryCollectorConfigEntry();
                dirSrvsQryEntry.Name = queryNode.ReadXmlElementAttr("name", "");
                dirSrvsQryEntry.DomainController = queryNode.ReadXmlElementAttr("domainController", "");
                dirSrvsQryEntry.PropertiesToLoad = queryNode.ReadXmlElementAttr("propertiesToLoad", "sAMAccountName");
                dirSrvsQryEntry.UseRowCountAsValue = queryNode.ReadXmlElementAttr("useRowCountAsValue", false);
                dirSrvsQryEntry.MaxRowsToEvaluate = queryNode.ReadXmlElementAttr("maxRows", 1);
                dirSrvsQryEntry.ReturnCheckSequence = CollectorAgentReturnValueCompareEngine.CheckSequenceTypeFromString(queryNode.ReadXmlElementAttr("returnCheckSequence", "gwe"));
                XmlNode queryFilterNode = queryNode.SelectSingleNode("queryFilter");
                dirSrvsQryEntry.QueryFilterText = queryFilterNode.InnerText;
                XmlNode goodConditionNode = queryNode.SelectSingleNode("goodCondition");
                dirSrvsQryEntry.GoodResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(goodConditionNode.ReadXmlElementAttr("resultMatchType", "match"));
                dirSrvsQryEntry.GoodScriptText = goodConditionNode.InnerText;
                XmlNode warningConditionNode = queryNode.SelectSingleNode("warningCondition");
                dirSrvsQryEntry.WarningResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(warningConditionNode.ReadXmlElementAttr("resultMatchType", "match"));
                dirSrvsQryEntry.WarningScriptText = warningConditionNode.InnerText;
                XmlNode errorConditionNode = queryNode.SelectSingleNode("errorCondition");
                dirSrvsQryEntry.ErrorResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(errorConditionNode.ReadXmlElementAttr("resultMatchType", "match"));
                dirSrvsQryEntry.ErrorScriptText = errorConditionNode.InnerText;
                Entries.Add(dirSrvsQryEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;

            XmlNode directoryServicesNode = root.SelectSingleNode("directoryServices");
            directoryServicesNode.InnerXml = "";

            foreach (DirectoryServicesQueryCollectorConfigEntry dirSrvsQryEntry in Entries)
            {
                XmlElement queryNode = config.CreateElement("query");
                queryNode.SetAttributeValue("name", dirSrvsQryEntry.Name);
                queryNode.SetAttributeValue("domainController", dirSrvsQryEntry.DomainController);
                queryNode.SetAttributeValue("propertiesToLoad", dirSrvsQryEntry.PropertiesToLoad);
                queryNode.SetAttributeValue("useRowCountAsValue", dirSrvsQryEntry.UseRowCountAsValue);
                queryNode.SetAttributeValue("maxRows", dirSrvsQryEntry.MaxRowsToEvaluate);
                queryNode.SetAttributeValue("returnCheckSequence", dirSrvsQryEntry.ReturnCheckSequence.ToString());
                XmlNode queryFilterNode = queryNode.AppendElementWithText("queryFilter", dirSrvsQryEntry.QueryFilterText);
                XmlNode goodConditionNode = queryNode.AppendElementWithText("goodCondition", dirSrvsQryEntry.GoodScriptText);
                goodConditionNode.SetAttributeValue("resultMatchType", dirSrvsQryEntry.GoodResultMatchType.ToString());
                XmlNode warningConditionNode = queryNode.AppendElementWithText("warningCondition", dirSrvsQryEntry.WarningScriptText);
                warningConditionNode.SetAttributeValue("resultMatchType", dirSrvsQryEntry.WarningResultMatchType.ToString());
                XmlNode errorConditionNode = queryNode.AppendElementWithText("errorCondition", dirSrvsQryEntry.ErrorScriptText);
                errorConditionNode.SetAttributeValue("resultMatchType", dirSrvsQryEntry.ErrorResultMatchType.ToString());
                directoryServicesNode.AppendChild(queryNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>\n\r" +
                "	<directoryServices>\n\r" +
                "		<query name=\"\" domainController=\"\" propertiesToLoad=\"sAMAccountName\" useRowCountAsValue=\"false\" maxRows=\"1\" returnCheckSequence=\"gwe\">\n\r" +
                "			<queryFilter>(&amp;(objectCategory=person)(objectClass=user)(cn=BugsBunny))</queryFilter>\n\r" +
                "			<goodCondition resultMatchType=\"match\" />\n\r" +
                "			<warningCondition resultMatchType=\"match\" />\n\r" +
                "			<errorCondition resultMatchType=\"match\" />\n\r" +
                "		</query>\n\r" +
                "	</directoryServices>\n\r" +
                "</config>";
        }
        public string ConfigSummary
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }

    public class DirectoryServicesQueryCollectorConfigEntry : ICollectorConfigEntry
    {
        #region Properties
        public string Name { get; set; }
        public string DomainController { get; set; }
        public string QueryFilterText { get; set; }
        public string PropertiesToLoad { get; set; }
        public CollectorAgentReturnValueCheckSequence ReturnCheckSequence { get; set; }
        public bool UseRowCountAsValue { get; set; }
        public int MaxRowsToEvaluate { get; set; }
        public CollectorAgentReturnValueCompareMatchType GoodResultMatchType { get; set; }
        public string GoodScriptText { get; set; }
        public CollectorAgentReturnValueCompareMatchType WarningResultMatchType { get; set; }
        public string WarningScriptText { get; set; }
        public CollectorAgentReturnValueCompareMatchType ErrorResultMatchType { get; set; }
        public string ErrorScriptText { get; set; }
        #endregion

        #region ICollectorConfigEntry Members
        public string Description
        {
            get { return string.Format("Name:{0},Props:{1},Filter:{2}",Name, PropertiesToLoad, QueryFilterText); }
        }
        public string TriggerSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();                
                if (ReturnCheckSequence == CollectorAgentReturnValueCheckSequence.GWE)
                {
                    sb.Append("GWE:");
                    sb.Append("{" + GoodResultMatchType.ToString() + " : " + GoodScriptText + "}");
                    sb.Append("{" + WarningResultMatchType.ToString() + " : " + WarningScriptText + "}");
                    sb.Append("{" + ErrorResultMatchType.ToString() + " : " + ErrorScriptText + "}");
                }
                else
                {
                    sb.Append("EWG:");
                    sb.Append("{" + ErrorResultMatchType.ToString() + " : " + ErrorScriptText + "}");
                    sb.Append("{" + WarningResultMatchType.ToString() + " : " + WarningScriptText + "}");
                    sb.Append("{" + GoodResultMatchType.ToString() + " : " + GoodScriptText + "}");
                }
                if (UseRowCountAsValue)
                    sb.Append(",Use RowCount");
                return sb.ToString();
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion

        //For Collector testing purposes only the first MaxRowsToEvaluate number of returned records are used unless UseRowCountAsValue is true.
        public object RunQuery()
        {
            object returnValue = null;

            if (QueryFilterText == null || QueryFilterText.Trim().Length == 0)
                return null;
            string formattedFilterText = FormatQueryFilter(QueryFilterText);
            if (formattedFilterText.Contains("%"))
                formattedFilterText = MacroVariables.FormatVariables(formattedFilterText);

            DirectoryEntry entryRoot = GetADRoot();
            using (DirectorySearcher searcher = new DirectorySearcher(entryRoot, formattedFilterText))
            {
                List<string> propertiesToLoad = new List<string>();
                if (PropertiesToLoad == null || PropertiesToLoad.Trim().Length == 0)
                    propertiesToLoad.Add("sAMAccountName");
                else
                    foreach (string propName in PropertiesToLoad.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        propertiesToLoad.Add(propName.Trim());
                searcher.PropertiesToLoad.AddRange(propertiesToLoad.ToArray());
                searcher.SizeLimit = 1000;
                searcher.PageSize = 1000;
                SearchResultCollection matches = searcher.FindAll();
                if (UseRowCountAsValue)
                    returnValue = matches.Count;
                else
                {
                    StringBuilder lines = new StringBuilder();
                    int lineCount = 0;
                    foreach (SearchResult match in matches)
                    {
                        StringBuilder line = new StringBuilder();
                        foreach (string propName in propertiesToLoad)
                        {
                            string propertyValue = "";
                            try
                            {
                                if (match.Properties.Contains(propName))
                                {
                                    if (match.Properties[propName].Count > 0 && match.Properties[propName] != null)
                                    {
                                        propertyValue = match.Properties[propName][0].ToString();
                                    }
                                    else
                                        propertyValue = "N/A";
                                }
                                else
                                {
                                    propertyValue = "N/A";
                                }
                            }
                            catch
                            {
                                propertyValue = "err";
                            }
                            line.Append(propertyValue + ",");
                        }
                        lines.AppendLine(line.ToString().Trim(','));
                        lineCount++;
                        if (lineCount >= MaxRowsToEvaluate)
                            break;
                    }
                    returnValue = lines.ToString();
                }
            }

            return returnValue;
        }
        public CollectorState GetState(object value)
        {
            return CollectorAgentReturnValueCompareEngine.GetState(ReturnCheckSequence,
                GoodResultMatchType, GoodScriptText,
                WarningResultMatchType, WarningScriptText,
                ErrorResultMatchType, ErrorScriptText,
                value);
        }

        #region Directory services helper methods
        private DirectoryEntry GetADRoot()
        {
            DirectoryEntry entryRoot;
            try
            {
                if (DomainController != null && DomainController.Trim().Length > 0)
                {
                    entryRoot = new DirectoryEntry(string.Format("LDAP://{0}:389/RootDSE", DomainController));
                    string domain = entryRoot.Properties["defaultNamingContext"][0].ToString();
                    entryRoot = new DirectoryEntry("LDAP://" + domain);
                }
                else
                {
                    entryRoot = new DirectoryEntry("LDAP://RootDSE");
                    string domain = entryRoot.Properties["defaultNamingContext"][0].ToString();
                    entryRoot = new DirectoryEntry("LDAP://" + domain);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error trying to get AD domain root '{0}'", DomainController), ex);
            }
            return entryRoot;
        }
        #endregion

        private string FormatQueryFilter(string rawFilter)
        {
            if (rawFilter.Contains("\r\n"))
            {
                StringBuilder sb = new StringBuilder();
                string[] lines = rawFilter.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                    sb.Append(line.Trim(' ', '\t'));
                rawFilter = sb.ToString();
            }
            return rawFilter;
        }
    }
}
