using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSaver : MonoBehaviour
{
    [SerializeField] private List<Team> teams = new List<Team>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SwitchEnemie();
        }
        if (Input.GetKey(KeyCode.O))
        {
            //create and save team
            Team newTeam = Instantiate<Team>(new Team());
            teams.Add(newTeam);
            newTeam.SaveTeam();
        }
    }


    private void SwitchEnemie()
    {

    }
}
