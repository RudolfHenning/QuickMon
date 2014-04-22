using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Notifiers
{
    public partial class InMemoryNotifierConfigEditor : Form, IEditConfigWindow, IEditConfigEntryWindow
    {
        public InMemoryNotifierConfigEditor()
        {
            InitializeComponent();
        }

        #region IEditConfigWindow Members
        public IAgentConfig SelectedConfig { get; set; }
        public QuickMonDialogResult ShowConfig()
        {
            if (SelectedConfig != null)
            {
                maxCountNumericUpDown.Value = ((InMemoryNotifierConfig)SelectedConfig).MaxEntryCount;
            }
            return (QuickMonDialogResult)ShowDialog();
        }
        public void SetTitle(string title)
        {
            Text = title;
        }
        #endregion

        #region IEditConfigEntryWindow Members
        public ICollectorConfigEntry SelectedEntry { get; set; }
        public QuickMonDialogResult ShowEditEntry()
        {
            return (QuickMonDialogResult)ShowDialog();
        }
        #endregion

        private void InMemoryNotifierConfigEditor_Shown(object sender, EventArgs e)
        {
            
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (SelectedConfig == null)
                SelectedConfig = new InMemoryNotifierConfig();
            ((InMemoryNotifierConfig)SelectedConfig).MaxEntryCount = (int)maxCountNumericUpDown.Value;

            //SelectedConfig = new InMemoryNotifierConfig() { MaxEntryCount = (int)maxCountNumericUpDown.Value };

            DialogResult = DialogResult.OK;
            Close();
        }


    }
}
