using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Server_Restart_Final
{ 
   public class Resizer:Thumb
    {
        public static DependencyProperty ThumbDirectionProperty = DependencyProperty.Register("ThumbDirection", typeof(ResizeDirections), typeof(Resizer));

        public ResizeDirections ThumbDirection
        {
            get
            {
                return (ResizeDirections)GetValue(ThumbDirectionProperty);
            }
            set
            {
                SetValue(Resizer.ThumbDirectionProperty, value);
            }
        }
        static Resizer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Resizer), new FrameworkPropertyMetadata(typeof(Resizer)));
        }
        public Resizer()
        {
            DragDelta += new DragDeltaEventHandler(Resizer_DragDelta);
        }

        private void Resizer_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Control ditem = this.DataContext as Control;
            if (ditem !=null)
            {
                double deltavertical, deltahorizontal;
                switch (ThumbDirection)
                {
                    case ResizeDirections.TopLeft:
                        deltavertical = ResizeTop(e, ditem);
                        deltahorizontal = ResizeLeft(e, ditem);
                        break;
                    case ResizeDirections.Left:
                        deltahorizontal = ResizeLeft(e, ditem);
                        break;
                    case ResizeDirections.BottomLeft:
                        deltavertical = ResizeBottom(e, ditem);
                        deltahorizontal = ResizeLeft(e, ditem);
                        break;
                    case ResizeDirections.Bottom:
                        deltavertical = ResizeBottom(e, ditem);
                        break;
                    case ResizeDirections.BottomRight:
                        deltavertical = ResizeBottom(e, ditem);
                        deltahorizontal = ResizeRight(e, ditem);
                        break;
                    case ResizeDirections.Right:
                        deltahorizontal = ResizeRight(e, ditem);
                        break;
                    case ResizeDirections.TopRight:
                        deltavertical = ResizeTop(e, ditem);
                        deltahorizontal = ResizeRight(e, ditem);
                        break;
                    case ResizeDirections.Top:
                        deltavertical = ResizeTop(e, ditem);
                        break;
                    default:
                        break;
                }
            }
            e.Handled = true;
        }
        static double ResizeRight(DragDeltaEventArgs e, Control ditem)
        {
            double deltaHorizontal;
            deltaHorizontal = Math.Min(-e.HorizontalChange, ditem.ActualWidth - ditem.MinWidth);
            ditem.Width -= deltaHorizontal;
            return deltaHorizontal;
        }
        static double ResizeTop(DragDeltaEventArgs e, Control ditem)
        {
            double deltaVertical;
            deltaVertical = Math.Min(e.VerticalChange, ditem.ActualHeight - ditem.MinHeight);
            Canvas.SetTop(ditem, Canvas.GetTop(ditem) + deltaVertical);
            ditem.Height -= deltaVertical;
            return deltaVertical;
        }
        static double ResizeLeft(DragDeltaEventArgs e, Control ditem)
        {
            double deltaHorizontal;
            deltaHorizontal = Math.Min(e.HorizontalChange, ditem.ActualWidth - ditem.MinWidth);
            Canvas.SetLeft(ditem,Canvas.GetLeft(ditem)+deltaHorizontal);
            ditem.Width -= deltaHorizontal;
            return deltaHorizontal;
        }
        static double ResizeBottom(DragDeltaEventArgs e, Control ditem)
        {
            double deltaVertical;
            deltaVertical = Math.Min(-e.VerticalChange, ditem.ActualHeight - ditem.MinHeight);
            ditem.Height -= deltaVertical;
            return deltaVertical;
        }
    }
    public enum ResizeDirections
    {
        TopLeft=0,
        Left,
        BottomLeft,
        Bottom,
        BottomRight,
        Right,
        TopRight,
        Top
    }
}
