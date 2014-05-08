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
            PFConfig = new PerfCounterConfig();
        }

        public PerfCounterConfig PFConfig { get; set; }

        #region Form events
        private void EditConfig_Load(object sender, EventArgs e)
        {
            RefreshList();
        } 
        #endregion

        #region Toolbar and Button events
        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            EditPerfCounterAlert editPerfCounterAlert = new EditPerfCounterAlert();
            if (editPerfCounterAlert.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PFConfig.QMPerfCounters.Add(editPerfCounterAlert.SelectedPCInstance);
                RefreshList();
            }
        }
        private void addCloneComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwPerfCounters.SelectedItems.Count > 0)
            {
                EditPerfCounterAlert editPerfCounterAlert = new EditPerfCounterAlert();
                editPerfCounterAlert.InitialMachine = ((QMPerfCounterInstance)lvwPerfCounters.SelectedItems[0].Tag).Computer;
                if (editPerfCounterAlert.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    PFConfig.QMPerfCounters.Add(editPerfCounterAlert.SelectedPCInstance);
                    RefreshList();
                }
            }
        }
        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwPerfCounters.SelectedItems.Count > 0)
            {
                EditPerfCounterAlert editPerfCounterAlert = new EditPerfCounterAlert();
                editPerfCounterAlert.SelectedPCInstance = (QMPerfCounterInstance)lvwPerfCounters.SelectedItems[0].Tag;
                if (editPerfCounterAlert.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lvwPerfCounters.SelectedItems[0].Tag = editPerfCounterAlert.SelectedPCInstance;
                    lvwPerfCounters.SelectedItems[0].Text = editPerfCounterAlert.SelectedPCInstance.ToString();
                    lvwPerfCounters.SelectedItems[0].SubItems[1].Text = string.Format("{0:f2}", editPerfCounterAlert.SelectedPCInstance.WarningValue);
                    lvwPerfCounters.SelectedItems[0].SubItems[2].Text = string.Format("{0:f2}", editPerfCounterAlert.SelectedPCInstance.ErrorValue);
                }
            }
        }
        private void removeToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwPerfCounters.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove the selected entry(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwPerfCounters.SelectedItems)
                    {
                        QMPerfCounterInstance removeItem = (QMPerfCounterInstance)lvi.Tag;
                        PFConfig.QMPerfCounters.Remove(removeItem);
                        lvwPerfCounters.Items.Remove(lvi);
                    }
                }
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            PFConfig.QMPerfCounters = new List<QMPerfCounterInstance>();
            foreach (ListViewItem lvi in lvwPerfCounters.Items)
            {
                if (lvi.Tag is QMPerfCounterInstance)
                {
                    PFConfig.QMPerfCounters.Add((QMPerfCounterInstance)lvi.Tag);
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        #endregion

        #region ListView events
        private void lvwPerfCounters_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerCheckButtonEnabled.Enabled = false;
            timerCheckButtonEnabled.Enabled = true;
            addCloneComputerToolStripMenuItem.Enabled = lvwPerfCounters.SelectedItems.Count > 0;
        }
        private void lvwPerfCounters_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                removeToolStripButton_Click(null, null);
            }
        }
        #endregion

        #region Timer events
        private void timerCheckButtonEnabled_Tick(object sender, EventArgs e)
        {
            timerCheckButtonEnabled.Enabled = false;
            CheckButtonEnabled();
        }
        #endregion

        #region Private methods
        private void RefreshList()
        {
            try
            {
                lvwPerfCounters.BeginUpdate();
                string previousSelected = "";
                if (lvwPerfCounters.SelectedItems.Count > 0)
                {
                    previousSelected = ((QMPerfCounterInstance)lvwPerfCounters.SelectedItems[0].Tag).ToString();
                }
                lvwPerfCounters.Items.Clear();
                if (PFConfig != null)
                {
                    foreach (QMPerfCounterInstance qmpc in PFConfig.QMPerfCounters)
                    {
                        ListViewItem lvi = new ListViewItem(qmpc.ToString());
                        if (qmpc.WarningValue < 9999)
                            lvi.SubItems.Add(string.Format("{0:f3}", qmpc.WarningValue));
                        else
                            lvi.SubItems.Add(string.Format("{0:f1}", qmpc.WarningValue));
                        if (qmpc.ErrorValue < 9999)
                            lvi.SubItems.Add(string.Format("{0:f3}", qmpc.ErrorValue));
                        else
                            lvi.SubItems.Add(string.Format("{0:f1}", qmpc.ErrorValue));
                        lvi.Tag = qmpc;
                        lvwPerfCounters.Items.Add(lvi);
                        if (previousSelected == qmpc.ToString())
                        {
                            lvi.Selected = true;
                        }
                    }
                    if (lvwPerfCounters.SelectedItems.Count > 0)
                        lvwPerfCounters.SelectedItems[0].EnsureVisible();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvwPerfCounters.EndUpdate();
            }
        }
        private void CheckButtonEnabled()
        {
            editToolStripButton.Enabled = lvwPerfCounters.SelectedItems.Count > 0;
            editToolStripMenuItem.Enabled = lvwPerfCounters.SelectedItems.Count > 0;
            removeToolStripButton.Enabled = lvwPerfCounters.SelectedItems.Count > 0;
            removeToolStripMenuItem.Enabled = lvwPerfCounters.SelectedItems.Count > 0;
        } 
        #endregion



    }
}
