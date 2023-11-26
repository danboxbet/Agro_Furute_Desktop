using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoinsBack : MonoBehaviour
{
    [SerializeField] private CoinsBack back;

    [SerializeField] private Text textCoins;

    private void Start()
    {
        textCoins.text = "0";
        back.OnAddCoin += UpdateCoinText;
    }
    private void OnDestroy()
    {
        back.OnAddCoin -= UpdateCoinText;
    }
    private void UpdateCoinText()
    {
        textCoins.text = back.Coins.ToString();
    }
}
