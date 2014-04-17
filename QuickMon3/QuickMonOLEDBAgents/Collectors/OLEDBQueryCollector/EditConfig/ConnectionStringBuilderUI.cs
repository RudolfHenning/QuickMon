using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HenIT.Utils;

namespace HenIT.Data.OLEDB
{
    public partial class ConnectionStringBuilderUI : Form
    {
        public ConnectionStringBuilderUI()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }


        private void ConnectionStringBuilderUI_Load(object sender, EventArgs e)
        {
            LoadProviders();
            txtConnectionString.Text = ConnectionString;
            cmdReadFromConnString_Click(null, null);
        }

        #region Private methods
        private void LoadProviders()
        {
            cboProvider.Items.Clear();
            cboProvider.Items.Add(new ComboItem() { DisplayName = "Microsoft Jet 4.0 (32-bit only)", Value = "Microsoft.Jet.OLEDB.4.0" });
            cboProvider.Items.Add(new ComboItem() { DisplayName = "Microsoft ACE 12.0 (Jet 64-bit support)", Value = "Microsoft.ACE.OLEDB.12.0" });
            cboProvider.Items.Add(new ComboItem() { DisplayName = "OLE DB provider for SQL Server", Value = "sqloledb" });
            cboProvider.Items.Add(new ComboItem() { DisplayName = "OLE DB provider for Oracle", Value = "msdaora" });
            cboProvider.Items.Add(new ComboItem() { DisplayName = "OLE DB provider for MySQL", Value = "MySQLProv" });

        }
        private void SetProviderFromText(string text = "")
        {
            if (text == "")
            {
                text = cboProvider.Text;
            }
            foreach (ComboItem c in cboProvider.Items)
            {
                if (c.Value.ToLower() == text.ToLower())
                {
                    cboProvider.Text = c.DisplayName;
                    return;
                }
            }
            cboProvider.Text = text;
        }
        private string GetProviderFromCombo()
        {
            string text = cboProvider.Text;
            foreach (ComboItem c in cboProvider.Items)
            {
                if (c.DisplayName.ToLower() == text.ToLower())
                {
                    return c.Value;
                }
            }
            return text;
        }
        #endregion

        private void llblConnStrTips_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo("http://www.connectionstrings.com/");
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdConstructConnString_Click(object sender, EventArgs e)
        {
            try
            {
                GenericOLEDBDAL dal = new GenericOLEDBDAL();
                dal.DataSource = txtDataSource.Text;
                dal.Provider = GetProviderFromCombo();
                dal.UserName = txtUserName.Text;
                dal.Password = txtPassword.Text;
                dal.InitialCatalogue = txtInitialCatalogue.Text;
                dal.Server = txtServer.Text;
                dal.Database = txtDatabase.Text;
                dal.PersistSecurityInfo = chkPersistSecurityInfo.Checked;
                dal.TrustedConnection = (byte)chkTrustedConnection.CheckState;
                txtConnectionString.Text = dal.GetConnectionString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdReadFromConnString_Click(object sender, EventArgs e)
        {
            try
            {
                GenericOLEDBDAL dal = new GenericOLEDBDAL();
                dal.ConnectionString = txtConnectionString.Text;
                txtDataSource.Text = dal.DataSource;
                SetProviderFromText(dal.Provider);
                txtUserName.Text = dal.UserName;
                txtPassword.Text = dal.Password;
                txtServer.Text = dal.Server;
                txtDatabase.Text = dal.Database;
                txtInitialCatalogue.Text = dal.InitialCatalogue;
                chkPersistSecurityInfo.Checked = dal.PersistSecurityInfo;
                chkTrustedConnection.CheckState = (CheckState)dal.TrustedConnection;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            ConnectionString = txtConnectionString.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }


    }
}
