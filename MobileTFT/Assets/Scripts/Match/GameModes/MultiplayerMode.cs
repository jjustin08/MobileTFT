using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerMode : GameMode
{
    [SerializeField] private Combat combat;
    [SerializeField] private CardManager cardManager;
    [SerializeField] private BotLoader botLoader;
    [SerializeField] private RoundDisplayUI UI;
    [SerializeField] private MapManager mapManager;

    private bool isGameRunning = false;

    private float timer = 0;
    private float timerMax = 0;

    private int step = 0;
    private int stepMax = 4;

    private int round = 0;
    private int realRound = 0;


    private void Update()
    {
        // debug input to skip planning step
        if (Input.GetKeyDown(KeyCode.W) && step == Step.TurnStart)
        {
            timer = timerMax;
        }


        if (isGameRunning)
        {
            UpdateGame();
        }

    }

    public override void StartGame()
    {
        isGameRunning = true;
        GridUtil.Instance.ToggleGridInteraction(false, false);
    }

    protected override void UpdateGame()
    {
        if (step == Step.CombatStart)
        {
            if (combat.IsCombatOver())
            {
                timer = timerMax;
            }
        }


        timer += Time.deltaTime;
        UI.UpdateTimer(timer, timerMax);

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

    protected override void StartTurn()
    {
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
        //TODO do something about combat bools
        combat.StartCombat();
        GridUtil.Instance.SetInCombat(true);
        cardManager.gameObject.SetActive(false);
    }

    protected override void EndCombat()
    {
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

    public override void EndGame()
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