using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnVisual : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    private GameObject visual;
    public void UpdateHealthBar(float max, float current)
    {
        healthBar.UpdateHealthBar(max, current);
    }

    public void SetVisual(GameObject vis)
    {
        visual = vis;
    }

}
