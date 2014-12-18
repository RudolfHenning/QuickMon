using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.UI
{
    public interface IWinFormsUI
    {
        /// <summary>
        /// Agent type it can edit
        /// </summary>
        string AgentType { get; set; }
        /// <summary>
        /// Get or Set the agent configuration
        /// </summary>
        string SelectedConfig { get; set; }
        /// <summary>
        /// Show the edit dialogbox
        /// </summary>
        /// <returns></returns>
        bool EditAgent();
        /// <summary>
        /// Indicates if this UI class has a detail window
        /// </summary>
        bool HasDetailView { get; }
        /// <summary>
        /// When called it show custom detail Window for the type of agent.
        /// </summary>
        /// <returns></returns>
        void ShowCurrentDetails();
    }
}
