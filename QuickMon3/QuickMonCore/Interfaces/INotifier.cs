using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface INotifier : IAgent
    {
        void RecordMessage(AlertRaised alertRaised);
        //void RecordMessage(AlertLevel alertLevel, CollectorEntry collectorEntry);
        //void RecordMessage(AlertLevel alertLevel, string generalMessage);
        /// <summary>
        /// Is there a built in Viewer?
        /// e.g. SMTP does not have a viewer but Database does
        /// </summary>
        bool HasViewer { get; }
        INotivierViewer GetNotivierViewer();
        bool ShowEditConfiguration(string title);
    }    
}
