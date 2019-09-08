using Endless_Development_Project_Studio.DataStorage;
using Newtonsoft.Json;
using ReDive_Bot.library.PrincessDataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDive_Bot.DataStorage
{
    public static class StorageData
    {
        public static void SaveAccount(IEnumerable<AccountModel> princesses, string TargetFile)
        {
            if (!Directory.Exists("Library")) Directory.CreateDirectory("Library");
            string jsonConvert = JsonConvert.SerializeObject(princesses, Formatting.Indented);
            File.WriteAllText(TargetFile, jsonConvert);
        }
        public static IEnumerable<AccountModel> LoadAccount(string TargetFile)
        {
            if (!File.Exists(TargetFile)) return null;
            string jsonConvert = File.ReadAllText(TargetFile);
            return JsonConvert.DeserializeObject<List<AccountModel>>(jsonConvert);
        }
        public static bool CheckFileExists(string TargetFile)
        {
            return File.Exists(TargetFile);
        }
    }
}

