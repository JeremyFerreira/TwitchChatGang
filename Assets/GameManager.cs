using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] List<string> _yellowPlayer;
    [SerializeField] List<string> _redPlayer;
    Dictionary<string, string> _allPlayer = new Dictionary<string, string>();
    bool _gameIsLaunch;
    Dictionary<string, int> _playerVoted = new Dictionary<string, int>();
    List<int> _yellowVote;
    List<int> _redVote;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _yellowPlayer = new List<string>();
        _redPlayer = new List<string>();
        _yellowVote = new List<int>();
        _redVote = new List<int>();
        _gameIsLaunch = false;
    }
    public void RunFunction(string user, string msg)
    {
        if (!_gameIsLaunch)
        {
            String str = msg;
            if (str.Contains("crocoYELLOW"))
            {
                _allPlayer.Add(user, "YELLOW");
                _yellowPlayer.Add(user);
            }
            else if (str.Contains("crocoRed"))
            {
                _redPlayer.Add(user);
                _allPlayer.Add(user, "RED");
            }
        }

        else
        {
            if (_allPlayer.ContainsKey(user) && !_playerVoted.ContainsKey(user))
            {
                switch (msg)
                {
                    case "0":
                        Vote(_allPlayer[user], user, 0);
                        break;
                    case "1":
                        Vote(_allPlayer[user], user, 1);
                        break;
                    case "2":
                        Vote(_allPlayer[user], user, 2);
                        break;
                    case "3":
                        Vote(_allPlayer[user], user, 3);
                        break;
                    case "4":
                        Vote(_allPlayer[user], user, 4);
                        break;
                    case "5":
                        Vote(_allPlayer[user], user, 5);
                        break;
                    case "6":
                        Vote(_allPlayer[user], user, 6);
                        break;
                    case "7":
                        Vote(_allPlayer[user], user, 7);
                        break;
                }
            }
        }
    }

    public void LaunchGame()
    {
        _gameIsLaunch = true;
        StartCoroutine(Check());
    }

    IEnumerator Check()
    {
        yield return new WaitForSeconds(1);
        CalculVote();
    }

    private void Vote(string team, string user, int vote)
    {
        _playerVoted.Add(user, vote);
        if (team == "RED")
        {
            _redVote[vote]++;
        }
        if (team == "YELLOW")
        {
            _yellowVote[vote]++;
        }
    }

    private void CalculVote()
    {
        int yellowChoice = -1;
        for (int i = 0; i < _yellowVote.Count; i++)
        {
            if (_yellowVote[i] > _yellowVote[yellowChoice])
                yellowChoice = i;
                
        }

        int redChoice = -1;
        for (int i = 0; i < _redVote.Count; i++)
        {
            if (_redVote[i] > _redVote[redChoice])
                redChoice = i;
        }

        _playerVoted.Clear();
        _redVote.Clear();
        _yellowVote.Clear();

       
    }
}
