using Endless_Development_Project_Studio.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Management;

namespace Endless_Development_Project_Studio.Server
{
    public class SourceServer
    {
        public Process ServerProcess { get; set; }
        public int ID { get; set; }
        public ProcessStartInfo ServerStartInfo { get; set; }
        public delegate void OutPutEventHandler(DataReceivedEventArgs e);
        public event OutPutEventHandler OutPutEvent;
        public delegate void CloseEventHandler();
        public event CloseEventHandler CloseEvent;
        public string StartUpFolder { get; set; }
        public Thread ServerThread { get; set; }
        public string ServerParameter { get; set; }
        public SourceServer(string parameter,string startupfolder)
        {
            ServerParameter = parameter;
            StartUpFolder = startupfolder;
            ServerProcess = new Process();
            ServerStartInfo = new ProcessStartInfo();
            ServerStartInfo.CreateNoWindow = true;
            ServerStartInfo.Arguments = ServerParameter;
            ServerStartInfo.FileName = "java";
            ServerStartInfo.RedirectStandardOutput = true;
            ServerStartInfo.RedirectStandardInput = true;
            ServerStartInfo.WorkingDirectory = startupfolder;
            ServerStartInfo.UseShellExecute = false;
        }
        public void Start()
        {
            ServerThread = new Thread(StartServer);
            ServerThread.Start(ServerStartInfo);
        }
        private void StartServer(object parameter)
        {
            var parameters = (ProcessStartInfo)parameter;
            ServerProcess = new Process();
            ServerProcess.StartInfo = parameters;
            ServerProcess.Start();
            
            ChildProcessTracker.AddProcess(ServerProcess);
            ID = ServerProcess.Id;
            Logger.ConsoleLogger.Log(ServerProcess.ProcessName);
            ServerProcess.OutputDataReceived += (sender,e) => OutPutEvent?.Invoke(e);
            ServerProcess.BeginOutputReadLine();
            ServerProcess.WaitForExit();
            CloseEvent?.Invoke();
        }
        public async Task Write(string command)
        {
            try
            {
                await ServerProcess.StandardInput.WriteLineAsync(command);
            }
            catch { }
        }
        public async Task Close()
        {
            try
            {
                ServerProcess.Kill();
            }
            catch { }
        }
    
    }
}
