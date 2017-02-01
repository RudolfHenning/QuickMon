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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Ξ
            if (Properties.Settings.Default.ShowMenuOnStart)
                ToggleMenuSize();
            //else
            //    HideMenu();
            treeView1.FullRowSelect = true;
            treeView1.FullRowSelect = false;
            tvwNotifiers.FullRowSelect = true;
            tvwNotifiers.FullRowSelect = false;
            masterSplitContainer.Panel2Collapsed = true;
            Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = string.Format("v{0}.{1}.{2}", v.Major, v.Minor, v.Build);
            lblCollectors.Text = "Collectors";
            lblNotifiers.Text = "Notifiers";
        }
               

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool ctrl = ((Control.ModifierKeys & Keys.Control) == Keys.Control);
            if (ctrl)
            {
                if (e.KeyChar == 'M')
                {
                    
                }
            }


        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.M)
                {
                    ToggleMenuSize();
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ShowMenuOnStart = (panelSlimMenu.Width != 45);
            Properties.Settings.Default.Save();
        }

        #region Menu
        private void cmdMenu_Click(object sender, EventArgs e)
        {
            ToggleMenuSize();
        }
        private void ToggleMenuSize()
        {
            if (panelSlimMenu.Width != 45)
            {
                panelSlimMenu.Width = 45;
                cmdMenu.Text = "";
                cmdNew.Text = "";
                cmdOpen.Text = "";
                splitButtonSave.ButtonText = "";
                splitButtonAgents.ButtonText = "";
                splitButtonTools.ButtonText = "";
                splitButtonInfo.ButtonText = "";
            }
            else
            {
                panelSlimMenu.Width = 105;
                cmdMenu.Text = " Menu";
                cmdNew.Text = " New";
                cmdOpen.Text = " Open";
                splitButtonSave.ButtonText = " Save";
                splitButtonAgents.ButtonText = " Agents";
                splitButtonTools.ButtonText = " Settings";
                splitButtonInfo.ButtonText = " About";
            }
        }
        private void splitButtonSave_SplitButtonClicked(object sender, EventArgs e)
        {
            saveContextMenuStrip.Show(splitButtonSave, new Point(splitButtonSave.Width, 0));
        }
        private void splitButtonAgents_SplitButtonClicked(object sender, EventArgs e)
        {
            agentsContextMenuStrip.Show(splitButtonAgents, new Point(splitButtonAgents.Width, 0));
        }
        private void splitButtonTools_SplitButtonClicked(object sender, EventArgs e)
        {
            settingsContextMenuStrip.Show(splitButtonTools, new Point(splitButtonTools.Width, 0));
        }
        private void splitButtonInfo_SplitButtonClicked(object sender, EventArgs e)
        {
            aboutContextMenuStrip.Show(splitButtonInfo, new Point(splitButtonInfo.Width, 0));
        }

        #endregion

        private void llblNotifierViewToggle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            masterSplitContainer.Panel2Collapsed = !masterSplitContainer.Panel2Collapsed;
            UpdateNotifiersLabel();
        }

        private void UpdateNotifiersLabel()
        {
            TreeNode notifierRoot = tvwNotifiers.Nodes[0];
            llblNotifierViewToggle.Text = masterSplitContainer.Panel2Collapsed ? "Show Notifiers" : "Hide Notifiers";
            if (notifierRoot.Nodes.Count > 0)
            {
                StringBuilder notSummary = new StringBuilder();
                foreach (TreeNode child in notifierRoot.Nodes)
                {
                    notSummary.AppendLine(child.Text);
                }
                llblNotifierViewToggle.Text += " (" + notifierRoot.Nodes.Count.ToString() + ")";
                toolTip1.SetToolTip(llblNotifierViewToggle, notSummary.ToString());
            }
        }

        private void tvwNotifiers_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
