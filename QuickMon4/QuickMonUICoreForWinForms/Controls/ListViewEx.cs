using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using QuickMon.Controls;

namespace QuickMon
{
    public class ListViewEx : ListView
    {
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);
        public ListViewEx()
            : base()
        {
            DoubleBuffered = true;
            View = View.Details;
            resizeTimer.Tick +=  resizeTimer_Tick;
        }

        [Description("Use one column to auto resize in detail view")]
        public bool AutoResizeColumnEnabled { get; set; }
        [Description("Column index of auto resize column")]
        public int AutoResizeColumnIndex { get; set; }
        public event MethodInvoker EnterKeyPressed;
        public event MethodInvoker DeleteKeyPressed;
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                if (EnterKeyPressed != null)
                {
                    EnterKeyPressed();
                    e.Handled = true;
                }
            base.OnKeyPress(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (DeleteKeyPressed != null)
                {
                    DeleteKeyPressed();
                    e.Handled = true;
                }
            base.OnKeyDown(e);
        }

        private Timer resizeTimer = new Timer() { Interval = 50, Enabled = false };
        private void resizeTimer_Tick(object sender, EventArgs e)
        {
            resizeTimer.Enabled = false;
            try
            {
                if (AutoResizeColumnEnabled && View == System.Windows.Forms.View.Details &&
                    AutoResizeColumnIndex > -1 && this.Columns.Count > AutoResizeColumnIndex)
                {
                    int columnsWidth = 0;
                    Application.DoEvents();
                    for (int i = 0; i < this.Columns.Count; i++)
                    {
                        if (i != AutoResizeColumnIndex)
                            columnsWidth += this.Columns[i].Width;
                    }
                    this.Columns[AutoResizeColumnIndex].Width = this.ClientSize.Width - columnsWidth - 2;
                }
            }
            catch { }
        }
        protected override void OnResize(EventArgs e)
        {
            resizeTimer.Enabled = false;
            resizeTimer.Enabled = true;
            base.OnResize(e);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (!this.DesignMode && Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
                SetWindowTheme(this.Handle, "explorer", null);
        }

        #region Group collapsings
        private delegate void CallBackSetGroupState(ListViewGroup lstvwgrp, ListViewGroupState state);
        private delegate void CallbackSetGroupString(ListViewGroup lstvwgrp, string value);
        private const int LVM_FIRST = 0x1000;                    // ListView messages
        private const int LVM_SETGROUPINFO = (LVM_FIRST + 147);  // ListView messages Setinfo on Group
        private const int WM_LBUTTONUP = 0x0202;                 // Windows message left button

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message. 
        /// To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function. To post a message to a thread's message queue and return immediately, use the PostMessage or PostThreadMessage function.
        /// </summary>
        /// <param name="hWnd">
        /// [in] Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows. 
        /// Microsoft Windows Vista and later. Message sending is subject to User Interface Privilege Isolation (UIPI). The thread of a process can send messages only to message queues of threads in processes of lesser or equal integrity level.
        /// </param>
        /// <param name="uMsg">[in] Specifies the message to be sent.</param>
        /// <param name="wParam">[in] Specifies additional message-specific information.</param>
        /// <param name="lParam">[in] Type of LVGROUP, Specifies additional message-specific information.</param>
        /// <returns>
        /// Microsoft Windows Vista and later. When a message is blocked by UIPI the last error, retrieved with GetLastError, is set to 5 (access denied).
        /// Applications that need to communicate using HWND_BROADCAST should use the RegisterWindowMessage function to obtain a unique message for inter-application communication.
        /// The system only does marshalling for system messages (those in the range 0 to (WM_USER-1)). To send other messages (those >= WM_USER) to another process, you must do custom marshalling.
        /// If the specified window was created by the calling thread, the window procedure is called immediately as a subroutine. If the specified window was created by a different thread, the system switches to that thread and calls the appropriate window procedure. Messages sent between threads are processed only when the receiving thread executes message retrieval code. The sending thread is blocked until the receiving thread processes the message. However, the sending thread will process incoming nonqueued messages while waiting for its message to be processed. To prevent this, use SendMessageTimeout with SMTO_BLOCK set. For more information on nonqueued messages, see Nonqueued Messages.
        /// Windows 95/98/Me: SendMessageW is supported by the Microsoft Layer for Unicode (MSLU). To use this, you must add certain files to your application, as outlined in Microsoft Layer for Unicode on Windows 95/98/Me Systems.
        /// </returns>
        [DllImport("User32.dll"), Description("Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message. To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function. To post a message to a thread's message queue and return immediately, use the PostMessage or PostThreadMessage function.")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref LVGROUP lParam);

        private static int? GetGroupID(ListViewGroup lstvwgrp)
        {
            int? rtnval = null;
            Type GrpTp = lstvwgrp.GetType();
            if (GrpTp != null)
            {
                PropertyInfo pi = GrpTp.GetProperty("ID", BindingFlags.NonPublic | BindingFlags.Instance);
                if (pi != null)
                {
                    object tmprtnval = pi.GetValue(lstvwgrp, null);
                    if (tmprtnval != null)
                    {
                        rtnval = tmprtnval as int?;
                    }
                }
            }
            return rtnval;
        }
        private static void setGrpState(ListViewGroup lstvwgrp, ListViewGroupState state)
        {
            if (Environment.OSVersion.Version.Major < 6)   //Only Vista and forward allows collaps of ListViewGroups
                return;
            if (lstvwgrp == null || lstvwgrp.ListView == null)
                return;
            if (lstvwgrp.ListView.InvokeRequired)
                lstvwgrp.ListView.Invoke(new CallBackSetGroupState(setGrpState), lstvwgrp, state);
            else
            {
                int? GrpId = GetGroupID(lstvwgrp);
                int gIndex = lstvwgrp.ListView.Groups.IndexOf(lstvwgrp);
                LVGROUP group = new LVGROUP();
                group.CbSize = Marshal.SizeOf(group);
                group.State = state;
                group.Mask = ListViewGroupMask.State;
                if (GrpId != null)
                {
                    group.IGroupId = GrpId.Value;
                    SendMessage(lstvwgrp.ListView.Handle, LVM_SETGROUPINFO, GrpId.Value, ref group);
                    SendMessage(lstvwgrp.ListView.Handle, LVM_SETGROUPINFO, GrpId.Value, ref group);
                }
                else
                {
                    group.IGroupId = gIndex;
                    SendMessage(lstvwgrp.ListView.Handle, LVM_SETGROUPINFO, gIndex, ref group);
                    SendMessage(lstvwgrp.ListView.Handle, LVM_SETGROUPINFO, gIndex, ref group);
                }
                lstvwgrp.ListView.Refresh();
            }
        }
        private static void setGrpFooter(ListViewGroup lstvwgrp, string footer)
        {
            if (Environment.OSVersion.Version.Major < 6)   //Only Vista and forward allows footer on ListViewGroups
                return;
            if (lstvwgrp == null || lstvwgrp.ListView == null)
                return;
            if (lstvwgrp.ListView.InvokeRequired)
                lstvwgrp.ListView.Invoke(new CallbackSetGroupString(setGrpFooter), lstvwgrp, footer);
            else
            {
                int? GrpId = GetGroupID(lstvwgrp);
                int gIndex = lstvwgrp.ListView.Groups.IndexOf(lstvwgrp);
                LVGROUP group = new LVGROUP();
                group.CbSize = Marshal.SizeOf(group);
                group.PszFooter = footer;
                group.Mask = ListViewGroupMask.Footer;
                if (GrpId != null)
                {
                    group.IGroupId = GrpId.Value;
                    SendMessage(lstvwgrp.ListView.Handle, LVM_SETGROUPINFO, GrpId.Value, ref group);
                }
                else
                {
                    group.IGroupId = gIndex;
                    SendMessage(lstvwgrp.ListView.Handle, LVM_SETGROUPINFO, gIndex, ref group);
                }
            }
        }
        public void SetGroupState(ListViewGroup lvg, ListViewGroupState state)
        {
            setGrpState(lvg, state);
        }
        public void SetGroupState(ListViewGroupState state)
        {
            foreach (ListViewGroup lvg in this.Groups)
                setGrpState(lvg, state);
        }
        public void SetGroupFooter(ListViewGroup lvg, string footerText)
        {
            setGrpFooter(lvg, footerText);
        }
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_LBUTTONUP)
                base.DefWndProc(ref m);
            base.WndProc(ref m);
        } 
        #endregion
    }
}
