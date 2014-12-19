using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Collectors
{
    public partial class ServiceStateCollectorEditEntry : Form, IAgentConfigEntryEditWindow
    {
        public ServiceStateCollectorEditEntry()
        {
            InitializeComponent();
        }

        #region IAgentConfigEntryEditWindow Members
        public ICollectorConfigEntry SelectedEntry { get; set; }
        public QuickMonDialogResult ShowEditEntry()
        {
            return (QuickMonDialogResult)ShowDialog();
        }
        #endregion

        private void ServiceStateCollectorEditEntry_Load(object sender, EventArgs e)
        {
            txtComputer.Text = "";
            txtFilter.Text = "";
            lstServices.Items.Clear();
            lstSearchServices.Items.Clear();            
            if (SelectedEntry != null)
            {
                WindowsServiceStateHostEntry selectedEntry = (WindowsServiceStateHostEntry)SelectedEntry;
                txtComputer.Text = selectedEntry.MachineName;                
                foreach (ICollectorConfigSubEntry service in selectedEntry.SubItems)
                {
                    lstServices.Items.Add(service.Description);
                }
                
            }            
        }   
        private void ServiceStateCollectorEditEntry_Shown(object sender, EventArgs e)
        {
            if (txtComputer.Text.Length > 0 && lstServices.Items.Count > 0)
            {
                LoadServiceList();
            }
        }

        private void cmdLoadServices_Click(object sender, EventArgs e)
        {
            LoadServiceList();
        }
        private void LoadServiceList()
        {
            if (txtComputer.Text.Length == 0)
                txtComputer.Text = System.Net.Dns.GetHostName();
            if ((txtComputer.Text == ".") || (txtComputer.Text == "localhost"))
                txtComputer.Text = System.Net.Dns.GetHostName();
            
            //machine = txtComputer.Text.ToUpper();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lstSearchServices.Items.Clear();
                LoadServiceList(txtComputer.Text.ToUpper());
                //Cursor.Current = Cursors.WaitCursor;
                //lstSearchServices.Items.Clear();
                //foreach (string machineName in machine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                //{
                //    LoadServiceList(machineName.Trim());
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            cmdAdd.Enabled = false;
        }
        private void LoadServiceList(string machineName)
        {
            machineName = machineName.ToUpper();
            lstSearchServices.Items.AddRange
                    (
                        (from ServiceController controller in ServiceController.GetServices(machineName)
                         where (
                                    txtFilter.Text.Length == 0 ||
                                    controller.DisplayName.ToUpper().Contains(txtFilter.Text.ToUpper())
                                )
                                && !ExcludeItem(controller.MachineName, controller.DisplayName)
                                && (from string s in lstServices.Items
                                    where s.ToUpper() == (controller.DisplayName).ToUpper()
                                    select s).Count() == 0
                         select controller.DisplayName).ToArray()
                    );
        }
        private bool ExcludeItem(string machineName, string displayName)
        {
            return (from string excl in lstServices.Items
                    where excl.ToUpper() == displayName.ToUpper()
                    select excl).Count() > 0;            
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            foreach (string serviceName in lstSearchServices.SelectedItems)
            {
                if (!lstServices.Items.Contains(serviceName))
                    lstServices.Items.Add(serviceName);
            }
            foreach (int index in (from int i in lstSearchServices.SelectedIndices
                                   orderby i descending
                                   select i))
            {
                lstSearchServices.Items.RemoveAt(index);
            }
            CheckOKEnabled();
        }

        private void CheckOKEnabled()
        {
            cmdOK.Enabled = lstServices.Items.Count > 0;
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            foreach (string serviceName in lstServices.SelectedItems)
            {
                if (!lstSearchServices.Items.Contains(serviceName))
                    lstSearchServices.Items.Add(serviceName);
            }
            foreach (int index in (from int i in lstServices.SelectedIndices
                                   orderby i descending
                                   select i))
            {
                lstServices.Items.RemoveAt(index);
            }
            CheckOKEnabled();
        }

        private void lstSearchServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdAdd.Enabled = lstSearchServices.SelectedIndex != -1;
        }

        private void lstServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdRemove.Enabled = lstServices.SelectedIndex != -1;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lstServices.Items.Count > 0)
            {
                if (SelectedEntry == null)
                    SelectedEntry = new WindowsServiceStateHostEntry();
                WindowsServiceStateHostEntry selectedEntry = (WindowsServiceStateHostEntry)SelectedEntry;
                selectedEntry.MachineName = txtComputer.Text;
                selectedEntry.SubItems.Clear();
                for (int i = 0; i < lstServices.Items.Count; i++)
                {
                    selectedEntry.SubItems.Add(new WindowsServiceStateServiceEntry() { Description = lstServices.Items[i].ToString() });
                }
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                LoadServiceList();
            }
        }

        private void txtComputer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                LoadServiceList();
            }
        }


    }
}
