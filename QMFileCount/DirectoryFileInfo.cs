using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace QuickMon
{
    public struct DirectoryFileInfo
    {
        public int FileCount;
        public long FileSize;
        public List<FileInfo> FileInfos;
    }
}
