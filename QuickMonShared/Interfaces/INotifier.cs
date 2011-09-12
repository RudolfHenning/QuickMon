using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface INotifier : IAgent
    {
        void RecordMessage(AlertLevel alertLevel, string collectorType, string category, MonitorStates oldState, MonitorStates newState, CollectorMessage collectorMessage);
        /// <summary>
        /// Is there a built in Viewer?
        /// e.g. SMTP does not have a viewer but Database does
        /// </summary>
        bool HasViewer { get; }
        void OpenViewer();
    }
}
