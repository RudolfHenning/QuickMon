using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public abstract class CollectorBase : AgentBase, ICollector
    {
        #region ICollector Members
        public abstract MonitorState GetState();
        public abstract ICollectorDetailView GetCollectorDetailView();        
        #endregion

        public virtual bool ShowEditEntry(ref ICollectorConfigEntry entry)
        {
            bool accepted = false;
            IEditConfigEntryWindow editConfig = GetEditConfigEntryWindow();
            editConfig.SelectedEntry = entry;
            //editConfig.SetTitle(title); //"Edit " + Name + " config");
            if (editConfig != null && editConfig.ShowEditEntry() == QuickMonDialogResult.Ok)
            {
                //entry = (ICollectorConfigEntry)editConfig.SelectedEntry;
                entry = editConfig.SelectedEntry;
                accepted = true;
            }
            return accepted;
        }
        public abstract IEditConfigEntryWindow GetEditConfigEntryWindow();
    }
}
