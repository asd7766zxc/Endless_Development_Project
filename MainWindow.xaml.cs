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
            this.DataContext = new WindowsVeiwModles(this);
            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
       
            DTS.Interval = TimeSpan.FromMilliseconds(500);
            DTS.Tick += DTS_Tick;
            DTS.Start();
            InitializeComponent();
        }

        private void DTS_Tick(object sender, EventArgs e)
        {
            SocketStatus.player_RPC.UpdatePresence("edp", Version, "edp-smalllogo", Name);
        }

     
        ConnectToSQL cts;
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (SocketStatus.Account != null)
                cts.SetPlayerOffline(SocketStatus.Account);
            if (SocketStatus.voice_Client.voicePage != null)
                SocketStatus.voice_Client.voicePage.DisconnectClient();
        }
        InformationWindowPage iwp = new InformationWindowPage();
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {


            InformationWindowPageContainer.Content = iwp;
            InformationWindowPageContainer.MouseLeave += InformationWindowPageContainer_MouseLeave;
            SocketStatus.LoginComplect += SocketStatus_LoginComplect;
            var Obj = new FrameControl(ADS,new ChatPage(),"From1");
             Obj.Height = 500;
             Obj.Width = 500;
             ADS.Children.Add(Obj);
             var Objs = new FrameControl(ADS, new ChatPage(), "From2");
             Objs.Height = 500;
             Objs.Width = 500;
             ADS.Children.Add(Objs);
            Version = File.ReadAllText(@"C:\EDP\Build.json").Split('|')[1];
            if (File.Exists(@"C:\EDP\LocalData\LocalContainer.json"))
            {
                var email = File.ReadAllText(@"C:\EDP\LocalData\LocalContainer.json").Split('|')[0];
                var pass = File.ReadAllText(@"C:\EDP\LocalData\LocalContainer.json").Split('|')[1];
                cts = new ConnectToSQL();
                   cts.Connect("cr-reports.ddns.net", 1433, "f");
                //TODO:  cts.Connect("192.168.1.103", 1433, "f");
                if (cts.GetServerData(int.Parse(email)).FirstOrDefault().Password == pass)
                {
                    SocketStatus.Account = cts.GetServerData(int.Parse(email)).FirstOrDefault();
                    SocketStatus.UserName = cts.GetServerData(int.Parse(email)).FirstOrDefault().Name;
                    SocketStatus.L(cts.GetServerData(int.Parse(email)).FirstOrDefault().Name);
                    cts.SetPlayerOnline(SocketStatus.Account);
                 
                }
                MainFrame.Visibility = Visibility.Collapsed;
            }
            else
            {
                CCC.Visibility = Visibility.Collapsed;
            }

        }

        private void InformationWindowPageContainer_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            awaitHeigh();
            iwp.sb.Stop(iwp);
            InformationWindowPageContainer.MouseLeave -= InformationWindowPageContainer_MouseLeave;
            InformationWindowPageContainer.MouseMove += InformationWindowPageContainer_MouseMove;
        }

        private void InformationWindowPageContainer_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            InformationWindowPageContainer.Height = 450;
            iwp.AnimateIn();
            iwp.sb.Begin(iwp, true);

            InformationWindowPageContainer.MouseMove -= InformationWindowPageContainer_MouseMove;
            EventRegeits();
        }

        async Task awaitHeigh()
        {
            Task.Delay(10);
            if (this.ActualHeight > 1000)
                await iwp.AnimateOut((float)(this.ActualHeight - 32 - InformationWindowPageContainer.Height + 90));
            else
                await iwp.AnimateOut((float)(this.ActualHeight - 32 - InformationWindowPageContainer.Height + 82));
            iwp.sb.Stop(iwp);
        }
        async Task awaitHeighB()
        {

            await iwp.AnimateIn();
            iwp.sb.Begin(iwp, true);
            await Task.Delay(1000);
            iwp.sb.Stop(iwp);
            if (this.WindowState == WindowState.Maximized)
                await iwp.AnimateOut((float)(this.ActualHeight - 32 - InformationWindowPageContainer.Height + 90));
            else
                await iwp.AnimateOut((float)(this.ActualHeight - 32 - InformationWindowPageContainer.Height + 82));

        }
        async Task EventRegeits()
        {
            await Task.Delay(500);
            InformationWindowPageContainer.MouseLeave += InformationWindowPageContainer_MouseLeave;
        }

        private void SocketStatus_LoginComplect(object Parameter)
        {
            Dispatcher.Invoke(() =>
            {
                LogOutButton.Visibility = Visibility.Visible;
                Title = "EDP - " + (string)Parameter;
                cts = new ConnectToSQL();
                SocketStatus.player_RPC.initialize();
                Name = (string)Parameter;
                SocketStatus.player_RPC.UpdatePresence("edp", File.ReadAllText(@"C:\EDP\Build.json").Split('|')[1], "edp-smalllogo",(string)Parameter);
                 cts.Connect("cr-reports.ddns.net", 1433, "f");
                //TODO:cts.Connect("192.168.1.103", 1433, "f");
                cts.SetPlayerOnline(SocketStatus.Account);
                MainFrame.Visibility = Visibility.Collapsed;
                CCC.Visibility = Visibility.Visible;
                MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
                VoicePageContainer.NavigationUIVisibility = NavigationUIVisibility.Hidden;
                SocketStatus.voice_Client.voicePage = new VoicePage();
                VoicePageContainer.Content = SocketStatus.voice_Client.voicePage;
                DT.Start();
            });
        }

        public string name { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            awaitHeighB();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (File.Exists(@"C:\EDP\LocalData\LocalContainer.json"))
            {
                File.Delete(@"C:\EDP\LocalData\LocalContainer.json");
                this.Close();
            }
        }

        bool MouseDrag = false;

        private bool _isMoving;
        private System.Windows.Point? _buttonPosition;
        private double deltaX;
        private double deltaY;
        private TranslateTransform _currentTT;


        private void VoicePageContainer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_buttonPosition == null)
                _buttonPosition = VoicePageContainer.TransformToAncestor(CACA).Transform(new System.Windows.Point(0, 0));
            var mousePosition = Mouse.GetPosition(CACA);
            deltaX = mousePosition.X - _buttonPosition.Value.X;
            deltaY = mousePosition.Y - _buttonPosition.Value.Y;
            _isMoving = true;
        }

        private void VoicePageContainer_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!_isMoving) return;

            var mousePoint = Mouse.GetPosition(CACA);

            var offsetX = (_currentTT == null ? _buttonPosition.Value.X : _buttonPosition.Value.X - _currentTT.X) + deltaX - mousePoint.X;
            var offsetY = (_currentTT == null ? _buttonPosition.Value.Y : _buttonPosition.Value.Y - _currentTT.Y) + deltaY - mousePoint.Y;

            this.VoicePageContainer.RenderTransform = new TranslateTransform(-offsetX, -offsetY);
        }

        private void VoicePageContainer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _currentTT = VoicePageContainer.RenderTransform as TranslateTransform;
            _isMoving = false;
        }

        private void VoicePageContainer_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _currentTT = VoicePageContainer.RenderTransform as TranslateTransform;
            _isMoving = false;
        }
    }
}
