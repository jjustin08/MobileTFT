using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interaction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool isClicking = false;
    private void Update()
    {
        if (isClicking)
        {
            if (Player.Instance.GetPlayerInput().IsDrag())
            {
                OnDrag();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClicking = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClicking = false;
        if (Player.Instance.GetPlayerInput().IsClick())
        {

            OnClick();
        }


        if (Player.Instance.GetPlayerInput().IsDragCanceled())
        {
            OnDragCanceled();
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHover();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        OnHoverCanceled();
    }

    virtual protected void OnClick() { }
    virtual protected void OnDrag() { }
    virtual protected void OnDragCanceled() { }
    virtual protected void OnHover() { }
    virtual protected void OnHoverCanceled() { }

}
