using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class CollectorMessage
    {
        public CollectorMessage() { }
        public CollectorMessage(string plainText)
        {
            PlainText = plainText;
        }
        public string PlainText { get; set; }
        private string htmlText = "";
        public string HtmlText
        {
            get
            {
                if (htmlText.Length == 0)
                    return PlainText;
                else
                    return htmlText;
            }
            set { htmlText = value; }
        }
        public void AppendCollectorMessage(CollectorMessage appendedOne)
        {
            PlainText += appendedOne.PlainText;
            htmlText += appendedOne.htmlText;
        }
    }
}
