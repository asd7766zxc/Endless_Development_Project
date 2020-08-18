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

namespace Endless_Development_Project_Studio.DialogSystem
{
    /// <summary>
    /// LoadingDialog.xaml 的互動邏輯
    /// </summary>
    public partial class LoadingDialog : Page
    {
        public LoadingDialog()
        {
            this.Loaded += LoadingDialog_Loaded;
            InitializeComponent();
        }

        private void LoadingDialog_Loaded(object sender, RoutedEventArgs e)
        {
            for (var times = 0; times < 30; times++)
            {
                var hudu = (2 * Math.PI / 360) * 12 * times;
                var x = 100 + Math.Sin(hudu) * 100;
                var y = 100 - Math.Cos(hudu) * 100;
                Border b = new Border();
                b.BorderThickness = new Thickness(0);
                b.BorderBrush = Brushes.White;
                b.Background = Brushes.White;
                b.Height = 10;
                b.Width = 5;

                RotateTransform t = new RotateTransform();
                t.CenterX = 2.5;
                t.CenterY = 5;
                t.Angle = times * (360 / 30);
                b.RenderTransform = t;
                Canvas.SetTop(b, y - 5);
                Canvas.SetLeft(b, x - 2.5);
                M.Children.Add(b);
            }
        }
    }
}
