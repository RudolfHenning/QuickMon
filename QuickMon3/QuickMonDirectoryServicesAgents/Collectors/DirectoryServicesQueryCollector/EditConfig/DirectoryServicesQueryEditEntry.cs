using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class DirectoryServicesQueryEditEntry : Form, IEditConfigEntryWindow
    {
        public DirectoryServicesQueryEditEntry()
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

        private void DirectoryServicesQueryEditEntry_Load(object sender, EventArgs e)
        {
            DirectoryServicesQueryCollectorConfigEntry selectedEntry = (DirectoryServicesQueryCollectorConfigEntry)SelectedEntry;
            cboSuccessMatchType.SelectedIndex = 0;
            cboWarningMatchType.SelectedIndex = 0;
            cboErrorMatchType.SelectedIndex = 0;
            if (selectedEntry != null)
            {
                txtName.Text = selectedEntry.Name;
                txtDomainController.Text = selectedEntry.DomainController;
                txtQueryText.Text = selectedEntry.QueryFilterText;
                txtPropertiestToLoad.Text = selectedEntry.PropertiesToLoad;
                optEWG.Checked = selectedEntry.ReturnCheckSequence == CollectorReturnValueCheckSequenceType.EWG;
                chkUseRowCount.Checked = selectedEntry.UseRowCountAsValue;
                maxRowsNumericUpDown.Value = selectedEntry.MaxRowsToEvaluate;
                txtSuccess.Text = selectedEntry.GoodScriptText;
                cboSuccessMatchType.SelectedIndex = (int)selectedEntry.GoodResultMatchType;
                txtWarning.Text = selectedEntry.WarningScriptText;
                cboWarningMatchType.SelectedIndex = (int)selectedEntry.WarningResultMatchType;
                txtError.Text = selectedEntry.ErrorScriptText;
                cboErrorMatchType.SelectedIndex = (int)selectedEntry.ErrorResultMatchType;
            }
        }

        private void cmdEditPropertiesToLoad_Click(object sender, EventArgs e)
        {
            CSVEditor csvEditor = new CSVEditor();
            csvEditor.Text = "Column names";
            csvEditor.ItemDescription = "Column";
            csvEditor.Sorted = false;
            csvEditor.CSVData = txtPropertiestToLoad.Text;
            if (csvEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPropertiestToLoad.Text = csvEditor.CSVData;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            DirectoryServicesQueryCollectorConfigEntry selectedEntry = null;
            if (SelectedEntry == null)
                SelectedEntry = new DirectoryServicesQueryCollectorConfigEntry();
            selectedEntry = (DirectoryServicesQueryCollectorConfigEntry)SelectedEntry;
            selectedEntry.Name = txtName.Text;
            selectedEntry.DomainController = txtDomainController.Text;
            selectedEntry.PropertiesToLoad = txtPropertiestToLoad.Text;
            selectedEntry.ReturnCheckSequence = optGWE.Checked ? CollectorReturnValueCheckSequenceType.GWE : CollectorReturnValueCheckSequenceType.EWG;
            selectedEntry.UseRowCountAsValue = chkUseRowCount.Checked;
            selectedEntry.MaxRowsToEvaluate = (int)maxRowsNumericUpDown.Value;
            selectedEntry.QueryFilterText = txtQueryText.Text;
            selectedEntry.GoodScriptText = txtSuccess.Text;
            selectedEntry.GoodResultMatchType = (CollectorReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
            selectedEntry.WarningScriptText = txtWarning.Text;
            selectedEntry.WarningResultMatchType = (CollectorReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
            selectedEntry.ErrorScriptText = txtError.Text;
            selectedEntry.ErrorResultMatchType = (CollectorReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void CheckOkEnabled()
        {
            cmdOK.Enabled = txtName.Text.Trim().Length > 0 && txtQueryText.Text.Trim().Length > 0 && txtPropertiestToLoad.Text.Trim().Length > 0 &&
                txtSuccess.Text.Trim().Length > 0 && txtWarning.Text.Trim().Length > 0 && txtError.Text.Trim().Length > 0;
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void txtQueryText_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void txtPropertiestToLoad_TextChanged(object sender, EventArgs e)
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

        private void cmdRunQuery_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DirectoryServicesQueryCollectorConfigEntry testEntry = new DirectoryServicesQueryCollectorConfigEntry();
                testEntry.Name = txtName.Text;
                testEntry.DomainController = txtDomainController.Text;
                testEntry.PropertiesToLoad = txtPropertiestToLoad.Text;
                testEntry.ReturnCheckSequence = optGWE.Checked ? CollectorReturnValueCheckSequenceType.GWE : CollectorReturnValueCheckSequenceType.EWG;
                testEntry.UseRowCountAsValue = chkUseRowCount.Checked;
                testEntry.MaxRowsToEvaluate = (int)maxRowsNumericUpDown.Value;
                testEntry.QueryFilterText = txtQueryText.Text;
                testEntry.GoodScriptText = txtSuccess.Text;
                testEntry.GoodResultMatchType = (CollectorReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
                testEntry.WarningScriptText = txtWarning.Text;
                testEntry.WarningResultMatchType = (CollectorReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
                testEntry.ErrorScriptText = txtError.Text;
                testEntry.ErrorResultMatchType = (CollectorReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;

                object results = testEntry.RunQuery();
                CollectorState currentstate = testEntry.GetState(results);
                string formattedResults = results.ToString();
                if (formattedResults.Length > 255)
                    formattedResults = formattedResults.Substring(0, 255);
                MessageBox.Show(string.Format("Result: {0}\r\nValue(s): {1}", currentstate, formattedResults) , "Test query", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
