using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Notifiers
{
    public partial class RSSNotifierEdit : Form, IAgentConfigEntryEditWindow
    {
        public RSSNotifierEdit()
        {
            InitializeComponent();
        }

        public IAgentConfig SelectedEntry { get; set; }
        public QuickMonDialogResult ShowEditEntry()
        {
            LoadEditData();
            return (QuickMonDialogResult)ShowDialog();
        }

        private void LoadEditData()
        {
            RSSNotifierConfig rssSettings;            
            if (SelectedEntry == null)
                SelectedEntry = new RSSNotifierConfig();
            rssSettings = (RSSNotifierConfig)SelectedEntry;

            txtRSSFilePath.Text = rssSettings.RSSFilePath;
            txtTitle.Text = rssSettings.Title;
            txtLink.Text = rssSettings.Link;
            txtLanguage.Text = rssSettings.Language;
            txtGenerator.Text = rssSettings.Generator;
            txtDescription.Text = rssSettings.Description;
            keepDataDaysNumericUpDown.Value = rssSettings.KeepEntriesDays;
            txtLineTitle.Text = rssSettings.LineTitle;
            txtLineCategory.Text = rssSettings.LineCategory;
            txtLineDescription.Text = rssSettings.LineDescription;
            txtLineLink.Text = rssSettings.LineLink;
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            saveFileDialogLogFile.FileName = txtRSSFilePath.Text;
            if (saveFileDialogLogFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtRSSFilePath.Text = saveFileDialogLogFile.FileName;
            }
        }

        private void lblLineDescription_DoubleClick(object sender, EventArgs e)
        {
            txtLineDescription.Text = "<b>Date Time:</b> %DateTime%\r\n" +
                                   "<b>Current state:</b> %CurrentState%\r\n" +
                                   "<b>Collector:</b> %CollectorName%\r\n" +
                                   "<b>Details</b>\r\n" +
                                   "%Details%";
        }

        private void lblCategory_DoubleClick(object sender, EventArgs e)
        {
            txtLineCategory.Text = "%CurrentState%, %CollectorName%";
        }

        private void lblLineTitle_DoubleClick(object sender, EventArgs e)
        {
            txtLineTitle.Text = "%CollectorName% - %AlertLevel%";
        }

        private void CheckOKEnabled()
        {
            cmdOK.Enabled = (txtRSSFilePath.Text.Length > 0) && (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtRSSFilePath.Text)));
        }

        private void txtRSSFilePath_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!txtLineDescription.Text.Contains("%Details%"))
                if (MessageBox.Show("Are you sure you do not want the details displayed in the description?", "Description", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

            RSSNotifierConfig rssSettings;
            rssSettings = (RSSNotifierConfig)SelectedEntry;

            rssSettings.RSSFilePath = txtRSSFilePath.Text;
            rssSettings.Title = txtTitle.Text;
            rssSettings.Link = txtLink.Text;
            rssSettings.Language = txtLanguage.Text;
            rssSettings.Generator = txtGenerator.Text;
            rssSettings.Description = txtDescription.Text;
            rssSettings.KeepEntriesDays = (int)keepDataDaysNumericUpDown.Value;
            rssSettings.LineTitle = txtLineTitle.Text;
            rssSettings.LineCategory = txtLineCategory.Text;
            rssSettings.LineDescription = txtLineDescription.Text;
            rssSettings.LineLink = txtLineLink.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
