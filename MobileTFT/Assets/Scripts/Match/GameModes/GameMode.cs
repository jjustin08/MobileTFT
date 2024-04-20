using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    virtual protected void StartGame(){}

    protected virtual void UpdateGame() { }

    virtual protected void StartTurn(){}

    virtual protected void EndTurn(){}

    virtual protected void StartCombat(){}

    virtual protected void EndCombat(){}

    virtual public void EndGame(){}
}
