using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HenIT.Data.SqlClient;

namespace QuickMon.Collectors
{
    public partial class SqlTableSizeCollectorEditEntry : Form, IEditConfigEntryWindow
    {
        public SqlTableSizeCollectorEditEntry()
        {
            InitializeComponent();
        }

        #region IEditConfigEntryWindow Members
        public ICollectorConfigEntry SelectedEntry { get; set; }
        public DialogResult ShowEditEntry()
        {
            return ShowDialog();
        }
        #endregion

        public SqlTableSizeCollectorEntry SelectedSqlTableSizeEntry { get; set; }

        private void SqlTableSizeCollectorEditEntry_Load(object sender, EventArgs e)
        {
            SqlTableSizeCollectorEntry selectedEntry;
            if (SelectedEntry != null)
                selectedEntry = (SqlTableSizeCollectorEntry)SelectedEntry;
            else
                selectedEntry = (SqlTableSizeCollectorEntry)SelectedSqlTableSizeEntry;

            if (selectedEntry != null)
            {
                txtServer.Text = selectedEntry.SqlServer;
                cboDatabase.Text = selectedEntry.Database;
                chkIntegratedSec.Checked = selectedEntry.IntegratedSecurity;
                txtUserName.Text = selectedEntry.UserName;
                txtPassword.Text = selectedEntry.Password;
                numericUpDownCmndTimeOut.Value = selectedEntry.SqlCmndTimeOutSec;
                LoadDatabases();
                LoadTables();
            }
        }

        #region Private methods
        private void LoadDatabases()
        {
            try
            {
                if (txtServer.Text.Trim().Length > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    cboDatabase.Items.Clear();
                    GenericSQLServerDAL dal = new GenericSQLServerDAL();
                    dal.Server = txtServer.Text;
                    dal.Database = "master";
                    if (!chkIntegratedSec.Checked)
                    {
                        dal.UserName = txtUserName.Text;
                        dal.Password = txtPassword.Text;
                    }
                    dal.SetConnection();
                    DataSet tables = dal.GetDataSet("select name as DatabaseName From sysdatabases where dbid > 4 order by name", CommandType.Text);
                    if (tables.Tables.Count > 0 && tables.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in tables.Tables[0].Rows)
                            cboDatabase.Items.Add(r[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading databases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        private void LoadTables()
        {
            try
            {
                if (txtServer.Text.Trim().Length > 0 && cboDatabase.Text.Length > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    lvwTables.Items.Clear();
                    List<TableSizeInfo> tables = SqlTableSizeCollectorEntry.GetAllTableRowCounts(txtServer.Text, cboDatabase.Text, chkIntegratedSec.Checked, txtUserName.Text, txtPassword.Text, (int)numericUpDownCmndTimeOut.Value);
                    foreach (var table in tables)
                    {
                        ListViewItem lvi = new ListViewItem(table.Name);                        
                        lvi.SubItems.Add("0");
                        lvi.SubItems.Add("0");
                        lvi.SubItems.Add(table.Rows.ToString());
                        lvi.Tag = table;

                        SqlTableSizeCollectorEntry selectedEntry;
                        if (SelectedEntry != null)
                            selectedEntry = (SqlTableSizeCollectorEntry)SelectedEntry;
                        else
                            selectedEntry = (SqlTableSizeCollectorEntry)SelectedSqlTableSizeEntry;

                        if (selectedEntry != null && selectedEntry.Tables != null)
                        {
                            TableSizeEntry tse = (from t in selectedEntry.Tables
                                                  where t.TableName.ToLower() == table.Name.ToLower()
                                                  select t).FirstOrDefault();
                            if (tse != null)
                            {
                                lvi.Checked = true;
                                lvi.SubItems[1].Text = tse.WarningValue.ToString();
                                lvi.SubItems[2].Text = tse.ErrorValue.ToString();
                            }
                        }
                        lvwTables.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading tables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        private void CheckOkEnabled()
        {
            cmdOK.Enabled = txtServer.Text.Length > 0 && (chkIntegratedSec.Checked || txtUserName.Text.Length > 0) &&
                cboDatabase.Text.Length > 0 && lvwTables.CheckedItems.Count > 0 &&  
                (lvwTables.SelectedItems.Count == 0 || !lvwTables.SelectedItems[0].Checked || warningNumericUpDown.Value < errorNumericUpDown.Value);
        }
        #endregion

        #region Button events
        private void cmdLoadDatabases_Click(object sender, EventArgs e)
        {
            LoadDatabases();
        }
        private void cmdUpdateTable_Click(object sender, EventArgs e)
        {
            if (lvwTables.SelectedItems.Count == 1)
            {
                lvwTables.SelectedItems[0].SubItems[1].Text = ((int)warningNumericUpDown.Value).ToString();
                lvwTables.SelectedItems[0].SubItems[2].Text = ((int)errorNumericUpDown.Value).ToString();
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SqlTableSizeCollectorEntry selectedEntry;
            if (SelectedEntry != null)
                selectedEntry = (SqlTableSizeCollectorEntry)SelectedEntry;
            else if (SelectedSqlTableSizeEntry != null)
                selectedEntry = (SqlTableSizeCollectorEntry)SelectedSqlTableSizeEntry;
            else
            {
                selectedEntry = new SqlTableSizeCollectorEntry();
                SelectedEntry = selectedEntry;
                SelectedSqlTableSizeEntry = selectedEntry;
            }

            if (selectedEntry != null)
            {

                selectedEntry.SqlServer = txtServer.Text;
                selectedEntry.Database = cboDatabase.Text;
                selectedEntry.IntegratedSecurity = chkIntegratedSec.Checked;
                selectedEntry.UserName = txtUserName.Text;
                selectedEntry.Password = txtPassword.Text;
                selectedEntry.SqlCmndTimeOutSec = (int)numericUpDownCmndTimeOut.Value;
                selectedEntry.Tables.Clear();
                foreach (ListViewItem lvi in lvwTables.CheckedItems)
                {
                    TableSizeEntry tse = new TableSizeEntry()
                    {
                        TableName = lvi.Text,
                        WarningValue = int.Parse(lvi.SubItems[1].Text),
                        ErrorValue = int.Parse(lvi.SubItems[2].Text),
                        RowCount = int.Parse(lvi.SubItems[3].Text)
                    };
                    selectedEntry.Tables.Add(tse);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region Change Checking
        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void cboDatabase_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void lvwTables_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            CheckOkEnabled();
        }
        private void warningNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (lvwTables.SelectedItems.Count == 1)
            {
                lvwTables.SelectedItems[0].SubItems[1].Text = ((int)warningNumericUpDown.Value).ToString();
            }
            CheckOkEnabled();
        }
        private void errorNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (lvwTables.SelectedItems.Count == 1)
            {
                lvwTables.SelectedItems[0].SubItems[2].Text = ((int)errorNumericUpDown.Value).ToString();
            }
            CheckOkEnabled();
        }
        #endregion

        private void cboDatabase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadTables();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void lvwTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwTables.SelectedItems.Count == 1)
            {
                warningNumericUpDown.Value = int.Parse(lvwTables.SelectedItems[0].SubItems[1].Text);
                errorNumericUpDown.Value = int.Parse(lvwTables.SelectedItems[0].SubItems[2].Text);
                cmdUpdateTable.Enabled = true;
            }
            else
                cmdUpdateTable.Enabled = false;
        }


    }
}
