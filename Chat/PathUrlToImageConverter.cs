using Chat_Pro_NCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Pro_NCP
{
    using System.Globalization;
    using System.IO;

    public class PathUrlToImageConverter : BaseValueConverter<PathUrlToImageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = value.ToString();

            if (path.StartsWith("\\"))
                path = path.Substring(1);

            return Path.Combine("", path);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
