using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.UPnPNetwork
{

    public class BaseServer
    {
        public delegate void ServerCommandHandler(string ip,string request);
        public event ServerCommandHandler CommandEvent;
        public TcpListener TcpServer;
        public Thread ServerThread;
        public void StartServer(int port)
        {
            UPnPTool.MakeUPnP(port);
            TcpServer = new TcpListener(UPnPTool.IPV4, port);

            ServerThread = new Thread(ServerTask);
            ServerThread.Start();
        }
        void ServerTask()
        {
            TcpServer.Start();
            while (true)
            {
                var client = TcpServer.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(processClient,client);
            }
        }
        public void SendLog(string log)
        {

        }
        void processClient(object obj)
        {
            var client = (TcpClient)obj;
            var Nw = client.GetStream();
            byte[] data = new byte[4096];
            int bytesRead;
            while (true)
            {
                bytesRead = 0;
                try
                {
                    bytesRead = Nw.Read(data,0,4096);

                }
                catch
                {
                    break;
                }
                if (bytesRead == 0)
                {

                }
                UnicodeEncoding ue = new UnicodeEncoding();
                CommandEvent?.Invoke(client.Client.RemoteEndPoint.ToString(),ue.GetString(data,0,bytesRead));
            }
        }
    }
}
