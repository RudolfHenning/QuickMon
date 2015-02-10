using QuickMon.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public partial class ConnectionStringBuilder : Form
    {
        public ConnectionStringBuilder()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }

        private void ConnectionStringBuilder_Load(object sender, EventArgs e)
        {
            LoadProviders();
            txtConnectionString.Text = ConnectionString;
            cmdReadFromConnString_Click(null, null);
        }

        #region Private methods
        private void LoadProviders()
        {
            cboProvider.Items.Clear();
            cboProvider.Items.Add(new ComboItem() { Text = "Microsoft Jet 4.0 (32-bit only)", Value = "Microsoft.Jet.OLEDB.4.0" });
            cboProvider.Items.Add(new ComboItem() { Text = "Microsoft ACE 12.0 (Jet 64-bit support)", Value = "Microsoft.ACE.OLEDB.12.0" });
            cboProvider.Items.Add(new ComboItem() { Text = "OLE DB provider for SQL Server", Value = "sqloledb" });
            cboProvider.Items.Add(new ComboItem() { Text = "OLE DB provider for Oracle", Value = "msdaora" });
            cboProvider.Items.Add(new ComboItem() { Text = "OLE DB provider for MySQL", Value = "MySQLProv" });

        }
        private void SetProviderFromText(string text = "")
        {
            if (text == "")
            {
                text = cboProvider.Text;
            }
            foreach (ComboItem c in cboProvider.Items)
            {
                if (c.Value.ToString().ToLower() == text.ToLower())
                {
                    cboProvider.Text = c.Text;
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
                if (c.Text.ToLower() == text.ToLower())
                {
                    return c.Value.ToString();
                }
            }
            return text;
        }
        #endregion

        private void cmdConstructConnString_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnectionStringBuilder connbuilder = new OleDbConnectionStringBuilder();
                connbuilder.DataSource = txtDataSource.Text;
                connbuilder.Provider = GetProviderFromCombo();
                if (txtUserName.Text.Length > 0 && (!(txtUserName.Text.ToLower() == "admin" && txtPassword.Text.Length == 0)))
                {
                    connbuilder["User Id"] = txtUserName.Text;
                    if (txtPassword.Text.Length > 0)
                        connbuilder["Password"] = txtPassword.Text;
                }
                if (txtInitialCatalogue.Text.Length > 0)
                    connbuilder["Initial Catalog"] = txtInitialCatalogue.Text;
                if (txtServer.Text.Length > 0)
                    connbuilder["Server"] = txtServer.Text;
                if (txtDatabase.Text.Length > 0)
                    connbuilder["Database"] = txtDatabase.Text;
                if (chkPersistSecurityInfo.Checked)
                    connbuilder.PersistSecurityInfo = chkPersistSecurityInfo.Checked;
                if ((byte)chkTrustedConnection.CheckState != 2)
                {
                    connbuilder["Trusted_Connection"] = (byte)chkTrustedConnection.CheckState == 1;
                }
                txtConnectionString.Text = connbuilder.ConnectionString;
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
                OleDbConnectionStringBuilder connbuilder = new OleDbConnectionStringBuilder();
                connbuilder.ConnectionString = txtConnectionString.Text;                
                try
                {
                    txtDataSource.Text = connbuilder.DataSource;
                    if (connbuilder.DataSource.Length == 0)
                        txtDataSource.Text = connbuilder["Data Source"].ToString();
                }
                catch { }                
                try
                {
                    SetProviderFromText(connbuilder.Provider);
                    if (connbuilder.Provider.Length == 0)
                        SetProviderFromText(connbuilder["Provider"].ToString());
                }
                 catch { }
                try
                {
                    if (connbuilder["User Id"] != null)
                        txtUserName.Text = connbuilder["User Id"].ToString();
                }
                catch { }
                try
                {
                    if (connbuilder["Password"] != null)
                        txtPassword.Text = connbuilder["Password"].ToString();
                }
                catch { }
                try
                {
                    if (connbuilder["Initial Catalog"] != null)
                        txtInitialCatalogue.Text = connbuilder["Initial Catalog"].ToString();
                }
                catch { }
                try
                {
                    if (connbuilder["Server"] != null)
                        txtServer.Text = connbuilder["Server"].ToString();
                }
                catch { }
                try
                {
                    if (connbuilder["Database"] != null)
                        txtDatabase.Text = connbuilder["Database"].ToString();
                }
                catch { }
                chkPersistSecurityInfo.Checked = connbuilder.PersistSecurityInfo;
                try
                {
                    if (connbuilder["Trusted_Connection"] != null)
                        chkTrustedConnection.CheckState = (CheckState)((connbuilder["Trusted_Connection"].ToString().ToLower() == "true" || connbuilder["Trusted_Connection"].ToString().ToLower() == "yes") ? (byte)1 : (byte)0);
                    else
                        chkTrustedConnection.CheckState = (CheckState) 2;
                }
                catch { }
            }
            catch (Exception ex)
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
