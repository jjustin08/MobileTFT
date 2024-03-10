using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class MovementUtil : MonoBehaviour
{
    public static MovementUtil Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Pawn> GetAllPawns()
    {
        List<Pawn> allPawns = new List<Pawn>();

        foreach(TilePosition tile in GetComponent<HexGridLayout>().GetAllTiles())
        {
            if(tile.GetSlot().GetPawn() != null)
            {
                allPawns.Add(tile.GetSlot().GetPawn());
            }    
        }

        return allPawns;
    }

    public TilePosition GetTargetInRange(int range, TilePosition tile)
    {
        
        TilePosition nearestTarget = FindNearestTarget(tile);
        int distance = tile.GetTileDistanceAway(nearestTarget, range);

        if (distance != 0) 
        {
            return nearestTarget;
        }

        return null;
    }


    public TilePosition GetNextMovementTile(TilePosition tile)
    {
        TilePosition targetTile = FindNearestTarget(tile);
        if(targetTile == null) 
            return null;

        TilePosition nextMoveTIle = null;
        int nearestDistance = 2000;

        foreach(TilePosition nei in tile.GetNeighbours())
        {
            if (nei == null)
                continue;
            if (nei.GetSlot().HasPawn())
                continue;
            
            int neiDistance = targetTile.GetTileDistanceAway(nei, 15);
            if (neiDistance < nearestDistance)
            {
                nextMoveTIle = nei;
                nearestDistance = neiDistance;
            }
        }

        return nextMoveTIle;
    }

    public TilePosition AStarNextMoveTile(TilePosition tile)
    {
        TilePosition targetTile = FindNearestTarget(tile);
        if (targetTile == null)
            return null;

        TilePosition nextMoveTile = null;
        AStar aStar = new AStar();
        nextMoveTile = aStar.DoThing(GetComponent<HexGridLayout>().GetAllTiles(), tile, targetTile);

        return nextMoveTile;
    }

        public TilePosition FindNearestTarget(TilePosition tile)
    {
        List<TilePosition> tilesWithEnemeyPawns = new List<TilePosition>();
        foreach(TilePosition nei in tile.GetNeighboursInRange(15))
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

        TilePosition nearestTarget = null;
        int nearestDistance = 2000;
        foreach(TilePosition nei in tilesWithEnemeyPawns)
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
