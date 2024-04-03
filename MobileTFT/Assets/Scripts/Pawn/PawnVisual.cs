using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnVisual : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private HealthBarAttached healthBarAttached;
    private GameObject visual;
    public void UpdateHealthBar(float max, float current)
    {
        healthBar.UpdateHealthBar(max, current);
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
