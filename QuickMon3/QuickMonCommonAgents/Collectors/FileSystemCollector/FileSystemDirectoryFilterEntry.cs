using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class FileSystemDirectoryFilterEntry : ICollectorConfigEntry
    {
        #region Properties
        public string DirectoryPath { get; set; }
        public string FileFilter { get; set; }
        public bool DirectoryExistOnly { get; set; }
        public bool FilesExistOnly { get; set; }
        public bool ErrorOnFilesExist { get; set; }
        public string ContainsText { get; set; }
        public bool UseRegEx { get; set; }
        /// <summary>
        /// File max age in seconds
        /// </summary>
        public long FileMaxAgeSec { get; set; }
        /// <summary>
        /// File min age in seconds
        /// </summary>
        public long FileMinAgeSec { get; set; }
        /// <summary>
        /// File minimum size in KB
        /// </summary>
        public long FileMinSizeKB { get; set; }
        /// <summary>
        /// File maximum size in KB
        /// </summary>
        public long FileMaxSizeKB { get; set; }

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

        public int CountWarningIndicator { get; set; }
        public int CountErrorIndicator { get; set; }
        /// <summary>
        /// File size warning indicator (in KB)
        /// </summary>
        public long SizeKBWarningIndicator { get; set; }
        /// <summary>
        /// File size error indicator (in KB)
        /// </summary>
        public long SizeKBErrorIndicator { get; set; }

        public string LastErrorMsg { get; set; }
        #endregion

        #region ICollectorConfigEntry Members
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
                else if (ErrorOnFilesExist)
                    filterSummary = "Err if file(s) exist";
                else if (FilesExistOnly)
                    filterSummary = "File(s) existance";
                else
                {
                    if (CountWarningIndicator > 0 || CountErrorIndicator > 0)
                        filterSummary += "File count: W:" + CountWarningIndicator + ", E:" + CountErrorIndicator;
                    if (SizeKBWarningIndicator > 0 || SizeKBErrorIndicator > 0)
                        filterSummary += (filterSummary.Length > 0 ? ", " : "") + "Total size: W:" + SizeKBWarningIndicator + "KB - E:" + SizeKBErrorIndicator + "KB";
                    if (FileMaxAgeSec > 0 || FileMinAgeSec > 0)
                        filterSummary += (filterSummary.Length > 0 ? ", " : "") + "File age: " + FileMinAgeSec + "-" + FileMaxAgeSec;
                    if (FileMinSizeKB > 0 || FileMaxSizeKB > 0)
                        filterSummary += (filterSummary.Length > 0 ? ", " : "") + "File size: " + FileMinSizeKB + "-" + FileMaxSizeKB;
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

        public DirectoryFileInfo GetDirFileInfo()
        {
            DirectoryFileInfo fileInfo;
            fileInfo.Exists = false;
            fileInfo.FileCount = 0;
            fileInfo.FileSize = 0;
            fileInfo.FileInfos = new List<FileInfo>();
            try
            {
                if (Directory.Exists(DirectoryPath))
                {
                    fileInfo.Exists = true;
                    if (!DirectoryExistOnly)
                    {
                        foreach (string filePath in System.IO.Directory.GetFiles(DirectoryPath, FileFilter))
                        {
                            System.IO.FileInfo fi = new System.IO.FileInfo(filePath);

                            if ((FileMaxAgeSec == 0 || fi.LastWriteTime.AddSeconds(FileMaxAgeSec) > DateTime.Now) &&
                                        (FileMinAgeSec == 0 || fi.LastWriteTime.AddSeconds(FileMinAgeSec) < DateTime.Now) &&
                                        (FileMaxSizeKB == 0 || fi.Length <= (FileMaxSizeKB * 1024)) &&
                                        (FileMinSizeKB == 0 || fi.Length >= (FileMinSizeKB * 1024))
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
                                    fileInfo.FileSize += fi.Length;
                                    fileInfo.FileCount += 1;
                                    fileInfo.FileInfos.Add(fi);
                                }
                            }
                        }
                    }
                }
                else
                {
                    fileInfo.Exists = false;
                }
            }
            catch (Exception ex)
            {
                LastErrorMsg = ex.Message;
                fileInfo.FileCount = -1;
                fileInfo.FileSize = -1;
            }
            return fileInfo;
        }
        public CollectorState GetState(DirectoryFileInfo fileInfo)
        {
            CollectorState returnState = CollectorState.Good;
            LastErrorMsg = "";
            if (!fileInfo.Exists)
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
                if (
                    (CountErrorIndicator > 0 && CountErrorIndicator <= fileInfo.FileCount) ||
                    (SizeKBErrorIndicator > 0 && SizeKBErrorIndicator * 1024 <= fileInfo.FileSize)
                   )
                {
                    returnState = CollectorState.Error;
                    LastErrorMsg = string.Format("Error state reached for '{0}': {1} file(s), {2}", FilterFullPath, fileInfo.FileCount, FormatUtils.FormatFileSize(fileInfo.FileSize));
                }
                else if (
                        (CountWarningIndicator > 0 && CountWarningIndicator <= fileInfo.FileCount) ||
                        (SizeKBWarningIndicator > 0 && SizeKBWarningIndicator * 1024 <= fileInfo.FileSize)
                       )
                {
                    returnState = CollectorState.Warning;
                    LastErrorMsg = string.Format("Warning state reached for '{0}': {1} file(s), {2}", FilterFullPath, fileInfo.FileCount, FormatUtils.FormatFileSize(fileInfo.FileSize));
                }
                else
                {
                    returnState = CollectorState.Good;
                }
            }
            return returnState;
        }
    }
}
