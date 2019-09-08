using Endless_Development_Project_Studio.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Endless_Development_Project_Studio.Connection
{
    public class VoiceUserEvent
    {
        public event UpdatePlayerHandler UserUpdateEvent;
        public DispatcherTimer DT = new DispatcherTimer();
        public VoiceUserEvent()
        {
            DT.Interval = TimeSpan.FromMilliseconds(500);
            DT.Tick += DT_Tick;
        }
        public ConnectToSQL cts = new ConnectToSQL();
        private void DT_Tick(object sender, EventArgs e)
        {
            UserUpdateEvent?.Invoke(cts.GetServerInChatData(1));
        }

        public void Connect()
        {

            cts.Connect("cr-reports.ddns.net", 1433, "f");
         
            cts.SetPlayerInVoiceChat(SocketStatus.Account);
            DT.Start();
          
        }
    }
}
