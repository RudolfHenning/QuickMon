using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;
using QuickMon.Notifiers;

namespace QuickMon.UI
{
    public partial class LogFileNotifierEdit : Form, IAgentConfigEntryEditWindow
    {
        public LogFileNotifierEdit()
        {
            InitializeComponent();
        }

        public IAgentConfig SelectedEntry { get; set; }

        public QuickMonDialogResult ShowEditEntry()
        {
            if (SelectedEntry != null)
            {
                LogFileNotifierConfig logFileNotifierConfig = (LogFileNotifierConfig)SelectedEntry;
                txtLogFilePath.Text = logFileNotifierConfig.OutputPath;
                numericUpDownCreateNewFileSizeKB.SaveValueSet(logFileNotifierConfig.CreateNewFileSizeKB);
                chkAppendDate.Checked = logFileNotifierConfig.AppendDate;
                chkUseLocalTimeFormat.Checked = logFileNotifierConfig.UseLocalTimeFormat;
                txtCustomTimeFormat.Text = logFileNotifierConfig.CustomTimeFormat;
            }
            return (QuickMonDialogResult)ShowDialog();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            saveFileDialogLogFile.FileName = txtLogFilePath.Text;
            if (saveFileDialogLogFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtLogFilePath.Text = saveFileDialogLogFile.FileName;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            LogFileNotifierConfig currentConfig;
            if (SelectedEntry == null)
                SelectedEntry = new LogFileNotifierConfig();
            currentConfig = (LogFileNotifierConfig)SelectedEntry;            

            if (currentConfig != null)
            {
                currentConfig.OutputPath = txtLogFilePath.Text;
                currentConfig.CreateNewFileSizeKB = (long)numericUpDownCreateNewFileSizeKB.Value;
                currentConfig.AppendDate = chkAppendDate.Checked;
                currentConfig.UseLocalTimeFormat = chkUseLocalTimeFormat.Checked ;
                currentConfig.CustomTimeFormat = txtCustomTimeFormat.Text ;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void txtLogFilePath_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void CheckOKEnabled()
        {
            cmdOK.Enabled = txtLogFilePath.Text.Trim().Length > 0 && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtLogFilePath.Text));
        }

        private void LogFileNotifierEdit_Load(object sender, EventArgs e)
        {

        }

        private void chkUseLocalTimeFormat_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomTimeFormat.Enabled = !chkUseLocalTimeFormat.Checked;
        }
    }
}
