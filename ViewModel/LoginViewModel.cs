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

            var email = this.Email;
            var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
                ConnectToSQL cts = new ConnectToSQL();
        
                    cts.Connect("cr-reports.ddns.net", 1433, "f");
                if (cts.GetServerData(int.Parse(email)).FirstOrDefault().Password==pass)
                {
                    SocketStatus.Account = cts.GetServerData(int.Parse(email)).FirstOrDefault();
                    SocketStatus.UserName = cts.GetServerData(int.Parse(email)).FirstOrDefault().Name;
                    SocketStatus.L(cts.GetServerData(int.Parse(email)).FirstOrDefault().Name);
                }

                if (!Directory.Exists(@"C:\EDP\LocalData"))
                    Directory.CreateDirectory(@"C:\EDP\LocalData");

                File.WriteAllText(@"C:\EDP\LocalData\LocalContainer.json",email+"|"+pass);
            });
        }
    }
}