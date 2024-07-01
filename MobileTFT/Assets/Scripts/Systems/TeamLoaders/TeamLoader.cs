using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

static public class TeamLoader
{
    static private List<Pawn> allPawns = new List<Pawn>();

    static public List<Pawn> GetSortedPawnsList()
    {
        return allPawns;
    }
    static public void LoadTeam(string msg)
    {
        List<Pawn> enemyPawns = new List<Pawn>();
        foreach (Pawn pawn in GridUtil.Instance.GetAllPawns(false))
        {
            pawn.SelfDestruct();
        }

        int msgIndex = 1;
        string[] csv = msg.Split(',');

        while (csv.Length > msgIndex + 1 && csv[msgIndex + 1] != ";")
        {
            ++msgIndex;
            PawnData data = PawnDataBase.pawns[int.Parse(csv[msgIndex])];
            ++msgIndex;
            int xPos = int.Parse(csv[msgIndex]);
            ++msgIndex;
            int yPos = int.Parse(csv[msgIndex]);
            Vector2Int position = new Vector2Int(xPos, yPos);

            Slot slot = GridUtil.Instance.GetSlotPositionFromVector2(position).GetSlot();


            GameObject pawnObject = Object.Instantiate(data.placedPawn);
            Pawn newPawn = pawnObject.GetComponent<Pawn>();
            newPawn.SetPawnData(data);
            slot.PlacePawn(newPawn);

            newPawn.GetStats().SetKillCount(0);
            newPawn.GetStats().SetDeathCount(0);
            newPawn.GetStats().SetStarCount(0);
            newPawn.SetEnemy(true);
            newPawn.transform.Rotate(0f, 180f, 0f);
            enemyPawns.Add(newPawn);
        }
        ++msgIndex;
        while (csv.Length > msgIndex + 1 && csv[msgIndex + 1] != "")
        {
            ++msgIndex;
            int playerID = int.Parse(csv[msgIndex]);
            ++msgIndex;
            int playerIndex = int.Parse(csv[msgIndex]);
            ++msgIndex;
            int sortedIndex = int.Parse(csv[msgIndex]);

          

            while (allPawns.Count <= sortedIndex)
            {
                allPawns.Add(null); 
            }
            Debug.Log("allpawns: " + allPawns.Count);
            Debug.Log("sortedIndex: " + sortedIndex);
            Debug.Log("Enemiespawns: " + enemyPawns.Count);
            Debug.Log("playerspawns: " + Player.Instance.GetPlayerStats().GetPawnList().Count);


            if (playerID == 0) 
            {

                allPawns[sortedIndex]=enemyPawns[playerIndex];
            }
            else
            {
                
                allPawns[sortedIndex] = Player.Instance.GetPlayerStats().GetPawnList()[playerIndex];
            } 
        }

    }

   
}
