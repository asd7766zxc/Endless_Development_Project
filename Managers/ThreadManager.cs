using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.Managers
{
    public class ThreadManager 
    {
        public static ThreadManager Instance
            => new ThreadManager();

        public void ConnectStart(ThreadStart action)
        {
            Thread ConnectThread;
            ConnectThread = new Thread(action);
            ConnectThread.Start();
        }
    }
}
