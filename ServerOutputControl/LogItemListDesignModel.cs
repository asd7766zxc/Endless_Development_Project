using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Endless_Development_Project_Studio.ServerOutputControl
{
    public class LogItemListDesignModel : BaseViewModel
    {
        public static LogItemListDesignModel Instance
            = new LogItemListDesignModel();
       
        public BindingList<OutPutItemControlViewModel> Items { get { return items; } set { items = value; /* OnPropertyChanged("Items"); */ } }
        public BindingList<OutPutItemControlViewModel> items = new BindingList<OutPutItemControlViewModel>();
        public double TopOffset { get { return ItemContainerMargin.Top; } set { topOffset = value; itemContainerMargin.Top = topOffset; OnPropertyChanged("ItemContainerMargin"); } }
        public double topOffset { get; set; }
        public Thickness ItemContainerMargin { get { return itemContainerMargin; } set { itemContainerMargin = value; OnPropertyChanged("ItemContainerMargin"); } }
        public Thickness itemContainerMargin = new Thickness();
        public LogItemListDesignModel()
        {
           
        }
    
    }
}
