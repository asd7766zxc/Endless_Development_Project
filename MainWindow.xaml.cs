using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReDive_Bot.library.PrincessDataBase;
using Endless_Development_Project_Studio.Connection;
using System.Net;
using System.Net.Sockets;
using Chat_Pro_NCP;
using NAudioDemo.NetworkChatDemo;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using MessageBox = System.Windows.MessageBox;
using Endless_Development_Project_Studio.SQL;
using System.IO;
using System.Windows.Media;
using System.Windows.Threading;
using Endless_Development_Project_Studio.WindowFrame;
using Endless_Development_Project_Studio.Discord;
using Endless_Development_Project_Studio.Pages;
using SharpDX.Direct2D1;
using System.Windows.Interop;
using Endless_Development_Project_Studio.SharpDXControl;
using Endless_Development_Project_Studio.Managers;
using Endless_Development_Project_Studio.TopTools;

namespace Endless_Development_Project_Studio
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    class Player { public string Name { get; set; } }
    public partial class MainWindow : Window
    {
        string Name = "No Login";
        string Version = "";
        
      
        DispatcherTimer DTS = new DispatcherTimer();
        public MainWindow()
        {

            Logger.ConsoleLogger.Log("MainWindow .ctor");

            int d = RenderCapability.Tier >> 16;
            this.DataContext = new WindowsVeiwModles(this);
            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
            PublicRevokeStaticEvent.PageEvent += PublicRevokeStaticEvent_PageEvent;
            InitializeComponent();
          //  this.MainContainer.Content = PageManager.Instance.PageComplex["Home"];
        }

        private void PublicRevokeStaticEvent_PageEvent(object parameter)
        {
            Logger.ConsoleLogger.Log("On Page Change");

            MainContainer.Content = PageManager.Instance.PageComplex[(string)parameter];
        }

        private void DTS_Tick(object sender, EventArgs e)
        {
           // SocketStatus.player_RPC.UpdatePresence("edp", Version, "edp-smalllogo", Name);
        }

     
        ConnectToSQL cts;
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Logger.ConsoleLogger.Log("Closing");
            if (SocketStatus.Account != null)
                cts.SetPlayerOffline(SocketStatus.Account);
            if (SocketStatus.voice_Client.voicePage != null)
                SocketStatus.voice_Client.voicePage.DisconnectClient();
        }
     
      

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Logger.ConsoleLogger.Log("MainWindow_Loaded");
            SocketStatus.LoginComplect += SocketStatus_LoginComplect;
            //var Obj = new FrameControl(ADS,new SyncUnitTestPage(),"From1");
             //Obj.Height = 500;
             //Obj.Width = 500;
             //ADS.Children.Add(Obj);
            //var Obja = new FrameControl(ADS, new SyncUnitTestPage(), "From2");
            //Obja.Height = 500;
            //Obja.Width = 500;
            //ADS.Children.Add(Obja);

            Version = File.ReadAllText(@"C:\EDP\Build.json").Split('|')[1];
            
        }

       

        private void SocketStatus_LoginComplect(object Parameter)
        {
            Dispatcher.Invoke(() =>
            {
                Logger.ConsoleLogger.Log("LoginComplect");
                Task.Run(() => { SocketStatus.GlobalSynchronizeClient.Setup(); });
                //LogOutButton.Visibility = Visibility.Visible;
                Title = "EDP - " + (string)Parameter;
                cts = new ConnectToSQL();
                //SocketStatus.player_RPC.initialize();
                Name = (string)Parameter;
                //SocketStatus.player_RPC.UpdatePresence("edp", File.ReadAllText(@"C:\EDP\Build.json").Split('|')[1], "edp-smalllogo",(string)Parameter);
                cts.Connect(Config.ConnectionStringEDP, 1433, "f");
                //TODO:cts.Connect("192.168.1.103", 1433, "f");
                cts.SetPlayerOnline(SocketStatus.Account);
                SocketStatus.GlobalSynchronizeClient.Login(SocketStatus.Account);
                SocketStatus.voice_Client.voicePage = new VoicePage();
            
              
            });
        }

        public string name { get; set; }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (File.Exists(@"C:\EDP\LocalData\LocalContainer.json"))
            {
                File.Delete(@"C:\EDP\LocalData\LocalContainer.json");
                this.Close();
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            //this.MainContainer.Content = PageManager.Instance.PageComplex["Home"];
        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {
            //this.MainContainer.Content = PageManager.Instance.PageComplex["Chat"];
        }

        private void ServerButton_Click(object sender, RoutedEventArgs e)
        {
        //    this.MainContainer.Content = PageManager.Instance.PageComplex["Server"];
        }

        private void ModFolderButton_Click(object sender, RoutedEventArgs e)
        {
          //  this.MainContainer.Content = PageManager.Instance.PageComplex["Mod"];
        }

        private void GlobalComplexButton_Click(object sender, RoutedEventArgs e)
        {
            //this.MainContainer.Content = PageManager.Instance.PageComplex["Global"];
        }
        Dictionary<string, string> NameComplex = new Dictionary<string, string>();
        private void Complex_MouseEnter(object sender, MouseEventArgs e)
        {

        }
        private void Complex_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        
    }
}
