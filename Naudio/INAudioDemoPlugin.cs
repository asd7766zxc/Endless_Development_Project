using Chat_Pro_NCP;
using NAudioDemo.NetworkChatDemo;
using System;
using System.Windows.Controls;

namespace NAudioDemo
{
    public interface INAudioDemoPlugin
    {
        string Name { get; }
        VoiceChatContainer CreatePanel();
    }
}
