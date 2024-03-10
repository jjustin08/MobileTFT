using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TilePosition : MonoBehaviour
{
    private Vector2Int hexCoordinate;
    [SerializeField]
    private TilePosition[] tileNeighbours = new TilePosition[6];

    private Slot slot;

    private void Start()
    {
        slot = GetComponent<Slot>();
    }
    public Slot GetSlot() { return slot; }

    public void SetHexCoordinate(Vector2Int hexCoordinate)
    {
        this.hexCoordinate = hexCoordinate;
    }

    public Vector2Int GetHexCoordinate()
    {
        return this.hexCoordinate;
    }

    public void AddNeighbour(TilePosition neighbour, int slot)
    {
        tileNeighbours[slot] = neighbour;
    }

    public TilePosition[] GetNeighbours()
    {
        return tileNeighbours;
    }

    public int GetTileDistanceAway(TilePosition tilePos, int maxRange)
    {
        if (tileNeighbours.Contains<TilePosition>(tilePos))
        {
            return 1;
        }
        else
        {
            for (int i = 2; i <= maxRange; i++)
            {
                if (GetNeighboursInRange(i).Contains<TilePosition>(tilePos))
                {
                    return i;
                }

            }
        }

        return 0;
    }


    public TilePosition[] GetNeighboursInRange(int range)
    {
        List<TilePosition> realNeighbours = new List<TilePosition>();

        AddNeighboursInRange(tileNeighbours, range, realNeighbours);

        return realNeighbours.ToArray();
    }

    private void AddNeighboursInRange(IEnumerable<TilePosition> neighbours, int range, List<TilePosition> realNeighbours)
    {
        if (range <= 0)
            return;

        List<TilePosition> nextNeighbours = new List<TilePosition>();

        foreach (TilePosition currentNeighbour in neighbours)
        {
            if (currentNeighbour != null && !realNeighbours.Contains(currentNeighbour))
            {
                realNeighbours.Add(currentNeighbour);

                foreach (TilePosition nextNeighbour in currentNeighbour.GetNeighbours())
                {
                    if (!realNeighbours.Contains(nextNeighbour) && !nextNeighbours.Contains(nextNeighbour))
                        nextNeighbours.Add(nextNeighbour);
                }
            }
        }

        AddNeighboursInRange(nextNeighbours, range - 1, realNeighbours);
    }
}
