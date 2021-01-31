using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;
using QuickMon.MeansurementUnits;
using QuickMon.Collectors;

namespace QuickMon.UI
{
    public partial class FileSystemCollectorEditFilterEntry : CollectorConfigEntryEditWindowBase
    {
        public FileSystemCollectorEditFilterEntry()
        {
            InitializeComponent();
        }

        private void FileSystemCollectorEditFilterEntry_Load(object sender, EventArgs e)
        {
            try
            {
                FileSystemDirectoryFilterEntry selectedEntry;
                if (SelectedEntry == null)
                    SelectedEntry = new FileSystemDirectoryFilterEntry() { FileFilter = "*.*",  };
                selectedEntry = (FileSystemDirectoryFilterEntry)SelectedEntry;

                txtDirectory.Text = selectedEntry.DirectoryPath;
                txtFilter.Text = selectedEntry.FileFilter;
                chkIncludeSubDirs.Checked = selectedEntry.IncludeSubDirectories;
                txtContains.Text = selectedEntry.ContainsText;
                chkUseRegEx.Checked = selectedEntry.UseRegEx;
                nudFindTextInLastXLines.SaveValueSet(selectedEntry.FindTextInLastXLines);
                cboFileAgeUnit.SelectedIndex = (int)selectedEntry.FileAgeUnit;
                numericUpDownFileAgeMin.SaveValueSet(selectedEntry.FileMinAge);
                numericUpDownFileAgeMax.SaveValueSet(selectedEntry.FileMaxAge);
                cboFileSizeUnit.SelectedIndex = (int)selectedEntry.FileSizeUnit;
                numericUpDownFileSizeMin.SaveValueSet(selectedEntry.FileMinSize);
                numericUpDownFileSizeMax.SaveValueSet(selectedEntry.FileMaxSize);

                optCounts.Checked = true;
                optDirectoryExistOnly.Checked = selectedEntry.DirectoryExistOnly;
                optCheckIfFilesExistOnly.Checked = selectedEntry.FilesExistOnly;
                optErrorOnFilesExist.Checked = selectedEntry.ErrorOnFilesExist;

                numericUpDownCountWarningIndicator.SaveValueSet(selectedEntry.CountWarningIndicator);
                numericUpDownCountErrorIndicator.SaveValueSet(selectedEntry.CountErrorIndicator);
                cboFileSizeIndicatorUnit.SelectedIndex = (int)selectedEntry.FileSizeIndicatorUnit;
                numericUpDownSizeWarningIndicator.SaveValueSet(selectedEntry.SizeWarningIndicator);
                numericUpDownSizeErrorIndicator.SaveValueSet(selectedEntry.SizeErrorIndicator);
                chkShowFilenamesInDetails.Checked = selectedEntry.ShowFilenamesInDetails;
                topFileNameCountInDetailsNumericUpDown.SaveValueSet(selectedEntry.TopFileNameCountInDetails);
                optShowFileCountInOutputValue.Checked = selectedEntry.ShowFileCountInOutputValue && !selectedEntry.ShowFileSizeInOutputValue;
                optShowFileSizeInOutputValue.Checked = !selectedEntry.ShowFileCountInOutputValue && selectedEntry.ShowFileSizeInOutputValue;
                ShowFileCountAndSizeInOutputValue.Checked = selectedEntry.ShowFileCountInOutputValue == selectedEntry.ShowFileSizeInOutputValue;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtDirectory.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = folderBrowserDialog1.SelectedPath;
            }
        }        

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtFilter.Text.Length == 0)
            {
                txtFilter.Text = "*.*";
            }
            if (txtDirectory.Text.Contains("*"))
            {
                txtFilter.Text = FileSystemDirectoryFilterEntry.GetFilterFromPath(txtDirectory.Text);
                txtDirectory.Text = FileSystemDirectoryFilterEntry.GetDirectoryFromPath(txtDirectory.Text);
            }

           // if (!Directory.Exists((txtDirectory.Text.Length > 0 && txtDirectory.Text.Contains('%')) ? Environment.ExpandEnvironmentVariables(txtDirectory.Text) : txtDirectory.Text))
           // {
           //     MessageBox.Show("Directory must exist and be accessible!", "Directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           // }
            //else 
            if (chkVerifyOnOK.Checked && optCounts.Checked && numericUpDownCountWarningIndicator.Value == numericUpDownCountErrorIndicator.Value && numericUpDownCountWarningIndicator.Value > 0)
            {
                MessageBox.Show("Error and warning file count values cannot the same!", "Warnings/Errors", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (chkVerifyOnOK.Checked && optCounts.Checked && numericUpDownSizeWarningIndicator.Value == numericUpDownSizeErrorIndicator.Value && numericUpDownSizeWarningIndicator.Value > 0)
            {
                MessageBox.Show("Error and warning file size values cannot be the same!", "Warnings/Errors", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (chkVerifyOnOK.Checked && !optDirectoryExistOnly.Checked && numericUpDownFileAgeMin.Value > numericUpDownFileAgeMax.Value && numericUpDownFileAgeMax.Value > 0)
            {
                MessageBox.Show("File age warning filter value cannot be more than the error value!", "Filters", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (chkVerifyOnOK.Checked && !optDirectoryExistOnly.Checked && numericUpDownFileSizeMin.Value > numericUpDownFileSizeMax.Value && numericUpDownFileSizeMax.Value > 0)
            {
                MessageBox.Show("File size warning filter value cannot be more than the error value!", "Filters", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FileSystemDirectoryFilterEntry selectedEntry;
                if (SelectedEntry == null)
                    SelectedEntry = new FileSystemDirectoryFilterEntry();

                selectedEntry = (FileSystemDirectoryFilterEntry)SelectedEntry;               

                selectedEntry.DirectoryPath = txtDirectory.Text;
                selectedEntry.DirectoryExistOnly = optDirectoryExistOnly.Checked;
                selectedEntry.FileFilter = txtFilter.Text;
                selectedEntry.IncludeSubDirectories = chkIncludeSubDirs.Checked;
                selectedEntry.FilesExistOnly = optCheckIfFilesExistOnly.Checked;
                selectedEntry.ErrorOnFilesExist = optErrorOnFilesExist.Checked;
                selectedEntry.ContainsText = txtContains.Text;
                selectedEntry.UseRegEx = chkUseRegEx.Checked;
                selectedEntry.FindTextInLastXLines = Convert.ToInt32(nudFindTextInLastXLines.Value);
                selectedEntry.CountWarningIndicator = Convert.ToInt32(numericUpDownCountWarningIndicator.Value);
                selectedEntry.CountErrorIndicator = Convert.ToInt32(numericUpDownCountErrorIndicator.Value);
                selectedEntry.FileSizeIndicatorUnit = (FileSizeUnits)cboFileSizeIndicatorUnit.SelectedIndex;
                selectedEntry.SizeWarningIndicator = (int)numericUpDownSizeWarningIndicator.Value;
                selectedEntry.SizeErrorIndicator = (int)numericUpDownSizeErrorIndicator.Value;
                selectedEntry.FileAgeUnit = (TimeUnits)cboFileAgeUnit.SelectedIndex;
                selectedEntry.FileMinAge = (int)numericUpDownFileAgeMin.Value;
                selectedEntry.FileMaxAge = (int)numericUpDownFileAgeMax.Value;
                selectedEntry.FileSizeUnit = (FileSizeUnits)cboFileSizeUnit.SelectedIndex;
                selectedEntry.FileMinSize = (int)numericUpDownFileSizeMin.Value;
                selectedEntry.FileMaxSize = (int)numericUpDownFileSizeMax.Value;
                selectedEntry.ShowFilenamesInDetails = chkShowFilenamesInDetails.Checked;
                selectedEntry.TopFileNameCountInDetails = (int)topFileNameCountInDetailsNumericUpDown.Value;
                selectedEntry.ShowFileCountInOutputValue = optShowFileCountInOutputValue.Checked || ShowFileCountAndSizeInOutputValue.Checked;
                selectedEntry.ShowFileSizeInOutputValue = optShowFileSizeInOutputValue.Checked || ShowFileCountAndSizeInOutputValue.Checked;

                SelectedEntry = selectedEntry;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #region Change tracking
        private void txtDirectory_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void numericUpDownCountWarningIndicator_ValueChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void numericUpDownCountErrorIndicator_ValueChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void numericUpDownSizeWarningIndicator_ValueChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void numericUpDownSizeErrorIndicator_ValueChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void numericUpDownFileAgeMin_ValueChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void numericUpDownFileAgeMax_ValueChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void numericUpDownFileSizeMin_ValueChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void numericUpDownFileSizeMax_ValueChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        } 
        private void optCounts_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckOptions();
        }
        private void optDirectoryExistOnly_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckOptions();
        }
        private void optCheckIfFilesExistOnly_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckOptions();
        }
        private void optErrorOnFilesExist_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckOptions();
        }

        private void CheckOKEnabled()
        {
            string fullPath = (txtDirectory.Text.Length > 0 && txtDirectory.Text.Contains('%')) ? Environment.ExpandEnvironmentVariables(txtDirectory.Text) : txtDirectory.Text;
            cmdOK.Enabled = fullPath.Length > 0 && // System.IO.Directory.Exists(fullPath) &&
                    txtFilter.Text.Length > 0 &&
                    (optDirectoryExistOnly.Checked || optCheckIfFilesExistOnly.Checked || optErrorOnFilesExist.Checked ||
                        (numericUpDownCountWarningIndicator.Value > 0 || numericUpDownCountErrorIndicator.Value > 0) ||
                        (numericUpDownSizeWarningIndicator.Value > 0 || numericUpDownSizeErrorIndicator.Value > 0)
                        );
            cmdTest.Enabled = cmdOK.Enabled;
            txtDirectory.BackColor = (txtDirectory.Text.Length == 0 || (!System.IO.Directory.Exists(fullPath))) ? Color.LightCoral : SystemColors.Window;
        }
        private void SetCheckOptions()
        {
            txtFilter.Enabled = optCounts.Checked || optErrorOnFilesExist.Checked || optCheckIfFilesExistOnly.Checked;
            txtContains.Enabled = optCounts.Checked || optErrorOnFilesExist.Checked || optCheckIfFilesExistOnly.Checked;
            chkUseRegEx.Enabled = optCounts.Checked || optErrorOnFilesExist.Checked || optCheckIfFilesExistOnly.Checked;
            cboFileAgeUnit.Enabled = optCounts.Checked || optErrorOnFilesExist.Checked || optCheckIfFilesExistOnly.Checked;
            numericUpDownFileAgeMin.Enabled = optCounts.Checked || optErrorOnFilesExist.Checked || optCheckIfFilesExistOnly.Checked;
            numericUpDownFileAgeMax.Enabled = optCounts.Checked || optErrorOnFilesExist.Checked || optCheckIfFilesExistOnly.Checked;
            cboFileSizeUnit.Enabled = optCounts.Checked || optErrorOnFilesExist.Checked || optCheckIfFilesExistOnly.Checked;
            numericUpDownFileSizeMin.Enabled = optCounts.Checked || optErrorOnFilesExist.Checked || optCheckIfFilesExistOnly.Checked;
            numericUpDownFileSizeMax.Enabled = optCounts.Checked || optErrorOnFilesExist.Checked || optCheckIfFilesExistOnly.Checked;
            numericUpDownCountWarningIndicator.Enabled = optCounts.Checked;
            numericUpDownCountErrorIndicator.Enabled = optCounts.Checked;
            cboFileSizeIndicatorUnit.Enabled = optCounts.Checked;
            numericUpDownSizeWarningIndicator.Enabled = optCounts.Checked;
            numericUpDownSizeErrorIndicator.Enabled = optCounts.Checked;
            CheckOKEnabled();
        }
        #endregion

        private void cmdTest_Click(object sender, EventArgs e)
        {
            try
            {
                FileSystemDirectoryFilterEntry testEntry = new FileSystemDirectoryFilterEntry();

                string directoryName = ApplyConfigVarsOnField(txtDirectory.Text);
                string filterText = ApplyConfigVarsOnField(txtFilter.Text);
                string containText = ApplyConfigVarsOnField(txtContains.Text);

                testEntry.DirectoryPath = directoryName;
                testEntry.DirectoryExistOnly = optDirectoryExistOnly.Checked;
                testEntry.FileFilter = filterText;
                testEntry.IncludeSubDirectories = chkIncludeSubDirs.Checked;
                testEntry.FilesExistOnly = optCheckIfFilesExistOnly.Checked;
                testEntry.ErrorOnFilesExist = optErrorOnFilesExist.Checked;
                testEntry.ContainsText = containText;
                testEntry.UseRegEx = chkUseRegEx.Checked;
                testEntry.FindTextInLastXLines = Convert.ToInt32(nudFindTextInLastXLines.Value);
                testEntry.CountWarningIndicator = Convert.ToInt32(numericUpDownCountWarningIndicator.Value);
                testEntry.CountErrorIndicator = Convert.ToInt32(numericUpDownCountErrorIndicator.Value);
                testEntry.FileSizeIndicatorUnit = (FileSizeUnits)cboFileSizeIndicatorUnit.SelectedIndex;
                testEntry.SizeWarningIndicator = (int)numericUpDownSizeWarningIndicator.Value;
                testEntry.SizeErrorIndicator = (int)numericUpDownSizeErrorIndicator.Value;
                testEntry.FileAgeUnit = (TimeUnits)cboFileAgeUnit.SelectedIndex;
                testEntry.FileMinAge = (int)numericUpDownFileAgeMin.Value;
                testEntry.FileMaxAge = (int)numericUpDownFileAgeMax.Value;
                testEntry.FileSizeUnit = (FileSizeUnits)cboFileSizeUnit.SelectedIndex;
                testEntry.FileMinSize = (int)numericUpDownFileSizeMin.Value;
                testEntry.FileMaxSize = (int)numericUpDownFileSizeMax.Value;
                testEntry.ShowFilenamesInDetails = chkShowFilenamesInDetails.Checked;
                testEntry.TopFileNameCountInDetails = (int)topFileNameCountInDetailsNumericUpDown.Value;

                MonitorState testState = testEntry.GetCurrentState();
                //DirectoryFileInfo directoryFileInfo = testEntry.GetFileListByFilters();

                //CollectorState currentState = testEntry.GetCurrentState().State;
                MessageBox.Show(string.Format("State: {0}\r\nDetails: {1}", testState.State, testState.ReadAllRawDetails()), "Test",  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void topFileNameCountInDetailsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //if (topFileNameCountInDetailsNumericUpDown.Value > 20 || topFileNameCountInDetailsNumericUpDown.Value == 0)
            //    lblFistWithTopWarning.Visible = true;
            //else
            //    lblFistWithTopWarning.Visible = false;
        }
    }
}
