using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.Logger
{
    public class DebuggerRedirectListener : TraceListener
    {
        static StackTrace stackTrace = new StackTrace();
        public override void Write(string message)
        {
            string path = "";
            foreach (var i in stackTrace.GetFrames())
            {
                path += i.GetMethod().Name + " -> ";
            }

            Logger.ConsoleLogger.Log(path + " " + message);

          
        }

        public override void WriteLine(string message)
        {
            string path = "";
            foreach (var i in stackTrace.GetFrames())
            {
                path += i.GetMethod().Name + " -> ";
            }

            Logger.ConsoleLogger.Log(path + " " + message);

            
        }
    }
}
