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
    public partial class ShowDetails : Form
    {
        public ShowDetails()
        {
            InitializeComponent();
        }

        public string SqlServer { get; set; }
        public bool IntegratedSec { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CmndTimeOut { get; set; }
        public List<DatabaseEntry> Databases { get; set; }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDatabaseList();
        }

        private void LoadDatabases()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lvwDatabases.BeginUpdate();
                lvwDatabases.Items.Clear();
                foreach (DatabaseEntry dbe in Databases)
                {
                    ListViewItem lvi = new ListViewItem(dbe.Name);
                    lvi.SubItems.Add("-");
                    lvi.Tag = dbe;
                    lvwDatabases.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvwDatabases.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
        }

        private void RefreshDatabaseList()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DatabaseSizeInfo databaseSizeInfo = new DatabaseSizeInfo();
                databaseSizeInfo.OpenConnection(SqlServer, IntegratedSec, UserName, Password, CmndTimeOut);
                foreach (ListViewItem lvi in lvwDatabases.Items)
                {
                    DatabaseEntry dbe = (DatabaseEntry)lvi.Tag;
                    try
                    {
                        long size = databaseSizeInfo.GetDatabaseSize(dbe.Name);
                        lvi.SubItems[1].Text = size.ToString();
                        if (size >= dbe.ErrorSizeMB)
                            lvi.ImageIndex = 2;
                        else if (size >= dbe.WarningSizeMB)
                            lvi.ImageIndex = 1;
                        else
                            lvi.ImageIndex = 0;
                    }
                    catch (Exception innerEx)
                    {
                        lvi.SubItems[1].Text = innerEx.Message;
                    }
                }
                databaseSizeInfo.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            
        }

        private void ShowDetails_Load(object sender, EventArgs e)
        {
            LoadDatabases();
        }

        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            RefreshDatabaseList();
        }
    }
}
