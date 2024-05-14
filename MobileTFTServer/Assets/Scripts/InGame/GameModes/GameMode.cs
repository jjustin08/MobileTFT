using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    virtual public void StartGame() { }

    virtual protected void UpdateGame() { }

    virtual protected void StartTurn() { }

    virtual protected void EndTurn() { }

    virtual protected void StartCombat() { }

    virtual protected void EndCombat() { }

    virtual protected void EndGame() { }
}

static public class Step
{
    public const int TurnStart = 1;
    public const int TurnEnd = 2;
    public const int CombatStart = 3;
    public const int CombatEnd = 4;
}
