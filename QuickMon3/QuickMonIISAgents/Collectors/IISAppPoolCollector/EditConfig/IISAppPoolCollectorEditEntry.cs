using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Collectors
{
    public partial class IISAppPoolCollectorEditEntry : Form, IEditConfigEntryWindow
    {
        public IISAppPoolCollectorEditEntry()
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

        private void IISAppPoolCollectorEditEntry_Load(object sender, EventArgs e)
        {
            if (SelectedEntry != null )
            {
                IISAppPoolMachine selectedEntry = (IISAppPoolMachine)SelectedEntry;
                txtComputer.Text = selectedEntry.MachineName;
                chkUsePerfCounters.Checked = selectedEntry.UsePerfCounter;
                foreach(var appPoolEntry in selectedEntry.SubItems)
                {
                    lstAppPools.Items.Add(appPoolEntry.Description);
                }
                ImportCheckTimer.Enabled = false;
                ImportCheckTimer.Enabled = true;
            }
        }

        private void cmdAddAppPool_Click(object sender, EventArgs e)
        {
            if (txtAddAppPool.Text.Trim().Length > 0)
            {
                lstAppPools.Items.Add(txtAddAppPool.Text);
                CheckOkEnabled();
            }
        }

        private void txtComputer_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void txtComputer_Leave(object sender, EventArgs e)
        {
            ImportCheckTimer.Enabled = false;
            ImportCheckTimer.Enabled = true;
        }
        private void lstAppPools_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                removeToolStripMenuItem_Click(null, null);
            }
        }

        private void CheckOkEnabled()
        {
            cmdOK.Enabled = txtComputer.Text.Trim().Length > 0 && lstAppPools.Items.Count > 0;            
        }

        private void ImportCheckTimer_Tick(object sender, EventArgs e)
        {
            ImportCheckTimer.Enabled = false;
            cmdImportSM.Invoke((MethodInvoker)delegate
            {
                try
                {
                    cmdImportSM.Enabled = txtComputer.Text.Trim().Length > 0 && System.Net.Dns.GetHostAddresses(txtComputer.Text).Count() > 0;
                }
                catch
                {
                    cmdImportSM.Enabled = false;
                }
            });
        }

        private void lstAppPools_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (int index in (from int i in lstAppPools.SelectedIndices
                                   orderby i descending
                                   select i))
            {
                lstAppPools.Items.RemoveAt(index);
            }
            CheckOkEnabled();
        }

        private void chkUsePerfCounters_CheckedChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (SelectedEntry == null)
            {
                SelectedEntry = new IISAppPoolMachine();
            }
            IISAppPoolMachine selectedEntry = (IISAppPoolMachine)SelectedEntry;
            selectedEntry.MachineName = txtComputer.Text;
            selectedEntry.UsePerfCounter = chkUsePerfCounters.Checked;
            selectedEntry.SubItems = new List<ICollectorConfigSubEntry>();
            foreach(string appPoolName in lstAppPools.Items)
            {
                selectedEntry.SubItems.Add(new IISAppPoolEntry() { Description = appPoolName });
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void cmdImportSM_Click(object sender, EventArgs e)
        {
            DialogResult choice = System.Windows.Forms.DialogResult.No;
            if (lstAppPools.Items.Count > 0)
                choice = MessageBox.Show("Do you want to clear any existing entries?", "Import", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (System.Net.Dns.GetHostAddresses(txtComputer.Text).Count() > 0)
                {
                    IISAppPoolMachine tmpIISAppPoolMachine = new IISAppPoolMachine();
                    tmpIISAppPoolMachine.MachineName = txtComputer.Text;
                    tmpIISAppPoolMachine.UsePerfCounter = chkUsePerfCounters.Checked;
                    List<IISAppPoolStateInfo> appPools = tmpIISAppPoolMachine.GetSourceIISAppPoolStates();

                    if (choice == System.Windows.Forms.DialogResult.Yes)
                        lstAppPools.Items.Clear();

                    foreach (var appPool in appPools)
                    {
                        if (!lstAppPools.Items.Contains(appPool.DisplayName))
                            lstAppPools.Items.Add(appPool.DisplayName);
                    }
                }
                CheckOkEnabled();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }






    }
}
