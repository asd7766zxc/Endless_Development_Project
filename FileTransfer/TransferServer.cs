using Endless_Development_Project_Studio.FileTransfer.NetworkTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Endless_Development_Project_Studio.FileTransfer
{
    public class TransferServer
    {
        public List<TransferQueue> QueueList = new List<TransferQueue>();
        public Dictionary<string, QueueInformation> QueueInfoList = new Dictionary<string, QueueInformation>();
        public int OverallProgress;
        public bool isServerRunning { get; set; }
        public TransferClient transferClient;
        private string outputfolder;
        private Timer tmrOverallprog;
        private Listener listeners;
        public string HostName { get; set; }
        public int Port { get; set; }
        public TransferServer(string hostname, int port)
        {
            HostName = hostname;
            Port = port;
            listeners = new Listener();
            listeners.Accepted += Listener_Accepted;
        }
        public void StartServer(int Port)
        {
            if (isServerRunning)
                return;
            isServerRunning = true;
            try
            {
                listeners.Start(Port);
                setConnetionStaus("Waiting...");
            }
            catch
            {

            }
        }
        public void RegisterEvents()
        {
            transferClient.Complete += TransferClient_Complete;
            transferClient.Disconnected += TransferClient_Disconnected;
            transferClient.ProgressChanged += TransferClient_ProgressChanged;
            transferClient.Queued += TransferClient_Queued;
            transferClient.Stopped += TransferClient_Stopped;
        }
        public void SendFile(string filename)
        {
            if (transferClient == null)
                return;

            transferClient.QueueTransfer(filename);
        }
        public void PauseTransfer()
        {
            if (transferClient == null)
                return;

            foreach (TransferQueue queue in QueueList)
            {
                queue.Client.PauseTransfer(queue);
            }
        }

        public void StopTransfer()
        {
            if (transferClient == null)
                return;

            foreach (TransferQueue queue in QueueList)
            {
                queue.Client.StopTransfer(queue);
                QueueList.Remove(queue);
            }
            OverallProgress = 0;
        }

        public void ClearComplete()
        {
            foreach (TransferQueue queue in QueueList)
            {
                if (queue.Progress == 100 || !queue.Running)
                {
                    QueueList.Remove(queue);
                }
            }
        }
        private void TransferClient_Stopped(object sender, TransferQueue queue)
        {
            QueueList = new List<TransferQueue>();
        }

        private void TransferClient_Queued(object sender, TransferQueue queue)
        {
            QueueInfoList.Add(queue.ID.ToString(),new QueueInformation { FileName = queue.FileName, Type =  queue.Type == QueueType.Download ? "Download" : "Upload" ,Progress = 0 });
            QueueList.Add(queue);
            if (queue.Type == QueueType.Download)
            {
                transferClient.StartTransfer(queue);
            }
        }

        private void TransferClient_ProgressChanged(object sender, TransferQueue queue)
        {
            QueueInfoList[queue.ID.ToString()].Progress = queue.Progress;
        }

        private void TransferClient_Disconnected(object sender, EventArgs e)
        {
            DeregisterEvents();
            try
            {
                foreach (TransferQueue aqueue in QueueList)
                {
                    aqueue.Close();
                    QueueList.Remove(aqueue);
                }
            }
            catch { }
            QueueList = new List<TransferQueue>();

            transferClient = null;
            setConnetionStaus("null");
            if (isServerRunning)
            {
                listeners.Start(Port);
                setConnetionStaus("await");
            }
        }

        private void setConnetionStaus(string v)
        {
            throw new NotImplementedException();
        }

        private void TransferClient_Complete(object sender, TransferQueue queue)
        {
           
        }

        public void DeregisterEvents()
        {
            if (transferClient == null)
                return;

            transferClient.Complete -= TransferClient_Complete;
            transferClient.Disconnected -= TransferClient_Disconnected;
            transferClient.ProgressChanged -= TransferClient_ProgressChanged;
            transferClient.Queued -= TransferClient_Queued;
            transferClient.Stopped -= TransferClient_Stopped;
        }
        private void TmrOverallprog_Tick(object sender, EventArgs e)
        {
            if (transferClient == null)
                return;

            OverallProgress = transferClient.GetOverallProgress();
        }

        private void Listener_Accepted(object sender, SocketAcceptedEventArgs e)
        {
            listeners.Stop();
            transferClient = new TransferClient(e.Accepted);
            transferClient.OutputFolder = outputfolder;
            RegisterEvents();
            transferClient.Run();
            tmrOverallprog.Start();
            setConnetionStaus(transferClient.EndPoint.Address.ToString());
        }
    }
    public class QueueInformation
    {
        public string FileName { get; set; }
        public string Type { get; set; }
        public int Progress { get; set; }
    }
}
