using Endless_Development_Project_Studio.Server;
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
        public ServerPage()
        {
            InitializeComponent();
            StringBuilder sb = new StringBuilder();
            sb.Append("java -server -Xms1024M -Xmx10240M -XX:+DisableExplicitGC -XX:+UseConcMarkSweepGC -XX:+UseParNewGC -XX:+UseNUMA -XX:+CMSParallelRemarkEnabled -XX:MaxGCPauseMillis=50 -XX:+UseAdaptiveGCBoundary -XX:-UseGCOverheadLimit -XX:+UseBiasedLocking -XX:SurvivorRatio=8 -XX:TargetSurvivorRatio=90 -XX:MaxTenuringThreshold=15 -XX:UseSSE=3 -XX:+UseFastAccessorMethods -XX:+UseStringCache -XX:+UseCompressedOops -XX:+OptimizeStringConcat -XX:+UseFastAccessorMethods -XX:+AggressiveOpts");
            sb.Append(" -jar");
            sb.Append(@" E:\OwO-Server\Server\Server_Start.jar");
            sb.Append(" nogui");
         
            baseServer = new SourceServer(sb.ToString(), @"E:\OwO-Server\Server\");
            baseServer.OutPutEvent += BaseServer_OutPutEvent;
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
            baseServer.Start();
        }
    }
}
