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
    public partial class RegistryQueryCollectorEditConfig : SimpleListEditConfig
    {
        public RegistryQueryCollectorEditConfig()
        {
            InitializeComponent();
        }

        #region Overrides
        public override void LoadList()
        {
            if (SelectedConfig != null)
            {
                RegistryQueryCollectorConfig currentConfig = (RegistryQueryCollectorConfig)SelectedConfig;
                lvwEntries.Items.Clear();
                foreach (RegistryQueryInstance entry in currentConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(entry.Name);
                    lvi.SubItems.Add(entry.ToString()); //(entry.UseRemoteServer ? entry.Server + "\\" : "") + RegistryQueryInstance.GetRegistryHiveFromString(entry.RegistryHive.ToString()).ToString() + "\\" + entry.Path);
                    lvi.SubItems.Add(entry.KeyName);
                    lvi.SubItems.Add(entry.SuccessValue);
                    lvi.SubItems.Add(entry.WarningValue);
                    lvi.SubItems.Add(entry.ErrorValue);
                    lvi.Tag = entry;
                    lvwEntries.Items.Add(lvi);
                }
            }
            base.LoadList();
        }
        public override void AddItem()
        {
            RegistryQueryCollectorEditInstance editQueryInstance = new RegistryQueryCollectorEditInstance();
            if (editQueryInstance.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editQueryInstance.SelectedRegistryQueryInstance.Name);
                lvi.SubItems.Add(editQueryInstance.SelectedRegistryQueryInstance.ToString());// ? editQueryInstance.SelectedRegistryQueryInstance.Server + "\\" : "") + RegistryQueryInstance.GetRegistryHiveFromString(editQueryInstance.SelectedRegistryQueryInstance.RegistryHive.ToString()).ToString() + "\\" + editQueryInstance.SelectedRegistryQueryInstance.Path);
                lvi.SubItems.Add(editQueryInstance.SelectedRegistryQueryInstance.KeyName);
                lvi.SubItems.Add(editQueryInstance.SelectedRegistryQueryInstance.SuccessValue);
                lvi.SubItems.Add(editQueryInstance.SelectedRegistryQueryInstance.WarningValue);
                lvi.SubItems.Add(editQueryInstance.SelectedRegistryQueryInstance.ErrorValue);
                lvi.Tag = editQueryInstance.SelectedRegistryQueryInstance;
                lvwEntries.Items.Add(lvi);
            }
        }
        public override void EditItem()
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvwEntries.SelectedItems[0];
                RegistryQueryCollectorEditInstance editQueryInstance = new RegistryQueryCollectorEditInstance();
                editQueryInstance.SelectedRegistryQueryInstance = (RegistryQueryInstance)lvi.Tag;
                if (editQueryInstance.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lvi.Text = editQueryInstance.SelectedRegistryQueryInstance.Name;
                    lvi.SubItems[1].Text = (editQueryInstance.SelectedRegistryQueryInstance.UseRemoteServer ? editQueryInstance.SelectedRegistryQueryInstance.Server + "\\" : "") + RegistryQueryInstance.GetRegistryHiveFromString(editQueryInstance.SelectedRegistryQueryInstance.RegistryHive.ToString()).ToString() + "\\" + editQueryInstance.SelectedRegistryQueryInstance.Path;
                    lvi.SubItems[2].Text = editQueryInstance.SelectedRegistryQueryInstance.KeyName;
                    lvi.SubItems[3].Text = editQueryInstance.SelectedRegistryQueryInstance.SuccessValue;
                    lvi.SubItems[4].Text = editQueryInstance.SelectedRegistryQueryInstance.WarningValue;
                    lvi.SubItems[5].Text = editQueryInstance.SelectedRegistryQueryInstance.ErrorValue;
                    lvi.Tag = editQueryInstance.SelectedRegistryQueryInstance;
                    CheckOKEnabled();
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
                    SelectedConfig = new RegistryQueryCollectorConfig();
                RegistryQueryCollectorConfig currentConfig = (RegistryQueryCollectorConfig)SelectedConfig;
                currentConfig.Entries.Clear();

                foreach (ListViewItem lvi in lvwEntries.Items)
                {
                    RegistryQueryInstance registryQueryInstance = (RegistryQueryInstance)lvi.Tag;
                    currentConfig.Entries.Add(registryQueryInstance);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion
    }
}
