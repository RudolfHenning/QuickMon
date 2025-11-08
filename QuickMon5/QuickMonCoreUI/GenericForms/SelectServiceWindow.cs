using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public partial class SelectServiceWindow : Form
    {
        public MonitorPack CurrentMonitorPack { get; set; } = null;
        public ServiceWindow SelectedServiceWindow { get; set; } = null;

        public SelectServiceWindow()
        {
            InitializeComponent();
        }

        private void SelectServiceWindow_Load(object sender, EventArgs e)
        {
            LoadServiceWindows();
        }

        private void LoadServiceWindows()
        {
            if (CurrentMonitorPack != null)
            {
                Dictionary<string, ServiceWindow> list = new Dictionary<string, ServiceWindow>();
                foreach (CollectorHost ch in CurrentMonitorPack.CollectorHosts)
                {
                    if (ch.ServiceWindows != null && ch.ServiceWindows.Entries.Count > 0)
                    {
                        foreach (var sv in ch.ServiceWindows.Entries)
                        {
                            string serviceWindowStr = sv.ToString();
                            if (!list.ContainsKey(serviceWindowStr))
                            {
                                list.Add(serviceWindowStr, sv);
                            }
                        }
                    }
                }
                foreach (NotifierHost nh in CurrentMonitorPack.NotifierHosts)
                {
                    if (nh.ServiceWindows != null && nh.ServiceWindows.Entries.Count > 0)
                    {
                        foreach (var sv in nh.ServiceWindows.Entries)
                        {
                            string serviceWindowStr = sv.ToString();
                            if (!list.ContainsKey(serviceWindowStr))
                            {
                                list.Add(serviceWindowStr, sv);
                            }
                        }
                    }
                }

                foreach (var si in list.OrderBy(s => s.Key))
                {
                    lstServiceWindows.Items.Add(si);
                }
            }
        }

        private void lstServiceWindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lstServiceWindows.SelectedIndex > -1;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lstServiceWindows.SelectedIndex > -1)
            {
                dynamic selectedObject = lstServiceWindows.SelectedItem;
                if (selectedObject.Value is ServiceWindow)
                {
                    SelectedServiceWindow = (ServiceWindow)selectedObject.Value;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}

