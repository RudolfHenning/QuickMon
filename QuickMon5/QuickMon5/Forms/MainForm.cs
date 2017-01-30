using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon5
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
        
        private void splitButtonSave_SplitButtonClicked(object sender, EventArgs e)
        {
            saveContextMenuStrip.Show(splitButtonSave, new Point(splitButtonSave.Width, 0));
        }

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

        private void splitButtonOpen_ButtonClicked(object sender, EventArgs e)
        {
            
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
            aboutContextMenuStrip.Show(splitButtonInfo, new Point(splitButtonInfo.Width , 0));
        }
    }
}
