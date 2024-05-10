using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    virtual public void RecieveServerMsg(string msg) { }
    virtual protected void StartGame(){}

    virtual protected void UpdateGame() { }

    virtual protected void StartTurn(){}

    virtual protected void EndTurn(){}

    virtual protected void StartCombat(){}

    virtual protected void EndCombat(){}

    virtual protected void EndGame(){}
}
