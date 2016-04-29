using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stl911Domain;
using HtmlAgilityPack;

namespace Stl911Repository
{
    public class ServiceCallRepository : IServiceCallRepository
    {
        public IEnumerable<ServiceCall> GetServiceCalls()
        {
            try
            {
                var serviceCalls = new List<ServiceCall>();

                string Url = "http://www.slmpd.org/cfs.aspx";
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(Url);

                HtmlNode table = doc.DocumentNode.SelectNodes("//*[@id=\"gvData\"]")[0];
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    // Time / id / location / description
                    var rowColumns = row.SelectNodes("td");
                    if (rowColumns.Count != 4) continue;

                    var servCall = new ServiceCall(rowColumns[1].InnerHtml, DateTime.Parse(rowColumns[0].InnerHtml), rowColumns[2].InnerHtml, rowColumns[3].InnerHtml);
                    serviceCalls.Add(servCall);
                }

                return serviceCalls;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
