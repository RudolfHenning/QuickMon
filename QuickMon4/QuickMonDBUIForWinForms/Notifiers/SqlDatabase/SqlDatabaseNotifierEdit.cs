using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Notifiers
{
    public partial class SqlDatabaseNotifierEdit : Form, IAgentConfigEntryEditWindow
    {
        public SqlDatabaseNotifierEdit()
        {
            InitializeComponent();
        }

        public IAgentConfig SelectedEntry { get; set; }
        public QuickMonDialogResult ShowEditEntry()
        {
            
            return (QuickMonDialogResult)ShowDialog();
        }

        private void SqlDatabaseNotifierEdit_Load(object sender, EventArgs e)
        {
            LoadEditData();
        }
        public void LoadEditData()
        {
            if (SelectedEntry == null)
                SelectedEntry = new SqlDatabaseNotifierConfig();
            SqlDatabaseNotifierConfig currentConfig = (SqlDatabaseNotifierConfig)SelectedEntry;

            txtServer.Text = currentConfig.SqlServer;
            txtDatabase.Text = currentConfig.Database;
            chkIntegratedSec.Checked = currentConfig.IntegratedSec;
            txtUserName.Text = currentConfig.UserName;
            txtPassword.Text = currentConfig.Password;
            numericUpDownCmndTimeOut.Value = currentConfig.CmndTimeOut;
            chkUseSP.Checked = currentConfig.UseSP;
            txtCmndValue.Text = currentConfig.CmndValue;
            txtAlertFieldName.Text = currentConfig.AlertFieldName;
            txtCategoryFieldName.Text = currentConfig.CategoryFieldName;
            txtPreviousStateFieldName.Text = currentConfig.PreviousStateFieldName;
            txtCurrentStateFieldName.Text = currentConfig.CurrentStateFieldName;
            txtDetailsFieldName.Text = currentConfig.DetailsFieldName;
            chkUseSP2.Checked = currentConfig.UseSPForViewer;
            txtViewerName.Text = currentConfig.ViewerName;
            txtDateTimeFieldName.Text = currentConfig.DateTimeFieldName;
        }
        private void CheckOKEnabled()
        {
            cmdOK.Enabled = txtServer.Text.Trim().Length > 0 && txtDatabase.Text.Trim().Length > 0;
        }
        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

    }
}
