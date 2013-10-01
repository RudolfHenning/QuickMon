using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class EditTableSizeEntry : Form
    {
        public EditTableSizeEntry()
        {
            InitializeComponent();
            DatabaseEntry = new DatabaseEntry();
        }

        public DatabaseEntry DatabaseEntry { get; set; }

        private bool selfUpdating = false;

        #region Form events
        private void EditTableSizeEntry_Shown(object sender, EventArgs e)
        {
            txtServer.Text = DatabaseEntry.SqlServer;
            chkIntegratedSec.Checked = DatabaseEntry.IntegratedSecurity;
            txtUserName.Text = DatabaseEntry.UserName;
            txtPassword.Text = DatabaseEntry.Password;
            LoadDatabases();
            cboDatabase.SelectedItem = DatabaseEntry.Name;
            LoadTables();
        } 
        #endregion

        #region ListView events
        private void lvwTables_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            CheckOKEnabled();
        }
        private void lvwTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selfUpdating)
                return;
            selfUpdating = true;
            if (lvwTables.SelectedItems.Count > 0)
            {
                warningNumericUpDown.Value = decimal.Parse(lvwTables.SelectedItems[0].SubItems[1].Text);
                errorNumericUpDown.Value = decimal.Parse(lvwTables.SelectedItems[0].SubItems[2].Text);
                cmdUpdateTable.Enabled = true;
            }
            else
                cmdUpdateTable.Enabled = false;
            selfUpdating = false;
        }
        #endregion

        #region Button events
        private void cmdLoadDatabases_Click(object sender, EventArgs e)
        {
            LoadDatabases();
        }
        private void cmdLoadTables_Click(object sender, EventArgs e)
        {
            LoadTables();
        }
        private void cmdUpdateTable_Click(object sender, EventArgs e)
        {
            if (selfUpdating)
                return;
            selfUpdating = true;
            if (lvwTables.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lvwTables.SelectedItems)
                {
                    lvi.SubItems[1].Text = warningNumericUpDown.Value.ToString();
                    lvi.SubItems[2].Text = errorNumericUpDown.Value.ToString();
                }
                CheckOKEnabled();
            }
            selfUpdating = false;
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            DatabaseEntry.TableSizeEntries = new List<TableSizeEntry>();
            DatabaseEntry.SqlServer = txtServer.Text;
            DatabaseEntry.IntegratedSecurity = chkIntegratedSec.Checked;
            DatabaseEntry.UserName = txtUserName.Text;
            DatabaseEntry.Password = txtPassword.Text;
            DatabaseEntry.Name = cboDatabase.Text;
            foreach (ListViewItem lvi in lvwTables.CheckedItems)
            {
                TableSizeEntry tableSizeEntry = new TableSizeEntry();
                tableSizeEntry.TableName = lvi.Text;
                tableSizeEntry.WarningValue = long.Parse(lvi.SubItems[1].Text);
                tableSizeEntry.ErrorValue = long.Parse(lvi.SubItems[2].Text);
                DatabaseEntry.TableSizeEntries.Add(tableSizeEntry);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        #endregion

        #region Other control events
        private void chkIntegratedSec_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.ReadOnly = chkIntegratedSec.Checked;
            txtPassword.ReadOnly = chkIntegratedSec.Checked;
        }
        private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTables();
        }
        private void warningNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            cmdUpdateTable_Click(null, null);
        }
        private void errorNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            cmdUpdateTable_Click(null, null);
        }
        #endregion

        #region Private methods
        private void LoadTables()
        {
            string sql = "select t.name, i.[rows] from sys.sysindexes i inner join sys.tables t on t.object_id = i.id where i.indid in (0, 1, 255) order by t.name";
            try
            {
                lvwTables.Items.Clear();
                if (cboDatabase.Text.Length > 0)
                {
                    SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                    scsb.DataSource = txtServer.Text;
                    scsb.InitialCatalog = cboDatabase.Text;
                    scsb.IntegratedSecurity = chkIntegratedSec.Checked;
                    scsb.UserID = txtUserName.Text;
                    scsb.Password = txtPassword.Text;
                    using (SqlConnection conn = new SqlConnection(scsb.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmnd = new SqlCommand(sql, conn))
                        {
                            cmnd.CommandType = CommandType.Text;
                            using (SqlDataReader r = cmnd.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                    string tableName = r[0].ToString();
                                    long currentCount = long.Parse(r[1].ToString());
                                    long warning = 0;
                                    long error = 0;
                                    ListViewItem lvi = new ListViewItem(tableName);
                                    TableSizeEntry table = (from t in DatabaseEntry.TableSizeEntries
                                                            where t.TableName == tableName
                                                            select t).FirstOrDefault();
                                    if (table != null)
                                    {
                                        warning = table.WarningValue;
                                        error = table.ErrorValue;
                                        lvi.Checked = true;
                                    }
                                    lvi.SubItems.Add(warning.ToString());
                                    lvi.SubItems.Add(error.ToString());
                                    lvi.SubItems.Add(currentCount.ToString());
                                    lvwTables.Items.Add(lvi);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CheckOKEnabled();
        }
        private bool CheckOKEnabled()
        {
            cmdOK.Enabled = (lvwTables.CheckedItems.Count > 0) &&
                        ((from ListViewItem l in lvwTables.CheckedItems
                          where l.SubItems[1].Text == "0" || l.SubItems[2].Text == "0"
                          select l).Count() == 0);

            return cmdOK.Enabled;
        }
        private void LoadDatabases()
        {
            string sql = "select name from sys.databases order by name";
            //sql = "select name from sys.databases where not(owner_sid = 0x01) order by name";
            try
            {
                cboDatabase.Items.Clear();
                if (txtServer.Text.Length > 0)
                {
                    SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                    scsb.DataSource = txtServer.Text;
                    scsb.InitialCatalog = "master";
                    scsb.IntegratedSecurity = chkIntegratedSec.Checked;
                    scsb.UserID = txtUserName.Text;
                    scsb.Password = txtPassword.Text;
                    using (SqlConnection conn = new SqlConnection(scsb.ConnectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmnd = new SqlCommand(sql, conn))
                        {
                            cmnd.CommandType = CommandType.Text;
                            using (SqlDataReader dr = cmnd.ExecuteReader())
                            {
                                while (dr.Read())
                                    cboDatabase.Items.Add(dr[0].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }                
        #endregion
        

    }
}
