using Endless_Development_Project_Studio.Server;
using Endless_Development_Project_Studio.ServerOutputControl;
using NF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class ServerWindow : Window
    {
        SourceServer baseServer;
        NF.TCPClient m_Client;
        Regex TimePattern { get; set; }
        Regex TypePattern { get; set; }
        public ServerWindow(string StartParameter,string StartFolder)
        {
            TimePattern = new Regex(@"\[\d{1,2}:\d{1,2}:\d{1,2}\]");
            TypePattern = new Regex(@"\s\[(.+)/(\w+)\]");
            m_Client = new NF.TCPClient("192.168.1.101", 1523);
            m_Client.DataReceived += new NF.TCPClient.DelegateDataReceived(OnClientDataReceived);
            InitializeComponent();
            
            baseServer = new SourceServer(StartParameter, StartFolder);
            baseServer.OutPutEvent += BaseServer_OutPutEvent;
            baseServer.CloseEvent += BaseServer_CloseEvent;
            this.Loaded += ServerWindow_Loaded;
        }

        private void OnClientDataReceived(TCPClient client, byte[] bytes)
        {
            var log = Encoding.UTF8.GetString(bytes);
            if (log.StartsWith("s,"))
            {
                var c = log.Substring(2);
                baseServer.Write(c);
                P.AddToOutput("FFEB3B", "Remote", "> " + c, "");
            }
        }

        private void Client_LogEvent(object Log)
        {
            var log = (string)Log;
            if (log.StartsWith("s,"))
            {
                var c = log.Substring(2);
                baseServer.Write(c);
                P.AddToOutput("FFEB3B", "Remote", "> " + c, "");
            }
        }

        private void BaseServer_CloseEvent()
        {
            Dispatcher.Invoke(() =>
            {
                this.Close();
            });
        }

        private void ServerWindow_Loaded(object sender, RoutedEventArgs e)
        {
            m_Client.Connect();
            baseServer.Start();
        }

        private void BaseServer_OutPutEvent(System.Diagnostics.DataReceivedEventArgs e)
        {
           
      
            try
            {
                var log = e.Data;
                if (log != null)
                    if (TimePattern.Match(log).Success)
                    {
                        if (TypePattern.Match(log).Success)
                        {
                            var result = log.Remove(0, TimePattern.Match(log).ToString().Length);
                            var type = TypePattern.Match(log).ToString().Split('/')[1].Split(']')[0];
                            var color = "8BC34A";
                            if (type == "INFO")
                                color = "64B5F6";
                            else if (type == "WARN")
                                color = "f44336";
                            else if (type == "ERROR")
                                color = "f44336";
                            m_Client.Send(Encoding.UTF8.GetBytes("C," + color + "|" + log.Split('[')[1].Split(']')[0] + "|" + type + "|" + result));
                           P.AddToOutput(color, TimePattern.Match(log).ToString(), result, type);
                        }
                    }
                    else
                    {
                        P.AddToOutput("fff", "", log, "");
                    }
                    /*
                    if (log.Split('[')[1] != null)
                        if (log.Split('[')[1].Split(']')[0] != null)
                            if (log.Split('[')[1].Split(']')[0].Split(':') != null)
                                if (log.Split('[')[1].Split(']')[0].Split(':').Length == 3)
                                {
                                    var result = log.Replace(log.Split(']')[0] + "]", "");
                                    var type = result.Split('[')[1].Split(']')[0].Split('/')[1];
                                    var thread = result.Split('[')[1].Split(']')[0].Split('/')[0];

                                    var color = "8BC34A";
                                    if (type == "INFO")
                                        color = "64B5F6";
                                    else if (type == "WARN")
                                        color = "f44336";
                                    else if (type == "ERROR")
                                        color = "f44336";
                                    client.SendString("C," + color + "|" + log.Split('[')[1].Split(']')[0]+ "|" + type + "|" + result);
                                    Task.Run(() => { P.AddToOutput(color, log.Split('[')[1].Split(']')[0], result, type); });
                                }
                                else
                                {
                                    client.SendString("C," + "" + "|" + log + "|" + "" + "|" + "");
                                    P.AddToOutput("fff", "", log, "");
                                }
                                */
            }
            catch { }


        }






        private async void TextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                try
                {
                    var c = Input.Text;
                    await baseServer.Write(c);
                    await P.AddToOutput("FFEB3B", "Command", "> " + c, "");
                    Input.Text = "";
                }
                catch { }
            }
        }



        private async void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await baseServer.Close();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await baseServer.Close();
        }
    }
}
