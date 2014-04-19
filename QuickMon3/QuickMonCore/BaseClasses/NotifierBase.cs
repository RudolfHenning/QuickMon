using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Notifiers
{
    public abstract class NotifierBase : AgentBase, INotifier
    {
        #region INotifier Members
        public abstract void RecordMessage(AlertRaised alertRaised);
        public abstract bool HasViewer { get; }
        public abstract INotivierViewer GetNotivierViewer();
        /// <summary>
        /// Not used anymore (at least for Collectors)
        /// </summary>
        /// <returns></returns>
        public abstract IEditConfigWindow GetEditConfigWindow();
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
        #endregion
    }
}
