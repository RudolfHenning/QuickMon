using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class GraphColorSettings : Form
    {
        public GraphColorSettings()
        {
            InitializeComponent();
        }

        public void InitializeGraphSettings()
        {
            GraphSettings = new HenIT.Windows.Controls.Graphing.GraphSettings();
            GraphSettings.SeriesColors = new List<string>();
        }

        #region Properties
        public List<string> DefaultSeriesColorNames { get; set; } = new List<string>();
        public HenIT.Windows.Controls.Graphing.GraphSettings GraphSettings { get; set; } = new HenIT.Windows.Controls.Graphing.GraphSettings(); 
        #endregion

        #region Form events
        private void GraphColorSettings_Load(object sender, EventArgs e)
        {
            LoadDefaultColors();
            LoadControls();
        }
        #endregion

        #region Private methods
        private void LoadDefaultColors()
        {
            if (DefaultSeriesColorNames == null || DefaultSeriesColorNames.Count == 0)
                DefaultSeriesColorNames = new List<string>();
            {
                DefaultSeriesColorNames.Add(Color.Blue.Name);
                DefaultSeriesColorNames.Add(Color.Red.Name);
                DefaultSeriesColorNames.Add(Color.Teal.Name);
                DefaultSeriesColorNames.Add(Color.DarkOrange.Name);
                DefaultSeriesColorNames.Add(Color.BlueViolet.Name);
                DefaultSeriesColorNames.Add(Color.Green.Name);
                DefaultSeriesColorNames.Add(Color.DarkGoldenrod.Name);
                DefaultSeriesColorNames.Add(Color.Aqua.Name);
                DefaultSeriesColorNames.Add(Color.Yellow.Name);
                DefaultSeriesColorNames.Add(Color.LightBlue.Name);
                DefaultSeriesColorNames.Add(Color.LightGreen.Name);
            }
        }
        private void LoadControls()
        {
            optGraphTypeStandard.Checked = GraphSettings.GraphType == 0;
            optGraphTypeLogarithmic.Checked = GraphSettings.GraphType != 0;

            List<ListViewItem> lvis = new List<ListViewItem>();
            lvwSeriesColors.Items.Clear();
            int seriesNo = 1;
            foreach (string colorName in GraphSettings.SeriesColors) // Properties.Settings.Default.GraphLineColors)
            {
                lvis.Add(CreateLVI($"Series {seriesNo}", colorName));
                seriesNo++;
            }
            lvwSeriesColors.Items.AddRange(lvis.ToArray());

            lvwGraphComponentColors.Items.Clear();
            lvwGraphComponentColors.Items.Add(CreateLVI("Background color 1", GraphSettings.BackgroundColor1));
            lvwGraphComponentColors.Items.Add(CreateLVI("Background color 2", GraphSettings.BackgroundColor2));
            lvwGraphComponentColors.Items.Add(CreateLVI("Grid color", GraphSettings.GridColor));
            lvwGraphComponentColors.Items.Add(CreateLVI("Axis labels color", GraphSettings.AxisLabelsColor));
            lvwGraphComponentColors.Items.Add(CreateLVI("Selection bar color", GraphSettings.SelectionBarColor));

            optBackgroundGradientDirectionHorizontal.Checked = GraphSettings.GradientDirection == 0;
            optBackgroundGradientDirectionVertical.Checked = GraphSettings.GradientDirection == 1;
            optBackgroundGradientDirectionBackwardDiagonal.Checked = GraphSettings.GradientDirection == 2;
            optBackgroundGradientDirectionForwardDiagonal.Checked = GraphSettings.GradientDirection == 3;

            optClosestClickedValueColorSameAsSeries.Checked = GraphSettings.ClosestClickedValueType == 0;
            optClosestClickedValueColorInvertedColor.Checked = GraphSettings.ClosestClickedValueType == 1;
            optClosestClickedValueColorCustomColor.Checked = GraphSettings.ClosestClickedValueType == 2;
            lblClosestClickedValueCustomColors.BackColor = HenIT.Windows.Controls.Graphing.GraphSettings.ConvertColorFromName(GraphSettings.ClosestClickedValueColor);

            chkHeaderVisible.Checked = GraphSettings.HeaderVisible;
            chkLegendVisible.Checked = GraphSettings.FooterVisible;
            chkHorisontalGridLinesVisible.Checked = GraphSettings.HorisontalGridLinesVisible;
            chkVerticalGridLinesVisible.Checked = GraphSettings.VerticalGridLinesVisible;
            chkSelectionBarVisible.Checked = GraphSettings.SelectionBarVisible;
            chkHighlighClickedValueVisible.Checked = GraphSettings.HighlightClickedSeriesVisible;
            chkEnableFillAreaBelowSeries.Checked = GraphSettings.EnableFillAreaBelowSeries;
            optGraphFillAreaBelowSeriesAlpha48.Checked = true; //default
            optGraphFillAreaBelowSeriesAlpha16.Checked = GraphSettings.FillAreaBelowSeriesAlpha == 16;
            optGraphFillAreaBelowSeriesAlpha32.Checked = GraphSettings.FillAreaBelowSeriesAlpha == 32;
            optGraphFillAreaBelowSeriesAlpha48.Checked = GraphSettings.FillAreaBelowSeriesAlpha == 48;
            optGraphFillAreaBelowSeriesAlpha64.Checked = GraphSettings.FillAreaBelowSeriesAlpha == 64;
            optGraphFillAreaBelowSeriesAlpha128.Checked = GraphSettings.FillAreaBelowSeriesAlpha == 128;
            optGraphFillAreaBelowSeriesAlpha192.Checked = GraphSettings.FillAreaBelowSeriesAlpha == 192;
        }
        private ListViewItem CreateLVI(string name, string colorName)
        {
            ListViewItem lvi = new ListViewItem(name);
            lvi.UseItemStyleForSubItems = false;
            ListViewItem.ListViewSubItem sub = new ListViewItem.ListViewSubItem();
            Color itemColor = HenIT.Windows.Controls.Graphing.GraphSettings.ConvertColorFromName(colorName);
            sub.Text = "     ";
            sub.ForeColor = itemColor;
            sub.BackColor = itemColor;
            lvi.SubItems.Add(sub);
            lvi.Tag = colorName;
            return lvi;
        }
        private void SetSeriesNames()
        {
            for (int i = 0; i < lvwSeriesColors.Items.Count; i++)
            {
                ListViewItem lvi = lvwSeriesColors.Items[i];
                lvi.Text = $"Series {i + 1}";
            }
        }
        private void SetButtonEnabled()
        {
            cmdChange.Enabled = lvwSeriesColors.SelectedItems.Count == 1;
            cmdChange2.Enabled = lvwGraphComponentColors.SelectedItems.Count == 1;
            cmdRemove.Enabled = lvwSeriesColors.SelectedItems.Count > 0;
            cmdMoveUp.Enabled = lvwSeriesColors.SelectedItems.Count == 1 && lvwSeriesColors.SelectedItems[0].Index > 0;
            cmdMoveDown.Enabled = lvwSeriesColors.SelectedItems.Count == 1 && lvwSeriesColors.SelectedItems[0].Index < lvwSeriesColors.Items.Count - 1;
            cmdOKSelect.Enabled = lvwSeriesColors.Items.Count > 0;

        }
        private bool SaveSettings()
        {
            bool success = true;

            GraphSettings.GraphType = optGraphTypeStandard.Checked ?  0 : 1;

            GraphSettings.SeriesColors = new List<string>();
            foreach (ListViewItem lvi in lvwSeriesColors.Items)
            {
                GraphSettings.SeriesColors.Add(lvi.Tag.ToString());
            }
            GraphSettings.BackgroundColor1 = lvwGraphComponentColors.Items[0].Tag.ToString();
            GraphSettings.BackgroundColor2 = lvwGraphComponentColors.Items[1].Tag.ToString();
            GraphSettings.GridColor = lvwGraphComponentColors.Items[2].Tag.ToString();
            GraphSettings.AxisLabelsColor = lvwGraphComponentColors.Items[3].Tag.ToString();
            GraphSettings.SelectionBarColor = lvwGraphComponentColors.Items[4].Tag.ToString();

            GraphSettings.GradientDirection = optBackgroundGradientDirectionHorizontal.Checked ? 0 : optBackgroundGradientDirectionVertical.Checked ? 1 : optBackgroundGradientDirectionBackwardDiagonal.Checked ? 2 : 3;
            GraphSettings.ClosestClickedValueType = optClosestClickedValueColorSameAsSeries.Checked ? 0 : optClosestClickedValueColorInvertedColor.Checked ? 1 : 2;
            GraphSettings.ClosestClickedValueColor = HenIT.Windows.Controls.Graphing.GraphSettings.ConvertColorToName(lblClosestClickedValueCustomColors.BackColor);

            GraphSettings.HeaderVisible = chkHeaderVisible.Checked;
            GraphSettings.FooterVisible = chkLegendVisible.Checked;
            GraphSettings.HorisontalGridLinesVisible = chkHorisontalGridLinesVisible.Checked;
            GraphSettings.VerticalGridLinesVisible = chkVerticalGridLinesVisible.Checked;
            GraphSettings.SelectionBarVisible = chkSelectionBarVisible.Checked;
            GraphSettings.HighlightClickedSeriesVisible = chkHighlighClickedValueVisible.Checked;
            GraphSettings.EnableFillAreaBelowSeries = chkEnableFillAreaBelowSeries.Checked;
            GraphSettings.FillAreaBelowSeriesAlpha = optGraphFillAreaBelowSeriesAlpha16.Checked ? 16 :
                optGraphFillAreaBelowSeriesAlpha32.Checked ? 32 :
                optGraphFillAreaBelowSeriesAlpha48.Checked ? 48 :
                optGraphFillAreaBelowSeriesAlpha64.Checked ? 64 :
                optGraphFillAreaBelowSeriesAlpha128.Checked ? 128 : 192;


            return success;
        }
        #endregion

        #region ListView events
        private void lvwSeriesColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonEnabled();
        }
        private void lvwGraphComponentColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonEnabled();
        }
        #endregion

        #region Button events
        private void cmdChange_Click(object sender, EventArgs e)
        {
            if (lvwSeriesColors.SelectedItems.Count == 1)
            {
                ListViewItem lvi = lvwSeriesColors.SelectedItems[0];
                string colorName = lvi.Tag.ToString();
                Color lineColor = lvi.SubItems[1].BackColor;
                colorDialog1.Color = lineColor;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        if (colorDialog1.Color.R == 0 && colorDialog1.Color.B == 0 && colorDialog1.Color.B == 0)
                            colorName = "Black";
                        else
                            colorName = HenIT.Windows.Controls.Graphing.GraphSettings.ConvertColorToName(colorDialog1.Color);
                        lvi.SubItems[1].ForeColor = colorDialog1.Color;
                        lvi.SubItems[1].BackColor = colorDialog1.Color;
                    }
                    catch
                    {
                        lvi.SubItems[1].ForeColor = lineColor;
                        lvi.SubItems[1].BackColor = lineColor;
                    }
                    lvi.Tag = colorName;
                }
            }
        }
        private void cmdChange2_Click(object sender, EventArgs e)
        {
            if (lvwGraphComponentColors.SelectedItems.Count == 1)
            {
                ListViewItem lvi = lvwGraphComponentColors.SelectedItems[0];
                string colorName = lvi.Tag.ToString();
                Color lineColor = lvi.SubItems[1].BackColor;
                colorDialog1.Color = lineColor;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (colorDialog1.Color.R == 0 && colorDialog1.Color.B == 0 && colorDialog1.Color.B == 0)
                            colorName = "Black";
                        else
                            colorName = HenIT.Windows.Controls.Graphing.GraphSettings.ConvertColorToName(colorDialog1.Color);
                        lvi.SubItems[1].ForeColor = colorDialog1.Color;
                        lvi.SubItems[1].BackColor = colorDialog1.Color;
                    }
                    catch
                    {
                        lvi.SubItems[1].ForeColor = lineColor;
                        lvi.SubItems[1].BackColor = lineColor;
                    }
                    lvi.Tag = colorName;
                }
            }
        }
        private void cmdMoveUp_Click(object sender, EventArgs e)
        {
            if (lvwSeriesColors.SelectedItems.Count == 1 && lvwSeriesColors.SelectedItems[0].Index > 0)
            {
                ListViewItem lvi = lvwSeriesColors.SelectedItems[0]; //select current item
                int currentIndex = lvi.Index;
                lvwSeriesColors.Items.Remove(lvi);
                lvwSeriesColors.Items.Insert(currentIndex - 1, lvi);
                lvi.Selected = true;
                SetSeriesNames();
            }
        }
        private void cmdMoveDown_Click(object sender, EventArgs e)
        {
            if (lvwSeriesColors.SelectedItems.Count == 1 && lvwSeriesColors.SelectedItems[0].Index < lvwSeriesColors.Items.Count - 1)
            {
                ListViewItem lvi = lvwSeriesColors.SelectedItems[0]; //select current item
                int currentIndex = lvi.Index;
                lvwSeriesColors.Items.Remove(lvi);
                lvwSeriesColors.Items.Insert(currentIndex + 1, lvi);
                lvi.Selected = true;
                SetSeriesNames();
            }
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                string colorName = "";
                int newItemNumber = lvwSeriesColors.Items.Count + 1;
                try
                {
                    colorName = HenIT.Windows.Controls.Graphing.GraphSettings.ConvertColorToName(colorDialog1.Color);
                }
                catch
                {

                }

                ListViewItem lvi = new ListViewItem($"Series {newItemNumber}");
                lvi.UseItemStyleForSubItems = false;
                ListViewItem.ListViewSubItem sub = new ListViewItem.ListViewSubItem();
                sub.Text = "     ";
                sub.ForeColor = colorDialog1.Color;
                sub.BackColor = colorDialog1.Color;
                lvi.SubItems.Add(sub);
                lvi.Tag = colorName;
                lvwSeriesColors.Items.Add(lvi);
                SetButtonEnabled();
            }
        }
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lvwSeriesColors.SelectedItems.Count > 0 && lvwSeriesColors.SelectedItems.Count != lvwSeriesColors.Items.Count)
            {
                if (MessageBox.Show("Are you sure you want to remove the selected item(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwSeriesColors.SelectedItems)
                    {
                        lvwSeriesColors.Items.Remove(lvi);
                    }
                    SetSeriesNames();
                    SetButtonEnabled();
                }
            }
        }
        private void cmdResetSeriesColors_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset all colors to defaults?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                GraphSettings.SeriesColors = new List<string>();
                foreach (string colorName in DefaultSeriesColorNames)
                {
                    GraphSettings.SeriesColors.Add(colorName);
                }
                LoadControls();
            }
        }
        private void cmdSwapBackgroundColors_Click(object sender, EventArgs e)
        {
            ListViewItem lvi1 = lvwGraphComponentColors.Items[0];
            ListViewItem lvi2 = lvwGraphComponentColors.Items[1];
            Color backgroundColor1 = lvi2.SubItems[1].BackColor;
            string backgroundColorName1 = lvi2.Tag.ToString();
            Color backgroundColor2 = lvi1.SubItems[1].BackColor;
            string backgroundColorName2 = lvi1.Tag.ToString();
            lvi1.SubItems[1].BackColor = backgroundColor1;
            lvi1.SubItems[1].ForeColor = backgroundColor1;
            lvi1.Tag = backgroundColorName1;
            lvi2.SubItems[1].BackColor = backgroundColor2;
            lvi2.SubItems[1].ForeColor = backgroundColor2;
            lvi2.Tag = backgroundColorName2;
        }

        private void cmdExportSeriesColors_Click(object sender, EventArgs e)
        {
            if (SaveSettings())
            {
                try
                {
                    string exportXMLContent = Serializer.SerializeXML(GraphSettings);
                    SaveFileDialog fd = new SaveFileDialog();
                    fd.DefaultExt = "xml";
                    fd.Title = "Specify export file path";
                    fd.Filter = "xml files|*.xml";
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(fd.FileName, exportXMLContent, Encoding.UTF8);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting setings\r\nDetails: {ex.ToString()}", "Export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void cmdImportSeriesColors_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.DefaultExt = "xml";
                fd.Title = "Specify import file path";
                fd.Filter = "xml files|*.xml";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    string importXMLContent  = System.IO.File.ReadAllText(fd.FileName,Encoding.UTF8);
                    HenIT.Windows.Controls.Graphing.GraphSettings importedSettings = (HenIT.Windows.Controls.Graphing.GraphSettings)Serializer.DeserializeXML(importXMLContent, typeof(HenIT.Windows.Controls.Graphing.GraphSettings));

                    GraphSettings = importedSettings;
                    LoadControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing setings\r\nDetails: {ex.ToString()}", "Import", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdOKSelect_Click(object sender, EventArgs e)
        {
            SetButtonEnabled();
            if (cmdOKSelect.Enabled && SaveSettings())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion

        private void lblClosestClickedValueCustomColors_DoubleClick(object sender, EventArgs e)
        {
            colorDialog1.Color = lblClosestClickedValueCustomColors.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lblClosestClickedValueCustomColors.BackColor = colorDialog1.Color;
            }
        }
    }
}
