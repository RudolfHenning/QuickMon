﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Controls
{
    public delegate void TreeNodeMovedDelegate(TreeNode node);
    public delegate void FunctionKeyUpDelegate(int functionKey, KeyEventArgs e);
    public delegate void NoNodeSelectedDelegate();

    public class TreeViewExBase : TreeView
    {
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);
        public TreeViewExBase() : base()
        {
            DoubleBuffered = true;
            //AllowDrop = true;
            DragColor = Color.Aquamarine;
            EnableAutoScrollToSelectedNode = false;
            AutoScrollToSelectedNodeWaitTimeMS = 500;
            autoScrollSelectedNode = new Timer();
            autoScrollSelectedNode.Tick += autoScrollSelectedNode_Tick;
            RootAlwaysExpanded = false;
            ExtraColumnWidth = 100;

            this.DrawMode = TreeViewDrawMode.OwnerDrawText; //.OwnerDrawAll;
            ShowLines = false;
            //FullRowSelect = true;
            ExtraColumnTextAlign = TreeViewExExtraColumnTextAlign.Left;
        }

        private Timer autoScrollSelectedNode;
        public int AutoScrollToSelectedNodeWaitTimeMS { get; set; }
        /// <summary>
        /// Set the color of items underneath the dragged item
        /// </summary>
        [Description("Set the color of items underneath the dragged item")]
        public Color DragColor { get; set; }
        public bool EnableAutoScrollToSelectedNode { get; set; }
        public bool RootAlwaysExpanded { get; set; }
        public bool DisableExpandOnDoubleClick { get; set; }
        public bool DisableCollapseOnDoubleClick { get; set; }
        public bool AllowKeyBoardNodeReorder { get; set; }
        public bool DisableNode0Collapse { get; set; }
        public int ExtraColumnWidth { get; set; }
        public TreeViewExExtraColumnTextAlign ExtraColumnTextAlign { get; set; }
        public bool ShowColumnSeparatorLine { get; set; }
        public bool HighLightWholeNode { get; set; }

        #region Overrides
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (!this.DesignMode && Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
                SetWindowTheme(this.Handle, "explorer", null);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                if (EnterKeyPressed != null)
                {
                    EnterKeyPressed(this, e);
                    e.Handled = true;
                }
            base.OnKeyPress(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            dblClick = false;
            if (e.KeyCode == Keys.Enter)
            {
                if (EnterKeyDown != null)
                {
                    EnterKeyDown(this, e);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (DeleteKeyPressed != null)
                {
                    DeleteKeyPressed();
                    e.Handled = true;
                }
            }
            else
                base.OnKeyDown(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.SelectedNode = this.GetNodeAt(e.X, e.Y);
                if (this.SelectedNode == null)
                    NoNodeSelected?.Invoke();
            }
            dblClick = e.Button == MouseButtons.Left && e.Clicks == 2;
            base.OnMouseDown(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Up)
            {
                MoveNodeUpInTree();
            }
            else if (e.Control && e.KeyCode == Keys.Down)
            {
                MoveNodeDownInTree();
            }
            else if (e.Control && e.KeyCode == Keys.Left)
            {
                MoveNodeLeftInTree();
            }
            else if (e.Control && e.KeyCode == Keys.Right)
            {
                MoveNodeRightInTree();
            }
            else if ((e.Shift && e.KeyCode == Keys.F10) || e.KeyCode == Keys.Apps)
            {
                if (ContextMenuShowUp != null)
                    ContextMenuShowUp();
            }
            else if (e.KeyCode == Keys.F1)
            {
                if (FunctionKeyUp != null)
                    FunctionKeyUp(1, e);
            }
            else if (e.KeyCode == Keys.F2)
            {
                if (FunctionKeyUp != null)
                    FunctionKeyUp(2, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                if (FunctionKeyUp != null)
                    FunctionKeyUp(3, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                if (FunctionKeyUp != null)
                    FunctionKeyUp(4, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                if (FunctionKeyUp != null)
                    FunctionKeyUp(5, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                if (FunctionKeyUp != null)
                    FunctionKeyUp(6, e);
            }
            else if (e.KeyCode == Keys.F7)
            {
                if (FunctionKeyUp != null)
                    FunctionKeyUp(7, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                if (FunctionKeyUp != null)
                    FunctionKeyUp(8, e);
            }
            else if (e.KeyCode == Keys.F9)
            {
                if (FunctionKeyUp != null)
                    FunctionKeyUp(9, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                if (FunctionKeyUp != null)
                    FunctionKeyUp(10, e);
            }
            base.OnKeyUp(e);
        }
        protected override void OnBeforeCollapse(TreeViewCancelEventArgs e)
        {
            if (e.Node != null && this.Nodes.Count > 0 && e.Node == this.Nodes[0] && DisableNode0Collapse)
            {
                e.Cancel = DisableNode0Collapse;
            }
            else if (DisableCollapseOnDoubleClick && e.Action == TreeViewAction.Collapse)
            {
                e.Cancel = dblClick;
            }
            base.OnBeforeCollapse(e);
        }
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            if (EnableAutoScrollToSelectedNode)
            {
                autoScrollSelectedNode.Interval = AutoScrollToSelectedNodeWaitTimeMS;
                autoScrollSelectedNode.Enabled = false;
                autoScrollSelectedNode.Enabled = true;

            }
            base.OnAfterSelect(e);
        }
        private bool dblClick = false;
        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            if (DisableExpandOnDoubleClick && e.Action == TreeViewAction.Expand)
                e.Cancel = dblClick;
            base.OnBeforeExpand(e);
        }
        #endregion

        #region Added Events
        [Description("Enter key was pressed")]
        public event KeyPressEventHandler EnterKeyPressed;
        public event KeyEventHandler EnterKeyDown;
        [Description("Del[ete] key was pressed")]
        public event MethodInvoker DeleteKeyPressed;
        [Description("A Tree Node was moved (either by keyboard or drag & drop event)")]
        public event TreeNodeMovedDelegate TreeNodeMoved;
        private void RaiseTreeNodeMoved(TreeNode node)
        {
            if (node != null && TreeNodeMoved != null)
            {
                TreeNodeMoved(node);
            }
        }
        public event FunctionKeyUpDelegate FunctionKeyUp;
        public event MethodInvoker ContextMenuShowUp;
        public event NoNodeSelectedDelegate NoNodeSelected;
        #endregion

        /// <summary>
        /// Allow user defined code to indicate if a Tree Node move would be allowed.
        /// </summary>
        /// <param name="selectedNode">The Node that needs to be moved</param>
        /// <param name="targetNode">The Node that the selectedNode will be moved under (as child)</param>
        /// <returns></returns>
        public virtual bool AllowNodeMove(TreeNode selectedNode, TreeNode targetNode)
        {
            if (selectedNode == null || targetNode == null)
                return false;
            else
                return (selectedNode.TreeView == targetNode.TreeView);
        }

        #region Keyboard moving nodes
        private void MoveNodeUpInTree()
        {
            TreeNode currentNode = this.SelectedNode;
            if (AllowKeyBoardNodeReorder && currentNode != null)
            {
                TreeNodeCollection nodes;
                if (currentNode.Parent == null)
                    nodes = Nodes;
                else
                    nodes = currentNode.Parent.Nodes;

                int currentIndex = currentNode.Index;
                if (currentIndex > 0 && currentNode != nodes[0])
                {
                    nodes.Remove(currentNode);
                    nodes.Insert(currentIndex - 1, currentNode);
                    this.SelectedNode = currentNode;
                    RaiseTreeNodeMoved(currentNode);
                    currentNode.EnsureVisible();
                }
            }
        }
        private void MoveNodeDownInTree()
        {
            TreeNode currentNode = this.SelectedNode;
            if (AllowKeyBoardNodeReorder && currentNode != null)
            {
                TreeNodeCollection nodes;
                if (currentNode.Parent == null)
                    nodes = Nodes;
                else
                    nodes = currentNode.Parent.Nodes;

                int currentIndex = currentNode.Index;
                if (currentIndex < nodes.Count - 1)
                {
                    nodes.Remove(currentNode);
                    nodes.Insert(currentIndex + 1, currentNode);
                    this.SelectedNode = currentNode;
                    RaiseTreeNodeMoved(currentNode);
                    currentNode.EnsureVisible();
                }
            }
        }
        private void MoveNodeLeftInTree()
        {
            TreeNode currentNode = this.SelectedNode;
            if (AllowKeyBoardNodeReorder && currentNode != null && currentNode.Parent != null)
            {
                TreeNode parentNode = currentNode.Parent;
                int parentIndex = parentNode.Index;
                TreeNode parentParentNode = parentNode.Parent;
                parentNode.Nodes.Remove(currentNode);
                if (parentParentNode == null) //parent is top node
                {
                    this.Nodes.Insert(parentIndex + 1, currentNode);
                }
                else
                {                    
                    parentParentNode.Nodes.Insert(parentIndex + 1, currentNode);
                }
                this.SelectedNode = currentNode;
                RaiseTreeNodeMoved(currentNode);
                currentNode.EnsureVisible();
            }
        }
        private void MoveNodeRightInTree()
        {
            TreeNode currentNode = this.SelectedNode;
            if (AllowKeyBoardNodeReorder && currentNode != null)
            {
                TreeNodeCollection nodes;
                if (currentNode.Parent == null)
                    nodes = Nodes;
                else
                    nodes = currentNode.Parent.Nodes;

                int currentIndex = currentNode.Index;
                if (currentIndex > 0)
                {
                    if (currentNode.PrevNode != null)
                    {
                        TreeNode preSibling = currentNode.PrevNode;
                        if (AllowNodeMove(currentNode, preSibling))
                        {
                            nodes.Remove(currentNode);
                            preSibling.Nodes.Add(currentNode);
                            this.SelectedNode = currentNode;
                            RaiseTreeNodeMoved(currentNode);
                            currentNode.EnsureVisible();
                        }
                    }
                }
            }
        }
        #endregion

        #region Dragging and dropping
        private TreeNode dragNode = null;
        private void ClearBackground(TreeNodeCollection nodes = null)
        {
            if (nodes == null)
                nodes = this.Nodes;
            foreach (TreeNode node in nodes)
            {
                //if (!node.Equals(this.Nodes[0]))
                node.BackColor = Color.White;
                ClearBackground(node.Nodes);
            }
        }
        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            dragNode = (TreeNode)e.Item;
            if (AllowDrop && this.Nodes.Count > 0 && dragNode != this.Nodes[0])
                DoDragDrop(e.Item, DragDropEffects.Move);
            base.OnItemDrag(e);
        }
        protected override void OnDragLeave(EventArgs e)
        {
            ClearBackground();
            base.OnDragLeave(e);
        }
        protected override void OnDragOver(DragEventArgs drgevent)
        {
            if (AllowDrop && (drgevent.Data.GetDataPresent("System.Windows.Forms.TreeNode", true) || drgevent.Data.GetDataPresent("QuickMon.TreeNodeEx", true)))
            {
                Point pt = this.PointToClient(new Point(drgevent.X, drgevent.Y));
                TreeNode targetNode = this.GetNodeAt(pt);

                if (targetNode != null)
                {
                    if (targetNode.PrevVisibleNode != null)
                    {
                        if (!targetNode.PrevVisibleNode.Equals(this.Nodes[0]))
                            targetNode.PrevVisibleNode.BackColor = Color.White;
                    }
                    if (targetNode.NextVisibleNode != null)
                    {
                        if (!targetNode.NextVisibleNode.Equals(this.Nodes[0]))
                            targetNode.NextVisibleNode.BackColor = Color.White;
                    }
                    targetNode.BackColor = DragColor;
                }
                else
                    ClearBackground();

                //Select the node currently under the cursor
                if (AllowNodeMove(dragNode, targetNode) || targetNode == null)
                {
                    drgevent.Effect = DragDropEffects.Move;
                    return;
                }


            }
            drgevent.Effect = DragDropEffects.None;
            base.OnDragOver(drgevent);
        }
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            if (AllowDrop && (drgevent.Data.GetDataPresent("System.Windows.Forms.TreeNode", true) || drgevent.Data.GetDataPresent("QuickMon.TreeNodeEx", true)))
            {
                Point pt = this.PointToClient(new Point(drgevent.X, drgevent.Y));
                TreeNode targetNode = this.GetNodeAt(pt);
                if (dragNode != targetNode && ( AllowNodeMove(dragNode, targetNode) || (dragNode != null && targetNode == null)))
                {
                    TreeNode oldParent = dragNode.Parent;
                    if (oldParent == null && targetNode != null) //for completenes sake
                    {
                        //do nothing
                        this.Nodes.Remove(dragNode);
                        int index = targetNode.Index;
                        targetNode.Nodes.Insert(index - 1, dragNode);
                    }
                    else if (oldParent == null && targetNode == null)
                    {
                        this.Nodes.Remove(dragNode);
                        this.Nodes.Add(dragNode);
                    }
                    else if (targetNode == null)
                    {
                        oldParent.Nodes.Remove(dragNode);
                        this.Nodes.Add(dragNode);
                    }
                    else if (dragNode == targetNode) //dropped on itself
                    {
                        //do nothing
                    }
                    else if (dragNode != targetNode)
                    {
                        oldParent.Nodes.Remove(dragNode);
                        int index = targetNode.Index;
                        targetNode.Nodes.Insert(index - 1, dragNode);
                    }
                    else if (oldParent.LastNode != dragNode) //append to parent
                    {
                        oldParent.Nodes.Remove(dragNode);
                        oldParent.Nodes.Add(dragNode);
                    }
                    else if (oldParent.Parent == null) // oldParent.Parent.Text == "Monitor Pack Agent Instances")
                    {
                        //do nothing
                    }
                    else //append to parent's parent
                    {
                        oldParent.Nodes.Remove(dragNode);
                        oldParent.Parent.Nodes.Add(dragNode);
                    }
                    this.SelectedNode = dragNode;

                    RaiseTreeNodeMoved(dragNode);
                }
            }
            ClearBackground();
            base.OnDragDrop(drgevent);
        }
        #endregion

        private void autoScrollSelectedNode_Tick(object sender, EventArgs e)
        {
            autoScrollSelectedNode.Enabled = false;
            this.Invoke((MethodInvoker)delegate
            {
                if (this.SelectedNode != null)
                    this.SelectedNode.EnsureVisible();
            });
        }

        #region Advanced Checkboxes
        public bool CheckBoxEnhancements { get; set; }
        private bool isBusyWithAdvancedCheckboxesChanges = false;
        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            if (CheckBoxEnhancements)
            {
                if (!isBusyWithAdvancedCheckboxesChanges)
                {
                    isBusyWithAdvancedCheckboxesChanges = true;
                    try
                    {
                        TreeNode currentNode = e.Node;
                        if (currentNode.Nodes.Count > 0)
                        {
                            SetChildNodeCheckBoxes(currentNode);
                        }
                        CheckParentForAllChildChecks(currentNode);
                    }
                    catch { }

                    isBusyWithAdvancedCheckboxesChanges = false;
                }
            }
            base.OnAfterCheck(e);
        }

        private void CheckParentForAllChildChecks(TreeNode currentNode)
        {
            TreeNode parentNode = currentNode.Parent;
            if (parentNode != null)
            {
                int childrenWithDifferentCheck = (from TreeNode t in parentNode.Nodes
                                                  where t.Checked != parentNode.Checked
                                                  select t).Count();
                if (parentNode.Nodes.Count == childrenWithDifferentCheck)
                {
                    parentNode.Checked = !parentNode.Checked;
                    CheckParentForAllChildChecks(parentNode);
                }

                //bool allChildrenCheckedDifferent = true;
                //foreach (TreeNode child in parentNode.Nodes)
                //{
                //    if (child.Checked == parentNode.Checked)
                //    {
                //        allChildrenCheckedDifferent = false;
                //        break;
                //    }
                //}
                //if (allChildrenCheckedDifferent)
                //{
                //    parentNode.Checked = !parentNode.Checked;
                //}
            }
        }
        private void SetChildNodeCheckBoxes(TreeNode currentNode)
        {
            bool checkedState = currentNode.Checked;
            foreach (TreeNode childNode in currentNode.Nodes)
            {
                childNode.Checked = checkedState;
                if (childNode.Nodes.Count > 0)
                {
                    SetChildNodeCheckBoxes(childNode);
                }
            }
        }
        #endregion

        #region OnDrawNode 
        // example http://stackoverflow.com/questions/8787876/correct-rendering-of-overridden-treeview
        // More http://stackoverflow.com/questions/11500917/cannot-set-icon-for-node-of-treeview
        // http://stackoverflow.com/questions/9136910/treeview-custom-drawnode-net-3-5-windows-forms
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            //base.OnDrawNode(e);

            //SolidBrush selectedTreeBrush = new SolidBrush(Color.FromArgb(255, 205, 232, 255));// .LightSkyBlue);

            //Pen selectedColorPen = new Pen(Color.FromArgb(255, 23, 23, 23));
            Font drawingFont = e.Node.NodeFont;
            if (drawingFont == null)
                drawingFont = this.Font;

            SizeF drawsize = e.Graphics.MeasureString(e.Node.Text, drawingFont);
            int yDiff = (int)((1 + e.Bounds.Height - drawsize.Height) / 2);
            int xDiff = (int)((1 + e.Bounds.Width - drawsize.Width) / 2);
            Rectangle newBounds = new Rectangle(e.Bounds.X, e.Bounds.Y + yDiff, (int) Math.Ceiling(drawsize.Width), e.Bounds.Height - yDiff);
            string extraDisplayValue = "";
            int lineEnd = this.DisplayRectangle.X + this.DisplayRectangle.Width;// - 1;

            if (e.Node is TreeNodeEx)
            {
                TreeNodeEx currentNode = (TreeNodeEx)e.Node;
                extraDisplayValue = currentNode.DisplayValue;
            }
            Rectangle backGroundRec = new Rectangle(e.Bounds.X, e.Bounds.Y, lineEnd - e.Bounds.X, e.Bounds.Height);
            if (backGroundRec.Height == 0)
                backGroundRec.Height = 1;
            if (backGroundRec.Width == 0)
                backGroundRec.Width = 1;
            Brush backgroundColor;
            if (e.Node != e.Node.TreeView.SelectedNode)
            {
                backgroundColor = new SolidBrush(this.BackColor);
            }
            else
            {
                backgroundColor = new System.Drawing.Drawing2D.LinearGradientBrush(backGroundRec, Color.FromArgb(255, 205, 232, 255), Color.FromArgb(255, 235, 252, 255), 0f);
            }
            if (HighLightWholeNode)
                e.Graphics.FillRectangle(backgroundColor, backGroundRec);
            else
                e.Graphics.FillRectangle(backgroundColor, e.Bounds);

            e.Graphics.DrawString(e.Node.Text, drawingFont, new SolidBrush(this.ForeColor), newBounds);
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(this.ForeColor)), newBounds);

            if (extraDisplayValue != null && extraDisplayValue.Length > 0)
            {
                SizeF extraDisplayValueSize = e.Graphics.MeasureString(extraDisplayValue + " ", drawingFont);

                if (ExtraColumnTextAlign == TreeViewExExtraColumnTextAlign.Left)
                    extraDisplayValueSize.Width = ExtraColumnWidth;

                if (extraDisplayValueSize.Width >= ExtraColumnWidth - 5)
                    extraDisplayValueSize.Width = ExtraColumnWidth - 5;
                e.Graphics.FillRectangle(backgroundColor, new RectangleF(lineEnd - ExtraColumnWidth, e.Bounds.Y, ExtraColumnWidth, e.Bounds.Height));

                Rectangle extraDisplayValueRec = new Rectangle(lineEnd - (int)extraDisplayValueSize.Width, e.Bounds.Y + yDiff, lineEnd, e.Bounds.Height - yDiff);
                e.Graphics.DrawString(extraDisplayValue, drawingFont, new SolidBrush(this.ForeColor), extraDisplayValueRec);
            }

            if (ShowColumnSeparatorLine)
            {
                Pen columnSeparator = new Pen(Color.FromArgb(255, 195, 222, 245));
                e.Graphics.DrawLine(columnSeparator, lineEnd - ExtraColumnWidth, e.Bounds.Y, lineEnd - ExtraColumnWidth, e.Bounds.Bottom);
            }

            if (backgroundColor != null)
                backgroundColor.Dispose();
        }

        #endregion

        protected override void OnResize(EventArgs e)
        {
            Refresh();
            base.OnResize(e);
        }
    }

    public enum TreeViewExExtraColumnTextAlign
    {
        Left,
        Right
    }
}
