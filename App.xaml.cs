using Endless_Development_Project_Studio.Connection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        public App()
        {

            this.Exit += App_Exit;
        }
       

        private void App_Exit(object sender, ExitEventArgs e)
        {
        
        }
    }
}
