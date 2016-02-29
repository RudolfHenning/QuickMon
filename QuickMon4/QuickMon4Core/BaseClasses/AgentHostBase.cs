using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public abstract class AgentHostBase
    {
        public AgentHostBase()
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
        internal bool InServiceWindow { get; set; }
        public bool IsEnabledNow()
        {
            if (Enabled)
            {
                InServiceWindow = !ServiceWindows.IsInTimeWindow();
                if (!InServiceWindow)
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
