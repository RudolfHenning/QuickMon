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
    public partial class CollectorDetails : Form, IChildWindowIdentity
    {
        public CollectorDetails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If set to true the main window refresh cycle will also trigger a refresh of this window's details (the states/current value/history etc)
        /// </summary>
        public bool AutoRefreshEnabled { get; set; }
        public CollectorHost SelectedCollectorHost { get; set; }
        /// <summary>
        /// reference to MainForm for bidirectional updating
        /// </summary>
        public IParentWindow ParentWindow { get; set; }

        #region IChildWindowIdentity
        public string Identifier { get; set; }
        public void RefreshDetails()
        {
            if (SelectedCollectorHost != null)
            {
                txtName.Text = SelectedCollectorHost.Name;
            }
        }
        public void CloseChildWindow()
        {
            if (ParentWindow != null)
                ParentWindow.RemoveChildWindow(this);
        }
        public void ShowChildWindow()
        {
            if (ParentWindow != null)
                ParentWindow.RegisterChildWindow(this);
            Show();
        }
        #endregion

        private void CollectorDetails_Load(object sender, EventArgs e)
        {
            if (SelectedCollectorHost == null)
                SelectedCollectorHost = new CollectorHost();
            RefreshDetails();
            splitContainerMain.Panel2Collapsed = true;
            SetActivePanel(panelAgentStates); 
        }

        private void CollectorDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseChildWindow();
        }

        private void cmdActionScriptsVisible_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel2Collapsed = !splitContainerMain.Panel2Collapsed;
        }

        private void cmdCollectorEdit_Click(object sender, EventArgs e)
        {
            StartEditMode();
        }

        private void StartEditMode()
        {
            optAgentStates.Enabled = false;
            optMetrics.Enabled = false;
            optHistory.Enabled = false;
            txtName.ReadOnly = false;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            SetActivePanel(panelEditing);
        }
        private void StopEditMode()
        {
            optAgentStates.Enabled = true;
            optMetrics.Enabled = true;
            optHistory.Enabled = true;
            txtName.ReadOnly = true;
            txtName.BorderStyle = BorderStyle.None;
            if (optAgentStates.Checked)
                optAgentStates_CheckedChanged(null, null);
            else if (optMetrics.Checked)
                optMetrics_CheckedChanged(null, null);
            else
                optHistory_CheckedChanged(null, null);
        }

        //private void flowLayoutPanelCollectorStuff_Resize(object sender, EventArgs e)
        //{
        //    int clientSizeWidth = flowLayoutPanelCollectorStuff.ClientSize.Width - flowLayoutPanelCollectorStuff.Margin.Left - flowLayoutPanelCollectorStuff.Margin.Right - 1;
        //    int clientSizeHeight = flowLayoutPanelCollectorStuff.ClientSize.Height - flowLayoutPanelCollectorStuff.Margin.Top - flowLayoutPanelCollectorStuff.Margin.Bottom - 1;
        //    foreach (Control c in flowLayoutPanelCollectorStuff.Controls)
        //    {
        //        if (c is Panel)
        //        {
        //            c.Width = clientSizeWidth;
        //            c.Height = clientSizeHeight;
        //        }
        //    }
        //}

        private void optAgentStates_CheckedChanged(object sender, EventArgs e)
        {
            SetActivePanel(panelAgentStates);
        }

        private void SetActivePanel(Panel panelAgentStates)
        {
            
            foreach (Control c in panelCollectorDetails.Controls)
            {
                if (c is Panel && panelAgentStates == (Panel)c)
                {
                    c.Visible = true;
                    c.Dock = DockStyle.Fill;
                }
                else
                {
                    c.Visible = false;
                    c.Dock = DockStyle.None;
                }

            }
        }

        private void optMetrics_CheckedChanged(object sender, EventArgs e)
        {
            SetActivePanel(panelMetrics);
        }

        private void optHistory_CheckedChanged(object sender, EventArgs e)
        {
            SetActivePanel(panelHistory);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            StopEditMode();
        }
    }
}
