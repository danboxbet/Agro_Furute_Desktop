using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class WordClicker : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private int currentWordIndex;
    private CrosswordWordSetup crosswordWordSetup;

    private void Start()
    {
        crosswordWordSetup = GetComponentInParent<CrosswordWordSetup>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        CrosswordWordSetup.currentWord = currentWordIndex;
       
    }
}
