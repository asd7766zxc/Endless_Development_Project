using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Endless_Development_Project_Studio.Connection;
using System.Runtime.CompilerServices;
using Endless_Development_Project_Studio.Managers;

namespace Endless_Development_Project_Studio.SQL.Chat
{
    public class SQLChat
    {
        public delegate void MessageEventHandler(List<Message> msg);
        public event MessageEventHandler MessageEvent;
        public delegate void UpdateEventHandler(ChatsC msg);
        public event UpdateEventHandler UpdateEvent;
        public SqlNotificationDependency SND = new SqlNotificationDependency();
        //public SynchronizeClient synchronizeClient = new SynchronizeClient();
        List<Message> messages = new List<Message>();
        DispatcherTimer Dt = new DispatcherTimer();
        public ConnectToSQL cts = new ConnectToSQL();
        public ConnectToSQL ctas = new ConnectToSQL();
        public ConnectToSQL ctbs = new ConnectToSQL();
        public void Connect()
        {
            SND.ErrorEvent += SND_ErrorEvent;
            SND.MessageEvent += SND_MessageEvent;
            cts.Connect(Config.ConnectionStringEDP, 1433, "f");
            ctas.Connect(Config.ConnectionStringEDP, 1433, "f");
            ctbs.Connect(Config.ConnectionStringEDP, 1433, "f");
            Manual_Update();
            //TODO:  cts.Connect("192.168.1.103", 1433, "f");
            //  Dt.Interval = TimeSpan.FromMilliseconds(500);
            // Dt.Tick += Dt_Tick;
            //Dt.Start();
        }

        private void SND_ErrorEvent(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs msg)
        {
         
        }

        private void SND_MessageEvent(TableDependency.SqlClient.Base.Enums.ChangeType changeType, ChatsC msg)
        {
            if(changeType == TableDependency.SqlClient.Base.Enums.ChangeType.Insert)
            UpdateEvent?.Invoke(msg);
        }

        public void Disconnect()
        {
           
            cts.Disconnect();
            ctas.Disconnect();
            ctbs.Disconnect();
            //TODO:  cts.Connect("192.168.1.103", 1433, "f");
            //  Dt.Interval = TimeSpan.FromMilliseconds(500);
            // Dt.Tick += Dt_Tick;
            //Dt.Start();
        }
        private void Manual_Update()
        {
        
         
                    var ListChat = cts.GetServerListChannelData(0).FirstOrDefault().Name;
                    var Sample = cts.GetServerData(ListChat);
                    if (messages != Sample)
                    {
                        messages = Sample;
                        MessageEvent?.Invoke(messages);
                    }
            Logger.ConsoleLogger.Log("Manual_Updated");
          
        }        
        private void SynchronizeClient_LogEvent(object Log)
        {
            Task.Run(() =>
            {
                var Parameter = (string)Log;
                var Command = Parameter.Split('|')[0];
                if (Command == "U")
                {
                    var ID = int.Parse(Parameter.Split('|')[1]);
                    var ListChat = ctas.GetServerListChannelData(ID).FirstOrDefault().Name;
                    var Sample = ctas.GetServerData(ListChat);
                    if (messages != Sample)
                    {
                        messages = Sample;
                        MessageEvent?.Invoke(messages);
                    }
                }
            });
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
           // var Sample = cts.GetServerData();
          //  if (messages != Sample)
           // {
           //     messages = Sample;
           //     MessageEvent?.Invoke(messages);
           // }
        }
        public void Send(Message msg)
        {
          //  cts.SetServerData(msg);
        }
        public void Send(Message msg,int ChannelID)
        {
            var ListChat = cts.GetServerListChannelData(0).FirstOrDefault().Name;
            ctbs.SetServerData(msg, ListChat);
        }
    }
    public class ConnectToSQL
    {
        public SqlConnection conn;
        public List<Message> Report = new List<Message>();
        DataAcess asc = new DataAcess();

        public void Disconnect()
        {
            conn.Close();
        }
 
        public void Connect(string Host, int port, string userid, string userpas)
        {

            string ConnectionString = $"Server={Config.ConnectionStringEDP},1433; initial catalog = chat_container; user id = SqlUser; password = SqlUserSt0rongP@assord";
          
            conn = new SqlConnection($"Server={Config.ConnectionStringEDP},1433; initial catalog = chat_container; user id = SqlUser; password = SqlUserSt0rongP@assord");
            conn.Open();
        }
       
        public void Connect(string Host, int port, string userid)
        {
            string ConnectionString = $"Server={Config.ConnectionStringEDP},1433; initial catalog = chat_container; user id = SqlUser; password = SqlUserSt0rongP@assord";

    
            conn = new SqlConnection($"Server={Config.ConnectionStringEDP},1433; initial catalog = chat_container; user id = SqlUser; password = SqlUserSt0rongP@assord");
            conn.Open();
        }
        public List<Message> GetServerData(string d, string ds, [CallerMemberName] string origin = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Logger.ConsoleLogger.Log("["+filePath+"] "+origin+" -> line: "+lineNumber);
            if (conn == null) return null;

            var report = asc.GetData(conn);
            return report;
        }
        public void SetServerData(Message dboreport,string f, string d, [CallerMemberName] string origin = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Logger.ConsoleLogger.Log("[" + filePath + "] " + origin + " -> line: " + lineNumber);
            if (conn == null) return;
        
            asc.SetData(dboreport, conn,long.Parse(DateTime.Now.ToString("yyyyMMddHHmmssffff")));
        }
        public List<Message> GetServerData(string Channel, [CallerMemberName] string origin = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Logger.ConsoleLogger.Log("[" + filePath + "] " + origin + " -> line: " + lineNumber);
            if (conn == null) return null;

            var report = asc.GetDataTrigger(conn, Channel);
            return report;
        }
        public List<Channel> GetServerListChannelData(int ChannelID, [CallerMemberName] string origin = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Logger.ConsoleLogger.Log("[" + filePath + "] " + origin + " -> line: " + lineNumber);
            if (conn == null) return null;

            var report = asc.GetChannelListData(ChannelID,conn);
            return report;
        }
        public void SetServerData(Message dboreport,string Channel, [CallerMemberName] string origin = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0)
        {
            Logger.ConsoleLogger.Log("[" + filePath + "] " + origin + " -> line: " + lineNumber);
            if (conn == null) return;

            asc.SetDataTrigger(dboreport, conn, long.Parse(DateTime.Now.ToString("yyyyMMddHHmmssffff")), Channel);
        }

    }
    public class Channel
    {
        public int ChannelID { get; set; }
        public string Name { get; set; }
        public string Member { get; set; }
    }
    class DataAcess
    {
        public delegate void MessageEventHandler(SqlNotificationEventArgs args);
        public event MessageEventHandler MessageEvent;
         
        private void SQLTableOnChange(object sender, SqlNotificationEventArgs e)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetData(SqlConnection conn)
        {
            IDbConnection ics = MultibleConnetion(conn);
            return ics.Query<Message>($"select * from "+ GetChannelListData(0, conn).FirstOrDefault().Name +" ORDER BY dshort ASC").ToList();
        }
        public void SetData(Message dbr, SqlConnection conn,long dshort)
        {
            IDbConnection ics = MultibleConnetion(conn);
            ics.Execute($"INSERT INTO "+GetChannelListData(0, conn).FirstOrDefault().Name+" (id, Message, Date, Modify ,[user],Address,_short,userid,dshort) VALUES ('{dbr.id}', '{dbr.message}', '{dbr.Date}', '{dbr.Modify.ToString()}', '{dbr.user}','{dbr.Address}','{dbr._short}','{dbr.userid}',{dshort})");
        }
        public List<Message> GetDataTrigger(SqlConnection conn,string Channel)
        {
            IDbConnection ics = MultibleConnetion(conn);
            return ics.Query<Message>($"select * from "+ Channel + " ORDER BY dshort ASC").ToList();
        }
        public async Task SetDataTrigger(Message dbr, SqlConnection conn, long dshort, string Channel)
        {
            IDbConnection ics = MultibleConnetion(conn);
            ics.Execute($"INSERT INTO {Channel} (id, Message, Date, Modify ,[user],Address,_short,userid,dshort) VALUES ('{dbr.id}', '{dbr.message}', '{dbr.Date}', '{dbr.Modify.ToString()}', '{dbr.user}','{dbr.Address}','{dbr._short}','{dbr.userid}',{dshort})");
        }
        public List<Channel> GetChannelListData(int id, SqlConnection conn)
        {
            IDbConnection ics = MultibleConnetion(conn);
            return ics.Query<Channel>($"select * from ChannelList where ChannelID = {id}").ToList();
        }
        public IDbConnection MultibleConnetion(IDbConnection Target)
        {
            return Target;
        }
    }
}
