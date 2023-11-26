using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CrosswordWordSetup : MonoBehaviour
{
    public int indexWord;
    [SerializeField] private string rightWord;
    [SerializeField] private List<InputField> fieldsCharUI; 
    private char[] elementsRightWord;
    private int currentIndex;
    public static int currentWord;
    public static CrosswordWordSetup[] words;

    public event Action OnRightWord;

    void Start()
    {
        words= FindObjectsOfType<CrosswordWordSetup>();
        elementsRightWord = rightWord.ToCharArray();

        for(int i=0;i<fieldsCharUI.Count;i++)
        {
            int index = i;
            fieldsCharUI[i].onValueChanged.AddListener(value => OnValueChangedField(value, index,indexWord));
            
        }
      
    }
    private void Update()
    {
       
        int charCount = 0;
        foreach (var field in fieldsCharUI)
        {
            if (field.text.ToUpper() != "")
            {
              
                charCount++;
                if (charCount == fieldsCharUI.Count) CheckInputChar();
              
            }
        }
      
    }
   
    private void OnValueChangedField(string value, int index, int indexWord)
    {
        if(value=="")
        {
            return;
        }
        else
        {
            currentIndex = index;
            
            if (currentIndex < fieldsCharUI.Count-1)
            {
                ActivateNextField(index,indexWord);
              
            }
        }
       
    }
    private void ActivateNextField(int index, int indexWord)
    {
       
      //  CrosswordWordSetup[] words = FindObjectsOfType<CrosswordWordSetup>();
        foreach (var word in words)
        {
           
            if(word.indexWord==currentWord)
            {
                
              
                for (int i = index + 1; i < word.fieldsCharUI.Count; i++)
                {
                    if (word.fieldsCharUI[i].interactable && indexWord == currentWord)
                    {
                        
                       
                        word.fieldsCharUI[i].Select();
                        word.fieldsCharUI[i].ActivateInputField();
                        break;
                    }
                }
                break;
            }
        }
    }
    private void CheckInputChar()
    {

            if(rightWord.ToUpper()==ConvertInputFieldsToWord())
            {
            
             SetColorOutlines(Color.green);
             foreach(var field in fieldsCharUI)
             {
               
                field.interactable = false;
             }
             if(OnRightWord!=null) OnRightWord.Invoke();
            }
            else
            {
                SetColorOutlines(Color.red);
               
            }
       
    }
    private void EnabledOutlines(bool enableStatus)
    {
        foreach (var field in fieldsCharUI)
        {
            var fieldOutline = field.GetComponent<Outline>();
            fieldOutline.enabled = enableStatus;
            
        }
    }
    private void SetColorOutlines(Color color)
    {
        foreach (var field in fieldsCharUI)
        {
           
            var fieldOutline = field.GetComponent<Outline>();
           
            fieldOutline.enabled = true;
            
            fieldOutline.effectColor = color;
        }
    }
    private string ConvertInputFieldsToWord()
    {
        string word = string.Join("", fieldsCharUI.Select(field => field.text));
        return word.ToUpper();
    }
    private void OnDestroy()
    {
        for (int i = 0; i < fieldsCharUI.Count; i++)
        {
            int index = i;
            fieldsCharUI[i].onValueChanged.RemoveListener(value => OnValueChangedField(value, index,i));

        }
    }

   
}
