using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public abstract class NotifierViewerBase : FadeSnapForm, INotivierViewer, IChildWindowIdentity
    {
        #region IChildWindowIdentity
        public bool AutoRefreshEnabled { get; set; }
        public string Identifier { get; set; }
        public IParentWindow ParentWindow { get; set; }
        public void DeRegisterChildWindow()
        {
            if (ParentWindow != null)
                ParentWindow.RemoveChildWindow(this);
        }
        public void RefreshDetails()
        {
            if (SelectedNotifier != null)
            {
                RefreshDisplayData();
            }
        }
        public void ShowChildWindow(IParentWindow parentWindow = null)
        {
            if (parentWindow != null)
                ParentWindow = parentWindow;
            if (ParentWindow != null)
                ParentWindow.RegisterChildWindow(this);
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
            RefreshDisplayData();
        }
        #endregion

        public abstract void RefreshDisplayData();
        protected override void OnLoad(EventArgs e)
        {
            SnappingEnabled = true;
            base.OnLoad(e);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //unregister client window and closes all
            DeRegisterChildWindow();
            base.OnFormClosing(e);
        }

        #region INotivierViewer
        public INotifier SelectedNotifier { get; set; }
        #endregion
    }

    public abstract class NotifierNoViewerBase : FadeSnapForm, INotivierViewer, IChildWindowIdentity
    {
        #region INotivierViewer
        public INotifier SelectedNotifier { get; set; } 
        #endregion

        #region IChildWindowIdentity
        public bool AutoRefreshEnabled { get; set; }
        public string Identifier { get; set; }
        public IParentWindow ParentWindow { get; set; }
        public void RefreshDetails()
        {
            //does nothing
        }
        public void DeRegisterChildWindow()
        {
            if (ParentWindow != null)
                ParentWindow.RemoveChildWindow(this);
        }

        public virtual void ShowChildWindow(IParentWindow parentWindow = null)
        {   
            
        }
        #endregion
    }
}
