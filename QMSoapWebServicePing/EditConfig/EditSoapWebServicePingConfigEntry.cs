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
    public partial class EditSoapWebServicePingConfigEntry : Form
    {
        public EditSoapWebServicePingConfigEntry()
        {
            InitializeComponent();
        }

        public SoapWebServicePingConfigEntry SelectedSoapWebServicePingConfigEntry { get; set; }

        #region Form events
        private void EditSoapWebServicePingConfigEntry_Shown(object sender, EventArgs e)
        {
            if (SelectedSoapWebServicePingConfigEntry != null)
            {
                txtServiceURL.Text = SelectedSoapWebServicePingConfigEntry.ServiceBaseURL;
                txtServiceName.Text = SelectedSoapWebServicePingConfigEntry.ServiceName;
                txtMethodName.Text = SelectedSoapWebServicePingConfigEntry.MethodName;
                txtParameters.Text = SelectedSoapWebServicePingConfigEntry.ToStringFromParameters();
                cboOnErrorType.SelectedIndex = SelectedSoapWebServicePingConfigEntry.OnErrorType;
                txtErrorCustomValue.Text = SelectedSoapWebServicePingConfigEntry.ErrorCustomValue;
            }
            else
                txtServiceURL.Text = "http://";
        }
        #endregion

        #region Button events
        private void cmdTestAddress_Click(object sender, EventArgs e)
        {
            SoapWebServicePingConfigEntry tmpSoapWebServicePingConfigEntry = new SoapWebServicePingConfigEntry();
            if (!(txtServiceURL.Text.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase) || txtServiceURL.Text.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase)))
                txtServiceURL.Text = "http://" + txtServiceURL.Text;
            tmpSoapWebServicePingConfigEntry.ServiceBaseURL = txtServiceURL.Text;
            tmpSoapWebServicePingConfigEntry.ServiceName = txtServiceName.Text;
            tmpSoapWebServicePingConfigEntry.MethodName = txtMethodName.Text;
            tmpSoapWebServicePingConfigEntry.Parameters = new List<string>();
            foreach (string par in txtParameters.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (par.Trim().Length > 0)
                    tmpSoapWebServicePingConfigEntry.Parameters.Add(par);
            }
            tmpSoapWebServicePingConfigEntry.OnErrorType = cboOnErrorType.SelectedIndex;
            tmpSoapWebServicePingConfigEntry.ErrorCustomValue = txtErrorCustomValue.Text;
            try
            {
                object pingResult = tmpSoapWebServicePingConfigEntry.ExecuteMethod();
                if (pingResult != null)
                {
                    if (pingResult is DataSet)
                        MessageBox.Show("Method was executed successfully and returned a DataSet", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Method was executed successfully and returned the following:\r\n" + pingResult.ToString(), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Method was executed successfully but return nothing!", "Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }                
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
                SelectedSoapWebServicePingConfigEntry = new SoapWebServicePingConfigEntry();
                SelectedSoapWebServicePingConfigEntry.ServiceBaseURL = txtServiceURL.Text;
                SelectedSoapWebServicePingConfigEntry.ServiceName = txtServiceName.Text;
                SelectedSoapWebServicePingConfigEntry.MethodName = txtMethodName.Text;
                SelectedSoapWebServicePingConfigEntry.Parameters = new List<string>();
                foreach (string par in txtParameters.Text.Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (par.Trim().Length > 0)
                        SelectedSoapWebServicePingConfigEntry.Parameters.Add(par);
                }
                SelectedSoapWebServicePingConfigEntry.OnErrorType = cboOnErrorType.SelectedIndex;
                SelectedSoapWebServicePingConfigEntry.ErrorCustomValue = txtErrorCustomValue.Text;
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
        #endregion

        #region Private methods
        private bool CheckOKButtonEnable()
        {
            cmdOK.Enabled = txtServiceURL.Text.Length > 0 
                && (!txtServiceURL.Text.Contains("\\"))
                && txtServiceName.Text.Trim().Length > 0
                && txtMethodName.Text.Trim().Length > 0;
            cmdTestAddress.Enabled = txtServiceURL.Text.Length > 0 && (!txtServiceURL.Text.Contains("\\"));
            return cmdOK.Enabled;
        }
        #endregion    

    }
}
