using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControllerUI : MonoSingletone<TimerControllerUI>
{
    [SerializeField] private Text timerGames;
    [SerializeField] private float mainTime;
    [SerializeField] private float winTime;
    public float IsWinTime => winTime;
    public event Action OnDefeat;
    public event Action OnWin;

    private float currentMainTime;
    private float currentMainTimeMinutes;
    private float currentMainTimeSecond;
    public float currentWinTime { get; private set; }
    private Timer mainTimer;
    private Timer winsTimer;
    private bool IsInitialWinTimer=false;
    private void Start()
    {
        mainTimer = new Timer();
        winsTimer = new Timer();
        mainTimer.Initialize(mainTime);
       
    }
    private void Update()
    {
        mainTimer.Updates();
        currentMainTime = mainTimer.GetCurrentTime();
        UpdateMainTimerUI();
        if (currentMainTime <= 0) OnDefeat.Invoke();
       // Debug.Log(currentWinTime);
        if (currentWinTime <= 0 && IsInitialWinTimer)
        {
            mainTimer.Stop();
            OnWin.Invoke();
        }
    }
    private void UpdateMainTimerUI()
    {
       
        currentMainTimeMinutes = Mathf.Floor(currentMainTime / 60);
        currentMainTimeSecond = currentMainTime % 60;
        timerGames.text = $"{currentMainTimeMinutes.ToString("00")}:{Mathf.Floor(currentMainTimeSecond).ToString("00")}";
    }
    public void InitialTimer()
    {
        winsTimer = new Timer();
        winsTimer.Initialize(winTime);
    }
    public void UpdateWinTimer()
    {
        IsInitialWinTimer = true;
        winsTimer.Updates();
        currentWinTime = winsTimer.GetCurrentTime();
    }
    public void ContinueTimer()
    {
        winsTimer.Continue();
    }
    public void StopTimer()
    {
        winsTimer.Stop();
    }
}
