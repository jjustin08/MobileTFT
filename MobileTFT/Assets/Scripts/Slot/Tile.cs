using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameObject slot;




    public void FillSlot(GameObject gameObject)
    {
        GameObject g = Instantiate(gameObject);
        g.transform.SetParent(transform, false);
        slot = g;
    }
}
