using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenIT.Windows.Controls.Graphing
{
    public class TimeValue
    {
        public DateTime Time { get; set; }
        public float Value { get; set; }        
    }
    public static class TimeValueGroupBy
    {
        public static List<TimeValue> GroupByMinutes(this List<TimeValue> originalList, int groupByMinutes = 1)
        {
            DateTime rootTime = new DateTime(2000, 1, 1);
            return (from rw in originalList
                    orderby rw.Time
                    group rw by rootTime.AddMinutes(Math.Floor((rw.Time.Subtract(rootTime).TotalMinutes / groupByMinutes)) * groupByMinutes) into g
                    select new TimeValue() { Time = g.Key, Value = g.Average(t => t.Value) }).ToList();
        }
    }
}
