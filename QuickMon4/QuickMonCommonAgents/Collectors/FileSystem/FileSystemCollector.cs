using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("File System Collector"), Category("General")]
    public class FileSystemCollector : CollectorAgentBase
    {
        public FileSystemCollector()
        {
            AgentConfig = new FileSystemCollectorConfig();
        }

        public override MonitorState GetState()
        {
            MonitorState returnState = new MonitorState();
            int errorCount = 0;
            int warningCount = 0;
            int okCount = 0;
            int totalFileCount = 0;
            int totalEntryCount = 0;
            try
            {
                FileSystemCollectorConfig currentConfig = (FileSystemCollectorConfig)AgentConfig;
                foreach (FileSystemDirectoryFilterEntry directoryFilter in currentConfig.Entries)
                {
                    DirectoryFileInfo directoryFileInfo = directoryFilter.GetFileListByFilters();
                    CollectorState currentState = directoryFilter.GetState(directoryFileInfo);
                    totalEntryCount++;

                    if (directoryFilter.DirectoryExistOnly && currentState != CollectorState.Good)
                    {
                        errorCount++;
                        returnState.RawDetails = string.Format("{0}", directoryFilter.LastErrorMsg);
                        returnState.HtmlDetails = string.Format("{0}", directoryFilter.LastErrorMsg);
                    }
                    else if (directoryFilter.DirectoryExistOnly)
                    {
                        okCount++;
                        returnState.RawDetails = string.Format("The directory '{0}' exists", directoryFilter.DirectoryPath);
                        returnState.HtmlDetails = string.Format("The directory <i>'{0}'</i> exists", directoryFilter.DirectoryPath);
                    }
                    else 
                    {
                        if (directoryFileInfo.FileCount == -1)
                        {
                            errorCount++;
                            returnState.RawDetails = string.Format("An error occured while accessing '{0}' - {1}", directoryFilter.FilterFullPath, directoryFilter.LastErrorMsg);
                            returnState.HtmlDetails = string.Format("An error occured while accessing '{0}' <blockquote>{1}</blockquote></li>", directoryFilter.FilterFullPath, directoryFilter.LastErrorMsg);
                        }
                        else
                        {
                            totalFileCount += directoryFileInfo.FileCount;
                            if (directoryFileInfo.FileCount > 0)
                            {
                                if (directoryFilter.LastErrorMsg.Length > 0)
                                {
                                    returnState.RawDetails = string.Format("{0}", directoryFilter.LastErrorMsg);
                                    returnState.HtmlDetails = string.Format("{0}", directoryFilter.LastErrorMsg);
                                }
                                else
                                {
                                     int topCount = 10;
                                     for (int i = 0; i < topCount && i < directoryFileInfo.FileInfos.Count; i++)
                                     {
                                         FileInfo fi = directoryFileInfo.FileInfos[i];
                                         returnState.ChildStates.Add(
                                            new MonitorState()
                                            {
                                                State = CollectorState.Error,
                                                RawDetails = string.Format("{0} - {1}", fi.Name, FormatUtils.FormatFileSize(fi.Length)),
                                                HtmlDetails = string.Format("{0} - {1}", fi.Name, FormatUtils.FormatFileSize(fi.Length)),
                                            });
                                     }
                                }
                            }
                            else
                            {
                                returnState.RawDetails = string.Format("No files found '{0}'", directoryFilter.FilterFullPath);
                                returnState.HtmlDetails = string.Format("No files found '{0}'", directoryFilter.FilterFullPath);
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
                }
                if (errorCount > 0 && totalEntryCount == errorCount) // any errors
                    returnState.State = CollectorState.Error;
                else if (okCount != totalEntryCount) //any warnings
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;

                returnState.CurrentValue = totalFileCount;
            }
            catch (Exception ex)
            {
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
    }
}
