using Endless_Development_Project_Studio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Pro_NCP
{
    public class ChatCollectionsViewModel : BaseViewModel
    {
        public List<ChatItemViewModel> Items { get { return items; } set { if (items != value) items = value; OnPropertyChanged("Items"); } }
        public List<ChatItemViewModel> items;
    }
}
