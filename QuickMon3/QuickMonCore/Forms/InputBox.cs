using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
            Prompt = "Specify text";
            Title = "Input box";
            SelectedValue = "";
        }

        public string FullTextSearchCaption
        {
            get { return chkFullText.Text; }
            set { chkFullText.Text = value; }
        }
        public bool FullTextSearch
        {
            get { return chkFullText.Checked; }
            set { chkFullText.Checked = value; }
        }
        public string Prompt { get; set; }
        public string Title { get; set; }
        public string SelectedValue { get; set; }

        public DialogResult ShowInputBox()
        {
            Text = Title;
            lblPromptMessage.Text = Prompt;
            txtValue.Text = SelectedValue;
            chkFullText.Text = FullTextSearchCaption;
            chkFullText.Checked = FullTextSearch;
            if (ShowDialog() == DialogResult.OK)
            {
                FullTextSearch = chkFullText.Checked;
                SelectedValue = txtValue.Text;
                return DialogResult.OK;
            }
            else
            {
                return DialogResult.Cancel;
            }
        }

        public static string Show(string prompt, string title, string defaultValue, bool enablefullTextSearch = false, bool fullTextSearch = false, string fullTextSearchCaption = "Full text search")
        {
            InputBox inputBox = new InputBox();
            inputBox.Text = title;
            inputBox.lblPromptMessage.Text = prompt;
            inputBox.txtValue.Text = defaultValue;
            inputBox.chkFullText.Visible = enablefullTextSearch;
            inputBox.chkFullText.Text = fullTextSearchCaption;
            inputBox.chkFullText.Checked = fullTextSearch;

            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                return inputBox.txtValue.Text;
            }
            else
            {
                return "";
            }
        }

        private void InputBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {

        }
    }
}