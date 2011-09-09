using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;

namespace QuickMon
{
    public partial class AddService : Form
    {
        public AddService()
        {
            InitializeComponent();
        }

        private List<string> excludeList = new List<string>();
        public List<string> ExcludeList
        {
            get { return excludeList; }
        }
        private string machine = ".";
        public string Machine
        {
            get { return machine; }
            set { machine = value; }
        }
        private System.Collections.Specialized.StringCollection selectedServices;
        public System.Collections.Specialized.StringCollection SelectedServices
        {
            get { return selectedServices; }
        }

        public DialogResult ShowDialog(string machine)
        {
            this.machine = machine;
            return this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadServiceList();
        }

        private void LoadServiceList()
        {
            if (txtMachine.Text.Length == 0)
                txtMachine.Text = System.Net.Dns.GetHostName();
            if ((txtMachine.Text == ".") || (txtMachine.Text == "localhost"))
                txtMachine.Text = System.Net.Dns.GetHostName();
            machine = txtMachine.Text.ToUpper();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                lstSearchServices.Items.Clear();
                foreach (string machineName in machine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    LoadServiceList(machineName.Trim());
                }
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
                                &&  !ExcludeItem(controller.MachineName, controller.DisplayName)
                         select controller.MachineName + "\\" + controller.DisplayName).ToArray()
                    );
        }
        private bool ExcludeItem(string machineName, string displayName)
        {
            return (from ex in excludeList
                    where ex.ToUpper() == (machineName + "\\" + displayName).ToUpper()
                    select ex).Count() > 0;
        }        

        private void txtMachine_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadServiceList();
                e.Handled = true;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lstServices.Items.Count > 0)
            {
                selectedServices = new System.Collections.Specialized.StringCollection();
                for (int i = 0; i < lstServices.Items.Count; i++)
                {
                    selectedServices.Add(lstServices.Items[i].ToString());
                }
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void AddService_Load(object sender, EventArgs e)
        {
            txtMachine.Text = machine;
        }

        private void lstServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdRemove.Enabled = lstServices.SelectedIndex != -1;
        }

        private void lstSearchServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdAdd.Enabled = lstSearchServices.SelectedIndex != -1;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            foreach (string serviceName in lstSearchServices.SelectedItems)
            {
                if (!lstServices.Items.Contains(serviceName))
                    lstServices.Items.Add(serviceName);
            }
            CheckOKEnabled();
        }

        private void CheckOKEnabled()
        {
            cmdOK.Enabled = lstServices.Items.Count > 0;
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            foreach (int index in (from int i in lstServices.SelectedIndices
                                   orderby i descending
                                   select i))
            {
                lstServices.Items.RemoveAt(index);
            }
            CheckOKEnabled();
        }
    }
}
