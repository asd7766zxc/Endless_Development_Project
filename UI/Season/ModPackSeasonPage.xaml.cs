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

namespace Endless_Development_Project_Studio
{
    /// <summary>
    /// ModPackSeasonPage.xaml 的互動邏輯
    /// </summary>
    public partial class ModPackSeasonPage : Page
    {
        DispatcherTimer Dt = new DispatcherTimer();
        public ModPackSeasonPage()
        {
            InitializeComponent();
            this.Loaded += ModPackSeasonPage_Loaded;
            Dt.Interval = TimeSpan.FromSeconds(1/120);
            Dt.Tick += Dt_Tick;
        }
        public const int distance = 1;
        byte R = 255;
        byte G = 0;
        byte B = 0;
        State t = State.IG;
        int tcount = 0;
        int Range = 3;
   
        private void Dt_Tick(object sender, EventArgs e)
        {

            ColorCycle();
            Dispatcher.Invoke(() =>
            {
                if (colorRange <= 0)
                {
                    colorRange = Range;
                    if (tcount < MultiText.Inlines.Count - 1)
                        tcount++;
                    else
                        tcount = 0;
                }
                colorRange--;
         if(tcount > 0)
                    MultiText.Inlines.ElementAt(tcount-1).Foreground = new SolidColorBrush(new Color { R = R, G = G, B = B, A = 255 });
                ColorCycle();
                MultiText.Inlines.ElementAt(tcount).Foreground = new SolidColorBrush(new Color { R = R, G = G, B = B, A = 255 });
               

            });
        }
        public void ColorCycle()
        {
            if (R == 255 && G == 0 && B == 0)
            {
                t = State.IG;
            }
            else if (R == 255 && G == 255 && B == 0)
            {
                t = State.DR;
            }
            else if (R == 0 && G == 255 && B == 0)
            {
                t = State.IB;
            }
            else if (R == 0 && G == 255 && B == 255)
            {
                t = State.DG;
            }
            else if (R == 0 && G == 0 && B == 255)
            {
                t = State.IR;
            }
            else if (R == 255 && G == 0 && B == 255)
            {
                t = State.DB;
            }
            switch (t)
            {
                case State.IR:
                    R += distance;
                    break;
                case State.IG:
                    G += distance;
                    break;
                case State.IB:
                    B += distance;
                    break;
                case State.DR:
                    R -= distance;
                    break;
                case State.DG:
                    G -= distance;
                    break;
                case State.DB:
                    B -= distance;
                    break;
            }
        }

        public enum State
        {
            IR,
            IG,
            IB,
            DR,
            DB,
            DG,

        }
        int colorRange = 0;
        private void ModPackSeasonPage_Loaded(object sender, RoutedEventArgs e)
        {
            colorRange = Range;
            Dt.Start();
        }
    }
}
