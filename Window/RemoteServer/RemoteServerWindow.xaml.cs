using Endless_Development_Project_Studio.Server;
using Endless_Development_Project_Studio.ServerOutputControl;
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
       
        LogClient client = new LogClient();
        public RemoteServerWindow()
        {
            client.LogEvent += Client_LogEvent;
            InitializeComponent();
            this.Loaded += ServerWindow_Loaded;
        }

        private void ServerWindow_Loaded(object sender, RoutedEventArgs e)
        {
            client.Setup();
        }

        private void Client_LogEvent(object Log)
        {
            string log = (string)Log;
            if (log.Split('|')[0].Split(',')[0]=="C")
            P.AddToOutput(log.Split('|')[0].Split(',')[1], log.Split('|')[1], log.Split('|')[2], log.Split('|')[3]);
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
                    client.SendString("s,"+Input.Text);
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
