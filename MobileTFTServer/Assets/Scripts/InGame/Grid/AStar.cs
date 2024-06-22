using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class AStar
{
    private List<Vector2Int> allVisitedTiles;
    private List<Searcher> searchers;
    private List<Searcher> newSearchers;

    private bool isFound;
    private Searcher foundSearcher;
    public Vector2Int DoThing(Vector2Int[] m_allTiles, Vector2Int startTile, Vector2Int targetTile)
    {
        allVisitedTiles = new List<Vector2Int>();
        searchers = new List<Searcher>();
        newSearchers = new List<Searcher>();

        foreach (Vector2Int nei in Grid.GetNeighbours(startTile))
        {
            if (nei != new Vector2Int(-1, -1))
                if (!Grid.DoesSlotHavePawn(nei))
                    searchers.Add(new Searcher(this, targetTile, nei, null));
        }

        while (!isFound && searchers.Count > 0)
        {
            foreach (Searcher s in searchers)
            {
                if (!isFound)
                    s.MoveToNeighbour();
            }
            searchers.Clear();
            searchers.AddRange(newSearchers);
            newSearchers.Clear();
        }


        if (foundSearcher != null)
        {
            return foundSearcher.GetVisitedTiles()[0];
        }
        return new Vector2Int(-1,-1);
    }
    public void Bingo(Searcher searcher)
    {
        isFound = true;
        foundSearcher = searcher;
    }

    public bool GetIsSolved() { return isFound; }

    public List<Vector2Int> GetAllVisitedTiles() { return allVisitedTiles; }
    public List<Searcher> GetAllSearchers() { return newSearchers; }
}


public class Searcher
{
    private List<Vector2Int> visitedTiles;
    private Vector2Int spawnTile;
    private Vector2Int targetTile;
    private AStar aStar;
    public Searcher(AStar aStar, Vector2Int targetTile, Vector2Int spawnTile, List<Vector2Int> visitedTiles)
    {
        
        if (Grid.DoesSlotHavePawn(spawnTile))
        {
            aStar.GetAllSearchers().Remove(this);
        }
        this.aStar = aStar;
        this.targetTile = targetTile;
        this.spawnTile = spawnTile;

        this.visitedTiles = new List<Vector2Int>();
        if (visitedTiles != null)
        {
            this.visitedTiles.AddRange(visitedTiles);
        }

        this.visitedTiles.Add(spawnTile);
        aStar.GetAllVisitedTiles().Add(spawnTile);
    }

    public void MoveToNeighbour()
    {
       
        foreach (Vector2Int nei in Grid.GetNeighbours(spawnTile))
        {
            if (nei != new Vector2Int(-1, -1))
            {
                if (!aStar.GetAllVisitedTiles().Contains(nei))
                {
                    if (nei == targetTile)
                    {
                        aStar.Bingo(this);
                        return;
                    }

                    if (!Grid.DoesSlotHavePawn(nei))
                    {
                        aStar.GetAllSearchers().Add(new Searcher(aStar, targetTile, nei, visitedTiles));
                    }

                }
            }
        }

    }

    public List<Vector2Int> GetVisitedTiles()
    {
        return visitedTiles;
    }
}

