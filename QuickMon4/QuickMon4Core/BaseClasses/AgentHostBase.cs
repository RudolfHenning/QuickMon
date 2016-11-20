using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public abstract class AgentHostBase
    {
        public AgentHostBase()
        {
            ServiceWindows = new ServiceWindows();
            ServiceWindows.CreateFromConfig("<serviceWindows/>");
        }

        #region General properties
        public string Name { get; set; }
        /// <summary>
        /// Any object you wish to link with this instance
        /// </summary>
        public object Tag { get; set; }
        #endregion

        #region Is this agent entry enabled now
        /// <summary>
        /// User/config based setting to disable this agent Entry
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// List of service windows when this agent can operate
        /// </summary>
        public ServiceWindows ServiceWindows { get; set; }
        internal bool InServiceWindow { get; set; }
        public bool IsEnabledNow()
        {
            if (Enabled)
            {
                InServiceWindow = !ServiceWindows.IsInTimeWindow();
                if (!InServiceWindow)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        #endregion

        #region Dynamic Config Variables
        public List<ConfigVariable> ConfigVariables { get; set; }
        #endregion

        #region Categories
        public List<string> Categories { get; set; }
        public string GetCategoriesXML()
        {
            StringBuilder categoriesXml = new StringBuilder();
            if (Categories != null && Categories.Count > 0)
            {
                categoriesXml.AppendLine("<categories>");
                foreach (string category in Categories)
                {
                    categoriesXml.AppendLine(string.Format("<category>{0}</category>", category.EscapeXml()));
                }
                categoriesXml.AppendLine("</categories>");
            }
            else
            {
                categoriesXml.AppendLine("<categories />");
            }
            return categoriesXml.ToString();
        }
        public void CategoriesCreateFromConfig(string config)
        {
            if (config.Length > 0)
            {
                Categories = new List<string>();
                XmlDocument configXml = new XmlDocument();
                configXml.LoadXml(config);
                XmlElement root = configXml.DocumentElement;
                foreach (XmlNode categoryNode in root.SelectNodes("category"))
                {
                    Categories.Add(categoryNode.InnerText.UnEscapeXml());
                }                
            }
        }
        #endregion
    }
}
