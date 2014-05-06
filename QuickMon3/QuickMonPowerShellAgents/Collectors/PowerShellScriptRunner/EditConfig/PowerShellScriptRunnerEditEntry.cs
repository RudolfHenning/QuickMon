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
    public partial class PowerShellScriptRunnerEditEntry : Form, IEditConfigEntryWindow
    {
        public PowerShellScriptRunnerEditEntry()
        {
            InitializeComponent();
        }

        #region IEditConfigEntryWindow Members
        public ICollectorConfigEntry SelectedEntry { get; set; }
        public QuickMonDialogResult ShowEditEntry()
        {
            return (QuickMonDialogResult)ShowDialog();
        }
        #endregion

        private void PowerShellScriptRunnerEditEntry_Load(object sender, EventArgs e)
        {
            PowerShellScriptRunnerEntry selectedEntry = (PowerShellScriptRunnerEntry)SelectedEntry;
            cboSuccessMatchType.SelectedIndex = 0;
            cboWarningMatchType.SelectedIndex = 0;
            cboErrorMatchType.SelectedIndex = 0;
            if (selectedEntry != null)
            {
                txtName.Text = selectedEntry.Name;
                optEWG.Checked = selectedEntry.ReturnCheckSequence == ReturnCheckSequenceType.EWG;
                txtScript.Text = selectedEntry.TestScript;
                txtSuccess.Text = selectedEntry.GoodScriptText;
                cboSuccessMatchType.SelectedIndex = (int)selectedEntry.GoodResultMatchType;
                txtWarning.Text = selectedEntry.WarningScriptText;
                cboWarningMatchType.SelectedIndex = (int)selectedEntry.WarningResultMatchType;
                txtError.Text = selectedEntry.ErrorScriptText;
                cboErrorMatchType.SelectedIndex = (int)selectedEntry.ErrorResultMatchType;
            }
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
                MessageBox.Show(PowerShellScriptRunnerEntry.RunScript(txtScript.Text), "Test script", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            PowerShellScriptRunnerEntry selectedEntry = null;
            if (SelectedEntry == null)
            {
                SelectedEntry = new PowerShellScriptRunnerEntry();
            }
            selectedEntry = (PowerShellScriptRunnerEntry)SelectedEntry;
            selectedEntry.Name = txtName.Text;

            selectedEntry.ReturnCheckSequence = optGWE.Checked ? ReturnCheckSequenceType.GWE : ReturnCheckSequenceType.EWG;
            selectedEntry.TestScript = txtScript.Text;
            selectedEntry.GoodScriptText = txtSuccess.Text;
            selectedEntry.GoodResultMatchType = (TextCompareMatchType)cboSuccessMatchType.SelectedIndex;
            selectedEntry.WarningScriptText = txtWarning.Text;
            selectedEntry.WarningResultMatchType = (TextCompareMatchType)cboWarningMatchType.SelectedIndex;
            selectedEntry.ErrorScriptText = txtError.Text;
            selectedEntry.ErrorResultMatchType = (TextCompareMatchType)cboErrorMatchType.SelectedIndex;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        #endregion

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
    }
}
