using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image HealthBarImage;
    [SerializeField] private float reducespeed = 1;

    private float target;
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
        target = 1;
    }


    private void Update()
    {
        Vector3 direction = new Vector3(0,
                                   transform.position.y - cam.transform.position.y,
                                   transform.position.z - cam.transform.position.z);
        transform.rotation = Quaternion.LookRotation(direction);


        HealthBarImage.fillAmount = Mathf.MoveTowards(HealthBarImage.fillAmount, target, reducespeed *Time.deltaTime);
    }


    public void UpdateHealthBar(float max, float current)
    {
        target = current / max;
    }
}
