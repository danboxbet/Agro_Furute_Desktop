using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СrosswordController : MonoBehaviour
{
    [SerializeField] private List<CrosswordWordSetup> words;
    [SerializeField] private GameObject WinPanel;
    private int rightWord=0;
    private void Start()
    {
        for(int i=0;i<words.Count;i++)
        {
            int index = i;
            Action rigthWordAction = null;
            rigthWordAction = () =>
              {
                  AddRightWord();
                  words[index].OnRightWord -= rigthWordAction;
              };
            if (rigthWordAction != null)
            words[i].OnRightWord += rigthWordAction;
           
        }
    }
    private void AddRightWord()
    {
        rightWord++;
        CheckWordsInCrossword();
       
      

        
    }
  
    private void CheckWordsInCrossword()
    {
       
        if (rightWord != words.Count) return;
        WinPanel.SetActive(true);
       // Debug.Log("Win");
    }
}
