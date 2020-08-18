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

namespace Endless_Development_Project_Studio.Controls
{
    /// <summary>
    /// TopCoverLoadingControl.xaml 的互動邏輯
    /// </summary>
    public partial class TopCoverLoadingControl : UserControl
    {
        DispatcherTimer frameTimer;
        public TopCoverLoadingControl()
        {
            frameTimer = new DispatcherTimer();
            frameTimer.Interval = TimeSpan.FromSeconds(1.0/240.0);
            frameTimer.Tick += FrameTimer_Tick;
            InitializeComponent();
        }

        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            frameTimer.Start();
        }
    }
}
