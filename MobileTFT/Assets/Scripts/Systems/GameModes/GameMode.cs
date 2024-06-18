using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    virtual public void RecieveServerMsg(string msg) { }
    virtual protected void StartGame(){}

    virtual protected void UpdateGame() { }

    virtual protected void StartTurn(){}

    virtual protected void EndTurn(string msg) {}

    virtual protected void StartCombat(){}

    virtual protected void EndCombat(){}

    virtual protected void EndGame(){}
}

static public class Step
{
    public const int TurnStart = 1;
    public const int TurnEnd = 2;
    public const int CombatStart = 3;
    public const int CombatEnd = 4;
}


#region Protocol Signifiers
static public class GameModeSignifiers
{
    public const int StartGame = 1;
    public const int StartTurn = 2;
    public const int EndTurn = 3;
    public const int StartCombat = 4;
    public const int EndCombat = 5;
    public const int EndGame = 6;

}

#endregion