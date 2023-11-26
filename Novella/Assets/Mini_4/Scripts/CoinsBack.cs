using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsBack : MonoBehaviour
{
    [SerializeField] private TaskDistributor taskDistributor;

    public event Action OnAddCoin;

    private int coins=0;
    public int Coins => coins;
    
    private void Start()
    {
        taskDistributor.OnCompleteDuty.AddListener(AddCoin);
    }
    private void OnDestroy()
    {
        taskDistributor.OnCompleteDuty.RemoveListener(AddCoin);
    }
    private void AddCoin()
    {
        coins++;
        OnAddCoin.Invoke();
    }
}
