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
    public partial class ServerWindow : Window
    {
        SourceServer baseServer;
        LogClient client = new LogClient();

        public ServerWindow(string StartParameter,string StartFolder)
        {
            client.LogEvent += Client_LogEvent;
            InitializeComponent();
            //StringBuilder sb = new StringBuilder();
            //sb.Append("java -server -Xms1024M -Xmx10240M -XX:+DisableExplicitGC -XX:+UseConcMarkSweepGC -XX:+UseParNewGC -XX:+UseNUMA -XX:+CMSParallelRemarkEnabled -XX:MaxGCPauseMillis=50 -XX:+UseAdaptiveGCBoundary -XX:-UseGCOverheadLimit -XX:+UseBiasedLocking -XX:SurvivorRatio=8 -XX:TargetSurvivorRatio=90 -XX:MaxTenuringThreshold=15 -XX:UseSSE=3 -XX:+UseFastAccessorMethods -XX:+UseStringCache -XX:+UseCompressedOops -XX:+OptimizeStringConcat -XX:+UseFastAccessorMethods -XX:+AggressiveOpts");
            //sb.Append(" -jar");
            //sb.Append(@" E:\ServerTest\minecraft_server.1.7.10.jar");
            //sb.Append(" nogui");

            baseServer = new SourceServer(StartParameter, StartFolder);
            baseServer.OutPutEvent += BaseServer_OutPutEvent;
            baseServer.CloseEvent += BaseServer_CloseEvent;
            this.Loaded += ServerWindow_Loaded;
        }

        private void Client_LogEvent(object Log)
        {
            var log = (string)Log;
            if (log.Split(',')[0] == "s")
            {
                var c = log.Split(',')[1];
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
            client.Setup();
            baseServer.Start();
        }

        private void BaseServer_OutPutEvent(System.Diagnostics.DataReceivedEventArgs e)
        {

            try
            {
                var log = e.Data;
                if (log != null)
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
                                    client.SendString("C," + color + "|" + log.Split('[')[1].Split(']')[0] + "|" + result + "|" + type);
                                    Task.Run(() => { P.AddToOutput(color, log.Split('[')[1].Split(']')[0], result, type); });
                                }
                                else
                                {
                                    client.SendString("C," + "" + "|" + log + "|" + "" + "|" + "");
                                    P.AddToOutput("fff", "", log, "");
                                }

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
    }
}
