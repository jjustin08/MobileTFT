using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameObject slot;




    public void PlacePawn(GameObject gameObject)
    {
        gameObject.transform.SetParent(transform, false);
        slot = gameObject;
    }
}
