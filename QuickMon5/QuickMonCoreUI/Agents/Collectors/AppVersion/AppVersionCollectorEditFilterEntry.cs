using QuickMon.Collectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class AppVersionCollectorEditFilterEntry : CollectorConfigEntryEditWindowBase
    {
        public AppVersionCollectorEditFilterEntry()
        {
            InitializeComponent();
        }

        private void AppVersionCollectorEditFilterEntry_Load(object sender, EventArgs e)
        {
            try
            {
                AppVersionEntry selectedEntry;
                if (SelectedEntry == null)
                    SelectedEntry = new AppVersionEntry();
                selectedEntry = (AppVersionEntry)SelectedEntry;
                txtAppName.Text = selectedEntry.ApplicationName;
                optFileVersion.Checked = selectedEntry.UseFileVersion;
                optProductVersion.Checked = !selectedEntry.UseFileVersion;
                optDisplayFormatRAW.Checked = selectedEntry.VersionFormat == VersionFormatType.RAWString;
                optDisplayFormatMMB.Checked = selectedEntry.VersionFormat == VersionFormatType.MajorMinorBuild;
                optDisplayFormatMM.Checked = selectedEntry.VersionFormat == VersionFormatType.MajorMinor;
                txtApplicationPaths.Text = "";
                selectedEntry.ExecutablePaths.ForEach(a => txtApplicationPaths.Text += a + "\r\n");
                chkFirstValidPath.Checked = selectedEntry.UseFirstValidPath;
                txtExpectedVersion.Text = selectedEntry.ExpectedVersion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Applications";
            openFile.Filter = "Applications|*.exe";
            openFile.DefaultExt = "exe";
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtApplicationPaths.Text = txtApplicationPaths.Text.Trim();
                if (txtApplicationPaths.Text.Length > 0)
                    txtApplicationPaths.Text += "\r\n";
                txtApplicationPaths.Text += openFile.FileName;
            }

        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            TestValidInput(true);            
        }

        private bool TestValidInput(bool showSuccess = false)
        {
            bool success =false;
            if (txtAppName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Application name must be specified!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtApplicationPaths.Text.Trim().Length == 0)
            {
                MessageBox.Show("Application path(s) must be specified!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtExpectedVersion.Text.Trim().Length == 0)
            {
                MessageBox.Show("Expected version must be specified!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    AppVersionEntry selectedEntry = new AppVersionEntry();
                    selectedEntry.ApplicationName = txtAppName.Text;
                    selectedEntry.UseFileVersion = optFileVersion.Checked;
                    selectedEntry.VersionFormat = optDisplayFormatRAW.Checked ? VersionFormatType.RAWString : optDisplayFormatMMB.Checked  ? VersionFormatType.MajorMinorBuild : VersionFormatType.MajorMinor;
                    string[] paths = txtApplicationPaths.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    selectedEntry.ExecutablePaths = new List<string>();
                    selectedEntry.ExecutablePaths.AddRange(paths);
                    selectedEntry.UseFirstValidPath = chkFirstValidPath.Checked;
                    selectedEntry.ExpectedVersion = txtExpectedVersion.Text;
                    MonitorState testState = selectedEntry.GetCurrentState();

                    success = true;
                    if (showSuccess)
                    {

                        MessageBox.Show(string.Format("State: {0}\r\nDetails: {1}", testState.State, testState.ReadAllRawDetails()), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return success;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if(!chkVerifyOnOK.Checked || TestValidInput())
            {
                AppVersionEntry selectedEntry;
                if (SelectedEntry == null)
                    SelectedEntry = new AppVersionEntry();
                selectedEntry = (AppVersionEntry)SelectedEntry;

                selectedEntry.ApplicationName = txtAppName.Text;
                selectedEntry.UseFileVersion = optFileVersion.Checked;
                selectedEntry.VersionFormat = optDisplayFormatRAW.Checked ? VersionFormatType.RAWString : optDisplayFormatMMB.Checked ? VersionFormatType.MajorMinorBuild : VersionFormatType.MajorMinor;
                string[] paths = txtApplicationPaths.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                selectedEntry.ExecutablePaths = new List<string>();
                selectedEntry.ExecutablePaths.AddRange(paths);
                selectedEntry.UseFirstValidPath = chkFirstValidPath.Checked;
                selectedEntry.ExpectedVersion = txtExpectedVersion.Text;
                SelectedEntry = selectedEntry;

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
