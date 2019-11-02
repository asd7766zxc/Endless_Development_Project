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

namespace Endless_Development_Project_Studio.Pages
{
    /// <summary>
    /// HomePage.xaml 的互動邏輯
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            InformationWindowPageContainer.Content = iwp;
        
        }
        InformationWindowPage iwp = new InformationWindowPage();
        private void InformationWindowPageContainer_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            awaitHeigh();
          
            InformationWindowPageContainer.MouseLeave -= InformationWindowPageContainer_MouseLeave;
            InformationWindowPageContainer.MouseMove += InformationWindowPageContainer_MouseMove;
        }

        private void InformationWindowPageContainer_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            InformationWindowPageContainer.Height = 450;
            iwp.AnimateIn();
           
            InformationWindowPageContainer.MouseMove -= InformationWindowPageContainer_MouseMove;
            EventRegeits();
        }

        async Task awaitHeigh()
        {
            Task.Delay(10);
            if (this.ActualHeight > 1000)
                await iwp.AnimateOut((float)(this.ActualHeight - 32 - InformationWindowPageContainer.Height + 90));
            else
                await iwp.AnimateOut((float)(this.ActualHeight - 32 - InformationWindowPageContainer.Height + 82));
         
        }
        async Task awaitHeighB()
        {

            await iwp.AnimateIn();
         
            await Task.Delay(1000);
        
          //  if (this.WindowState == WindowState.Maximized)
               // await iwp.AnimateOut((float)(this.ActualHeight - 32 - InformationWindowPageContainer.Height + 90));
           // else
                await iwp.AnimateOut();

        }
        async Task EventRegeits()
        {
            await Task.Delay(500);
            InformationWindowPageContainer.MouseLeave += InformationWindowPageContainer_MouseLeave;
        }
    }
}
