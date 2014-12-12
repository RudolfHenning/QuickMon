﻿using System;
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
            //StringBuilder plainTextDetails = new StringBuilder();
            //StringBuilder htmlTextTextDetails = new StringBuilder();
            int errorCount = 0;
            int warningCount = 0;
            int okCount = 0;
            int totalFileCount = 0;
            int totalEntryCount = 0;
            try
            {
                //htmlTextTextDetails.AppendLine("<ul>");
                FileSystemCollectorConfig currentConfig = (FileSystemCollectorConfig)AgentConfig;
                foreach (FileSystemDirectoryFilterEntry directoryFilter in currentConfig.Entries)
                {
                    DirectoryFileInfo directoryFileInfo = directoryFilter.GetDirFileInfo();
                    CollectorState currentState = directoryFilter.GetState(directoryFileInfo);
                    totalEntryCount++;

                    if (directoryFilter.DirectoryExistOnly && currentState != CollectorState.Good)
                    {
                        errorCount++;
                        returnState.RawDetails = string.Format("{0}", directoryFilter.LastErrorMsg);
                        returnState.HtmlDetails = string.Format("{0}", directoryFilter.LastErrorMsg);

                        //plainTextDetails.AppendLine(directoryFilter.LastErrorMsg);
                        //htmlTextTextDetails.AppendLine("<li>" + directoryFilter.LastErrorMsg + "</li>");
                    }
                    else if (directoryFilter.DirectoryExistOnly)
                    {
                        okCount++;
                        returnState.RawDetails = string.Format("The directory '{0}' exists", directoryFilter.DirectoryPath);
                        returnState.HtmlDetails = string.Format("The directory <i>'{0}'</i> exists", directoryFilter.DirectoryPath);

                        //plainTextDetails.AppendLine(string.Format("The directory '{0}' exists", directoryFilter.DirectoryPath));
                        //htmlTextTextDetails.AppendLine("<li>" + string.Format("The directory '{0}' exists", directoryFilter.DirectoryPath) + "</li>");
                    }
                    else //if (!directoryFilter.DirectoryExistOnly)
                    {
                        if (directoryFileInfo.FileCount == -1)
                        {
                            errorCount++;
                            returnState.RawDetails = string.Format("An error occured while accessing '{0}' - {1}", directoryFilter.FilterFullPath, directoryFilter.LastErrorMsg);
                            returnState.HtmlDetails = string.Format("An error occured while accessing '{0}' <blockquote>{1}</blockquote></li>", directoryFilter.FilterFullPath, directoryFilter.LastErrorMsg);

                            //plainTextDetails.AppendLine(string.Format("An error occured while accessing '{0}'\r\n\t{1}", directoryFilter.FilterFullPath, directoryFilter.LastErrorMsg));
                            //htmlTextTextDetails.AppendLine(string.Format("<li>'{0}' - Error accessing files<blockquote>{1}</blockquote></li>", directoryFilter.FilterFullPath, directoryFilter.LastErrorMsg));
                        }
                        else
                        {
                            totalFileCount += directoryFileInfo.FileCount;
                            if (directoryFileInfo.FileCount > 0)
                            {
                                //htmlTextTextDetails.AppendLine("<li>");
                                if (directoryFilter.LastErrorMsg.Length > 0)
                                {
                                    returnState.RawDetails = string.Format("{0}", directoryFilter.LastErrorMsg);
                                    returnState.HtmlDetails = string.Format("{0}", directoryFilter.LastErrorMsg);
                                    //plainTextDetails.AppendLine(directoryFilter.LastErrorMsg);
                                    //htmlTextTextDetails.AppendLine(directoryFilter.LastErrorMsg);
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

                                //plainTextDetails.AppendLine(GetTop10FileInfos(directoryFileInfo.FileInfos));
                                //htmlTextTextDetails.AppendLine("<blockquote>");
                                //htmlTextTextDetails.AppendLine(GetTop10FileInfos(directoryFileInfo.FileInfos).Replace("\r\n", "<br/>"));
                                //htmlTextTextDetails.AppendLine("</blockquote></li>");
                            }
                            else
                            {
                                returnState.RawDetails = string.Format("No files found '{0}'", directoryFilter.FilterFullPath);
                                returnState.HtmlDetails = string.Format("No files found '{0}'", directoryFilter.FilterFullPath);
                                //plainTextDetails.AppendLine(string.Format("No files found '{0}'", directoryFilter.FilterFullPath));
                                //htmlTextTextDetails.AppendLine(string.Format("<li>'{0}' - No files found</li>", directoryFilter.FilterFullPath));
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
                    //else
                    //{
                    //    okCount++;
                    //}
                }
                //htmlTextTextDetails.AppendLine("</ul>");
                if (errorCount > 0 && totalEntryCount == errorCount) // any errors
                    returnState.State = CollectorState.Error;
                else if (okCount != totalEntryCount) //any warnings
                    returnState.State = CollectorState.Warning;
                else
                    returnState.State = CollectorState.Good;

                //returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                //returnState.HtmlDetails = htmlTextTextDetails.ToString();
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
    }
}
