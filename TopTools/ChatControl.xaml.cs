using Chat_Pro_NCP;
using Endless_Development_Project_Studio.Connection;
using Endless_Development_Project_Studio.Managers;
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

namespace Endless_Development_Project_Studio.TopTools
{
    /// <summary>
    /// ChatControl.xaml 的互動邏輯
    /// </summary>
    public partial class ChatControl : UserControl
    {
        int UnReadMessageCount = 0;
        public ChatControl()
        {
            InitializeComponent();
            MainContainer.Content = PageManager.Instance.PageComplex["Chat"];
            SocketStatus.MessageEvent += SocketStatus_MessageEvent;
            MainContainer.Visibility = Visibility.Visible;
            this.Loaded += ChatControl_Loaded;
        }

        private void ChatControl_Loaded(object sender, RoutedEventArgs e)
        {
            MainContainer.Visibility = Visibility.Collapsed;
        }
        bool AnimationLock = true;
        Storyboard storyboard1 = new Storyboard();
        Storyboard storyboard = new Storyboard();
        private void SocketStatus_MessageEvent()
        {
            UnReadMessageCount++;
            if (ContentExpandsion)
            {
                Dispatcher.Invoke(() =>
                { NewMessageCount.Content = UnReadMessageCount; });
                if (AnimationLock)
                {
                    AnimationLock = false;
                    Dispatcher.Invoke(() =>
                    {
                        NewMessageCount.Content = UnReadMessageCount;

                        NewMessageCount.Opacity = 1;
                        NewMessageCountRect.Opacity = 1;

                    });
                }
            }
        }





        bool ContentExpandsion = true;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ContentExpandsion)
            {
                MainContainer.Visibility = Visibility.Visible;
                ContentExpandsion = false;
                if (!AnimationLock)
                {
                    Dispatcher.Invoke(() =>
                    {
                        NewMessageCount.Opacity = 0;
                        NewMessageCountRect.Opacity = 0;
                    });
                }
                AnimationLock = true;
               
                UnReadMessageCount = 0;
            }
            else
            {
                MainContainer.Visibility = Visibility.Collapsed;
                ContentExpandsion = true;
            }
        }
    }
}
