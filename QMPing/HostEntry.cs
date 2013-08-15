using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class PingResult
    {
        public bool Success { get; set; }
        public int PingTime { get; set; }
        public string LastErrorMsg { get; set; }
    }

    public class HostEntry
    {
        private string hostName = "";
        public string HostName { get { return hostName; } set { hostName = value; } }
        private string description = "";
        public string Description { get { return description; } set { description = value; } }
        private int maxTime = 1000;
        public int MaxTime { get { return maxTime; } set { maxTime = value; } }
        private int timeOut = 5000;
        public int TimeOut { get { return timeOut; } set { timeOut = value; } }
        public PingResult LastPingResult { get; set; }

        public PingResult Ping()
        {
            PingResult result = new PingResult();
            result.Success = false;
            result.PingTime = -1;
            result.LastErrorMsg = "";
            try
            {
                using (System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping())
                {
                    System.Net.NetworkInformation.PingReply reply = ping.Send(HostName, TimeOut);
                    if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        result.PingTime = Convert.ToInt32(reply.RoundtripTime);
                        result.Success = true;
                        if (reply.Address != null)
                            result.LastErrorMsg = reply.Address.ToString();
                    }
                    else // if (reply.Status == System.Net.NetworkInformation.IPStatus.TimedOut)
                    {
                        result.PingTime = int.MaxValue;
                        result.LastErrorMsg = "Timed out";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.PingTime = -1;
                result.LastErrorMsg = ex.Message;
            }
            LastPingResult = result;
            return result;
        }

        public MonitorStates GetState(PingResult pingResult)
        {
            MonitorStates result = MonitorStates.Good;
            if (pingResult.Success)
            {
                if (pingResult.PingTime > TimeOut)
                {
                    result = MonitorStates.Error;
                }
                else if (pingResult.PingTime > MaxTime)
                {
                    result = MonitorStates.Warning;
                }
                else
                {
                    result = MonitorStates.Good;
                }
            }
            else
            {
                result = MonitorStates.Error;
            }
            return result;
        }
    }
}
