using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.SQL
{
    public class dboReport
    {
        public int id { get; set; }

        public string Address { get; set; }

        public string MailAddress { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Online { get; set; }

        public string fullinfo
        {
            get
            {
                return $"{id} {Address} {MailAddress} {Account} {Password} {Name}";
            }
        }
    }
}
