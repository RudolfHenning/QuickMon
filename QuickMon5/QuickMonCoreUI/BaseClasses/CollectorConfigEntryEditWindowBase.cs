using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public class CollectorConfigEntryEditWindowBase : Form, ICollectorConfigEntryEditWindow
    {
        #region ICollectorConfigEntryEditWindow
        public ICollectorConfigEntry SelectedEntry { get; set; }
        public QuickMonDialogResult ShowEditEntry()
        {
            return (QuickMonDialogResult)ShowDialog();
        }
        public List<ConfigVariable> ConfigVariables { get; set; } = new List<ConfigVariable>();
        #endregion

        public string ApplyConfigVarsOnField(string field)
        {
            List<ConfigVariable> allConfigVars = new List<ConfigVariable>();
            //applying its own first
            foreach (ConfigVariable cv in ConfigVariables)
            {
                ConfigVariable existingCV = (from ConfigVariable c in allConfigVars
                                             where c.FindValue == cv.FindValue
                                             select c).FirstOrDefault();
                if (existingCV == null)
                {
                    allConfigVars.Add(cv.Clone());
                }
            }
            return allConfigVars.ApplyOn(field);            
        }
    }
}
