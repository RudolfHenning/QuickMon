using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Utils;

namespace QuickMon.Collectors
{
    public partial class RegistryQueryCollectorEditInstance : Form, IEditConfigEntryWindow
    {
        public RegistryQueryCollectorEditInstance()
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

        public RegistryQueryInstance SelectedRegistryQueryInstance { get; set; }

        #region Form events
        private void EditRegistryQueryInstance_Shown(object sender, EventArgs e)
        {
            RegistryQueryInstance selectedEntry;
            if (SelectedEntry != null)
                selectedEntry = (RegistryQueryInstance)SelectedEntry;
            else
                selectedEntry = (RegistryQueryInstance)SelectedRegistryQueryInstance;

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
                chkValueIsInARange.Checked = selectedEntry.ReturnValueInARange;
                chkReturnValueNotInverted.Checked = !selectedEntry.ReturnValueInverted;
                cboSuccessValue.Text = selectedEntry.SuccessValue;
                cboWarningValue.Text = selectedEntry.WarningValue;
                cboErrorValue.Text = selectedEntry.ErrorValue;
            }
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
                    Microsoft.Win32.RegistryHive rh = RegistryQueryInstance.GetRegistryHiveFromString(parts[0]);
                    cboRegistryHive.Text = rh.ToString();
                    txtPath.Text = txtPath.Text.Substring(parts[0].Length + 1);
                }
            }
        }
        private void chkValueIsANumber_CheckedChanged(object sender, EventArgs e)
        {
            chkValueIsInARange.Enabled = chkValueIsANumber.Checked;
            chkReturnValueNotInverted.Enabled = chkValueIsANumber.Checked;
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
                RegistryQueryInstance selectedEntry;
                if (SelectedEntry != null)
                    selectedEntry = (RegistryQueryInstance)SelectedEntry;
                else if (SelectedRegistryQueryInstance != null)
                    selectedEntry = (RegistryQueryInstance)SelectedRegistryQueryInstance;
                else
                {
                    selectedEntry = new RegistryQueryInstance();
                    SelectedEntry = selectedEntry;
                }

                selectedEntry.Name = txtName.Text;
                selectedEntry.UseRemoteServer = chkUseRemoteServer.Checked;
                selectedEntry.Server = txtServer.Text;
                selectedEntry.Path = txtPath.Text;
                selectedEntry.KeyName = txtKey.Text;
                selectedEntry.ExpandEnvironmentNames = chkExpandEnvNames.Checked;
                selectedEntry.RegistryHive = RegistryQueryInstance.GetRegistryHiveFromString(cboRegistryHive.Text);

                if (!chkValueIsANumber.Checked)
                {
                    selectedEntry.ReturnValueIsNumber = false;
                    selectedEntry.ReturnValueInARange = false;
                    selectedEntry.ReturnValueInverted = false;
                }
                else
                {
                    selectedEntry.ReturnValueIsNumber = true;
                    selectedEntry.ReturnValueInARange = chkValueIsInARange.Checked;
                    selectedEntry.ReturnValueInverted = !chkReturnValueNotInverted.Checked;
                }

                selectedEntry.SuccessValue = cboSuccessValue.Text;
                selectedEntry.WarningValue = cboWarningValue.Text;
                selectedEntry.ErrorValue = cboErrorValue.Text;
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
                    RegistryQueryInstance testQueryInstance = new RegistryQueryInstance();
                    testQueryInstance.Name = txtName.Text;
                    testQueryInstance.UseRemoteServer = chkUseRemoteServer.Checked;
                    testQueryInstance.Server = txtServer.Text;
                    testQueryInstance.Path = txtPath.Text;
                    testQueryInstance.KeyName = txtKey.Text;
                    testQueryInstance.ExpandEnvironmentNames = chkExpandEnvNames.Checked;
                    testQueryInstance.RegistryHive = RegistryQueryInstance.GetRegistryHiveFromString(cboRegistryHive.Text);

                    if (!chkValueIsANumber.Checked)
                    {
                        testQueryInstance.ReturnValueIsNumber = false;
                        testQueryInstance.ReturnValueInARange = false;
                        testQueryInstance.ReturnValueInverted = false;
                    }
                    else
                    {
                        testQueryInstance.ReturnValueIsNumber = true;
                        testQueryInstance.ReturnValueInARange = chkValueIsInARange.Checked;
                        testQueryInstance.ReturnValueInverted = !chkReturnValueNotInverted.Checked;
                    }

                    testQueryInstance.SuccessValue = cboSuccessValue.Text;
                    testQueryInstance.WarningValue = cboWarningValue.Text;
                    testQueryInstance.ErrorValue = cboErrorValue.Text;

                    object returnValue = null;
                    returnValue = testQueryInstance.GetValue();
                    CollectorState state = testQueryInstance.EvaluateValue(returnValue);
                    if (state == CollectorState.Good)
                    {
                        MessageBox.Show(string.Format("Success!\r\nValue return: {0}", returnValue), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (state == CollectorState.Warning)
                    {
                        MessageBox.Show(string.Format("Warning!\r\nValue return: {0}", returnValue), "Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show(string.Format("Error!\r\nValue return: {0}", returnValue), "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            catch(Exception ex)
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
                if (cboSuccessValue.Text == cboWarningValue.Text || cboWarningValue.Text == cboErrorValue.Text)
                {
                    throw new InPutValidationException("Success, Warning and error values must be unique!", cboSuccessValue);
                }
                if ((cboSuccessValue.Text == "[null]" && cboWarningValue.Text == "[null]") ||
                    (cboSuccessValue.Text == "[null]" && cboErrorValue.Text == "[null]") ||
                    (cboWarningValue.Text == "[null]" && cboErrorValue.Text == "[null]"))
                {
                    throw new InPutValidationException("Only one value can be [null]!", cboSuccessValue);
                }
                if ((cboSuccessValue.Text == "[any]" && cboWarningValue.Text == "[any]") ||
                    (cboSuccessValue.Text == "[any]" && cboErrorValue.Text == "[any]") ||
                    (cboWarningValue.Text == "[any]" && cboErrorValue.Text == "[any]"))
                {
                    throw new InPutValidationException("Only one value can be [any]!", cboSuccessValue);
                }
                if ((cboSuccessValue.Text == "[exists]" && cboWarningValue.Text == "[exists]") ||
                    (cboSuccessValue.Text == "[exists]" && cboErrorValue.Text == "[exists]") ||
                    (cboWarningValue.Text == "[exists]" && cboErrorValue.Text == "[exists]"))
                {
                    throw new InPutValidationException("Only one value can be [exists]!", cboSuccessValue);
                }
                if ((cboSuccessValue.Text == "[notExists]" && cboWarningValue.Text == "[notExists]") ||
                    (cboSuccessValue.Text == "[notExists]" && cboErrorValue.Text == "[notExists]") ||
                    (cboWarningValue.Text == "[notExists]" && cboErrorValue.Text == "[notExists]"))
                {
                    throw new InPutValidationException("Only one value can be [notExists]!", cboSuccessValue);
                }
                if (chkValueIsANumber.Checked)
                {
                    if (cboSuccessValue.Text == "[exists]" || cboSuccessValue.Text == "[notExists]" ||
                        cboWarningValue.Text == "[exists]" || cboWarningValue.Text == "[notExists]" ||
                        cboErrorValue.Text == "[exists]" || cboErrorValue.Text == "[notExists]")
                    {
                        throw new InPutValidationException("The values [exists] and [notExists] cannot be used when testing for numbers!", cboSuccessValue);
                    }
                    if (cboSuccessValue.Text != "[null]" && cboSuccessValue.Text != "[any]" && !cboSuccessValue.Text.IsLong())
                        throw new InPutValidationException("Success value must be a valid integer!\r\n(or predefined values [any] or [null])", cboSuccessValue);
                    else if (cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" && !cboWarningValue.Text.IsLong())
                        throw new InPutValidationException("Warning value must be a valid integer!\r\n(or predefined values [any] or [null])", cboWarningValue);
                    else if (cboErrorValue.Text != "[null]" && cboErrorValue.Text != "[any]" && !cboErrorValue.Text.IsLong())
                        throw new InPutValidationException("Error value must be a valid integer!\r\n(or predefined values [any] or [null])", cboErrorValue);
                    else if (chkReturnValueNotInverted.Checked)
                    {
                        if (cboSuccessValue.Text != "[null]" && cboSuccessValue.Text != "[any]" &&
                            cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" &&
                            long.Parse(cboSuccessValue.Text) >= long.Parse(cboWarningValue.Text))
                            throw new InPutValidationException("Success value must smaller than Warning value", cboSuccessValue);
                        else if (cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" &&
                            cboErrorValue.Text != "[null]" && cboErrorValue.Text != "[any]" &&
                            int.Parse(cboWarningValue.Text) >= long.Parse(cboErrorValue.Text))
                            throw new InPutValidationException("Warning value must smaller than Error value", cboWarningValue);
                    }
                    else if (!chkReturnValueNotInverted.Checked)
                    {
                        if (cboSuccessValue.Text != "[null]" && cboSuccessValue.Text != "[any]" &&
                            cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" &&
                            long.Parse(cboSuccessValue.Text) <= long.Parse(cboWarningValue.Text))
                            throw new InPutValidationException("Success value must bigger than Warning value", cboSuccessValue);
                        else if (cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" &&
                            cboErrorValue.Text != "[null]" && cboErrorValue.Text != "[any]" &&
                            long.Parse(cboWarningValue.Text) <= long.Parse(cboErrorValue.Text))
                            throw new InPutValidationException("Warning value must bigger than Error value", cboWarningValue);
                    }
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
