using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoreDeathMode : GameMode
{
    [SerializeField] private Combat combat;
    [SerializeField] private CardManager cardManager;
    [SerializeField] private BotLoader botLoader;
    [SerializeField] private RoundDisplayUI UI;
    [SerializeField] private LevelManager levelManager;

    private float timer = 0;
    private float timerMax = 60;

    private int step = 1;
    private int stepMax = 4;

    private int round = 0;

    private bool isGameRunning = false;

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            timer = timerMax;
        }
        if (isGameRunning)
        {
            UpdateGame();
        }

    }

    protected override void StartGame()
    {
        isGameRunning = true;
        GridUtil.Instance.ToggleGridInteraction(false, false);
        StartTurn();
    }

    protected override void UpdateGame()
    {
        if (combat.IsCombatOver())
        {
            timer = timerMax;
        }
        timer += Time.deltaTime;

        UI.UpdateTimer(timer, timerMax);



        if (timer > timerMax)
        {
            timer = 0;
            // Activate next step
            step++;
            if (step > stepMax)
            {
                step = 1;
            }

            switch (step)
            {
                case 1:
                    StartTurn();
                    timerMax = 60;
                    break;
                case 2:
                    EndTurn();
                    timerMax = 1;
                    break;
                case 3:
                    StartCombat();
                    timerMax = 60;
                    break;
                case 4:
                    EndCombat();
                    timerMax = 1;
                    break;
            }
        }
    }

    protected override void StartTurn()
    {
        round++;
        
        GridUtil.Instance.ToggleGridInteraction(true, true);
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
                UI.UpdateText("Bot Round");
                botLoader.LoadBotTeam(4);
                break;
            case 6:
                // player round
                UI.UpdateText("Death Round");
                break;
            case 7:
                UI.UpdateText("Death Round");
                break;
            case 8:
                UI.UpdateText("Bot Round");
                botLoader.LoadBotTeam(6);
                break;
            case 9:
                UI.UpdateText("Death Round");
                round = 0;
                break;
        }
    }

    protected override void EndTurn()
    {
        GridUtil.Instance.ToggleGridInteraction(true, false);
        UI.UpdateText("");


        switch (round)
        {
            case 1:

                break;
            case 2:

                break;
            case 3:
                botLoader.LoadBotTeam(3);
                break;
            case 4:
                botLoader.LoadBotTeam(2);
                break;
            case 5:
                break;
            case 6:
                botLoader.LoadBotTeam(7);
                break;
            case 7:
                botLoader.LoadBotTeam(5);
                break;
            case 8:
   
                break;
            case 9:
                botLoader.LoadBotTeam(7);
                round = 0;
                break;
        }
    }

    protected override void StartCombat()
    {
        combat.StartCombat();
        GridUtil.Instance.SetInCombat(true);


    }

    protected override void EndCombat()
    {

        levelManager.GainExp(2);

        switch (combat.CheckCombatState())
        {
            //win
            case 1:
                UI.UpdateText("Win");
                CashManager.Instance.GainCash(10);
                break;
            //lose
            case 2:
                UI.UpdateText("Lose");
                CashManager.Instance.GainCash(5);
                break;
            //tie
            case 3:
                UI.UpdateText("Tie");
                CashManager.Instance.GainCash(5);
                break;
            default:
                break;


        }
        GridUtil.Instance.SetInCombat(false);

        switch (round)
        {
            case 1:
                combat.EndCombat();
                break;
            case 2:
                combat.EndCombat();
                break;
            case 3:
                //player round
                combat.EndCombatDeath();
                break;
            case 4:
                combat.EndCombatDeath();
                break;
            case 5:
                combat.EndCombat();
                break;
            case 6:
                // player round
                combat.EndCombatDeath();
                break;
            case 7:
                combat.EndCombatDeath();
                break;
            case 8:
                combat.EndCombat();
                break;
            case 9:
                combat.EndCombatDeath();
                EndGame();
                break;
        }


        if (Player.Instance.GetPlayerStats().GetPlayerHealth() <= 0)
        {
            EndGame();
            return;
        }

        
    }



    public override void EndGame()
    {
        isGameRunning = false;
        //end the game somehow
        if (Player.Instance.GetPlayerStats().GetPlayerHealth() > 0)
        {
            //win
            UI.UpdateText("You Won the Game");
        }
        else
        {
            //lose??
            UI.UpdateText("You Lost the Game");
        }
    }

}



