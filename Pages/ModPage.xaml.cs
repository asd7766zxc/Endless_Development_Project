using Endless_Development_Project_Studio.Win32Control;
using MojangSharp.Endpoints;
using MojangSharp.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Endless_Development_Project_Studio.Pages
{
    /// <summary>
    /// ModPage.xaml 的互動邏輯
    /// </summary>
    public partial class ModPage : Page
    {

      
        public ModPage()
        {
            InitializeComponent();
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
          
        }
        public async void Load()
        {
            AuthenticateResponse auth = await new Authenticate(new Credentials() { Username = "",Password = "" }).PerformRequestAsync();


        }
    }
}
