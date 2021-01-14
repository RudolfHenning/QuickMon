using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using QuickMon;

namespace HenIT.Windows.Controls.Graphing
{
    [Serializable]
    public class GraphSettings
    {
        [XmlElement("SeriesColors")]
        public List<string> SeriesColors { get; set; } 

        [XmlAttribute(AttributeName = "BackgroundColor1")]
        public string BackgroundColor1 { get; set; }

        [XmlAttribute(AttributeName = "BackgroundColor2")]
        public string BackgroundColor2 { get; set; }

        [XmlAttribute(AttributeName = "GridColor")]
        public string GridColor { get; set; }

        [XmlAttribute(AttributeName = "AxisLabelsColor")]
        public string AxisLabelsColor { get; set; }

        [XmlAttribute(AttributeName = "SelectionBarColor")]
        public string SelectionBarColor { get; set; }

        [XmlAttribute(AttributeName = "GraphType")]
        public int GraphType { get; set; }

        [XmlAttribute(AttributeName = "GradientDirection")]
        public int GradientDirection { get; set; }

        [XmlAttribute(AttributeName = "ClosestClickedValueType")]
        public int ClosestClickedValueType { get; set; }

        [XmlAttribute(AttributeName = "ClosestClickedValueColor")]
        public string ClosestClickedValueColor { get; set; }


        public static string ConvertColorToName(System.Drawing.Color col)
        {
            if (col == null)
                return "Black";
            else if (col.IsNamedColor)
                return col.Name;
            else
                return col.ToArgb().ToString();
        }
        public static System.Drawing.Color ConvertColorFromName(string col)
        {
            if (col == null || col.Length == 0)
                return System.Drawing.Color.Black;
            else if (col.IsIntegerTypeNumber())
                return System.Drawing.Color.FromArgb(int.Parse(col));
            else
                return System.Drawing.Color.FromName(col);
        }
    }
}
