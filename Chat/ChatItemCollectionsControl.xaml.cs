using Endless_Development_Project_Studio;
using Endless_Development_Project_Studio.Connection;
using Endless_Development_Project_Studio.Logger;
using Endless_Development_Project_Studio.Managers;
using Endless_Development_Project_Studio.SQL;
using Endless_Development_Project_Studio.SQL.Chat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace Chat_Pro_NCP
{
    /// <summary>
    /// ChatItemCollectionsControl.xaml 的互動邏輯
    /// </summary>
    public partial class ChatItemCollectionsControl : Page
    {
      
        public ChatItemCollectionsControl()
        {
            InitializeComponent();
            this.Loaded += ChatItemCollectionsControl_Loaded;
            this.Unloaded += ChatItemCollectionsControl_Unloaded;
        }

        private void ChatItemCollectionsControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Disconnect();
        }

        private void ChatItemCollectionsControl_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Connect();
            });

        }
        public void Connect()
        {
            Task.Run(() =>
            {
                sqlchat.MessageEvent += Sqlchat_MessageEvent;
                sqlchat.UpdateEvent += Sqlchat_UpdateEvent;
                cts.Connect(Config.ConnectionStringEDP, 1433, "f");
                sqlchat.Connect();
            });
        }

        private void Sqlchat_UpdateEvent(Endless_Development_Project_Studio.ChatsC msg)
        {
            SocketStatus.UpdateNewMessage();
            Dispatcher.Invoke(() =>
            {
                IC.Items.Add(new ChatItemViewModel { AvatarUrl = cts.GetServerData(msg.userid).FirstOrDefault().Account.Split('|')[1], message = msg.message, Date = msg.Date.Split(':')[0] + "/" + msg.Date.Split(':')[1] + "/" + msg.Date.Split(':')[2] + " " + msg.Date.Split(':')[3] + ":" + msg.Date.Split(':')[4] + ":" + msg.Date.Split(':')[5], Modify = msg.Modify, user = msg.user, Name = msg.user });
                SVroller.ScrollToEnd();
            });
        }

        public void Disconnect()
        {
            Task.Run(() =>
            {
                sqlchat.MessageEvent -= Sqlchat_MessageEvent;
                sqlchat.UpdateEvent -= Sqlchat_UpdateEvent;
                sqlchat.Disconnect();
            });
        }
        public SQLChat sqlchat = new SQLChat();
        Endless_Development_Project_Studio.SQL.ConnectToSQL cts = new Endless_Development_Project_Studio.SQL.ConnectToSQL();
        List<Message> Messages = new List<Message>();
        List<ChatItemViewModel> _Items = new List<ChatItemViewModel>();
        private void Sqlchat_MessageEvent(List<Message> msg)
        {
            Task.Run(() =>
            {
                var offset = msg.Count - Messages.Count;
                if (offset != 0)
                {
                    var buffers = msg.ToList();
                    buffers.RemoveRange(0, Messages.Count);


                    foreach (var buffer in buffers)
                    {
                        Dispatcher.Invoke(() =>
                        {
                            IC.Items.Add(new ChatItemViewModel { AvatarUrl = cts.GetServerData(buffer.userid).FirstOrDefault().Account.Split('|')[1], message = buffer.message, Date = buffer.Date.Split(':')[0] + "/" + buffer.Date.Split(':')[1] + "/" + buffer.Date.Split(':')[2] + " " + buffer.Date.Split(':')[3] + ":" + buffer.Date.Split(':')[4] + ":" + buffer.Date.Split(':')[5], Modify = buffer.Modify, user = buffer.user, Name = buffer.user });
                            SVroller.ScrollToEnd();

                        });
                    }
                    Messages = msg;

                }
            });
        }
        Stopwatch d = new Stopwatch();
        private void Inputtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (!string.IsNullOrEmpty(inputtb.Text))
                    if (!string.IsNullOrWhiteSpace(inputtb.Text))
                    {
                     
                        d.Start();
                        sqlchat.Send(new Message { message = inputtb.Text, user = DataManagers.account.UserName, _short = 0, id = new Random().Next(0, 9999999), Date = DateTime.Now.ToString("yyyy:MM:dd:HH:mm:ss"), Address = "127.0.0.1", Modify = false, userid = int.Parse(DataManagers.account.UserID) },0);
                        inputtb.Text = "";
                        d.Stop();
                        ConsoleLogger.Log($"Send Elapsed {d.ElapsedTicks * 1000000F / Stopwatch.Frequency:n3}μs");
                        d.Reset();
                        
                    }
        }
      
    }
}

