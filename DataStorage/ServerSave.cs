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
                settings = StorageData<ServerSettingsModel>.LoadAccount(TargetFile).ToList();
            }
            else
            {
                settings = new List<ServerSettingsModel>();
                SaveSettingsContainer();
            }
        }
        public static void SaveSettingsContainer()
        {
            StorageData<ServerSettingsModel>.SaveAccount(Settings, TargetFile);
        }
        public static ServerSettingsModel GetSettings(ulong id)
        {
            var ResourcesTarget = from Target in Settings where Target.serverid == id select Target;
            var princess = ResourcesTarget.FirstOrDefault();
            if (princess == null)
            {
                return CreateSettings(id);
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
        private static ServerSettingsModel CreateSettings(ulong id)
        {
            var model = new ServerSettingsModel
            {
                Title = "None",
                JarFile = "",
                MaxRam = "-Xmx10240M",
                MinRam = "-Xms1024M",
                ChangeDate = DateTime.Now.ToString(),
                serverid = id,
                Parameter = "",
            };
            Settings.Add(model);
            SaveSettingsContainer();
            return model;
        }
    }
}
