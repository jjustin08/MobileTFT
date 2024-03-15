using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Team : MonoBehaviour
{
    [SerializeField] private List<GameObject> pawns = new List<GameObject>();
    [SerializeField] private List<GameObject> savedPawns = new List<GameObject>();
    // list of pawns
    // also want know there location
    // will load team into battle field
    // probably set it to enemy
    // for multiplayer positions cant be same need to reverse

    private void Update()
    {
        
    }

    public void SaveTeam()
    {
        foreach(GameObject p in pawns)
        {
            GameObject newPawn = Instantiate(p,transform);
            savedPawns.Add(newPawn);
            newPawn.SetActive(false);
        }
    }

    public void LoadTeam() 
    {
        foreach (GameObject p in savedPawns)
        {
            //GameObject newPawn = Instantiate(p, transform);
            //savedPawns.Add(newPawn);
            p.SetActive(true);
        }

    }
}
