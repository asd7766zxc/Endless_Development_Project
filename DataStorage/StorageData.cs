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
    public class StorageData<T>
    {
        public static StorageData<T> Instance => new StorageData<T>();
        public static void SaveAccount(IEnumerable<T> princesses, string TargetFile)
        {
            if (!Directory.Exists("Library")) Directory.CreateDirectory("Library");
            string jsonConvert = JsonConvert.SerializeObject(princesses, Formatting.Indented);
            File.WriteAllText(TargetFile, jsonConvert);
        }
        public static IEnumerable<T> LoadAccount(string TargetFile)
        {
            if (!File.Exists(TargetFile)) return null;
            string jsonConvert = File.ReadAllText(TargetFile);
            return JsonConvert.DeserializeObject<List<T>>(jsonConvert);
        }
        public static bool CheckFileExists(string TargetFile)
        {
            return File.Exists(TargetFile);
        }
    }
}

