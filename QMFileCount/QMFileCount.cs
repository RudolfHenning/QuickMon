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

        internal List<DirectoryFilterEntry> DirectorieFilters = new List<DirectoryFilterEntry>();

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
            int totalFileCount = 0;
            try
            {
                htmlTextTextDetails.AppendLine("<ul>");
                foreach (DirectoryFilterEntry directoryFilter in DirectorieFilters)
                {
                    DirectoryFileInfo directoryFileInfo = directoryFilter.GetDirFileInfo();
                    MonitorStates currentState = directoryFilter.GetState(directoryFileInfo);

                    if (directoryFilter.DirectoryExistOnly && currentState != MonitorStates.Good)
                    {
                        errorCount++;
                        plainTextDetails.AppendLine(directoryFilter.LastErrorMsg);
                        htmlTextTextDetails.AppendLine("<li>" + directoryFilter.LastErrorMsg + "</li>");
                    }
                    else if (!directoryFilter.DirectoryExistOnly)
                    {
                        if (directoryFileInfo.FileCount == -1)
                        {
                            errorCount++;
                            plainTextDetails.AppendLine(string.Format("An error occured while accessing '{0}'\r\n\t{1}", directoryFilter.FilterFullPath, directoryFilter.LastErrorMsg));
                            htmlTextTextDetails.AppendLine(string.Format("<li>'{0}' - Error accessing files<blockquote>{1}</blockquote></li>", directoryFilter.FilterFullPath, directoryFilter.LastErrorMsg));
                        }
                        else 
                        {
                            totalFileCount += directoryFileInfo.FileCount;
                            if (directoryFileInfo.FileCount > 0)
                            {
                                htmlTextTextDetails.AppendLine("<li>");
                                if (directoryFilter.LastErrorMsg.Length > 0)
                                {
                                    plainTextDetails.AppendLine(directoryFilter.LastErrorMsg);
                                    htmlTextTextDetails.AppendLine(directoryFilter.LastErrorMsg);
                                }
                                
                                plainTextDetails.AppendLine(GetTop10FileInfos(directoryFileInfo.FileInfos));
                                htmlTextTextDetails.AppendLine("<blockquote>");
                                htmlTextTextDetails.AppendLine(GetTop10FileInfos(directoryFileInfo.FileInfos).Replace("\r\n", "<br/>"));
                                htmlTextTextDetails.AppendLine("</blockquote></li>");
                            }
                            else
                            {
                                plainTextDetails.AppendLine(string.Format("No files found '{0}'", directoryFilter.FilterFullPath));
                                htmlTextTextDetails.AppendLine(string.Format("<li>'{0}' - No files found</li>", directoryFilter.FilterFullPath));
                            }
                            if (currentState == MonitorStates.Warning)
                            {
                                warningCount++;                                
                            }
                            else if (currentState == MonitorStates.Error)
                            {
                                errorCount++;
                            }
                            else
                            {
                                okCount++;
                            }
                        }
                    }
                    else
                    {
                        okCount++;
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
                LastDetailMsg.LastValue = totalFileCount;
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
                sb.AppendLine(string.Format("\t{0} - {1}", fi.Name, FormatUtils.FormatFileSize(fi.Length)));
            }
            if (fileInfos.Count > 10)
                sb.AppendLine("...");
            return sb.ToString();
        }
        private DirectoryFileInfo GetDirFileInfo(DirectoryFilterEntry directoryFilterEntry)
        {
            DirectoryFileInfo fileInfo;
            fileInfo.Exists = false;
            fileInfo.FileCount = 0;
            fileInfo.FileSize = 0;
            fileInfo.FileInfos = new List<FileInfo>();
            try
            {
                if (Directory.Exists(directoryFilterEntry.DirectoryPath))
                {
                    fileInfo.Exists = true;
                    if (!directoryFilterEntry.DirectoryExistOnly)
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
                }
                else
                {
                    fileInfo.Exists = false;
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

        public override void ShowStatusDetails(string collectorName)
        {
            ShowDetails showDetails = new ShowDetails();
            showDetails.DirectorieFilters = DirectorieFilters;
            showDetails.Text = "Show details - " + collectorName;
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
            DirectorieFilters = new List<DirectoryFilterEntry>();
            System.Xml.XmlElement root = config.DocumentElement;
            foreach (System.Xml.XmlElement host in root.SelectNodes("directoryList/directory"))
            {
                DirectoryFilterEntry directoryFilterEntry = new DirectoryFilterEntry();
                directoryFilterEntry.FilterFullPath = host.Attributes.GetNamedItem("directoryPathFilter").Value;
                directoryFilterEntry.DirectoryExistOnly = bool.Parse(host.ReadXmlElementAttr("testDirectoryExistOnly", "False"));

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

                DirectorieFilters.Add(directoryFilterEntry);
            }
        }

        public override ICollectorDetailView GetCollectorDetailView()
        {
            return (ICollectorDetailView)(new ShowDetails());
        }
    }
}
