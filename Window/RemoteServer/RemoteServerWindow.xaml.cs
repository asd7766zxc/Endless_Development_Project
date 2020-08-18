using Endless_Development_Project_Studio.Server;
using Endless_Development_Project_Studio.ServerOutputControl;
using NF;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Endless_Development_Project_Studio
{
    /// <summary>
    /// ServerWindow.xaml 的互動邏輯
    /// </summary>
    public partial class RemoteServerWindow : Window
    {

        TCPClient m_Client;
        public RemoteServerWindow()
        {
            m_Client = new NF.TCPClient("192.168.1.101", 1523);
            m_Client.DataReceived += new NF.TCPClient.DelegateDataReceived(OnClientDataReceived);
          
            InitializeComponent();
            this.Loaded += ServerWindow_Loaded;
        }

        private void OnClientDataReceived(TCPClient client, byte[] bytes)
        {
            string log = Encoding.UTF8.GetString(bytes);
            if (log.StartsWith("C,"))
            {
                var color = log.Split('|')[0].Split(',')[1];
                var time = log.Split('|')[1];
                var type = log.Split('|')[2];

                var result = log.Replace(log.Split('|')[0] + "|", "").Replace(log.Split('|')[1] + "|", "").Replace(log.Split('|')[2] + "|", "");
                P.AddToOutput(color, time, result, type);
            }
        }

        private void ServerWindow_Loaded(object sender, RoutedEventArgs e)
        {
            m_Client.Connect();
        }

        private void Client_LogEvent(object Log)
        {
          
        }

        private void BaseServer_CloseEvent()
        {
            Dispatcher.Invoke(() =>
            {
                this.Close();
            });
        }

        private async void TextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                try
                {
                    m_Client.Send(Encoding.UTF8.GetBytes("s," + Input.Text));
                    Input.Text = "";
                }
                catch { }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
