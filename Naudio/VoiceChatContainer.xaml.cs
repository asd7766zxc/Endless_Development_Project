using Chat_Pro_NCP;
using Endless_Development_Project_Studio.Connection;
using NAudioDemo;
using ESBasic;
using NAudio.Wave;
using NAudioDemo.NetworkChatDemo;
using NAudioDemo.Utils;
using OMCS.Boost.Controls;
using OMCS.Contracts;
using OMCS.Passive;
using OMCS.Passive.MultiChat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Xml.Serialization;
using System.Net.Sockets;


/// <summary>
/// VoicePage.xaml 的互動邏輯
/// </summary>
namespace NAudioDemo.NetworkChatDemo
{
    public partial class VoiceChatContainer : BasePage<VoicePageViewModel>
    {
        private INetworkChatCodec selectedCodec;
        private volatile bool connected;
        private NetworkAudioPlayer player;
        private NetworkAudioSender audioSender;

        public VoiceChatContainer()
        {
            var codecs = ReflectionHelper.CreateAllInstancesOf<INetworkChatCodec>();

            InitializeComponent();
            PopulateInputDevicesCombo();
            PopulateCodecsCombo(codecs);
            comboBoxProtocol.Items.Add("UDP");
            comboBoxProtocol.Items.Add("TCP");
            comboBoxProtocol.SelectedIndex = 1;
        }

        void OnPanelDisposed(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void PopulateCodecsCombo(IEnumerable<INetworkChatCodec> codecs)
        {
            var sorted = from codec in codecs
                         where codec.IsAvailable
                         orderby codec.BitsPerSecond ascending
                         select codec;

            foreach (var codec in sorted)
            {
                var bitRate = codec.BitsPerSecond == -1 ? "VBR" : $"{codec.BitsPerSecond / 1000.0:0.#}kbps";
                var text = $"{codec.Name} ({bitRate})";
                comboBoxCodecs.Items.Add(new CodecComboItem { Text = text, Codec = codec });
            }
            comboBoxCodecs.SelectedIndex = 0;
        }

        class CodecComboItem
        {
            public string Text { get; set; }
            public INetworkChatCodec Codec { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }

        private void PopulateInputDevicesCombo()
        {
            for (int n = 0; n < WaveIn.DeviceCount; n++)
            {
                var capabilities = WaveIn.GetCapabilities(n);
                comboBoxInputDevices.Items.Add(capabilities.ProductName);
            }
            if (comboBoxInputDevices.Items.Count > 0)
            {
                comboBoxInputDevices.SelectedIndex = 0;
            }
        }

        private void buttonStartStreaming_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                IPEndPoint endPoint = new IPEndPoint(Dns.GetHostAddresses(Config.ConnectionStringEDP).Where(x => x.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault(), 15123);
                int inputDeviceNumber = comboBoxInputDevices.SelectedIndex;
                selectedCodec = ((CodecComboItem)comboBoxCodecs.SelectedItem).Codec;
                Connect(endPoint, inputDeviceNumber, selectedCodec);
                buttonStartStreaming.Content = "Disconnect";
            }
            else
            {
                Disconnect();
                buttonStartStreaming.Content = "Connect";
            }
        }

        private void Connect(IPEndPoint endPoint, int inputDeviceNumber, INetworkChatCodec codec)
        {
            var receiver = (comboBoxProtocol.SelectedIndex == 0)
                ? (IAudioReceiver)new UdpAudioReceiver(endPoint.Port)
                : new TcpAudioReceiver(endPoint.Port);
            var sender = (comboBoxProtocol.SelectedIndex == 0)
                ? (IAudioSender)new UdpAudioSender(endPoint)
                : new TcpAudioSender(endPoint);

            player = new NetworkAudioPlayer(codec, receiver);
            audioSender = new NetworkAudioSender(codec, inputDeviceNumber, sender);
            connected = true;
        }

        private void Disconnect()
        {
            if (connected)
            {
                connected = false;

                player.Dispose();
                audioSender.Dispose();

                // a bit naughty but we have designed the codecs to support multiple calls to Dispose, 
                // recreating their resources if Encode/Decode called again
                selectedCodec.Dispose();
            }
        }
    }

    public class NetworkChatPanelPlugin : INAudioDemoPlugin
    {
        public string Name => "Network Chat";

        public VoiceChatContainer CreatePanel()
        {
            return new VoiceChatContainer();
        }
    }
}



