using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPawn : MonoBehaviour
{
    [SerializeField] private Pawn pawn;


    public Pawn GetPawn() { return pawn; }
}
