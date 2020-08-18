using Endless_Development_Project_Studio.TopTools;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Endless_Development_Project_Studio.EDP_GUI
{
    /// <summary>
    /// SideButtonMenu.xaml 的互動邏輯
    /// </summary>
    public partial class SideButtonMenu : UserControl
    {
        List<string> ListButtonContent;
        public SideButtonMenu()
        {
            ListButtonContent = new List<string>();
            ListButtonContent.Add("\xf233");
            ListButtonContent.Add("\xf07b");
            ListButtonContent.Add("\xf1ce");
            ListButtonContent.Add("\xf013");
            //    ListButtonContent.Add("\xf0c8");
            InitializeComponent();

            this.Loaded += SideButtonMenu_Loaded;
        }

        private void SideButtonMenu_Loaded(object sender, RoutedEventArgs e)
        {
            // MainStackPanel.Children.Add();
        }

        private void ButtonList_Loaded(object sender, RoutedEventArgs e)
        {

        }
        List<ButtonControlViewModel> Items = new List<ButtonControlViewModel>();
        bool AddLock = false;
        public async Task DelayAdd()
        {
            await ButtonList.Dispatcher.Invoke(async () =>
            {
                if (Items.Count == 0)
                {
                    AddLock = true;
                    foreach (var item in ListButtonContent)
                    {
                        await Task.Delay(100);
                        if (item == "\xf0c8")
                        {
                            Items.Add(new ButtonControlViewModel { ButtonContent = item, ButtonFontSize = 30, ButtonPadding = 5, Angle = 45, RotateCenter = 30, ButtonOpacity = 1 });
                            ButtonList.Items.Add(Items.LastOrDefault());
                        }
                        else
                        {
                            Items.Add(new ButtonControlViewModel { ButtonContent = item, ButtonFontSize = 30, ButtonPadding = 5, ButtonOpacity = 1 });
                            ButtonList.Items.Add(Items.LastOrDefault());
                        }
                    }
                }
            });

        }
        public async Task DelayRemove()
        {
            await Task.Delay(1000);
            if (!AddLock) return;
            await ButtonList.Dispatcher.Invoke(async () =>
            {
              
                    for (int i = Items.Count-1; i >= 0; i--)
                    {
                        await Task.Delay(100);
                        Items[i].Unload();

                    }
                foreach (var item in Items)
                {
                  ButtonList.Items.Remove(item);
                }
                  Items = new List<ButtonControlViewModel>();
            });
            AddLock = false;
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!AddLock)
                DelayAdd();
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (AddLock)
                DelayRemove();
        }

        private void ButtonList_MouseEnter(object sender, MouseEventArgs e)
        {
            AddLock = false;
        }

        private void ButtonList_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!AddLock)
                AddLock = true;
            DelayRemove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PublicRevokeStaticEvent.RevokeEvent("Home"); 
        }
    }
}
