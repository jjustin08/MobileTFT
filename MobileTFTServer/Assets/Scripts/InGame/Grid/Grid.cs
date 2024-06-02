using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid
{
    private Vector2Int[] gridPositions;

    Grid() 
    {
        LayoutHexGrid(6,8);
    }


    private void LayoutHexGrid(int xSize, int ySize)
    {
        gridPositions = new Vector2Int[xSize * ySize];

        int num = 0;
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                gridPositions[num] = new Vector2Int(x, y);
                num++;

            }
        }
    }

    public Vector2Int[] GetNeighbours(Vector2Int pos)
    {
        Vector2Int[] neighbours = new Vector2Int[6];


        float evenOrOdd = pos.y;

        if (evenOrOdd % 2 == 0)
        {
            neighbours[0] = pos + new Vector2Int(1, 0);
            neighbours[1] = pos + new Vector2Int(1, -1);
            neighbours[2] = pos + new Vector2Int(0, -1);
            neighbours[3] = pos + new Vector2Int(-1, 0);
            neighbours[4] = pos + new Vector2Int(0, 1);
            neighbours[5] = pos + new Vector2Int(1, 1);
             for(int i = 0; i < neighbours.Length; i++)
            {
                if (neighbours[i].x > 5 || neighbours[i].x < 0 || neighbours[i].y > 7 || neighbours[i].y < 0)
                {
                    neighbours[i] = new Vector2Int(-1, -1);
                }
            }
        }
        else if (evenOrOdd % 2 == 1)
        {
            neighbours[0] = pos + new Vector2Int(1, 0);
            neighbours[1] = pos + new Vector2Int(0, -1);
            neighbours[2] = pos + new Vector2Int(-1, -1);
            neighbours[3] = pos + new Vector2Int(-1, 0);
            neighbours[4] = pos + new Vector2Int(-1, 1);
            neighbours[5] = pos + new Vector2Int(0, 1);
            for (int i = 0; i < neighbours.Length; i++)
            {
                if (neighbours[i].x > 5 || neighbours[i].x < 0 || neighbours[i].y > 7 || neighbours[i].y < 0)
                {
                    neighbours[i] = new Vector2Int(-1, -1);
                }
            }
        }
        return neighbours;
    }

    public Vector2Int[] GetNeighboursInRange(int range, Vector2Int startSlot)
    {
        List<Vector2Int> realNeighbours = new List<Vector2Int>();

        AddNeighboursInRange(GetNeighbours(startSlot), range, realNeighbours);

        return realNeighbours.ToArray();
    }

    private void AddNeighboursInRange(IEnumerable<Vector2Int> neighbours, int range, List<Vector2Int> realNeighbours)
    {
        if (range <= 0)
            return;

        List<Vector2Int> nextNeighbours = new List<Vector2Int>();

        foreach (Vector2Int currentNeighbour in neighbours)
        {
            if (currentNeighbour != null && !realNeighbours.Contains(currentNeighbour))
            {
                realNeighbours.Add(currentNeighbour);

                foreach (Vector2Int nextNeighbour in GetNeighbours(currentNeighbour))
                {
                    if (!realNeighbours.Contains(nextNeighbour) && !nextNeighbours.Contains(nextNeighbour))
                        nextNeighbours.Add(nextNeighbour);
                }
            }
        }

        AddNeighboursInRange(nextNeighbours, range - 1, realNeighbours);
    }
    public int GetTileDistanceAway(Vector2Int startPos,Vector2Int TargetPos, int maxRange)
    {
        if (GetNeighbours(startPos).Contains<Vector2Int>(TargetPos))
        {
            return 1;
        }
        else
        {
            for (int i = 2; i <= maxRange; i++)
            {
                if (GetNeighboursInRange(i, startPos).Contains<Vector2Int>(TargetPos))
                {
                    return i;
                }

            }
        }

        return 0;
    }

    public bool IsSlotInRange(int range, Vector2Int startSlot, Vector2Int targetSlot)
    {
        int distance = GetTileDistanceAway(startSlot, targetSlot, range);
        if (distance <= range && distance != 0)
        {
            return true;
        }
        return false;
    }
    public Vector2Int GetTargetInRange(int range, Vector2Int startSlot, List<Pawn> allPawns)
    {
        Vector2Int nearestTarget = FindNearestTarget(startSlot);
        int distance = GetTileDistanceAway(startSlot, nearestTarget, range);

        if (distance != 0)
        {
            return nearestTarget;
        }

        return new Vector2Int(-1,-1);
    }

    public Vector2Int FindNearestTarget(Vector2Int startTile, List<Pawn> allPawns)
    {
        List<Vector2Int> tilesWithEnemeyPawns = new List<Vector2Int>();
        foreach (Vector2Int nei in GetNeighboursInRange(15,startTile))
        {
            if (nei.GetSlot().HasPawn())
            {
                if (tile.GetSlot().GetPawn().IsEnemy())
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
        foreach (SlotPosition nei in tilesWithEnemeyPawns)
        {
            int neiDistance = tile.GetTileDistanceAway(nei, 15);
            if (neiDistance < nearestDistance)
            {
                nearestTarget = nei;
                nearestDistance = neiDistance;
            }
        }

        if (nearestTarget != null)
        {
            return nearestTarget;
        }

        return null;

    }

}
