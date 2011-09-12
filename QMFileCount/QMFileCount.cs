using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace QuickMon
{
    public class FileCount : CollectorBase
    {
        public FileCount() : base() { }

        private List<DirectoryFilterEntry> directorieFilters = new List<DirectoryFilterEntry>();

        public override MonitorStates GetState()
        {
            MonitorStates returnState = MonitorStates.Good;
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            LastDetailMsg.PlainText = "Getting file details";
            LastDetailMsg.HtmlText = "Getting file details";
            LastError = 0;
            LastErrorMsg = "";

            int errorCount = 0;
            int warningCount = 0;
            int okCount = 0;
            try
            {
                htmlTextTextDetails.AppendLine("<ul>");
                foreach (DirectoryFilterEntry directoryFilter in directorieFilters)
                {
                    DirectoryFileInfo directoryFileInfo = GetDirFileInfo(directoryFilter);

                    if (directoryFileInfo.FileCount == -1)
                    {
                        errorCount++;
                        plainTextDetails.AppendLine(string.Format("An error occured while accessing {0}\r\n\t{1}", directoryFilter.FilterFullPath, LastErrorMsg));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0} - Error accessing files<blockquote>{1}</blockquote></li>", directoryFilter.FilterFullPath, LastErrorMsg));
                    }
                    else if (
                        (directoryFilter.CountErrorIndicator > 0 && directoryFilter.CountErrorIndicator <= directoryFileInfo.FileCount) || 
                        (directoryFilter.SizeKBErrorIndicator > 0 && directoryFilter.SizeKBErrorIndicator * 1024 <= directoryFileInfo.FileSize)
                       )
                    {
                        errorCount++;
                        plainTextDetails.AppendLine(string.Format("Error state reached for {0}: {1} file(s), {2}", directoryFilter.FilterFullPath, directoryFileInfo.FileCount, FormatFileSize(directoryFileInfo.FileSize)));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0} - <b>Error</b> {1} file(s), {2}\r\n<blockquote>", directoryFilter.FilterFullPath, directoryFileInfo.FileCount, FormatFileSize(directoryFileInfo.FileSize)));
                        plainTextDetails.AppendLine(GetTop10FileInfos(directoryFileInfo.FileInfos));
                        htmlTextTextDetails.AppendLine(GetTop10FileInfos(directoryFileInfo.FileInfos).Replace("\r\n", "<br/>"));
                        htmlTextTextDetails.AppendLine("</blockquote></li>");
                    }
                    else if (
                        (directoryFilter.CountWarningIndicator > 0 && directoryFilter.CountWarningIndicator <= directoryFileInfo.FileCount) ||
                        (directoryFilter.SizeKBWarningIndicator > 0 && directoryFilter.SizeKBWarningIndicator * 1024 <= directoryFileInfo.FileSize)
                       )
                    {
                        warningCount++;
                        plainTextDetails.AppendLine(string.Format("Warning state reached for {0}: {1} file(s), {2}", directoryFilter.FilterFullPath, directoryFileInfo.FileCount, FormatFileSize(directoryFileInfo.FileSize)));
                        htmlTextTextDetails.AppendLine(string.Format("<li>{0} - <b>Warning</b> {1} file(s), {2}\r\n<blockquote>", directoryFilter.FilterFullPath, directoryFileInfo.FileCount, FormatFileSize(directoryFileInfo.FileSize)));
                        plainTextDetails.AppendLine(GetTop10FileInfos(directoryFileInfo.FileInfos));
                        htmlTextTextDetails.AppendLine(GetTop10FileInfos(directoryFileInfo.FileInfos).Replace("\r\n", "<br/>"));
                        htmlTextTextDetails.AppendLine("</blockquote></li>");
                    }
                    else
                    {
                        okCount++;
                        if (directoryFileInfo.FileCount > 0)
                        {
                            plainTextDetails.AppendLine(string.Format("Example details of {0}: {1} file(s), {2}", directoryFilter.FilterFullPath, directoryFileInfo.FileCount, FormatFileSize(directoryFileInfo.FileSize)));
                            htmlTextTextDetails.AppendLine(string.Format("<li>{0} {1} file(s), {2}\r\n<blockquote>", directoryFilter.FilterFullPath, directoryFileInfo.FileCount, FormatFileSize(directoryFileInfo.FileSize)));
                            plainTextDetails.AppendLine(GetTop10FileInfos(directoryFileInfo.FileInfos));
                            htmlTextTextDetails.AppendLine(GetTop10FileInfos(directoryFileInfo.FileInfos).Replace("\r\n", "<br/>"));
                            htmlTextTextDetails.AppendLine("</blockquote></li>");
                        }
                        else
                        {
                            plainTextDetails.AppendLine(string.Format("No files found {0}", directoryFilter.FilterFullPath));
                            htmlTextTextDetails.AppendLine(string.Format("<li>{0} - No files found</li>", directoryFilter.FilterFullPath));
                        }
                    }                    
                }
                htmlTextTextDetails.AppendLine("</ul>");
                if (errorCount > 0)
                    returnState = MonitorStates.Error;
                else if (warningCount > 0)
                    returnState = MonitorStates.Warning;
                else
                    returnState = MonitorStates.Good;
                LastDetailMsg.PlainText = plainTextDetails.ToString().TrimEnd('\r', '\n');
                LastDetailMsg.HtmlText = htmlTextTextDetails.ToString();
            }
            catch (Exception ex)
            {
                LastError = 1;
                LastErrorMsg = ex.Message;
                LastDetailMsg.PlainText = ex.Message;
                LastDetailMsg.HtmlText = ex.Message;
                returnState = MonitorStates.Disabled;
            }
            
            return returnState;
        }
        private string GetTop10FileInfos(List<FileInfo> fileInfos)
        {
            StringBuilder sb = new StringBuilder();
            int topCount = 10;
            for (int i = 0; i < topCount && i < fileInfos.Count; i++)
            {
                FileInfo fi = fileInfos[i];
                sb.AppendLine(string.Format("\t{0} - {1}", fi.Name, FormatFileSize(fi.Length)));
            }
            if (fileInfos.Count > 10)
                sb.AppendLine("...");
            return sb.ToString();
        }
        private string FormatFileSize(long fileSize)
        {
            if (fileSize < 1024)
            {
                return fileSize.ToString() + " bytes";
            }
            else if (fileSize < 1048576)
            {
                return (fileSize / 1024).ToString() + " KB";
            }
            else if (fileSize < 1073741824)
            {
                return (fileSize / 1048576.0).ToString("0.00") + " MB";
            }
            else
            {
                return (fileSize / 1073741824.00).ToString("0.00") + " GB";
            }

        }
        private DirectoryFileInfo GetDirFileInfo(DirectoryFilterEntry directoryFilterEntry)
        {
            DirectoryFileInfo fileInfo;
            fileInfo.FileCount = 0;
            fileInfo.FileSize = 0;
            fileInfo.FileInfos = new List<FileInfo>();
            try
            {
                if (Directory.Exists(directoryFilterEntry.DirectoryPath))
                {
                    foreach (string filePath in System.IO.Directory.GetFiles(directoryFilterEntry.DirectoryPath, directoryFilterEntry.FileFilter))
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(filePath);

                        if ((directoryFilterEntry.FileMaxAgeSec == 0 || fi.LastWriteTime.AddSeconds(directoryFilterEntry.FileMaxAgeSec) > DateTime.Now) &&
                                    (directoryFilterEntry.FileMinAgeSec == 0 || fi.LastWriteTime.AddSeconds(directoryFilterEntry.FileMinAgeSec) < DateTime.Now) &&
                                    (directoryFilterEntry.FileMaxSizeKB == 0 || fi.Length <= (directoryFilterEntry.FileMaxSizeKB * 1024)) &&
                                    (directoryFilterEntry.FileMinSizeKB == 0 || fi.Length >= (directoryFilterEntry.FileMinSizeKB * 1024))
                                    )
                        {
                            fileInfo.FileSize += fi.Length;
                            fileInfo.FileCount += 1;
                            fileInfo.FileInfos.Add(fi);
                        }
                    }
                }
                else
                {
                    LastErrorMsg = "Directory '" + directoryFilterEntry.DirectoryPath + "' does not exist!";
                    fileInfo.FileCount = -1;
                    fileInfo.FileSize = -1;
                }
            }
            catch (Exception ex)
            {
                LastErrorMsg = ex.ToString();
                fileInfo.FileCount = -1;
                fileInfo.FileSize = -1;
            }
            return fileInfo;
        }

        public override void ShowStatusDetails()
        {
            ShowDetails showDetails = new ShowDetails();
            showDetails.DirectorieFilters = directorieFilters;
            showDetails.ShowDetail();
        }
        public override string ConfigureAgent(string config)
        {
            EditConfig editConfig = new EditConfig();
            editConfig.CustomConfig = config;
            if (editConfig.ShowConfig() == System.Windows.Forms.DialogResult.OK)
                config = editConfig.CustomConfig;
            return config;
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.FileCountEmptyConfig_xml;
        }
        public override void ReadConfiguration(XmlDocument config)
        {
            directorieFilters = new List<DirectoryFilterEntry>();
            System.Xml.XmlElement root = config.DocumentElement;
            foreach (System.Xml.XmlElement host in root.SelectNodes("directoryList/directory"))
            {
                DirectoryFilterEntry directoryFilterEntry = new DirectoryFilterEntry();
                directoryFilterEntry.FilterFullPath = host.Attributes.GetNamedItem("directoryPathFilter").Value;
                
                int tmp = 0;
                if (int.TryParse(host.ReadXmlElementAttr("warningFileCountMax", "0"), out tmp))
                    directoryFilterEntry.CountWarningIndicator = tmp;
                if (int.TryParse(host.ReadXmlElementAttr("errorFileCountMax", "0"), out tmp))
                    directoryFilterEntry.CountErrorIndicator = tmp;
                long tmpl;

                if (long.TryParse(host.ReadXmlElementAttr("warningFileSizeMaxKB", "0"), out tmpl))
                    directoryFilterEntry.SizeKBWarningIndicator = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("errorFileSizeMaxKB", "0"), out tmpl))
                    directoryFilterEntry.SizeKBErrorIndicator = tmpl;

                if (long.TryParse(host.ReadXmlElementAttr("fileMaxAgeSec", "0"), out tmpl))
                    directoryFilterEntry.FileMaxAgeSec = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("fileMinAgeSec", "0"), out tmpl))
                    directoryFilterEntry.FileMinAgeSec = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("fileMinSizeKB", "0"), out tmpl))
                    directoryFilterEntry.FileMinSizeKB = tmpl;
                if (long.TryParse(host.ReadXmlElementAttr("fileMaxSizeKB", "0"), out tmpl))
                    directoryFilterEntry.FileMaxSizeKB = tmpl;

                directorieFilters.Add(directoryFilterEntry);
            }
        }
        
    }
}
