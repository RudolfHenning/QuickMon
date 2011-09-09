using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace QuickMon
{
    public partial class EditConfig : Form
    {
        public EditConfig()
        {
            InitializeComponent();
        }

        public string CustomConfig { get; set; }

        public DialogResult ShowConfig()
        {
            if (CustomConfig.Length > 0)
            {
                try
                {
                    XmlDocument config = new XmlDocument();
                    config.LoadXml(CustomConfig);

                    XmlNodeList hostListNodes = config.GetElementsByTagName("host");
                    foreach (XmlNode hostXmlNode in hostListNodes)
                    {
                        HostEntry hostEntry = new HostEntry();
                        hostEntry.HostName = hostXmlNode.Attributes.GetNamedItem("hostName").Value;
                        hostEntry.Description = hostXmlNode.Attributes.GetNamedItem("description").Value;
                        hostEntry.MaxTime = int.Parse( hostXmlNode.Attributes.GetNamedItem("maxTime").Value);
                        hostEntry.TimeOut = int.Parse(hostXmlNode.Attributes.GetNamedItem("timeOut").Value);

                        ListViewItem lvi = new ListViewItem(hostEntry.HostName);
                        lvi.SubItems.Add(hostEntry.MaxTime.ToString());
                        lvi.SubItems.Add(hostEntry.TimeOut.ToString());
                        lvi.SubItems.Add(hostEntry.Description);
                        lvi.Tag = hostEntry;
                        lvwHosts.Items.Add(lvi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ShowDialog();
        }

        private void lvwHosts_Resize(object sender, EventArgs e)
        {
            lvwHosts.Columns[3].Width = lvwHosts.Width - 25 - lvwHosts.Columns[0].Width - lvwHosts.Columns[1].Width - lvwHosts.Columns[2].Width;
        }

        private void lvwHosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdEdit.Enabled = (lvwHosts.SelectedItems.Count > 0);
            cmdRemove.Enabled = (lvwHosts.SelectedItems.Count > 0);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml("<config><hosts></hosts></config>");

            XmlNode hostsListNode = config.SelectSingleNode("config/hosts");
            foreach (ListViewItem lvi in lvwHosts.Items)
            {
                HostEntry hostEntry = (HostEntry)lvi.Tag;

                XmlNode hostXmlNode = config.CreateElement("host");
                XmlAttribute hostNameXmlAttribute = config.CreateAttribute("hostName");
                hostNameXmlAttribute.Value = hostEntry.HostName;
                hostXmlNode.Attributes.Append(hostNameXmlAttribute);
                XmlAttribute descriptionXmlAttribute = config.CreateAttribute("description");
                descriptionXmlAttribute.Value = hostEntry.Description;
                hostXmlNode.Attributes.Append(descriptionXmlAttribute);
                XmlAttribute maxTimeXmlAttribute = config.CreateAttribute("maxTime");
                maxTimeXmlAttribute.Value = hostEntry.MaxTime.ToString();
                hostXmlNode.Attributes.Append(maxTimeXmlAttribute);
                XmlAttribute timeOutXmlAttribute = config.CreateAttribute("timeOut");
                timeOutXmlAttribute.Value = hostEntry.TimeOut.ToString();
                hostXmlNode.Attributes.Append(timeOutXmlAttribute);

                hostsListNode.AppendChild(hostXmlNode);
            }

            CustomConfig = config.OuterXml;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            EditHostAddress editHostAddress = new EditHostAddress();
            editHostAddress.HostEntry = new HostEntry();

            if (editHostAddress.ShowHostAddress() == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editHostAddress.HostEntry.HostName);
                lvi.SubItems.Add(editHostAddress.HostEntry.MaxTime.ToString());
                lvi.SubItems.Add(editHostAddress.HostEntry.TimeOut.ToString());
                lvi.SubItems.Add(editHostAddress.HostEntry.Description);
                lvi.Tag = editHostAddress.HostEntry;
                lvwHosts.Items.Add(lvi);
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lvwHosts.SelectedItems.Count > 0)
            {
                EditHostAddress editHostAddress = new EditHostAddress();
                editHostAddress.HostEntry = (HostEntry)lvwHosts.SelectedItems[0].Tag;
                if (editHostAddress.ShowHostAddress() == DialogResult.OK)
                {
                    lvwHosts.SelectedItems[0].Text = editHostAddress.HostEntry.HostName;
                    lvwHosts.SelectedItems[0].SubItems[1].Text = editHostAddress.HostEntry.MaxTime.ToString();
                    lvwHosts.SelectedItems[0].SubItems[2].Text = editHostAddress.HostEntry.TimeOut.ToString();
                    lvwHosts.SelectedItems[0].SubItems[3].Text = editHostAddress.HostEntry.Description;
                    lvwHosts.SelectedItems[0].Tag = editHostAddress.HostEntry;
                }
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lvwHosts.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove this entry(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwHosts.SelectedItems)
                    {
                        lvwHosts.Items.Remove(lvi);
                    }
                }
            }
        }
    }
}
