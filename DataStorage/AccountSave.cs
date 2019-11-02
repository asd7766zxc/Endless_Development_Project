using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endless_Development_Project_Studio.DataStorage;
using ReDive_Bot.DataStorage;

namespace ReDive_Bot.library.PrincessDataBase
{
    public static class AccountSave
    {
        public static List<AccountModel> _Account { get { return Account; } private set { } }
        private static List<AccountModel> Account;
        private static string TargetFile = "Library/Princesses.json";
        static AccountSave()
        {
            if (StorageData<AccountModel>.CheckFileExists(TargetFile))
            {
                Account = StorageData<AccountModel>.LoadAccount(TargetFile).ToList();
            }
            else
            {
                Account = new List<AccountModel>();
                SaveAccountContainer();
            }
        }
        public static void SaveAccountContainer()
        {
            StorageData<AccountModel>.SaveAccount(Account, TargetFile);
        }
        public static AccountModel GetAccount(ulong id)
        {
            var ResourcesTarget = from Target in Account where Target.uuid == id select Target;
            var princess = ResourcesTarget.FirstOrDefault();
            if (princess == null)
            {
                princess = CreatePrincess(id);
            }
            return princess;
        }
        public static bool AccountOverCover(ulong id)
        {
            try
            {
                bool quest = false;
                var ResourcesTarget = from Target in Account where Target.uuid == id select Target;
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
        private static AccountModel CreatePrincess(ulong id)
        {
            var account = new AccountModel
            {
               name="Empty",
               randompass="Empty",
            };
            Account.Add(account);
            SaveAccountContainer();
            return account;
        }
    }
}
