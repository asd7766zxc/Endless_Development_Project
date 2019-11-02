using Endless_Development_Project_Studio.SQL;
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
using System.Windows.Threading;

namespace Endless_Development_Project_Studio
{
    /// <summary>
    /// OnlinePage.xaml 的互動邏輯
    /// </summary>
    public partial class OnlinePage : Page
    {
        public OnlinePage()
        {
            cts = new ConnectToSQL();
            cts.Connect("cr-reports.ddns.net", 1433, "f");
            this.Loaded += OnlinePage_Loaded;
            InitializeComponent();
        }

        private void OnlinePage_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer DT = new DispatcherTimer();
            DT.Interval = TimeSpan.FromMilliseconds(500);
            DT.Tick += DT_Tick;
           
            DT.Start();
        }
        ConnectToSQL cts;
        private void DT_Tick(object sender, EventArgs e)
        {
            OnlinePlayer.Items.Clear();
            foreach (var i in cts.GetServerOnlineData(1))
            {
                OnlinePlayer.Items.Add(new Player { Name = i.Name });
            }

        }
    }
}
