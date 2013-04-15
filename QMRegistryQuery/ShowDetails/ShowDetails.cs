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
        public RegistryQueryConfig SelectedRegistryQueryConfig { get; set; }

        public ShowDetails()
        {
            InitializeComponent();
        }

        #region Form events
        private void ShowDetails_Load(object sender, EventArgs e)
        {
            
        }
        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            LoadList();
            columnResizeTimer.Enabled = true;
        }
        #endregion

        #region Timer events
        private void columnResizeTimer_Tick(object sender, EventArgs e)
        {
            columnResizeTimer.Enabled = false;
            lvwDetails.Columns[1].Width = lvwDetails.ClientSize.Width - lvwDetails.Columns[0].Width - lvwDetails.Columns[2].Width;
        } 
        #endregion

        #region ListView events
        private void lvwDetails_Resize(object sender, EventArgs e)
        {
            columnResizeTimer.Enabled = true;
        } 
        #endregion

        #region Private methods
        private void LoadList()
        {
            if (SelectedRegistryQueryConfig != null)
            {
                lvwDetails.Items.Clear();
                foreach (RegistryQueryInstance rq in SelectedRegistryQueryConfig.Queries)
                {
                    ListViewItem lvi = new ListViewItem(rq.Name);
                    lvi.SubItems.Add((rq.UseRemoteServer ? "[" + rq.Server + "]\\" : "") + rq.Path + "\\@[" + rq.KeyName + "]");
                    lvi.SubItems.Add("-");
                    lvi.Tag = rq;
                    lvwDetails.Items.Add(lvi);
                }
            }
            RefreshList();
        }
        private void RefreshList()
        {
            if (SelectedRegistryQueryConfig != null)
            {
                foreach (ListViewItem lvi in lvwDetails.Items)
                {
                    if (lvi.Tag is RegistryQueryInstance)
                    {
                        RegistryQueryInstance rq = (RegistryQueryInstance)lvi.Tag;
                        try
                        {
                            object value = rq.GetValue();
                            if (value == null)
                                lvi.SubItems[2].Text = "Null";
                            else
                                lvi.SubItems[2].Text = value.ToString();
                        }
                        catch (Exception ex)
                        {
                            lvi.SubItems[2].Text = ex.Message;
                        }
                    }
                }
            }
        } 
        #endregion

        #region Toolbar and menu events
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList();
        } 
        #endregion
    }
}
