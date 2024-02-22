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
        Vector3 mouseWorldPos = GetCursorWorldPos();

        Vector3 newWorldPos = new Vector3(mouseWorldPos.x, height, mouseWorldPos.z);

        Vector3 difference = newWorldPos - transform.position;

        rb.velocity = difference * speed;
        Quaternion rotate = Quaternion.Euler(rb.velocity.z, 0, -rb.velocity.x);
        rb.rotation = rotate;

    }



    private Vector3 GetCursorWorldPos()
    {
        Plane plane = new Plane(Vector3.up, Vector3.one * height);
        Ray ray = Player.Instance.GetPlayerInput().GetMouseToScreenRay();

        float entry;

        if (plane.Raycast(ray, out entry))
        {

            return ray.GetPoint(entry);
        }

        return Vector3.zero;
    }

    public bool IsDraging()
    {
        return isDraging;
    }
}
