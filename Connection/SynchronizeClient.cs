using Endless_Development_Project_Studio.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.Connection
{
    public class SynchronizeClient
    {
        private static readonly Socket ClientSocket = new Socket
           (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private const int PORT = 1061;
        public delegate void LogEventHandler(object Log);
        public event LogEventHandler LogEvent;
        public void Start()
        {
            ConnectToServer();
            Task.Run(() => { RequestLoop(); });
            // Exit();
        }

        private void ConnectToServer()
        {
            int attempts = 0;

            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    Logging("Connection attempt " + attempts);
                    // Change IPAddress.Loopback to a remote IP to connect to a remote host.
                    ClientSocket.Connect(Dns.GetHostAddresses("cr-reports.ddns.net").Where(x => x.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString(), PORT);

                }
                catch (SocketException)
                {
                    // Console.Clear();
                }
            }

            ///Console.Clear();
            Logging("Connected");
        }

        private void RequestLoop()
        {
            Console.WriteLine(@"<Type ""exit"" to properly disconnect client>");

            while (true)
            {
                //SendRequest();
                ReceiveResponse();
            }
        }

        /// <summary>
        /// Close socket and exit program.
        /// </summary>
        private void Exit()
        {
            SendString("exit"); // Tell the server we are exiting
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
            Environment.Exit(0);
        }

        public void SendRequest()
        {
            Console.Write("Send a request: ");
            string request = Console.ReadLine();
            SendString(request);

            if (request.ToLower() == "exit")
            {
                Exit();
            }
        }

        /// <summary>
        /// Sends a string to the server with Unicode encoding.
        /// </summary>
        public void SendString(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }
        public void Login(dboReport Account)
        {
            byte[] buffer = Encoding.UTF8.GetBytes($"Login|{Account.Name},{Account.id},{Account.Channel}");
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private void ReceiveResponse()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.UTF8.GetString(data);
            Logging(text);
        }
        public void Logging(string parameter)
        {
            LogEvent?.Invoke(parameter);
        }
    }
}
