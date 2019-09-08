using Endless_Development_Project_Studio.WindowFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.Containers
{
    public static class WindowsContainerList
    {
        public static Dictionary<uint, FrameControl> Windows { get; set; }
        public static Random RWindows { get; set; }
        public static uint OnTop { get; set; }
        static WindowsContainerList()
        {
            Windows = new Dictionary<uint, FrameControl>();
            RWindows = new Random();
        }
    }
}
