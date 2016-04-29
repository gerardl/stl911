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

        public IEnumerable<ServiceCall> GetServiceCalls()
        {
            return _IServiceCallRepository.GetServiceCalls();
        }
    }
}
