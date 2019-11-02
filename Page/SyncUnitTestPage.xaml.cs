using Endless_Development_Project_Studio.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Endless_Development_Project_Studio
{
    /// <summary>
    /// SyncUnitTestPage.xaml 的互動邏輯
    /// </summary>
    public partial class SyncUnitTestPage : Page
    {
        public SyncUnitTestPage()
        {
            InitializeComponent();
            SynchronizeClient SyncClient = new SynchronizeClient();
            SyncClient.LogEvent += SyncClient_LogEvent;
            Task.Run(()=>{ SyncClient.Start(); });
        }

        private void SyncClient_LogEvent(object Log)
        {
            Dispatcher.Invoke(() => {
                D.AppendText((string)Log);
            });
        }
    }
}
