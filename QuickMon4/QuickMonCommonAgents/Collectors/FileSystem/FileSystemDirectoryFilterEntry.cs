using QuickMon.MeansurementUnits;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class FileSystemDirectoryFilterEntry : ICollectorConfigEntry
    {
        public FileSystemDirectoryFilterEntry()
        {
            FileAgeUnit = TimeUnits.Minute;
            FileSizeUnit = FileSizeUnits.KB;
            IncludeSubDirectories = false;  
        }

        #region Properties
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
        public bool DirectoryExistOnly { get; set; }
        /// <summary>
        /// If any files are found mathing filtering conditions it return a True
        /// </summary>
        public bool FilesExistOnly { get; set; }
        /// <summary>
        /// If any files are found mathing filtering conditions it return a True
        /// </summary>
        public bool ErrorOnFilesExist { get; set; }
        public bool IncludeSubDirectories { get; set; }

        #region File filters
        public string FileFilter { get; set; }
        /// <summary>
        /// Does the file contain this text
        /// </summary>
        public string ContainsText { get; set; }
        /// <summary>
        /// Should Regular expressions be used for ContainsText
        /// </summary>
        public bool UseRegEx { get; set; }
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
        #region Summary trigger conditions
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
        public string LastErrorMsg { get; set; }
        /// <summary>
        /// Show file names in RAW/Html details
        /// </summary>
        public bool ShowFilenamesInDetails { get; set; }
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
                                    string content = File.ReadAllText(filePath);
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
        public CollectorState GetState(DirectoryFileInfo fileInfo)
        {
            CollectorState returnState = CollectorState.NotAvailable;
            LastErrorMsg = "";
            if (!fileInfo.DirectoryExists)
            {
                returnState = CollectorState.Error;
                LastErrorMsg = string.Format("Directory '{0}' not found or not accessible!", DirectoryPath);
            }
            else if (DirectoryExistOnly)
            {
                returnState = CollectorState.Good;
            }
            else if (fileInfo.FileCount == -1)
            {
                returnState = CollectorState.Error;
                LastErrorMsg = string.Format("An error occured while accessing '{0}'\r\n\t{1}", FilterFullPath, LastErrorMsg);
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
                    if ((SizeWarningIndicator > 0 ||  SizeErrorIndicator > 0) && SizeWarningIndicator != SizeErrorIndicator)
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
                    LastErrorMsg = string.Format("Warning state reached for '{0}': {1} file(s), {2}", FilterFullPath, fileInfo.FileCount, FormatUtils.FormatFileSize(fileInfo.TotalFileSize));
                else if (returnState == CollectorState.Error)
                    LastErrorMsg = string.Format("Error state reached for '{0}': {1} file(s), {2}", FilterFullPath, fileInfo.FileCount, FormatUtils.FormatFileSize(fileInfo.TotalFileSize));
            }
            return returnState;
        }
    }
}
