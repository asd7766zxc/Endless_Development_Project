using Chat_Pro_NCP;
using Endless_Development_Project_Studio.Connection;
using Endless_Development_Project_Studio.SQL;
using Endless_Development_Project_Studio.SQL.Chat;
using Endless_Development_Project_Studio.WebConnection;
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

/// <summary>
/// ChatPage.xaml 的互動邏輯
/// </summary>
public partial class ChatPage : BasePage<ChatPageViewModel>
{
    SQLChat sqlchat = new SQLChat();
    WebClient wc = new WebClient();
    List<Message> Messages = new List<Message>();
    public ChatPage()
    {
        this.Loaded += ChatPage_Loaded;

        InitializeComponent();
    }

    private void ChatPage_Loaded(object sender, RoutedEventArgs e)
    {
        wc.OnRecived += Wc_OnRecived;
        wc.Connect();
        this.outputtb.IsReadOnly = true;
    }

    private void Wc_OnRecived(string parameter)
    {
        Dispatcher.Invoke(() => { outputtb.Text += parameter + "\n"; });
    }

    private void Sqlchat_MessageEvent(List<Message> msg)
    {
        var offset = msg.Count - Messages.Count;
        if (offset != 0)
        {
            var buffers = msg.ToList();
            buffers.RemoveRange(0, Messages.Count);
            Messages = msg;
        
            foreach (var buffer in buffers)
            {
                AddMessage(buffer);
            }
        }
    }

    private void Inputtb_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            if (!string.IsNullOrEmpty(inputtb.Text))
                if (!string.IsNullOrWhiteSpace(inputtb.Text))
                {
                    wc.Chat(inputtb.Text);
                    inputtb.Text = "";
                }
        
    }

    private void AddMessage(Message msg)
    {
        Dispatcher.Invoke(() => { outputtb.Text += msg.user+": " +msg.message+ "\n"; });
    }
    private void Main_client_MessageEvent(string Message)
    {
        Dispatcher.Invoke(() => { outputtb.Text += Message +"\n"; });
    }
}

