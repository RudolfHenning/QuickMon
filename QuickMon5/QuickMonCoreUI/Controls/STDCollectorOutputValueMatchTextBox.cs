using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.Controls
{
    public class STDCollectorOutputValueMatchTextBox : TextBox
    {
        private ContextMenuStrip stdCollectorOutputValueMatchesContextMenuStrip;
        private ToolStripMenuItem insertToolStripMenuItem;
        private ToolStripMenuItem anyToolStripMenuItem;
        private ToolStripMenuItem nullToolStripMenuItem;
        private ToolStripMenuItem betweenXAndYToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.stdCollectorOutputValueMatchesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.betweenXAndYToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stdCollectorOutputValueMatchesContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // stdCollectorOutputValueMatchesContextMenuStrip
            // 
            this.stdCollectorOutputValueMatchesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.toolStripSeparator3,
            this.undoToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator2,
            this.selectAllToolStripMenuItem});
            this.stdCollectorOutputValueMatchesContextMenuStrip.Name = "stdCollectorOutputValueMatchesContextMenuStrip";
            this.stdCollectorOutputValueMatchesContextMenuStrip.Size = new System.Drawing.Size(153, 176);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anyToolStripMenuItem,
            this.nullToolStripMenuItem,
            this.betweenXAndYToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.insertToolStripMenuItem.Text = "Set Value To";
            // 
            // anyToolStripMenuItem
            // 
            this.anyToolStripMenuItem.Name = "anyToolStripMenuItem";
            this.anyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.anyToolStripMenuItem.Text = "[any]";
            // 
            // nullToolStripMenuItem
            // 
            this.nullToolStripMenuItem.Name = "nullToolStripMenuItem";
            this.nullToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.nullToolStripMenuItem.Text = "[null]";
            //
            // betweenXAndYToolStripMenuItem
            //
            this.betweenXAndYToolStripMenuItem.Name = "betweenXAndYToolStripMenuItem";
            this.betweenXAndYToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.betweenXAndYToolStripMenuItem.Text = "[Between|Not Between] X and Y";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            // 
            // STDCollectorOutputValueMatchTextBox
            // 
            this.ContextMenuStrip = this.stdCollectorOutputValueMatchesContextMenuStrip;
            this.stdCollectorOutputValueMatchesContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public STDCollectorOutputValueMatchTextBox()
        {
            if (anyToolStripMenuItem == null)
                InitializeComponent();
            anyToolStripMenuItem.Click += AnyToolStripMenuItem_Click;
            nullToolStripMenuItem.Click += NullToolStripMenuItem_Click;
            betweenXAndYToolStripMenuItem.Click += BetweenXAndYToolStripMenuItem_Click;
            undoToolStripMenuItem.Click += UndoToolStripMenuItem_Click;
            cutToolStripMenuItem.Click += CutToolStripMenuItem_Click;
            copyToolStripMenuItem.Click += CopyToolStripMenuItem_Click;
            pasteToolStripMenuItem.Click += PasteToolStripMenuItem_Click;
            selectAllToolStripMenuItem.Click += SelectAllToolStripMenuItem_Click;
        }


        #region Context Menu events
        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void NullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "[null]";
        }
        private void AnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "[any]";
        } 
        private void BetweenXAndYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "[X] and [Y]";
        }
        #endregion
    }
}
