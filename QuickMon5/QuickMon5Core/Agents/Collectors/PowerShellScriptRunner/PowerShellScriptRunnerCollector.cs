using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("PowerShell Script Runner Collector"), Category("PowerShell")]
    public class PowerShellScriptRunnerCollector : CollectorAgentBase
    {
        public PowerShellScriptRunnerCollector()
        {
            AgentConfig = new PowerShellScriptRunnerCollectorConfig();
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
                PowerShellScriptRunnerCollectorConfig currentConfig = (PowerShellScriptRunnerCollectorConfig)AgentConfig;
                foreach (PowerShellScriptRunnerEntry entry in currentConfig.Entries)
                {
                    CollectorState currentState = CollectorState.NotAvailable;
                    string output = "N/A";
                    try
                    {
                        lastAction = "Running PowerShell script " + entry.Description;
                        output = entry.RunScript();
                        lastAction = "Checking states of " + entry.Description;
                        currentState = entry.GetState(output);
                        lastAction = output;
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
                                ForAgent = entry.Description,
                                State = CollectorState.Error,
                                CurrentValue = output//,
                                //RawDetails = string.Format("'{0}' (Error)", output),
                                //HtmlDetails = string.Format("'{0}' (<b>Error</b>)", output)
                            });
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                ForAgent = entry.Description,
                                State = CollectorState.Warning,
                                CurrentValue = output//,
                                //RawDetails = string.Format("'{0}' (Warning)", output),
                                //HtmlDetails = string.Format("'{0}' (<b>Warning</b>)", output)
                            });
                    }
                    else
                    {
                        success++;
                        returnState.ChildStates.Add(
                            new MonitorState()
                            {
                                ForAgent = entry.Description,
                                State = CollectorState.Good,
                                CurrentValue = output//,
                                //RawDetails = string.Format("'{0}'", output),
                                //HtmlDetails = string.Format("'{0}'", output)
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
            List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                dt.Columns.Add(new System.Data.DataColumn("Script name", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Response", typeof(string)));

                PowerShellScriptRunnerCollectorConfig currentConfig = (PowerShellScriptRunnerCollectorConfig)AgentConfig;
                foreach (PowerShellScriptRunnerEntry entry in currentConfig.Entries)
                {
                    string output = "N/A";
                    try
                    {
                        output = entry.RunScript();
                    }
                    catch (Exception ex)
                    {
                        output = ex.Message;
                    }
                    dt.Rows.Add(entry.Name, output);
                }
            }
            catch (Exception ex)
            {
                dt = new System.Data.DataTable("Exception");
                dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
                dt.Rows.Add(ex.ToString());
            }
            tables.Add(dt);
            return tables;
        }
    }

    public class PowerShellScriptRunnerCollectorConfig : ICollectorConfig
    {
        public PowerShellScriptRunnerCollectorConfig()
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
            Entries.Clear();
            XmlElement root = config.DocumentElement;
            //Old format
            foreach (XmlElement powerShellScriptRunnerNode in root.SelectNodes("powerShellScripts/powerShellScriptRunner"))
            {
                PowerShellScriptRunnerEntry entry = new PowerShellScriptRunnerEntry();
                entry.Name = powerShellScriptRunnerNode.ReadXmlElementAttr("name", "");
                entry.ReturnCheckSequence = CollectorAgentReturnValueCompareEngine.CheckSequenceTypeFromString(powerShellScriptRunnerNode.ReadXmlElementAttr("returnCheckSequence", "gwe"));
                XmlNode testScriptNode = powerShellScriptRunnerNode.SelectSingleNode("testScript");
                entry.TestScript = testScriptNode.InnerText;

                XmlNode goodScriptNode = powerShellScriptRunnerNode.SelectSingleNode("goodScript");
                entry.GoodResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(goodScriptNode.ReadXmlElementAttr("resultMatchType", "match"));
                entry.GoodScriptText = goodScriptNode.InnerText;

                XmlNode warningScriptNode = powerShellScriptRunnerNode.SelectSingleNode("warningScript");
                entry.WarningResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(warningScriptNode.ReadXmlElementAttr("resultMatchType", "match"));
                entry.WarningScriptText = warningScriptNode.InnerText;

                XmlNode errorScriptNode = powerShellScriptRunnerNode.SelectSingleNode("errorScript");
                entry.ErrorResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(errorScriptNode.ReadXmlElementAttr("resultMatchType", "match"));
                entry.ErrorScriptText = errorScriptNode.InnerText;

                Entries.Add(entry);
            }
            //New format
            foreach (XmlElement carvceEntryNode in root.SelectNodes("carvcesEntries/carvceEntry"))
            {
                PowerShellScriptRunnerEntry entry = new PowerShellScriptRunnerEntry();
                entry.Name = carvceEntryNode.ReadXmlElementAttr("name", "");
                XmlNode testScriptNode = carvceEntryNode.SelectSingleNode("dataSource");
                entry.TestScript = testScriptNode.InnerText;

                XmlNode testConditionsNode = carvceEntryNode.SelectSingleNode("testConditions");
                entry.ReturnCheckSequence = CollectorAgentReturnValueCompareEngine.CheckSequenceTypeFromString(testConditionsNode.ReadXmlElementAttr("testSequence", "gwe"));

                XmlNode goodScriptNode = testConditionsNode.SelectSingleNode("success");
                entry.GoodResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(goodScriptNode.ReadXmlElementAttr("testType", "match"));
                entry.GoodScriptText = goodScriptNode.InnerText;

                XmlNode warningScriptNode = testConditionsNode.SelectSingleNode("warning");
                entry.WarningResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(warningScriptNode.ReadXmlElementAttr("testType", "match"));
                entry.WarningScriptText = warningScriptNode.InnerText;

                XmlNode errorScriptNode = testConditionsNode.SelectSingleNode("error");
                entry.ErrorResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(errorScriptNode.ReadXmlElementAttr("testType", "match"));
                entry.ErrorScriptText = errorScriptNode.InnerText;

                Entries.Add(entry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;

            XmlNode carvcesEntriesNode = root.SelectSingleNode("carvcesEntries");
            carvcesEntriesNode.InnerXml = "";
            foreach (PowerShellScriptRunnerEntry queryEntry in Entries)
            {
                XmlElement carvceEntryNode = config.CreateElement("carvceEntry");
                carvceEntryNode.SetAttributeValue("name", queryEntry.Name);
                XmlElement dataSourceNode = config.CreateElement("dataSource");
                dataSourceNode.InnerText = queryEntry.TestScript;
                XmlElement testConditionsNode = config.CreateElement("testConditions");
                testConditionsNode.SetAttributeValue("testSequence", queryEntry.ReturnCheckSequence.ToString());
                XmlElement successNode = config.CreateElement("success");
                successNode.SetAttributeValue("testType", queryEntry.GoodResultMatchType.ToString());
                successNode.InnerText = queryEntry.GoodScriptText;
                XmlElement warningNode = config.CreateElement("warning");
                warningNode.SetAttributeValue("testType", queryEntry.WarningResultMatchType.ToString());
                warningNode.InnerText = queryEntry.WarningScriptText;
                XmlElement errorNode = config.CreateElement("error");
                errorNode.SetAttributeValue("testType", queryEntry.ErrorResultMatchType.ToString());
                errorNode.InnerText = queryEntry.ErrorScriptText;

                testConditionsNode.AppendChild(successNode);
                testConditionsNode.AppendChild(warningNode);
                testConditionsNode.AppendChild(errorNode);

                carvceEntryNode.AppendChild(dataSourceNode);
                carvceEntryNode.AppendChild(testConditionsNode);
                carvcesEntriesNode.AppendChild(carvceEntryNode);
            }

            //XmlNode powerShellScriptsNode = root.SelectSingleNode("powerShellScripts");
            //powerShellScriptsNode.InnerXml = "";

            //foreach (PowerShellScriptRunnerEntry queryEntry in Entries)
            //{
            //    XmlElement powerShellScriptNode = config.CreateElement("powerShellScriptRunner");
            //    powerShellScriptNode.SetAttributeValue("name", queryEntry.Name);
            //    powerShellScriptNode.SetAttributeValue("returnCheckSequence", queryEntry.ReturnCheckSequence.ToString());
            //    XmlNode testScriptNode = powerShellScriptNode.AppendElementWithText("testScript", queryEntry.TestScript);
            //    XmlNode goodScriptNode = powerShellScriptNode.AppendElementWithText("goodScript", queryEntry.GoodScriptText);
            //    goodScriptNode.SetAttributeValue("resultMatchType", queryEntry.GoodResultMatchType.ToString());
            //    XmlNode warningScriptNode = powerShellScriptNode.AppendElementWithText("warningScript", queryEntry.WarningScriptText);
            //    warningScriptNode.SetAttributeValue("resultMatchType", queryEntry.WarningResultMatchType.ToString());
            //    XmlNode errorScriptNode = powerShellScriptNode.AppendElementWithText("errorScript", queryEntry.ErrorScriptText);
            //    errorScriptNode.SetAttributeValue("resultMatchType", queryEntry.ErrorResultMatchType.ToString());
            //    powerShellScriptsNode.AppendChild(powerShellScriptNode);
            //}
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>" +
                "  <carvcesEntries>" +
                "    <carvceEntry name=\"\">" +
                "      <dataSource></dataSource>" +
                "      <testCondition testSequence=\"GWE\">" +
                "        <success testType=\"match\"></success>" +
                "        <warning testType=\"match\"></warning>" +
                "        <error testType=\"match\"></error>" +
                "      </testCondition>" +
                "    </carvceEntry>" +
                "  </carvcesEntries>" +
                "</config>";

            /*
                "<config>" +
                "<powerShellScripts>" +
                    "<powerShellScriptRunner name=\"\" returnCheckSequence=\"GWE\">" +
                        "<testScript></testScript>" +
                        "<goodScript resultMatchType=\"match|contains|regex\"></goodScript>" +
                        "<warningScript resultMatchType=\"match|contains|regex\"></warningScript>" +
                        "<errorScript resultMatchType=\"match|contains|regex\"></errorScript>" +
                    "</powerShellScriptRunner>" +
                "</powerShellScripts>" +
            "</config>";
            */
        }
        public string ConfigSummary
        {
            get {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("{0} entry(s): ", Entries.Count));
                if (Entries.Count == 0)
                    sb.Append("None");
                else
                {
                    foreach (ICollectorConfigEntry entry in Entries)
                    {
                        sb.Append(entry.Description + ", ");
                    }
                }
                return sb.ToString().TrimEnd(' ', ',');            
            }
        }
        #endregion
    }

    public class PowerShellScriptRunnerEntry : ICollectorConfigEntry
    {
        #region Properties
        public string Name { get; set; }
        public CollectorAgentReturnValueCheckSequence ReturnCheckSequence { get; set; }
        public string TestScript { get; set; }
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
            get { return Name; }
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
                return sb.ToString();
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion

        public string RunScript()
        {
            return RunScript(TestScript);
        }
        public static string RunScript(string testScript)
        {
            string output = "";
            try
            {
                // create Powershell runspace
                Runspace runspace = RunspaceFactory.CreateRunspace();

                // open it
                runspace.Open();
                // create a pipeline and feed it the script text

                Pipeline pipeline = runspace.CreatePipeline();
                pipeline.Commands.AddScript(testScript);

                // add an extra command to transform the script
                // output objects into nicely formatted strings

                // remove this line to get the actual objects
                // that the script returns. For example, the script

                // "Get-Process" returns a collection
                // of System.Diagnostics.Process instances.

                pipeline.Commands.Add("Out-String");

                // execute the script

                Collection<PSObject> results = pipeline.Invoke();

                // close the runspace

                runspace.Close();
                runspace = null;

                // convert the script result into a single string
                StringBuilder stringBuilder = new StringBuilder();
                foreach (PSObject obj in results)
                {
                    if (obj != null)
                        stringBuilder.AppendLine(obj.ToString());
                    else
                        stringBuilder.AppendLine("[null]");
                }
                output = stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                output = ex.ToString();
            }
            return output.Trim('\r', '\n');
        }
        public CollectorState GetState(string scriptResultText)
        {
            return CollectorAgentReturnValueCompareEngine.GetState(ReturnCheckSequence,
               GoodResultMatchType, GoodScriptText,
               WarningResultMatchType, WarningScriptText,
               ErrorResultMatchType, ErrorScriptText,
               scriptResultText);
        }
    }
}
