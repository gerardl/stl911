using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stl911Domain
{
    public class AppInformation
    {
        public int AppInformationId { get; set; }
        public string Version { get; set; }
        public DateTime LastSyncTime { get; set; }
    }
}
