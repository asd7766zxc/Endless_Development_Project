using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.DataStorage
{
    public class ServerSettingsModel
    {
        public string JarFile { get; set; }

        public string MinRam { get; set; }

        public string MaxRam { get; set; }

        public string Parameter { get; set; }

        public string ChangeDate { get; set; }

        public string Title { get; set; }

        public ulong serverid { get; set; }

        public string StartFolder { get; set; }
    }
}
