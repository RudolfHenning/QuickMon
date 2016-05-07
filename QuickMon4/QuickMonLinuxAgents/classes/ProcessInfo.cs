using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Linux
{
    public class ProcessInfo
    {
        public ProcessInfo()
        {
        }
        //USER       PID %CPU %MEM    VSZ   RSS TTY      STAT START   TIME COMMAND
        public string User { get; set; }
        public long PID { get; set; }
        public double percCPU { get; set; }
        public double percMEM { get; set; }
        public long VSZ { get; set; }
        public long RSS { get; set; }
        public string STAT { get; set; }
        public string StartTime { get; set; }
        public string CommandLine { get; set; }
        public string ProcessName { get; set; }
        
        public static List<ProcessInfo> FromPsAux(Renci.SshNet.SshClient sshClient)
        {
            return FromPsAux(sshClient.RunCommand("ps aux").Result);
        }

        /// <summary>
        /// Parsing the output of 'ps aux'
        /// </summary>
        /// <param name="input">output of 'ps aux'</param>
        /// <returns></returns>
        public static List<ProcessInfo> FromPsAux(string input)
        {
            List<ProcessInfo> processes = new List<ProcessInfo>();

            string[] lines = input.Split(new string[] { "\r", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line.Trim().Length > 0 && !line.StartsWith("USER"))
                {
                    string[] values = line.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    ProcessInfo p = new ProcessInfo();
                    p.User = values[0];
                    p.PID = Parsers.ParseLong(values[1]);
                    p.percCPU = Parsers.ParseDouble(values[2]);
                    p.percMEM = Parsers.ParseDouble(values[3]);
                    p.VSZ = Parsers.ParseLong(values[4]);
                    p.RSS = Parsers.ParseLong(values[5]);
                    p.STAT = values[7];
                    p.StartTime = values[8] + " " + values[9];
                    p.CommandLine = values[10];
                    p.ProcessName = values[10];
                    if (p.ProcessName.Contains('/'))
                    {
                        p.ProcessName = p.ProcessName.Substring(p.ProcessName.LastIndexOf('/') + 1);
                    }
                    if (values.Length > 11)
                    {
                        for (int i = 11; i < values.Length; i++)
                        {
                            p.CommandLine += " " + values[i];
                        }
                    }
                    if (!p.CommandLine.StartsWith("["))
                    {
                        processes.Add(p);
                    }
                }
            }
            return processes;
        }
    }
}
