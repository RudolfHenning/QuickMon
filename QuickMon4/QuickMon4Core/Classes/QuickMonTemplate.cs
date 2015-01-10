using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class QuickMonTemplate
    {
        public TemplateType TemplateType { get; set; }
        public string Name { get; set; }
        public string ForClass { get; set; }
        public string Description { get; set; }
        public string Config { get; set; }

        public static List<QuickMonTemplate> GetAllTemplates()
        {
            List<QuickMonTemplate> list = new List<QuickMonTemplate>();

            return list;
        }
    }
}
