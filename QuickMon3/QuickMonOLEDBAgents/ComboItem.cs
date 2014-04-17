using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenIT.Utils
{
    internal class ComboItem
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return DisplayName;
        }
    }
}
