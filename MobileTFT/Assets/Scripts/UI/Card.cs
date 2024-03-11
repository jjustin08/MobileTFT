using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private Pawn pawn;


    public Pawn GetPawn() { return pawn; }
}
