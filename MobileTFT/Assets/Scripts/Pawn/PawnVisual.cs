using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnVisual : MonoBehaviour
{
    [SerializeField] private HealthBarUI healthBar;
    [SerializeField] private HealthBarAttachedUI healthBarAttached;
    private GameObject visual;
    public void UpdateHealthBar(float max, float current)
    {
        healthBar.UpdateHealthBar(max, current);
    }

    public void UpdateManaBar(float max, float current)
    {
        healthBarAttached.UpdateManaBar(max,current);
    }

    public void SetVisual(GameObject vis)
    {
        visual = vis;
    }

    public void SetStarCountImage(int num)
    {
        healthBarAttached.SetStarImage(num);
    }

    public void SetKillCountText(int num)
    {
        healthBarAttached.SetKillCountText(num);
    }

}
