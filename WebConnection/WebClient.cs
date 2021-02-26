using Endless_Development_Project_Studio.SQL;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Endless_Development_Project_Studio.WebConnection
{
    public class WebClient
    {
        private const string SignalRurl = "http://cr-report.ddns.net:4258/";
        private HubConnection _conn;
        public delegate void OnRecivedHandler(string parameter);
        public event OnRecivedHandler OnRecived;
        private delegate void UiCallBack();
        private IHubProxy _chatHub;
        private Dictionary<string, IHubProxy> _hubs;
        private readonly SQL.dboReport _currectUser;

        public WebClient()
        {
            var querystringData = new Dictionary<string, string> { { "id", "10001" } };
            _conn = new HubConnection(SignalRurl, querystringData);
            // v1的測試hub
            _chatHub = _conn.CreateHubProxy("chatHub");
            _chatHub.On<string>("addMessage", (msg) =>
            {
                OnRecived?.Invoke(msg);
            });

            // v2的測試Hub：應從DB中取得該人員參與的頻道，再加入Hub
            var t = new List<ChannelInfo>();

            _hubs = GetUserHubs(t);

            foreach (var currectHub in _hubs)
            {
                currectHub.Value.On<string>("received", (msg) =>
                {
                    OnRecived?.Invoke(msg);
                });
            }
        }

        private Dictionary<string, IHubProxy> GetUserHubs(IEnumerable<ChannelInfo> channels)
        {
            var result = new Dictionary<string, IHubProxy>();
            foreach (var info in channels)
            {
                result.Add(info.Name, _conn.CreateHubProxy(info.Name));
            }

            // 這邊是為了 V1 的測 應該吧 或許是一些 UnitTest
            result.Add("chathub", _conn.CreateHubProxy("chathub"));

            return result;
        }
        public void Connect()
        {
            _conn.Start().ContinueWith(task =>
            {
                if (task.IsFaulted) return;
                // V1 版本
                //_chatHub.Invoke("sendMessage", $"{_currectUser.Name}加入了聊天室");
                //
                // V2 版本
                // foreach (var currectHub in _hubs)
                // {
                //   currectHub.Value.Invoke("send", $"{_currectUser.Name}加入了聊天室");
                // }
            });
        }

        public void Chat(string msg)
        {
            try
            {
                var nowChannel = "chathub";
                if (!_hubs.ContainsKey(nowChannel)) return;

                if (nowChannel == "chathub")
                {
                    // for v1 group hub test
                    _chatHub.Invoke("sendMessage", msg);
                }
                else
                {
                    // for v2 multi Hub test
                    _hubs[nowChannel].Invoke("send", $"[{nowChannel}]{msg}");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
