using Endless_Development_Project_Studio;
using Endless_Development_Project_Studio.Connection;
using Endless_Development_Project_Studio.SQL;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;
using System.Windows.Input;
using System.IO;
using Endless_Development_Project_Studio.Managers;
using Endless_Development_Project_Studio.Events;

namespace Chat_Pro_NCP
{
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }

        public string LoginButtonContent { get; set; } = "Next";

        public bool LoginIsRunning { get; set; }
        
        public ICommand LoginCommand { get; set; }

        public ICommand NoAccount { get; set; }


        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
        }

        public async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () => {

                LoginButtonContent = "Login...";
                OnPropertyChanged("LoginButtonContent");
                var email = this.Email;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
                DataManagers.account.account = email;
                DataManagers.account.AccountReady = false;
                DataManagers.account.password = pass;

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

                if (!Directory.Exists(@"C:\EDP\LocalData"))
                    Directory.CreateDirectory(@"C:\EDP\LocalData");

                File.WriteAllText(@"C:\EDP\LocalData\LocalContainer.json",email+"|"+pass);
            });
        }
    }
}