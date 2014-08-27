using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon
{
    public partial class EditMonitorPackConfig : Form
    {
        public EditMonitorPackConfig()
        {
            InitializeComponent();
            RequestCollectorsRefresh = false;
        }

        public MonitorPack SelectedMonitorPack { get; set; }
        public bool RequestCollectorsRefresh { get; set; }

        private bool freChanging = false;

        #region Form events
        private void EditMonitorPackConfig_Load(object sender, EventArgs e)
        {
            if (SelectedMonitorPack == null)
                SelectedMonitorPack = new MonitorPack();
            if (SelectedMonitorPack.MonitorPackPath != null)
            {
                string pathString = SelectedMonitorPack.MonitorPackPath;
                if (TextRenderer.MeasureText(pathString + "........", lblMonitorPackPath.Font).Width > lblMonitorPackPath.Width)
                {
                    string ellipseText = pathString.Substring(0, 20) + "....";
                    string tmpStr = pathString.Substring(4);
                    while (TextRenderer.MeasureText(ellipseText + tmpStr, lblMonitorPackPath.Font).Width > lblMonitorPackPath.Width)
                    {
                        tmpStr = tmpStr.Substring(1);
                    }
                    pathString = ellipseText + tmpStr;
                }

                lblMonitorPackPath.Text = pathString;
            }
            txtName.Text = SelectedMonitorPack.Name;
            txtType.Text = SelectedMonitorPack.TypeName;
            chkCorrectiveScripts.Checked = SelectedMonitorPack.RunCorrectiveScripts;
            chkEnabled.Checked = SelectedMonitorPack.Enabled;
            collectorStateHistorySizeNumericUpDown.Value = SelectedMonitorPack.CollectorStateHistorySize;
            SetFrequency(SelectedMonitorPack.PollingFrequencyOverrideSec);
            LoadNotifiers();
        } 
        #endregion

        #region Controls
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnable();
        }
        private void txtType_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnable();
        }
        private void freqSecNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetFrequency((int)freqSecNumericUpDown.Value);
        }
        private void freqSecTrackBar_Scroll(object sender, EventArgs e)
        {
            SetFrequency(freqSecTrackBar.Value);
        }
        #endregion

        #region Button events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                SelectedMonitorPack.Name = txtName.Text;
                SelectedMonitorPack.TypeName = txtType.Text;
                SelectedMonitorPack.RunCorrectiveScripts = chkCorrectiveScripts.Checked;
                SelectedMonitorPack.Enabled = chkEnabled.Checked;
                SelectedMonitorPack.CollectorStateHistorySize = (int)collectorStateHistorySizeNumericUpDown.Value;
                SelectedMonitorPack.PollingFrequencyOverrideSec = (int)freqSecNumericUpDown.Value;
                if (cboDefaultNotifier.SelectedIndex > -1)
                    SelectedMonitorPack.DefaultViewerNotifier = (NotifierEntry)cboDefaultNotifier.SelectedItem;
                else
                    SelectedMonitorPack.DefaultViewerNotifier = null;
                Close();
            }
        }
        #endregion

        #region Private methods
        private void LoadNotifiers()
        {
            cboDefaultNotifier.Items.Clear();
            foreach (NotifierEntry n in SelectedMonitorPack.Notifiers)
            {
                cboDefaultNotifier.Items.Add(n);
            }
            cboDefaultNotifier.SelectedItem = SelectedMonitorPack.DefaultViewerNotifier;
        }
        private bool ValidateInput()
        {
            if (txtName.Text.Trim().Length == 0)
            {
                txtName.Focus();
                return false;
            }
            else if (txtType.Text.Contains(","))
            {
                MessageBox.Show("The Type value may not include the comma (,) character.", "Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtType.Focus();
                return false;
            }
            else
                return true;
        }
        private void CheckOkEnable()
        {
            cmdOK.Enabled = (txtName.Text.Trim().Length > 0) && (!txtType.Text.Contains(","));
        }
        private void SetFrequency(int frequency)
        {
            if (!freChanging)
            {
                freChanging = true;
                if (freqSecNumericUpDown.Maximum >= frequency)
                    freqSecNumericUpDown.Value = frequency;
                else
                    freqSecNumericUpDown.Value = 10;
                freqSecTrackBar.Value = (int)freqSecNumericUpDown.Value;
                freChanging = false;
            }
        } 
        #endregion

        private void llblEditConfigVars_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (SelectedMonitorPack != null)
                {
                    EditConfigVariables editConfigVariables = new EditConfigVariables();
                    editConfigVariables.SelectedConfigVariables = SelectedMonitorPack.ConfigVariables;
                    if (editConfigVariables.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        SelectedMonitorPack.ConfigVariables = editConfigVariables.SelectedConfigVariables;
                        RequestCollectorsRefresh = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblMonitorPackPath_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (SelectedMonitorPack != null && SelectedMonitorPack.MonitorPackPath.Length > 0 && System.IO.File.Exists(SelectedMonitorPack.MonitorPackPath))
                {
                    System.Diagnostics.Process.Start("explorer.exe", "/select, " + SelectedMonitorPack.MonitorPackPath);
                }
            }
            catch (Exception)
            {
            }
        }

    }
}
