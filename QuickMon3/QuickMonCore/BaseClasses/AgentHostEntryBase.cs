using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    /// <summary>
    /// Base class for CollectorEntry and NotifierEntry
    /// </summary>
    public abstract class AgentHostEntryBase
    {
        public AgentHostEntryBase()
        {
            ServiceWindows = new ServiceWindows();
            ServiceWindows.CreateFromConfig("<serviceWindows/>");
        }

        #region General properties
        public string Name { get; set; }
        /// <summary>
        /// Any object you wish to link with this instance
        /// </summary>
        public object Tag { get; set; }
        #endregion

        #region Is this agent entry enabled now
        /// <summary>
        /// User/config based setting to disable this agent Entry
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// List of service windows when this agent can operate
        /// </summary>
        public ServiceWindows ServiceWindows { get; set; }
        public bool IsEnabledNow()
        {
            if (Enabled)
            {
                if (ServiceWindows.IsInTimeWindow())
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        #endregion

        #region Dynamic Config Variables
        public List<ConfigVariable> ConfigVariables { get; set; }
        #endregion
    }
}
