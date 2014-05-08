using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuickMon.Management
{
    public partial class RegisteredAgentsManagement : Form
    {
        public RegisteredAgentsManagement()
        {
            InitializeComponent();
        }

        #region Private vars
        private List<AgentRegistration> registrationList; 
        #endregion

        #region Properties
        public string FilePath
        {
            get { return txtFilePath.Text; }
            set
            {
                txtFilePath.Text = value;
            }
        } 
        #endregion

        #region Form events
        private void RegisteredAgentsManagement_Shown(object sender, EventArgs e)
        {
            LoadList();
        }
        #endregion

        #region Toolbar and context menu events
        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            registrationList = new List<AgentRegistration>();
            lvwAgents.Items.Clear();
            txtFilePath.Text = "";
            ValidateInput();
        }
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                string startUpPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify), "Hen IT\\QuickMon");
                if (!System.IO.Directory.Exists(startUpPath))
                    System.IO.Directory.CreateDirectory(startUpPath);
                saveFileDialog1.InitialDirectory = startUpPath;
                saveFileDialog1.FileName = txtFilePath.Text;
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtFilePath.Text = saveFileDialog1.FileName;
                }
                ValidateInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                string startUpPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify), "Hen IT\\QuickMon");
                if (!System.IO.Directory.Exists(startUpPath))
                    System.IO.Directory.CreateDirectory(startUpPath);
                openFileDialog1.InitialDirectory = startUpPath;
                openFileDialog1.FileName = txtFilePath.Text;
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog1.FileName;
                    LoadList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Open", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            EditRegisteredMonitor editRegisteredMonitor = new EditRegisteredMonitor();
            if (editRegisteredMonitor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((from ListViewItem l in lvwAgents.Items
                     where l.Text == editRegisteredMonitor.AgentRegistration.Name
                     select l).Count() > 0)
                {
                    if (MessageBox.Show(string.Format("There is already an agent with the name '{0}'. Do you want to continue?", editRegisteredMonitor.AgentRegistration.Name), "Duplicate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                        return;
                }

                ListViewGroup group = (from ListViewGroup g in lvwAgents.Groups
                                       where (g.Header.ToUpper() == ("Collectors").ToUpper() && editRegisteredMonitor.AgentRegistration.IsCollector) ||
                                            (g.Header.ToUpper() == ("Notifiers").ToUpper() && editRegisteredMonitor.AgentRegistration.IsNotifier)
                                       select g).FirstOrDefault();
                ListViewItem lvi = new ListViewItem(editRegisteredMonitor.AgentRegistration.Name, group);
                lvi.Group = group;
                if (editRegisteredMonitor.AgentRegistration.IsCollector)
                    lvi.ImageIndex = 0;
                else
                    lvi.ImageIndex = 1;
                lvi.SubItems.Add(editRegisteredMonitor.AgentRegistration.ClassName);
                lvi.SubItems.Add(editRegisteredMonitor.AgentRegistration.AssemblyPath);
                lvi.Tag = editRegisteredMonitor.AgentRegistration;
                lvwAgents.Items.Add(lvi);
            }
            ValidateInput();
        }
        private void bulkAddToolStripButton_Click(object sender, EventArgs e)
        {
            List<AgentRegistration> testRegistrationList = new List<AgentRegistration>();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            int addCount = 0;
            int duplicateCount = 0;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (AgentRegistration ar in RegistrationHelper.CreateAgentRegistrationListByDirectory(fbd.SelectedPath))
                {
                    if ((from ListViewItem l in lvwAgents.Items
                         where l.Text == ar.Name
                         select l).Count() == 0)
                    {
                        ListViewGroup group = (from ListViewGroup g in lvwAgents.Groups
                                               where (g.Header.ToUpper() == ("Collectors").ToUpper() && ar.IsCollector) ||
                                                    (g.Header.ToUpper() == ("Notifiers").ToUpper() && ar.IsNotifier)
                                               select g).FirstOrDefault();
                        ListViewItem lvi = new ListViewItem(ar.Name, group);
                        lvi.Group = group;
                        if (ar.IsCollector)
                            lvi.ImageIndex = 0;
                        else
                            lvi.ImageIndex = 1;
                        lvi.SubItems.Add(ar.ClassName);
                        lvi.SubItems.Add(ar.AssemblyPath);
                        lvi.Tag = ar;
                        lvwAgents.Items.Add(lvi);
                        addCount++;
                    }
                    else
                        duplicateCount++;
                }
                MessageBox.Show(string.Format("Import stats:\r\n{0} item(s) added\r\n{1} duplicates ignored", addCount, duplicateCount), "Import done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //foreach (string dllPath in Directory.GetFiles(fbd.SelectedPath, "*.dll"))
                //{
                //    try
                //    {
                //        if (RegistrationHelper.IsQuickMonAssembly(dllPath))
                //        {
                //            foreach (string className in RegistrationHelper.LoadQuickMonClasses(dllPath))
                //            {
                //                string name = className.Replace("QuickMon.", "");
                //                if ((from ListViewItem l in lvwAgents.Items
                //                     where l.Text == name
                //                     select l).Count() == 0)
                //                {
                //                    AgentRegistration agentRegistration = new AgentRegistration();
                //                    agentRegistration.Name = name;
                //                    agentRegistration.AssemblyPath = dllPath;
                //                    agentRegistration.ClassName = className;
                //                    agentRegistration.IsCollector = RegistrationHelper.IsCollectorClass(dllPath, className);
                //                    agentRegistration.IsNotifier = !agentRegistration.IsCollector;

                //                    ListViewGroup group = (from ListViewGroup g in lvwAgents.Groups
                //                                           where (g.Header.ToUpper() == ("Collectors").ToUpper() && agentRegistration.IsCollector) ||
                //                                                (g.Header.ToUpper() == ("Notifiers").ToUpper() && agentRegistration.IsNotifier)
                //                                           select g).FirstOrDefault();
                //                    ListViewItem lvi = new ListViewItem(agentRegistration.Name, group);
                //                    lvi.Group = group;
                //                    if (agentRegistration.IsCollector)
                //                        lvi.ImageIndex = 0;
                //                    else
                //                        lvi.ImageIndex = 1;
                //                    lvi.SubItems.Add(agentRegistration.ClassName);
                //                    lvi.SubItems.Add(agentRegistration.AssemblyPath);
                //                    lvi.Tag = agentRegistration;
                //                    lvwAgents.Items.Add(lvi);
                //                    addCount++;
                //                }
                //                else
                //                    duplicateCount++;
                //            }
                //        }
                //    }
                //    catch { errorCount++; }
                //}
            }
            
            ValidateInput();
        }
        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            EditEntry();
        }
        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            RemoveEntries(); 
        }
        #endregion

        #region Button events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    registrationList = new List<AgentRegistration>();
                    foreach (ListViewItem lvi in lvwAgents.Items)
                    {
                        if (lvi.Tag is AgentRegistration)
                        {
                            registrationList.Add((AgentRegistration)lvi.Tag);
                        }
                    }
                    SerializationUtils.SerializeXMLToFile<List<AgentRegistration>>(txtFilePath.Text, registrationList);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ListView events
        private void lvwAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripButtonRemove.Enabled = lvwAgents.SelectedItems.Count > 0;
            removeToolStripMenuItem.Enabled = lvwAgents.SelectedItems.Count > 0;
            toolStripButtonEdit.Enabled = lvwAgents.SelectedItems.Count == 1;
            editToolStripMenuItem.Enabled = lvwAgents.SelectedItems.Count == 1;
        }
        private void lvwAgents_EnterKeyPressed()
        {
            EditEntry();
        }
        private void lvwAgents_DoubleClick(object sender, EventArgs e)
        {
            EditEntry();
        }
        private void lvwAgents_DeleteKeyPressed()
        {
            RemoveEntries(); 
        }
        #endregion

        #region Private methods
        private void LoadList()
        {
            lvwAgents.Items.Clear();
            if (System.IO.File.Exists(txtFilePath.Text))
            {
                try
                {
                    registrationList = SerializationUtils.DeserializeXML<List<AgentRegistration>>(System.IO.File.ReadAllText(txtFilePath.Text));

                    foreach (AgentRegistration ar in (from a in registrationList
                                                      orderby a.Name
                                                      select a))
                    {
                        ListViewGroup group = (from ListViewGroup g in lvwAgents.Groups
                                               where (g.Header.ToUpper() == ("Collectors").ToUpper() && ar.IsCollector) ||
                                                    (g.Header.ToUpper() == ("Notifiers").ToUpper() && ar.IsNotifier)
                                               select g).FirstOrDefault();
                        if (group == null)
                        {
                            if (ar.IsCollector)
                                group = new ListViewGroup(("Collectors").ToUpper(), ("Collectors").ToUpper());
                            else
                                group = new ListViewGroup(("Notifiers").ToUpper(), ("Notifiers").ToUpper());
                        }
                        ListViewItem lvi = new ListViewItem(ar.Name, group);
                        if (ar.IsCollector)
                        {
                            lvi.ImageIndex = 0;
                        }
                        else
                        {
                            lvi.ImageIndex = 1;
                        }
                        lvi.SubItems.Add(ar.ClassName);
                        lvi.SubItems.Add(ar.AssemblyPath);
                        lvi.Tag = ar;
                        lvwAgents.Items.Add(lvi);
                    }
                    lvwAgents.ShowGroups = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ValidateInput();
        }
        private bool ValidateInput()
        {

            cmdOK.Enabled = txtFilePath.Text.Length > 0 && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtFilePath.Text));
            if (lvwAgents.Items.Count == 0)
                lblWarning.Text = "Add some items to the list";
            else if (txtFilePath.Text.Length == 0)
                lblWarning.Text = "Specify registration list path by Saving";
            else if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtFilePath.Text)))
                lblWarning.Text = "Specify a valid registration list path";
            else
                lblWarning.Text = "";
            int collectorCount = (from ListViewItem l in lvwAgents.Items
                                  where l.ImageIndex == 0
                                  select l).Count();
            int notifierCount = (from ListViewItem l in lvwAgents.Items
                                 where l.ImageIndex == 1
                                 select l).Count();

            statusToolStripStatusLabel.Text = string.Format("{0} collector(s), {1} notifier(s)", collectorCount, notifierCount);
            return cmdOK.Enabled;
        } 
        private void EditEntry()
        {
            if (lvwAgents.SelectedItems.Count == 1)
            {
                EditRegisteredMonitor editRegisteredMonitor = new EditRegisteredMonitor();
                editRegisteredMonitor.AgentRegistration = (AgentRegistration)lvwAgents.SelectedItems[0].Tag;
                if (editRegisteredMonitor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ListViewGroup group = (from ListViewGroup g in lvwAgents.Groups
                                           where (g.Header.ToUpper() == ("Collectors").ToUpper() && editRegisteredMonitor.AgentRegistration.IsCollector) ||
                                                (g.Header.ToUpper() == ("Notifiers").ToUpper() && editRegisteredMonitor.AgentRegistration.IsNotifier)
                                           select g).FirstOrDefault();
                    ListViewItem lvi = lvwAgents.SelectedItems[0];
                    lvi.Text = editRegisteredMonitor.AgentRegistration.Name;
                    lvi.Group = group;
                    if (editRegisteredMonitor.AgentRegistration.IsCollector)
                        lvi.ImageIndex = 0;
                    else
                        lvi.ImageIndex = 1;
                    lvi.SubItems[1].Text = editRegisteredMonitor.AgentRegistration.ClassName;
                    lvi.SubItems[2].Text = editRegisteredMonitor.AgentRegistration.AssemblyPath;
                    lvi.Tag = editRegisteredMonitor.AgentRegistration;
                }
            }
        }
        private void RemoveEntries()
        {
            if (lvwAgents.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove the selected 'agent(s)'", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwAgents.SelectedItems)
                    {
                        lvwAgents.Items.Remove(lvi);
                    }
                }
            }
            ValidateInput();
        }
        #endregion

    }
}
