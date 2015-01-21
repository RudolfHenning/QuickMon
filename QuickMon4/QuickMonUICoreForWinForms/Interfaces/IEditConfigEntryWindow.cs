using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface IAgentDetailWindow
    {
        IAgent SelectedAgent { get; set; }
        void ShowDetailWindow();
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
