using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class SQLQueryConfig
    {
        public SQLQueryConfig()
        {
            Queries = new List<QueryInstance>();
        }
        public List<QueryInstance> Queries { get; set; }

        public void ReadConfiguration(XmlDocument config)
        {
            XmlElement root = config.DocumentElement;
            Queries.Clear();
            foreach (XmlElement queryNode in root.SelectNodes("queries/query"))
            {
                QueryInstance queryEntry = new QueryInstance();
                queryEntry.Name = queryNode.ReadXmlElementAttr("name", "");
                queryEntry.SqlServer = queryNode.ReadXmlElementAttr("sqlServer", "");
                queryEntry.Database = queryNode.ReadXmlElementAttr("database", "");
                queryEntry.IntegratedSecurity = bool.Parse(queryNode.ReadXmlElementAttr("integratedSec", "True"));
                queryEntry.UserName = queryNode.ReadXmlElementAttr("userName", "");
                queryEntry.Password = queryNode.ReadXmlElementAttr("password", "");
                queryEntry.CmndTimeOut = int.Parse(queryNode.ReadXmlElementAttr("cmndTimeOut", "60"));

                XmlNode summaryQueryNode = queryNode.SelectSingleNode("summaryQuery");
                queryEntry.UseSPForSummary = bool.Parse(summaryQueryNode.ReadXmlElementAttr("useSP", "False"));
                queryEntry.ReturnValueIsInt = bool.Parse(summaryQueryNode.ReadXmlElementAttr("returnValueIsInt", "True"));
                queryEntry.ReturnValueInverted = bool.Parse(summaryQueryNode.ReadXmlElementAttr("returnValueInverted", "False"));
                queryEntry.WarningValue = summaryQueryNode.ReadXmlElementAttr("warningValue", "1");
                queryEntry.ErrorValue = summaryQueryNode.ReadXmlElementAttr("errorValue", "2");
                queryEntry.SuccessValue = summaryQueryNode.ReadXmlElementAttr("successValue", "[any]");
                queryEntry.UseRowCountAsValue = bool.Parse(summaryQueryNode.ReadXmlElementAttr("useRowCountAsValue", "False"));
                queryEntry.SummaryQuery = summaryQueryNode.InnerText;

                XmlNode detailQueryNode = queryNode.SelectSingleNode("detailQuery");
                queryEntry.UseSPForDetail = bool.Parse(detailQueryNode.ReadXmlElementAttr("useSP", "False"));
                queryEntry.DetailQuery = detailQueryNode.InnerText;
                Queries.Add(queryEntry);
            }
        }
        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.SqlQueryEmptyConfig);
            XmlElement root = config.DocumentElement;
            XmlNode queriesNode = root.SelectSingleNode("queries");
            queriesNode.InnerXml = "";

            foreach (QueryInstance queryEntry in Queries)
            {
                XmlElement queryNode = config.CreateElement("query");
                queryNode.SetAttributeValue("name", queryEntry.Name);
                queryNode.SetAttributeValue("sqlServer", queryEntry.SqlServer);
                queryNode.SetAttributeValue("database", queryEntry.Database);
                queryNode.SetAttributeValue("integratedSec", queryEntry.IntegratedSecurity);
                queryNode.SetAttributeValue("userName", queryEntry.UserName);
                queryNode.SetAttributeValue("password", queryEntry.Password);
                queryNode.SetAttributeValue("cmndTimeOut", queryEntry.CmndTimeOut);

                XmlNode summaryQueryNode = queryNode.AppendElementWithText("summaryQuery", queryEntry.SummaryQuery);
                summaryQueryNode.SetAttributeValue("useSP", queryEntry.UseSPForSummary);
                summaryQueryNode.SetAttributeValue("returnValueIsInt", queryEntry.ReturnValueIsInt);
                summaryQueryNode.SetAttributeValue("returnValueInverted", queryEntry.ReturnValueInverted);
                summaryQueryNode.SetAttributeValue("warningValue", queryEntry.WarningValue);
                summaryQueryNode.SetAttributeValue("errorValue", queryEntry.ErrorValue);
                summaryQueryNode.SetAttributeValue("successValue", queryEntry.SuccessValue);
                summaryQueryNode.SetAttributeValue("useRowCountAsValue", queryEntry.UseRowCountAsValue);
                
                XmlNode detailQueryNode = queryNode.AppendElementWithText("detailQuery", queryEntry.DetailQuery);
                detailQueryNode.SetAttributeValue("useSP", queryEntry.UseSPForDetail);
                queriesNode.AppendChild(queryNode);
            }
            return config.OuterXml;
        }
    }
}
