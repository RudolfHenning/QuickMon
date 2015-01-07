using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Controls
{
    public class PopperContainer : ToolStripDropDown
    {
        private Control m_popedContainer;

        private ToolStripControlHost m_host;

        private bool m_fade = true;

        public PopperContainer(Control popedControl)
        {
            InitializeComponent();

            if (popedControl == null)
                throw new ArgumentNullException("content");

            this.m_popedContainer = popedControl;

            this.m_fade = SystemInformation.IsMenuAnimationEnabled && SystemInformation.IsMenuFadeEnabled;

            this.m_host = new ToolStripControlHost(popedControl);
            m_host.AutoSize = false;//make it take the same room as the poped control

            Padding = Margin = m_host.Padding = m_host.Margin = Padding.Empty;

            popedControl.Location = Point.Empty;

            this.Items.Add(m_host);

            popedControl.Disposed += delegate(object sender, EventArgs e)
            {
                popedControl = null;
                Dispose(true);// this popup container will be disposed immediately after disposion of the contained control
            };
        }

        #region Component Designer generated code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (m_popedContainer != null)
                {
                    System.Windows.Forms.Control _content = m_popedContainer;
                    m_popedContainer = null;
                    _content.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion

        protected override bool ProcessDialogKey(Keys keyData)
        {//prevent alt from closing it and allow alt+menumonic to work
            if ((keyData & Keys.Alt) == Keys.Alt)
                return false;

            return base.ProcessDialogKey(keyData);
        }

        public void Show(Control control)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            Show(control, control.ClientRectangle);
        }

        public void Show(Form f, Point p)
        {
            this.Show(f, new Rectangle(p, new Size(0, 0)));

        }

        private void Show(Control control, Rectangle area)
        {
            if (control == null)
                throw new ArgumentNullException("control");


            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));

            Rectangle screen = Screen.FromControl(control).WorkingArea;

            if (location.X + Size.Width > (screen.Left + screen.Width))
                location.X = (screen.Left + screen.Width) - Size.Width;

            if (location.Y + Size.Height > (screen.Top + screen.Height))
                location.Y -= Size.Height + area.Height;

            location = control.PointToClient(location);

            Show(control, location, ToolStripDropDownDirection.BelowRight);
        }
        private void Show(TreeView tree)
        {
            Point location = Cursor.Position;  //default
            Show(tree, location, ToolStripDropDownDirection.BelowRight);
        }




        private const int frames = 5;
        private const int totalduration = 100;
        private const int frameduration = totalduration / frames;

        protected override void SetVisibleCore(bool visible)
        {
            double opacity = Opacity;
            if (visible && m_fade) Opacity = 0;
            base.SetVisibleCore(visible);
            if (!visible || !m_fade) return;
            for (int i = 1; i <= frames; i++)
            {
                if (i > 1)
                {
                    System.Threading.Thread.Sleep(frameduration);
                }
                Opacity = opacity * (double)i / (double)frames;
            }
            Opacity = opacity;
        }

        protected override void OnOpening(CancelEventArgs e)
        {
            if (m_popedContainer.IsDisposed || m_popedContainer.Disposing)
            {
                e.Cancel = true;
                return;
            }
            base.OnOpening(e);
        }

        protected override void OnOpened(EventArgs e)
        {
            m_popedContainer.Focus();

            base.OnOpened(e);
        }
    }
}
