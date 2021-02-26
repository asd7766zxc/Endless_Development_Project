using Endless_Development_Project_Studio.Events;
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
using System.Windows.Shapes;

namespace Endless_Development_Project_Studio.Windows
{
    /// <summary>
    /// LoginWindow.xaml 的互動邏輯
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
           
           
            this.DataContext = new LoginWindowViewModel(this);
            InitializeComponent();
            this.Loaded += LoginWindow_Loaded;
        }

        private void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StaticEvent.LoginEvent += StaticEvent_LoginEvent;
            if (File.Exists(@"C:\EDP\LocalData\LocalContainer.json"))
            {
                var email = File.ReadAllText(@"C:\EDP\LocalData\LocalContainer.json").Split('|')[0];
                var pass = File.ReadAllText(@"C:\EDP\LocalData\LocalContainer.json").Split('|')[1];
                var Client = DataBaseManager.Instance.DataBaseClient;
                Client.Connect(Config.ConnectionStringEDP, 1433, "f");
                var Data = Client.GetServerDataByAccount(email).FirstOrDefault();
                if (Data.Password == pass)
                {
                    DataManagers.account.Complex = Data;
                    DataManagers.account.UserID = Data.id.ToString();
                    DataManagers.account.UserName = Data.Name;
                    StaticEvent.OnLoginEvent();
                }
            }
        }

        private void StaticEvent_LoginEvent(object Parameter)
        {
            MainWindow mWindow = new MainWindow();
            mWindow.Show();
            this.Close();
        }

      
    }
}
