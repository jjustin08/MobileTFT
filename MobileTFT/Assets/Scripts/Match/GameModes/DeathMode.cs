using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMode : GameMode
{
    [SerializeField] private Combat combat;
    [SerializeField] private CardManager cardManager;

    private float Timer = 0;
    private float TimerMax = 15;

    private int step = 1;
    private int StepMax = 4;

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        UpdateGame();
    }

    protected override void StartGame()
    {
        GridUtil.Instance.ToggleGridInteraction(false, false);
        StartTurn();
    }

    protected override void UpdateGame()
    {
        Timer += Time.deltaTime;

        if(Timer > TimerMax)
        {
            Timer = 0;
            // Activate next step
            step++;
            if(step > StepMax)
            {
                step = 1;
            }

            switch (step)
            {
                case 1:
                    StartTurn();
                    TimerMax = 20;
                    break; 
                case 2:
                    EndTurn();
                    TimerMax = 2;
                    break;
                case 3:
                    StartCombat();
                    TimerMax = 15;
                    break;
                case 4:
                    EndCombat();
                    TimerMax = 2;
                    break;
            }
        }
    }

    protected override void StartTurn()
    {
        GridUtil.Instance.ToggleGridInteraction(true, true);
        cardManager.ReRollPawns();
    }

    protected override void EndTurn()
    {
        GridUtil.Instance.ToggleGridInteraction(true, false);
    }

    protected override void StartCombat()
    {
        combat.StartCombat();
    }

    protected override void EndCombat()
    {
        switch (combat.CheckCombatState())
        {
            //win
            case 1:
                CashManager.Instance.GainCash(10);
                break;
            //lose
            case 2:
                CashManager.Instance.GainCash(5);
                break;
            //tie
            case 3:
                CashManager.Instance.GainCash(5);
                break;
            default: 
                break;


        }

        // depends on what kind of battle player or minion
        combat.EndCombatDeath();
    }
}
