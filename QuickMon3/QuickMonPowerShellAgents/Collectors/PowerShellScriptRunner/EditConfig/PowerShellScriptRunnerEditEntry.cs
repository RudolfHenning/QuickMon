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

            #region Load Match types
            cboSuccessMatchType.Items.Clear();
            cboSuccessMatchType.Items.AddRange(CollectorReturnValueCompareEngine.ReturnValueCompareMatchTypesToList().ToArray());
            if (cboSuccessMatchType.Items.Count > 0)
                cboSuccessMatchType.SelectedIndex = 0;
            cboWarningMatchType.Items.Clear();
            cboWarningMatchType.Items.AddRange(CollectorReturnValueCompareEngine.ReturnValueCompareMatchTypesToList().ToArray());
            if (cboWarningMatchType.Items.Count > 0)
                cboWarningMatchType.SelectedIndex = 0;
            cboErrorMatchType.Items.Clear();
            cboErrorMatchType.Items.AddRange(CollectorReturnValueCompareEngine.ReturnValueCompareMatchTypesToList().ToArray());
            if (cboErrorMatchType.Items.Count > 0)
                cboErrorMatchType.SelectedIndex = 0;
            #endregion

            if (selectedEntry != null)
            {
                txtName.Text = selectedEntry.Name;
                optEWG.Checked = selectedEntry.ReturnCheckSequence == CollectorReturnValueCheckSequenceType.EWG;
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
                PowerShellScriptRunnerEntry testEntry = new PowerShellScriptRunnerEntry();
                testEntry.Name = txtName.Text;
                testEntry.ReturnCheckSequence = optGWE.Checked ? CollectorReturnValueCheckSequenceType.GWE : CollectorReturnValueCheckSequenceType.EWG;
                testEntry.TestScript = txtScript.Text;
                testEntry.GoodScriptText = txtSuccess.Text;
                testEntry.GoodResultMatchType = (CollectorReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
                testEntry.WarningScriptText = txtWarning.Text;
                testEntry.WarningResultMatchType = (CollectorReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
                testEntry.ErrorScriptText = txtError.Text;
                testEntry.ErrorResultMatchType = (CollectorReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;

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
            PowerShellScriptRunnerEntry selectedEntry = null;
            if (SelectedEntry == null)
            {
                SelectedEntry = new PowerShellScriptRunnerEntry();
            }
            selectedEntry = (PowerShellScriptRunnerEntry)SelectedEntry;
            selectedEntry.Name = txtName.Text;

            selectedEntry.ReturnCheckSequence = optGWE.Checked ? CollectorReturnValueCheckSequenceType.GWE : CollectorReturnValueCheckSequenceType.EWG;
            selectedEntry.TestScript = txtScript.Text;
            selectedEntry.GoodScriptText = txtSuccess.Text;
            selectedEntry.GoodResultMatchType = (CollectorReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
            selectedEntry.WarningScriptText = txtWarning.Text;
            selectedEntry.WarningResultMatchType = (CollectorReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
            selectedEntry.ErrorScriptText = txtError.Text;
            selectedEntry.ErrorResultMatchType = (CollectorReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;
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
    }
}
