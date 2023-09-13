using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenIT.Windows.Controls.Graphing
{
    [Serializable]
    public class GraphSeries
    {
        public GraphSeries() 
        { 
            Enabled = true;
            Values = new List<TimeValue>();
        }
        public GraphSeries(string name) : this()
        {
            Name = name;
            LineWidth = 2;
        }
        public GraphSeries(string name, Color lineColor) : this(name)
        {
            LineColor = lineColor;
        }

        public string Name { get; set; }
        public List<TimeValue> Values { get; set; }
        public Color LineColor { get; set; }
        public int LineWidth { get; set; }
        public bool Enabled { get; set; } = true;
        public bool Selected { get; set; } = false;
        public string ValueUnit { get; set; } = "";

        #region Legend details
        public string CurrentSeriesLabelText { get; set; }
        public Point CurrentSeriesLabelLocation { get; set; }
        public SizeF CurrentSeriesLabelSize { get; set; }
        #endregion

        public GraphSeries Clone()
        {
            GraphSeries newSeries = new GraphSeries();
            newSeries.Name = Name;
            newSeries.LineColor = LineColor;
            newSeries.LineWidth = LineWidth;
            newSeries.Enabled = Enabled;
            if (Values != null)
            {
                newSeries.Values = new List<TimeValue>();
                foreach (var val in Values)
                    newSeries.Values.Add(new TimeValue() { Time = val.Time, Value = val.Value });
            }
            return newSeries;
        }
    }
}
