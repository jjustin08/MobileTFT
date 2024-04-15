using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathMode : GameMode
{
    [SerializeField] private Combat combat;
    [SerializeField] private CardManager cardManager;
    [SerializeField] private BotLoader botLoader;
    [SerializeField] private RoundDisplayUI UI;
    [SerializeField] private LevelUI levelManager;

    private float timer = 0;
    private float timerMax = 0;

    private int step = 0;
    private int stepMax = 4;

    private int round = 0;

    private bool isGameRunning = false;

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && step == 1)
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
        GridUtil.Instance.ToggleGridInteraction(true, false);
    }

    protected override void UpdateGame()
    {
        // only run in combat
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
            if (step > stepMax || step == 0)
            {
                step = 1;
            }

            switch (step)
            {
                case 1:
                    StartTurn();
                    timerMax = 40;
                    break;
                case 2:
                    EndTurn();
                    timerMax = 1.0f;
                    break;
                case 3:
                    StartCombat();
                    timerMax = 25;
                    break;
                case 4:
                    EndCombat();
                    timerMax = 2.0f;
                    break;
            }
        }
    }

    protected override void StartTurn()
    {
        round++;
        
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
        GridUtil.Instance.ToggleGridInteraction(true, false);
        UI.UpdateText("");


        switch (round)
        {
            case 1:

                break;
            case 2:

                break;
            case 3:
                botLoader.LoadBotTeam(2);
                break;
            case 4:
                botLoader.LoadBotTeam(3);
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                botLoader.LoadBotTeam(6);
                break;
            case 8:
                botLoader.LoadBotTeam(7);
                break;
            case 9:
                botLoader.LoadBotTeam(8);
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
                Player.Instance.GetPlayerStats().GainCash(10);
                break;
            //lose
            case 2:
                UI.UpdateText("Lose");
                Player.Instance.GetPlayerStats().GainCash(6);
                break;
            //tie
            case 3:
                UI.UpdateText("Tie");
                Player.Instance.GetPlayerStats().GainCash(8);
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



