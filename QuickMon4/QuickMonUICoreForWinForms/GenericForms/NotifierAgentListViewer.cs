using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public partial class NotifierAgentListViewer : Form
    {
        //private class NotifierContainer
        //{
        //    public INotifier Notifier { get; set; }
        //    public WinFormsUINotifierBase AgentUI { get; set; }
        //}
        public NotifierAgentListViewer()
        {
            InitializeComponent();
        }

        public NotifierHost SelectedNotifierHost { get; set; }

        private List<INotivierViewer> agentDetailViews = new List<INotivierViewer>();

        public void RefreshNotifierDetails()
        {
            if (SelectedNotifierHost != null)
            {
                txtName.Text = SelectedNotifierHost.Name;
                Text = "Notifier Agent List Viewer - " + SelectedNotifierHost.Name;

                lvwAgents.Items.Clear();
                foreach(INotifier n in SelectedNotifierHost.NotifierAgents)
                {
                    ListViewItem lvi = new ListViewItem(n.Name);
                    lvi.SubItems.Add(n.AgentClassDisplayName);
                    lvi.Tag = n;
                    try
                    {
                        WinFormsUINotifierBase agentUI = RegisteredAgentUIMapper.GetNotifierUIClass(n);
                        if (agentUI == null)
                        {
                            lvi.ForeColor = SystemColors.GrayText;
                            lvi.ImageIndex = 0;
                            //lvi.Tag = new NotifierContainer() { Notifier = n, AgentUI = null };
                        }
                        else if (!agentUI.HasDetailView)
                        {
                            lvi.ForeColor = SystemColors.GrayText;
                            lvi.ImageIndex = 0;
                            //lvi.Tag = new NotifierContainer() { Notifier = n, AgentUI = agentUI };
                        }
                        else
                        {
                            lvi.ForeColor = SystemColors.ControlText;
                            lvi.ImageIndex = 1;
                            //lvi.Tag = new NotifierContainer() { Notifier = n, AgentUI = agentUI };
                        }
                    }
                    catch
                    {
                        lvi.ForeColor = SystemColors.GrayText;
                        lvi.ImageIndex = 0;
                        //lvi.Tag = new NotifierContainer() { Notifier = n, AgentUI = null };
                    }

                    lvwAgents.Items.Add(lvi);
                }
            }
        }

        private void NotifierAgentListViewer_Load(object sender, EventArgs e)
        {
            lvwAgents.AutoResizeColumnIndex = 1;
            lvwAgents.AutoResizeColumnEnabled = true;
        }

        private void lvwAgents_DoubleClick(object sender, EventArgs e)
        {
            ShowAgentViewer();
        }

        private void ShowAgentViewer()
        {
            if (lvwAgents.SelectedItems.Count == 1 && lvwAgents.SelectedItems[0].Tag is INotifier)
            {
                INotifier currentNotifier = (INotifier)lvwAgents.SelectedItems[0].Tag;
                INotivierViewer currentNotivierViewer = (from v in agentDetailViews
                                                         where v.SelectedNotifier == currentNotifier
                                                         select v).FirstOrDefault();

                if (currentNotivierViewer != null && !currentNotivierViewer.IsViewerStillVisible())
                {
                    agentDetailViews.Remove(currentNotivierViewer);
                    currentNotivierViewer = null;
                }

                if (currentNotivierViewer == null)
                {
                    WinFormsUINotifierBase agentUI = RegisteredAgentUIMapper.GetNotifierUIClass(currentNotifier);
                    if (agentUI != null && agentUI.HasDetailView)
                    {
                        currentNotivierViewer = agentUI.Viewer;
                        currentNotivierViewer.SelectedNotifier = currentNotifier;
                        agentDetailViews.Add(currentNotivierViewer);
                    }                    
                }
                if (currentNotivierViewer != null)
                    currentNotivierViewer.ShowNotifierViewer(); ;
            }
        }

        private void NotifierAgentListViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(INotivierViewer currentNotivierViewer in agentDetailViews)
            {
                try
                {
                    if (currentNotivierViewer.IsViewerStillVisible())
                    {
                        ((Form)currentNotivierViewer).Close();
                    }
                }
                catch { }
            }
            agentDetailViews = null;
        }
    }
}
