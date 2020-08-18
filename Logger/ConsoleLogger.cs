using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.Logger
{
    public static class ConsoleLogger
    {
        public static Random rand = new Random();
        public static int hash;

        public static long Date;
        static StackTrace stackTrace = new StackTrace();
        static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                
                return true;
            }


            return false;
        }

        public static void Log(string log, [CallerMemberName] string origin = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {

            try
            {
                if (File.Exists("C:\\EDP\\Log\\" + "Log " + hash + " - " + Date + ".txt"))
                {
                    if (!IsFileLocked(new FileInfo("C:\\EDP\\Log\\" + "Log " + hash + " - " + Date + ".txt")))
                        using (StreamWriter sw = File.AppendText("C:\\EDP\\Log\\" + "Log " + hash + " - " + Date + ".txt"))
                        {

                            sw.WriteLine("[" + filePath + "] " + origin + " -> line: " + lineNumber + " ->" + log);
                        }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText("C:\\EDP\\Log\\" + "Log " + hash + " - " + Date + ".txt"))
                    {

                        sw.WriteLine("[" + filePath + "] " + origin + " -> line: " + lineNumber + " ->" + log);
                    }
                }
            }
            catch
            { }
        }
    }
}
