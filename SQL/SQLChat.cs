using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Endless_Development_Project_Studio.SQL.Chat
{
    public class SQLChat
    {
        public delegate void MessageEventHandler(List<Message> msg);
        public event MessageEventHandler MessageEvent;
        List<Message> messages = new List<Message>();
        DispatcherTimer Dt = new DispatcherTimer();
        public ConnectToSQL cts = new ConnectToSQL();
        public void Connect()
        {
           cts.Connect("cr-reports.ddns.net", 1433, "f");
            //TODO:  cts.Connect("192.168.1.103", 1433, "f");
            Dt.Interval = TimeSpan.FromMilliseconds(500);
            Dt.Tick += Dt_Tick;
            Dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            if (messages != cts.GetServerData())
            {
                messages = cts.GetServerData();
                MessageEvent?.Invoke(messages);
            }
        }
        public void Send(Message msg)
        {
            cts.SetServerData(msg);
        }
    }
    public class ConnectToSQL
    {
        public SqlConnection conn;
        public List<Message> Report = new List<Message>();
        DataAcess asc = new DataAcess();

        public void Connect(string Host, int port, string userid, string userpas)
        {
            conn = new SqlConnection($"Server={Host},{port}; initial catalog = chat_container; user id = {userid}; password = {userpas}");
            conn.Open();
        }

        public void Connect(string Host, int port, string userid)
        {
            conn = new SqlConnection($"Server={Host},{port}; initial catalog = chat_container; user id = {userid}; password = uyliouphjytuupr");
            conn.Open();
        }
        public List<Message> GetServerData()
        {
            if (conn == null) return null;

            var report = asc.GetData(conn);
            return report;
        }
        public void SetServerData(Message dboreport)
        {
            if (conn == null) return;
        
            asc.SetData(dboreport, conn,long.Parse(DateTime.Now.ToString("yyyyMMddHHmmssffff")));
        }

    }
    class DataAcess
    {
        public List<Message> GetData(SqlConnection conn)
        {
            IDbConnection ics = conn;
            return ics.Query<Message>($"select * from ChatsA ORDER BY dshort ASC").ToList();
        }
        public void SetData(Message dbr, SqlConnection conn,long dshort)
        {
            IDbConnection ics = conn;
            ics.Execute($"INSERT INTO ChatsA (id, Message, Date, Modify ,[user],Address,_short,userid,dshort) VALUES ('{dbr.id}', '{dbr.message}', '{dbr.Date}', '{dbr.Modify.ToString()}', '{dbr.user}','{dbr.Address}','{dbr._short}','{dbr.userid}',{dshort})");
        }
    }
}
