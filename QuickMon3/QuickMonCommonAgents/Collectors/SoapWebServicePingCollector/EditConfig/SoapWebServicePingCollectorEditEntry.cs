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
    public partial class SoapWebServicePingCollectorEditEntry : Form, IEditConfigEntryWindow
    {
        public SoapWebServicePingCollectorEditEntry()
        {
            InitializeComponent();
        }

        #region IEditConfigEntryWindow Members
        public ICollectorConfigEntry SelectedEntry { get; set; }
        public DialogResult ShowEditEntry()
        {
            return ShowDialog();
        }
        #endregion

        public SoapWebServicePingConfigEntry SelectedConfig { get; set; }

        private void SoapWebServicePingCollectorEditEntry_Shown(object sender, EventArgs e)
        {
            SoapWebServicePingConfigEntry selectedEntry;
            if (SelectedEntry != null)
                selectedEntry = (SoapWebServicePingConfigEntry)SelectedEntry;
            else
                selectedEntry = (SoapWebServicePingConfigEntry)SelectedConfig;

            if (selectedEntry != null)
            {
                txtServiceURL.Text = selectedEntry.ServiceBaseURL;
                txtServiceName.Text = selectedEntry.ServiceName;
                txtMethodName.Text = selectedEntry.MethodName;
                txtParameters.Text = selectedEntry.ToStringFromParameters();
                cboCheckType.SelectedIndex = selectedEntry.CheckType == SoapWebServicePingCheckType.Success ? 0 : 1;
                cboResultType.SelectedIndex = (int)selectedEntry.ResultType;
                cboErrorCustomValue1.Text = selectedEntry.CustomValue1;
                cboErrorCustomValue2.Text = selectedEntry.CustomValue2;
            }
            else
            {
                txtServiceURL.Text = "http://";
                cboCheckType.SelectedIndex = 0;
                cboResultType.SelectedIndex = 0;
            }
        }

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
            tmpSoapWebServicePingConfigEntry.CheckType = (SoapWebServicePingCheckType)cboCheckType.SelectedIndex;
            tmpSoapWebServicePingConfigEntry.ResultType = (SoapWebServicePingResult)cboResultType.SelectedIndex;
            tmpSoapWebServicePingConfigEntry.CustomValue1 = cboErrorCustomValue1.Text;
            tmpSoapWebServicePingConfigEntry.CustomValue2 = cboErrorCustomValue2.Text;
            try
            {
                object pingResult = tmpSoapWebServicePingConfigEntry.ExecuteMethod();
                if (tmpSoapWebServicePingConfigEntry.ResultType == SoapWebServicePingResult.CheckAvailabilityOnly)
                {
                    MessageBox.Show("Web service is available!", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (pingResult != null && pingResult.ToString() != "")
                {
                    string formattedVal = "";
                    bool result = tmpSoapWebServicePingConfigEntry.CheckResultMatch(pingResult, tmpSoapWebServicePingConfigEntry.ResultType,
                        tmpSoapWebServicePingConfigEntry.CustomValue1, tmpSoapWebServicePingConfigEntry.CustomValue2, out formattedVal);
                    MessageBox.Show(string.Format("Method was executed successfully\r\nResult: {0}\r\nValue: {1}",
                            result ? "Success" : "Fail", formattedVal), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                SoapWebServicePingConfigEntry selectedEntry;
                if (SelectedEntry != null)
                    selectedEntry = (SoapWebServicePingConfigEntry)SelectedEntry;
                else if (SelectedConfig != null)
                    selectedEntry = (SoapWebServicePingConfigEntry)SelectedConfig;
                else
                {
                    selectedEntry = new SoapWebServicePingConfigEntry();
                    SelectedEntry = selectedEntry;
                }

                selectedEntry.ServiceBaseURL = txtServiceURL.Text;
                selectedEntry.ServiceName = txtServiceName.Text;
                selectedEntry.MethodName = txtMethodName.Text;
                selectedEntry.Parameters = new List<string>();
                foreach (string par in txtParameters.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (par.Trim().Length > 0)
                        selectedEntry.Parameters.Add(par);
                }
                selectedEntry.CheckType = (SoapWebServicePingCheckType)cboCheckType.SelectedIndex;
                selectedEntry.ResultType = (SoapWebServicePingResult)cboResultType.SelectedIndex;
                selectedEntry.CustomValue1 = cboErrorCustomValue1.Text;
                selectedEntry.CustomValue2 = cboErrorCustomValue2.Text;
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
            bool customValue1Check = true;
            bool customValue2Check = true;

            if (cboResultType.SelectedIndex < 2) //Check Availability Only & No/Empty Value
                customValue1Check = true;
            else if (cboResultType.SelectedIndex == 2) // Specified Value
            {
                customValue1Check = cboErrorCustomValue1.Text.Length > 0 && !cboErrorCustomValue1.Text.StartsWith("[");
            }
            else if (cboResultType.SelectedIndex == 3) // Values in range
            {
                customValue1Check = cboErrorCustomValue1.Text.IsNumber() && cboErrorCustomValue2.Text.IsNumber();
            }
            else if (cboResultType.SelectedIndex == 4) // Dataset 
            {
                customValue1Check = (cboErrorCustomValue1.Text == "[Count]" && cboErrorCustomValue2.Text.IsNumber())
                        || (cboErrorCustomValue1.Text == "[FirstValue]" && cboErrorCustomValue2.Text.Length > 0)
                        || (cboErrorCustomValue1.Text == "[LastValue]" && cboErrorCustomValue2.Text.Length > 0)
                        || (cboErrorCustomValue1.Text.StartsWith("[") && cboErrorCustomValue1.Text.Contains("][") && cboErrorCustomValue1.Text.EndsWith("]") && cboErrorCustomValue2.Text.Length > 0);
            }
            else //String array
            {
                customValue1Check = (cboErrorCustomValue1.Text == "[Count]" && cboErrorCustomValue2.Text.IsNumber())
                        || (cboErrorCustomValue1.Text == "[FirstValue]" && cboErrorCustomValue2.Text.Length > 0)
                        || (cboErrorCustomValue1.Text == "[LastValue]" && cboErrorCustomValue2.Text.Length > 0)
                        || (cboErrorCustomValue1.Text.StartsWith("[") && (!cboErrorCustomValue1.Text.Contains("][")) && cboErrorCustomValue1.Text.EndsWith("]") && cboErrorCustomValue2.Text.Length > 0);
            }
            if (customValue1Check && cboErrorCustomValue1.Text.StartsWith("[") && cboErrorCustomValue2.Text.StartsWith("["))
            {
                customValue2Check = false;
                if (cboResultType.SelectedIndex >= 4)
                {
                    if (cboErrorCustomValue2.Text.StartsWith("[Between]") && cboErrorCustomValue2.Text.Contains("[and]"))
                    {
                        string[] queryItems = cboErrorCustomValue2.Text.Split(' ');
                        if (queryItems.Length == 4 && queryItems[1].IsNumber() && queryItems[3].IsNumber())
                            customValue2Check = true;
                    }
                    else if (cboErrorCustomValue2.Text.StartsWith("[LargerThan]"))
                    {
                        string[] queryItems = cboErrorCustomValue2.Text.Split(' ');
                        if (queryItems.Length == 2 && queryItems[1].IsNumber())
                            customValue2Check = true;
                    }
                    else if (cboErrorCustomValue2.Text.StartsWith("[SmallerThan]"))
                    {
                        string[] queryItems = cboErrorCustomValue2.Text.Split(' ');
                        if (queryItems.Length == 2 && queryItems[1].IsNumber())
                            customValue2Check = true;
                    }
                }
            }

            cmdOK.Enabled = txtServiceURL.Text.Length > 0
                && (!txtServiceURL.Text.Contains("\\"))
                && txtServiceName.Text.Trim().Length > 0
                && txtMethodName.Text.Trim().Length > 0
                && cboCheckType.SelectedIndex > -1
                && cboResultType.SelectedIndex > -1
                && customValue1Check
                && customValue2Check;
            cmdTestAddress.Enabled = txtServiceURL.Text.Length > 0
                && txtServiceURL.Text.ToLower() != "http://"
                && (!txtServiceURL.Text.Contains("\\"))
                && txtServiceName.Text.Length > 0
                && txtMethodName.Text.Length > 0
                && cboCheckType.SelectedIndex > -1
                && cboResultType.SelectedIndex > -1
                && customValue1Check
                && customValue2Check;
            return cmdOK.Enabled;
        }
        #endregion

        private void cboCheckType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckOKButtonEnable();
        }

        private void cboResultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckOKButtonEnable();
        }

        private void cmdGetWSDL_Click(object sender, EventArgs e)
        {
            if (txtServiceURL.Text.Length > 0)
            {
                string wsdlURL = txtServiceURL.Text + "?WSDL";
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                psi.FileName = wsdlURL;
                p.StartInfo = psi;
                p.Start();
            }
        }


    }
}
