using Endless_Development_Project_Studio.Connection;
using Endless_Development_Project_Studio.Managers;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace Endless_Development_Project_Studio.TopTools
{
    /// <summary>
    /// UserStatus.xaml 的互動邏輯
    /// </summary>
    public partial class UserStatus : UserControl
    {
        public UserStatus()
        {
            SocketStatus.LoginComplect += SocketStatus_LoginComplect;
            InitializeComponent();
          
            this.Loaded += UserStatus_Loaded;
            
        }

        private void Account_LoginDataEvent(object Parameter)
        {
          
        }

        private void SocketStatus_LoginComplect(object Parameter)
        {
         
        }

        private void UserStatus_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(() => {

                string path = DataManagers.account.Complex.Account.Split('|')[1].ToString();

                if (path.StartsWith("\\"))
                    path = path.Substring(1);


                UserAvater.ImageSource = new BitmapImage(new Uri(Path.Combine("", path)));
                User.Content = DataManagers.account.Complex.Name;
                Details.Content = DataManagers.account.Complex.Account.Split('|')[0];
            });
        }
    }
}
