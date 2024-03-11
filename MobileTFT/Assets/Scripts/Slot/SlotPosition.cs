using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlotPosition : MonoBehaviour
{
    private Vector2Int hexCoordinate;
    [SerializeField]
    private SlotPosition[] tileNeighbours = new SlotPosition[6];

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

    public void AddNeighbour(SlotPosition neighbour, int slot)
    {
        tileNeighbours[slot] = neighbour;
    }

    public SlotPosition[] GetNeighbours()
    {
        return tileNeighbours;
    }

    public int GetTileDistanceAway(SlotPosition tilePos, int maxRange)
    {
        if (tileNeighbours.Contains<SlotPosition>(tilePos))
        {
            return 1;
        }
        else
        {
            for (int i = 2; i <= maxRange; i++)
            {
                if (GetNeighboursInRange(i).Contains<SlotPosition>(tilePos))
                {
                    return i;
                }

            }
        }

        return 0;
    }


    public SlotPosition[] GetNeighboursInRange(int range)
    {
        List<SlotPosition> realNeighbours = new List<SlotPosition>();

        AddNeighboursInRange(tileNeighbours, range, realNeighbours);

        return realNeighbours.ToArray();
    }

    private void AddNeighboursInRange(IEnumerable<SlotPosition> neighbours, int range, List<SlotPosition> realNeighbours)
    {
        if (range <= 0)
            return;

        List<SlotPosition> nextNeighbours = new List<SlotPosition>();

        foreach (SlotPosition currentNeighbour in neighbours)
        {
            if (currentNeighbour != null && !realNeighbours.Contains(currentNeighbour))
            {
                realNeighbours.Add(currentNeighbour);

                foreach (SlotPosition nextNeighbour in currentNeighbour.GetNeighbours())
                {
                    if (!realNeighbours.Contains(nextNeighbour) && !nextNeighbours.Contains(nextNeighbour))
                        nextNeighbours.Add(nextNeighbour);
                }
            }
        }

        AddNeighboursInRange(nextNeighbours, range - 1, realNeighbours);
    }
}
