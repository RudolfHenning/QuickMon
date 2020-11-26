using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HenIT.Forms;

namespace QuickMon
{
    public partial class ManageCategories : Form
    {
        public ManageCategories()
        {
            InitializeComponent();
        }

        public MonitorPack HostedMonitorPack { get; set; } = null;
        public List<string> SelectedCategories { get; set; } = new List<string>();
        public bool SelectionMode { get; set; } = false;

        private void ManageCategories_Load(object sender, EventArgs e)
        {
            if (SelectionMode)
            {
                cmdOKSelect.Visible = true;
                cmdClose.Visible = true;
            }
            else
            {
                cmdOKSelect.Visible = false;
                cmdClose.Visible = false;
            }
        }
        private void ManageCategories_Shown(object sender, EventArgs e)
        {
            RefreshCategories();
        }

        private void RefreshCategories()
        {
            if (HostedMonitorPack != null)
            {
                List<string> existingCategories = new List<string>();
                List<ListViewItem> list = new List<ListViewItem>();
                foreach (CollectorHost ch in HostedMonitorPack.CollectorHosts)
                {
                    foreach (string cat in ch.Categories)
                    {
                        if ((from string c in existingCategories
                             where c.ToLower() == cat.ToLower()
                             select c).FirstOrDefault() == null)
                        {
                            existingCategories.Add(cat);
                            ListViewItem itmX = new ListViewItem(cat);
                            itmX.SubItems.Add("1");
                            list.Add(itmX);
                        }
                        else
                        {
                            ListViewItem itmX = (from ListViewItem itm in list
                                                 where itm.Text.ToLower() == cat.ToLower()
                                                 select itm).FirstOrDefault();
                            if (itmX != null)
                            {
                                int cnt = int.Parse(itmX.SubItems[1].Text);
                                itmX.SubItems[1].Text = (cnt + 1).ToString();
                            }
                        }
                    }
                }
                lvwCategories.Items.Clear();
                lvwCategories.Items.AddRange((from l in list
                                              orderby l.Text.ToLower()
                                              select l).ToArray());
            }
        }

        private void lvwCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOKSelect.Enabled = lvwCategories.SelectedItems.Count > 0;
        }

        private void cmdOKSelect_Click(object sender, EventArgs e)
        {
            SelectedCategories = new List<string>();
            foreach(ListViewItem lvi in lvwCategories.SelectedItems)
            {
                SelectedCategories.Add(lvi.Text);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            string newTag = InputBox.Show("Specify new category", "New category", "", false);
            if (newTag != "")
            {
                ListViewItem itmX = (from ListViewItem itm in lvwCategories.Items
                                     where itm.Text.ToLower() == newTag.ToLower()
                                     select itm).FirstOrDefault();
                if (itmX == null)
                {
                    itmX = new ListViewItem(newTag);
                    itmX.SubItems.Add("0");
                    lvwCategories.Items.Add(itmX);
                }
            }
        }
    }
}
