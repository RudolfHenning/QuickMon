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
    public partial class WMIQueryCollectorEditConfig : SimpleListEditConfig
    {
        public WMIQueryCollectorEditConfig()
        {
            InitializeComponent();
        }

        #region Overrides
        public override void LoadList()
        {
            if (SelectedConfig != null)
            {
                WMIQueryCollectorConfig currentConfig = (WMIQueryCollectorConfig)SelectedConfig;
                lvwEntries.Items.Clear();
                foreach (WMIQueryEntry wmiConfigEntry in currentConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(wmiConfigEntry.Name);
                    lvi.SubItems.Add(wmiConfigEntry.Machinename);
                    lvi.SubItems.Add(wmiConfigEntry.Namespace);
                    lvi.SubItems.Add(wmiConfigEntry.StateQuery);
                    lvi.Tag = wmiConfigEntry;
                    lvwEntries.Items.Add(lvi);
                }
                CheckOKEnabled();
            }
            base.LoadList();
        }
        public override void DoResize()
        {
            
        }
        public override void AddItem()
        {
            WMIQueryCollectorEditEntry editConfigEntry = new WMIQueryCollectorEditEntry();
            editConfigEntry.SelectedWMIQueryEntry = new WMIQueryEntry();
            if (editConfigEntry.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editConfigEntry.SelectedWMIQueryEntry.Name);
                lvi.SubItems.Add(editConfigEntry.SelectedWMIQueryEntry.Machinename);
                lvi.SubItems.Add(editConfigEntry.SelectedWMIQueryEntry.Namespace);
                lvi.SubItems.Add(editConfigEntry.SelectedWMIQueryEntry.DetailQuery);
                lvi.Tag = editConfigEntry.SelectedWMIQueryEntry;
                lvwEntries.Items.Add(lvi);
            }
        }
        public override void EditItem()
        {
            if (lvwEntries.SelectedItems.Count > 0 && lvwEntries.SelectedItems[0].Tag is WMIQueryEntry)
            {
                WMIQueryCollectorEditEntry editConfigEntry = new WMIQueryCollectorEditEntry();
                editConfigEntry.SelectedWMIQueryEntry = (WMIQueryEntry)lvwEntries.SelectedItems[0].Tag;
                if (editConfigEntry.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    ListViewItem lvi = lvwEntries.SelectedItems[0];
                    lvi.Text = editConfigEntry.SelectedWMIQueryEntry.Name;
                    lvi.SubItems[1].Text = editConfigEntry.SelectedWMIQueryEntry.Machinename;
                    lvi.SubItems[2].Text = editConfigEntry.SelectedWMIQueryEntry.Namespace;
                    lvi.SubItems[3].Text = editConfigEntry.SelectedWMIQueryEntry.DetailQuery;
                    lvi.Tag = editConfigEntry.SelectedWMIQueryEntry;
                }
            }
        }
        public override void DeleteItems()
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove the selected entries?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwEntries.SelectedItems)
                    {
                        lvwEntries.Items.Remove(lvi);
                    }
                    CheckOKEnabled();
                }
            }
        }
        public override void OKClicked()
        {
            if (CheckOKEnabled())
            {
                if (SelectedConfig == null)
                    SelectedConfig = new WMIQueryCollectorConfig();
                WMIQueryCollectorConfig currentConfig = (WMIQueryCollectorConfig)SelectedConfig;
                currentConfig.Entries.Clear();

                foreach (ListViewItem lvi in lvwEntries.Items)
                {
                    WMIQueryEntry eventLogEntry = (WMIQueryEntry)lvi.Tag;
                    currentConfig.Entries.Add(eventLogEntry);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion
    }
}
