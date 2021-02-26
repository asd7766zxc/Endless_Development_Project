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

namespace Endless_Development_Project_Studio.UI
{
    /// <summary>
    /// MartiralTDimesionalUi.xaml 的互動邏輯
    /// </summary>
    public partial class MartiralTDimesionalUi : Page
    {
        public MartiralTDimesionalUi()
        {
            InitializeComponent();
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePoint = Mouse.GetPosition(this);
            var distanceY = (this.Height / 2)+mousePoint.Y;
            var distanceX = (this.Width / 2)+mousePoint.X;


           

            if (distanceX < 0)
            {

            }
            if (distanceY < 0)
            {

            }
            if (distanceX > 0)
            {

            }
            if (distanceY > 0)
            {

            }
        }
    }
}
