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
            teams[0].LoadTeam(false);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            //create and save team
            GameObject newTeam = Instantiate(new GameObject());
            Team team = newTeam.AddComponent<Team>();
            teams.Add(team);
            team.SaveTeam(true);
        }
    }


    private void SwitchEnemy()
    {

    }
}
