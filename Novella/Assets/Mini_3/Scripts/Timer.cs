using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer 
{
    private float duration;
    private float currentTime;
    private bool continuesTime;
   public void Initialize(float duration)
   {
            this.duration = duration;
            currentTime = duration;
            continuesTime = true;
        
   }
    public void Updates()
    {
        if(currentTime>0 && continuesTime)
        {
            currentTime -= Time.deltaTime;
        }
        if (currentTime <= 0)
        {
            continuesTime = false;
            currentTime = 0;
        }
    }
    public void Stop()
    {
        continuesTime = false;
    }
    public void Continue()
    {
        continuesTime = true;
    }
    public void Reset()
    {
        currentTime = duration;
        continuesTime = true;
    }
    public float GetCurrentTime()
    {
        return currentTime;
    }
}
