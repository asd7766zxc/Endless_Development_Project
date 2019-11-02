using Endless_Development_Project_Studio.Connection;
using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.Server
{

    public class LogClient
    {
        AsyncTcpSession BaseClient = new AsyncTcpSession();
        // Socket d = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.IPv4);
        public delegate void LogEventHandler(object Log);
        public event LogEventHandler LogEvent;
        public LogClient()
        {
            BaseClient.Connected += Client_Connected;
            BaseClient.DataReceived += BaseClient_DataReceived;

        }
        public void SendString(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes("S " + text + "#BordercaseServerLog#");
            BaseClient.Send(buffer, 0, buffer.Length);
        }
        private void BaseClient_DataReceived(object sender, DataEventArgs e)
        {
            Logging(Encoding.UTF8.GetString(e.Data, e.Offset, e.Length));
        }
        public void Logging(string parameter)
        {
            LogEvent?.Invoke(parameter);
        }

        public void Setup()
        {
            BaseClient.Connect(new IPEndPoint(IPAddress.Parse(SocketStatus.GetIpAddress), 6865));
        }
        private void Client_Connected(object sender, EventArgs e)
        {
            byte[] data = Encoding.Default.GetBytes("N/A");
            BaseClient.Send(data, 0, data.Length);
        }


    }
}
