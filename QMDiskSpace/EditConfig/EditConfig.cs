using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

                    XmlElement root = config.DocumentElement;
                    foreach (XmlElement drive in root.SelectNodes("drives/drive"))
                    {
                        DriveSpaceEntry driveSpaceEntry = new DriveSpaceEntry();
                        driveSpaceEntry.DriveLetter = drive.ReadXmlElementAttr("name", "c");
                        driveSpaceEntry.WarningSizeLeftMB = long.Parse(drive.ReadXmlElementAttr("warningSizeLeftMB", "500"));
                        driveSpaceEntry.ErrorSizeLeftMB = long.Parse(drive.ReadXmlElementAttr("errorSizeLeftMB", "100"));
                        driveSpaceEntry.WarnOnNotReady = bool.Parse(drive.ReadXmlElementAttr("warnOnNotReady", "False"));

                        ListViewItem lvi = new ListViewItem(driveSpaceEntry.DriveLetter);
                        lvi.SubItems.Add(driveSpaceEntry.WarningSizeLeftMB.ToString());
                        lvi.SubItems.Add(driveSpaceEntry.ErrorSizeLeftMB.ToString());
                        lvi.SubItems.Add(driveSpaceEntry.WarnOnNotReady.ToString());
                        lvi.Tag = driveSpaceEntry;
                        lvwDrives.Items.Add(lvi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return ShowDialog();
        }

        private void lvwHosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdEdit.Enabled = (lvwDrives.SelectedItems.Count > 0);
            cmdRemove.Enabled = (lvwDrives.SelectedItems.Count > 0);
        }

        #region Button events
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            EditDiskSpace editDiskSpace = new EditDiskSpace();
            editDiskSpace.DriveSpace = new DriveSpaceEntry();

            if (editDiskSpace.ShowDriveSpace() == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editDiskSpace.DriveSpace.DriveLetter);
                lvi.SubItems.Add(editDiskSpace.DriveSpace.WarningSizeLeftMB.ToString());
                lvi.SubItems.Add(editDiskSpace.DriveSpace.ErrorSizeLeftMB.ToString());
                lvi.SubItems.Add(editDiskSpace.DriveSpace.WarnOnNotReady.ToString());
                lvi.Tag = editDiskSpace.DriveSpace;
                lvwDrives.Items.Add(lvi);
            }
        }
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lvwDrives.SelectedItems.Count > 0)
            {
                EditDiskSpace editDiskSpace = new EditDiskSpace();
                editDiskSpace.DriveSpace = (DriveSpaceEntry)lvwDrives.SelectedItems[0].Tag;
                if (editDiskSpace.ShowDriveSpace() == DialogResult.OK)
                {
                    lvwDrives.SelectedItems[0].Text = editDiskSpace.DriveSpace.DriveLetter;
                    lvwDrives.SelectedItems[0].SubItems[1].Text = editDiskSpace.DriveSpace.WarningSizeLeftMB.ToString();
                    lvwDrives.SelectedItems[0].SubItems[2].Text = editDiskSpace.DriveSpace.ErrorSizeLeftMB.ToString();
                    lvwDrives.SelectedItems[0].SubItems[3].Text = editDiskSpace.DriveSpace.WarnOnNotReady.ToString();
                    lvwDrives.SelectedItems[0].Tag = editDiskSpace.DriveSpace;
                }
            }
        }
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lvwDrives.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove this entry(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwDrives.SelectedItems)
                    {
                        lvwDrives.Items.Remove(lvi);
                    }
                }
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml("<config><drives></drives></config>");

            XmlNode drivesListNode = config.SelectSingleNode("config/drives");
            foreach (ListViewItem lvi in lvwDrives.Items)
            {
                DriveSpaceEntry dse = (DriveSpaceEntry)lvi.Tag;

                XmlNode driveXmlNode = config.CreateElement("drive");
                driveXmlNode.Attributes.Append(config.CreateAttributeWithValue("name", dse.DriveLetter));
                driveXmlNode.Attributes.Append(config.CreateAttributeWithValue("warningSizeLeftMB", dse.WarningSizeLeftMB));
                driveXmlNode.Attributes.Append(config.CreateAttributeWithValue("errorSizeLeftMB", dse.ErrorSizeLeftMB));
                driveXmlNode.Attributes.Append(config.CreateAttributeWithValue("warnOnNotReady", dse.WarnOnNotReady));

                drivesListNode.AppendChild(driveXmlNode);
            }

            CustomConfig = config.OuterXml;
            DialogResult = DialogResult.OK;
            Close();
        } 
        #endregion
    }
}
