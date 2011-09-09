using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class EditConfig : Form
    {
        public EditConfig()
        {
            InitializeComponent();
        }

        public BizTalkGroup BizTalkGroup { get; set; }

        public DialogResult ShowConfig()
        {
            return ShowDialog();
        }

        private void EditConfig_Shown(object sender, EventArgs e)
        {
            if (BizTalkGroup == null)
            {
                BizTalkGroup = new BizTalkGroup();
            }
            txtSQLServer.Text = BizTalkGroup.SqlServer;
            txtDatabase.Text = BizTalkGroup.MgmtDBName;
            chkAllReceiveLocations.Checked = BizTalkGroup.AllReceiveLocations;
            chkAllSendPorts.Checked = BizTalkGroup.AllSendPorts;
            chkAllOrchestrations.Checked = BizTalkGroup.AllOrchestrations;
            LoadReceiveLocations();
            LoadSendPorts();
            LoadOrchestrations();
        }

        private void LoadOrchestrations()
        {
            StringBuilder sb = new StringBuilder();
            lstOrchestrations.Items.Clear();
            txtDisplayOrchestrations.Text = "";
            foreach (string r in (from s in BizTalkGroup.Orchestrations
                                  orderby s
                                  select s))
            {
                lstOrchestrations.Items.Add(r);
                sb.Append(r + ", ");
            }
            string output = sb.ToString().Trim(' ', ',');
            if (output.Length > 1000)
                output = output.Substring(0, 1000) + "...";
            txtDisplayOrchestrations.Text = output;
        }

        private void LoadSendPorts()
        {
            StringBuilder sb = new StringBuilder();
            lstSendPorts.Items.Clear();
            txtDisplaySendPorts.Text = "";
            foreach (string r in (from s in BizTalkGroup.SendPorts
                                  orderby s
                                  select s))
            {
                lstSendPorts.Items.Add(r);
                sb.Append(r + ", ");
            }
            string output = sb.ToString().Trim(' ', ',');
            if (output.Length > 1000)
                output = output.Substring(0, 1000) + "...";
            txtDisplaySendPorts.Text = output;
        }

        private void LoadReceiveLocations()
        {
            StringBuilder sb = new StringBuilder();
            lstReceiveLocations.Items.Clear();
            txtDisplayReceiveLocations.Text = "";
            foreach (string r in (from s in BizTalkGroup.ReceiveLocations
                                      orderby s
                                      select s))
            {
                lstReceiveLocations.Items.Add(r);
                sb.Append(r + ", ");
            }
            string output = sb.ToString().Trim(' ', ',');
            if (output.Length > 1000)
                output = output.Substring(0, 1000) + "...";
            txtDisplayReceiveLocations.Text = output;
        }

        private void chkAllReceiveLocations_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = ((CheckBox)sender).Checked;
            if (chkDisplayAllReceiveLocations.Checked != isChecked)
                chkDisplayAllReceiveLocations.Checked = isChecked;
            if (chkAllReceiveLocations.Checked != isChecked)
                chkAllReceiveLocations.Checked = isChecked;
            lstReceiveLocations.Enabled = !isChecked;
            cmdAddReceiveLocation.Enabled = !isChecked;
            cmdRemoveReceiveLocation.Enabled = !isChecked;
        }
        private void chkAllSendPorts_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = ((CheckBox)sender).Checked;
            if (chkDisplayAllSendPorts.Checked != isChecked)
                chkDisplayAllSendPorts.Checked = isChecked;
            if (chkAllSendPorts.Checked != isChecked)
                chkAllSendPorts.Checked = isChecked;
            lstSendPorts.Enabled = !isChecked;
            cmdAddSendPort.Enabled = !isChecked;
            cmdRemoveSendPort.Enabled = !isChecked;
        }
        private void chkAllOrchestrations_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = ((CheckBox)sender).Checked;
            if (chkDisplayAllOchestrations.Checked != isChecked)
                chkDisplayAllOchestrations.Checked = isChecked;
            if (chkAllOrchestrations.Checked != isChecked)
                chkAllOrchestrations.Checked = isChecked;
            lstOrchestrations.Enabled = !isChecked;
            cmdAddOrchestration.Enabled = !isChecked;
            cmdRemoveOrchestrations.Enabled = !isChecked;
        }

        private void cmdTestDB_Click(object sender, EventArgs e)
        {
            BizTalkGroup.SqlServer = txtSQLServer.Text;
            BizTalkGroup.MgmtDBName = txtDatabase.Text;
            if (!BizTalkGroup.TestConnection())
            {
                MessageBox.Show(BizTalkGroup.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Success", "Connection test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            BizTalkGroup.SqlServer = txtSQLServer.Text;
            BizTalkGroup.MgmtDBName = txtDatabase.Text;
            BizTalkGroup.AllReceiveLocations = chkAllReceiveLocations.Checked;
            BizTalkGroup.AllSendPorts = chkAllSendPorts.Checked;
            BizTalkGroup.AllOrchestrations = chkAllOrchestrations.Checked;
            BizTalkGroup.ReceiveLocations.Clear();
            foreach (string s in lstReceiveLocations.Items)
            {
                BizTalkGroup.ReceiveLocations.Add(s);
            }
            BizTalkGroup.SendPorts.Clear();
            foreach (string s in lstSendPorts.Items)
            {
                BizTalkGroup.SendPorts.Add(s);
            }
            BizTalkGroup.Orchestrations.Clear();
            foreach (string s in lstOrchestrations.Items)
            {
                BizTalkGroup.Orchestrations.Add(s);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        #region Add and remove list items
        private void cmdAddReceiveLocation_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BizTalkGroup.TestConnection())
                    MessageBox.Show(BizTalkGroup.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    EditList editList = new EditList();
                    editList.Text = "Receive Locations";
                    editList.ColumnNames = new List<string>();
                    editList.ColumnNames.Add("Receive Port");
                    editList.ColumnNames.Add("Receive Location");
                    editList.ColumnNames.Add("Host");
                    editList.ValueColumn = 1;
                    editList.ExcludeItems = new List<string>();
                    editList.ExcludeItems.AddRange((from s in BizTalkGroup.ReceiveLocations
                                                    orderby s
                                                    select s).ToArray());
                    editList.Items = new List<string[]>();
                    List<ReceiveLocationInfo> list = BizTalkGroup.GetReceiveLocationList();
                    foreach (var rl in list)
                    {
                        editList.Items.Add(new string[] { rl.ReceivePortName, rl.ReceiveLocationName, rl.HostName });
                    }
                    if (editList.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BizTalkGroup.ReceiveLocations.AddRange(editList.SelectedItems.ToArray());
                        LoadReceiveLocations();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdRemoveReceiveLocation_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove the selected item(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (int index in (from int i in lstReceiveLocations.SelectedIndices
                                       orderby i descending
                                       select i))
                {
                    BizTalkGroup.ReceiveLocations.Remove(lstReceiveLocations.Items[index].ToString());
                    LoadReceiveLocations();
                }
            }
        }
        private void cmdAddSendPort_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BizTalkGroup.TestConnection())
                    MessageBox.Show(BizTalkGroup.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    EditList editList = new EditList();
                    editList.Text = "Send ports";
                    editList.ColumnNames = new List<string>();
                    editList.ColumnNames.Add("Send Port");
                    editList.ValueColumn = 1;
                    editList.ExcludeItems = new List<string>();
                    editList.ExcludeItems.AddRange((from s in BizTalkGroup.SendPorts
                                                    orderby s
                                                    select s).ToArray());
                    editList.Items = new List<string[]>();
                    List<SendPortInfo> list = BizTalkGroup.GetSendPortList();
                    foreach (var s in list)
                    {
                        editList.Items.Add(new string[] { s.Name });
                    }
                    if (editList.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BizTalkGroup.SendPorts.AddRange(editList.SelectedItems.ToArray());
                        LoadSendPorts();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdRemoveSendPort_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove the selected item(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (int index in (from int i in lstSendPorts.SelectedIndices
                                       orderby i descending
                                       select i))
                {
                    BizTalkGroup.SendPorts.Remove(lstSendPorts.Items[index].ToString());
                    LoadSendPorts();
                }
            }
        }
        private void cmdAddOrchestration_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BizTalkGroup.TestConnection())
                    MessageBox.Show(BizTalkGroup.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    EditList editList = new EditList();
                    editList.Text = "Orchestrations";
                    editList.ColumnNames = new List<string>();
                    editList.ColumnNames.Add("Orchestrations");
                    editList.ValueColumn = 1;
                    editList.ExcludeItems = new List<string>();
                    editList.ExcludeItems.AddRange((from s in BizTalkGroup.Orchestrations
                                                    orderby s
                                                    select s).ToArray());
                    editList.Items = new List<string[]>();
                    List<SendPortInfo> list = BizTalkGroup.GetOrchestrationList();
                    foreach (var s in list)
                    {
                        editList.Items.Add(new string[] { s.Name });
                    }
                    if (editList.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BizTalkGroup.Orchestrations.AddRange(editList.SelectedItems.ToArray());
                        LoadOrchestrations();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdRemoveOrchestrations_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove the selected item(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (int index in (from int i in lstOrchestrations.SelectedIndices
                                       orderby i descending
                                       select i))
                {
                    BizTalkGroup.Orchestrations.Remove(lstOrchestrations.Items[index].ToString());
                    LoadOrchestrations();
                }
            }
        } 
        #endregion
    }
}
