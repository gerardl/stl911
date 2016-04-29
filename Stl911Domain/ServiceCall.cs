using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stl911Domain
{
    public class ServiceCall
    {
        public int ServiceCallId { get; set; }
        public string ServiceIdentifier { get; set; }
        public DateTime CallTime { get; set; }
        public string LocationRaw { get; set; }
        public string Description { get; set; }

        public ServiceCall() { }

        public ServiceCall(string identifier, DateTime callTime, string location, string description)
        {
            ServiceIdentifier = identifier;
            CallTime = callTime;
            LocationRaw = location;
            Description = description;
        }
    }
}
