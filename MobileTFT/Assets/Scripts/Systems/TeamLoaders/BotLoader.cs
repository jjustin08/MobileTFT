using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BotLoader : MonoBehaviour
{
    //TODO : server
    [SerializeField] private List<BotTeamSO> teams = new List<BotTeamSO>();

    private void ClearEnemyPawns()
    {
        foreach(Pawn pawn in GridUtil.Instance.GetAllPawns(false))
        {
            pawn.SelfDestruct();
        }
    }

    public void LoadBotTeam(int index)
    {
        ClearEnemyPawns();
        //teams[index].LoadTeam();
    }

}
