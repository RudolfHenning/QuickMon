﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class EditActionScript : Form
    {
        public EditActionScript()
        {
            InitializeComponent();
        }

        public ActionScript SelectedActionScript { get; set; }

        private void EditActionScript_Load(object sender, EventArgs e)
        {
            if (SelectedActionScript == null)
                SelectedActionScript = new ActionScript();

            txtName.Text = SelectedActionScript.Name;
            optDOS.Checked = SelectedActionScript.ScriptType == ScriptType.DOS;
            optPowerShell.Checked = SelectedActionScript.ScriptType == ScriptType.PowerShell;
            cboWindowSizeStyle.SelectedIndex = (int)SelectedActionScript.WindowSizeStyle;
            chkAdminMode.Checked = SelectedActionScript.RunAdminMode;
            txtDescription.Text = SelectedActionScript.Description;
            txtScript.Text = SelectedActionScript.Script;
            chkIsRestorationScript.Checked = SelectedActionScript.IsRestorationScript;
            chkIsWarningCorrectiveScript.Checked = SelectedActionScript.IsWarningCorrectiveScript;
            chkIsErrorCorrectiveScript.Checked = SelectedActionScript.IsErrorCorrectiveScript;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void txtScript_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void CheckOKEnabled()
        {
            cmdOK.Enabled = txtName.Text.Length > 1 && txtScript.Text.Length > 1;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedActionScript.Name = txtName.Text;
            SelectedActionScript.ScriptType = optDOS.Checked ? ScriptType.DOS : ScriptType.PowerShell;
            SelectedActionScript.WindowSizeStyle = (WindowSizeStyle)cboWindowSizeStyle.SelectedIndex;
            SelectedActionScript.RunAdminMode = chkAdminMode.Checked;
            SelectedActionScript.Description = txtDescription.Text;
            SelectedActionScript.Script = txtScript.Text;
            SelectedActionScript.IsRestorationScript = chkIsRestorationScript.Checked;
            SelectedActionScript.IsWarningCorrectiveScript = chkIsWarningCorrectiveScript.Checked;
            SelectedActionScript.IsErrorCorrectiveScript = chkIsErrorCorrectiveScript.Checked;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void llnkExecutionPolicy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string output = Collectors.PowerShellScriptRunnerEntry.RunScript("Set-ExecutionPolicy RemoteSigned");
                if (output == null || output.Length == 0)
                    output = "No output.";
                MessageBox.Show(output, "ExecutionPolicy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ActionScript psEp = new ActionScript();
                //psEp.Name = "SetExecutionPolicy";
                //psEp.RunAdminMode = true;
                //psEp.ScriptType = ScriptType.PowerShell;
                //psEp.WindowSizeStyle = WindowSizeStyle.Normal;
                //psEp.Script = "Set-ExecutionPolicy RemoteSigned";
                //psEp.PSNoExitSet = true;
                //psEp.Run(true);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error setting ExecutionPolicy!\r\n" + ex.Message, "ExecutionPolicy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
