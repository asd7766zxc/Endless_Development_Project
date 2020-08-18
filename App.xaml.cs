using Endless_Development_Project_Studio.Connection;
using Endless_Development_Project_Studio.Logger;
using Endless_Development_Project_Studio.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Endless_Development_Project_Studio
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        static long Date = DateTime.Now.ToFileTimeUtc();
       public static Random rand = new Random();
    

    static int hash = rand.Next();
        public App()
        {
            ProcessThreadCollection currentThreads = Process.GetCurrentProcess().Threads;
            hash = rand.Next();
            Date = DateTime.Now.ToFileTimeUtc(); 
            foreach (ProcessThread thread in currentThreads)
            {
                Console.WriteLine(thread.Id);
            }
           
          
            Logger.ConsoleLogger.hash = hash;
            Logger.ConsoleLogger.Date = Date;
           
            ConsoleOuputHandler consoleOuput = new ConsoleOuputHandler();
            DebuggerRedirectListener DRL = new DebuggerRedirectListener();
            if (!Directory.Exists("C:\\EDP\\Log\\"))
            {
                Directory.CreateDirectory("C:\\EDP\\Log\\");
            }
            
            Debug.Listeners.Add(DRL);
            Console.SetOut(consoleOuput);


            Logger.ConsoleLogger.Log("Start Logging");
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
            this.Exit += App_Exit;
        }

        private void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Logger.ConsoleLogger.Log("AssemblyLoad "+args.LoadedAssembly.CodeBase);
        }

        private void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            string path = "";
            foreach (var i in stackTrace.GetFrames())
            {
                path += i.GetMethod().Name + " -> ";
            }

            Logger.ConsoleLogger.Log(e.Exception.StackTrace.ToString() + " " + e.Exception);
        }

        static StackTrace stackTrace = new StackTrace();
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string path = "";
            foreach (var i in stackTrace.GetFrames())
            {
                path += i.GetMethod().Name + " -> ";
            }

            Logger.ConsoleLogger.Log(path+" "+e.ExceptionObject.GetType());
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
        
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginWindow Lm = new LoginWindow();
            Lm.Show();
        }
    }
}
