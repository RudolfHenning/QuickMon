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
    public partial class EditHttpPingEntry : Form
    {
        public EditHttpPingEntry()
        {
            InitializeComponent();
        }

        public HttpPingEntry SelectedHttpPingEntry { get; set; }

        #region Form events
        private void EditHttpPingEntry_Shown(object sender, EventArgs e)
        {
            if (SelectedHttpPingEntry != null)
            {
                txtAddress.Text = SelectedHttpPingEntry.Url;
                txtProxyServer.Text = SelectedHttpPingEntry.ProxyServer;
                nudExpextedTime.Value = SelectedHttpPingEntry.MaxTime;
                nudTimeOut.Value = SelectedHttpPingEntry.TimeOut;
            }
            else
                txtAddress.Text = "http://";
        }
        #endregion 

        #region Button events
        private void cmdTestAddress_Click(object sender, EventArgs e)
        {
            HttpPingEntry tmpHttpPingEntry = new HttpPingEntry();
            if (!(txtAddress.Text.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase) || txtAddress.Text.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase)))
                txtAddress.Text = "http://" + txtAddress.Text;
            tmpHttpPingEntry.Url = txtAddress.Text;
            tmpHttpPingEntry.ProxyServer = txtProxyServer.Text;
            tmpHttpPingEntry.MaxTime = (int)nudExpextedTime.Value;
            tmpHttpPingEntry.TimeOut = (int)nudTimeOut.Value;
            try
            {
                int pingTime = tmpHttpPingEntry.Ping();
                if (pingTime == int.MaxValue)
                    throw new Exception("An error occured while trying to ping the URL\r\n" + tmpHttpPingEntry.LastError);

                MessageBox.Show(string.Format("Test success!\r\nTime: {0}ms", pingTime), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (CheckOKButtonEnable())
            {
                SelectedHttpPingEntry = new HttpPingEntry();
                SelectedHttpPingEntry.Url = txtAddress.Text;
                SelectedHttpPingEntry.ProxyServer = txtProxyServer.Text;
                SelectedHttpPingEntry.MaxTime = (int)nudExpextedTime.Value;
                SelectedHttpPingEntry.TimeOut = (int)nudTimeOut.Value;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region Input control events
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            CheckOKButtonEnable();
        }
        private void nudExpextedTime_ValueChanged(object sender, EventArgs e)
        {
            CheckOKButtonEnable();
        }
        private void nudTimeOut_ValueChanged(object sender, EventArgs e)
        {
            CheckOKButtonEnable();
        }
        #endregion

        #region Private methods
        private bool CheckOKButtonEnable()
        {
            cmdOK.Enabled = txtAddress.Text.Length > 0 && (!txtAddress.Text.Contains("\\")) && nudExpextedTime.Value < nudTimeOut.Value;
            cmdTestAddress.Enabled = txtAddress.Text.Length > 0 && (!txtAddress.Text.Contains("\\"));
            return cmdOK.Enabled;
        } 
        #endregion        
    }
}
