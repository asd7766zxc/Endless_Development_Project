using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chat_Pro_NCP
{
    public class ChatListDesignModel : ChatlistViewModel
    {


        public static ChatListDesignModel Instance
        => new ChatListDesignModel();

        public ChatListDesignModel()
        {

            Items = new List<ChatlistItemViewModel>
            {
                new ChatlistItemViewModel
                {
                    Name = "Shit",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FF0000",
                    NewContentAvailable = true
                },
                new ChatlistItemViewModel
                {
                    Name = "U n",
                    Initials = "GO",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FF525252",
                },
                new ChatlistItemViewModel
                {
                    Name = "Fuck",
                    Initials = "FC",
                    Message = "Unknown",
                    ProfilePictrueRGB = "AA565656",
                    IsSelected = true
                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "BDBDBD",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "4A148C",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FFEB3B",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "C8E6C9",

                },
                new ChatlistItemViewModel
                {
                    Name = "Shit",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FF0000",

                },
                new ChatlistItemViewModel
                {
                    Name = "U n",
                    Initials = "GO",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FF525252",
                },
                new ChatlistItemViewModel
                {
                    Name = "Fuck",
                    Initials = "FC",
                    Message = "Unknown",
                    ProfilePictrueRGB = "AA565656",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "BDBDBD",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "4A148C",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FFEB3B",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "C8E6C9",

                },  new ChatlistItemViewModel
                {
                    Name = "Shit",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FF0000",

                },
                new ChatlistItemViewModel
                {
                    Name = "U n",
                    Initials = "GO",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FF525252",
                },
                new ChatlistItemViewModel
                {
                    Name = "Fuck",
                    Initials = "FC",
                    Message = "Unknown",
                    ProfilePictrueRGB = "AA565656",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "BDBDBD",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "4A148C",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FFEB3B",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "C8E6C9",

                },
                new ChatlistItemViewModel
                {
                    Name = "Shit",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FF0000",

                },
                new ChatlistItemViewModel
                {
                    Name = "U n",
                    Initials = "GO",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FF525252",
                },
                new ChatlistItemViewModel
                {
                    Name = "Fuck",
                    Initials = "FC",
                    Message = "Unknown",
                    ProfilePictrueRGB = "AA565656",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "BDBDBD",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "4A148C",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FFEB3B",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "C8E6C9",

                },
                new ChatlistItemViewModel
                {
                    Name = "Shit",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FF0000",

                },
                new ChatlistItemViewModel
                {
                    Name = "U n",
                    Initials = "GO",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FF525252",
                },
                new ChatlistItemViewModel
                {
                    Name = "Fuck",
                    Initials = "FC",
                    Message = "Unknown",
                    ProfilePictrueRGB = "AA565656",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "BDBDBD",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "4A148C",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FFEB3B",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "C8E6C9",

                },  new ChatlistItemViewModel
                {
                    Name = "Shit",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FF0000",

                },
                new ChatlistItemViewModel
                {
                    Name = "U n",
                    Initials = "GO",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FF525252",
                   
                },
                new ChatlistItemViewModel
                {
                    Name = "Fuck",
                    Initials = "FC",
                    Message = "Unknown",
                    ProfilePictrueRGB = "AA565656",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "BDBDBD",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "4A148C",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "FFEB3B",

                },
                new ChatlistItemViewModel
                {
                    Name = "Unknown",
                    Initials = "UN",
                    Message = "Unknown",
                    ProfilePictrueRGB = "C8E6C9",

                },
            };
        }
    }
}