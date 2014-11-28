using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public abstract class CollectorAgentBase : AgentBase
    {
        #region ICollector Members
        public abstract MonitorState GetState();
        //public abstract ICollectorDetailView GetCollectorDetailView();
        #endregion

        //public virtual bool ShowEditEntry(ref ICollectorConfigEntry entry)
        //{
        //    bool accepted = false;
        //    //IEditConfigEntryWindow editConfig = GetEditConfigEntryWindow();
        //    //editConfig.SelectedEntry = entry;
        //    //if (editConfig != null && editConfig.ShowEditEntry() == QuickMonDialogResult.Ok)
        //    //{
        //    //    entry = editConfig.SelectedEntry;
        //    //    accepted = true;
        //    //}
        //    return accepted;
        //}
        //public abstract IAgentConfigEntryEditWindow GetEditConfigEntryWindow();
    }
}
