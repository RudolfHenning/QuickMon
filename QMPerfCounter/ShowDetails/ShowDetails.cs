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
        public PerfCounterConfig PFConfig { get; set; }

        public ShowDetails()
        {
            InitializeComponent();
            PFConfig = new PerfCounterConfig();
        }

        private void lvwPerfCounters_Resize(object sender, EventArgs e)
        {
            lvwPerfCounters.Columns[0].Width = lvwPerfCounters.ClientSize.Width - lvwPerfCounters.Columns[1].Width;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            Cursor.Current = Cursors.WaitCursor;
            lvwPerfCounters.BeginUpdate();
            foreach (ListViewItem lvi in lvwPerfCounters.Items)
            {
                try
                {
                    QMPerfCounterInstance pc = (QMPerfCounterInstance)lvi.Tag;
                    lvi.SubItems[1].Text = pc.GetNextValue().ToString("F3");
                }
                catch (Exception ex)
                {
                    lvi.SubItems[1].Text = ex.Message;
                }
            }
            lvwPerfCounters.EndUpdate();
            Cursor.Current = Cursors.Default;
        }

        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void ShowDetails_Load(object sender, EventArgs e)
        {
            foreach (var pc in PFConfig.QMPerfCounters)
            {
                ListViewItem lvi = new ListViewItem(pc.ToString());
                lvi.SubItems.Add("-");
                lvi.Tag = pc;
                lvwPerfCounters.Items.Add(lvi);
            }
        }
    }
}
