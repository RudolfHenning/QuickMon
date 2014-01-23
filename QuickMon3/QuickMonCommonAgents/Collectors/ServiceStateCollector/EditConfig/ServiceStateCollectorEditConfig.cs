using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Collectors
{
    public partial class ServiceStateCollectorEditConfig : Form, IEditConfigWindow, IEditConfigEntryWindow
    {
        public ServiceStateCollectorEditConfig()
        {
            InitializeComponent();
        }

        #region IEditConfigWindow Members
        public IAgentConfig SelectedConfig { get; set; }
        public DialogResult ShowConfig()
        {
            return ShowDialog();
        }
        public void SetTitle(string title)
        {
            this.Text = title;
        }
        #endregion

        #region IEditConfigEntryWindow Members
        public ICollectorConfigEntry SelectedEntry { get; set; }
        public DialogResult ShowEditEntry()
        {
            return ShowDialog();
        }
        #endregion

        private void ServiceStateCollectorEditConfig_Load(object sender, EventArgs e)
        {
            LoadTree();
        }

        private void LoadTree()
        {
            if (SelectedConfig!= null)
            {
                try
                {
                    ServiceStateCollectorConfig currentConfig = (ServiceStateCollectorConfig)SelectedConfig;
                    foreach (ServiceStateDefinition entry in currentConfig.Entries)
                    {
                        TreeNode machineTreeNode = treeConfig.Nodes.Add(entry.MachineName, entry.MachineName);
                        machineTreeNode.ImageIndex = 0;

                        foreach (ServiceStateServiceEntry serviceEntry in entry.SubItems)
                        {
                            TreeNode serviceTreeNode = machineTreeNode.Nodes.Add(entry.MachineName + "\\" + serviceEntry.Description, serviceEntry.Description);
                            serviceTreeNode.ImageIndex = 1;
                            serviceTreeNode.SelectedImageIndex = 1;
                            serviceTreeNode.Tag = serviceEntry;
                        }
                        machineTreeNode.Expand();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private string GetMachineName(string machineSrv)
        {
            if (machineSrv.IndexOf('\\') > -1)
                return machineSrv.Substring(0, machineSrv.IndexOf('\\'));
            else
                return machineSrv;
        }
        private string GetServiceName(string machineSrv)
        {
            if (machineSrv.IndexOf('\\') > -1)
                return machineSrv.Substring(machineSrv.IndexOf('\\') + 1);
            else
                return machineSrv;
        }

        private void treeConfig_AfterSelect(object sender, TreeViewEventArgs e)
        {
            removeToolStripButton.Enabled = (treeConfig.SelectedNode != null);// && treeConfig.SelectedNode.ImageIndex == 1);
            removeToolStripMenuItem.Enabled = (treeConfig.SelectedNode != null);// && treeConfig.SelectedNode.ImageIndex == 1);
        }

        private void removeToolStripButton_Click(object sender, EventArgs e)
        {
            if (treeConfig.SelectedNode != null)
            {
                if (treeConfig.SelectedNode.ImageIndex == 0)
                {
                    if (MessageBox.Show("Are you sure you want to remove this machine and all its services?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        treeConfig.Nodes.Remove(treeConfig.SelectedNode);
                    }
                }
                else
                    if (MessageBox.Show("Are you sure you want to remove this service?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (treeConfig.SelectedNode.Parent.Nodes.Count == 1)
                        {
                            treeConfig.Nodes.Remove(treeConfig.SelectedNode.Parent);
                        }
                        else
                            treeConfig.Nodes.Remove(treeConfig.SelectedNode);
                    }
            }
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            string machineName = "";
            if (treeConfig.SelectedNode != null)
            {
                if (treeConfig.SelectedNode.ImageIndex == 0)
                {
                    machineName = treeConfig.SelectedNode.Text;
                }
                else
                    machineName = treeConfig.SelectedNode.Parent.Text;
            }
            ServiceStateCollectorAddService addService = new ServiceStateCollectorAddService();
            addService.Machine = machineName;
            foreach (TreeNode machineTreeNode in treeConfig.Nodes)
            {
                foreach (TreeNode serviceTreeNode in machineTreeNode.Nodes)
                {
                    addService.ExcludeList.Add(serviceTreeNode.Name);
                }
            }
            if (addService.ShowDialog() == DialogResult.OK)
            {
                foreach (string mn in (from string s in addService.SelectedServices
                                       group s by GetMachineName(s) into g
                                       select g.Key)
                                           )
                {
                    TreeNode selectedMachineTreeNode = null;
                    foreach (TreeNode machineTreeNode in treeConfig.Nodes)
                    {
                        if (machineTreeNode.Text.ToUpper() == mn.ToUpper())
                            selectedMachineTreeNode = machineTreeNode;
                    }
                    if (selectedMachineTreeNode == null)
                    {
                        selectedMachineTreeNode = new TreeNode(mn);
                        treeConfig.Nodes.Add(selectedMachineTreeNode);
                        selectedMachineTreeNode.ImageIndex = 0;
                    }
                    foreach (string service in (from string s in addService.SelectedServices
                                                where GetMachineName(s).ToUpper() == mn.ToUpper()
                                                select GetServiceName(s)))
                    {
                        bool existingService = false;
                        foreach (TreeNode serviceTreeNode in selectedMachineTreeNode.Nodes)
                        {
                            if (service.ToUpper() == serviceTreeNode.Text.ToUpper())
                            {
                                existingService = true;
                                break;
                            }
                        }
                        if (!existingService)
                        {
                            TreeNode serviceTreeNode = new TreeNode(service);
                            serviceTreeNode.Name = mn + "\\" + service;
                            serviceTreeNode.ImageIndex = 1;
                            serviceTreeNode.SelectedImageIndex = 1;
                            selectedMachineTreeNode.Nodes.Add(serviceTreeNode);
                        }
                    }
                }
            }
            foreach (TreeNode machineTreeNode in treeConfig.Nodes)
            {
                machineTreeNode.Expand();
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (SelectedConfig == null)
                SelectedConfig = new ServiceStateCollectorConfig();
            ((ServiceStateCollectorConfig)SelectedConfig).Entries.Clear();
            foreach (TreeNode machineTreeNode in treeConfig.Nodes)
            {
                ServiceStateDefinition ssd = new ServiceStateDefinition();
                ssd.MachineName = machineTreeNode.Text;
                ssd.SubItems = new List<ICollectorConfigSubEntry>();

                foreach (TreeNode serviceTreeNode in machineTreeNode.Nodes)
                {
                    ssd.SubItems.Add(new ServiceStateServiceEntry() { Description = serviceTreeNode.Text });
                }
                ((ServiceStateCollectorConfig)SelectedConfig).Entries.Add(ssd);
            }
            DialogResult = DialogResult.OK;
            Close();
        }


    }
}
