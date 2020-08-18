using Endless_Development_Project_Studio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.FileTransfer
{
    public class TransferItemCollectionsViewModel : BaseViewModel
    {
        public List<TransferItemViewModel> Items { get { return items; } set { if (items != value) items = value; OnPropertyChanged("Items"); } }
        public List<TransferItemViewModel> items;
    }
}
