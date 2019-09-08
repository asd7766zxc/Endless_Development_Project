using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Endless_Development_Project_Studio.SQL
{
    public class ConnectToSQL
    {
        public SqlConnection conn;
        public List<dboReport> Report = new List<dboReport>();
        DataAcess asc = new DataAcess();

        public void Connect(string Host, int port, string userid, string userpas)
        {
            conn = new SqlConnection($"Server={Host},{port}; initial catalog = EDP-Users; user id = {userid}; password = {userpas}");
            conn.Open();
        }

        public void Connect(string Host, int port, string userid)
        {
            try
            {
                conn = new SqlConnection($"Server={Host},{port}; initial catalog = EDP-Users; user id = {userid}; password = uyliouphjytuupr");
                conn.Open();
            }
            catch(Exception e) {
                MessageBox.Show(e.Message);
            }
        }
        public List<dboReport> GetServerData(int id)
        {
            if (conn == null) return null;

            var report = asc.GetData(id, conn);
            return report;
        }
        public List<dboReport> GetServerDataByAccount(string id)
        {
            if (conn == null) return null;

            var report = asc.GetDataByAccount(id, conn);
            return report;
        }
        public List<dboReport> GetServerOnlineData(int Status)
        {
            if (conn == null) return null;

            var report = asc.GetOnlineData(Status, conn);
            return report;
        }
        public List<dboReport> GetServerInChatData(int Status)
        {
            if (conn == null) return null;

            var report = asc.GetInChatData(Status, conn);
            return report;
        }
        public void SetServerData(dboReport dboreport)
        {
            if (conn == null) return;
            asc.SetData(dboreport, conn);
        }
        public void SetPlayerOnline(dboReport dboreport)
        {
            if (conn == null) return;
            asc.SetOnline(dboreport, conn);
        }
        public void SetPlayerInVoiceChat(dboReport dboreport)
        {
            if (conn == null) return;
            asc.SetPlayerInChat(dboreport, conn);
        }

        public void SetPlayerOffline(dboReport dboreport)
        {
            if (conn == null) return;
            asc.SetOffline(dboreport, conn);
        }
        public void SetPlayerLeaveVoiceChat(dboReport dboreport)
        {
            if (conn == null) return;
            asc.SetPlayerLeaveChat(dboreport, conn);
        }
        public bool checkAccountExit(string account)
        {
           return asc.CheckAccountExit(account,conn);
        }
    
    }
    public class DataAcess
    {
        public List<dboReport> GetData(int id, SqlConnection conn)
        {
            IDbConnection ics = conn;
            return ics.Query<dboReport>($"select * from Users where id = {id}").ToList();
        }
        public List<dboReport> GetOnlineData(int State, SqlConnection conn)
        {
            IDbConnection ics = conn;
            return ics.Query<dboReport>($"select * from Users where OnlineNum = {State}").ToList();
        }
        public List<dboReport> GetInChatData(int State, SqlConnection conn)
        {
            IDbConnection ics = conn;
            return ics.Query<dboReport>($"select * from Users where InVoiceChat = {State}").ToList();
        }
        public List<dboReport> GetDataByAccount(string id, SqlConnection conn)
        {
            IDbConnection ics = conn;
            return ics.Query<dboReport>($"select * from Users where Account = {id}").ToList();
        }
        public bool CheckAccountExit(string Account, SqlConnection conn)
        {
            bool result = false;
            IDbConnection ics = conn;
            try
            {
                if (ics.Query<dboReport>($"IF EXISTS( SELECT * FROM Users WHERE Account = '{Account}' ) select * from Users where Account = {Account}").FirstOrDefault().Name == null)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch { result = false; }
            return result;
        }
        public void SetOnline(dboReport dbr, SqlConnection conn)
        {
            try
            {
                IDbConnection ics = conn;
                ics.Execute($"Update Users Set OnlineNum = 1 Where id = '{dbr.id}'");
            }
            catch { }
        }
        public void SetPlayerInChat(dboReport dbr, SqlConnection conn)
        {
            try
            {
                IDbConnection ics = conn;
                ics.Execute($"Update Users Set InVoiceChat = 1 Where id = '{dbr.id}'");
            }
            catch { }
        }
        public void SetPlayerLeaveChat(dboReport dbr, SqlConnection conn)
        {
            try
            {
                IDbConnection ics = conn;
                ics.Execute($"Update Users Set InVoiceChat = 0 Where id = '{dbr.id}'");
            }
            catch { }
        }
        public void SetOffline(dboReport dbr, SqlConnection conn)
        {
            try
            {
                IDbConnection ics = conn;
                ics.Execute($"Update Users Set OnlineNum = 0 Where id = '{dbr.id}'");
            }
            catch { }
        }
        public void SetData(dboReport dbr, SqlConnection conn)
        {
            IDbConnection ics = conn;
            ics.Execute($"INSERT INTO Users (id, Address, MailAddress,Account, Password ,Name) VALUES ('{dbr.id}', '{dbr.Address}', '{dbr.MailAddress}', '{dbr.Account}', '{dbr.Password}', '{dbr.Name}')");
        }
    }
}
