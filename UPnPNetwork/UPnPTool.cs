using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NATUPNPLib;

namespace Endless_Development_Project_Studio.UPnPNetwork
{
    public static class UPnPTool
    {
        public static string Name => Dns.GetHostName();
        public static IPAddress IPV4 => Dns.GetHostEntry(Name).AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
        public static UPnPNAT uPnPNAT = new UPnPNAT();
        public static IStaticPortMappingCollection PortMap => uPnPNAT.StaticPortMappingCollection;
        public static int RPort = 1523;
        public static string EIP = "";
        public static bool MakeUPnP(int port)
        {
            RPort = port;
            if (PortMap == null)
            {
                return false;
            }
            PortMap.Add(RPort,"TCP",RPort,IPV4.ToString(),true,"EDP-DynamicServer");
            return true;
        }
    }
}
