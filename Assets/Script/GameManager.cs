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
    Dictionary<string, int> _redVoted = new Dictionary<string, int>();
    Dictionary<string, int> _yellowVoted = new Dictionary<string, int>();
    List<int> _yellowVote;
    List<int> _redVote;

    public int scoreRed;
    public int GetScoreRed()
    {
        return scoreRed;
    }
    public void AddScoreRed()
    {
        scoreRed++;
    }
    public int scoreYellow;
    public int GetScoreYellow()
    {
        return scoreYellow;
    }
    public void AddScoreYellow()
    {
        scoreYellow++;
    }
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _yellowPlayer = new List<string>();
        _redPlayer = new List<string>();
        _yellowVote = new List<int>();
        while (_yellowVote.Count < 8)
            _yellowVote.Add(0);

         _redVote = new List<int>(8);
        while (_redVote.Count < 8)
            _redVote.Add(0);
        _gameIsLaunch = false;
        scoreRed = 0;
        scoreYellow = 0;
    }
    public void RunFunction(string user, string msg)
    {
        Debug.Log($"{user} said \"{msg}\"");
        if (!_gameIsLaunch)
        {
            String str = msg;
            if (str.Contains("crocoYELLOW") && !_allPlayer.ContainsKey(user))
            {
                _allPlayer.Add(user, "YELLOW");
                _yellowPlayer.Add(user);
                CanvasMenu.instance.AddYellowPlayer(user, _allPlayer.Count, _yellowPlayer.Count);
            }
            else if (str.Contains("crocoRED") && !_allPlayer.ContainsKey(user))
            {
                _redPlayer.Add(user);
                _allPlayer.Add(user, "RED");
                CanvasMenu.instance.AddRedPlayer(user, _allPlayer.Count, _redPlayer.Count);
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
        StartCoroutine(Check());
    }

    private void Vote(string team, string user, int vote)
    {
        _playerVoted.Add(user, vote);
        if (team == "RED")
        {
            _redVoted.Add(user, vote);
            _redVote[vote]++;
        }
        if (team == "YELLOW")
        {
            _yellowVoted.Add(user, vote);
            _yellowVote[vote]++;
        }
    }

    private void CalculVote()
    {

        int yellowChoice = 0;
        for (int i = 0; i < _yellowVote.Count; i++)
        {
            if (_yellowVote[i] > _yellowVote[yellowChoice])
                yellowChoice = i;
                
        }

        int redChoice = 0;
        for (int i = 0; i < _redVote.Count; i++)
        {
            if (_redVote[i] > _redVote[redChoice])
                redChoice = i;
        }

        if (_playerVoted.Count > 0)
        {

        if (_yellowVoted.Count > 0)
            PaddleController.instance.ChangePosPaddleLeft(yellowChoice);
        if (_redVoted.Count > 0)
            PaddleController.instance.ChangePosPaddleRight(redChoice);
        }
        _yellowVoted.Clear();
        _redVoted.Clear();
        _playerVoted.Clear();
        _yellowVote = new List<int>();
        while (_yellowVote.Count < 8)
            _yellowVote.Add(0);

        _redVote = new List<int>();
        while (_redVote.Count < 8)
            _redVote.Add(0);
    }
}
