using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using QuickMon.MeansurementUnits;

namespace QuickMon.Collectors
{
    [Description("File System Collector"), Category("General")]
    public class FileSystemCollector : CollectorAgentBase
    {
        public FileSystemCollector()
        {
            AgentConfig = new FileSystemCollectorConfig();
        }
    }
    public class FileSystemCollectorConfig : ICollectorConfig
    {
        public FileSystemCollectorConfig()
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
            System.Xml.XmlElement root = config.DocumentElement;
            foreach (System.Xml.XmlElement host in root.SelectNodes("directoryList/directory"))
            {
                FileSystemDirectoryFilterEntry directoryFilterEntry = new FileSystemDirectoryFilterEntry();
                directoryFilterEntry.FilterFullPath = host.Attributes.GetNamedItem("directoryPathFilter").Value;
                directoryFilterEntry.DirectoryExistOnly = bool.Parse(host.ReadXmlElementAttr("testDirectoryExistOnly", "False"));
                directoryFilterEntry.FilesExistOnly = bool.Parse(host.ReadXmlElementAttr("testFilesExistOnly", "False"));
                directoryFilterEntry.ErrorOnFilesExist = bool.Parse(host.ReadXmlElementAttr("errorOnFilesExist", "False"));
                directoryFilterEntry.IncludeSubDirectories = bool.Parse(host.ReadXmlElementAttr("includeSubDirs", "False"));
                directoryFilterEntry.ContainsText = host.ReadXmlElementAttr("containsText", "");
                directoryFilterEntry.UseRegEx = host.ReadXmlElementAttr("useRegEx", false);
                directoryFilterEntry.FindTextInLastXLines = host.ReadXmlElementAttr("FindTextInLastXLines", 0);

                int tmp = 0;
                if (int.TryParse(host.ReadXmlElementAttr("warningFileCountMax", "0"), out tmp))
                    directoryFilterEntry.CountWarningIndicator = tmp;
                if (int.TryParse(host.ReadXmlElementAttr("errorFileCountMax", "0"), out tmp))
                    directoryFilterEntry.CountErrorIndicator = tmp;
                long tmpl;

                directoryFilterEntry.FileSizeIndicatorUnit = (FileSizeUnits)Enum.Parse(typeof(FileSizeUnits), host.ReadXmlElementAttr("fileSizeIndicatorUnit", "KB"));
                if (long.TryParse(host.ReadXmlElementAttr("warningFileSizeMax", "0"), out tmpl))
                    directoryFilterEntry.SizeWarningIndicator = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("errorFileSizeMax", "0"), out tmpl))
                    directoryFilterEntry.SizeErrorIndicator = tmpl;

                directoryFilterEntry.FileAgeUnit = (TimeUnits)Enum.Parse(typeof(TimeUnits), host.ReadXmlElementAttr("fileAgeUnit", "Minute"));
                if (long.TryParse(host.ReadXmlElementAttr("fileMinAge", "0"), out tmpl))
                    directoryFilterEntry.FileMinAge = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("fileMaxAge", "0"), out tmpl))
                    directoryFilterEntry.FileMaxAge = tmpl;
                directoryFilterEntry.FileSizeUnit = (FileSizeUnits)Enum.Parse(typeof(FileSizeUnits), host.ReadXmlElementAttr("fileSizeUnit", "KB"));
                if (long.TryParse(host.ReadXmlElementAttr("fileMinSize", "0"), out tmpl))
                    directoryFilterEntry.FileMinSize = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("fileMaxSize", "0"), out tmpl))
                    directoryFilterEntry.FileMaxSize = tmpl;

                directoryFilterEntry.ShowFilenamesInDetails = host.ReadXmlElementAttr("showFilenamesInDetails", false);
                directoryFilterEntry.TopFileNameCountInDetails = host.ReadXmlElementAttr("topFileNameCountInDetails", 10);
                directoryFilterEntry.ShowFileCountInOutputValue = host.ReadXmlElementAttr("showFileCountInOutputValue", true);
                directoryFilterEntry.ShowFileSizeInOutputValue = host.ReadXmlElementAttr("showFileSizeInOutputValue", false);
                directoryFilterEntry.PrimaryUIValue = host.ReadXmlElementAttr("primaryUIValue", false);

                Entries.Add(directoryFilterEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlNode directoryList = config.SelectSingleNode("config/directoryList");
            foreach (FileSystemDirectoryFilterEntry de in Entries)
            {
                XmlNode directoryXmlNode = config.CreateElement("directory");

                directoryXmlNode.SetAttributeValue("directoryPathFilter", de.FilterFullPath);
                directoryXmlNode.SetAttributeValue("testDirectoryExistOnly", de.DirectoryExistOnly);
                directoryXmlNode.SetAttributeValue("testFilesExistOnly", de.FilesExistOnly);
                directoryXmlNode.SetAttributeValue("errorOnFilesExist", de.ErrorOnFilesExist);
                directoryXmlNode.SetAttributeValue("includeSubDirs", de.IncludeSubDirectories);
                directoryXmlNode.SetAttributeValue("containsText", de.ContainsText);
                directoryXmlNode.SetAttributeValue("useRegEx", de.UseRegEx);
                directoryXmlNode.SetAttributeValue("FindTextInLastXLines", de.FindTextInLastXLines);
                directoryXmlNode.SetAttributeValue("warningFileCountMax", de.CountWarningIndicator);
                directoryXmlNode.SetAttributeValue("errorFileCountMax", de.CountErrorIndicator);
                directoryXmlNode.SetAttributeValue("fileSizeIndicatorUnit", de.FileSizeIndicatorUnit.ToString());
                directoryXmlNode.SetAttributeValue("warningFileSizeMax", de.SizeWarningIndicator);
                directoryXmlNode.SetAttributeValue("errorFileSizeMax", de.SizeErrorIndicator);
                directoryXmlNode.SetAttributeValue("fileAgeUnit", de.FileAgeUnit.ToString());
                directoryXmlNode.SetAttributeValue("fileMinAge", de.FileMinAge);
                directoryXmlNode.SetAttributeValue("fileMaxAge", de.FileMaxAge);
                directoryXmlNode.SetAttributeValue("fileSizeUnit", de.FileSizeUnit.ToString());
                directoryXmlNode.SetAttributeValue("fileMinSize", de.FileMinSize);
                directoryXmlNode.SetAttributeValue("fileMaxSize", de.FileMaxSize);
                directoryXmlNode.SetAttributeValue("showFilenamesInDetails", de.ShowFilenamesInDetails);
                directoryXmlNode.SetAttributeValue("topFileNameCountInDetails", de.TopFileNameCountInDetails);
                directoryXmlNode.SetAttributeValue("showFileCountInOutputValue", de.ShowFileCountInOutputValue);
                directoryXmlNode.SetAttributeValue("showFileSizeInOutputValue", de.ShowFileSizeInOutputValue);
                directoryXmlNode.SetAttributeValue("primaryUIValue", de.PrimaryUIValue);

                directoryList.AppendChild(directoryXmlNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><directoryList></directoryList></config>";
        }
        public string ConfigSummary
        {
            get
            {
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
    public class FileSystemDirectoryFilterEntry : ICollectorConfigEntry
    {
        public FileSystemDirectoryFilterEntry()
        {
            FileAgeUnit = TimeUnits.Minute;
            FileSizeUnit = FileSizeUnits.KB;
            FileSizeIndicatorUnit = FileSizeUnits.KB;
            IncludeSubDirectories = false;
            ShowFileCountInOutputValue = true;
            FindTextInLastXLines = 0;
        }

        private string stateDescription = "";

        #region Properties  
        #region File Filters      
        public string DirectoryPath { get; set; }
        public string FilterFullPath
        {
            get
            {
                return DirectoryPath.TrimEnd('\\') + "\\" + FileFilter;
            }
            set
            {
                DirectoryPath = GetDirectoryFromPath(value);
                FileFilter = GetFilterFromPath(value);
            }
        }        
        public string FileFilter { get; set; }
        public bool IncludeSubDirectories { get; set; }

        #region File Content matching
        /// <summary>
        /// Does the file contain this text
        /// </summary>
        public string ContainsText { get; set; }
        /// <summary>
        /// Should Regular expressions be used for ContainsText
        /// </summary>
        public bool UseRegEx { get; set; }
        public int FindTextInLastXLines { get; set; } 
        #endregion

        #region File Age
        /// <summary>
        /// Unit type used for FileMinAge and FileMaxAge
        /// </summary>
        public TimeUnits FileAgeUnit { get; set; }
        /// <summary>
        /// File max age
        /// </summary>
        public long FileMaxAge { get; set; }
        /// <summary>
        /// File min age
        /// </summary>
        public long FileMinAge { get; set; }
        #endregion

        #region File Size
        /// <summary>
        /// Unit type of FileMinSize and FileMaxSize
        /// </summary>
        public FileSizeUnits FileSizeUnit { get; set; }
        /// <summary>
        /// File minimum size
        /// </summary>
        public long FileMinSize { get; set; }
        /// <summary>
        /// File maximum size
        /// </summary>
        public long FileMaxSize { get; set; }
        #endregion
        #endregion

        #region Test Conditions
        public bool DirectoryExistOnly { get; set; }
        /// <summary>
        /// If any files are found matching filtering conditions it return a success
        /// </summary>
        public bool FilesExistOnly { get; set; }
        /// <summary>
        /// If any files are found matching filtering conditions it return a failure
        /// </summary>
        public bool ErrorOnFilesExist { get; set; }

        #region File count conditions
        /// <summary>
        /// If CountWarningIndicator < CountErrorIndicator then Good state is when count < CountWarningIndicator
        /// Else Good > CountErrorIndicator
        /// </summary>
        public int CountWarningIndicator { get; set; }
        /// <summary>
        /// If CountWarningIndicator < CountErrorIndicator then Good state is when count < CountWarningIndicator
        /// Else Good > CountErrorIndicator
        /// </summary>
        public int CountErrorIndicator { get; set; }
        #endregion

        #region File size conditions
        /// <summary>
        /// Unit type of SizeWarningIndicator and SizeErrorIndicator
        /// </summary>
        public FileSizeUnits FileSizeIndicatorUnit { get; set; }
        /// <summary>
        /// Total File size warning indicator (in KB). If SizeKBWarningIndicator < SizeKBErrorIndicator then Good state is when total size < SizeKBWarningIndicator
        /// Else Good > SizeKBErrorIndicator
        /// </summary>
        public long SizeWarningIndicator { get; set; }
        /// <summary>
        /// Total File size warning indicator (in KB). If SizeKBWarningIndicator < SizeKBErrorIndicator then Good state is when total size < SizeKBWarningIndicator
        /// Else Good > SizeKBErrorIndicator
        /// </summary>
        public long SizeErrorIndicator { get; set; }
        #endregion
        #endregion

        #region Output display value option
        /// <summary>
        /// Show file names in RAW/Html details
        /// </summary>
        public bool ShowFilenamesInDetails { get; set; }
        public int TopFileNameCountInDetails { get; set; } = 10;
        public bool ShowFileCountInOutputValue { get; set; }
        public bool ShowFileSizeInOutputValue { get; set; }

        #endregion

        public string LastErrorMsg { get; set; }
        #endregion

        #region ICollectorConfigEntry
        public string Description
        {
            get
            {
                return string.Format("{0}\\[{1}]", DirectoryPath, FileFilter);
            }
        }
        public string TriggerSummary
        {
            get
            {
                string filterSummary = "";
                if (DirectoryExistOnly)
                    filterSummary = "Dir existance";
                else
                {
                    if (ErrorOnFilesExist)
                        filterSummary = "Err if file(s) exist";
                    else if (FilesExistOnly)
                        filterSummary = "File(s) existance";

                    if (CountWarningIndicator > 0 || CountErrorIndicator > 0)
                        filterSummary += (filterSummary.Length > 0 ? ", " : "") + "File count: W:" + CountWarningIndicator + ", E:" + CountErrorIndicator;
                    if (SizeWarningIndicator > 0 || SizeErrorIndicator > 0)
                        filterSummary += (filterSummary.Length > 0 ? ", " : "") + "Total size: W:" + SizeWarningIndicator + FileSizeIndicatorUnit.ToString() + " - E:" + SizeErrorIndicator + FileSizeIndicatorUnit.ToString();
                    if (FileMaxAge > 0 || FileMinAge > 0)
                        filterSummary += (filterSummary.Length > 0 ? ", " : "") + "File age(" + FileAgeUnit.ToString() + "): " + FileMinAge + "-" + FileMaxAge;
                    if (FileMinSize > 0 || FileMaxSize > 0)
                        filterSummary += (filterSummary.Length > 0 ? ", " : "") + "File size(" + FileSizeUnit.ToString() + "): " + FileMinSize + "-" + FileMaxSize;

                }
                return string.Format("{0}", filterSummary);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }
        public MonitorState GetCurrentState()
        {
            DirectoryFileInfo directoryFileInfo = GetFileListByFilters();
            MonitorState currentState = new MonitorState()
            {
                ForAgent = DirectoryPath,
                State = GetState(directoryFileInfo)
            };

            if (DirectoryExistOnly && currentState.State != CollectorState.Good)
            {
                currentState.CurrentValue = stateDescription;
            }
            else if (DirectoryExistOnly)
            {
                currentState.CurrentValue = stateDescription;                
            }
            else
            {
                currentState.RawDetails = stateDescription;
                if (directoryFileInfo.FileCount == -1)
                {
                    currentState.CurrentValue = stateDescription;                    
                }
                else
                {
                    if (directoryFileInfo.FileCount > 0)
                    {
                        if (ShowFileCountInOutputValue && ShowFileSizeInOutputValue)
                        {
                            currentState.CurrentValue = string.Format("{0} file(s), {1}", directoryFileInfo.FileCount, FormatUtils.FormatFileSize(directoryFileInfo.TotalFileSize));
                        }
                        else if (ShowFileCountInOutputValue)
                        {
                            currentState.CurrentValue = directoryFileInfo.FileInfos.Count;
                            currentState.CurrentValueUnit = "file(s)";
                        }
                        else if (ShowFileSizeInOutputValue)
                        {
                            currentState.CurrentValue = FormatUtils.FormatFileSize(directoryFileInfo.TotalFileSize);
                        }
                        else
                        {
                            currentState.CurrentValue = stateDescription;
                        }

                        if (ShowFilenamesInDetails)
                        {
                            int topCount = TopFileNameCountInDetails;
                            if (topCount <= 0)
                                topCount = directoryFileInfo.FileInfos.Count;
                            for (int i = 0; i < TopFileNameCountInDetails && i < directoryFileInfo.FileInfos.Count; i++)
                            {
                                FileInfo fi = directoryFileInfo.FileInfos[i];
                                currentState.ChildStates.Add(
                                   new MonitorState()
                                   {
                                       ForAgent = fi.Name,
                                       ForAgentType = "FileInfo",
                                       CurrentValue = string.Format("{0}", FormatUtils.FormatFileSize(fi.Length))
                                   });
                            }
                        }
                    }
                    else
                    {
                        currentState.CurrentValue = "No";
                        currentState.CurrentValueUnit = "file(s)";
                    }                   
                }
            }
            CurrentAgentValue = currentState.CurrentValue;
            return currentState;
        }
        #endregion

        public static string GetDirectoryFromPath(string path)
        {
            string directory = path;
            if (path.Contains("*"))
            {
                directory = path.Substring(0, path.LastIndexOf('\\')).Trim();
            }
            else
            {
                directory = Path.GetDirectoryName(path);
            }
            return directory;
        }
        public static string GetFilterFromPath(string path)
        {
            string filter = "*.*";
            if (path.Contains("*"))
            {
                filter = path.Substring(path.LastIndexOf('\\') + 1).Trim();
            }
            else
            {
                filter = Path.GetFileName(path);
            }
            return filter;
        }
        public DirectoryFileInfo GetFileListByFilters()
        {
            DirectoryFileInfo fileInfo;
            fileInfo.DirectoryExists = false;
            fileInfo.FileCount = 0;
            fileInfo.TotalFileSize = 0;
            fileInfo.FileInfos = new List<FileInfo>();
            string fullFilePath = Environment.ExpandEnvironmentVariables(DirectoryPath);
            try
            {
                if (Directory.Exists(fullFilePath))
                {
                    fileInfo.DirectoryExists = true;
                    if (!DirectoryExistOnly)
                    {
                        SearchOption so = IncludeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                        foreach (string filePath in System.IO.Directory.GetFiles(fullFilePath, FileFilter, so))
                        {
                            System.IO.FileInfo fi = new System.IO.FileInfo(filePath);

                            if ((FileMaxAge == 0 || TimeUnitsTools.AddTime(fi.LastWriteTime, FileMaxAge, FileAgeUnit) > DateTime.Now) &&
                                        (FileMinAge == 0 || TimeUnitsTools.AddTime(fi.LastWriteTime, FileMinAge, FileAgeUnit) < DateTime.Now) &&
                                        (FileMaxSize == 0 || fi.Length <= FileSizeUnitsTools.ToBytes(FileSizeUnit, FileMaxSize)) &&
                                        (FileMinSize == 0 || fi.Length >= FileSizeUnitsTools.ToBytes(FileSizeUnit, FileMinSize))
                                        )
                            {
                                bool match = true;
                                if (ContainsText != null && ContainsText.Trim().Length > 0)
                                {
                                    string content = "";
                                    if (FindTextInLastXLines == 0)
                                    {
                                        content = File.ReadAllText(filePath);
                                    }
                                    else
                                    {
                                        content = ReadFileXLastLines(filePath, FindTextInLastXLines);
                                    }                                    

                                    if (UseRegEx)
                                    {
                                        System.Text.RegularExpressions.Match regMatch = System.Text.RegularExpressions.Regex.Match(content, ContainsText, System.Text.RegularExpressions.RegexOptions.Multiline);
                                        match = regMatch.Success;
                                    }
                                    else
                                        match = content.Contains(ContainsText);
                                }
                                if (match)
                                {
                                    fileInfo.TotalFileSize += fi.Length;
                                    fileInfo.FileCount += 1;
                                    fileInfo.FileInfos.Add(fi);
                                }
                            }
                        }
                    }
                }
                else
                {
                    fileInfo.DirectoryExists = false;
                }
            }
            catch (Exception ex)
            {
                LastErrorMsg = ex.Message;
                fileInfo.FileCount = -1;
                fileInfo.TotalFileSize = -1;
            }
            return fileInfo;
        }
        private CollectorState GetState(DirectoryFileInfo fileInfo)
        {
            CollectorState returnState = CollectorState.NotAvailable;
            stateDescription = "";
            if (!fileInfo.DirectoryExists)
            {
                returnState = CollectorState.Error;
                stateDescription = string.Format("Directory '{0}' not found or not accessible!", DirectoryPath);
            }
            else if (DirectoryExistOnly)
            {
                returnState = CollectorState.Good;
            }
            else if (fileInfo.FileCount == -1)
            {
                returnState = CollectorState.Error;
                stateDescription = string.Format("An error occured while accessing '{0}'\r\n\t{1}", FilterFullPath, LastErrorMsg);
            }
            else if (ErrorOnFilesExist)
            {
                returnState = fileInfo.FileCount > 0 ? CollectorState.Error : CollectorState.Good;
            }
            else if (FilesExistOnly)
            {
                returnState = fileInfo.FileCount > 0 ? CollectorState.Good : CollectorState.Error;
            }
            else
            {
                if ((CountErrorIndicator > 0 || CountWarningIndicator > 0) && (CountWarningIndicator != CountErrorIndicator))
                {
                    if (CountWarningIndicator < CountErrorIndicator)
                    {
                        if (fileInfo.FileCount < CountWarningIndicator)
                            returnState = CollectorState.Good;
                        else if (fileInfo.FileCount >= CountErrorIndicator)
                            returnState = CollectorState.Error;
                        else
                            returnState = CollectorState.Warning;
                    }
                    else
                        if (fileInfo.FileCount > CountWarningIndicator)
                        returnState = CollectorState.Good;
                    else if (fileInfo.FileCount <= CountErrorIndicator)
                        returnState = CollectorState.Error;
                    else
                        returnState = CollectorState.Warning;
                }

                if (returnState == CollectorState.Good || returnState == CollectorState.NotAvailable)
                {
                    if ((SizeWarningIndicator > 0 || SizeErrorIndicator > 0) && SizeWarningIndicator != SizeErrorIndicator)
                    {
                        if (SizeWarningIndicator < SizeErrorIndicator)
                        {
                            if (FileSizeUnitsTools.ToBytes(FileSizeIndicatorUnit, SizeWarningIndicator) > fileInfo.TotalFileSize)
                                returnState = CollectorState.Good;
                            else if (FileSizeUnitsTools.ToBytes(FileSizeIndicatorUnit, SizeErrorIndicator) < fileInfo.TotalFileSize)
                                returnState = CollectorState.Error;
                            else
                                returnState = CollectorState.Warning;
                        }
                        else
                        {
                            if (FileSizeUnitsTools.ToBytes(FileSizeIndicatorUnit, SizeWarningIndicator) < fileInfo.TotalFileSize)
                                returnState = CollectorState.Good;
                            else if (FileSizeUnitsTools.ToBytes(FileSizeIndicatorUnit, SizeErrorIndicator) > fileInfo.TotalFileSize)
                                returnState = CollectorState.Error;
                            else
                                returnState = CollectorState.Warning;
                        }
                    }
                }
                if (returnState == CollectorState.Warning)
                    stateDescription = string.Format("Warning state reached for '{0}': {1} file(s), {2}", FilterFullPath, fileInfo.FileCount, FormatUtils.FormatFileSize(fileInfo.TotalFileSize));
                else if (returnState == CollectorState.Error)
                    stateDescription = string.Format("Error state reached for '{0}': {1} file(s), {2}", FilterFullPath, fileInfo.FileCount, FormatUtils.FormatFileSize(fileInfo.TotalFileSize));
            }
            return returnState;
        }

        private string ReadFileXLastLines(string filePath, int lineCount = 1)
        {
            string contentOfLastLines = "";
            if (filePath != "" && System.IO.File.Exists(filePath))
            {
                var buffer = new Queue<string>(lineCount);
                var fileReader = new StreamReader(filePath);
                while (!fileReader.EndOfStream)
                {
                    string line = fileReader.ReadLine();

                    if (buffer.Count >= lineCount)
                        buffer.Dequeue();
                    buffer.Enqueue(line);
                }
                string[] lastLines = buffer.ToArray();
                contentOfLastLines = String.Join(Environment.NewLine, lastLines);
            }
            else
            {
                throw new Exception("Invalid/no file specified!");
            }
            return contentOfLastLines;
        }
    }
}
