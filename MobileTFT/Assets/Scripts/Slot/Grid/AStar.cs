using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    private HexGridLayout gridLayout;

    private void Start()
    {
        gridLayout = GetComponent<HexGridLayout>();
    }
}
