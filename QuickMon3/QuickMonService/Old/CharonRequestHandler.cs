using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace QuickMon
{
    public class CharonRequestHandler
    {
        private TcpClient clientSocket;
        private NetworkStream networkStream = null;
        int clientNo = 0;
        public CharonRequestHandler(TcpClient clientConnected, int clientNo)
        {
            this.clientSocket = clientConnected;
            this.clientNo = clientNo;
        }

        #region Events
        public event RelayMessage InfoMessage;
        private void RaiseInfoMessage(string message)
        {
            if (InfoMessage != null)
                InfoMessage(message);
        }
        public event RelayMessage ErrorMessage;
        private void RaiseErrorMessage(string message)
        {
            if (ErrorMessage != null)
                ErrorMessage(message);
        }
        public event RelayMessage DisplayMonitorPackName;
        private void RaiseDisplayMonitorPackName(string message)
        {
            if (DisplayMonitorPackName != null)
                DisplayMonitorPackName(message);
        } 
        #endregion

        public void StartClient()
        {
            networkStream = clientSocket.GetStream();
            WaitForRequest();
        }
        private void WaitForRequest()
        {
            byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
            try
            {
                networkStream.BeginRead(buffer, 0, buffer.Length, ReadCallback, buffer);
            }
            catch (Exception ex)
            {
                if (ex is System.IO.IOException && ex.Message.Contains("Unable to read data from the transport connection: An established connection was aborted by the software in your host machine"))
                {
                    RaiseInfoMessage(string.Format("Client {0} disconnecting.", clientNo));
                }
                else
                    RaiseErrorMessage(string.Format("Client {0} error: {1}", clientNo, ex));
            }
        }
        private void ReadCallback(IAsyncResult result)
        {
            try
            {
                using (NetworkStream networkStream = clientSocket.GetStream())
                {
                    int read = networkStream.EndRead(result);
                    MonitorState packResult = new MonitorState() { State = CollectorState.NotAvailable, RawDetails = "", HtmlDetails = "" };

                    string data = "";
                    if (read > 0)
                    {
                        byte[] buffer = result.AsyncState as byte[];
                        data = Encoding.UTF8.GetString(buffer, 0, read);

                        //do the job with the data here
                        if (data.StartsWith("<monitorPack") && data.EndsWith("</monitorPack>"))
                        {
                            MonitorPack m = new MonitorPack();
                            StringBuilder plainTextDetails = new StringBuilder();
                            StringBuilder htmlTextTextDetails = new StringBuilder();

                            m.RaiseMonitorPackError += m_RaiseMonitorPackError;
                            m.LoadXml(data);
                            RaiseDisplayMonitorPackName(m.Name);
                            packResult.State = m.RefreshStates();
                            htmlTextTextDetails.AppendLine("<ul>");
                            foreach (CollectorEntry ce in (from c in m.Collectors
                                                           where c.CurrentState != null
                                                           select c))
                            {
                                if (ce.CurrentState == null)
                                {
                                    plainTextDetails.AppendLine(string.Format("\tCollector: {0}, State: N/A", ce.Name));
                                    htmlTextTextDetails.AppendLine(string.Format("<li>Collector: {0}, State: N/A</li>", ce.Name));
                                }
                                else if (ce.CurrentState.State == CollectorState.Good)
                                {
                                    plainTextDetails.AppendLine(string.Format("\tCollector: {0}, State: {1}", ce.Name, ce.CurrentState.State));
                                    htmlTextTextDetails.AppendLine(string.Format("<li>Collector: {0}, State: {1}</li>", ce.Name, ce.CurrentState.State));
                                }
                                else 
                                {
                                    plainTextDetails.AppendLine(string.Format("\tCollector: {0}, State: {1}", ce.Name, ce.CurrentState.State));
                                    if (ce.CurrentState.RawDetails != null && ce.CurrentState.RawDetails.Length > 0)
                                        plainTextDetails.AppendLine(string.Format("\t\tDetails: {0}", ce.CurrentState.RawDetails.Replace("\r\n","\r\n\t\t\t")));
                                    htmlTextTextDetails.AppendLine(string.Format("<li>Collector: {0}, State: {1}</li>", ce.Name, ce.CurrentState.State));
                                    if (ce.CurrentState.HtmlDetails != null && ce.CurrentState.HtmlDetails.Length > 0)
                                        htmlTextTextDetails.AppendLine(string.Format("<br/>Details: {0}", ce.CurrentState.HtmlDetails));
                                }
                                
                            }
                            htmlTextTextDetails.AppendLine("</ul>");
                            packResult.RawDetails = plainTextDetails.ToString();
                            packResult.HtmlDetails = htmlTextTextDetails.ToString();

                            RaiseInfoMessage(string.Format("MonitorPack: '{0}' - state: {1}", m.Name, packResult.State));
                            m = null;
                        }
                        else
                        {
                            RaiseErrorMessage("Input request data invalid!\r\n" + summarizeErrData(data));
                            packResult.State = CollectorState.Error;
                            packResult.RawDetails = "Input request data invalid!\r\n" + summarizeErrData(data);
                            packResult.HtmlDetails = "Input request data invalid!\r\n" + summarizeErrData(data.Replace("<", "&lt;").Replace(">", "&gt;"));
                        }

                        //send the data back to client.
                        Byte[] sendBytes = Encoding.UTF8.GetBytes(packResult.ToXml());
                        networkStream.Write(sendBytes, 0, sendBytes.Length);
                        networkStream.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                if ((ex is System.IO.IOException && ex.Message.Contains("Unable to read data from the transport connection: An existing connection was forcibly closed by the remote host")) ||
                    ex is System.InvalidOperationException && ex.Message.Contains("The operation is not allowed on non-connected sockets"))
                {
                    RaiseInfoMessage(string.Format("Client {0} disconnecting.", clientNo));
                }
                else
                {
                    if (clientSocket != null && clientSocket.Client != null && clientSocket.Client.RemoteEndPoint is System.Net.IPEndPoint)
                        RaiseErrorMessage(string.Format("Error processing request from {0}\r\nError: {1}", ((System.Net.IPEndPoint)clientSocket.Client.RemoteEndPoint).Address.ToString(), ex));
                    else
                        RaiseErrorMessage(string.Format("Error from unknown client: {0}", ex));
                }
            }
        }

        private string summarizeErrData(string data)
        {
            if (data == null || data.Length == 0)
                return "";
            else if (data.Length < 256)
            {
                return data + "(" + data.Length + " chars)";
            }
            else
                return data.Substring(0, 100) + "..." + data.Substring(data.Length - 100, 100) + "(" + data.Length + " chars)";

        }

        private void m_RaiseMonitorPackError(string errorMessage)
        {
            RaiseErrorMessage(string.Format("Client {0} Monitor pack error: {1}", clientNo, errorMessage));
        }
    }
}
