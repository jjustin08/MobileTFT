using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    // I want to run all game mechanics throught this class
    // this will be a parent class to other game modes

    virtual protected void StartGame(){}

    protected virtual void UpdateGame() { }

    virtual protected void StartTurn(){}

    virtual protected void EndTurn(){}

    virtual protected void StartCombat(){}

    virtual protected void EndCombat(){}

    virtual protected void EndGame(){}
}
