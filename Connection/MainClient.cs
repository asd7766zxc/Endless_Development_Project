using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server_Restart_Final.SocketClient
{
    public class MainClient
    {
        public Socket BaseClient { get; set; }
        public NetworkStream ns { get; set; }

        public event MessageHandler MessageEvent;

        public MainClient()
        {
            BaseClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public bool Connected()
        {
            return BaseClient.Connected;
        }
        public void Connect(string ip, int port)
        {
            if (String.IsNullOrEmpty(ip)) return;
            var IPs = Dns.GetHostAddresses(ip);
            IPAddress IP = IPs.Where(x => x.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
            var ep = new IPEndPoint(IP, port);
            try
            {
                BaseClient.Connect(ep);
            }
            catch
            {
                return;
            }
            ns = new NetworkStream(BaseClient);
            Thread thread = new Thread(o => ReceiveData((Socket)o));
            thread.Start(BaseClient);

        }
        async void ReceiveData(Socket client)
        {
            string Msg = "";
            NetworkStream ns = new NetworkStream(client);
            byte[] receivedBytes = new byte[1024];
            int byte_count;
            try
            {
                while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
                {
                    Msg = Encoding.UTF8.GetString(receivedBytes, 0, byte_count);
                    MessageEvent?.Invoke(Msg);
                }
            }
            catch { }
        }

        public async Task Send(byte[] buffer)
        {
            byte[] Buffer = buffer;
            try
            {
                await ns.WriteAsync(Buffer, 0, Buffer.Length);
            }
            catch { }
            await Task.CompletedTask;
        }
    }
}
