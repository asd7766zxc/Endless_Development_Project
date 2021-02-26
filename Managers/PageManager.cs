using Chat_Pro_NCP;
using Endless_Development_Project_Studio.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Endless_Development_Project_Studio.Managers
{
    public class PageManager 
    {
        public Dictionary<string, Page> PageComplex { get; set; }
        public ChatItemCollectionsControl ChatPage { get; set; }
        public static PageManager Instance 
            => new PageManager();
        public PageManager()
        {
            ChatPage = new ChatItemCollectionsControl();
            PageComplex = new Dictionary<string, Page>();
            PageComplex.Add("Chat", ChatPage);
            PageComplex.Add("Home", new HomePage());
            PageComplex.Add("\xf233", new ServerPage());
            PageComplex.Add("\xf1ce", new GlobalPage());
            PageComplex.Add("Login", new LoginPage());
            PageComplex.Add("\xf07b", new ModPackSeasonPage());
            PageComplex.Add("\xf013", new ModPage());
        }
    }
}
