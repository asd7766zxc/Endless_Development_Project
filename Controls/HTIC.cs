using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Endless_Development_Project_Studio.Controls
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HTIC : IValueConverter
    {

        public static HTIC Instance = new HTIC();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string)value;
            if (path == null)
                return null;

            var pach = path.Split('.');

            var name = FileViewControl.GFN(path);

            var image = "Images/icons8-documents-100.png";

            if (string.IsNullOrEmpty(name))
                image = "Images/icons8-c-drive-120.png";
            else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
                image = "Images/icons8-folder-48.png";
            else if (pach[pach.Length - 1].ToLower() == "dll")
                image = "Images/icons8-dll-48.png";
            else if (pach[pach.Length - 1].ToLower() == "xml")
                image = "Images/icons8-xml-transformer-48.png";
            else if (pach[pach.Length - 1].ToLower() == "dat")
                image = "Images/icons8-database-48.png";
            else if (pach[pach.Length - 1].ToLower() == "cfg")
                image = "Images/icons8-automatic-48.png";
            else if (pach[pach.Length - 1].ToLower() == "jar")
                image = "Images/icons8-java-48.png";
            else if (pach[pach.Length - 1].ToLower() == "json")
                image = "Images/icons8-json-48.png";
            else if (pach[pach.Length - 1].ToLower() == "log")
                image = "Images/icons8-index-48.png";
            else if (pach[pach.Length - 1].ToLower() == "txt")
                image = "Images/icons8-txt-48.png";
            else if (pach[pach.Length - 1].ToLower() == "bat")
                image = "Images/icons8-services-48.png";
            else if (pach[pach.Length - 1].ToLower() == "config")
                image = "Images/icons8-job-48.png";
            else if (pach[pach.Length - 1].ToLower() == "pdb")
                image = "Images/icons8-protein-48.png";
            else if (pach[pach.Length - 1].ToLower() == "exe")
                image = "Images/icons8-exe-48.png";
            else if (pach[pach.Length - 1].ToLower() == "winmd")
                image = "Images/icons8-maximize-window-48.png";
            else if (pach[pach.Length - 1].ToLower() == "mca")
                image = "Images/icons8-antivirus-48.png";
            else if (pach[pach.Length - 1].ToLower() == "lock")
                image = "Images/icons8-lock-48.png";
            else if (pach[pach.Length - 1].ToLower() == "gz")
                image = "Images/icons8-zip-48.png";


            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
