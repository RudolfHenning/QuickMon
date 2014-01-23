using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace QuickMon
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
            f.Icon = Properties.Resources._319;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            f.MaximizeBox = false;
            f.MinimizeBox = false;
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
            cmdOK.TabIndex = 1;
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
            cmdCancel.TabIndex = 2;
            cmdCancel.Text = "Cancel";
            cmdCancel.UseVisualStyleBackColor = true;
            cmdCancel.FlatStyle = FlatStyle.Popup;

            f.CancelButton = cmdCancel;

            ListBox lb = new ListBox();
            lb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            lb.Location = new Point(0, 0);
            lb.Size = new System.Drawing.Size(f.ClientSize.Width, 320);
            lb.Name = "lstFiles";
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
            foreach (string filePath in (from string s in Properties.Settings.Default.RecentQMConfigFiles
                                         orderby s
                                         select s))
            {
                lb.Items.Add(filePath);
            }
            f.Controls.Add(lb);
            f.Controls.Add(cmdOK);
            f.Controls.Add(cmdCancel);

            f.ResumeLayout(false);
            f.PerformLayout();

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