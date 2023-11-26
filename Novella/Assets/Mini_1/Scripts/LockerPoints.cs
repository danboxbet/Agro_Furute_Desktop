using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerPoints : MonoBehaviour
{
    private PointsController pointsController;
    public event Action OnWin;
    public List<RectTransform> rectTransforms;
    void Start()
    {
        pointsController = GetComponent<PointsController>();
    }

    
    void Update()
    {
        if (rectTransforms.Count == 7) OnWin.Invoke();
    }
}
