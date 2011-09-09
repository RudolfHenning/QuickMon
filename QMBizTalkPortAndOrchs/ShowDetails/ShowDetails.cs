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

        public BizTalkGroup BizTalkGroup { get; set; }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadLists();
        }

        private void LoadLists()
        {
            try
            {
                if (BizTalkGroup != null)
                {
                    lvwReceiveLocations.BeginUpdate();
                    lvwReceiveLocations.Items.Clear();

                    foreach (var item in BizTalkGroup.GetReceiveLocationList())
                    {
                        ListViewItem lvi = new ListViewItem(item.ReceivePortName);
                        lvi.SubItems.Add(item.ReceiveLocationName);
                        lvi.SubItems.Add(item.Disabled ? "Disabled" : "Enabled");
                        if (item.Disabled)
                            lvi.BackColor = Color.LightCoral;
                        lvi.Tag = item;
                        lvwReceiveLocations.Items.Add(lvi);
                    }

                    lvwSendPorts.BeginUpdate();
                    lvwSendPorts.Items.Clear();
                    foreach (var item in BizTalkGroup.GetSendPortList())
                    {
                        ListViewItem lvi = new ListViewItem(item.Name);
                        lvi.SubItems.Add(item.State);
                        if (item.State == "Stopped")
                            lvi.BackColor = Color.LightCoral;
                        else if (item.State == "Unenlisted")
                            lvi.BackColor = Color.Yellow;
                        lvi.Tag = item;
                        lvwSendPorts.Items.Add(lvi);
                    }


                    lvwOrchestrations.BeginUpdate();
                    lvwOrchestrations.Items.Clear();
                    foreach (var item in BizTalkGroup.GetOrchestrationList())
                    {
                        ListViewItem lvi = new ListViewItem(item.Name);
                        lvi.SubItems.Add(item.State);
                        if (item.State == "Stopped")
                            lvi.BackColor = Color.LightCoral;
                        else if (item.State == "Unenlisted")
                            lvi.BackColor = Color.Yellow;
                        lvi.Tag = item;
                        lvwOrchestrations.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvwReceiveLocations.EndUpdate();
                lvwSendPorts.EndUpdate();
                lvwOrchestrations.EndUpdate();
            }
        }

        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            LoadLists();
        }
    }
}
