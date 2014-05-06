using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class PowerShellScriptRunnerShowDetails : MiniDetailView, ICollectorDetailView
    {
        public PowerShellScriptRunnerShowDetails()
        {
            InitializeComponent();
        }

        private void PowerShellScriptRunnerShowDetails_Load(object sender, EventArgs e)
        {
            lvwScripts.AutoResizeColumnEnabled = true;
            ExportButtonVisible = false;
            splitContainer2.Panel1Collapsed = true;
        }

        #region Overrides
        public override void LoadDisplayData()
        {
            if (Collector != null && Collector.AgentConfig != null)
            {
                PowerShellScriptRunnerCollectorConfig sqlQueryConfig = (PowerShellScriptRunnerCollectorConfig)Collector.AgentConfig;
                lvwScripts.Items.Clear();
                foreach (PowerShellScriptRunnerEntry queryInstance in sqlQueryConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(queryInstance.Name);
                    lvi.ImageIndex = 0;
                    lvi.Tag = queryInstance;
                    lvwScripts.Items.Add(lvi);
                }
            }
            base.LoadDisplayData();
        }
        public override void RefreshDisplayData()
        {
            try
            {
                lvwScripts.BeginUpdate();
                Cursor.Current = Cursors.WaitCursor;
                foreach (ListViewItem lvi in lvwScripts.Items)
                {
                    PowerShellScriptRunnerEntry pssrEntry = (PowerShellScriptRunnerEntry)lvi.Tag;
                    string scriptResult = pssrEntry.RunScript();
                    CollectorState currentState = pssrEntry.GetState(scriptResult);
                    if (currentState == CollectorState.Good)
                        lvi.ImageIndex = 1;
                    else if (currentState == CollectorState.Warning)
                        lvi.ImageIndex = 2;
                    else if (currentState == CollectorState.Error)
                        lvi.ImageIndex = 3;
                    else
                        lvi.ImageIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                lvwScripts.EndUpdate();
            }
            ShowScriptDetails();
            base.RefreshDisplayData();
        }

        private void ShowScriptDetails()
        {
            if (lvwScripts.SelectedItems.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sbps = new StringBuilder();
                bool multiples = lvwScripts.SelectedItems.Count > 1;
                Cursor.Current = Cursors.WaitCursor;
                foreach (ListViewItem lvi in lvwScripts.SelectedItems)
                {
                    PowerShellScriptRunnerEntry pssrEntry = (PowerShellScriptRunnerEntry)lvi.Tag;
                    try
                    {
                        sbps.AppendLine(pssrEntry.TestScript);
                        if (multiples)
                        {
                            sb.AppendLine("-----------------------------");
                            sb.AppendLine("Name: " + pssrEntry.Name);
                            sb.AppendLine("-----------------------------");

                            sbps.AppendLine("#----------------------------");
                        }
                        
                        string scriptResult = pssrEntry.RunScript();
                        sb.AppendLine(scriptResult);
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine(ex.Message);
                    }
                    txtPSScript.Text = sbps.ToString();
                    txtPSScriptResults.Text = sb.ToString();
                }
            }
            else
            {
                txtPSScript.Text = "";
                txtPSScriptResults.Text = "";
            }
            Cursor.Current = Cursors.Default;
        }
        #endregion

        private void lvwScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectItemRefreshTimer.Enabled = false;
            selectItemRefreshTimer.Enabled = true;            
        }

        private void selectItemRefreshTimer_Tick(object sender, EventArgs e)
        {
            selectItemRefreshTimer.Enabled = false;
            lvwScripts.Invoke((MethodInvoker)delegate
            {
                ShowScriptDetails();
            });
        }

        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel1Collapsed = !splitContainer2.Panel1Collapsed;
            cmdViewDetails.Text = splitContainer2.Panel1Collapsed ? "uuu" : "ttt";
            splitContainer2.SplitterWidth = 6;
        }

        private void cmdRunScript_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txtPSScriptResults.Text = PowerShellScriptRunnerEntry.RunScript(txtPSScript.Text);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Run script", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
