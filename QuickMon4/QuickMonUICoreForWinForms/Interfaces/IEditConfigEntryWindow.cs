using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface IAgentConfigEntryEditWindow
    {
        IAgentConfigEntry SelectedEntry { get; set; }
        QuickMonDialogResult ShowEditEntry();
    }
    public interface ICollectorConfigEntryEditWindow
    {
        ICollectorConfigEntry SelectedEntry { get; set; }
        QuickMonDialogResult ShowEditEntry();        
    }    
}
