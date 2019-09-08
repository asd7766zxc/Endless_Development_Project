using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless_Development_Project_Studio.WebConnection
{
    public class Channel
    {
        public string ChannelName { get; set; }
        public int ChannelID { get; set; }
        public string ConnectionString { get; set; }
        public List<int> ChannelMember { get; set; }
        public ChannelType ChannelSecurity { get; set; }
    }
    public enum ChannelType
    {
        Main,
        DM,
        Shelter,
        Central,
        Group
    }
}
