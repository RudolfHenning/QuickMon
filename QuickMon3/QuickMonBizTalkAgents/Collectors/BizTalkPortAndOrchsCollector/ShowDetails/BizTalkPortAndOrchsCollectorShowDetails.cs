using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class BizTalkPortAndOrchsCollectorShowDetails : MiniDetailView, ICollectorDetailView
    {
        public BizTalkPortAndOrchsCollectorShowDetails()
        {
            InitializeComponent();
            ExportButtonVisible = false;
            lvwReceiveLocations.AutoResizeColumnEnabled = true;
            lvwReceiveLocations.AutoResizeColumnIndex = 0;
            lvwSendPorts.AutoResizeColumnEnabled = true;
            lvwSendPorts.AutoResizeColumnIndex = 0;
            lvwOrchestrations.AutoResizeColumnEnabled = true;
            lvwOrchestrations.AutoResizeColumnIndex = 0;
        }

        public override void RefreshDisplayData()
        {            
            try
            {
                if (Collector != null)
                {
                    BizTalkPortAndOrchsCollectorConfigEntry currentConfig = (BizTalkPortAndOrchsCollectorConfigEntry)((ICollectorConfig)Collector.AgentConfig).Entries[0];
                    lvwReceiveLocations.BeginUpdate();
                    lvwReceiveLocations.Items.Clear();

                    foreach (var item in currentConfig.GetReceiveLocationList())
                    {
                        if (currentConfig.AllReceiveLocations || currentConfig.ReceiveLocations.Contains(item.ReceiveLocationName))
                        {
                            ListViewItem lvi = new ListViewItem(item.ReceivePortName);
                            lvi.SubItems.Add(item.ReceiveLocationName);
                            lvi.SubItems.Add(item.Disabled ? "Disabled" : "Enabled");
                            if (item.Disabled)
                                lvi.BackColor = Color.LightCoral;
                            lvi.Tag = item;
                            lvwReceiveLocations.Items.Add(lvi);
                        }
                    }

                    lvwSendPorts.BeginUpdate();
                    lvwSendPorts.Items.Clear();
                    foreach (var item in currentConfig.GetSendPortList())
                    {
                        if (currentConfig.AllSendPorts || currentConfig.SendPorts.Contains(item.Name))
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
                    }

                    lvwOrchestrations.BeginUpdate();
                    lvwOrchestrations.Items.Clear();
                    foreach (var item in currentConfig.GetOrchestrationList())
                    {
                        if (currentConfig.AllOrchestrations || currentConfig.Orchestrations.Contains(item.Name))
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
    }
}
