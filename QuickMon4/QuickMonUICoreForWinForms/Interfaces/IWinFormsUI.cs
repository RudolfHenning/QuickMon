using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.UI
{
    public interface IWinFormsUI
    {
        /// <summary>
        /// Specify the Agent type this implemetation can edit.
        /// </summary>
        string AgentType { get; }
        /// <summary>
        /// Name of agent (for editing)
        /// </summary>
        string AgentName { get; set; }
        /// <summary>
        /// Is agent enabled (for editing)
        /// </summary>
        bool AgentEnabled { get; set; }
        /// <summary>
        /// Xml config to edit or return
        /// </summary>
        string SelectedAgentConfig { get; set; }
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
