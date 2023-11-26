using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlay : MonoBehaviour
{
    [SerializeField] private float timeToPlay;

    public float TimeToPlay => timeToPlay;

    public event Action TimeToEnd;

    public bool IsPlayMode=true;

    private void Update()
    {
        if (IsPlayMode)
        {
            timeToPlay -= Time.deltaTime;

            if (timeToPlay <= 0)
            {
                timeToPlay = 0;
                TimeToEnd.Invoke();
            }
        }
    }



}
