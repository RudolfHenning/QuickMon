using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuickMon
{
    public partial class EditDirectory : Form
    {
        public EditDirectory()
        {
            InitializeComponent();
            SelectedDirectoryFilterEntry = new DirectoryFilterEntry();
            SelectedDirectoryFilterEntry.FileFilter = "*.*";
        }

        public DirectoryFilterEntry SelectedDirectoryFilterEntry { get; set; }
        
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtDirectory.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        public DialogResult ShowDirectoryDetail()
        {
            txtDirectory.Text = SelectedDirectoryFilterEntry.DirectoryPath;
            txtFilter.Text = SelectedDirectoryFilterEntry.FileFilter;
            numericUpDownCountWarningIndicator.Value = SelectedDirectoryFilterEntry.CountWarningIndicator;
            numericUpDownCountErrorIndicator.Value = SelectedDirectoryFilterEntry.CountErrorIndicator;
            numericUpDownSizeWarningIndicator.Value = SelectedDirectoryFilterEntry.SizeKBWarningIndicator;
            numericUpDownSizeErrorIndicator.Value = SelectedDirectoryFilterEntry.SizeKBErrorIndicator;
            numericUpDownFileAgeMin.Value = SelectedDirectoryFilterEntry.FileMinAgeSec;
            numericUpDownFileAgeMax.Value = SelectedDirectoryFilterEntry.FileMaxAgeSec;
            numericUpDownFileSizeMin.Value = SelectedDirectoryFilterEntry.FileMinSizeKB;
            numericUpDownFileSizeMax.Value = SelectedDirectoryFilterEntry.FileMaxSizeKB;
            return ShowDialog();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtFilter.Text.Length == 0)
            {
                txtFilter.Text = "*.*";
            }
            if (txtDirectory.Text.Contains("*")) 
            {
                txtFilter.Text = DirectoryFilterEntry.GetFilterFromPath(txtDirectory.Text);
                txtDirectory.Text = DirectoryFilterEntry.GetDirectoryFromPath(txtDirectory.Text);
            }
            
            if (!Directory.Exists(txtDirectory.Text))
            {
                MessageBox.Show("Directory must exist and be accessible!", "Directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (numericUpDownCountWarningIndicator.Value > numericUpDownCountErrorIndicator.Value)
            {
                MessageBox.Show("Error file count cannot be less than warning file count!", "Warnings/Errors", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (numericUpDownSizeWarningIndicator.Value > numericUpDownSizeErrorIndicator.Value)
            {
                MessageBox.Show("Error file size cannot be less than warning file size!", "Warnings/Errors", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SelectedDirectoryFilterEntry.DirectoryPath = txtDirectory.Text;
                SelectedDirectoryFilterEntry.FileFilter = txtFilter.Text;
                SelectedDirectoryFilterEntry.CountWarningIndicator = Convert.ToInt32(numericUpDownCountWarningIndicator.Value);
                SelectedDirectoryFilterEntry.CountErrorIndicator = Convert.ToInt32(numericUpDownCountErrorIndicator.Value);
                SelectedDirectoryFilterEntry.SizeKBWarningIndicator = (int)numericUpDownSizeWarningIndicator.Value;
                SelectedDirectoryFilterEntry.SizeKBErrorIndicator = (int)numericUpDownSizeErrorIndicator.Value;
                SelectedDirectoryFilterEntry.FileMinAgeSec = (int)numericUpDownFileAgeMin.Value;
                SelectedDirectoryFilterEntry.FileMaxAgeSec = (int)numericUpDownFileAgeMax.Value;
                SelectedDirectoryFilterEntry.FileMinSizeKB = (int)numericUpDownFileSizeMin.Value;
                SelectedDirectoryFilterEntry.FileMaxSizeKB = (int)numericUpDownFileSizeMax.Value;

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
