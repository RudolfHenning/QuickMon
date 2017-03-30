using QuickMon.Collectors;
using QuickMon.Utils;
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
    public partial class RegistryQueryCollectorEditEntry : Form, ICollectorConfigEntryEditWindow
    {
        public RegistryQueryCollectorEditEntry()
        {
            InitializeComponent();
        }

        #region IEditConfigEntryWindow Members
        public ICollectorConfigEntry SelectedEntry { get; set; }
        public QuickMonDialogResult ShowEditEntry()
        {
            RegistryQueryCollectorConfigEntry selectedEntry = (RegistryQueryCollectorConfigEntry)SelectedEntry;
            if (selectedEntry != null)
            {
                txtName.Text = selectedEntry.Name;
                chkUseRemoteServer.Checked = selectedEntry.UseRemoteServer;
                txtServer.Text = selectedEntry.Server;
                cboRegistryHive.SelectedIndex =
                    selectedEntry.RegistryHive == Microsoft.Win32.RegistryHive.LocalMachine ? 0 :
                    selectedEntry.RegistryHive == Microsoft.Win32.RegistryHive.ClassesRoot ? 1 :
                    selectedEntry.RegistryHive == Microsoft.Win32.RegistryHive.CurrentUser ? 2 :
                    selectedEntry.RegistryHive == Microsoft.Win32.RegistryHive.Users ? 3 :
                    selectedEntry.RegistryHive == Microsoft.Win32.RegistryHive.CurrentConfig ? 4 : 0;
                txtPath.Text = selectedEntry.Path;
                txtKey.Text = selectedEntry.KeyName;
                chkExpandEnvNames.Checked = selectedEntry.ExpandEnvironmentNames;

                chkValueIsANumber.Checked = selectedEntry.ReturnValueIsNumber;
                cboReturnCheckSequence.SelectedIndex = (int)selectedEntry.ReturnCheckSequence;
                txtSuccess.Text = selectedEntry.GoodValue;
                cboSuccessMatchType.SelectedIndex = (int)selectedEntry.GoodResultMatchType;
                txtWarning.Text = selectedEntry.WarningValue;
                cboWarningMatchType.SelectedIndex = (int)selectedEntry.WarningResultMatchType;
                txtError.Text = selectedEntry.ErrorValue;
                cboErrorMatchType.SelectedIndex = (int)selectedEntry.ErrorResultMatchType;
                cboOutputValueUnit.Text = selectedEntry.OutputValueUnit;
            }
            return (QuickMonDialogResult)ShowDialog();
        }
        #endregion

        #region Input control events
        private void txtPath_Leave(object sender, EventArgs e)
        {
            if (txtPath.Text.Length > 0 && txtPath.Text.ToUpper().StartsWith("HKEY_"))
            {
                string[] parts = txtPath.Text.Split('\\');
                if (parts.Length > 1)
                {
                    Microsoft.Win32.RegistryHive rh = RegistryQueryCollectorConfigEntry.GetRegistryHiveFromString(parts[0]);
                    cboRegistryHive.Text = rh.ToString();
                    txtPath.Text = txtPath.Text.Substring(parts[0].Length + 1);
                }
            }
        }
        private void chkValueIsANumber_CheckedChanged(object sender, EventArgs e)
        {
            //chkValueIsInARange.Enabled = chkValueIsANumber.Checked;
            //chkReturnValueNotInverted.Enabled = chkValueIsANumber.Checked;
        }
        private void chkUseRemoteServer_CheckedChanged(object sender, EventArgs e)
        {
            txtServer.Enabled = chkUseRemoteServer.Checked;
        }
        #endregion

        #region Button events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (DoValidate())
            {
                if (SelectedEntry == null)
                    SelectedEntry = new RegistryQueryCollectorConfigEntry();
                RegistryQueryCollectorConfigEntry selectedEntry = (RegistryQueryCollectorConfigEntry)SelectedEntry;

                selectedEntry.Name = txtName.Text;
                selectedEntry.UseRemoteServer = chkUseRemoteServer.Checked;
                selectedEntry.Server = txtServer.Text;
                selectedEntry.Path = txtPath.Text;
                selectedEntry.KeyName = txtKey.Text;
                selectedEntry.ExpandEnvironmentNames = chkExpandEnvNames.Checked;
                selectedEntry.RegistryHive = RegistryQueryCollectorConfigEntry.GetRegistryHiveFromString(cboRegistryHive.Text);

                if (!chkValueIsANumber.Checked)
                {
                    selectedEntry.ReturnValueIsNumber = false;
                }
                else
                {
                    selectedEntry.ReturnValueIsNumber = true;
                }

                selectedEntry.ReturnCheckSequence = (CollectorAgentReturnValueCheckSequence)cboReturnCheckSequence.SelectedIndex;
                selectedEntry.GoodValue = txtSuccess.Text;
                selectedEntry.GoodResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
                selectedEntry.WarningValue = txtWarning.Text;
                selectedEntry.WarningResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
                selectedEntry.ErrorValue = txtError.Text;
                selectedEntry.ErrorResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;
                selectedEntry.OutputValueUnit = cboOutputValueUnit.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        private void cmdTest_Click(object sender, EventArgs e)
        {
            if (DoValidate())
            {
                string lastStep = "Initialize values";
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    RegistryQueryCollectorConfigEntry testQueryInstance = new RegistryQueryCollectorConfigEntry();
                    testQueryInstance.Name = txtName.Text;
                    testQueryInstance.UseRemoteServer = chkUseRemoteServer.Checked;
                    testQueryInstance.Server = txtServer.Text;
                    testQueryInstance.Path = txtPath.Text;
                    testQueryInstance.KeyName = txtKey.Text;
                    testQueryInstance.ExpandEnvironmentNames = chkExpandEnvNames.Checked;
                    testQueryInstance.RegistryHive = RegistryQueryCollectorConfigEntry.GetRegistryHiveFromString(cboRegistryHive.Text);

                    if (!chkValueIsANumber.Checked)
                    {
                        testQueryInstance.ReturnValueIsNumber = false;
                    }
                    else
                    {
                        testQueryInstance.ReturnValueIsNumber = true;
                    }

                    testQueryInstance.ReturnCheckSequence = (CollectorAgentReturnValueCheckSequence)cboReturnCheckSequence.SelectedIndex;
                    testQueryInstance.GoodValue = txtSuccess.Text;
                    testQueryInstance.GoodResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
                    testQueryInstance.WarningValue = txtWarning.Text;
                    testQueryInstance.WarningResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
                    testQueryInstance.ErrorValue = txtError.Text;
                    testQueryInstance.ErrorResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;
                    testQueryInstance.OutputValueUnit = cboOutputValueUnit.Text;

                    object returnValue = null;
                    //returnValue = testQueryInstance.GetValue();
                    CollectorState state = testQueryInstance.GetCurrentState().State;
                    returnValue = testQueryInstance.CurrentAgentValue;
                    if (state == CollectorState.Good)
                    {
                        MessageBox.Show(string.Format("Success!\r\nValue return: {0}", FormatUtils.FormatArrayToString(returnValue)), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (state == CollectorState.Warning)
                    {
                        MessageBox.Show(string.Format("Warning!\r\nValue return: {0}", FormatUtils.FormatArrayToString(returnValue)), "Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show(string.Format("Error!\r\nValue return: {0}", FormatUtils.FormatArrayToString(returnValue)), "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Failed!\r\nLast step: {0}\r\n{1}", lastStep, ex.Message), "Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
        private void cmdRegedit_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo("regedit.exe");
                p.StartInfo.Verb = "runas";
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Regedit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Private methods
        private bool DoValidate()
        {
            try
            {
                if (txtName.Text.Length == 0)
                    throw new InPutValidationException("Name must be specified!", txtName);
                if (chkUseRemoteServer.Checked && txtServer.Text.Length == 0)
                    throw new InPutValidationException("The server/machine name must be specified!", txtServer);
                if (cboRegistryHive.SelectedIndex == -1)
                    throw new InPutValidationException("The Registry Hive must be specified!", cboRegistryHive);
                if (txtPath.Text.Trim().Length == 0)
                    throw new InPutValidationException("The Path must be specified!", txtPath);
                //if (txtKey.Text.Trim().Length == 0)
                //    throw new InPutValidationException("The Key must be specified!", txtKey);
                if (txtSuccess.Text == txtWarning.Text || txtWarning.Text == txtError.Text)
                {
                    throw new InPutValidationException("Success, Warning and error values must be unique!", txtSuccess);
                }
                if ((txtSuccess.Text == "[null]" && txtWarning.Text == "[null]") ||
                    (txtSuccess.Text == "[null]" && txtError.Text == "[null]") ||
                    (txtWarning.Text == "[null]" && txtError.Text == "[null]"))
                {
                    throw new InPutValidationException("Only one value can be [null]!", txtSuccess);
                }
                if ((txtSuccess.Text == "[any]" && txtWarning.Text == "[any]") ||
                    (txtSuccess.Text == "[any]" && txtError.Text == "[any]") ||
                    (txtWarning.Text == "[any]" && txtError.Text == "[any]"))
                {
                    throw new InPutValidationException("Only one value can be [any]!", txtSuccess);
                }
                if ((txtSuccess.Text == "[exists]" && txtWarning.Text == "[exists]") ||
                    (txtSuccess.Text == "[exists]" && txtError.Text == "[exists]") ||
                    (txtWarning.Text == "[exists]" && txtError.Text == "[exists]"))
                {
                    throw new InPutValidationException("Only one value can be [exists]!", txtSuccess);
                }
                if ((txtSuccess.Text == "[notExists]" && txtWarning.Text == "[notExists]") ||
                    (txtSuccess.Text == "[notExists]" && txtError.Text == "[notExists]") ||
                    (txtWarning.Text == "[notExists]" && txtError.Text == "[notExists]"))
                {
                    throw new InPutValidationException("Only one value can be [notExists]!", txtSuccess);
                }
                if (chkValueIsANumber.Checked)
                {
                    if (txtSuccess.Text == "[exists]" || txtSuccess.Text == "[notExists]" ||
                        txtWarning.Text == "[exists]" || txtWarning.Text == "[notExists]" ||
                        txtError.Text == "[exists]" || txtError.Text == "[notExists]")
                    {
                        throw new InPutValidationException("The values [exists] and [notExists] cannot be used when testing for numbers!", txtSuccess);
                    }
                    if (txtSuccess.Text != "[null]" && txtSuccess.Text != "[any]" && !txtSuccess.Text.IsLong())
                        throw new InPutValidationException("Success value must be a valid integer!\r\n(or predefined values [any] or [null])", txtSuccess);
                    else if (txtWarning.Text != "[null]" && txtWarning.Text != "[any]" && !txtWarning.Text.IsLong())
                        throw new InPutValidationException("Warning value must be a valid integer!\r\n(or predefined values [any] or [null])", txtWarning);
                    else if (txtError.Text != "[null]" && txtError.Text != "[any]" && !txtError.Text.IsLong())
                        throw new InPutValidationException("Error value must be a valid integer!\r\n(or predefined values [any] or [null])", txtError);                    
                }
                return true;
            }
            catch (InPutValidationException ex)
            {
                MessageBox.Show(ex.Message, "Input Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (ex.ValidatedObject is Control)
                {
                    Control theControl = ((Control)ex.ValidatedObject);
                    ((Control)ex.ValidatedObject).Focus();
                }
                return false;
            }
        }
        private void CheckOKEnabled()
        {
            cmdOK.Enabled = txtName.Text.Length > 0 && txtPath.Text.Length > 0;// && txtKey.Text.Length > 0;
            cmdTest.Enabled = txtName.Text.Length > 0 && txtPath.Text.Length > 0;// && txtKey.Text.Length > 0;
        }
        #endregion

        #region Change checking
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        #endregion
    }
}
