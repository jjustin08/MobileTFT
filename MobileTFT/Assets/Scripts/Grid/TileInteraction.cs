using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInteraction : Interaction
{
    [SerializeField] private Tile tile;
    override protected void OnClick() 
    {
        tile.FillSlot(Player.Instance.GetTestObject());
    }
}
