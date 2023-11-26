using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateRectTransform : MonoBehaviour
{
     
     private RectTransform rectTransform;

    public void UpdateRect(RectTransform rectTransform)
    {
        this.rectTransform = rectTransform;
    }
    public void RotateTo()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, 90);
        rectTransform.rotation *= targetRotation;
        Debug.Log(rectTransform.rotation);
    }
}
