using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.Logger
{
    public class ConsoleOuputHandler : TextWriter
    {
        static StackTrace stackTrace = new StackTrace();
        public override Encoding Encoding { get { return Encoding.Unicode; } }
        public override void Write(string value)
        {
            string path = "";
            foreach (var i in stackTrace.GetFrames())
            {
                path += i.GetMethod().Name + " -> ";
            }

            Logger.ConsoleLogger.Log(path+" "+ value);

            base.Write(value);
        }
        public override void WriteLine(string value)
        {
            string path = "";
            foreach (var i in stackTrace.GetFrames())
            {
                path += i.GetMethod().Name + " -> ";
            }

            Logger.ConsoleLogger.Log(path + " " + value);


            base.WriteLine(value);
        }

    }
}
