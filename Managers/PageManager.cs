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
        public static PageManager Instance 
            => new PageManager();
        public PageManager()
        {
            PageComplex = new Dictionary<string, Page>();
            PageComplex.Add("Chat", new ChatItemCollectionsControl());
            PageComplex.Add("Home", new HomePage());
            PageComplex.Add("Server", new ServerPage());
            PageComplex.Add("Global", new GlobalPage());
            PageComplex.Add("Login", new LoginPage());
            PageComplex.Add("Mod", new ModPage());
        }
    }
}
