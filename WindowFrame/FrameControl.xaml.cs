using Endless_Development_Project_Studio.Containers;
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
    /// FrameControl.xaml 的互動邏輯
    /// </summary>
    public partial class FrameControl : UserControl
    {
        UIElement Container;
        UIElement _Content;
        string _title;
        public uint ID { get; set; }
        public FrameControl(UIElement Parent,UIElement content,string title)
        {
            InitializeComponent();
            Container = Parent;
            this._Content = content;
            this.Loaded += FrameControl_Loaded;
            ID = uint.Parse(WindowsContainerList.RWindows.Next().ToString());
            WindowsContainerList.Windows.Add(ID,this);
            PageContent.MouseDown += PageContent_MouseDown;
            _title = title;
        }

        private void PageContent_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocusFrame();
        }

        public void SetToDown()
        {
            Dispatcher.Invoke(() =>
            {
                Panel.SetZIndex(this, WindowsContainerList.Windows.Count - 1);
            });
        }
        private void FrameControl_Loaded(object sender, RoutedEventArgs e)
        {
            TitleBarText.Content = _title;
            PageContent.Content = _Content;
        }
        void FocusFrame()
        {
            if (WindowsContainerList.OnTop != 0)
                WindowsContainerList.Windows[WindowsContainerList.OnTop].SetToDown();
            Panel.SetZIndex(this, WindowsContainerList.Windows.Count);
            WindowsContainerList.OnTop = ID;
        }
        private bool _isMoving;
        private System.Windows.Point? _buttonPosition;
        private double deltaX;
        private double deltaY;
        private TranslateTransform _currentTT;
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocusFrame();
            if (_buttonPosition == null) 
                _buttonPosition = this.TransformToAncestor(Container).Transform(new System.Windows.Point(0, 0));
            var mousePosition = Mouse.GetPosition(Container);
            deltaX = mousePosition.X - _buttonPosition.Value.X;
            deltaY = mousePosition.Y - _buttonPosition.Value.Y;
            _isMoving = true;
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            _currentTT = this.RenderTransform as TranslateTransform;
            _isMoving = false;
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMoving) return;

            var mousePoint = Mouse.GetPosition(Container);

            var offsetX = (_currentTT == null ? _buttonPosition.Value.X : _buttonPosition.Value.X - _currentTT.X) + deltaX - mousePoint.X;
            var offsetY = (_currentTT == null ? _buttonPosition.Value.Y : _buttonPosition.Value.Y - _currentTT.Y) + deltaY - mousePoint.Y;

            this.RenderTransform = new TranslateTransform(-offsetX, -offsetY);
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _currentTT = this.RenderTransform as TranslateTransform;
            _isMoving = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            var mContainer = (Grid)Container;
            mContainer.Children.Remove(this);
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Close_MouseDown(object sender, MouseButtonEventArgs e)
        {
        
        }
    }
}
