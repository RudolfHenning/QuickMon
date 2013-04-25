using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QuickMon
{
    public class DirectoryFilterEntry
    {
        public string DirectoryPath { get; set; }
        public string FileFilter { get; set; }
        public bool DirectoryExistOnly { get; set; }
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
        public static string GetDirectoryFromPath(string path)
        {
            string directory = path;
            if (path.Contains("*"))
            {
                directory = path.Substring(0, path.LastIndexOf('\\')).Trim();
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
                                fileInfo.FileSize += fi.Length;
                                fileInfo.FileCount += 1;
                                fileInfo.FileInfos.Add(fi);
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
    }
}
