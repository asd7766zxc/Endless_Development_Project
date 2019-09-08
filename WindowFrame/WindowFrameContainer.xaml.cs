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

namespace Endless_Development_Project_Studio.WindowFrame
{
    /// <summary>
    /// WindowFrameContainer.xaml 的互動邏輯
    /// </summary>
    public partial class WindowFrameContainer : Page
    {
        UIElement Container;
        public WindowFrameContainer()
        {
            InitializeComponent();
           // Container = uIElement;
        }

        private bool _isMoving;
        private System.Windows.Point? _buttonPosition;
        private double deltaX;
        private double deltaY;
        private TranslateTransform _currentTT;

        private void Page_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMoving) return;

            var mousePoint = Mouse.GetPosition(Container);

            var offsetX = (_currentTT == null ? _buttonPosition.Value.X : _buttonPosition.Value.X - _currentTT.X) + deltaX - mousePoint.X;
            var offsetY = (_currentTT == null ? _buttonPosition.Value.Y : _buttonPosition.Value.Y - _currentTT.Y) + deltaY - mousePoint.Y;

            this.RenderTransform = new TranslateTransform(-offsetX, -offsetY);
        }

        private void Page_MouseUp(object sender, MouseButtonEventArgs e)
        {

            _currentTT = this.RenderTransform as TranslateTransform;
            _isMoving = false;
        }

        private void Page_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (_buttonPosition == null)
                _buttonPosition = this.TransformToAncestor(Container).Transform(new System.Windows.Point(0, 0));
            var mousePosition = Mouse.GetPosition(Container);
            deltaX = mousePosition.X - _buttonPosition.Value.X;
            deltaY = mousePosition.Y - _buttonPosition.Value.Y;
            _isMoving = true;
        }

        private void Page_MouseLeave(object sender, MouseEventArgs e)
        {
            _currentTT = this.RenderTransform as TranslateTransform;
            _isMoving = false;
        }
    }
}
