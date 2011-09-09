using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace QuickMon
{
    public partial class ShowDetails : Form
    {
        //public string CustomConfig { get; set; }
        public List<HostEntry> HostEntries { get; set; }

        public ShowDetails()
        {
            InitializeComponent();
        }

        #region Show detail
        public void ShowDetail()
        {
            //if (CustomConfig.Length > 0)
            //{
            //    try
            //    {
            //        XmlDocument config = new XmlDocument();
            //        config.LoadXml(CustomConfig);

            //        XmlNodeList hostListNodes = config.GetElementsByTagName("host");
            //        foreach (XmlNode hostXmlNode in hostListNodes)
            //        {
            //            HostEntry hostEntry = new HostEntry();
            //            hostEntry.HostName = hostXmlNode.Attributes.GetNamedItem("hostName").Value;
            //            hostEntry.Description = hostXmlNode.Attributes.GetNamedItem("description").Value;
            //            hostEntry.MaxTime = int.Parse(hostXmlNode.Attributes.GetNamedItem("maxTime").Value);
            //            hostEntry.TimeOut = int.Parse(hostXmlNode.Attributes.GetNamedItem("timeOut").Value);

            //            ListViewItem lvi = new ListViewItem(hostEntry.HostName);
            //            lvi.SubItems.Add("-");
            //            lvi.Tag = hostEntry;
            //            lvwHosts.Items.Add(lvi);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            base.Show();
            LoadList();
            RefreshList();
        }

        
        #endregion

        #region ListView events
        private void ShowDetails_Resize(object sender, EventArgs e)
        {
            lvwHosts.Columns[0].Width = lvwHosts.Width - 25 - lvwHosts.Columns[1].Width;
        }
        #endregion

        #region Context menu events
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region Toolbar events
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region Local methods
        private void LoadList()
        {
            if (HostEntries != null)
            {
                foreach (var hostEntry in HostEntries)
                {
                    ListViewItem lvi = new ListViewItem(hostEntry.HostName);
                    lvi.SubItems.Add("-");
                    lvi.Tag = hostEntry;
                    lvwHosts.Items.Add(lvi);
                }
            }
        } 
        private void RefreshList()
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            lvwHosts.BeginUpdate();
            foreach (ListViewItem itmX in lvwHosts.Items)
            {
                HostEntry host = (HostEntry)itmX.Tag;
                try
                {
                    int pingTime = 0;
                    using (System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping())
                    {
                        System.Net.NetworkInformation.PingReply reply = ping.Send(host.HostName, host.TimeOut);
                        if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                            pingTime = Convert.ToInt32(reply.RoundtripTime);
                        else // if (reply.Status == System.Net.NetworkInformation.IPStatus.TimedOut)
                            pingTime = int.MaxValue;

                    }
                    itmX.SubItems[1].Text = pingTime.ToString();
                    if (pingTime > host.TimeOut)
                    {
                        itmX.ForeColor = Color.Red;
                        itmX.SubItems[1].Text = "Time-out";
                    }
                    else if (pingTime > host.MaxTime)
                    {
                        itmX.SubItems[1].ForeColor = Color.DarkOrange;
                    }
                    else
                    {
                        itmX.SubItems[1].ForeColor = SystemColors.WindowText;
                    }

                }
                catch (Exception ex)
                {
                    itmX.SubItems[1].Text = ex.Message;
                }
            }
            lvwHosts.EndUpdate();
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            toolStripStatusLabel1.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        #endregion
        
    }
}
