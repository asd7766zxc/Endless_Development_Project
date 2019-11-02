using Endless_Development_Project_Studio.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.Managers
{
    public class DataBaseManager
    {
        public static DataBaseManager Instance
            => new DataBaseManager();
        public ConnectToSQL DataBaseClient
        {
            get
            {
                var client = new ConnectToSQL();
                return client;
            }
            set
            {
                DataBaseClient = value;
            }
        }
    }
}
