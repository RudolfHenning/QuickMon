using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuickMon
{
    public partial class EditDiskSpace : Form
    {
        public EditDiskSpace()
        {
            InitializeComponent();
        }

        public DriveSpaceEntry DriveSpace { get; set; }

        public DialogResult ShowDriveSpace()
        {
            cboDriveLetter.SelectedItem = DriveSpace.DriveLetter.ToUpper();
            numericUpDownWarningSizeLeftMB.Value = DriveSpace.WarningSizeLeftMB;
            numericUpDownErrorSizeLeftMB.Value = DriveSpace.ErrorSizeLeftMB;
            chkWarningOnNotAvailable.Checked = DriveSpace.WarnOnNotReady;
            return ShowDialog();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (cboDriveLetter.SelectedItem == null)
            {
                MessageBox.Show("Please select a drive letter!", "Drive letter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                //DriveInfo[] dis = DriveInfo.GetDrives();

                DriveInfo di = new DriveInfo(cboDriveLetter.SelectedItem.ToString());
                if (!di.IsReady)
                {
                    if (MessageBox.Show(string.Format("The drive {0} is not available at the moment. Do you want top accept this choice anyway?", cboDriveLetter.SelectedItem), "Drive not available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                        return;
                }
            }
            DriveSpace.DriveLetter = cboDriveLetter.SelectedItem.ToString();
            DriveSpace.WarningSizeLeftMB = (long)numericUpDownWarningSizeLeftMB.Value;
            DriveSpace.ErrorSizeLeftMB = (long)numericUpDownErrorSizeLeftMB.Value;
            DriveSpace.WarnOnNotReady = chkWarningOnNotAvailable.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cboDriveLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DriveInfo di = new DriveInfo(cboDriveLetter.SelectedItem.ToString());
                lblDriveType.Text = di.DriveType.ToString();
                if (!di.IsReady)
                    lblDriveType.ForeColor = Color.OrangeRed;
                else
                {
                    lblDriveType.ForeColor = SystemColors.ControlText;
                    lblDriveType.Text += " (" + (di.TotalFreeSpace / 1048576).ToString("0") + " MB)";
                }
            }
            catch { }
        }
    }
}
