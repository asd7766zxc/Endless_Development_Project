using Endless_Development_Project_Studio.SQL.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace Endless_Development_Project_Studio
{
    public class SqlNotificationDependency
    {
        public delegate void MessageEventHandler(ChangeType changeType,ChatsC msg);
        public event MessageEventHandler MessageEvent;
        public delegate void ErrorEventHandler(object sender, ErrorEventArgs msg);
        public event ErrorEventHandler ErrorEvent;
        public SqlNotificationDependency()
        {
            ConnectToSQL cts = new ConnectToSQL();
            cts.Connect("cr-reports.ddns.net", 1433, "f");
            string ConnectionString = $"Server=cr-reports.ddns.net,1433; initial catalog = chat_container; user id = SqlUser; password = SqlUserSt0rongP@assord";
            SqlTableDependency<ChatsC> myDependencyTableDependency;
            try
            {
                myDependencyTableDependency = new SqlTableDependency<ChatsC>(ConnectionString, cts.GetServerListChannelData(0).FirstOrDefault().Name);

                myDependencyTableDependency.OnError += (o, args) => this.ErrorNotification(o, args);

                myDependencyTableDependency.OnChanged += (o, args) => this.OutputNotification(args.ChangeType, args.Entity);

                myDependencyTableDependency.Start();
            }
            catch
            { }
        }

        private void OutputNotification(ChangeType changeType, ChatsC entity)
        {
            MessageEvent?.Invoke(changeType,entity);
            Logger.ConsoleLogger.Log("SQL Debugger MessageEvent "+ changeType+" "+entity.id);
        }
        private void ErrorNotification(object sender, ErrorEventArgs entity)
        {
            ErrorEvent?.Invoke(sender, entity);
        }
    }
    public class ChatsC
    {
        public string message { get; set; }
        public int id { get; set; }
        public string Date { get; set; }
        public string user { get; set; }
        public int userid { get; set; }
        public int _short { get; set; }
        public bool Modify { get; set; }
        public string Address { get; set; }
        public string dshort { get; set; }
    }
}
