using DiscordRpcDemo;
using Endless_Development_Project_Studio.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Endless_Development_Project_Studio.Discord
{
    public class Player_RPC
    {
        private DiscordRpc.RichPresence presence;

        DiscordRpc.EventHandlers handlers;
       


        /*
		=============================================
		Private
		=============================================
		*/

        /// <summary>
        /// Initialize the RPC.
        /// </summary>
        /// <param name="clientId"></param>
        private void Initialize(string clientId)
        {
            
            handlers = new DiscordRpc.EventHandlers();

            handlers.readyCallback = ReadyCallback;
            handlers.disconnectedCallback += DisconnectedCallback;
            handlers.errorCallback += ErrorCallback;

            DiscordRpc.Initialize(clientId, ref handlers, true, null);

            this.SetStatusBarMessage("Initialized.");
        }
        bool locker = true;
        DateTime dt = new DateTime(2050,1,1,1,1,1,1);
        /// <summary>
        /// Update the presence status from what's in the UI fields.
        /// </summary>
        public void UpdatePresence(string largeImageKey,string largeImageText,string smallImageKey,string name)
        {
            presence.details = largeImageText;
            presence.state = "Alpha Test "+name;

            if (locker)
            {
                //ToDo: SomeThing Test
                presence.startTimestamp = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000 ) / 10000000;
                locker = false;
            }

            presence.largeImageKey = largeImageKey;
            presence.largeImageText = largeImageText;
            presence.smallImageKey = smallImageKey;
            presence.smallImageText = name;

            DiscordRpc.UpdatePresence(ref presence);

            this.SetStatusBarMessage("Presence updated.");
        }

        /// <summary>
        /// Calls ReadyCallback(), DisconnectedCallback(), ErrorCallback().
        /// </summary>
        private void RunCallbacks()
        {
            DiscordRpc.RunCallbacks();

            this.SetStatusBarMessage("Rallbacks run.");
        }

        /// <summary>
        /// Stop RPC.
        /// </summary>
        public void Shutdown()
        {
            DiscordRpc.Shutdown();

            this.SetStatusBarMessage("Shuted down.");
        }

        /// <summary>
        /// Called after RunCallbacks() when ready.
        /// </summary>
        private void ReadyCallback()
        {
            this.SetStatusBarMessage("Ready.");
        }

        /// <summary>
        /// Called after RunCallbacks() in cause of disconnection.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        private void DisconnectedCallback(int errorCode, string message)
        {
            this.SetStatusBarMessage(string.Format("Disconnect {0}: {1}", errorCode, message));
        }

        /// <summary>
        /// Called after RunCallbacks() in cause of error.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        private void ErrorCallback(int errorCode, string message)
        {
            this.SetStatusBarMessage(string.Format("Error {0}: {1}", errorCode, message));
        }

        /// <summary>
        /// Just set a message to be displayed in the status bar at the window's bottom.
        /// </summary>
        /// <param name="message"></param>
        private void SetStatusBarMessage(string message)
        {
          
        }

        /// <summary>
        /// Convert a DateTime object into a timestamp.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private long DateTimeToTimestamp(DateTime dt)
        {
            return (DateTime.Now.Ticks - 621355968000000000) / 10000000;
        }

        /*
		=============================================
		Event
		=============================================
		*/

        public void initialize()
        {
            string clientId = "618756304072081427";
            bool isNumeric = ulong.TryParse(clientId, out ulong n);

            if (!isNumeric)
            {
            

                return;
            }

            this.Initialize(clientId);
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            initialize();
        }

     

   
    }
}
