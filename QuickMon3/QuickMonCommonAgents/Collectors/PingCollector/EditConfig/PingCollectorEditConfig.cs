using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using QuickMon.Forms;  

namespace QuickMon.Collectors
{
    public partial class PingCollectorEditConfig : SimpleListEditConfig
    {
        public PingCollectorEditConfig()
        {
            InitializeComponent();
        }

        #region Overrides
        public override void LoadList()
        {
            if (SelectedConfig != null)
            {
                PingCollectorConfig pingCollectorConfig = (PingCollectorConfig)SelectedConfig;
                foreach (PingCollectorHostEntry hostEntry in pingCollectorConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(hostEntry.ToString());
                    lvi.SubItems.Add(hostEntry.MaxTimeMS.ToString());
                    lvi.SubItems.Add(hostEntry.TimeOutMS.ToString());
                    lvi.SubItems.Add(hostEntry.DescriptionLocal);
                    lvi.Tag = hostEntry;
                    lvwEntries.Items.Add(lvi);
                }
            }
            base.LoadList();
        }
        public override void AddItem()
        {
            PingCollectorEditHostAddress editHostAddress = new PingCollectorEditHostAddress();
            editHostAddress.HostEntry = new PingCollectorHostEntry();

            if (editHostAddress.ShowHostAddress() == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editHostAddress.HostEntry.ToString());
                lvi.SubItems.Add(editHostAddress.HostEntry.MaxTimeMS.ToString());
                lvi.SubItems.Add(editHostAddress.HostEntry.TimeOutMS.ToString());
                lvi.SubItems.Add(editHostAddress.HostEntry.DescriptionLocal);
                lvi.Tag = editHostAddress.HostEntry;
                lvwEntries.Items.Add(lvi);
            }
            base.AddItem();
        }
        public override void EditItem()
        {

            if (lvwEntries.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvwEntries.SelectedItems[0];
                PingCollectorEditHostAddress editHostAddress = new PingCollectorEditHostAddress();
                editHostAddress.HostEntry = (PingCollectorHostEntry)lvi.Tag;
                if (editHostAddress.ShowHostAddress() == DialogResult.OK)
                {
                    lvi.Text = editHostAddress.HostEntry.ToString();
                    lvi.SubItems[1].Text = editHostAddress.HostEntry.MaxTimeMS.ToString();
                    lvi.SubItems[2].Text = editHostAddress.HostEntry.TimeOutMS.ToString();
                    lvi.SubItems[3].Text = editHostAddress.HostEntry.DescriptionLocal;
                    lvi.Tag = editHostAddress.HostEntry;
                }
            }
            base.EditItem();            
        }
        public override void OKClicked()
        {
            if (CheckOKEnabled())
            {
                if (SelectedConfig == null)
                {
                    SelectedConfig = new PingCollectorConfig();
                }
                PingCollectorConfig pingCollectorConfig = (PingCollectorConfig)SelectedConfig;
                pingCollectorConfig.Entries.Clear();
                foreach (ListViewItem lvi in lvwEntries.Items)
                {
                    PingCollectorHostEntry hostEntry = (PingCollectorHostEntry)lvi.Tag;
                    pingCollectorConfig.Entries.Add(hostEntry);
                }

                DialogResult = DialogResult.OK;
                Close();
            }            
        }
        #endregion
    }
}
