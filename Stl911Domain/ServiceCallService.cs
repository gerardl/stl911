using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stl911Domain
{
    public class ServiceCallService
    {
        private readonly IServiceCallRepository _IServiceCallRepository;

        public ServiceCallService(IServiceCallRepository iServiceCallRepository)
        {
            _IServiceCallRepository = iServiceCallRepository;
        }

        public void ScrapeServiceCalls()
        {
            _IServiceCallRepository.ScrapeServiceCalls();
        }

        public IEnumerable<ServiceCall> GetServiceCalls()
        {
            return _IServiceCallRepository.GetServiceCalls();
        }

        public IEnumerable<string> GetServiceCallLocations()
        {
            return _IServiceCallRepository.GetServiceCallLocations();
        }
    }
}
