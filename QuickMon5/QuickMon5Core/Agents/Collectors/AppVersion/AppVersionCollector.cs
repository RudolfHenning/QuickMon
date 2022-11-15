using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Application Version Collector"), Category("General")]
    public class AppVersionCollector : CollectorAgentBase
    {
        public AppVersionCollector()
        {
            AgentConfig = new AppVersionCollectorConfig();
        }
    }
    public class AppVersionCollectorConfig : ICollectorConfig
    {
        public AppVersionCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }
        #region ICollectorConfig Members
        public bool SingleEntryOnly { get { return true; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        #region IAgentConfig Members
        public string GetDefaultOrEmptyXml()
        {
            return "<config><applications></applications></config>";
        }
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            Entries.Clear();
            System.Xml.XmlElement root = config.DocumentElement;
            foreach (System.Xml.XmlElement appVersion in root.SelectNodes("applications/application"))
            {
                AppVersionEntry appVersionEntry = new AppVersionEntry();
                appVersionEntry.ApplicationName = appVersion.Attributes.GetNamedItem("name").Value;
                appVersionEntry.ExpectedVersion = appVersion.Attributes.GetNamedItem("expectedVersion").Value;
                appVersionEntry.UseFileVersion = bool.Parse(appVersion.ReadXmlElementAttr("useFileVersion", "True"));
                appVersionEntry.UseFirstValidPath = bool.Parse(appVersion.ReadXmlElementAttr("useFirstValidPath", "True"));
                appVersionEntry.PrimaryUIValue = appVersion.ReadXmlElementAttr("primaryUIValue", false);

                appVersionEntry.ExecutablePaths = new List<string>();
                foreach (XmlElement pathNode in appVersion.SelectNodes("paths/path"))
                {
                    appVersionEntry.ExecutablePaths.Add(pathNode.InnerText);
                }

                Entries.Add(appVersionEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlNode applicationsNode = config.SelectSingleNode("config/applications");
            foreach (AppVersionEntry de in Entries)
            {
                XmlNode applicationXmlNode = config.CreateElement("application");
                applicationXmlNode.SetAttributeValue("name", de.ApplicationName);
                applicationXmlNode.SetAttributeValue("expectedVersion", de.ExpectedVersion);
                applicationXmlNode.SetAttributeValue("useFileVersion", de.UseFileVersion);
                applicationXmlNode.SetAttributeValue("useFirstValidPath", de.UseFirstValidPath);
                applicationXmlNode.SetAttributeValue("primaryUIValue", de.PrimaryUIValue);

                XmlElement pathsNode = config.CreateElement("paths");
                foreach (string exepath in de.ExecutablePaths)
                {
                    pathsNode.AppendElementWithText("path", exepath);
                }
                applicationXmlNode.AppendChild(pathsNode);
                applicationsNode.AppendChild(applicationXmlNode);
            }
            return config.OuterXml;
        }
        public string ConfigSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("{0} entries(s): ", Entries.Count));
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
    public class AppVersionEntry : ICollectorConfigEntry
    {
        public AppVersionEntry()
        {
            ExecutablePaths = new List<string>();            
        }

        #region Properties  
        /// <summary>
        /// Display name of the application/executable
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// If true use 'File' version of executable
        /// If false use 'Product' version of executable
        /// </summary>
        public bool UseFileVersion { get; set; } = false;
        /// <summary>
        /// In case there are multiple possible paths - e.g. like 64/32bit versions
        /// </summary>
        public List<string> ExecutablePaths { get; set; }
        /// <summary>
        /// If true use the first valid path in Executable Paths to retrieve version number
        /// If false use the maximum version number of all executables
        /// </summary>
        public bool UseFirstValidPath { get; set; } = true;
        /// <summary>
        /// The expected value of the version. 
        /// Can use * wildcard at the end to match any string that starts with value
        /// </summary>
        public string ExpectedVersion { get; set; }
        //public FileVersionMatchType MatchType { get; set; }
        #endregion

        #region ICollectorConfigEntry Members
        public string Description
        {
            get
            {
                return string.Format("{0}", ApplicationName);
            }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("Expected '{0}', ", ExpectedVersion);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }

        private sbyte IsVersionBigger(System.Diagnostics.FileVersionInfo v1, System.Diagnostics.FileVersionInfo v2, bool fileVersion = true)
        {
            int v1majorVersion = 0;
            int v1minorVersion = 0;
            int v1buildVersion = 0;
            int v2majorVersion = 0;
            int v2minorVersion = 0;
            int v2buildVersion = 0;
            if (fileVersion)
            {
                v1majorVersion = v1.FileMajorPart;
                v1minorVersion = v1.FileMinorPart;
                v1buildVersion = v1.FileBuildPart;
                v2majorVersion = v2.FileMajorPart;
                v2minorVersion = v2.FileMinorPart;
                v2buildVersion = v2.FileBuildPart;
            }

            if (v1majorVersion == v2majorVersion && v1minorVersion == v2minorVersion && v1buildVersion == v2buildVersion)
                return 0;
            else if (v1majorVersion > v2majorVersion)
                return 1;
            else if (v1majorVersion < v2majorVersion)
                return -1;
            else if (v1majorVersion == v2majorVersion && v1minorVersion < v2minorVersion)
                return -1;
            else if (v1majorVersion == v2majorVersion && v1minorVersion > v2minorVersion)
                return 1;
            else if (v1majorVersion == v2majorVersion && v1minorVersion == v2minorVersion && v1buildVersion < v2buildVersion)
                return -1;
            else //if (v1majorVersion == v2majorVersion && v1minorVersion == v2minorVersion && v1buildVersion > v2buildVersion)
                return 1;

            //if (fileVersion)
            //{
            //    if (v1.FileVersion == v2.FileVersion)
            //        return 0;
            //    else if (v1.FileMajorPart > v2.FileMajorPart)
            //        return 1;
            //    else if (v1.FileMajorPart < v2.FileMajorPart)
            //        return -1;
            //    else if (v1.FileMajorPart == v2.FileMajorPart && v1.FileMinorPart < v2.FileMinorPart)
            //        return -1;
            //    else if (v1.FileMajorPart == v2.FileMajorPart && v1.FileMinorPart == v2.FileMinorPart && v1.FileBuildPart < v2.FileBuildPart)
            //        return -1;
            //    else 
            //        return 1;
            //}
            //else
            //{
            //    if (v1.ProductVersion == v2.ProductVersion)
            //        return 0;
            //    else if (v1.ProductMajorPart < v2.ProductMajorPart ||
            //            v1.ProductMinorPart < v2.ProductMinorPart ||
            //            v1.ProductBuildPart < v2.ProductBuildPart)
            //    {
            //        return -1;
            //    }
            //    else return 1;
            //}
        }
        public MonitorState GetCurrentState()
        {
            MonitorState currentState = new MonitorState()
            {
                ForAgent = ApplicationName,
                State = CollectorState.NotAvailable,
                CurrentValueUnit = ""
            };
            System.Diagnostics.FileVersionInfo fvi = null;
            if (ExecutablePaths != null && ExecutablePaths.Count > 0)
            {
                foreach(string path in ExecutablePaths)
                {
                    if (System.IO.File.Exists(path))
                    {
                        try
                        {
                            System.Diagnostics.FileVersionInfo currentfvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(path);
                            if (UseFirstValidPath)
                            {
                                fvi = currentfvi;
                                break;
                            } 
                            else
                            {
                                if (fvi == null)
                                    fvi = currentfvi;
                                else //if higher version then use
                                {
                                    if (IsVersionBigger(fvi, currentfvi, UseFileVersion) == -1)                                    
                                        fvi = currentfvi;
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
            if (fvi == null)
            {
                currentState.State = CollectorState.Error;
                currentState.CurrentValue = "N/A";
                currentState.RawDetails = "No executable found!";
            }
            else
            {
                currentState.CurrentValue = UseFileVersion ? fvi.FileVersion : fvi.ProductVersion;
                currentState.RawDetails = $"exe path : {fvi.FileName}";
                currentState.RawDetails += $"\r\nProduct name : {fvi.ProductName}";
                currentState.RawDetails += $"\r\nExpected version : {ExpectedVersion}";
                if (ExpectedVersion.Length > 1 && ExpectedVersion.EndsWith("*"))
                {
                    string startsWith = ExpectedVersion.TrimEnd('*');
                    if (currentState.CurrentValue.ToString().StartsWith(startsWith))
                        currentState.State = CollectorState.Good;
                    else
                        currentState.State = CollectorState.Warning;
                }
                else
                {
                    if (currentState.CurrentValue.ToString() == ExpectedVersion)
                        currentState.State = CollectorState.Good;
                    else
                        currentState.State = CollectorState.Warning;
                }
            }
            CurrentAgentValue = currentState.CurrentValue;
            return currentState;
        }
        #endregion
    }
}
