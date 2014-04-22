using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Collectors
{
    public partial class LoopbackCollectorEditConfig : Form, IEditConfigWindow, IEditConfigEntryWindow
    {
        public LoopbackCollectorEditConfig()
        {
            InitializeComponent();
        }

        #region IEditConfigWindow Members
        public IAgentConfig SelectedConfig { get;set;}
        public QuickMonDialogResult ShowConfig()
        {
            return (QuickMonDialogResult)ShowDialog();
        }
        public void SetTitle(string title)
        {
            Text = title;
        }
        #endregion

        #region IEditConfigEntryWindow Members
        public ICollectorConfigEntry SelectedEntry { get;set;}
        public QuickMonDialogResult ShowEditEntry()
        {
            return (QuickMonDialogResult)ShowDialog();
        }
        #endregion

        #region Form events
        private void LoopbackCollectorEditConfig_Shown(object sender, EventArgs e)
        {
            LoopbackCollectorConfigEntry selectedEntry;
            if (SelectedEntry != null)
                selectedEntry = (LoopbackCollectorConfigEntry)SelectedEntry;
            else
            {
                if (SelectedConfig == null)
                {
                    SelectedConfig = new LoopbackCollectorConfig();
                }
                selectedEntry = (LoopbackCollectorConfigEntry)((ICollectorConfig)SelectedConfig);
            }
            for (int i = 0; i < cboCollectorState.Items.Count; i++)
            {
                if (selectedEntry.ReturnState == CollectorStateConverter.GetCollectorStateFromText(cboCollectorState.Items[i].ToString()))
                {
                    cboCollectorState.SelectedIndex = i;
                    break;
                }
            }
        }
        #endregion

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (cboCollectorState.SelectedIndex > -1)
            {
                LoopbackCollectorConfigEntry selectedEntry;
                if (SelectedEntry != null)
                    selectedEntry = (LoopbackCollectorConfigEntry)SelectedEntry;
                else
                {
                    if (SelectedConfig == null)
                    {
                        SelectedConfig = new LoopbackCollectorConfig();
                    }
                    selectedEntry = (LoopbackCollectorConfigEntry)((ICollectorConfig)SelectedConfig);
                }
                selectedEntry.ReturnState = CollectorStateConverter.GetCollectorStateFromText(cboCollectorState.Text);
                SelectedEntry = selectedEntry;              
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
