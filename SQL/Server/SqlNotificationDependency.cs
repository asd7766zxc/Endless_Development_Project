using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace Endless_Development_Project_Studio.SQL.Server
{
    public class SqlNotificationDependency
    {
        public delegate void MessageEventHandler(ChangeType changeType, ServerEvents msg);
        public event MessageEventHandler MessageEvent;
        public delegate void ErrorEventHandler(object sender, ErrorEventArgs msg);
        public event ErrorEventHandler ErrorEvent;
        public SqlNotificationDependency()
        {
            string ConnectionString = $"Server={Config.ConnectionStringEDP},1433; initial catalog = chat_container; user id = SqlUser; password = SqlUserSt0rongP@assord";
            SqlTableDependency<ServerEvents> myDependencyTableDependency;
            try
            {
                myDependencyTableDependency = new SqlTableDependency<ServerEvents>(ConnectionString);

                myDependencyTableDependency.OnError += (o, args) => this.ErrorNotification(o, args);
                myDependencyTableDependency.OnChanged += (o, args) => this.OutputNotification(args.ChangeType, args.Entity);
                myDependencyTableDependency.Start();
            }
            catch
            { }
        }

        private void OutputNotification(ChangeType changeType, ServerEvents entity)
        {
            MessageEvent?.Invoke(changeType, entity);
        }
        private void ErrorNotification(object sender, ErrorEventArgs entity)
        {
            ErrorEvent?.Invoke(sender, entity);
        }
    }
    public class ServerEvents
    {
        public string ServerEventType { get; set; }
        public string ID { get; set; }
        public string Date { get; set; }
        public string Direct { get; set; }
        public string Info { get; set; }
    }
    public class SConnectToSQL
    {
        public SqlConnection conn;
        public List<ServerEvents> Report = new List<ServerEvents>();
        DataAcess asc = new DataAcess();

        public void Connect(string Host, int port, string userid, string userpas)
        {
            conn = new SqlConnection($"Server={Host},{port}; initial catalog = chat_container; user id = {userid}; password = {userpas}");
            conn.Open();
        }

        public void Connect(string Host, int port, string userid)
        {
            try
            {
                conn = new SqlConnection($"Server={Host},{port}; initial catalog = chat_container; user id = {userid}; password = uyliouphjytuupr");
                conn.Open();
            }
            catch (Exception e)
            {

            }
        }
        public List<ServerEvents> GetServerData(int id)
        {
            if (conn == null) return null;

            var report = asc.GetData(id, conn);
            return report;
        }
        public List<ServerEvents> GetServerDataByAccount(string id)
        {
            if (conn == null) return null;

            var report = asc.GetDataByAccount(id, conn);
            return report;
        }

        public void SetServerData(ServerEvents ServerEvents)
        {
            if (conn == null) return;
            asc.SetData(ServerEvents, conn);
        }
    }
    public class DataAcess
    {
        public List<ServerEvents> GetData(int id, SqlConnection conn)
        {
            IDbConnection ics = conn;
            return ics.Query<ServerEvents>($"select * from Users where id = {id}").ToList();
        }
        public List<ServerEvents> GetDataByAccount(string id, SqlConnection conn)
        {
            IDbConnection ics = conn;
            return ics.Query<ServerEvents>($"select * from Users where CONVERT(VARCHAR, MailAddress) = '{id}'").ToList();
        }

        public void SetData(ServerEvents dbr, SqlConnection conn)
        {
            IDbConnection ics = conn;
            ics.Execute($"INSERT INTO ServerEvents (ServerEventType, ID, Date,Direct,Info) VALUES ('{dbr.ServerEventType}', '{dbr.ID}', '{dbr.Date}', '{dbr.Direct}', '{dbr.Info}')");
        }
    }
}
