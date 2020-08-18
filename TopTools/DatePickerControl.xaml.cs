using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Endless_Development_Project_Studio.TopTools
{
    /// <summary>
    /// DatePickerControl.xaml 的互動邏輯
    /// </summary>
    public partial class DatePickerControl : UserControl
    {
        DispatcherTimer DT = new DispatcherTimer();
        public DatePickerControl()
        {
            InitializeComponent();
            DT.Interval = TimeSpan.FromSeconds(1);
            DT.Tick += DT_Tick;

            this.Loaded += DatePickerControl_Loaded;
        }

        private void DatePickerControl_Loaded(object sender, RoutedEventArgs e)
        {
            DT.Start();
        }

        private void DT_Tick(object sender, EventArgs e)
        {
            TimeButton.Content = DateTime.Now;
        }
    }
}
