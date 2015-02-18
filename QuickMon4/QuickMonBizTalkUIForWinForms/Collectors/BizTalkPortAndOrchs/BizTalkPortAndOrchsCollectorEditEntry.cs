using QuickMon.BizTalk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using QuickMon.Forms;
using System.Windows.Forms;

namespace QuickMon.Collectors
{
    public partial class BizTalkPortAndOrchsCollectorEditEntry : CollectorConfigEntryEditWindowBase // Form, ICollectorConfigEntryEditWindow
    {
        public BizTalkPortAndOrchsCollectorEditEntry()
        {
            InitializeComponent();
        }

        //#region ICollectorConfigEntryEditWindow
        //public ICollectorConfigEntry SelectedEntry { get; set; }
        //public QuickMonDialogResult ShowEditEntry()
        //{
        //    return (QuickMonDialogResult)ShowDialog();
        //}
        //#endregion

        #region Form events
        private void BizTalkPortAndOrchsCollectorEditEntry_Load(object sender, EventArgs e)
        {
            if (SelectedEntry == null)
                SelectedEntry = new BizTalkPortAndOrchsCollectorConfigEntry();

            BizTalkPortAndOrchsCollectorConfigEntry currentConfig = (BizTalkPortAndOrchsCollectorConfigEntry)SelectedEntry;
            txtSQLServer.Text = currentConfig.SqlServer;
            txtDatabase.Text = currentConfig.MgmtDBName;
            chkAllReceiveLocations.Checked = currentConfig.AllReceiveLocations;
            chkAllSendPorts.Checked = currentConfig.AllSendPorts;
            chkAllOrchestrations.Checked = currentConfig.AllOrchestrations;
            LoadReceiveLocations();
            LoadSendPorts();
            LoadOrchestrations();
        } 
        #endregion

        #region Private methods
        private void LoadReceiveLocations()
        {
            BizTalkPortAndOrchsCollectorConfigEntry currentConfig = (BizTalkPortAndOrchsCollectorConfigEntry)SelectedEntry;
            lstReceiveLocations.Items.Clear();
            foreach (string r in (from s in currentConfig.ReceiveLocations
                                  orderby s
                                  select s))
            {
                lstReceiveLocations.Items.Add(r);                
            }
            SetReceiveLocationTextBox();            
        }
        private void SetReceiveLocationTextBox()
        {
            if (chkAllReceiveLocations.Checked)
                txtDisplayReceiveLocations.Text = "All";
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string r in lstReceiveLocations.Items)
                {
                    sb.Append(r + ", ");
                }
                string output = sb.ToString().Trim(' ', ',');
                if (output.Length > 1000)
                    output = output.Substring(0, 1000) + "...";
                txtDisplayReceiveLocations.Text = output;
            }
        }
        private void LoadSendPorts()
        {
            BizTalkPortAndOrchsCollectorConfigEntry currentConfig = (BizTalkPortAndOrchsCollectorConfigEntry)SelectedEntry;
            lstSendPorts.Items.Clear();
            foreach (string r in (from s in currentConfig.SendPorts
                                  orderby s
                                  select s))
            {
                lstSendPorts.Items.Add(r);
            }
            SetSendPortTextBox();
        }
        private void SetSendPortTextBox()
        {
            if (chkAllSendPorts.Checked)
                txtDisplaySendPorts.Text = "All";
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string r in lstSendPorts.Items)
                {
                    sb.Append(r + ", ");
                }
                string output = sb.ToString().Trim(' ', ',');
                if (output.Length > 1000)
                    output = output.Substring(0, 1000) + "...";
                txtDisplaySendPorts.Text = output;
            }
        }
        private void LoadOrchestrations()
        {
            BizTalkPortAndOrchsCollectorConfigEntry currentConfig = (BizTalkPortAndOrchsCollectorConfigEntry)SelectedEntry;

            StringBuilder sb = new StringBuilder();
            lstOrchestrations.Items.Clear();
            txtDisplayOrchestrations.Text = "";
            foreach (string r in (from s in currentConfig.Orchestrations
                                  orderby s
                                  select s))
            {
                lstOrchestrations.Items.Add(r);
                sb.Append(r + ", ");
            }
            string output = sb.ToString().Trim(' ', ',');
            if (output.Length > 1000)
                output = output.Substring(0, 1000) + "...";
            if (chkAllOrchestrations.Checked)
                txtDisplayOrchestrations.Text = "All";
            else
                txtDisplayOrchestrations.Text = output;
        }
        private void SetOrchestrationTextBox()
        {
            if (chkAllOrchestrations.Checked)
                txtDisplayOrchestrations.Text = "All";
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string r in lstOrchestrations.Items)
                {
                    sb.Append(r + ", ");
                }
                string output = sb.ToString().Trim(' ', ',');
                if (output.Length > 1000)
                    output = output.Substring(0, 1000) + "...";
                txtDisplayOrchestrations.Text = output;
            }
        }
        #endregion

        #region Checkbox events
        private void chkAllReceiveLocations_CheckedChanged(object sender, EventArgs e)
        {
            lstReceiveLocations.Enabled = !chkAllReceiveLocations.Checked;
            cmdAddReceiveLocation.Enabled = !chkAllReceiveLocations.Checked;
            cmdRemoveReceiveLocation.Enabled = !chkAllReceiveLocations.Checked;
            SetReceiveLocationTextBox();   
        }
        private void chkAllSendPorts_CheckedChanged(object sender, EventArgs e)
        {
            lstSendPorts.Enabled = !chkAllSendPorts.Checked;
            cmdAddSendPort.Enabled = !chkAllSendPorts.Checked;
            cmdRemoveSendPort.Enabled = !chkAllSendPorts.Checked;
            SetSendPortTextBox();
        }
        private void chkAllOrchestrations_CheckedChanged(object sender, EventArgs e)
        {
            lstOrchestrations.Enabled = !chkAllOrchestrations.Checked;
            cmdAddOrchestration.Enabled = !chkAllOrchestrations.Checked;
            cmdRemoveOrchestrations.Enabled = !chkAllOrchestrations.Checked;
            SetOrchestrationTextBox();
        }
        #endregion

        #region Button events
        private void cmdTestDB_Click(object sender, EventArgs e)
        {
            BizTalkPortAndOrchsCollectorConfigEntry currentConfig = new BizTalkPortAndOrchsCollectorConfigEntry();
            currentConfig.SqlServer = txtSQLServer.Text;
            currentConfig.MgmtDBName = txtDatabase.Text;
            if (!currentConfig.TestConnection())
            {
                MessageBox.Show(currentConfig.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Success", "Connection test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            BizTalkPortAndOrchsCollectorConfigEntry currentConfig = (BizTalkPortAndOrchsCollectorConfigEntry)SelectedEntry;            

            currentConfig.SqlServer = txtSQLServer.Text;
            currentConfig.MgmtDBName = txtDatabase.Text;
            currentConfig.AllReceiveLocations = chkAllReceiveLocations.Checked;
            currentConfig.AllSendPorts = chkAllSendPorts.Checked;
            currentConfig.AllOrchestrations = chkAllOrchestrations.Checked;
            currentConfig.ReceiveLocations.Clear();
            foreach (string s in lstReceiveLocations.Items)
            {
                currentConfig.ReceiveLocations.Add(s);
            }
            currentConfig.SendPorts.Clear();
            foreach (string s in lstSendPorts.Items)
            {
                currentConfig.SendPorts.Add(s);
            }
            currentConfig.Orchestrations.Clear();
            foreach (string s in lstOrchestrations.Items)
            {
                currentConfig.Orchestrations.Add(s);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        #endregion

        #region Add and remove list items
        private void cmdAddReceiveLocation_Click(object sender, EventArgs e)
        {
            try
            {
                BizTalkPortAndOrchsCollectorConfigEntry tmpentry = new BizTalkPortAndOrchsCollectorConfigEntry();
                tmpentry.SqlServer = txtSQLServer.Text;
                tmpentry.MgmtDBName = txtDatabase.Text;
                if (!tmpentry.TestConnection())
                    MessageBox.Show(tmpentry.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    BizTalkEditList editList = new BizTalkEditList();
                    editList.Text = "Receive Locations";
                    editList.ColumnNames = new List<string>();
                    editList.ColumnNames.Add("Receive Port");
                    editList.ColumnNames.Add("Receive Location");
                    editList.ColumnNames.Add("Host");
                    editList.ValueColumn = 1;
                    editList.ExcludeItems = new List<string>();
                    editList.ExcludeItems.AddRange((from string s in lstReceiveLocations.Items
                                                    orderby s
                                                    select s).ToArray());
                    editList.Items = new List<string[]>();
                    List<ReceiveLocationInfo> list = tmpentry.GetReceiveLocationList();
                    foreach (var rl in list)
                    {
                        editList.Items.Add(new string[] { rl.ReceivePortName, rl.ReceiveLocationName, rl.HostName });
                    }
                    if (editList.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        lstReceiveLocations.Items.AddRange(editList.SelectedItems.ToArray());                        
                    }
                    SetReceiveLocationTextBox();   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdRemoveReceiveLocation_Click(object sender, EventArgs e)
        {
            BizTalkPortAndOrchsCollectorConfigEntry tmpentry = new BizTalkPortAndOrchsCollectorConfigEntry();
            tmpentry.SqlServer = txtSQLServer.Text;
            tmpentry.MgmtDBName = txtDatabase.Text;
            if (MessageBox.Show("Are you sure you want to remove the selected item(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (int index in (from int i in lstReceiveLocations.SelectedIndices
                                       orderby i descending
                                       select i))
                {
                    lstReceiveLocations.Items.RemoveAt(index);                    
                }
                SetReceiveLocationTextBox();
            }
        }
        private void cmdAddSendPort_Click(object sender, EventArgs e)
        {
            try
            {
                BizTalkPortAndOrchsCollectorConfigEntry tmpentry = new BizTalkPortAndOrchsCollectorConfigEntry();
                tmpentry.SqlServer = txtSQLServer.Text;
                tmpentry.MgmtDBName = txtDatabase.Text;
                if (!tmpentry.TestConnection())
                    MessageBox.Show(tmpentry.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    BizTalkEditList editList = new BizTalkEditList();
                    editList.Text = "Send ports";
                    editList.ColumnNames = new List<string>();
                    editList.ColumnNames.Add("Send Port");
                    editList.ValueColumn = 1;
                    editList.ExcludeItems = new List<string>();
                    editList.ExcludeItems.AddRange((from string s in lstSendPorts.Items
                                                    orderby s
                                                    select s).ToArray());
                    editList.Items = new List<string[]>();
                    List<SendPortInfo> list = tmpentry.GetSendPortList();
                    foreach (var s in list)
                    {
                        editList.Items.Add(new string[] { s.Name });
                    }
                    if (editList.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        lstSendPorts.Items.AddRange(editList.SelectedItems.ToArray());                             
                    }
                    SetSendPortTextBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdRemoveSendPort_Click(object sender, EventArgs e)
        {
            BizTalkPortAndOrchsCollectorConfigEntry currentConfig = (BizTalkPortAndOrchsCollectorConfigEntry)SelectedEntry;

            if (MessageBox.Show("Are you sure you want to remove the selected item(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (int index in (from int i in lstSendPorts.SelectedIndices
                                       orderby i descending
                                       select i))
                {
                    lstSendPorts.Items.RemoveAt(index);                       
                }
                SetSendPortTextBox();
            }
        }
        private void cmdAddOrchestration_Click(object sender, EventArgs e)
        {
            try
            {
                BizTalkPortAndOrchsCollectorConfigEntry currentConfig = (BizTalkPortAndOrchsCollectorConfigEntry)SelectedEntry;
                if (!currentConfig.TestConnection())
                    MessageBox.Show(currentConfig.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    BizTalkEditList editList = new BizTalkEditList();
                    editList.Text = "Orchestrations";
                    editList.ColumnNames = new List<string>();
                    editList.ColumnNames.Add("Orchestrations");
                    editList.ValueColumn = 1;
                    editList.ExcludeItems = new List<string>();
                    editList.ExcludeItems.AddRange((from string s in lstOrchestrations.Items
                                                    orderby s
                                                    select s).ToArray());
                    editList.Items = new List<string[]>();
                    List<SendPortInfo> list = currentConfig.GetOrchestrationList();
                    foreach (var s in list)
                    {
                        editList.Items.Add(new string[] { s.Name });
                    }
                    if (editList.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        lstOrchestrations.Items.AddRange(editList.SelectedItems.ToArray());                        
                    }
                    SetOrchestrationTextBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdRemoveOrchestrations_Click(object sender, EventArgs e)
        {
            BizTalkPortAndOrchsCollectorConfigEntry currentConfig = (BizTalkPortAndOrchsCollectorConfigEntry)SelectedEntry;

            if (MessageBox.Show("Are you sure you want to remove the selected item(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (int index in (from int i in lstOrchestrations.SelectedIndices
                                       orderby i descending
                                       select i))
                {
                    lstOrchestrations.Items.RemoveAt(index);   
                }
                SetOrchestrationTextBox();
            }
        }
        #endregion

    }
}
