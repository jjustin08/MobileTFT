using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineTriggerAction.ActionSettings;

public class NormalMode : GameMode
{
    [SerializeField] private Combat combat;
    [SerializeField] private CardManager cardManager;
    [SerializeField] private BotLoader botLoader;
    [SerializeField] private RoundDisplayUI UI;
    [SerializeField] private MapManager mapManager;

    private bool isGameRunning = false;

    private float timer = 0;
    private float timerMax = 0;

    //private int step = 0;
    //private int stepMax = 4;

    private int round = 0;
    private int realRound = 0;

    private void Start()
    {
        NetworkClientProcessing.SetGameMode(this);

        string msg = ClientToServerSignifiers.GameLoaded.ToString();
        NetworkClientProcessing.SendMessageToServer(msg, TransportPipeline.ReliableAndInOrder);
    }

    override public void RecieveServerMsg(string msg)
    {
        string[] csv = msg.Split(',');
        int signifier = int.Parse(csv[1]);

        switch (signifier)
        {
            case ServerToClientGameModeSignifiers.StartGame:
                StartGame();
                break; 
            case ServerToClientGameModeSignifiers.StartTurn:
                StartTurn();
                break; 
            case ServerToClientGameModeSignifiers.EndTurn:
                EndTurn();
                break; 
            case ServerToClientGameModeSignifiers.StartCombat:
                StartCombat();
                break;
            case ServerToClientGameModeSignifiers.EndCombat:
                EndCombat();
                break;
            case ServerToClientGameModeSignifiers.EndGame:
                EndGame();
                break;
            default:
                Debug.Log("Invalid signifier");
                break;
        }
    }


    private void Update()
    {
        if (isGameRunning)
        {
            UpdateGame();
        }
    }

    protected override void StartGame()
    {
        isGameRunning = true;
        GridUtil.Instance.ToggleGridInteraction(false, false);
    }

    protected override void UpdateGame()
    {
        timer += Time.deltaTime;

        UI.UpdateTimer(timer, timerMax);  
    }

    protected override void StartTurn()
    {
        timer = 0;
        timerMax = 20;
        cardManager.gameObject.SetActive(true);
        switch (round)
        {
            case 1:
                combat.EndCombat();
                break;
            case 2:
                combat.EndCombat();
                break;
            case 3:
                combat.EndCombatDeath();
                break;
            case 4:
                combat.EndCombatDeath();
                break;
            case 5:
                combat.EndCombat();
                break;
            case 6:

                combat.EndCombat();
                break;
            case 7:
                combat.EndCombatDeath();
                break;
            case 8:
                combat.EndCombatDeath();
                break;
            case 9:
                combat.EndCombatDeath();
                round = 0;
                break;
        }


        if (Player.Instance.GetPlayerStats().GetPlayerHealth() <= 0)
        {
            EndGame();
            return;
        }

        //load bot teams
        round++;
        realRound++;


        mapManager.ChangeMap(0);
        int cashAmount = 1 + realRound;
        if (cashAmount > 10) { cashAmount = 10; }

        Player.Instance.GetPlayerStats().SetCash(cashAmount);
        Player.Instance.GetPlayerStats().ReduceCostToLevelUp(1);
        cardManager.ReRollPawns();
        switch (round)
        {
            case 1:
                UI.UpdateText("Safe Round");
                botLoader.LoadBotTeam(0);
                break;
            case 2:
                UI.UpdateText("Safe Round");
                botLoader.LoadBotTeam(1);
                break;
            case 3:
                //player round
                UI.UpdateText("Death Round");
                break;
            case 4:
                UI.UpdateText("Death Round");
                break;
            case 5:
                UI.UpdateText("Safe Round");
                botLoader.LoadBotTeam(4);
                break;
            case 6:
                // player round
                UI.UpdateText("Safe Round");
                botLoader.LoadBotTeam(5);
                break;
            case 7:
                UI.UpdateText("Death Round");
                break;
            case 8:
                UI.UpdateText("Death Round");

                break;
            case 9:
                UI.UpdateText("Death Round");
                break;
        }
    }

    protected override void EndTurn()
    {
        timer = 0;
        timerMax = 1.0f;
        UI.UpdateText("");



        switch (round)
        {
            case 1:

                break;
            case 2:

                break;
            case 3:
                mapManager.ChangeMap(1);
                botLoader.LoadBotTeam(2);
                break;
            case 4:
                mapManager.ChangeMap(1);
                botLoader.LoadBotTeam(3);
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                mapManager.ChangeMap(1);
                botLoader.LoadBotTeam(6);
                break;
            case 8:
                mapManager.ChangeMap(1);
                botLoader.LoadBotTeam(7);
                break;
            case 9:
                mapManager.ChangeMap(1);
                botLoader.LoadBotTeam(8);
                break;
        }
    }

    protected override void StartCombat()
    {
        timer = 0;
        timerMax = 20;
        //TODO do something about combat bools
        combat.StartCombat();
        GridUtil.Instance.SetInCombat(true);
        cardManager.gameObject.SetActive(false);
    }

    protected override void EndCombat()
    {
        timer = 0;
        timerMax = 2.0f;
        switch (combat.GetCombatEndState())
        {
            //win
            case 1:
                UI.UpdateText("Win");
                break;
            //lose
            case 2:
                UI.UpdateText("Lose");
                break;
            //tie
            case 3:
                UI.UpdateText("Tie");
                break;
            default:
                break;


        }
        GridUtil.Instance.SetInCombat(false);


    }

    protected override void EndGame()
    {
        isGameRunning = false;

        if (Player.Instance.GetPlayerStats().GetPlayerHealth() > 0)
        {
            //win
            UI.UpdateText("You Won the Game");
        }
        else
        {
            //lose
            UI.UpdateText("You Lost the Game");
        }
    }
}


#region Protocol Signifiers
static public class ClientToServerGameModeSignifiers
{
    public const int JoinLobby = 1;
}

static public class ServerToClientGameModeSignifiers
{
    public const int StartGame = 1;
    public const int StartTurn = 2;
    public const int EndTurn = 3;
    public const int StartCombat = 4;
    public const int EndCombat = 5;
    public const int EndGame = 6;

}

#endregion