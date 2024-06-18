using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LerpingMovement :MonoBehaviour
{
    public Transform oldPosition;
    public Transform newPosition;
    public Transform obj;

    private float lerpSpeed = 2f;
    private float currentLerpTime = 0f;
    private float totalLerpTime = 1f;

    private void Update()
    {
        if(!GridUtil.Instance.GetInCombat())
        {
            
            Destroy(this);

            return;
        }
        currentLerpTime += Time.deltaTime * lerpSpeed;


        if (currentLerpTime > totalLerpTime)
            currentLerpTime = totalLerpTime;

        float t = currentLerpTime / totalLerpTime;

        obj.position = Vector3.Lerp(oldPosition.position, newPosition.position, t);


        Vector3 direction = (newPosition.position - oldPosition.position).normalized;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            obj.rotation = Quaternion.Lerp(obj.rotation, targetRotation, t);
        }


        if (currentLerpTime >= totalLerpTime)
        {
            obj.SetParent(newPosition);
            Destroy(this);
        }
    }

}
