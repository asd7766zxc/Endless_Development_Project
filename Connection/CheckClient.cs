using ReDive_Bot.library.PrincessDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.Connection
{
    public class CheckClient
    {
        public Socket MainClient { get; set; }
        public NetworkStream ns { get; set; }
        public event MessageHandler MessageEvent;

        public CheckClient()
        {
            MainClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public bool Connected()
        {
            return MainClient.Connected;
        }
        public void Connect(string ip, int port,string AP)
        {
            if (String.IsNullOrEmpty(ip)) return;
            var IPs = Dns.GetHostAddresses(ip);
            IPAddress IP = IPs.Where(x => x.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
            var ep = new IPEndPoint(IP, port);
            try
            {
                MainClient.Connect(ep);
            }
            catch
            {
                return;
            }
            
            ns = new NetworkStream(MainClient);
            Thread thread = new Thread(o => ReceiveData((Socket)o));
            thread.Start(MainClient);
            MainClient.Send(Encoding.UTF8.GetBytes(AP));
        }
        async void ReceiveData(Socket client)
        {
            string g = "";
            NetworkStream ns = new NetworkStream(client);
            byte[] receivedBytes = new byte[1024];
            int byte_count;
            try
            {
                while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
                {
                    g = Encoding.UTF8.GetString(receivedBytes, 0, byte_count);
                    if (g.Split('?')[0] == "C")
                    {
                        MessageEvent?.Invoke(g.Split('!')[1]);
                    }

                }
            }
            catch { }
        }

        public async Task Send(byte[] buffer)
        {
            byte[] Buffer = buffer;
            try
            {
                ns.WriteAsync(Buffer, 0, Buffer.Length);
            }
            catch
            {

            }

            await Task.CompletedTask;
        }
    }
}
