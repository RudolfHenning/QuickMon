using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface INotifier : IAgent
    {
        void RecordMessage(AlertRaised alertRaised);
        /// <summary>
        /// Indication if the implemented class/component can run Attended (with UI) or UnAttended (no UI like service) or both
        /// Default should be Both
        /// </summary>
        AttendedOption AttendedRunOption { get; }
    }   
}
