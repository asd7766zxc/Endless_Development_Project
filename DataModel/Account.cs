using Endless_Development_Project_Studio.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.DataModel
{
    public class Account
    {
        public event LoginDataHandler LoginDataEvent;

        public string UserName { get; set; }

        public string ID { get; set; }

        public string UserID { get; set; }

        public string Permission { get; set; }

        public bool AccountReady { get; set; }

        public string account { get; set; }

        public string password { get; set; }

        public dboReport Complex { get; set; }
    }
}
