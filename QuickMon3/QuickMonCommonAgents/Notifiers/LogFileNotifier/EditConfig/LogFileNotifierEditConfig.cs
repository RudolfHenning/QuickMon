using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Notifiers
{
    public partial class LogFileNotifierEditConfig :  SimpleNotifierEditConfig
    {
        public LogFileNotifierEditConfig()
        {
            InitializeComponent();
        }

        public override void LoadEditData()
        {
            LogFileNotifierConfig currentConfig;
            if (SelectedEntry != null)
                currentConfig = (LogFileNotifierConfig)SelectedEntry;
            else
                currentConfig = (LogFileNotifierConfig)SelectedConfig;

            if (currentConfig != null)
            {
                txtLogFilePath.Text = currentConfig.OutputPath;
                numericUpDownCreateNewFileSizeKB.Value = currentConfig.CreateNewFileSizeKB;                
            }
            CheckOKEnabled();
            base.LoadEditData();
        }
        public override void OkClicked()
        {
            LogFileNotifierConfig currentConfig;
            if (SelectedEntry != null)
                currentConfig = (LogFileNotifierConfig)SelectedEntry;
            else
                currentConfig = (LogFileNotifierConfig)SelectedConfig;

            if (currentConfig != null)
            {
                currentConfig.OutputPath = txtLogFilePath.Text;
                currentConfig.CreateNewFileSizeKB = (long)numericUpDownCreateNewFileSizeKB.Value;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        private void CheckOKEnabled()
        {
            SetOKEnabled(txtLogFilePath.Text.Trim().Length > 0 && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtLogFilePath.Text)));
        }

        private void txtLogFilePath_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            saveFileDialogLogFile.FileName = txtLogFilePath.Text;
            if (saveFileDialogLogFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtLogFilePath.Text = saveFileDialogLogFile.FileName;
        }
    }
}
