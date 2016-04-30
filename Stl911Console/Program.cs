using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stl911Console
{
    class Program
    {
        private static Stl911Repository.ServiceCallRepository _IServiceCallRepository;

        static Stl911Repository.ServiceCallRepository GetServiceCallRepository()
        {
            if (_IServiceCallRepository == null)
                _IServiceCallRepository = new Stl911Repository.ServiceCallRepository();
            return _IServiceCallRepository;
        }

        static void Main(string[] args)
        {
            do
            {
                ScrapeCalls();
                System.Threading.Thread.Sleep(300000);
            } while (true);
        }

        static void ScrapeCalls()
        {
            try
            {
                Stl911Domain.ServiceCallService service = new Stl911Domain.ServiceCallService(GetServiceCallRepository());
                service.ScrapeServiceCalls();
                Console.WriteLine("*********** Scraped Calls Successfully **************");
            }
            catch (Exception e)
            {
                Console.WriteLine("*********** Scraping Failed! **************");
                Console.WriteLine("Exception: " + e.Message);
            }
            
        }
    }
}
