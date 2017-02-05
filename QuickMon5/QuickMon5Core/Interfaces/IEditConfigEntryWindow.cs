using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface IAgentDetailWindow
    {
        IAgent SelectedAgent { get; set; }
        //bool RemoteAgentHostEnabled { get; set; }
        //string RemoteAgentHostAddress { get; set; }
        //int RemoteAgentHostPort { get; set; }
        void ShowDetailWindow();
    }
    public interface ICollectorDetailWindow : IAgentDetailWindow
    {
        bool RemoteAgentHostEnabled { get; set; }
        string RemoteAgentHostAddress { get; set; }
        int RemoteAgentHostPort { get; set; }
    }

    public interface IAgentConfigEntryEditWindow
    {
        IAgentConfig SelectedEntry { get; set; }
        QuickMonDialogResult ShowEditEntry();
    }
    public interface ICollectorConfigEntryEditWindow
    {
        ICollectorConfigEntry SelectedEntry { get; set; }
        QuickMonDialogResult ShowEditEntry();
    }
}
