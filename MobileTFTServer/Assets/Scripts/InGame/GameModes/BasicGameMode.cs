using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicGameMode : GameMode
{
    private bool isGameRunning = false;

    private float timer = 0;
    private float timerMax = 0;

    private int step = 0;
    private int stepMax = 4;

    private int round = 0;
    private int realRound = 0;

    private void Awake()
    {
        Lobby.SetGameMode(this);
    }

    private void Update()
    {
        if (isGameRunning)
        {
            UpdateGame();
        }
    }

    protected override void UpdateGame()
    {
        
        // SERVER
        if (step == Step.CombatStart)
        {
            //if (combat.IsCombatOver())
            //{
            //    timer = timerMax;
            //}
        }

        timer += Time.deltaTime;

        if (timer > timerMax)
        {
            timer = 0;
            step++;
            if (step > stepMax || step == 0)
            {
                step = Step.TurnStart;
            }

            switch (step)
            {
                case Step.TurnStart:
                    StartTurn();
                    timerMax = 20;
                    break;
                case Step.TurnEnd:
                    EndTurn();
                    timerMax = 1.0f;
                    break;
                case Step.CombatStart:
                    StartCombat();
                    timerMax = 20;
                    break;
                case Step.CombatEnd:
                    EndCombat();
                    timerMax = 2.0f;
                    break;
            }
        }
    }

    public override void StartGame()
    {
        isGameRunning = true;
        string msg = ServerToClientSignifiers.Gamemode + "," + GameModeSignifiers.StartGame;
        foreach (Player player in Lobby.GetPlayers())
        {
            int id = player.getId();
            NetworkServerProcessing.SendMessageToClient(msg, id, TransportPipeline.ReliableAndInOrder);
        }
    }

    protected override void StartTurn()
    {
        round++;
        realRound++;
        string msg = ServerToClientSignifiers.Gamemode + "," + GameModeSignifiers.StartTurn;
        foreach (Player player in Lobby.GetPlayers())
        {
            int id = player.getId();
            NetworkServerProcessing.SendMessageToClient(msg, id, TransportPipeline.ReliableAndInOrder);
        }
    }

    protected override void EndTurn()
    {
        MatchMaker.MatchMake();
        foreach (Player player in Lobby.GetPlayers())
        {
            string msg = MatchMaker.GetOppenonts(player);
            int id = player.getId();
            NetworkServerProcessing.SendMessageToClient(msg, id, TransportPipeline.ReliableAndInOrder);
        }
    }

    protected override void StartCombat()
    {
        //I want to run combat here quickly to get results
        Combat.RunCombat();
        string msg = ServerToClientSignifiers.Gamemode + "," + GameModeSignifiers.StartCombat;
        foreach (Player player in Lobby.GetPlayers())
        {
            int id = player.getId();
            NetworkServerProcessing.SendMessageToClient(msg, id, TransportPipeline.ReliableAndInOrder);
        }
    }

    protected override void EndCombat()
    {
        //string msg = ServerToClientSignifiers.Gamemode + "," + GameModeSignifiers.EndCombat
        string msg = Combat.GetCombatResults();
        foreach (Player player in Lobby.GetPlayers())
        {
            int id = player.getId();
            NetworkServerProcessing.SendMessageToClient(msg, id, TransportPipeline.ReliableAndInOrder);
        }
    }
}
