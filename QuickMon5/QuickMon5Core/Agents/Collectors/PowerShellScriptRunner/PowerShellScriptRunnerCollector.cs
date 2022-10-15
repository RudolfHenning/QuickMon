using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Xml;
using QuickMon.Utils;

namespace QuickMon.Collectors
{
    [Description("PowerShell Script Runner Collector"), Category("General")]
    public class PowerShellScriptRunnerCollector : CollectorAgentBase
    {
        public PowerShellScriptRunnerCollector()
        {
            AgentConfig = new PowerShellScriptRunnerCollectorConfig();
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
                entry.PrimaryUIValue = carvceEntryNode.ReadXmlElementAttr("primaryUIValue", false);
                entry.OutputValueUnit  = carvceEntryNode.ReadXmlElementAttr("outputValueUnit", "");
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
                carvceEntryNode.SetAttributeValue("primaryUIValue", queryEntry.PrimaryUIValue);
                carvceEntryNode.SetAttributeValue("outputValueUnit", queryEntry.OutputValueUnit);
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
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><carvcesEntries><carvceEntry name=\"\"><dataSource></dataSource>" +
                "<testConditions testSequence=\"GWE\">" +
                "<success testType=\"match\"></success>" +
                "<warning testType=\"match\"></warning>" +
                "<error testType=\"match\"></error>" +
                "</testConditions></carvceEntry></carvcesEntries></config>";
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
        public PowerShellScriptRunnerEntry()
        {
            Name = "";
            OutputValueUnit = "";
        }
        #region Properties
        public string Name { get; set; }
        public string OutputValueUnit { get; set; }
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
        public MonitorState GetCurrentState()
        {
            MonitorState currentState = new MonitorState()
            {
                ForAgent = Description
            };
            try
            {
                string scriptResultText = RunScript();
                if (scriptResultText.Contains("System.Management.Automation.CommandNotFoundException"))
                {
                    currentState.State = CollectorState.Error;
                    currentState.CurrentValue = "Bad command(s)";
                    currentState.CurrentValueUnit = "";
                    CurrentAgentValue = "Bad command(s)";
                    currentState.RawDetails = scriptResultText;
                }
                else if (scriptResultText.Contains("The remote server returned an error: (401) Unauthorized"))
                {
                    currentState.State = CollectorState.Error;
                    currentState.CurrentValue = "Unauthorized";
                    currentState.CurrentValueUnit = "";
                    CurrentAgentValue = "Unauthorized";
                    currentState.RawDetails = scriptResultText;
                }
                else
                {
                    CurrentAgentValue = scriptResultText;
                    currentState.CurrentValue = scriptResultText;
                    currentState.CurrentValueUnit = OutputValueUnit;
                    CollectorState currentScriptState = CollectorAgentReturnValueCompareEngine.GetState(ReturnCheckSequence,
                       GoodResultMatchType, GoodScriptText,
                       WarningResultMatchType, WarningScriptText,
                       ErrorResultMatchType, ErrorScriptText,
                       scriptResultText);
                    currentState.State = currentScriptState;
                }
            }
            catch (Exception ex)
            {
                currentState.State = CollectorState.Error;
                currentState.CurrentValue = "Unknown error";
                currentState.CurrentValueUnit = "";
                currentState.RawDetails = ex.Message;                
            }

            return currentState;
        }
        public string Description
        {
            get { return Name; }
        }
        public string TriggerSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ReturnCheckSequence.ToString() + ": ");
                sb.Append("{G:" + GoodResultMatchType.ToString() + ": " + GoodScriptText + "}");
                sb.Append("{W:" + WarningResultMatchType.ToString() + ": " + WarningScriptText + "}");
                sb.Append("{E:" + ErrorResultMatchType.ToString() + ": " + ErrorScriptText + "}");
                
                return sb.ToString();
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }
        #endregion

        private static string lockObject = "";

        public string RunScript()
        {
            if (TestScript.StartsWith("#UseExitCode"))
                return RunScriptWithExitCode(TestScript);
            else 
                return RunScript(TestScript);
        }
        public static string RunScript(string testScript)
        {
            string output = "";
            string errorLogged = "";
            try
            {
                Collection<PSObject> results = null;
                // create Powershell runspace
                using (Runspace runspace = RunspaceFactory.CreateRunspace())
                {

                    // open it
                    runspace.Open();
                    runspace.StateChanged += Runspace_StateChanged;
                    // create a pipeline and feed it the script text

                    using (Pipeline pipeline = runspace.CreatePipeline())
                    {
                        pipeline.Commands.AddScript(testScript);
                        pipeline.Commands.Add("Out-String");

                        // execute the script
                        lock (lockObject)
                        {
                            results = pipeline.Invoke();
                        }
                        if (pipeline.HadErrors)
                        {
                            PipelineReader<object> errs = pipeline.Error;
                            if (errs != null)
                            {
                                if (errs.Count > 0)
                                {
                                    for (int i = 0; i < errs.Count; i++)
                                    {
                                        errorLogged += errs.Read().ToString() + "\r\n";
                                    }
                                    System.Diagnostics.Trace.WriteLine($"Error: {errs.Read()}");
                                }
                                errs.Close();
                                errs = null;
                            }
                        }
                    }                

                    // close the runspace
                    runspace.Close();
                }

                // convert the script result into a single string
                StringBuilder stringBuilder = new StringBuilder();
                if (results != null)
                {
                    foreach (PSObject obj in results)
                    {
                        if (obj != null)
                            stringBuilder.AppendLine(obj.ToString());
                        else
                            stringBuilder.AppendLine("[null]");
                    }                    
                }
                else
                {
                    stringBuilder.AppendLine("[null]");
                }
                if (errorLogged.Length > 0)
                {
                    stringBuilder.AppendLine($"Exception(s):{errorLogged}");
                }
                output = stringBuilder.ToString();

                //cleanups
                if (results != null)
                    results.Clear();
                results = null;
                stringBuilder = null;
            }
            catch (Exception ex)
            {
#if DEBUG
                output = $"Exception: {ex.ToString()}";
                //output = $"Exception: {ex.GetMessageStack()}";
#else
                output = $"Exception: {ex.GetMessageStack()}";
#endif
            }
            return output.Trim('\r', '\n');
        }
        public static string RunScriptWithExitCode(string testScript)
        {
            string output = "";
            string errorLogged = "";
            try
            {
                //in order to ensure there is an exit code wrap it inside a PowerShell {} block

                testScript = "PowerShell {\r\n" + testScript + "\r\n}";

                Collection<PSObject> results = null;
                Collection<PSObject> exitCodeResults = null;
                // create Powershell runspace
                using (Runspace runspace = RunspaceFactory.CreateRunspace())
                {
                    // open it
                    runspace.Open();
                    runspace.StateChanged += Runspace_StateChanged;
                    // create a pipeline and feed it the script text

                    using (Pipeline pipeline = runspace.CreatePipeline())
                    {
                        pipeline.Commands.AddScript(testScript);
                        pipeline.Commands.Add("Out-String");

                        // execute the script
                        lock (lockObject)
                        {
                            results = pipeline.Invoke();
                        }

                        if (pipeline.HadErrors)
                        {
                            PipelineReader<object> errs = pipeline.Error;
                            if (errs.Count > 0)
                            {
                                for (int i = 0; i < errs.Count; i++)
                                {
                                    errorLogged += errs.Read().ToString() + "\r\n";
                                }
                                System.Diagnostics.Trace.WriteLine($"Error: {errs.Read()}");
                            }
                        }
                    }
                    using (Pipeline pipeline = runspace.CreatePipeline())
                    {
                        pipeline.Commands.AddScript("$LASTEXITCODE");
                        pipeline.Commands.Add("Out-String");
                        // execute the script
                        lock (lockObject)
                        {
                            exitCodeResults = pipeline.Invoke();
                        }
                    }

                    // close the runspace
                    runspace.Close();
                }

                // convert the script result into a single string
                StringBuilder stringBuilder = new StringBuilder();

                if (results != null)
                {
                    foreach (PSObject obj in results)
                    {
                        if (obj != null)
                            stringBuilder.AppendLine(obj.ToString());
                        else
                            stringBuilder.AppendLine("[null]");
                    }
                }
                else
                {
                    stringBuilder.AppendLine("[null]");
                }
                if (errorLogged.Length > 0)
                {
                    stringBuilder.AppendLine($"Exception(s):{errorLogged}");
                }

                if (exitCodeResults != null)
                {
                    foreach (PSObject obj in exitCodeResults)
                    {
                        if (obj != null && obj.ToString() != "")
                        {
                            stringBuilder.AppendLine($"Exit code : {obj}");
                            System.Diagnostics.Trace.WriteLine($"Exit code : {obj}");
                        }
                    }
                }
                else
                {
                    stringBuilder.AppendLine($"Exit code : 0");
                }

                output = stringBuilder.ToString();

                //cleanups
                if (results != null)
                    results.Clear();
                results = null;
                if (exitCodeResults != null)
                    exitCodeResults.Clear();
                exitCodeResults = null;
                stringBuilder = null;
            }
            catch (Exception ex)
            {
#if DEBUG
                output = $"Exception: {ex.ToString()}";
                //output = $"Exception: {ex.GetMessageStack()}";
#else
                output = $"Exception: {ex.GetMessageStack()}";
#endif
            }
            return output.Trim('\r', '\n');
        }

        private static void Runspace_StateChanged(object sender, RunspaceStateEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine($"Sender: {sender}");
            System.Diagnostics.Trace.WriteLine($"State: {e.RunspaceStateInfo.State}");
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
