using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Controls
{
    public partial class ConfigureEditButton : UserControl
    {
        public ConfigureEditButton()
        {
            InitializeComponent();
        }

        public event EventHandler ConfigureClicked;
        private void RaiseConfigureClicked(object sender, EventArgs e)
        {
            if (ConfigureClicked != null)
            {
                ConfigureClicked(sender, e);
            }
        }
        public event EventHandler ManualConfigureClicked;
        private void RaiseManualConfigureClicked(object sender, EventArgs e)
        {
            if (ManualConfigureClicked != null)
            {
                ManualConfigureClicked(sender, e);
            }
        }
        public event EventHandler ImportConfigurationClicked;
        private void RaiseImportConfigurationClicked(object sender, EventArgs e)
        {
            if (ImportConfigurationClicked != null)
            {
                ImportConfigurationClicked(sender, e);
            }
        }

        private void cmdDropDown_Click(object sender, EventArgs e)
        {
            contextMenuStripButton.Show(this, new Point(0, this.Height));
        }

        private void cmdConfigure_Click(object sender, EventArgs e)
        {
            RaiseConfigureClicked(sender, e);
        }
        private void manualConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RaiseManualConfigureClicked(sender, e);
        }
        private void importFromExistingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RaiseImportConfigurationClicked(sender, e);
        }
    }
}
