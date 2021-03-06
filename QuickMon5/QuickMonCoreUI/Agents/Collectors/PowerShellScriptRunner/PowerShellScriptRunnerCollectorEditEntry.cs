﻿using QuickMon.Collectors;
using QuickMon.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class PowerShellScriptRunnerCollectorEditEntry : CollectorConfigEntryEditWindowBase
    {
        public PowerShellScriptRunnerCollectorEditEntry()
        {
            InitializeComponent();
        }

        private void PowerShellScriptRunnerCollectorEditEntry_Load(object sender, EventArgs e)
        {
            if (SelectedEntry == null)
                SelectedEntry = new PowerShellScriptRunnerEntry();
            PowerShellScriptRunnerEntry selectedEntry = (PowerShellScriptRunnerEntry)SelectedEntry;

            #region Load Match types
            cboSuccessMatchType.Items.Clear();
            cboSuccessMatchType.Items.AddRange(CollectorAgentReturnValueCompareEngine.ReturnValueCompareMatchTypesToList().ToArray());
            if (cboSuccessMatchType.Items.Count > 0)
                cboSuccessMatchType.SelectedIndex = 0;
            cboWarningMatchType.Items.Clear();
            cboWarningMatchType.Items.AddRange(CollectorAgentReturnValueCompareEngine.ReturnValueCompareMatchTypesToList().ToArray());
            if (cboWarningMatchType.Items.Count > 0)
                cboWarningMatchType.SelectedIndex = 0;
            cboErrorMatchType.Items.Clear();
            cboErrorMatchType.Items.AddRange(CollectorAgentReturnValueCompareEngine.ReturnValueCompareMatchTypesToList().ToArray());
            if (cboErrorMatchType.Items.Count > 0)
                cboErrorMatchType.SelectedIndex = 0;
            #endregion

            txtName.Text = selectedEntry.Name;
            cboOutputValueUnit.Text = selectedEntry.OutputValueUnit;
            cboReturnCheckSequence.SelectedIndex = (int)selectedEntry.ReturnCheckSequence;
            txtScript.Text = selectedEntry.TestScript;
            txtSuccess.Text = selectedEntry.GoodScriptText;
            cboSuccessMatchType.SelectedIndex = (int)selectedEntry.GoodResultMatchType;
            txtWarning.Text = selectedEntry.WarningScriptText;
            cboWarningMatchType.SelectedIndex = (int)selectedEntry.WarningResultMatchType;
            txtError.Text = selectedEntry.ErrorScriptText;
            cboErrorMatchType.SelectedIndex = (int)selectedEntry.ErrorResultMatchType;
        }

        #region Button events
        private void cmdImportScript_Click(object sender, EventArgs e)
        {
            if (ps1OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtScript.Text = System.IO.File.ReadAllText(ps1OpenFileDialog.FileName);
            }
        }
        private void cmdLoadScript_Click(object sender, EventArgs e)
        {
            if (ps1OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtScript.Text = ps1OpenFileDialog.FileName;
            }
        }
        private void cmdRunScript_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                PowerShellScriptRunnerEntry testEntry = new PowerShellScriptRunnerEntry();

                string name = ApplyConfigVarsOnField(txtName.Text);
                string testScript = ApplyConfigVarsOnField(txtScript.Text);
                string successVal = ApplyConfigVarsOnField(txtSuccess.Text);
                string warningVal = ApplyConfigVarsOnField(txtWarning.Text);
                string errorVal = ApplyConfigVarsOnField(txtError.Text);

                testEntry.Name = name;
                testEntry.OutputValueUnit = cboOutputValueUnit.Text;
                testEntry.ReturnCheckSequence = (CollectorAgentReturnValueCheckSequence)cboReturnCheckSequence.SelectedIndex;
                //in case the static config vars are used
                testEntry.TestScript = testScript;
                testEntry.GoodScriptText = successVal;
                testEntry.GoodResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
                testEntry.WarningScriptText = warningVal;
                testEntry.WarningResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
                testEntry.ErrorScriptText = errorVal;
                testEntry.ErrorResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;

                string scriptResult = testEntry.RunScript();
                CollectorState state = testEntry.GetState(scriptResult);

                MessageBox.Show(scriptResult, "Test script", MessageBoxButtons.OK, state == CollectorState.Good ? MessageBoxIcon.Information : state == CollectorState.Warning ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Run script", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (SelectedEntry == null)
                SelectedEntry = new PowerShellScriptRunnerEntry();
            PowerShellScriptRunnerEntry selectedEntry = (PowerShellScriptRunnerEntry)SelectedEntry;
            selectedEntry.Name = txtName.Text;
            selectedEntry.OutputValueUnit = cboOutputValueUnit.Text;
            selectedEntry.ReturnCheckSequence = (CollectorAgentReturnValueCheckSequence)cboReturnCheckSequence.SelectedIndex;
            selectedEntry.TestScript = txtScript.Text;
            selectedEntry.GoodScriptText = txtSuccess.Text;
            selectedEntry.GoodResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
            selectedEntry.WarningScriptText = txtWarning.Text;
            selectedEntry.WarningResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
            selectedEntry.ErrorScriptText = txtError.Text;
            selectedEntry.ErrorResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        #endregion

        #region Change tracking
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void txtScript_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void txtSuccess_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void txtWarning_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void txtError_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void CheckOkEnabled()
        {
            cmdOK.Enabled = txtName.Text.Trim().Length > 0 && txtScript.Text.Trim().Length > 0 &&
                txtSuccess.Text.Trim().Length > 0 && txtWarning.Text.Trim().Length > 0 && txtError.Text.Trim().Length > 0;
        }
        #endregion

        private void llblScriptingTip_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.ShowTextDialog tipWindow = new Forms.ShowTextDialog();
            tipWindow.Height = 300;
            tipWindow.ShowScrollbars = false;
            tipWindow.WordWrap = true;
            tipWindow.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            tipWindow.TopMost = true;
            tipWindow.ShowText("PowerShell Scripting tips", Properties.Resources.PowerShellTips, true);
        }
    }
}
