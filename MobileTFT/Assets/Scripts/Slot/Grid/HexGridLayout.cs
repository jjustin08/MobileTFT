using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HexGridLayout : MonoBehaviour
{
    private AStar aStar;



    [SerializeField] private GameObject emptyTile;


    private TilePosition[] m_allTiles;

    private float outerSize = 1;

    private void Start()
    {
        aStar = GetComponent<AStar>();
        LayoutGrid(6,8);
    }

    public TilePosition[] LayoutGrid(int sizeX, int sizeY)
    {
        m_allTiles = new TilePosition[sizeX * sizeY];
        int num = 0;
        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                // tile object generation from prefab
                GameObject tileGameObject = Instantiate(emptyTile, transform);
                tileGameObject.name = $"{num}Tile {x}, {y}";

                // transform
                tileGameObject.transform.position = GetPositionForHexFromCoordinate(new Vector2Int(x, y));
                tileGameObject.GetComponent<TilePosition>().SetHexCoordinate(new Vector2Int(x, y));

                // for neighbors
                m_allTiles[num] = tileGameObject.GetComponent<TilePosition>();
                num++;

            }
        }


        // Neigherbors
        for (int i = 0; i < m_allTiles.Length; i++)
        {
            int neiNum = 0;
            for (int j = 1; j < m_allTiles.Length; j++)
            {
                Vector2 difference = m_allTiles[j].GetHexCoordinate() - m_allTiles[i].GetHexCoordinate();
                float evenOrOdd = m_allTiles[i].GetHexCoordinate().y;

                if (evenOrOdd % 2 == 0)
                {
                    if (difference == new Vector2(1, 0) ||
                        difference == new Vector2(1, -1) ||
                        difference == new Vector2(0, -1) ||
                        difference == new Vector2(-1, 0) ||
                        difference == new Vector2(0, 1) ||
                        difference == new Vector2(1, 1))
                    {
                        m_allTiles[i].AddNeighbour(m_allTiles[j], neiNum);
                        neiNum++;
                    }
                }
                if (evenOrOdd % 2 == 1)
                {
                    if (difference == new Vector2(1, 0) ||
                        difference == new Vector2(0, -1) ||
                        difference == new Vector2(-1, -1) ||
                        difference == new Vector2(-1, 0) ||
                        difference == new Vector2(-1, 1) ||
                        difference == new Vector2(0, 1))
                    {
                        m_allTiles[i].AddNeighbour(m_allTiles[j], neiNum); ;
                        neiNum++;
                    }
                }
            }


        }

        //add first tile
        foreach (TilePosition obj in m_allTiles[0].GetNeighbours())
        {
            if (obj != null)
                obj.AddNeighbour(m_allTiles[0], 5);
        }


        return m_allTiles;
    }





    public Vector3 GetPositionForHexFromCoordinate(Vector2Int coordinate)
    {
        int column = coordinate.x;
        int row = coordinate.y;

        float width, height, xPosition, yPosition;
        bool shouldOffset;
        float horizontalDistance, verticalDistance, offset, size = outerSize;


        shouldOffset = (row % 2) == 0;
        width = Mathf.Sqrt(3) * size;
        height = 2f * size;

        horizontalDistance = width;
        verticalDistance = height * (3f / 4f);

        offset = (shouldOffset) ? width / 2 : 0;

        xPosition = (column * (horizontalDistance)) + offset;
        yPosition = (row * (verticalDistance));

        return new Vector3(xPosition, 0, -yPosition);
    }

    public TilePosition[] GetAllTiles()
    {
        return m_allTiles;
    }

}
