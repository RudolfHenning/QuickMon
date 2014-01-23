using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Notifiers
{
    public partial class EventLogNotifierEditConfig : SimpleNotifierEditConfig
    {
        public EventLogNotifierEditConfig()
        {
            InitializeComponent();
        }

        public override void LoadEditData()
        {
            if (SelectedConfig != null)
            {
                EventLogNotifierConfig currentConfig = (EventLogNotifierConfig)SelectedConfig;
                txtMachine.Text = currentConfig.MachineName;
                txtEventSource.Text = currentConfig.EventSource;
            }
            base.LoadEditData();
        }

    }
}
