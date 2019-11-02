using Endless_Development_Project_Studio.Connection.AppClients;
using Endless_Development_Project_Studio.Discord;
using Endless_Development_Project_Studio.SQL;
using Server_Restart_Final.SocketClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.Connection
{
    public static class SocketStatus
    {
        public static int Page = 0;
        public static Clients GlobalSynchronizeClient = new Clients();
    //    static CheckClient cClient = new CheckClient();
        public static string UserName { get; set; }
        public static event ReceiveDataHandler LoginComplect;
        public static Voice_Client voice_Client = new Voice_Client();
        public static VoiceUserEvent voiceUserEvent = new VoiceUserEvent();
        public static string GetIpAddress { get { return Dns.GetHostAddresses("cr-reports.ddns.net").Where(x => x.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString(); } private set { } }
        public static dboReport Account;
     //   public static Player_RPC player_RPC = new Player_RPC();
      //  public static MainClient main_client = new MainClient();
        public static Random GlobalRandom = new Random();
        static SocketStatus()
        {
            SocketStatus.GlobalSynchronizeClient.Setup();
        }
        public static void Login(string ac, string ps)
        {
            // cClient.Connect(Dns.GetHostAddresses("cr-reports.ddns.net").Where(x => x.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString(), 14330, $"L?{ac}|{ps}");
          
           // cClient.Connect(Dns.GetHostAddresses("cr-reports.ddns.net").Where(x => x.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString(), 10127, $"L?{ac}|{ps}");
        }
        public static void L(string l)
        {
            Page = 1;
            LoginComplect?.Invoke(l);
        }
        public static void Logout()
        {
         
            //cClient.Send(Encoding.UTF8.GetBytes("Logout?"));
        }

        private static void CClient_MessageEvent(string Message)
        {
            Page = 1;
            LoginComplect?.Invoke(Message);
            UserName = Message;
          //  try { main_client.Connect("cr-reports.ddns.net", 14330); } catch { }
        }
        public static void Close()
        {
            //if (cClient.Connected())
            //    cClient.MainClient.Disconnect(false);
         //   try { cClient.MainClient.Disconnect(false); } catch { }
           // try { main_client.BaseClient.Disconnect(false); } catch { }
          
        }
    }
}
