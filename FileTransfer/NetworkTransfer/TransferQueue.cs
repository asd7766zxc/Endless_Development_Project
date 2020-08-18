using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.FileTransfer.NetworkTransfer
{
    public enum QueueType : byte
    {
        Download,
        Upload
    }
    public class TransferQueue
    {
        public static TransferQueue CreateUploadQueue(TransferClient client, string filename)
        {
            try
            {
                var queu = new TransferQueue();
                queu.FileName = Path.GetFileName(filename);
                queu.Client = client;
                queu.Type = QueueType.Upload;
                queu.FS = new FileStream(filename, FileMode.Open);
                queu.Thread = new Thread(new ParameterizedThreadStart(transferProc));
                queu.Thread.IsBackground = true;
                queu.ID = App.rand.Next();
                queu.Length = queu.FS.Length;
                return queu;
            }
            catch
            {
                return null;
            }
        }
        public static TransferQueue CreateDownloadQueue(TransferClient client, int id, string savename, long lenght)
        {
            try
            {
                var queu = new TransferQueue();
                queu.FileName = Path.GetFileName(savename);
                queu.Client = client;
                queu.Type = QueueType.Download;
                queu.FS = new FileStream(savename, FileMode.Create);
                queu.FS.SetLength(lenght);
                queu.Length = lenght;
                queu.ID = id;
                return queu;
            }
            catch
            {
                return null;
            }
        }

        private const int FILE_BUFFER_SIZE = 8175;
        private static byte[] file_buffer = new byte[FILE_BUFFER_SIZE];

        private ManualResetEvent pauseEnevt;
        public int ID;
        public int Progress, LastProgress;

        public long TransferRead;
        public long Index;
        public long Length;

        public bool Running;
        public bool Paused;

        public string FileName;

        public QueueType Type;

        public TransferClient Client;
        public Thread Thread;
        public FileStream FS;

        public TransferQueue()
        {
            pauseEnevt = new ManualResetEvent(true);
            Running = true;
        }
        public void Start()
        {
            Running = true;
            Thread.Start(this);
        }
        public void Stop()
        {
            Running = false;
        }
        public void Pause()
        {
            if (!Paused)
            {
                pauseEnevt.Reset();
            }
            else
            {
                pauseEnevt.Set();
            }
            Paused = !Paused;
        }
        public void Close()
        {
            try
            {
                Client.Transfers.Remove(ID);
            }
            catch
            {

            }
            Running = false;
            FS.Close();
            pauseEnevt.Dispose();

            Client = null;
        }
        public void Write(byte[] bytes, long index)
        {
            lock (this)
            {
                FS.Position = index;
                FS.Write(bytes, 0, bytes.Length);
                TransferRead += bytes.Length;
            }
        }
        private static void transferProc(object o)
        {
            TransferQueue queue = (TransferQueue)o;
            while (queue.Running && queue.Index < queue.Length)
            {
                queue.pauseEnevt.WaitOne();
                if (!queue.Running)
                {
                    break;
                }
                lock (file_buffer)
                {
                    queue.FS.Position = queue.Index;
                    int read = queue.FS.Read(file_buffer, 0, file_buffer.Length);
                    PacketWriter pw = new PacketWriter();
                    pw.Write((byte)Headers.Chunk);
                    pw.Write(queue.ID);
                    pw.Write(queue.Index);
                    pw.Write(read);
                    pw.Write(file_buffer, 0, read);

                    queue.TransferRead += read;
                    queue.Index += read;
                    queue.Client.Send(pw.GetBytes());

                    queue.Progress = (int)((queue.TransferRead * 100) / queue.Length);

                    if (queue.LastProgress < queue.Progress)
                    {
                        queue.LastProgress = queue.Progress;
                        queue.Client.callProgressChanged(queue);
                    }
                    Thread.Sleep(1);
                }
            }
            queue.Close();
        }
    }
}
