using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface IAgentConfigEntryEditWindow
    {
        ICollectorConfigEntry SelectedEntry { get; set; }
        QuickMonDialogResult ShowEditEntry();
    }
}
