using Endless_Development_Project_Studio.SQL;
using SuperSocket.ClientEngine;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.Connection.AppClients
{
    public class Clients
    {
        AsyncTcpSession BaseClient = new AsyncTcpSession();
       // Socket d = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.IPv4);
        public delegate void LogEventHandler(object Log);
        public event LogEventHandler LogEvent;
        public Clients()
        {
            BaseClient.Connected += Client_Connected;
            BaseClient.DataReceived += BaseClient_DataReceived;
            
        }
        public void SendString(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes("C "+text+"##");
            BaseClient.Send(buffer, 0, buffer.Length);
        }
        private void BaseClient_DataReceived(object sender, DataEventArgs e)
        {
            Logging(Encoding.UTF8.GetString(e.Data,e.Offset,e.Length));
        }
        public void Logging(string parameter)
        {
            LogEvent?.Invoke(parameter);
        }
        public void Login(dboReport Account)
        {
         //   StringRequestInfo D = new StringRequestInfo("Login",$"Login|{Account.Name},{Account.id},{Account.Channel}",new string[1]);
            byte[] buffer = Encoding.UTF8.GetBytes($"C Login|{Account.Name},{Account.id},{Account.Channel}##");
            BaseClient.Send(buffer, 0, buffer.Length);
        }
        public void Setup()
        {
            BaseClient.Connect(new IPEndPoint(IPAddress.Parse(SocketStatus.GetIpAddress), 9865));
        }
        private void Client_Connected(object sender, EventArgs e)
        {
            byte[] data = Encoding.Default.GetBytes("N/A");
            BaseClient.Send(data, 0, data.Length);
        }
    }
}
