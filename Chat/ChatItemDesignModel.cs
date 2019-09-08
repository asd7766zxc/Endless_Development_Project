using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Pro_NCP
{
    class ChatItemDesignModel: ChatItemViewModel
    {
        public static ChatItemDesignModel Instance
        => new ChatItemDesignModel();

        public ChatItemDesignModel()
        {
            AvatarUrl = "";
        }
    }
}
