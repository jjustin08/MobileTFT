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

        private void Position_performed(Vector2 value)
        {
            mousePos = value;
        }

        public Ray GetMouseToScreenRay()
        {
            return mainCamera.ScreenPointToRay(GetMousePosition());
        }
    
}
