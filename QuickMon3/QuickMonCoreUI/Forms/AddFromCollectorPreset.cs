using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public partial class AddFromCollectorPreset : Form
    {
        public AddFromCollectorPreset()
        {
            InitializeComponent();
        }

        public List<AgentPresetConfig> AvailablePresets { get; set; }
        public AgentPresetConfig SelectedPreset { get; set; }

        private void AddFromCollectorPreset_Load(object sender, EventArgs e)
        {
            lvwPresets.AutoResizeColumnIndex = 1;
            lvwPresets.AutoResizeColumnEnabled = true;

            if (AvailablePresets != null)
            {
                foreach(AgentPresetConfig preset in (from p in AvailablePresets
                                                                                 orderby p.AgentDefaultName
                                                                                 select p))
                {
                    ListViewItem lvi = new ListViewItem(preset.Description);
                    lvi.SubItems.Add(preset.Config);
                    lvi.Tag = preset;
                    lvwPresets.Items.Add(lvi);
                }
            }
        }

        private void lvwPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwPresets.SelectedItems.Count > 0;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwPresets.SelectedItems.Count > 0)
            {
                SelectedPreset = (AgentPresetConfig)lvwPresets.SelectedItems[0].Tag;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
