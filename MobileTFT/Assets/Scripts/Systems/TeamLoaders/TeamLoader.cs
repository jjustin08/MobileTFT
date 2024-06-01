using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

static public class TeamLoader
{
    static public void LoadTeam(string msg)
    {
        int msgIndex = 1;
        string[] csv = msg.Split(',');

        while(csv[msgIndex++] != null)
        {
            PawnData data = PawnDataBase.pawns[int.Parse(csv[msgIndex])];
            msgIndex++;
            int xPos = int.Parse(csv[msgIndex]);
            msgIndex++;
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
        }
       

    }
}
