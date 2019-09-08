
using Endless_Development_Project_Studio;

namespace Chat_Pro_NCP
{
    public class ChatlistItemViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string Initials { get; set; }
        public string ProfilePictrueRGB { get; set; }
        public bool NewContentAvailable { get; set; }
        public bool IsSelected { get; set; }
    }
}
