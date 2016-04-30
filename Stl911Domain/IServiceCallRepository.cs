using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stl911Domain
{
    public interface IServiceCallRepository
    {
        void ScrapeServiceCalls();
        IEnumerable<ServiceCall> GetServiceCalls();
    }
}
