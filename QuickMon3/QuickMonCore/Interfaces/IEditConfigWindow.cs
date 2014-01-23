using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public interface IEditConfigWindow
    {
        IAgentConfig SelectedConfig { get; set; }
        DialogResult ShowConfig();
        void SetTitle(string title);
    }
    public interface IEditConfigEntryWindow
    {
        ICollectorConfigEntry SelectedEntry { get; set; }
        DialogResult ShowEditEntry();
        //void SetTitle(string title);
    }
}
