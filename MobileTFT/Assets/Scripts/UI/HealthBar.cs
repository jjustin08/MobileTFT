using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image HealthBarImage;

    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }


    private void Update()
    {
        Vector3 direction = new Vector3(0,
                                   transform.position.y - cam.transform.position.y,
                                   transform.position.z - cam.transform.position.z);
        transform.rotation = Quaternion.LookRotation(direction);
        // transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);   
    }


    public void UpdateHealthBar(float max, float current)
    {
        HealthBarImage.fillAmount = current / max;
    }
}
