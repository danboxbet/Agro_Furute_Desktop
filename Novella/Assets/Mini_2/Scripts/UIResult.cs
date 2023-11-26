using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResult : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Text increase;
    [SerializeField] private Text stamine;
    [SerializeField] private Text diversity;
    [SerializeField] private Text sintez;
    [SerializeField] private Text stressResistance;
    private void Start()
    {
        ResultCreator.OnResult += ChangeTextResult;
    }
    private void OnDestroy()
    {
        ResultCreator.OnResult -= ChangeTextResult;
    }
    public void ChangeTextResult(Results results)
    {
        increase.text = results.Increase.ToString();
        stamine.text = results.Stamine.ToString();
        diversity.text = results.Diversity.ToString();
        sintez.text = results.Sintez.ToString();
        stressResistance.text = results.StressResistance.ToString();
        DefineVictory(results);
    }
    private void DefineVictory(Results results)
    {
      if(results.Increase>=35 && results.Stamine>=63 && results.Diversity>=15 && results.Sintez>=27 && results.StressResistance>=19)
        {
            StartCoroutine(Finish());
        }
    }
    IEnumerator Finish()
    {
        yield return new WaitForSeconds(2);
        winPanel.SetActive(true);
    }
}
