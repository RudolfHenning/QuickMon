using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class RSSNotifierConfig
    {
        public string RSSFilePath { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Generator { get; set; }

        public int KeepEntriesDays { get; set; }
        public string LineTitle { get; set; }
        public string LineCategory { get; set; }
        //public string LineComments { get; set; }
        public string LineDescription { get; set; }
    }
}
