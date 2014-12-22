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
            lstSelectedServices.Items.Clear();
            lstAvailableServices.Items.Clear();
            if (SelectedEntry != null)
            {
                WindowsServiceStateHostEntry selectedEntry = (WindowsServiceStateHostEntry)SelectedEntry;
                txtComputer.Text = selectedEntry.MachineName;
                foreach (ICollectorConfigSubEntry service in selectedEntry.SubItems)
                {
                    lstSelectedServices.Items.Add(service.Description);
                }
            }
            CheckOKEnabled();
        }   
        private void ServiceStateCollectorEditEntry_Shown(object sender, EventArgs e)
        {
            if (txtComputer.Text.Length > 0 && lstSelectedServices.Items.Count > 0)
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
            //if ((txtComputer.Text == ".") || (txtComputer.Text == "localhost"))
            //    txtComputer.Text = System.Net.Dns.GetHostName();
            
            //machine = txtComputer.Text.ToUpper();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lstAvailableServices.Items.Clear();
                LoadServiceList(txtComputer.Text.ToUpper());
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
            CheckOKEnabled();
        }
        private void LoadServiceList(string machineName)
        {
            machineName = machineName.ToUpper();
            if ((machineName == ".") || (machineName.ToLower() == "localhost"))
                machineName = System.Net.Dns.GetHostName().ToUpper();
            lstAvailableServices.Items.AddRange
                    (
                        (from ServiceController controller in ServiceController.GetServices(machineName)
                         where (
                                    txtFilter.Text.Length == 0 ||
                                    controller.DisplayName.ToUpper().Contains(txtFilter.Text.ToUpper())
                                )
                                && !ExcludeItem(controller.MachineName, controller.DisplayName)
                                && (from string s in lstSelectedServices.Items
                                    where s.ToUpper() == (controller.DisplayName).ToUpper()
                                    select s).Count() == 0
                         select controller.DisplayName).ToArray()
                    );
        }
        private bool ExcludeItem(string machineName, string displayName)
        {
            return (from string excl in lstSelectedServices.Items
                    where excl.ToUpper() == displayName.ToUpper()
                    select excl).Count() > 0;            
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            foreach (string serviceName in lstAvailableServices.SelectedItems)
            {
                if (!lstSelectedServices.Items.Contains(serviceName))
                    lstSelectedServices.Items.Add(serviceName);
            }
            foreach (int index in (from int i in lstAvailableServices.SelectedIndices
                                   orderby i descending
                                   select i))
            {
                lstAvailableServices.Items.RemoveAt(index);
            }
            CheckOKEnabled();
        }

        private void CheckOKEnabled()
        {
            txtComputer.Enabled = lstSelectedServices.Items.Count == 0;
            cmdOK.Enabled = lstSelectedServices.Items.Count > 0;
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            foreach (string serviceName in lstSelectedServices.SelectedItems)
            {
                if (!lstAvailableServices.Items.Contains(serviceName))
                    lstAvailableServices.Items.Add(serviceName);
            }
            foreach (int index in (from int i in lstSelectedServices.SelectedIndices
                                   orderby i descending
                                   select i))
            {
                lstSelectedServices.Items.RemoveAt(index);
            }
            CheckOKEnabled();
        }

        private void lstSearchServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdAdd.Enabled = lstAvailableServices.SelectedIndex != -1;
        }

        private void lstServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdRemove.Enabled = lstSelectedServices.SelectedIndex != -1;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lstSelectedServices.Items.Count > 0)
            {
                if (SelectedEntry == null)
                    SelectedEntry = new WindowsServiceStateHostEntry();
                WindowsServiceStateHostEntry selectedEntry = (WindowsServiceStateHostEntry)SelectedEntry;
                selectedEntry.MachineName = txtComputer.Text;
                selectedEntry.SubItems.Clear();
                for (int i = 0; i < lstSelectedServices.Items.Count; i++)
                {
                    selectedEntry.SubItems.Add(new WindowsServiceStateServiceEntry() { Description = lstSelectedServices.Items[i].ToString() });
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
