using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FollowCursor : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private int height = 0;

    private Rigidbody rb;

    private bool isDraging = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ToggleDraggin(bool toggle)
    {
        isDraging = toggle;
        if (!toggle)
        {
            rb.velocity = Vector3.zero;

            transform.localRotation = Quaternion.Euler(0, 0, 0);

            transform.localPosition = Vector3.zero;
        }
    }


    private void Update()
    {
        FollowMouseWithVelocity();
    }

    private void FollowMouseWithVelocity()
    {
        if (!isDraging)
            return;
        Vector3 mouseWorldPos = Player.Instance.GetPlayerInput().GetCursorWorldPos(height);

        Vector3 newWorldPos = new Vector3(mouseWorldPos.x, height, mouseWorldPos.z);

        Vector3 difference = newWorldPos - transform.position;

        rb.velocity = difference * speed;
        Quaternion rotate = Quaternion.Euler(rb.velocity.z, 0, -rb.velocity.x);
        rb.rotation = rotate;

    }

    public bool IsDraging()
    {
        return isDraging;
    }
}
