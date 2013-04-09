using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public interface IAgent
    {
        string Name { get; set; }
        int LastError { get; set; }
        string LastErrorMsg { get; set; }

        /// <summary>
        /// Display a window 
        /// </summary>
        /// <param name="config">Existing Xml configuration</param>
        /// <returns>Changed Xml configuration</returns>
        string ConfigureAgent(string config);
        string GetDefaultOrEmptyConfigString();
        void ReadConfiguration(XmlDocument configDoc);
        //In case some agents needs to close some resources
        void Close();
    }
}
