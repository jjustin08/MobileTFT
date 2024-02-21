using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragObject : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private int height = 2;

    private InputActions inputActions;

    private Rigidbody rb;

    private bool isDraging = false;

    //private bool allowInteraction = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        inputActions = new InputActions();
        inputActions.Enable();
    }



    private void Update()
    {
        FollowMouseWithVelocity();
    }

    private void FollowMouseWithVelocity()
    {
        //if (!isDraging)
        //    return;
        //Plane plane = new Plane(Vector3.up, Vector3.one * height);
        //Ray ray = Camera.main.ScreenPointToRay(inputActions.InGame.PressPos.ReadValue<Vector2>());

        //float entry;

        //plane.Raycast(ray, out entry);
        

        //Vector3 mouseWorldPos = ray.GetPoint(entry);
        //Vector3 newWorldPos = new Vector3(mouseWorldPos.x, height, mouseWorldPos.z);

        //Vector3 difference = newWorldPos - transform.position;

        //rb.velocity = difference * speed;
        //Quaternion rotate = Quaternion.Euler(rb.velocity.z, 0, -rb.velocity.x) * Camera.main.transform.rotation;
        //rb.rotation = rotate;

    }

    public void ToggleDraggin(bool toggle)
    {
        isDraging = toggle;

        if (!toggle)
        {
            rb.velocity = Vector3.zero;
            //reset transform

            transform.localRotation = Quaternion.Euler(0, 0, 0);

            transform.localPosition = Vector3.zero;
        }
    }

    public bool IsDraging()
    {
        return isDraging;
    }
}
