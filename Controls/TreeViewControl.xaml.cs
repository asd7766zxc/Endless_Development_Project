using System;
using System.Collections.Concurrent;
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
    /// TreeViewControl.xaml 的互動邏輯
    /// </summary>
    public partial class TreeViewControl : UserControl
    {
        public TreeViewControl()
        {
            InitializeComponent();
            this.Loaded += TreeViewControl_Loaded;
        }

        Dictionary<int, List<TreeViewNodeControl>> ComplexCollections = new Dictionary<int, List<TreeViewNodeControl>>();
        Line lineR = new Line();
        private void TreeViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer DT = new DispatcherTimer();
            DT.Interval = TimeSpan.FromSeconds(1);
            DT.Tick += DT_Tick;
         
            lineR.Stroke = Brushes.Black;
            lineR.X1 = 10;
            lineR.X2 = 100;
            lineR.Y2 = 10;
            lineR.Y1 = 100;
            lineR.StrokeThickness = 4;
            DT.Start();
            lineR.Name = "TestSub";
            Collecstion.TryAdd(lineR.Name, lineR);
            GR.Children.Add(lineR);

            bool hasnode = false;

            var t = new TreeViewNodeControl(GR);
            t.AddNode(new TreeViewNodeControl(GR));
            t.ChangeValue("ID:" + t.id);
            GR.Children.Add(t);
            t.collection.FirstOrDefault().AddNode(new TreeViewNodeControl(GR));
           
            t.MoveEvent += T_MoveEvent;
            TreeViewNodeControl gg;
            gg = t;
            T:
          
          
            foreach (var d in gg.collection)
            {
                hasnode = false;
                d.MoveEvent += T_MoveEvent;
                if (d.collection != null)
                {
                    hasnode = true;
                    gg = d;
                }
                var control = d;
                if (control.ParentID != 0)
                {
                    if (!ComplexCollections.ContainsKey(control.ParentID))
                        ComplexCollections.Add(control.ParentID, new List<TreeViewNodeControl> { control });
                    else
                        ComplexCollections[control.ParentID].Add(control);
                    control.ChangeValue("PID:" + control.ParentID + "\n ID:" + control.id);
                }
            }
            if (hasnode)
            {

                goto T;
            }
            else
            {
                goto F;
            }
            F:
            UpdateLine();
            TreeViewGlobal.MoveEvent += TreeViewGlobal_MoveEvent;


        


        }

        private void DT_Tick(object sender, EventArgs e)
        {
            Collecstion["TestSub"].X1 += 10;
            Collecstion["TestSub"].X2 += 10;
            Collecstion["TestSub"].Y2 += 10;
            Collecstion["TestSub"].Y1 += 10;
        }

        public void BeingDraw()
        {
            Dispatcher.Invoke(() => {


            });
        }
        ConcurrentDictionary<string, Line> Collecstion = new ConcurrentDictionary<string, Line>();
        private void TreeViewGlobal_MoveEvent(int ida , int idb ,Point point, Point point2)
        {
          
           
                if (!Collecstion.ContainsKey(ida + "_" + idb))
                {
                    Line line = new Line();
                    line.Stroke = Brushes.Black;
                    line.X1 = point.X;
                    line.X2 = point2.X;
                    line.Y2 = point2.Y;
                    line.Y1 = point.Y;
                    line.StrokeThickness = 4;
                    Collecstion.TryAdd(ida + "_" + idb, line);
                Dispatcher.Invoke(() => {
                    Panel.SetZIndex(line,-1);
                    GR.Children.Add(line);
                   
                });
                }
                else
                {
                    var ccobj = Collecstion[ida + "_" + idb];
                
                        ccobj.Dispatcher.Invoke(() => {
                        ccobj.X1 = point.X;
                        ccobj.Y1 = point.Y;
                        ccobj.X2 = point2.X;
                        ccobj.Y2 = point2.Y;
                        });
                    
                }


            if (!Collecstion.ContainsKey(idb + "_" + ida))
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = point2.X;
                line.X2 = point.X;
                line.Y2 = point.Y;
                line.Y1 = point2.Y;
                line.StrokeThickness = 4;
                Collecstion.TryAdd(idb + "_" + ida, line);
                Dispatcher.Invoke(() => {
                    Panel.SetZIndex(line,-1);
                    GR.Children.Add(line);
                });
            }
            else
            {
                var ccobj = Collecstion[idb + "_" + ida];

                ccobj.Dispatcher.Invoke(() => {
                    ccobj.X1 = point.X;
                    ccobj.Y1 = point.Y;
                    ccobj.X2 = point2.X;
                    ccobj.Y2 = point2.Y;
                });

            }

        }

        private void TreeViewControl_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void T_MoveEvent()
        {

        }

    
        public void UpdateLine()
        {
            foreach (var sd in ComplexCollections)
            {

                foreach (var td in sd.Value)
                {

                    if (!GR.Children.Contains(td))
                        GR.Children.Add(td);
                 /*   if (ComplexCollections.ContainsKey(td.id))
                    {
                        foreach (var f in ComplexCollections[td.id])
                        {
                            Dispatcher.Invoke(() =>
                            {
                                if (!Collecstion.ContainsKey(td.id + "_" + f.id))
                                {
                                    Line line = new Line();
                                    line.Stroke = Brushes.Black;
                                    line.X1 = (td.RenderTransform as TranslateTransform).X;
                                    line.X2 = (f.RenderTransform as TranslateTransform).X;
                                    line.Y2 = (f.RenderTransform as TranslateTransform).Y;
                                    line.Y1 = (td.RenderTransform as TranslateTransform).Y;
                                    line.StrokeThickness = 4;
                                    line.Name = td.id + "_" + f.id;

                                    Collecstion.Add(line.Name, line);
                                    GR.Children.Add(line);
                                }
                                else
                                {
                                    var ccobj = Collecstion[td.id + "_" + f.id];
                                    if (GR.Children.Contains(ccobj))
                                    {
                                        ccobj.X1 = (td.RenderTransform as TranslateTransform).X;
                                        ccobj.X2 = (f.RenderTransform as TranslateTransform).X;
                                        ccobj.Y2 = (f.RenderTransform as TranslateTransform).Y;
                                        ccobj.Y1 = (td.RenderTransform as TranslateTransform).Y;
                                    }
                                }
                            });
                        }
                    }*/


                }
            }
        }
    }
    public static class TreeViewGlobal
    {
        public static Dictionary<string, Point> LocationCollection = new Dictionary<string, Point>();
        public static Dictionary<string, List<string>> ParentChildPair = new Dictionary<string, List<string>>();
        public static List<TreeViewNodeControl> ControlEntityPool = new List<TreeViewNodeControl>();
        public delegate void MoveEventHandler(int ida, int idb, Point point, Point point2);
        public static event MoveEventHandler MoveEvent;
        public static Random GlobalRandom = new Random();
        public static void Update(int ida , int idb ,Point point, Point point2)
        {
            Console.WriteLine("FFFFF");
            MoveEvent?.Invoke(ida,idb, point,  point2);
        }
    }
}
