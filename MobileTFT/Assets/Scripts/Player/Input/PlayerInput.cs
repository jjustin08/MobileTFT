using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
        [SerializeField] private Camera mainCamera;

    private InputActions inputActions;

    private bool isClicked;
        private bool isDragStarted;
        private bool isDragging;
        private bool isDraggingCanceled;
        private Vector3 mousePos;

        private int timer;
        private int timerMax = 10;

        public void Awake()
        {
        inputActions = new InputActions();
        inputActions.Enable();

        inputActions.Player.Press.performed += Press_performed;
        
        inputActions.Player.Drag.started += Drag_started;
        inputActions.Player.Drag.performed += Drag_performed;
        inputActions.Player.Drag.canceled += Drag_canceled; ;

        inputActions.Player.PressPos.performed += Position_performed;

        timer = timerMax;
        }

   

    private void Update()
        {
            if (isDragStarted)
            {
                if (timer == 0)
                {
                    timer = timerMax;
                    isDragStarted = false;
                }
                else
                {
                    timer--;
                }
            }
            else if (isDraggingCanceled)
            {

                if (timer == 0)
                {
                    timer = timerMax;
                    isDraggingCanceled = false;
                }
                else
                {
                    timer--;
                }
            }
        }

        private void LateUpdate()
        {
            isClicked = false;
        }

        private void Drag_started(InputAction.CallbackContext obj)
        {
            isDragStarted = true;
        }



        private void Drag_canceled(InputAction.CallbackContext obj)
        {
            if (isDragging)
            {
                isDraggingCanceled = true;
                isDragging = false;
            }
        }

        private void Drag_performed(InputAction.CallbackContext obj)
        {
            isDragging = true;
        }

    private void Press_performed(InputAction.CallbackContext obj)
    {
        isClicked = true;
    }


    public bool IsClick()
    {
       return isClicked;
    }

        public bool IsDragStarted()
        {
            return isDragStarted;
        }

        public bool IsDrag()
        {
            return isDragging;
        }

        public bool IsDragCanceled()
        {
            return isDraggingCanceled;
        }

        public Vector3 GetMousePosition()
        {
            return mousePos;
        }

        private void Position_performed(InputAction.CallbackContext obj)
        {
            mousePos = obj.ReadValue<Vector2>();
        }

        public Ray GetMouseToScreenRay()
        {
            return mainCamera.ScreenPointToRay(GetMousePosition());
        }


    public GameObject TestCardTileIntercept()
    {
        Ray ray = mainCamera.ScreenPointToRay(GetMousePosition());
        Physics.Raycast(ray, out RaycastHit hit, 100f, mainCamera.cullingMask, QueryTriggerInteraction.Ignore);

        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }
        return null;

    }

    public Vector3 GetCursorWorldPos(float height)
    {
        Plane plane = new Plane(Vector3.up, Vector3.one * height);
        Ray ray = GetMouseToScreenRay();

        float entry;

        if (plane.Raycast(ray, out entry))
        {

            return ray.GetPoint(entry);
        }

        return Vector3.zero;
    }

}
