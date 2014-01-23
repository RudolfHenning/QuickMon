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
    public partial class EventLogCollectorEditConfig : SimpleListEditConfig
    {
        public EventLogCollectorEditConfig()
        {
            InitializeComponent();
        }

        #region Overrides
        public override void LoadList()
        {
            if (SelectedConfig != null)
            {
                EventLogCollectorConfig currentConfig = (EventLogCollectorConfig)SelectedConfig;
                lvwEntries.Items.Clear();
                foreach (EventLogCollectorEntry entry in currentConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(entry.ComputerLogName);
                    lvi.SubItems.Add(entry.FilterSummary);
                    lvi.SubItems.Add(entry.WarningValue.ToString());
                    lvi.SubItems.Add(entry.ErrorValue.ToString());
                    lvi.Tag = entry;
                    lvwEntries.Items.Add(lvi);
                }
            }            
            base.LoadList();
        }
        public override void DoResize()
        {
            lvwEntries.Columns[0].Width = lvwEntries.ClientSize.Width - lvwEntries.Columns[1].Width - lvwEntries.Columns[2].Width - lvwEntries.Columns[3].Width;
        }
        public override void AddItem()
        {
            EventLogCollectorEditEntry editEventLogEntry = new EventLogCollectorEditEntry();
            if (editEventLogEntry.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editEventLogEntry.SelectedEventLogEntry.ComputerLogName);
                lvi.SubItems.Add(editEventLogEntry.SelectedEventLogEntry.FilterSummary);
                lvi.SubItems.Add(editEventLogEntry.SelectedEventLogEntry.WarningValue.ToString());
                lvi.SubItems.Add(editEventLogEntry.SelectedEventLogEntry.ErrorValue.ToString());
                lvi.Tag = editEventLogEntry.SelectedEventLogEntry;
                lvwEntries.Items.Add(lvi);
            }
        }
        public override void EditItem()
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                EventLogCollectorEditEntry editEventLogEntry = new EventLogCollectorEditEntry();
                editEventLogEntry.SelectedEventLogEntry = (EventLogCollectorEntry)lvwEntries.SelectedItems[0].Tag;
                if (editEventLogEntry.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lvwEntries.SelectedItems[0].Text = editEventLogEntry.SelectedEventLogEntry.ComputerLogName;
                    lvwEntries.SelectedItems[0].SubItems[1].Text = editEventLogEntry.SelectedEventLogEntry.FilterSummary;
                    lvwEntries.SelectedItems[0].SubItems[2].Text = editEventLogEntry.SelectedEventLogEntry.WarningValue.ToString();
                    lvwEntries.SelectedItems[0].SubItems[3].Text = editEventLogEntry.SelectedEventLogEntry.ErrorValue.ToString();
                    lvwEntries.SelectedItems[0].Tag = editEventLogEntry.SelectedEventLogEntry;
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
                    SelectedConfig = new EventLogCollectorConfig();
                EventLogCollectorConfig currentConfig = (EventLogCollectorConfig)SelectedConfig;
                currentConfig.Entries.Clear();

                foreach (ListViewItem lvi in lvwEntries.Items)
                {
                    EventLogCollectorEntry eventLogEntry = (EventLogCollectorEntry)lvi.Tag;
                    currentConfig.Entries.Add(eventLogEntry);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        } 
        #endregion
    }
}
