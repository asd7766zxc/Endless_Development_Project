using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Chat_Pro_NCP
{
    public class StringRGBToBrushConverter : BaseValueConverter<StringRGBToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush)new BrushConverter().ConvertFrom($"#{value}");
        }
 

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}