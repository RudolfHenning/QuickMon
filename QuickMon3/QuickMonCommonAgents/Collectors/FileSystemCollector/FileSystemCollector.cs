using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("File System Collector"), Category("General")]
    public class FileSystemCollector : CollectorBase
    {
        public FileSystemCollector()
        {
            AgentConfig = new FileSystemCollectorConfig();
        }
        public override MonitorState GetState()
        {
            MonitorState returnState = new MonitorState();
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            int errorCount = 0;
            int warningCount = 0;
            int okCount = 0;
            int totalFileCount = 0;
            int totalEntryCount = 0;
            try
            {
                htmlTextTextDetails.AppendLine("<ul>");
                FileSystemCollectorConfig currentConfig = (FileSystemCollectorConfig)AgentConfig;
                foreach (FileSystemDirectoryFilterEntry directoryFilter in currentConfig.Entries)
                {
                    DirectoryFileInfo directoryFileInfo = directoryFilter.GetDirFileInfo();
                    CollectorState currentState = directoryFilter.GetState(directoryFileInfo);
                    totalEntryCount++;

                    if (directoryFilter.DirectoryExistOnly && currentState != CollectorState.Good)
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
                            if (currentState == CollectorState.Warning)
                            {
                                warningCount++;
                            }
                            else if (currentState == CollectorState.Error)
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
                if (errorCount > 0 && totalEntryCount == errorCount) // any errors
                    returnState.State = CollectorState.Error;
                else if (okCount != totalEntryCount) //any warnings
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;

                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();
                returnState.CurrentValue = totalFileCount;
            }
            catch (Exception ex)
            {
                //LastError = 1;
                //LastErrorMsg = ex.Message;
                returnState.RawDetails = ex.Message;
                returnState.HtmlDetails = ex.Message;
                returnState.State = CollectorState.Error;
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
        public override ICollectorDetailView GetCollectorDetailView()
        {
            return new FileSystemCollectorViewDetails();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.FileSystemCollectorDefaultConfig;
        }
        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new FileSystemCollectorEditFilterEntry();
        }
    }
}
