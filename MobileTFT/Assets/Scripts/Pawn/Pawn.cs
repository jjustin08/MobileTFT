using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private bool isEnemy;
    [SerializeField] private PawnStats stats;
    [SerializeField] private PawnMovement movement;
}
