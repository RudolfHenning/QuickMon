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
    public partial class SoapWebServicePingCollectorEditConfig : SimpleListEditConfig // Form, IEditConfigWindow
    {
        public SoapWebServicePingCollectorEditConfig()
        {
            InitializeComponent();
        }

        #region Overrides
        public override void LoadList()
        {
            if (SelectedConfig != null)
            {
                lvwEntries.BeginUpdate();
                lvwEntries.Items.Clear();
                try
                {
                    SoapWebServicePingCollectorConfig currentConfig = (SoapWebServicePingCollectorConfig)SelectedConfig;
                    foreach (SoapWebServicePingConfigEntry entry in currentConfig.Entries)
                    {
                        ListViewItem lvi = new ListViewItem(entry.ServiceBaseURL);
                        lvi.SubItems.Add(entry.ServiceName);
                        lvi.SubItems.Add(entry.MethodName);
                        lvi.SubItems.Add(entry.ToStringFromParameters());
                        lvi.Tag = entry;
                        lvwEntries.Items.Add(lvi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    lvwEntries.EndUpdate();
                }
            }
            base.LoadList();
        }
        public override void AddItem()
        {
            SoapWebServicePingCollectorEditEntry SoapWebServicePingEditEntry = new SoapWebServicePingCollectorEditEntry();
            if (SoapWebServicePingEditEntry.ShowDialog() == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(SoapWebServicePingEditEntry.SelectedConfig.ServiceBaseURL);
                lvi.SubItems.Add(SoapWebServicePingEditEntry.SelectedConfig.ServiceName);
                lvi.SubItems.Add(SoapWebServicePingEditEntry.SelectedConfig.MethodName);
                lvi.SubItems.Add(SoapWebServicePingEditEntry.SelectedConfig.ToStringFromParameters());
                lvi.Tag = SoapWebServicePingEditEntry.SelectedConfig;
                lvwEntries.Items.Add(lvi);
            }
            base.AddItem();
        }
        public override void EditItem()
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                SoapWebServicePingCollectorEditEntry SoapWebServicePingEditEntry = new SoapWebServicePingCollectorEditEntry();
                SoapWebServicePingEditEntry.SelectedConfig = (SoapWebServicePingConfigEntry)lvwEntries.SelectedItems[0].Tag;
                if (SoapWebServicePingEditEntry.ShowDialog() == DialogResult.OK)
                {
                    lvwEntries.SelectedItems[0].Text = SoapWebServicePingEditEntry.SelectedConfig.ServiceBaseURL;
                    lvwEntries.SelectedItems[0].SubItems[1].Text = SoapWebServicePingEditEntry.SelectedConfig.ServiceName;
                    lvwEntries.SelectedItems[0].SubItems[2].Text = SoapWebServicePingEditEntry.SelectedConfig.MethodName;
                    lvwEntries.SelectedItems[0].SubItems[3].Text = SoapWebServicePingEditEntry.SelectedConfig.ToStringFromParameters();
                    lvwEntries.SelectedItems[0].Tag = SoapWebServicePingEditEntry.SelectedConfig;
                }
            }
            base.EditItem();
        }
        public override void OKClicked()
        {
            if (CheckOKEnabled())
            {
                if (SelectedConfig == null)
                    SelectedConfig = new SoapWebServicePingCollectorConfig();

                ((SoapWebServicePingCollectorConfig)SelectedConfig).Entries.Clear();
                foreach (ListViewItem lvi in lvwEntries.Items)
                {
                    SoapWebServicePingConfigEntry soapWebServicePingConfigEntry = (SoapWebServicePingConfigEntry)lvi.Tag;
                    ((SoapWebServicePingCollectorConfig)SelectedConfig).Entries.Add(soapWebServicePingConfigEntry);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion
    }
}
