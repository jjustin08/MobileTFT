using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnStats : MonoBehaviour
{
    // TODO get base stats from scriptible object
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float attackTime;
    [SerializeField] private int range;



    public float GetAttackTime(){return attackTime;}
    public float GetHealth() { return health;}
    public float GetDamage() { return damage;}
    public int GetRange() { return range; }

    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }
}
