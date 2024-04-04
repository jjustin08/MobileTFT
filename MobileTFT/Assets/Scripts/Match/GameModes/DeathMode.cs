using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathMode : GameMode
{
    [SerializeField] private Combat combat;
    [SerializeField] private CardManager cardManager;
    [SerializeField] private BotLoader botLoader;
    [SerializeField] private RoundDisplay UI;
    [SerializeField] private LevelManager levelManager;

    private float timer = 0;
    private float timerMax = 15;

    private int step = 1;
    private int stepMax = 4;

    private int round = 0;

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            timer = timerMax;
        }

        UpdateGame();
    }

    protected override void StartGame()
    {
        GridUtil.Instance.ToggleGridInteraction(false, false);
        StartTurn();
    }

    protected override void UpdateGame()
    {
        timer += Time.deltaTime;
        UI.UpdateTimer(timer, timerMax);

        if(timer > timerMax)
        {
            timer = 0;
            // Activate next step
            step++;
            if(step > stepMax)
            {
                step = 1;
            }

            switch (step)
            {
                case 1:
                    StartTurn();
                    timerMax = 20;
                    break; 
                case 2:
                    EndTurn();
                    timerMax = 2;
                    break;
                case 3:
                    StartCombat();
                    timerMax = 15;
                    break;
                case 4:
                    EndCombat();
                    timerMax = 2;
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
                UI.UpdateText("Bot Round");
                botLoader.LoadBotTeam(0);
                break;
            case 2:
                UI.UpdateText("Bot Round");
                botLoader.LoadBotTeam(1);
                break;
            case 3:
                //player round
                UI.UpdateText("Player Round      Pawns will die");
                break;
            case 4:
                UI.UpdateText("Bot Round");
                botLoader.LoadBotTeam(3);
                break;
            case 5:
                UI.UpdateText("Bot Round");
                botLoader.LoadBotTeam(4);
                break;
            case 6:
                // player round
                UI.UpdateText("Player Round      Pawns will die");
                break;
            case 7:
                UI.UpdateText("Bot Round");
                botLoader.LoadBotTeam(5);
                break;
        }
    }

    protected override void EndTurn()
    {
        GridUtil.Instance.ToggleGridInteraction(true, false);
        UI.UpdateText("");
        switch (round)
        {
            case 3:
                //player round
                botLoader.LoadBotTeam(2);
                break;
            case 6:
                // player round
                botLoader.LoadBotTeam(2);
                break;
        }
    }

    protected override void StartCombat()
    {
        combat.StartCombat();
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

        // depends on what kind of battle player or minion
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
                combat.EndCombat();
                break;
            case 5:
                combat.EndCombat();
                break;
            case 6:
                // player round
                combat.EndCombatDeath();
                break;
            case 7:
                combat.EndCombat();
                break;
        }
       
    }
}
