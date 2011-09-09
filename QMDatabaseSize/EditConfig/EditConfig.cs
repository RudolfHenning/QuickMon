using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class EditConfig : Form
    {
        public EditConfig()
        {
            InitializeComponent();
        }

        public string SqlServer { get; set; }
        public bool IntegratedSec { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CmndTimeOut { get; set; }
        public List<DatabaseEntry> Databases { get; set; }

        public DialogResult ShowConfig()
        {
            return ShowDialog();
        }

        private void lvwDatabases_Resize(object sender, EventArgs e)
        {
            lvwDatabases.Columns[0].Width = lvwDatabases.ClientSize.Width - lvwDatabases.Columns[1].Width - lvwDatabases.Columns[2].Width;
        }

        private void EditConfig_Load(object sender, EventArgs e)
        {
            txtServer.Text = SqlServer;
            chkIntegratedSec.Checked = IntegratedSec;
            txtUserName.Text = UserName;
            txtPassword.Text = Password;
            numericUpDownCmndTimeOut.Value = CmndTimeOut;
            LoadDatabases();
        }

        private void chkIntegratedSec_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.ReadOnly = chkIntegratedSec.Checked;
            txtPassword.ReadOnly = chkIntegratedSec.Checked;
            okEnabledtimer.Enabled = false;
            okEnabledtimer.Enabled = true;
        }

        private void LoadDatabases()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lvwDatabases.Items.Clear();
                lvwDatabases.BeginUpdate();
                foreach (DatabaseEntry dbe in Databases)
                {
                    if (dbe.Name.Length > 0)
                    {
                        ListViewItem lvi = new ListViewItem(dbe.Name);
                        lvi.SubItems.Add(dbe.WarningSizeMB.ToString());
                        lvi.SubItems.Add(dbe.ErrorSizeMB.ToString());
                        lvi.Tag = dbe;
                        lvwDatabases.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading databases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvwDatabases.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
        }

        private void lvwDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdRemove.Enabled = lvwDatabases.SelectedItems.Count > 0;
            if (lvwDatabases.SelectedItems.Count > 0 && lvwDatabases.SelectedItems[0].Tag != null && lvwDatabases.SelectedItems[0].Tag is DatabaseEntry)
            {
                DatabaseEntry dbe = (DatabaseEntry)lvwDatabases.SelectedItems[0].Tag;
                cboDatabase.Text = dbe.Name;
                warningNumericUpDown.Value = dbe.WarningSizeMB;
                errorNumericUpDown.Value = dbe.ErrorSizeMB;
            }
            else
            {
                cboDatabase.Text = "";
                warningNumericUpDown.Value = 1024;
                errorNumericUpDown.Value = 4096;
            }
        }

        private void cboDatabase_DropDown(object sender, EventArgs e)
        {
            DatabaseSizeInfo databaseSizeInfo = new DatabaseSizeInfo();            
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                cboDatabase.Items.Clear();
                databaseSizeInfo.OpenConnection(txtServer.Text, chkIntegratedSec.Checked, txtUserName.Text, txtPassword.Text, (int)numericUpDownCmndTimeOut.Value);
                foreach (string databaseName in databaseSizeInfo.GetDatabaseNames())
                {
                    cboDatabase.Items.Add(databaseName);
                }
                databaseSizeInfo.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Getting databases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cmdAddUpdateDB_Click(object sender, EventArgs e)
        {
            DatabaseEntry dbe = new DatabaseEntry();
            dbe.Name = cboDatabase.Text;
            dbe.WarningSizeMB = (int)warningNumericUpDown.Value;
            dbe.ErrorSizeMB = (int)errorNumericUpDown.Value;
            if (lvwDatabases.SelectedItems.Count > 0)
            {
                lvwDatabases.SelectedItems[0].Text = cboDatabase.Text;
                lvwDatabases.SelectedItems[0].SubItems[1].Text = warningNumericUpDown.Value.ToString();
                lvwDatabases.SelectedItems[0].SubItems[2].Text = errorNumericUpDown.Value.ToString();
                lvwDatabases.SelectedItems[0].Tag = dbe;
            }
            else
            {
                ListViewItem lvi = new ListViewItem(cboDatabase.Text);
                lvi.SubItems.Add(warningNumericUpDown.Value.ToString());
                lvi.SubItems.Add(errorNumericUpDown.Value.ToString());
                lvi.Tag = dbe;
                lvwDatabases.Items.Add(lvi);
            }
            cboDatabase.Text = "";
            warningNumericUpDown.Value = 1024;
            errorNumericUpDown.Value = 4096;
            okEnabledtimer.Enabled = false;
            okEnabledtimer.Enabled = true;
        }

        private void cboDatabase_TextChanged(object sender, EventArgs e)
        {
            checkAdUpdateEnabletimer.Enabled = false;
            checkAdUpdateEnabletimer.Enabled = true;            
        }

        private void checkAdUpdateEnabletimer_Tick(object sender, EventArgs e)
        {
            checkAdUpdateEnabletimer.Enabled = false;
            cmdAddUpdateDB.Enabled = cboDatabase.Text.Length > 0;
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove the selected entries?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (ListViewItem lvi in lvwDatabases.SelectedItems)
                {
                    lvwDatabases.Items.Remove(lvi);
                }
            }
            okEnabledtimer.Enabled = false;
            okEnabledtimer.Enabled = true;
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            DatabaseSizeInfo databaseSizeInfo = new DatabaseSizeInfo();
            string lastStep = "Opening connection";
            string details = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                databaseSizeInfo.OpenConnection(txtServer.Text, chkIntegratedSec.Checked, txtUserName.Text, txtPassword.Text, (int)numericUpDownCmndTimeOut.Value);
                foreach (ListViewItem lvi in lvwDatabases.Items)
                {
                    DatabaseEntry dbe = (DatabaseEntry)lvi.Tag;
                    lastStep = string.Format("Getting database size for: {0}", dbe.Name);
                    long size = databaseSizeInfo.GetDatabaseSize(dbe.Name);
                    details += string.Format("{0} - {1}MB\r\n", dbe.Name, size);
                }

                databaseSizeInfo.CloseConnection();
                MessageBox.Show("Test completed successfully!\r\n" + details, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Test failed!\r\nLast step: {0}\r\n{1}", lastStep, ex.Message), "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SqlServer = txtServer.Text;
            IntegratedSec = chkIntegratedSec.Checked;
            UserName = txtUserName.Text;
            Password = txtPassword.Text;
            CmndTimeOut = (int)numericUpDownCmndTimeOut.Value;
            Databases = new List<DatabaseEntry>();
            foreach (ListViewItem lvi in lvwDatabases.Items)
            {
                DatabaseEntry dbe = (DatabaseEntry)lvi.Tag;
                Databases.Add(dbe);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void okEnabledtimer_Tick(object sender, EventArgs e)
        {
            okEnabledtimer.Enabled = false;
            cmdOK.Enabled = txtServer.Text.Length > 0 && (chkIntegratedSec.Checked || txtUserName.Text.Length > 0);
            cmdTest.Enabled = txtServer.Text.Length > 0 && (chkIntegratedSec.Checked || txtUserName.Text.Length > 0) && lvwDatabases.Items.Count > 0;
        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            okEnabledtimer.Enabled = false;
            okEnabledtimer.Enabled = true;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            okEnabledtimer.Enabled = false;
            okEnabledtimer.Enabled = true;
        }

        private void lblDatabase_DoubleClick(object sender, EventArgs e)
        {
            DatabaseSizeInfo databaseSizeInfo = new DatabaseSizeInfo();
            string lastStep = "Opening connection";
            string details = "";
            try
            {
                if (cboDatabase.Text.Length == 0)
                    return;
                Cursor.Current = Cursors.WaitCursor;
                databaseSizeInfo.OpenConnection(txtServer.Text, chkIntegratedSec.Checked, txtUserName.Text, txtPassword.Text, (int)numericUpDownCmndTimeOut.Value);

                lastStep = string.Format("Getting database size for: {0}", cboDatabase.Text);
                long size = databaseSizeInfo.GetDatabaseSize(cboDatabase.Text);
                details += string.Format("{0} - {1}MB\r\n", cboDatabase.Text, size);

                databaseSizeInfo.CloseConnection();
                MessageBox.Show("Getting specified database size!\r\n" + details, "Size", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Getting specified database size failed!\r\nLast step: {0}\r\n{1}", lastStep, ex.Message), "Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

    }
}
