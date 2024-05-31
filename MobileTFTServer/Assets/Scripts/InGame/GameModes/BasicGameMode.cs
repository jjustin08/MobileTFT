using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGameMode :GameMode
{
    private bool isGameRunning = false;

    private float timer = 0;
    private float timerMax = 0;

    private int step = 0;
    private int stepMax = 4;

    private int round = 0;
    private int realRound = 0;

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
        isGameRunning=true;
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
        string msg = ServerToClientSignifiers.Gamemode + "," + GameModeSignifiers.EndTurn;
        foreach (Player player in Lobby.GetPlayers())
        {
            int id = player.getId();
            NetworkServerProcessing.SendMessageToClient(msg, id, TransportPipeline.ReliableAndInOrder);
        }
    }

    protected override void StartCombat()
    {
        string msg = ServerToClientSignifiers.Gamemode + "," + GameModeSignifiers.StartCombat;
        foreach (Player player in Lobby.GetPlayers())
        {
            int id = player.getId();
            NetworkServerProcessing.SendMessageToClient(msg, id, TransportPipeline.ReliableAndInOrder);
        }
    }

    protected override void EndCombat()
    {
        string msg = ServerToClientSignifiers.Gamemode + "," + GameModeSignifiers.EndCombat;
        foreach (Player player in Lobby.GetPlayers())
        {
            int id = player.getId();
            NetworkServerProcessing.SendMessageToClient(msg, id, TransportPipeline.ReliableAndInOrder);
        }
    }
}



static public class GameModeSignifiers
{
    public const int StartGame = 1;
    public const int StartTurn = 2;
    public const int EndTurn = 3;
    public const int StartCombat = 4;
    public const int EndCombat = 5;
    public const int EndGame = 6;

}
