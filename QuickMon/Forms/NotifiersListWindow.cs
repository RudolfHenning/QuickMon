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
    public partial class NotifiersListWindow : Form
    {
        public NotifiersListWindow()
        {
            InitializeComponent();
        }

        public MonitorPack SelectedMonitorPack { get; set; }

        private void NotifiersListWindow_Shown(object sender, EventArgs e)
        {
            if (SelectedMonitorPack != null)
            {
                LoadNotifiers();
            }
        }

        private void LoadNotifiers()
        {
            foreach (NotifierEntry ne in SelectedMonitorPack.Notifiers)
            {
                ListViewItem lvi = new ListViewItem(ne.Name);
                lvi.Tag = ne;
                lvwNotifiers.Items.Add(lvi);
            }
        }

        private void lvwNotifiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            openViewerToolStripMenuItem.Enabled = lvwNotifiers.SelectedItems.Count == 1 && 
                    lvwNotifiers.SelectedItems[0].Tag is NotifierEntry &&
                    ((NotifierEntry)lvwNotifiers.SelectedItems[0].Tag).Notifier.HasViewer;
        }

        private void openViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwNotifiers.SelectedItems.Count == 1 &&
                    lvwNotifiers.SelectedItems[0].Tag is NotifierEntry &&
                    ((NotifierEntry)lvwNotifiers.SelectedItems[0].Tag).Notifier.HasViewer)
                {
                    NotifierEntry ne = (NotifierEntry)lvwNotifiers.SelectedItems[0].Tag;
                    ne.OpenViewer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
