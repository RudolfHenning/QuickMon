using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public struct DirectoryFileInfo
    {
        public bool Exists;
        public int FileCount;
        public long FileSize;
        public List<FileInfo> FileInfos;
    }
}
