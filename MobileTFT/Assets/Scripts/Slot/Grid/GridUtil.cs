using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Tilemaps;

public class GridUtil : MonoBehaviour
{
    public static GridUtil Instance;

    private HexGridLayout hexGrid;
    private void Awake()
    {
        Instance = this;
        hexGrid= GetComponent<HexGridLayout>();


    }
    public SlotPosition GetOppositeSlot(SlotPosition p)
    {
       for (int i = 0; i < hexGrid.GetAllTiles().Length; i++)
        {
            if (hexGrid.GetAllTiles()[i] == p)
            {
                return (hexGrid.GetAllTiles()[hexGrid.GetAllTiles().Length - i  - 1]);
            }
        }
       

        return null;
    }

    public List<Slot> GetOneSideOfSlots(bool friendly)
    {
        List<Slot> halfSlots = new List<Slot>();
        int startCount = 0;
        int maxCount = GetAllSlots().Count / 2;

        if (friendly)
        {
            startCount = GetAllSlots().Count / 2;
            maxCount = GetAllSlots().Count;
        }
        for (int i = startCount; i < maxCount; i++)
        {
            halfSlots.Add(GetAllSlots()[i]);
        }
        return halfSlots;
    }

    public void ToggleGridInteraction(bool friendly, bool toggle)
    {
        foreach (Slot s in GetOneSideOfSlots(friendly))
        {
            s.GetSlotInteraction().gameObject.SetActive(toggle);
        }

    }
    public List<Slot> GetAllSlots()
    {
        List<Slot> allSlots = new List<Slot>();

        foreach (SlotPosition tile in hexGrid.GetAllTiles())
        {
            if (tile.GetSlot() != null)
            {
                allSlots.Add(tile.GetSlot());
            }
        }

        return allSlots;
    }
    public List<Pawn> GetAllPawns()
    {
        List<Pawn> allPawns = new List<Pawn>();

        foreach(Slot slot in GetAllSlots())
        {
            if(slot.GetPawn() != null)
            {
                allPawns.Add(slot.GetPawn());
            }    
        }

        return allPawns;
    }

    public SlotPosition GetTargetInRange(int range, Slot slot)
    {
        SlotPosition currentTile = slot.GetSlotPos();
        SlotPosition nearestTarget = FindNearestTarget(currentTile);
        int distance = currentTile.GetTileDistanceAway(nearestTarget, range);

        if (distance != 0) 
        {
            return nearestTarget;
        }

        return null;
    }

    public SlotPosition AStarNextMoveTile(Slot slot)
    {
        SlotPosition currentTile = slot.GetSlotPos();
        SlotPosition targetTile = FindNearestTarget(currentTile);
        if (targetTile == null)
            return null;

        SlotPosition nextMoveTile = null;
        AStar aStar = new AStar();
        nextMoveTile = aStar.DoThing(hexGrid.GetAllTiles(), currentTile, targetTile);

        return nextMoveTile;
    }

        public SlotPosition FindNearestTarget(SlotPosition tile)
    {
        List<SlotPosition> tilesWithEnemeyPawns = new List<SlotPosition>();
        foreach(SlotPosition nei in tile.GetNeighboursInRange(15))
        {
            if(nei.GetSlot().HasPawn())
            {
                if(tile.GetSlot().GetPawn().IsEnemy())
                {
                    if (!nei.GetSlot().GetPawn().IsEnemy())
                    {
                        tilesWithEnemeyPawns.Add(nei);
                    }
                }
                else 
                {
                    if (nei.GetSlot().GetPawn().IsEnemy())
                    {
                        tilesWithEnemeyPawns.Add(nei);
                    }
                }
              
            }
        }

        SlotPosition nearestTarget = null;
        int nearestDistance = 2000;
        foreach(SlotPosition nei in tilesWithEnemeyPawns)
        {
            int neiDistance = tile.GetTileDistanceAway(nei,15);
            if (neiDistance < nearestDistance)
            {
                nearestTarget = nei;
                nearestDistance = neiDistance;
            }
        }

        if(nearestTarget != null) 
        {
            return nearestTarget;
        }

        return null;
       
    }
}
