using Endless_Development_Project_Studio;
using Endless_Development_Project_Studio.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Pro_NCP
{
    public class ChatItemViewModel : BaseViewModel
    {
        public string AvatarUrl { get; set; }

        public string Name { get; set; }

        public string message { get; set; }

        public int id { get; set; }

        public string Date { get; set; }

        public string user { get; set; }

        public int userid { get; set; }

        public int _short { get; set; }

        public bool Modify { get; set; }

        public string Address { get; set; }

    }
}
