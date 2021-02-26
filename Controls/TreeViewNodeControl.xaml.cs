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


namespace Endless_Development_Project_Studio.Controls
{
    /// <summary>
    /// TreeViewNodeControl.xaml 的互動邏輯
    /// </summary>
    public partial class TreeViewNodeControl : UserControl 
    {
        public void AddNode(TreeViewNodeControl node)
        {
           
            node.ParentID = this.id;
            node.ChangeValue("PID:" + node.ParentID + "\n ID:" + node.id);
            if (collection == null)
                collection = new List<TreeViewNodeControl>();

            if (!TreeViewGlobal.ParentChildPair.ContainsKey(this.id.ToString()))
            {
                node.ParentID = this.id;
                TreeViewGlobal.ParentChildPair.Add(this.id.ToString(), new List<string> { node.id.ToString() });
            }
            else
            {
                TreeViewGlobal.ParentChildPair[this.id.ToString()].Add(node.id.ToString());
            }
            collection.Add(node);
            this.Container.Dispatcher.Invoke(() => {

                (Container as Grid).Children.Add(node);
            });
        }
        public delegate void MoveEventHandler();
        public event MoveEventHandler MoveEvent;
        public List<TreeViewNodeControl> collection { get; set; }
        private object Value { get; set; }
        public int id = TreeViewGlobal.GlobalRandom.Next();
        public int ParentID;
        UIElement Container;
        UIElement _Content;
        string _title;
        public uint ID { get; set; }
        public double ParentX { get; set; }
        public double ParentY { get; set; }
        public TreeViewNodeControl(UIElement Parent/*,/* UIElement content,*/ /*string title*/)
        {
            this.Width = 50;
            this.Height = 50; 
            InitializeComponent();
            Container = Parent;
            ValueDisplay.Content = ParentID;
            this.Loaded += TreeViewNodeControl_Loaded;
            // this._Content = content;


            //   _title = title;
        }
       
        private void TreeViewNodeControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.RenderTransform = new TranslateTransform();
            if (_buttonPosition == null)
                _buttonPosition = this.TransformToAncestor(Container).Transform(new System.Windows.Point(0, 0));

            Point CahePoint = new Point();
            CahePoint.Y = this.TransformToAncestor(Container).Transform(new System.Windows.Point(0, 0)).Y + 25;
            CahePoint.X = this.TransformToAncestor(Container).Transform(new System.Windows.Point(0, 0)).X + 25;
            if (!TreeViewGlobal.LocationCollection.ContainsKey(this.id.ToString()))
            {
                TreeViewGlobal.LocationCollection.Add(this.id.ToString(), CahePoint);
            }
            else
            {
                TreeViewGlobal.LocationCollection[this.id.ToString()] = CahePoint;
            }
            try
            {
                if (TreeViewGlobal.LocationCollection.ContainsKey(this.ParentID.ToString()))
                {
                    TreeViewGlobal.Update(this.ParentID, this.id, TreeViewGlobal.LocationCollection[this.ParentID.ToString()], CahePoint);
                }
                 if (TreeViewGlobal.LocationCollection.ContainsKey(this.id.ToString()))
                {
                    foreach (var i in TreeViewGlobal.ParentChildPair[this.id.ToString()])
                    {
                      
                            TreeViewGlobal.Update(this.id, int.Parse(i), CahePoint, TreeViewGlobal.LocationCollection[i]);
                        
                    }
                }
            }
            catch { }

        }

        public void ChangeValue(object value)
        {
            Dispatcher.Invoke(() => {

                Value = value;

                ValueDisplay.Content = value;

            });
        }

        private bool _isMoving;
        private System.Windows.Point? _buttonPosition;
        private double deltaX;
        private double deltaY;
        private TranslateTransform _currentTT;
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
    
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
        bool isBinding = false;
        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
        
            if (!_isMoving) return;

            var mousePoint = Mouse.GetPosition(Container);

            var offsetX = (_currentTT == null ? _buttonPosition.Value.X : _buttonPosition.Value.X - _currentTT.X) + deltaX - mousePoint.X;
            var offsetY = (_currentTT == null ? _buttonPosition.Value.Y : _buttonPosition.Value.Y - _currentTT.Y) + deltaY - mousePoint.Y;

            this.RenderTransform = new TranslateTransform(-offsetX, -offsetY);

            Point CahePoint = new Point();
            CahePoint.Y = this.TransformToAncestor(Container).Transform(new System.Windows.Point(0, 0)).Y+25;
            CahePoint.X = this.TransformToAncestor(Container).Transform(new System.Windows.Point(0, 0)).X+25;
            if (!TreeViewGlobal.LocationCollection.ContainsKey(this.id.ToString()))
            {
                TreeViewGlobal.LocationCollection.Add(this.id.ToString(), CahePoint);
            }
            else
            {
                TreeViewGlobal.LocationCollection[this.id.ToString()] = CahePoint;
            }
            try
            {
                if (TreeViewGlobal.LocationCollection.ContainsKey(this.ParentID.ToString()))
                {
                   
                    TreeViewGlobal.Update(this.ParentID,this.id,TreeViewGlobal.LocationCollection[this.ParentID.ToString()], CahePoint);
                }
                if (TreeViewGlobal.LocationCollection.ContainsKey(this.id.ToString()))
                {
                    if(TreeViewGlobal.ParentChildPair.ContainsKey(this.id.ToString()))
                    foreach (var i in TreeViewGlobal.ParentChildPair[this.id.ToString()])
                    {
                          if(TreeViewGlobal.LocationCollection.ContainsKey(i))
                            TreeViewGlobal.Update(this.id,int.Parse(i), CahePoint, TreeViewGlobal.LocationCollection[i]);
                        
                    }
                }
            }
            catch { }
            
          //  MoveEvent?.Invoke();

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
        Line ML;
        public void Binding(UIElement BindingParent,double TX,double TY)
        {
          
            if (!isBinding)
            {
                isBinding = true;
                Container.Dispatcher.Invoke(() =>
                {

                    Line line = new Line();
                    line.Stroke = Brushes.Black;
                    line.X1 = (BindingParent.RenderTransform as TranslateTransform).X;
                    line.X2 = TX;
                    line.Y2 = TY;
                    line.Y1 = (BindingParent.RenderTransform as TranslateTransform).Y;
                    line.StrokeThickness = 4;
                    var bgh = Container as Grid;
                    ML = line;
                   
                    bgh.Children.Add(ML);
                });
            }
         


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var node = new TreeViewNodeControl(Container);
     
            AddNode(node);
        }
    }
}
