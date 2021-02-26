using Endless_Development_Project_Studio.Controls;
using Endless_Development_Project_Studio.Server;
using Endless_Development_Project_Studio.SQL.Server;
using ReDive_Bot.library.PrincessDataBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net.NetworkInformation;
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

namespace Endless_Development_Project_Studio.Pages
{
    /// <summary>
    /// ServerPage.xaml 的互動邏輯
    /// </summary>
    public partial class ServerPage : Page
    {
        SourceServer baseServer;
        SConnectToSQL cts = new SConnectToSQL();
        static Random r = new Random();
        public ServerPage()
        {
            InitializeComponent();

            this.Loaded += ServerPage_Loaded;
            //StringBuilder sb = new StringBuilder();
            //sb.Append("java -server -Xms1024M -Xmx10240M -XX:+DisableExplicitGC -XX:+UseConcMarkSweepGC -XX:+UseParNewGC -XX:+UseNUMA -XX:+CMSParallelRemarkEnabled -XX:MaxGCPauseMillis=50 -XX:+UseAdaptiveGCBoundary -XX:-UseGCOverheadLimit -XX:+UseBiasedLocking -XX:SurvivorRatio=8 -XX:TargetSurvivorRatio=90 -XX:MaxTenuringThreshold=15 -XX:UseSSE=3 -XX:+UseFastAccessorMethods -XX:+UseStringCache -XX:+UseCompressedOops -XX:+OptimizeStringConcat -XX:+UseFastAccessorMethods -XX:+AggressiveOpts");
            //sb.Append(" -jar");
            //sb.Append(@" E:\OwO-Server\Server\Server_Start.jar");
            //sb.Append(" nogui");

            //baseServer = new SourceServer(sb.ToString(), @"E:\OwO-Server\Server\");
            //baseServer.OutPutEvent += BaseServer_OutPutEvent;
        }
        List<string> ServerSettingsNames = new List<string>();
        private void SqlNotification_MessageEvent(TableDependency.SqlClient.Base.Enums.ChangeType changeType, SQL.Server.ServerEvents msg)
        {

            foreach (var item in ServerSave.Settings)
            {
                ServerSettingsNames.Add(item.Title);
            }

            if (msg.ServerEventType == "StartServer")
            {
                if (ServerSettingsNames.Contains(msg.Info))
                {
                    var obj = ServerSave.Settings.Where(x => x.Title == msg.Info).LastOrDefault();
                    string @jarfile = obj.JarFile;
                    string @serverPath = obj.StartFolder;
                    StringBuilder ParameterStringBuilder = new StringBuilder();
                    ParameterStringBuilder.Append("-server");
                    ParameterStringBuilder.Append($" {obj.MinRam}");
                    ParameterStringBuilder.Append($" {obj.MaxRam}");
                    ParameterStringBuilder.Append($" {obj.Parameter}");
                    ParameterStringBuilder.Append(" -jar");
                    ParameterStringBuilder.Append($" \"\"{@jarfile}\"\"");
                    ParameterStringBuilder.Append(" nogui");
                    Process p = new Process();
                    var path = @serverPath;

                    Console.WriteLine("\"" + ParameterStringBuilder.ToString() + "|" + path + "\"");
                    p.StartInfo.Arguments = " \" " + ParameterStringBuilder.ToString() + "|" + path + " \"";
                    p.StartInfo.FileName = "C:\\EDP\\Builds\\EDP-External_Output.exe";
                    p.Start();
                }
            }
            else if (msg.ServerEventType == "Check")
            {
                cts.SetServerData(new ServerEvents { ServerEventType = "Notification", Info = "From EDP - ServerSide" + cts.conn.ClientConnectionId, Direct = "Notification", ID = "C" + r.Next().ToString() });
            }
        }
        SQL.Server.SqlNotificationDependency sqlNotification;
        private void ServerPage_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                foreach (var item in ServerSave.Settings)
                {
                    ComplexControl.Items.Add(new ServerSettingsControlViewModel(item.serverid));
                }
            });
            sqlNotification = new SQL.Server.SqlNotificationDependency();

            sqlNotification.MessageEvent += SqlNotification_MessageEvent;
        }
        public static bool PingHost(string hostUri, int portNumber)
        {
            try
            {
                using (var client = new TcpClient(hostUri, portNumber))
                    return true;
            }
            catch (SocketException ex)
            {
                return false;
            }
        }
        private async Task PingToServer()
        {

            Ping p = new Ping();
            while (true)
            {
                try
                {
                    if (!PingHost(Config.ConnectionStringEDP, 1433))
                    {
                        await ReconnectToServer();
                    }
                }
                catch
                {
                    await ReconnectToServer();
                }
                await Task.Delay(10000);
            }
        }

        private async Task ReconnectToServer()
        {
            Ping p = new Ping();
            while (true)
            {
                try
                {
                    if (PingHost(Config.ConnectionStringEDP, 1433))
                    {
                        try
                        {
                            sqlNotification.ErrorEvent -= SqlNotification_ErrorEvent;
                            sqlNotification.MessageEvent -= SqlNotification_MessageEvent;
                        }
                        catch
                        { }
                        sqlNotification = new SQL.Server.SqlNotificationDependency();
                        try
                        {
                            sqlNotification.ErrorEvent += SqlNotification_ErrorEvent;
                            sqlNotification.MessageEvent += SqlNotification_MessageEvent;
                        }
                        catch
                        { }
                    }
                }
                catch
                {

                }
                await Task.Delay(10000);
            }
        }
        private void SqlNotification_ErrorEvent(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs msg)
        {
            
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
                                { }
                                //  OPC.AddToOutput("fff", log.Split(']')[0] + "]", log.Replace(log.Split(']')[0] + "]", ""));
                                else
                                { }
                //   OPC.AddToOutput("fff", "", log);
            }
            catch { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComplexControl.Items.Add(new ServerSettingsControlViewModel(ServerSave.GetSettings((ulong)ServerSave.Settings.Count).serverid));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RemoteServerWindow remote = new RemoteServerWindow();
            remote.Show();
        }
    }
}
