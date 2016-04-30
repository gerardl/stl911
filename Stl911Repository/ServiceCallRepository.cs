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
        public void GetServiceCalls()
        {
            try
            {
                using (var context = new ServiceCallContext())
                {
                    var serviceCalls = new List<ServiceCall>();

                    string Url = "http://www.slmpd.org/cfs.aspx";
                    HtmlWeb web = new HtmlWeb();
                    HtmlDocument doc = web.Load(Url);

                    var lastPoliceUpdate = DateTime.Parse(doc.DocumentNode.SelectNodes("//*[@id=\"lblLastUpdate\"]")[0].InnerText.Replace("Last updated: ", "").Replace(" (Central Standard Time)", ""));
                    var lastAppUpdate = context.AppInformation.First().LastSyncTime;
                    if (lastPoliceUpdate > lastAppUpdate)
                    {
                        HtmlNode table = doc.DocumentNode.SelectNodes("//*[@id=\"gvData\"]")[0];
                        foreach (HtmlNode row in table.SelectNodes("tr"))
                        {
                            // Time / id / location / description
                            var rowColumns = row.SelectNodes("td");
                            if (rowColumns.Count != 4) continue;

                            var servCall = new ServiceCall(rowColumns[1].InnerHtml, DateTime.Parse(rowColumns[0].InnerHtml), rowColumns[2].InnerHtml, rowColumns[3].InnerHtml);
                            serviceCalls.Add(servCall);
                        }

                        serviceCalls.ForEach(f =>
                        {
                            var existingCall = context.ServiceCall.Where(w => w.ServiceCallIdentifier == f.ServiceCallIdentifier).SingleOrDefault();
                            if (existingCall == null)
                                context.ServiceCall.Add(f);
                            else
                            {
                                existingCall.CallTime = f.CallTime;
                                existingCall.Description = f.Description;
                                existingCall.LocationRaw = f.LocationRaw;
                                existingCall.LocationFriendly = f.LocationFriendly;
                            }
                        });

                        context.AppInformation.First().LastSyncTime = lastPoliceUpdate;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
