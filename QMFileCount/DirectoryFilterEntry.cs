using System;
using System.Collections.Generic;
using System.Text;

namespace QuickMon
{
    public class DirectoryFilterEntry
    {
        public string DirectoryPath { get; set; }
        public string FileFilter { get; set; }
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
    }
}
