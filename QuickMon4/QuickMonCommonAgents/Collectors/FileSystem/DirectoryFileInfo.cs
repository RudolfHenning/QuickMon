using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public struct DirectoryFileInfo
    {
        public bool DirectoryExists;
        public int FileCount;
        public long TotalFileSize;
        public List<FileInfo> FileInfos;
    }
}
