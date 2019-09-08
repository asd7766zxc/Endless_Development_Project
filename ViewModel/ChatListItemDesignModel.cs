using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chat_Pro_NCP
{
    public class ChatListItemDesignModel:ChatlistItemViewModel
    {

        public static ChatListItemDesignModel Instance
        => new ChatListItemDesignModel();
       
        public ChatListItemDesignModel()
        {
            Initials = "UN";
            Name = "Unknown";
            Message = "Unknown";
            ProfilePictrueRGB = "AA565656";
        }
    }
}