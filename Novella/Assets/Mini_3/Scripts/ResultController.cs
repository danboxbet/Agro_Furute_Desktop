using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    [SerializeField] private GameObject DefeatPanel;
    [SerializeField] private GameObject WinPanel;

    private void Start()
    {
        TimerControllerUI.Instance.OnDefeat += ShowDefeat;
        TimerControllerUI.Instance.OnWin += ShowWin;
    }
    private void OnDestroy()
    {
        TimerControllerUI.Instance.OnDefeat -= ShowDefeat;
        TimerControllerUI.Instance.OnWin -= ShowWin;
    }
    private void ShowDefeat()
    {
        
        DefeatPanel.SetActive(true);
    }
    private void ShowWin()
    {
       
        WinPanel.SetActive(true);

    }
}
