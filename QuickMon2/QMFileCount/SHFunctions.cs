using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Win32;


namespace QuickMon
{
    public class SHFunctions
    {
        public static DirectoryFileInfo GetDirectoryFileInfo(
            string directoryPath, 
            string filter, 
            long fileAgeMax = 0, 
            long fileAgeMin = 0,
            long fileSizeMax = 0,
            long fileSizeMin = 0)
        {
            DirectoryFileInfo fileInfo;
            fileInfo.Exists = System.IO.Directory.Exists(directoryPath);
            fileInfo.FileCount = 0;
            fileInfo.FileSize = 0;
            fileInfo.FileInfos = new List<System.IO.FileInfo>();

            foreach (string filePath in System.IO.Directory.GetFiles(directoryPath, filter))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(filePath);                

                if ((fileAgeMax == 0 || fi.LastWriteTime.AddSeconds(fileAgeMax) > DateTime.Now) &&
                            (fileAgeMin == 0 || fi.LastWriteTime.AddSeconds(fileAgeMin) < DateTime.Now) &&
                            (fileSizeMax == 0 || fi.Length <= (fileSizeMax * 1024)) &&
                            (fileSizeMin == 0 || fi.Length >= (fileSizeMin * 1024))
                            )
                {
                    fileInfo.FileSize += fi.Length;
                    fileInfo.FileCount += 1;
                }
            }
            return fileInfo;
        }

        //public static DirectoryFileInfo GetDirectoryFileInfoOld(
        //    string directoryPath, 
        //    string filter, 
        //    long fileAgeMax = 0, 
        //    long fileAgeMin = 0,
        //    long fileSizeMax = 0,
        //    long fileSizeMin = 0)
        //{
        //    DirectoryFileInfo fileInfo;
        //    fileInfo.FileCount = 0;
        //    fileInfo.FileSize = 0;

        //    WIN32_FIND_DATA_FF data = new WIN32_FIND_DATA_FF();
        //    IntPtr searchHandle;
        //    int continueSearch = 1;
        //    searchHandle = Win32.Kernel.FindFirstFile(directoryPath.TrimEnd('\\') + "\\" + filter, data);
        //    if (searchHandle.ToInt32() != Win32.User.INVALID_HANDLE_VALUE)
        //    {
        //        while ((continueSearch != 0))
        //        {
        //            if ((data.fileName != ".") && (data.fileName != "..") &&
        //                ((data.fileAttributes & Win32.Kernel.FILE_ATTRIBUTE_DIRECTORY) == 0))
        //            {
        //                long fileSize = (data.nFileSizeHigh * int.MaxValue) + data.nFileSizeLow;
        //                #region Getting file last modified date
        //                FILETIME fileTime;
        //                SYSTEMTIME fileSysTime = new SYSTEMTIME();
        //                fileTime.dwHighDateTime = data.lastWriteTime_highDateTime;
        //                fileTime.dwLowDateTime = data.lastWriteTime_lowDateTime;
        //                Kernel.FileTimeToLocalFileTime(ref fileTime, ref fileTime);
        //                Kernel.FileTimeToSystemTime(ref fileTime, ref fileSysTime);
        //                DateTime fileDt = new DateTime(fileSysTime.wYear, fileSysTime.wMonth, fileSysTime.wDay, fileSysTime.wHour, fileSysTime.wMinute, fileSysTime.wSecond);

        //                #endregion

        //                if ((fileAgeMax == 0 || fileDt.AddSeconds(fileAgeMax) > DateTime.Now) &&
        //                    (fileAgeMin == 0 || fileDt.AddSeconds(fileAgeMin) < DateTime.Now) &&
        //                    (fileSizeMax == 0 || fileSize <= (fileSizeMax * 1024)) &&
        //                    (fileSizeMin == 0 || fileSize >= (fileSizeMin * 1024))
        //                    )
        //                {
        //                    fileInfo.FileSize += fileSize;
        //                    fileInfo.FileCount += 1;
        //                }
        //            }
        //            continueSearch = Win32.Kernel.FindNextFile(searchHandle, data);
        //        }
        //    }
        //    Win32.Kernel.FindClose(searchHandle);
        //    data = null;
        //    return fileInfo;
        //}
    }
}
