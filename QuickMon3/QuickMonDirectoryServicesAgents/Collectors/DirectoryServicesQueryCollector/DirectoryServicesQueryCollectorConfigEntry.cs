using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class DirectoryServicesQueryCollectorConfigEntry : ICollectorConfigEntry
    {
        public DirectoryServicesQueryCollectorConfigEntry()
        {
            UseRowCountAsValue = false;
            MaxRowsToEvaluate = 1;
            PropertiesToLoad = "sAMAccountName";
        }
        #region Properties
        public string Name { get; set; }
        public string DomainController { get; set; }
        public string QueryFilterText { get; set; }
        public string PropertiesToLoad { get; set; }
        public CollectorReturnValueCheckSequenceType ReturnCheckSequence { get; set; }
        public bool UseRowCountAsValue { get; set; }
        public int MaxRowsToEvaluate { get; set; }
        public CollectorReturnValueCompareMatchType GoodResultMatchType { get; set; }
        public string GoodScriptText { get; set; }
        public CollectorReturnValueCompareMatchType WarningResultMatchType { get; set; }
        public string WarningScriptText { get; set; }
        public CollectorReturnValueCompareMatchType ErrorResultMatchType { get; set; }
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
                    foreach (string propName in PropertiesToLoad.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
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
            return CollectorReturnValueCompareEngine.GetState(ReturnCheckSequence,
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
