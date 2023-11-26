using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultMiniFour : MonoBehaviour
{
    [SerializeField] private TimePlay timePlay;

    [SerializeField] private CoinsBack coinsBack;

    [SerializeField] private GameObject WinPanel;

    [SerializeField] private GameObject DefeatPanel;

    [SerializeField] private int needScore;

    private void Start()
    {
        DefeatPanel.SetActive(false);
        WinPanel.SetActive(false);

        timePlay.TimeToEnd += SetLosePlay;
        coinsBack.OnAddCoin += SetWinPlay;
    }

    private void OnDestroy()
    {
        timePlay.TimeToEnd -= SetLosePlay;
        coinsBack.OnAddCoin -= SetWinPlay;
    }

    private void SetLosePlay()
    {
        DefeatPanel.SetActive(true);
        timePlay.IsPlayMode = false;
    }
    private void SetWinPlay()
    {
        if (needScore <= coinsBack.Coins)
        {
            WinPanel.SetActive(true);
            timePlay.IsPlayMode = false;
        }
    }
}
