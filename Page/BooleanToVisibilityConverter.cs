using System;
using System.Globalization;
using System.Windows;

namespace Chat_Pro_NCP
{
    public class BooleanToVisbilityConverter : BaseValueConverter<BooleanToVisbilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            return (bool)value ? Visibility.Hidden : Visibility.Visible;

            else
                return (bool)value ? Visibility.Visible : Visibility.Hidden;
        }
 

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}