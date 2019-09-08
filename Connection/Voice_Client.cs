using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OMCS;
using OMCS.Contracts;
using OMCS.Boost;
using OMCS.Passive;
using OMCS.Passive.Audio;
using OMCS.Boost.MultiChat;
using Chat_Pro_NCP;
using NAudioDemo.NetworkChatDemo;

namespace Endless_Development_Project_Studio.Connection
{
    public class Voice_Client
    {
        public IMultimediaManager multimediaManager;
        
        public VoicePage voicePage;
        public Voice_Client()
        {
        }
        public void connetc(string chatid)
        {
                
        }
        void connectvoice()
        {
         
        }
        private void multimediaManager_ConnectionRebuildSucceed(IPEndPoint obj)
        {
            throw new NotImplementedException();
        }
     

        private void multimediaManager_ConnectionInterrupted(IPEndPoint obj)
        {
            throw new NotImplementedException();
        }
        
    }
}
