using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    [SerializeField] private TimePlay timePlay;

    [SerializeField] private Text timeText;

    private void Update()
    {
        SetFormatTime(timePlay.TimeToPlay);   
    }

    private void SetFormatTime(float time)
    {
        var minute = (Mathf.Floor(time / 60));
        var seconds = Mathf.Floor((time - (minute * 60)));

        timeText.text = minute.ToString("00") + ":" + seconds.ToString("00");
    }
}
