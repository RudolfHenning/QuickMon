using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface IEditConfigWindow
    {
        IAgentConfig SelectedConfig { get; set; }
        QuickMonDialogResult ShowConfig();
        void SetTitle(string title);
    }
    public interface IEditConfigEntryWindow
    {
        ICollectorConfigEntry SelectedEntry { get; set; }
        QuickMonDialogResult ShowEditEntry();
    }
}
