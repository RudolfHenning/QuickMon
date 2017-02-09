using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Controls
{
    public class ComboItem
    {
        public ComboItem() { }

        public ComboItem(string text, object value)
        {
            Text = text;
            Value = value;
        }
        public string Text { get; set; }
        public object Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
