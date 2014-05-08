using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
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
                    XmlNodeList machines = config.GetElementsByTagName("machine");
                    foreach (XmlNode machine in machines)
                    {
                        string machineName = machine.Attributes.GetNamedItem("name").Value;
                        TreeNode machineTreeNode = treeConfig.Nodes.Add(machineName, machineName);
                        machineTreeNode.ImageIndex = 0;

                        XmlNodeList services = machine.SelectNodes("service");
                        foreach (XmlNode service in services)
                        {
                            string serviceName =service.ReadXmlElementAttr("name");
                            TreeNode serviceTreeNode = machineTreeNode.Nodes.Add(machineName + "\\" + serviceName, serviceName);
                            serviceTreeNode.ImageIndex = 1;
                            serviceTreeNode.SelectedImageIndex = 1;
                        }

                        machineTreeNode.Expand();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ShowDialog();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml("<config></config>");
            XmlNode root = config.SelectSingleNode("config");
            foreach (TreeNode machineTreeNode in treeConfig.Nodes)
            {
                XmlNode machineXmlNode = config.CreateElement("machine");
                XmlAttribute machineNameXmlAttribute = config.CreateAttribute("name");
                machineNameXmlAttribute.Value = machineTreeNode.Text;
                machineXmlNode.Attributes.Append(machineNameXmlAttribute);                

                foreach (TreeNode serviceTreeNode in machineTreeNode.Nodes)
                {
                    XmlNode serviceXmlNode = config.CreateElement("service");
                    XmlAttribute nameXmlAttribute = config.CreateAttribute("name");
                    nameXmlAttribute.Value = serviceTreeNode.Text;
                    serviceXmlNode.Attributes.Append(nameXmlAttribute);
                    machineXmlNode.AppendChild(serviceXmlNode);
                }
                root.AppendChild(machineXmlNode);
            }
            CustomConfig = config.OuterXml;
            DialogResult = DialogResult.OK;
            Close();
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

        private void cmdAdd_Click(object sender, EventArgs e)
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
            AddService addService = new AddService();
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

                //TreeNode selectedMachineTreeNode = null;
                //foreach (TreeNode machineTreeNode in treeConfig.Nodes)
                //{
                //    if (machineTreeNode.Text.ToUpper() == addService.Machine.ToUpper())
                //        selectedMachineTreeNode = machineTreeNode;
                //}
                //if (selectedMachineTreeNode == null)
                //{
                //    selectedMachineTreeNode = new TreeNode(addService.Machine);
                //    treeConfig.Nodes.Add(selectedMachineTreeNode);
                //    selectedMachineTreeNode.ImageIndex = 0;
                //}

                //foreach (string service in addService.SelectedServices)
                //{
                //    bool existingService = false;
                //    foreach (TreeNode serviceTreeNode in selectedMachineTreeNode.Nodes)
                //    {
                //        if (service.ToUpper() == serviceTreeNode.Text.ToUpper())
                //        {
                //            existingService = true;
                //            break;
                //        }
                //    }
                //    if (!existingService)
                //    {
                //        TreeNode serviceTreeNode = new TreeNode(service);
                //        serviceTreeNode.ImageIndex = 1;
                //        serviceTreeNode.SelectedImageIndex = 1;
                //        selectedMachineTreeNode.Nodes.Add(serviceTreeNode);
                //    }
                //}
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
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
    }
}
