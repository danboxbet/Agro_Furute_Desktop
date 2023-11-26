using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonsEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action OnSingleCLick;
    public event Action OnExitClick;
    public event Action OnClick;
    private bool IsOnClick;
    private void Update()
    {
        if (IsOnClick)
        {
            OnClick?.Invoke();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnSingleCLick?.Invoke();
        IsOnClick = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsOnClick = false;
        OnExitClick?.Invoke();

    }

}
