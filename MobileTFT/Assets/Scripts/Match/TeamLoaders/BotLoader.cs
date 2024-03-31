using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotLoader : MonoBehaviour
{
    [SerializeField] private List<BotSavedTeam> teams = new List<BotSavedTeam>();

    private void Update()
    {
        //TODO: create checks
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ClearEnemyPawns();
            teams[0].LoadTeam();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ClearEnemyPawns();
            teams[1].LoadTeam();
        }

        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    //create and save team
        //    GameObject newTeam = Instantiate(new GameObject());
        //    PlayerSavedTeam team = newTeam.AddComponent<PlayerSavedTeam>();
        //    teams.Add(team);
        //    team.SaveTeam(true);
        //}
    }

    //temp function
    private void ClearEnemyPawns()
    {
        foreach(Pawn pawn in GridUtil.Instance.GetAllPawns(false))
        {
            pawn.SelfDestruct();
        }
      
    }

}
