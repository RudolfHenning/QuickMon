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
            if (ConfigVariables == null)
                ConfigVariables = new List<ConfigVariable>();
            return ConfigVariables.ApplyOn(field);

            //List<ConfigVariable> allConfigVars = new List<ConfigVariable>();
            ////applying its own first
            //foreach (ConfigVariable cv in ConfigVariables)
            //{
            //    ConfigVariable existingCV = (from ConfigVariable c in allConfigVars
            //                                 where c.FindValue == cv.FindValue
            //                                 select c).FirstOrDefault();
            //    if (existingCV == null)
            //    {
            //        allConfigVars.Add(cv.Clone());
            //    }
            //}
            ////if (allConfigVars.Count == 0) //adds dummy entry so internal vars also get applied
            ////{
            ////    allConfigVars.Add(new ConfigVariable() { FindValue = DateTime.Now.Millisecond.ToString(), ReplaceValue = DateTime.Now.Millisecond.ToString() });
            ////}            

            //return allConfigVars.ApplyOn(field);            
        }
    }
}
