using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace QuickMon.Collectors
{
    //public enum TextCompareMatchType
    //{
    //    Match,
    //    Contains,
    //    RegEx
    //}
    //public static class TextCompareMatchTypeConverter
    //{
    //    public static TextCompareMatchType FromString(string text)
    //    {
    //        if (text.ToLower() == "match")
    //            return TextCompareMatchType.Match;
    //        else if (text.ToLower() == "regex")
    //            return TextCompareMatchType.RegEx;
    //        else
    //            return TextCompareMatchType.Contains;
    //    }
    //}
    //public enum ReturnCheckSequenceType
    //{
    //    GWE, //Test first for Good then Warning and then assume Error
    //    EWG  //Test first for Error then Warning and then assume good
    //}
    //public static class ReturnCheckSequenceTypeConverter
    //{
    //    public static ReturnCheckSequenceType FromString(string text)
    //    {
    //        if (text.ToLower() == "gwe")
    //            return ReturnCheckSequenceType.GWE;
    //        else
    //            return ReturnCheckSequenceType.EWG;
    //    }
    //}

    public class PowerShellScriptRunnerEntry : ICollectorConfigEntry
    {
        #region ICollectorConfigEntry Members
        public string Description
        {
            get { return Name; }
        }
        public string TriggerSummary
        {
            get {
                StringBuilder sb = new StringBuilder();
                if (ReturnCheckSequence == CollectorReturnValueCheckSequenceType.GWE)
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

        #region Properties
        public string Name { get; set; }
        public CollectorReturnValueCheckSequenceType ReturnCheckSequence { get; set; }
        public string TestScript { get; set; }
        public CollectorReturnValueCompareMatchType GoodResultMatchType { get; set; }
        public string GoodScriptText { get; set; }
        public CollectorReturnValueCompareMatchType WarningResultMatchType { get; set; }
        public string WarningScriptText { get; set; }
        public CollectorReturnValueCompareMatchType ErrorResultMatchType { get; set; }
        public string ErrorScriptText { get; set; }
        #endregion

        internal string RunScript()
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
                //if (variableList != null)
                //{
                //    foreach (var vari in variableList)
                //    {
                //        runspace.SessionStateProxy.SetVariable(vari.Item1, vari.Item2);
                //    }
                //}

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
                //if (pipeline.HadErrors)
                //{
                //    foreach (var err in pipeline.Error.ReadToEnd())
                //    {
                //        stringBuilder.AppendLine("Error(s):" + err.ToString());
                //    }
                //}

                output = stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                output = ex.ToString();
            }
            return output.Trim('\r', '\n');
        }

        internal CollectorState GetState(string scriptResultText)
        {
            return CollectorReturnValueCompareEngine.GetState(ReturnCheckSequence,
               GoodResultMatchType, GoodScriptText,
               WarningResultMatchType, WarningScriptText,
               ErrorResultMatchType, ErrorScriptText,
               scriptResultText);

            //CollectorState currentState = CollectorState.Good;

            //if (ReturnCheckSequence == ReturnCheckSequenceType.GWE)
            //{
            //    if (MatchGoodResult(scriptResultText))
            //        currentState = CollectorState.Good;
            //    else if (MatchWarningResult(scriptResultText))
            //        currentState = CollectorState.Warning;
            //    else 
            //        currentState = CollectorState.Error;
            //}
            //else
            //{
            //    if (MatchErrorResult(scriptResultText))
            //        currentState = CollectorState.Error;
            //    else if (MatchWarningResult(scriptResultText))
            //        currentState = CollectorState.Warning;
            //    else
            //        currentState = CollectorState.Good;
            //}
            //return currentState;
        }
        //private bool MatchGoodResult(string scriptResultText)
        //{
        //    return MatchResult(scriptResultText, GoodResultMatchType, GoodScriptText);            
        //}
        //private bool MatchWarningResult(string scriptResultText)
        //{
        //    return MatchResult(scriptResultText, WarningResultMatchType, WarningScriptText);
        //}
        //private bool MatchErrorResult(string scriptResultText)
        //{
        //    return MatchResult(scriptResultText, ErrorResultMatchType, ErrorScriptText);
        //}
        //private bool MatchResult(string scriptResultText, CollectorReturnValueCompareMatchType matchType, string matchWith)
        //{
        //    if (matchWith.ToLower() == "[any]")
        //        return true;
        //    else if (matchWith.ToLower() == "[null]" && (scriptResultText == null || scriptResultText == "[null]"))
        //        return true;
        //    else if (matchType == TextCompareMatchType.RegEx)
        //    {
        //        System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(scriptResultText, matchWith, System.Text.RegularExpressions.RegexOptions.Multiline); // | System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        //        return match.Success;
        //    }
        //    else if (matchType == TextCompareMatchType.Contains)
        //        return scriptResultText.Contains(matchWith);
        //    else
        //        return scriptResultText == matchWith;
        //}

    }
}
