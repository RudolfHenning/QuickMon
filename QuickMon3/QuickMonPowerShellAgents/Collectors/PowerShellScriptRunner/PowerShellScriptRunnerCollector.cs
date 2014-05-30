using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.Collectors
{
    [Description("PowerShell Script Runner Collector"), Category("PowerShell")]
    public class PowerShellScriptRunnerCollector : CollectorBase
    {
        public PowerShellScriptRunnerCollector()
        {
            AgentConfig = new PowerShellScriptRunnerCollectorConfig();
        }
        public override MonitorState GetState()
        {
            MonitorState returnState = new MonitorState();
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            string lastAction = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;
            try
            {
                PowerShellScriptRunnerCollectorConfig psScriptConfig = (PowerShellScriptRunnerCollectorConfig)AgentConfig;
                plainTextDetails.AppendLine(string.Format("Running {0} PowerShell scripts", psScriptConfig.Entries.Count));
                htmlTextTextDetails.AppendLine(string.Format("<i>Running {0} PowerShell scripts'</i>", psScriptConfig.Entries.Count));
                htmlTextTextDetails.AppendLine("<ul>");
                StringBuilder sbTotalResults = new StringBuilder();

                foreach (PowerShellScriptRunnerEntry pssrEntry in psScriptConfig.Entries)
                {
                    lastAction = string.Format("Running PowerShell script for {0} - ", pssrEntry.Name);
                    sbTotalResults.AppendLine(pssrEntry.Name);
                    plainTextDetails.Append(string.Format("\t{0} - ", pssrEntry.Name));
                    htmlTextTextDetails.Append(string.Format("<li>{0} - ", pssrEntry.Name));

                    string scriptResult = pssrEntry.RunScript();
                    CollectorState currentState = pssrEntry.GetState(scriptResult);
                    if (currentState == CollectorState.Error)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("\t\tScript '{0}' - Error\r\n\t\t Result: '{1}'", pssrEntry.Name, FormatUtils.N(scriptResult, "[null]")));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Script '{0}' - <b>Error</b><br>Result: <blockquote>{1}</blockquote></li>", pssrEntry.Name, FormatUtils.N(scriptResult, "[null]")));
                    }
                    else if (currentState == CollectorState.Warning)
                    {
                        warnings++;
                        plainTextDetails.AppendLine(string.Format("\t\tScript '{0}' - Warning\r\n\t\t Result: '{1}'", pssrEntry.Name, FormatUtils.N(scriptResult, "[null]")));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Script '{0}' - <b>Warning</b><br>Result: <blockquote>{1}</blockquote></li>", pssrEntry.Name, FormatUtils.N(scriptResult, "[null]")));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.AppendLine(string.Format("\t\tScript '{0}'\r\n\t\t Result: '{1}'", pssrEntry.Name, FormatUtils.N(scriptResult, "[null]")));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Script '{0}'<br>Result: <blockquote>{1}</blockquote></li>", pssrEntry.Name, FormatUtils.N(scriptResult, "[null]")));
                    }
                    if (scriptResult != null)
                        sbTotalResults.AppendLine(scriptResult);
                    else
                        sbTotalResults.AppendLine("[null]");
                }

                htmlTextTextDetails.AppendLine("</ul>");
                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();
                returnState.CurrentValue = sbTotalResults.ToString();
                if (errors > 0 && warnings == 0 && success == 0)
                    returnState.State = CollectorState.Error;
                else if (errors > 0 || warnings > 0)
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
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.PowerShellScriptRunnerDefaultConfig;
        }
        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new PowerShellScriptRunnerEditEntry();
        }
        public override ICollectorDetailView GetCollectorDetailView()
        {
            return new PowerShellScriptRunnerShowDetails();
        }
        //public override List<AgentPresetConfig> GetPresets()
        //{
        //    List<AgentPresetConfig> list = new List<AgentPresetConfig>();
        //    list.Add(new AgentPresetConfig()
        //    {
        //        AgentClassName = this.GetType().Name,
        //        AgentDefaultName = "Check QuickMon version",
        //        Description = "Check QuickMon version >= 3.14",
        //        Config = "<config><powerShellScripts><powerShellScriptRunner name=\"Get QuickMon version (&gt; 3.14)\" returnCheckSequence=\"GWE\">\r\n" +
        //            "<testScript>$filePath = \"C:\\Program Files\\Hen IT\\QuickMon 3\\Quickmon.exe\"\r\n" +
        //            "if (Test-Path $filePath){\r\n" +
        //            "    $versionInfo = (Get-Command $filePath).FileVersionInfo.FileVersion\r\n" +
        //            "    $versionArray = $versionInfo.Split(\".\")\r\n" +
        //            "    $major = [int]$versionArray[0]\r\n" +
        //            "    $minor = [int]$versionArray[1]\r\n" +
        //            "    if ($major -eq 3 -and $minor -ge 14)\r\n" +
        //            "    {\r\n" +
        //            "       \"Version check OK - \"  + $versionInfo.ToString()\r\n" +
        //            "    }\r\n" +
        //            "    else\r\n" +
        //            "    {\r\n" +
        //            "        \"Version check fail - \" + $versionInfo.ToString()\r\n" +
        //            "    }\r\n" +
        //            "}\r\n" +
        //            "else {\r\n" +
        //            "    \"'\" + $filePath + \"' does not exist!\"\r\n" +
        //            "}</testScript>\r\n" +
        //            "<goodScript resultMatchType=\"Contains\">Version check OK</goodScript>\r\n" +
        //            "<warningScript resultMatchType=\"Contains\">Version check fail</warningScript>\r\n" +
        //            "<errorScript resultMatchType=\"Match\">[any]</errorScript>\r\n" +
        //            "</powerShellScriptRunner>\r\n" +
        //            "</powerShellScripts>\r\n" +
        //            "</config>"
        //    });
        //    list.Add(new AgentPresetConfig()
        //    {
        //        AgentClassName = this.GetType().Name,
        //        AgentDefaultName = "PowerShell 2 installed",
        //        Description = "Is PowerShell 2 (or later) installed",
        //        Config = "<config><powerShellScripts><powerShellScriptRunner name=\"PowerShell 4\" returnCheckSequence=\"GWE\">\r\n" +
        //                "<testScript>if ($host.Version.Major -ge 2){\r\n" +
        //                "   \"Success. Version: \" + $host.Version.ToString()\r\n" +
        //                "}\r\n" +
        //                "else {\r\n" +
        //                "   \"Fail. Version: \" + $host.Version.Major\r\n" +
        //                "}</testScript>\r\n" +
        //                "<goodScript resultMatchType=\"Contains\">Success</goodScript>\r\n" +
        //                "<warningScript resultMatchType=\"Match\">[null]</warningScript>\r\n" +
        //                "<errorScript resultMatchType=\"Match\">[any]</errorScript>\r\n" +
        //                "</powerShellScriptRunner>\r\n" +
        //                "</powerShellScripts>\r\n" +
        //                "</config>"
        //    });
        //    list.Add(new AgentPresetConfig()
        //    {
        //        AgentClassName = this.GetType().Name,
        //        AgentDefaultName = "PowerShell 4 installed",
        //        Description = "Is PowerShell 4 installed",
        //        Config = "<config><powerShellScripts><powerShellScriptRunner name=\"PowerShell 4\" returnCheckSequence=\"GWE\">\r\n" +
        //                "<testScript>if ($host.Version.Major -ge 4){\r\n" +
        //                "   \"Success. Version: \" + $host.Version.ToString()\r\n" +
        //                "}\r\n" +
        //                "else {\r\n" +
        //                "   \"Fail. Version: \" + $host.Version.Major\r\n" +
        //                "}</testScript>\r\n" +
        //                "<goodScript resultMatchType=\"Contains\">Success</goodScript>\r\n" +
        //                "<warningScript resultMatchType=\"Match\">[null]</warningScript>\r\n" +
        //                "<errorScript resultMatchType=\"Match\">[any]</errorScript>\r\n" +
        //                "</powerShellScriptRunner>\r\n" +
        //                "</powerShellScripts>\r\n" +
        //                "</config>"
        //    });
        //    return list;
        //}
    }
}
