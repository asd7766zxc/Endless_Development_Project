using System;
using System.Windows;

namespace Chat_Pro_NCP
{
    public abstract class BaseAttached<Parent, Property> where Parent : BaseAttached<Parent, Property>, new()
    {

        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChange = (sender, e) => { };

        public static Parent Instane { get; private set; } = new Parent();

        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value",typeof(Property),typeof(BaseAttached<Parent,Property>),new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChange)));

        private static void OnValuePropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Instane.OnValueChange(d, e);
            Instane.ValueChange(d, e);
        }
        
        public static Property GetValue(DependencyObject d)
        =>(Property) d.GetValue(ValueProperty);
        public static void SetValue(DependencyObject d, Property value)
            =>d.SetValue(ValueProperty,value);

        public virtual void OnValueChange(DependencyObject sender, DependencyPropertyChangedEventArgs e){ }
    }
}