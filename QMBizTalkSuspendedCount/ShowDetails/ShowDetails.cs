using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Specialized;

namespace QuickMon
{
    public partial class ShowDetails : Form
    {
        //public string CustomConfig { get; set; }
        //private BizTalkGroup bizTalkGroup = new BizTalkGroup();
        public BizTalkGroup BizTalkGroup { get; set; }

        public ShowDetails()
        {
            InitializeComponent();
        }

        #region Show detail
        public void ShowDetail()
        {
            //ReadConfiguration();
            base.Show();
            RefreshList();
        }
        #endregion

        //private void ReadConfiguration()
        //{
        //    XmlDocument config = new XmlDocument();
        //    config.LoadXml(CustomConfig);
        //    XmlNode root = config.DocumentElement.SelectSingleNode("bizTalkGroup");
        //    bizTalkGroup.SqlServer = root.ReadXmlElementAttr("sqlServer", ".");
        //    bizTalkGroup.MgmtDBName = root.ReadXmlElementAttr("mgmtDb", "BizTalkMgmtDb");
        //    bizTalkGroup.InstancesWarning = int.Parse(root.ReadXmlElementAttr("instancesWarning", "1"));
        //    bizTalkGroup.InstancesError = int.Parse(root.ReadXmlElementAttr("instancesError", "1"));
        //    bizTalkGroup.ShowLastXDetails = int.Parse(root.ReadXmlElementAttr("showLastXDetails", "0"));

        //    foreach (XmlElement host in root.SelectNodes("hosts/host"))
        //    {
        //        string hostName = host.ReadXmlElementAttr("name");
        //        if (hostName.Length > 0)
        //            bizTalkGroup.Hosts.Add(hostName);
        //    }
        //    foreach (XmlElement app in root.SelectNodes("apps/app"))
        //    {
        //        string appName = app.ReadXmlElementAttr("name");
        //        if (appName.Length > 0)
        //            bizTalkGroup.Apps.Add(app.Attributes.GetNamedItem("name").Value);
        //    }
        //}

        private void RefreshList()
        {
            if (BizTalkGroup != null)
            {
                lvwSuspMsgs.Items.Clear();
                foreach (SuspendedInstance suspendedInstance in (from s in BizTalkGroup.GetAllSuspendedInstances()
                                                                     orderby s.SuspendTime descending 
                                                                     select s))
                {
                    ListViewItem lvi = new ListViewItem(suspendedInstance.Host);
                    lvi.SubItems.Add(suspendedInstance.Application);
                    lvi.SubItems.Add(suspendedInstance.MessageType);
                    lvi.SubItems.Add(suspendedInstance.PublishingServer);
                    lvi.SubItems.Add(suspendedInstance.SuspendTime.ToString());
                    lvi.SubItems.Add(suspendedInstance.Uri);
                    lvi.SubItems.Add(suspendedInstance.Adapter);
                    lvi.SubItems.Add(suspendedInstance.AdditionalInfo);
                    lvi.Tag = suspendedInstance;

                    lvwSuspMsgs.Items.Add(lvi);
                }
                toolStripStatusLabel1.Text = lvwSuspMsgs.Items.Count.ToString() + " item(s) found";
            }           
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void lvwSuspMsgs_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerShowDetail.Enabled = true;
        }

        private void timerShowDetail_Tick(object sender, EventArgs e)
        {
            timerShowDetail.Enabled = false;
            txtDetails.Text = "";

            foreach (ListViewItem lvi in lvwSuspMsgs.SelectedItems)
            {
                SuspendedInstance suspendedInstance = (SuspendedInstance)lvi.Tag;
                txtDetails.AppendText("Host : ", FontStyle.Bold);
                txtDetails.AppendText(suspendedInstance.Host, FontStyle.Regular);
                txtDetails.AppendText("\r\n");
                txtDetails.AppendText("Application : ", FontStyle.Bold);
                txtDetails.AppendText(suspendedInstance.Application, FontStyle.Regular);
                txtDetails.AppendText("\r\n");
                txtDetails.AppendText("Message type : ", FontStyle.Bold);
                txtDetails.AppendText(suspendedInstance.MessageType, FontStyle.Regular);
                txtDetails.AppendText("\r\n");
                txtDetails.AppendText("Server : ", FontStyle.Bold);
                txtDetails.AppendText(suspendedInstance.PublishingServer, FontStyle.Regular);
                txtDetails.AppendText("\r\n");
                txtDetails.AppendText("Time : ", FontStyle.Bold);
                txtDetails.AppendText(suspendedInstance.SuspendTime.ToString(), FontStyle.Regular);
                txtDetails.AppendText("\r\n");
                txtDetails.AppendText("URI : ", FontStyle.Bold);
                txtDetails.AppendText(suspendedInstance.Uri, FontStyle.Regular);
                txtDetails.AppendText("\r\n");
                txtDetails.AppendText("Adapter : ", FontStyle.Bold);
                txtDetails.AppendText(suspendedInstance.Adapter, FontStyle.Regular);
                if (suspendedInstance.Adapter == "FILE")
                {
                    txtDetails.AppendText("\r\n");
                    txtDetails.AppendText("File name : ", FontStyle.Bold);
                    txtDetails.AppendText(suspendedInstance.MsgPath, FontStyle.Regular);
                }
                txtDetails.AppendText("\r\n");
                txtDetails.AppendText("Additional Info : ", FontStyle.Bold);
                txtDetails.AppendText("\r\n");
                txtDetails.AppendText(suspendedInstance.AdditionalInfo, FontStyle.Regular);
                txtDetails.AppendText("\r\n");
                txtDetails.AppendText("------------------------------------------------------------------------------\r\n");
                txtDetails.AppendText("\r\n");
            }            
        }

        private void cmdToggleHideDetails_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            cmdToggleHideDetails.Text = splitContainer1.Panel2Collapsed ? "ttt" : "uuu";
            if (splitContainer1.SplitterDistance > splitContainer1.Height - 200)
                splitContainer1.SplitterDistance = splitContainer1.Height - 200;
        }

        private void ShowDetails_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
        }

        private void ShowDetails_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshList();
            }
            else if (e.KeyCode == Keys.F8)
            {
                cmdToggleHideDetails_Click(sender,e);
            }
        }
    }
}
