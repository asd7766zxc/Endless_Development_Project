using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endless_Development_Project_Studio.DataStorage;
using ReDive_Bot.DataStorage;

namespace ReDive_Bot.library.PrincessDataBase
{
    public static class ServerSave
    {
        public static List<ServerSettingsModel> Settings { get { return settings; } private set { } }
        private static List<ServerSettingsModel> settings;
        private static string TargetFile = "Library/ServerSettings.json";
        static ServerSave()
        {
            if (StorageData<ServerSettingsModel>.CheckFileExists(TargetFile))
            {
                Settings = StorageData<ServerSettingsModel>.LoadAccount(TargetFile).ToList();
            }
            else
            {
                Settings = new List<ServerSettingsModel>();
                SaveSettingsContainer();
            }
        }
        public static void SaveSettingsContainer()
        {
            StorageData<ServerSettingsModel>.SaveAccount(Settings, TargetFile);
        }
        public static ServerSettingsModel GetAccount(ulong id)
        {
            var ResourcesTarget = from Target in Settings where Target.serverid == id select Target;
            var princess = ResourcesTarget.FirstOrDefault();
            if (princess == null)
            {
                return null;
            }
            return princess;
        }
        public static bool AccountOverCover(ulong id)
        {
            try
            {
                bool quest = false;
                var ResourcesTarget = from Target in Settings where Target.serverid == id select Target;
                var princess = ResourcesTarget.FirstOrDefault();
                if (princess == null)
                {
                    quest = true;
                }
                return quest;
            }
            catch
            {
                return false;
            }
        }
        private static ServerSettingsModel CreateSettings(ServerSettingsModel model)
        {
            Settings.Add(model);
            SaveSettingsContainer();
            return model;
        }
    }
}
