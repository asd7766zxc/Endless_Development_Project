using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.DataStorage
{
    public class ServerSettingsModel
    {
        public string servername { get; set; }

        public ulong serverid { get; set; }

        public string parameter { get; set; }

        public int maxmemory { get; set; }

        public int minmemory { get; set; }

        public string StartFolder { get; set; }
    }
}
