using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public abstract class AgentBase : IAgent
    {
        #region IAgent Members
        public string Name { get;  set; }
        public IAgentConfig AgentConfig { get; set; }

        public virtual bool ShowEditConfiguration(string title)
        {
            bool accepted = false;
            IEditConfigWindow editConfig = GetEditConfigWindow();
            editConfig.SelectedConfig = AgentConfig;
            editConfig.SetTitle(title); //"Edit " + Name + " config");
            if (editConfig != null && editConfig.ShowConfig() == System.Windows.Forms.DialogResult.OK)
            {
                AgentConfig = editConfig.SelectedConfig;
                accepted = true;
            }
            return accepted;
        }
        public virtual bool ShowEditEntry(ref ICollectorConfigEntry entry)
        {
            bool accepted = false;
            IEditConfigEntryWindow editConfig = GetEditConfigEntryWindow();
            editConfig.SelectedEntry = entry;
            //editConfig.SetTitle(title); //"Edit " + Name + " config");
            if (editConfig != null && editConfig.ShowEditEntry() == System.Windows.Forms.DialogResult.OK)
            {
                entry = (ICollectorConfigEntry)editConfig.SelectedEntry;
                accepted = true;
            }
            return accepted;
        }
        public abstract IEditConfigEntryWindow GetEditConfigEntryWindow();
        public abstract IEditConfigWindow GetEditConfigWindow();
        public abstract string GetDefaultOrEmptyConfigString();
        public virtual void SetConfigurationFromXmlString(string configurationString)
        {
            AgentConfig.ReadConfiguration(configurationString);
        }
        public virtual void Close() { }
        #endregion
    }
}
