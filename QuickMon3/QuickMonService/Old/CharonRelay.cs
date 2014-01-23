using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace QuickMon
{
    public delegate void RelayMessage(string message);
    public class CharonRelay
    {
        private int clientCount = 1;
        private TcpListener serverListener;

        public bool IsRunning { get; set; }

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
        #endregion

        private void RaiseDisplayMonitorPackName(string message)
        {
            if (DisplayMonitorPackName != null)
                DisplayMonitorPackName(message);
        }
        public void StartRelay(string hostName, int hostPort)
        {
            IsRunning = true;
            RaiseInfoMessage("Opening server listener");

            System.Net.IPAddress localIP = (from a in System.Net.Dns.GetHostAddresses(hostName)
                                            where a.AddressFamily == AddressFamily.InterNetwork
                                            select a).FirstOrDefault();
            serverListener = new TcpListener(localIP, hostPort);
            serverListener.Start();

            RaiseInfoMessage("Waiting for connections");
            WaitForClientConnect();
        }

        private void WaitForClientConnect()
        {
            if (IsRunning)
                serverListener.BeginAcceptTcpClient(new System.AsyncCallback(OnClientConnect), serverListener);
        }

        private void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                TcpClient clientSocket = default(TcpClient);                
                clientSocket = serverListener.EndAcceptTcpClient(asyn);
                clientSocket.SendBufferSize = Properties.Settings.Default.RemoteHostSendBufferSize;
                clientSocket.ReceiveBufferSize = Properties.Settings.Default.RemoteHostReceiveBufferSize;
                clientSocket.ReceiveTimeout = Properties.Settings.Default.RemoteHostReceiveTimeOut;
                clientSocket.SendTimeout = Properties.Settings.Default.RemoteHostSendTimeOut;
                if (clientSocket.Client.RemoteEndPoint is System.Net.IPEndPoint)
                    RaiseInfoMessage(string.Format("Client connecting from " + ((System.Net.IPEndPoint)clientSocket.Client.RemoteEndPoint).Address.ToString()));
                CharonRequestHandler clientReq = new CharonRequestHandler(clientSocket, clientCount);
                clientReq.InfoMessage += clientReq_InfoMessage;
                clientReq.ErrorMessage += clientReq_ErrorMessage;
                clientReq.DisplayMonitorPackName += clientReq_DisplayMonitorPackName;
                clientCount++;
                clientReq.StartClient();
            }
            catch (Exception se)
            {
                RaiseErrorMessage(se.ToString());
            }

            WaitForClientConnect();
        }

        private void clientReq_DisplayMonitorPackName(string name)
        {
            RaiseDisplayMonitorPackName(name);
        }

        private void clientReq_ErrorMessage(string message)
        {
            RaiseErrorMessage(message);
        }

        private void clientReq_InfoMessage(string message)
        {
            RaiseInfoMessage(message);
        }
    }
}
