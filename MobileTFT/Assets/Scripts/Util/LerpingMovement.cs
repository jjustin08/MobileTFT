using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LerpingMovement :MonoBehaviour
{
    public Transform oldSlot;
    public Transform newSlot;
    public Transform pawn;

    private float lerpSpeed = 2f;
    private float currentLerpTime = 0f;
    private float totalLerpTime = 1f;

    private void Update()
    {

        currentLerpTime += Time.deltaTime * lerpSpeed;


        if (currentLerpTime > totalLerpTime)
            currentLerpTime = totalLerpTime;

        float t = currentLerpTime / totalLerpTime;

        pawn.position = Vector3.Lerp(oldSlot.position, newSlot.position, t);


        Vector3 direction = (newSlot.position - oldSlot.position).normalized;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            pawn.rotation = Quaternion.Lerp(pawn.rotation, targetRotation, t);
        }


        if (currentLerpTime >= totalLerpTime)
        {
            pawn.SetParent(newSlot);
            Destroy(this);
        }
    }

}
