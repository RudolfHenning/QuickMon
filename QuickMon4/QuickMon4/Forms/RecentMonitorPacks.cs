using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public class RecentMonitorPacks
    {
        public string SelectedPack { get; private set; }
        public DialogResult ShowDialog()
        {
            Form f = new Form();
            f.SuspendLayout();
            f.Name = "RecentFilesWindow";
            f.Text = "Recently opened QuickMon config files";
            f.Icon = Properties.Resources.folderWLightning1;
            f.BackColor = Color.White;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            f.MaximizeBox = false;
            f.MinimizeBox = false;
            f.MinimumSize = new Size(550, 300);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Size = new System.Drawing.Size(800, 400);
            f.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            f.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            f.KeyPreview = true;
            f.KeyUp += (object mysender, KeyEventArgs ea) =>
            {
                if (ea.KeyCode == Keys.Escape)
                {
                    Form theForm = ((Form)mysender);
                    theForm.Close();
                }
                else if (ea.KeyCode == Keys.Delete)
                {
                    Form theForm = ((Form)mysender);
                    ListBox l = (ListBox)theForm.Controls["lstFiles"];
                    if (l.SelectedIndex > -1)
                    {
                        if (MessageBox.Show("Are you sure you want to remove the selected entry?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Properties.Settings.Default.RecentQMConfigFiles.Remove(l.SelectedItem.ToString());
                            Properties.Settings.Default.Save();
                            l.Items.RemoveAt(l.SelectedIndex);
                        }
                    }
                }
            };

            Button cmdOK = new Button();
            cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            cmdOK.Location = new System.Drawing.Point(620, 330);
            cmdOK.Name = "cmdOK";
            cmdOK.Size = new System.Drawing.Size(75, 23);
            cmdOK.TabIndex = 3;
            cmdOK.Text = "OK";
            cmdOK.UseVisualStyleBackColor = true;
            cmdOK.Enabled = false;
            cmdOK.FlatStyle = FlatStyle.Popup;
            cmdOK.Click += (object mysender, EventArgs ea) =>
            {
                Form theForm = ((Button)mysender).FindForm();
                ListBox l = (ListBox)theForm.Controls["lstFiles"];
                if (l.SelectedIndex > -1)
                {
                    theForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                    theForm.Close();
                }
            };
            Button cmdCancel = new Button();
            cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cmdCancel.Location = new System.Drawing.Point(700, 330);
            cmdCancel.Name = "cmdCancel";
            cmdCancel.Size = new System.Drawing.Size(75, 23);
            cmdCancel.TabIndex = 4;
            cmdCancel.Text = "Cancel";
            cmdCancel.UseVisualStyleBackColor = true;
            cmdCancel.FlatStyle = FlatStyle.Popup;

            f.CancelButton = cmdCancel;

            ListBox lb = new ListBox();
            lb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            lb.Location = new Point(0, 0);
            lb.Size = new System.Drawing.Size(f.ClientSize.Width, 320);
            lb.Name = "lstFiles";
            lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb.BorderStyle = BorderStyle.FixedSingle;
            lb.TabIndex = 0;
            lb.SelectedIndexChanged += (object mysender, EventArgs ea) =>
            {
                ListBox l = (ListBox)mysender;
                Form theForm = l.FindForm();
                Button okb = (Button)theForm.Controls["cmdOK"];
                okb.Enabled = l.SelectedIndex > -1;
            };
            lb.DoubleClick += (object mysender, EventArgs ea) =>
            {
                ListBox l = (ListBox)mysender;
                Form theForm = l.FindForm();
                if (l.SelectedIndex > -1)
                {
                    theForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                    theForm.Close();
                }

            };
            lb.KeyUp += (object mysender, KeyEventArgs ea) =>
            {
                if (ea.KeyCode == Keys.Return)
                {
                    ListBox l = (ListBox)mysender;
                    Form theForm = l.FindForm();
                    if (l.SelectedIndex > -1)
                    {
                        theForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                        theForm.Close();
                    }
                }
            };

            Graphics g = f.CreateGraphics();

            LinkLabel llblResetRecents = new LinkLabel();
            llblResetRecents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            llblResetRecents.Location = new System.Drawing.Point(5, 330);
            llblResetRecents.Size = new System.Drawing.Size(75, 23);
            llblResetRecents.AutoSize = true;
            llblResetRecents.TabIndex = 1;
            llblResetRecents.Name = "llblResetRecents";
            llblResetRecents.Text = "Reset list";
            llblResetRecents.LinkBehavior = LinkBehavior.HoverUnderline;
            llblResetRecents.Click += (object sender, EventArgs ea) => {
                if (MessageBox.Show("Are you sure you want to clear the recent list?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Properties.Settings.Default.RecentQMConfigFiles.Clear();
                    Properties.Settings.Default.Save();
                    lb.Items.Clear();
                }
            };
            LinkLabel llblClearInvalidRecents = new LinkLabel();
            llblClearInvalidRecents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            llblClearInvalidRecents.Location = new System.Drawing.Point((int)g.MeasureString(llblResetRecents.Text, llblResetRecents.Font).Width + 10, 330);
            llblClearInvalidRecents.Size = new System.Drawing.Size(75, 23);
            llblClearInvalidRecents.AutoSize = true;
            llblClearInvalidRecents.TabIndex = 2;
            llblClearInvalidRecents.Name = "llblClearInvalidRecents";
            llblClearInvalidRecents.Text = "Clear invalid items";
            llblClearInvalidRecents.LinkBehavior = LinkBehavior.HoverUnderline;
            llblClearInvalidRecents.Click += (object sender, EventArgs ea) =>
            {
                List<string> invalids = new List<string>();
                foreach (string filePath in Properties.Settings.Default.RecentQMConfigFiles)
                {                    
                    if (!System.IO.File.Exists(filePath))
                    {
                        invalids.Add(filePath);
                    }
                }
                foreach (string invalid in invalids)
                {
                    Properties.Settings.Default.RecentQMConfigFiles.Remove(invalid);
                    lb.Items.Remove(invalid);
                }
            };
            LinkLabel llblImportMPs = new LinkLabel();
            llblImportMPs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            llblImportMPs.Location = new System.Drawing.Point((int)g.MeasureString(llblClearInvalidRecents.Text, llblClearInvalidRecents.Font).Width + llblClearInvalidRecents.Left + 10, 330);
            llblImportMPs.Size = new System.Drawing.Size(75, 23);
            llblImportMPs.AutoSize = true;
            llblImportMPs.TabIndex = 3;
            llblImportMPs.Name = "llblImportMPs";
            llblImportMPs.Text = "Import existing Monitor Packs";
            llblImportMPs.LinkBehavior = LinkBehavior.HoverUnderline;
            llblImportMPs.Click += (object sender, EventArgs ea) =>
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.DefaultExt = "qmp4";
                fd.Filter = "Monitor Pack files|*qmp4";
                fd.Multiselect = true;
                fd.Title = "Import Monitor Packs";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    foreach(var file in fd.FileNames)
                    {
                        if (!Properties.Settings.Default.RecentQMConfigFiles.Contains(file))
                        {
                            Properties.Settings.Default.RecentQMConfigFiles.Add(file);
                            lb.Items.Add(file);
                        }
                    }
                }
            };
            
            int widest = 400;
            foreach (string filePath in (from string s in Properties.Settings.Default.RecentQMConfigFiles
                                         orderby s
                                         select s))
            {
                lb.Items.Add(filePath);
                SizeF sz = g.MeasureString(filePath, lb.Font);
                if (sz.Width > widest)
                    widest = (int)sz.Width;
            }


            f.Controls.Add(lb);
            f.Controls.Add(llblResetRecents);
            f.Controls.Add(llblClearInvalidRecents);
            f.Controls.Add(llblImportMPs);
            f.Controls.Add(cmdOK);
            f.Controls.Add(cmdCancel);

            f.ResumeLayout(false);
            f.PerformLayout();

            if (widest + 50 < Screen.PrimaryScreen.WorkingArea.Width)
            {
                f.Width = widest + 50;
            }

            if (f.ShowDialog() == DialogResult.OK)
            {
                SelectedPack = ((ListBox)f.Controls["lstFiles"]).SelectedItem.ToString();
                return DialogResult.OK;
            }
            else
                return DialogResult.Cancel;
        }
    }
}
