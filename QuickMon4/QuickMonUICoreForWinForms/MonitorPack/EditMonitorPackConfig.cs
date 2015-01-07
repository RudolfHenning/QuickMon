﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;
using QuickMon.UI;

namespace QuickMon
{
    public partial class EditMonitorPackConfig : Form
    {
        public EditMonitorPackConfig()
        {
            InitializeComponent();
            TriggerMonitorPackReload = false;
        }

        public MonitorPack SelectedMonitorPack { get; set; }
        public bool TriggerMonitorPackReload { get; set; }

        private bool freChanging = false;

        #region Form events
        private void EditMonitorPackConfig_Load(object sender, EventArgs e)
        {
            if (SelectedMonitorPack == null)
                SelectedMonitorPack = new MonitorPack();
            LoadFormControls();
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
                    SelectedMonitorPack.DefaultViewerNotifier = (NotifierHost)cboDefaultNotifier.SelectedItem;
                else
                    SelectedMonitorPack.DefaultViewerNotifier = null;
                SelectedMonitorPack.ConfigVariables = new List<ConfigVariable>();
                foreach (ListViewItem lvi in lvwConfigVars.Items)
                {
                    SelectedMonitorPack.ConfigVariables.Add(((ConfigVariable)lvi.Tag).Clone());
                }
                Close();
            }
        }
        #endregion

        #region Private methods
        private void LoadFormControls()
        {
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
            LoadConfigVars();
        }
        private void LoadNotifiers()
        {
            cboDefaultNotifier.Items.Clear();
            foreach (NotifierHost n in SelectedMonitorPack.NotifierHosts)
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
                //freqSecTrackBar.Value = (int)freqSecNumericUpDown.Value;
                freChanging = false;
            }
        } 
        #endregion

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

        #region Config Vars
        private bool loadConfigVarEntry = false;
        private void LoadConfigVars()
        {
            loadConfigVarEntry = true;
            lvwConfigVars.Items.Clear();
            if (SelectedMonitorPack.ConfigVariables != null && SelectedMonitorPack.ConfigVariables.Count > 0)
            {

                foreach (ConfigVariable cv in SelectedMonitorPack.ConfigVariables)
                {
                    ListViewItem lvi = new ListViewItem(cv.FindValue);
                    lvi.SubItems.Add(cv.ReplaceValue);
                    lvi.Tag = cv;
                    lvwConfigVars.Items.Add(lvi);
                }

            }
            loadConfigVarEntry = false;
        }
        private void lvwConfigVars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwConfigVars.SelectedItems.Count == 1)
            {
                loadConfigVarEntry = true;
                txtConfigVarSearchFor.Text = lvwConfigVars.SelectedItems[0].Text;
                txtConfigVarReplaceByValue.Text = lvwConfigVars.SelectedItems[0].SubItems[1].Text;
                loadConfigVarEntry = false;
            }
            else
            {
                loadConfigVarEntry = true;
                txtConfigVarSearchFor.Text = "";
                txtConfigVarReplaceByValue.Text = "";
                loadConfigVarEntry = false;
            }
            moveUpConfigVarToolStripButton.Enabled = lvwConfigVars.SelectedItems.Count == 1 && lvwConfigVars.SelectedItems[0].Index > 0;
            moveDownConfigVarToolStripButton.Enabled = lvwConfigVars.SelectedItems.Count == 1 && lvwConfigVars.SelectedItems[0].Index < lvwConfigVars.Items.Count - 1;
            deleteConfigVarToolStripButton.Enabled = lvwConfigVars.SelectedItems.Count > 0;
        }
        private void txtConfigVarSearchFor_TextChanged(object sender, EventArgs e)
        {
            UpdateConfigVarListFromText();
        }
        private void txtConfigVarReplaceByValue_TextChanged(object sender, EventArgs e)
        {
            UpdateConfigVarListFromText();

        }
        private void UpdateConfigVarListFromText()
        {
            if (!loadConfigVarEntry)
            {
                if (lvwConfigVars.SelectedItems.Count == 1)
                {
                    lvwConfigVars.SelectedItems[0].Text = txtConfigVarSearchFor.Text;
                    lvwConfigVars.SelectedItems[0].SubItems[1].Text = txtConfigVarReplaceByValue.Text;
                    ((ConfigVariable)lvwConfigVars.SelectedItems[0].Tag).FindValue = txtConfigVarSearchFor.Text;
                    ((ConfigVariable)lvwConfigVars.SelectedItems[0].Tag).ReplaceValue = txtConfigVarReplaceByValue.Text;
                }
                else if (lvwConfigVars.SelectedItems.Count == 0)
                {
                    ListViewItem lvi = new ListViewItem(txtConfigVarSearchFor.Text);
                    lvi.SubItems.Add(txtConfigVarReplaceByValue.Text);
                    lvi.Tag = new ConfigVariable() { FindValue = txtConfigVarSearchFor.Text, ReplaceValue = txtConfigVarReplaceByValue.Text };
                    lvwConfigVars.Items.Add(lvi);
                    lvi.Selected = true;
                }
                TriggerMonitorPackReload = true;
            }
        }
        private void addConfigVarToolStripButton_Click(object sender, EventArgs e)
        {
            loadConfigVarEntry = true;
            lvwConfigVars.SelectedItems.Clear();
            txtConfigVarSearchFor.Text = "";
            txtConfigVarReplaceByValue.Text = "";
            loadConfigVarEntry = false;
            txtConfigVarSearchFor.Focus();
        }
        private void deleteConfigVarToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwConfigVars.SelectedItems.Count > 0)
            {
                loadConfigVarEntry = true;
                if (MessageBox.Show("Are you sure you want to delete the seleted entry(s)?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwConfigVars.SelectedItems)
                        lvwConfigVars.Items.Remove(lvi);
                }
                txtConfigVarSearchFor.Text = "";
                txtConfigVarReplaceByValue.Text = "";
                loadConfigVarEntry = false;
            }
        }
        private void moveUpConfigVarToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwConfigVars.SelectedItems.Count == 1)
            {
                int index = lvwConfigVars.SelectedItems[0].Index;
                if (index > 0)
                {
                    loadConfigVarEntry = true;
                    ConfigVariable tmpBottom = (ConfigVariable)lvwConfigVars.Items[index].Tag;
                    ConfigVariable tmpTop = (ConfigVariable)lvwConfigVars.Items[index - 1].Tag;
                    lvwConfigVars.Items[index].Tag = tmpTop;
                    lvwConfigVars.Items[index].Text = tmpTop.FindValue;
                    lvwConfigVars.Items[index].SubItems[1].Text = tmpTop.ReplaceValue;
                    lvwConfigVars.Items[index - 1].Tag = tmpBottom;
                    lvwConfigVars.Items[index - 1].Text = tmpBottom.FindValue;
                    lvwConfigVars.Items[index - 1].SubItems[1].Text = tmpBottom.ReplaceValue;
                    lvwConfigVars.Items[index].Selected = false;
                    lvwConfigVars.Items[index].Focused = false;
                    lvwConfigVars.Items[index - 1].Selected = true;
                    lvwConfigVars.Items[index - 1].Focused = true;
                    lvwConfigVars.Items[index - 1].EnsureVisible();
                    loadConfigVarEntry = false;
                }
            }
        }
        private void moveDownConfigVarToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwConfigVars.SelectedItems.Count == 1)
            {
                int index = lvwConfigVars.SelectedItems[0].Index;
                if (index < lvwConfigVars.Items.Count - 1)
                {
                    loadConfigVarEntry = true;
                    ConfigVariable tmpBottom = (ConfigVariable)lvwConfigVars.Items[index + 1].Tag;
                    ConfigVariable tmpTop = (ConfigVariable)lvwConfigVars.Items[index].Tag;
                    lvwConfigVars.Items[index + 1].Tag = tmpTop;
                    lvwConfigVars.Items[index + 1].Text = tmpTop.FindValue;
                    lvwConfigVars.Items[index + 1].SubItems[1].Text = tmpTop.ReplaceValue;
                    lvwConfigVars.Items[index].Tag = tmpBottom;
                    lvwConfigVars.Items[index].Text = tmpBottom.FindValue;
                    lvwConfigVars.Items[index].SubItems[1].Text = tmpBottom.ReplaceValue;
                    lvwConfigVars.Items[index].Selected = false;
                    lvwConfigVars.Items[index].Focused = false;
                    lvwConfigVars.Items[index + 1].Selected = true;
                    lvwConfigVars.Items[index + 1].Focused = true;
                    lvwConfigVars.Items[index].EnsureVisible();
                    loadConfigVarEntry = false;
                }
            }
        }
        #endregion

        private void llblRawEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    SelectedMonitorPack.Name = txtName.Text;
                    SelectedMonitorPack.TypeName = txtType.Text;
                    SelectedMonitorPack.RunCorrectiveScripts = chkCorrectiveScripts.Checked;
                    SelectedMonitorPack.Enabled = chkEnabled.Checked;
                    SelectedMonitorPack.CollectorStateHistorySize = (int)collectorStateHistorySizeNumericUpDown.Value;
                    SelectedMonitorPack.PollingFrequencyOverrideSec = (int)freqSecNumericUpDown.Value;
                    if (cboDefaultNotifier.SelectedIndex > -1)
                        SelectedMonitorPack.DefaultViewerNotifier = (NotifierHost)cboDefaultNotifier.SelectedItem;
                    else
                        SelectedMonitorPack.DefaultViewerNotifier = null;
                    SelectedMonitorPack.ConfigVariables = new List<ConfigVariable>();
                    foreach (ListViewItem lvi in lvwConfigVars.Items)
                    {
                        SelectedMonitorPack.ConfigVariables.Add(((ConfigVariable)lvi.Tag).Clone());
                    }
                    RAWXmlEditor editor = new RAWXmlEditor();
                    string oldMarkUp = SelectedMonitorPack.ToXml();
                    editor.SelectedMarkup = oldMarkUp;
                    if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        TriggerMonitorPackReload = true;
                        MonitorPack newMP = new MonitorPack();
                        newMP.LoadXml(editor.SelectedMarkup);
                        newMP.MonitorPackPath = SelectedMonitorPack.MonitorPackPath;
                        SelectedMonitorPack = null;
                        SelectedMonitorPack = newMP;
                        LoadFormControls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}
