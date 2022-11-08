using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public static ChatManager instance;
    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;

    string username = "Shtockk";
    string password = "oauth:rybuaw25d1wpkhxtrff2greot01t1u";
    string channelName = "crocodyle_lol"; //Set to the channel you want ot get chat messages from

    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    void Connect()
    {
        twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        reader = new StreamReader(twitchClient.GetStream());
        writer = new StreamWriter(twitchClient.GetStream());

        writer.WriteLine("PASS " + password);
        writer.WriteLine("NICK " + username);
        writer.WriteLine("USER " + username + " 8 * :" + username);
        writer.WriteLine("JOIN #" + channelName);
        writer.Flush();

        Debug.Log("Connected to Twitch IRC");
    }

    // Update is called once per frame
    void Update()
    {
        if (twitchClient == null || !twitchClient.Connected)
        {
            Connect();
        }

        ReadChat();
    }

    void ReadChat()
    {
        if (twitchClient.Available > 0)
        {
            string message = reader.ReadLine();
            if (message.Contains("PRIVMSG"))
            {
                int splitPoint = message.IndexOf("!", 1);
                string chatName = message.Substring(1, splitPoint - 1);

                splitPoint = message.IndexOf(":", 1);
                string chatMessage = message.Substring(splitPoint + 1);

                GameManager.instance.RunFunction(chatName, chatMessage);
            }
        }
    }
}