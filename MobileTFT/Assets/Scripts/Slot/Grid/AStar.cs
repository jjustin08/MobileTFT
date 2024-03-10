using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Searcher;
using UnityEngine;

public class AStar
{
    private  List<TilePosition> allVisitedTiles;
    private  List<Searcher> searchers;
    private  List<Searcher> newSearchers;

    private  bool isFound;
    private  Searcher foundSearcher;
    public TilePosition DoThing(TilePosition[] m_allTiles, TilePosition startTile, TilePosition targetTile)
    {
        allVisitedTiles = new List<TilePosition>();
        searchers = new List<Searcher>();
        newSearchers = new List<Searcher>();

        foreach (TilePosition nei in startTile.GetNeighbours())
        {
            if (nei != null)
                if(!nei.GetSlot().HasPawn())
                    searchers.Add(new Searcher(this, targetTile, nei, null));
        }

        while(!isFound && searchers.Count > 0)
        {
            foreach (Searcher s in searchers)
            {
                if(!isFound)
                s.MoveToNeighbour();
            }
            searchers.Clear();
            searchers.AddRange(newSearchers);
            newSearchers.Clear();
        }


        if(foundSearcher != null)
        {
            return foundSearcher.GetVisitedTiles()[0];
        }
        return null;
    }
    public void Bingo(Searcher searcher)
    {
        isFound = true;
        foundSearcher = searcher;
    }

    public bool GetIsSolved() { return isFound; }
    
    public List<TilePosition> GetAllVisitedTiles() { return allVisitedTiles; }
    public List<Searcher> GetAllSearchers() { return newSearchers; }
}


public class Searcher
{
    private List<TilePosition> visitedTiles;
    private TilePosition spawnTile;
    private TilePosition targetTile;
    private AStar aStar;
    public Searcher(AStar aStar, TilePosition targetTile, TilePosition spawnTile, List<TilePosition> visitedTiles)
    {
        if(spawnTile.GetSlot().HasPawn())
        {
            aStar.GetAllSearchers().Remove(this);
        }
        this.aStar = aStar;
        this.targetTile = targetTile;
        this.spawnTile = spawnTile;

        this.visitedTiles = new List<TilePosition>();
        if (visitedTiles != null)
        {
            this.visitedTiles.AddRange(visitedTiles);
        }
            
        this.visitedTiles.Add(spawnTile);
        aStar.GetAllVisitedTiles().Add(spawnTile);
    }

    public void MoveToNeighbour()
    {
        foreach (TilePosition nei in spawnTile.GetNeighbours())
        {
            if (nei != null)
            {
                if (!aStar.GetAllVisitedTiles().Contains(nei))
                {
                    if (nei == targetTile)
                    {
                        aStar.Bingo(this);
                        return;
                    }
                   
                    if (!nei.GetSlot().HasPawn())
                    {
                        aStar.GetAllSearchers().Add(new Searcher(aStar, targetTile, nei, visitedTiles));
                    }
                    
                }
            }
        }
        
    }

    public List<TilePosition> GetVisitedTiles()
    {
        return visitedTiles;
    }
}

