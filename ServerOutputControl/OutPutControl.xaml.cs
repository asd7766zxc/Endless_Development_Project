using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Endless_Development_Project_Studio.ServerOutputControl
{
    /// <summary>
    /// OutPutControl.xaml 的互動邏輯
    /// </summary>
    public partial class OutPutControl : UserControl
    {

        DispatcherTimer TickTimer = new DispatcherTimer();
        public OutPutControl()
        {
            InitializeComponent();
            this.Loaded += OutPutControl_Loaded;
             TickTimer.Interval = TimeSpan.FromMilliseconds(200);
             TickTimer.Tick += TickTimer_Tick;

        }
        bool TimerLock = false;
        private void TickTimer_Tick(object sender, EventArgs e)
        {
            TimerLock = true;
            if (itemcount != LogItemListDesignModel.Instance.Items.Count)
            {
                
                itemcount = LogItemListDesignModel.Instance.Items.Count;
                action.Invoke();
            }

        }

        private void OutPutControl_Loaded(object sender, RoutedEventArgs e)
        {
               var border = VisualTreeHelper.GetChild(CustomerGrid, 0) as Decorator;
               if (border != null)
               {
                   var scroll = border.Child as ScrollViewer;
                   if (scroll != null) action = () => scroll.ScrollToVerticalOffset(LogItemListDesignModel.Instance.Items.Count*25);
               }
            TickTimer.Start();
        }
        int itemcount = 0;
        Stopwatch s = new Stopwatch();
        DispatcherTimer ScrollDownTimer = new DispatcherTimer();

        Action action;
        public async Task AddToOutput(string colorType, string timeText, string outputText, string type)
        {
            Dispatcher.Invoke(() => { 
            using (var item = new OutPutItemControlViewModel { OutputText = outputText, TimeText = timeText, TypeColor = colorType, Type = type })
            {
                LogItemListDesignModel.Instance.Items.Add(item);
                //  action.Invoke();
                // CustomerGrid.ScrollIntoView(item);
                /*  if (TimerLock)
                  {
                      // CustomerGrid.ScrollIntoView(item);
                      //action.Invoke();
                      TimerLock = false;
                  }*/
            }
            });
            //Items.Add(new OutPutItemControlViewModel { OutputText = outputText, TimeText = timeText, TypeColor = colorType });
            // });
        }
        private void CustomerGrid_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
           
        }
    }
}
