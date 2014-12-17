using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class EditCollectorHost : Form
    {
        public EditCollectorHost()
        {
            InitializeComponent();
        }

        public string SelectedConfig { get; set; }
        public MonitorPack HostingMonitorPack { get; set; }
        private CollectorHost editingCollectorHost = new CollectorHost();


        public DialogResult ShowDialog(CollectorHost ch, MonitorPack hostingMonitorPack = null)
        {
            if (ch != null)
            {
                SelectedConfig = ch.ToXml();
                return ShowDialog();
            }
            else
                return System.Windows.Forms.DialogResult.Cancel;
        }

        private void EditCollectorHost_Load(object sender, EventArgs e)
        {
            if (SelectedConfig != null && SelectedConfig.Length > 0 && SelectedConfig.StartsWith("<collectorHost", StringComparison.CurrentCultureIgnoreCase))
            {
                editingCollectorHost = CollectorHost.FromXml(SelectedConfig, false);
            }
        }
        private void EditCollectorHost_Shown(object sender, EventArgs e)
        {
            LoadControlData();
        }

        #region private methods
        private void LoadControlData()
        {
            if (editingCollectorHost != null)
            {
                txtName.Text = editingCollectorHost.Name;
                chkEnabled.Checked = editingCollectorHost.Enabled;
                chkExpandOnStart.Checked = editingCollectorHost.ExpandOnStart;
            }
        }
        #endregion

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtRemoteAgentServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {

        }

        private void chkForceRemoteExcuteOnChildCollectors_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkRemoteAgentEnabled_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkEnablePollingOverride_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkEnablePollingFrequencySliding_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmdBrowseForRestorationScript_Click(object sender, EventArgs e)
        {

        }

        private void cmdBrowseForWarningCorrectiveScript_Click(object sender, EventArgs e)
        {

        }
    }
}