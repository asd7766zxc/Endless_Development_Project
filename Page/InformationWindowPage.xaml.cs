using Chat_Pro_NCP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Endless_Development_Project_Studio
{
    /// <summary>
    /// InformationWindowPage.xaml 的互動邏輯
    /// </summary>
    public partial class InformationWindowPage :BasePage <LoginViewModel>
    {

        public InformationWindowPage()
        {
            InitializeComponent();
            Info.Loaded += Info_Loaded;

      
            this.Loaded += InformationWindowPage_Loaded;
         
          
        }

        private void Info_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void InformationWindowPage_Loaded(object sender, RoutedEventArgs e)
        {
            Version.Content = File.ReadAllText(@"C:\EDP\Build.json").Split('|')[1];
            Protan.Content = File.ReadAllText(@"C:\EDP\Build.json").Split('|')[0].Split(',')[0];
            Protan.Background = (SolidColorBrush)new BrushConverter().ConvertFrom($"#{File.ReadAllText(@"C:\EDP\Build.json").Split('|')[0].Split(',')[1]}");

            UpdateContent.Text = File.ReadAllText(@"C:\EDP\Build.json").Split('|')[0].Split(',')[2];
             
        }
     

    }
}
