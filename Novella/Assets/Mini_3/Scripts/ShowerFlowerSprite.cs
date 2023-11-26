using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowerFlowerSprite : MonoBehaviour
{
    [SerializeField] private Image[] imagesFlowers;
    [SerializeField] private Sprite[] targetSprites;
    private float currentTime;
    private float allTime;
    private int iteration=1;
    private int i;
    private void Start()
    {
        allTime = TimerControllerUI.Instance.IsWinTime;
        iteration = 0;
        i = 1;
    }
    private void Update()
    {
       
        currentTime = TimerControllerUI.Instance.currentWinTime;
        var part = allTime / targetSprites.Length;
        
       
            if(currentTime<=allTime-part*i  && currentTime != 0) 
            {
                iteration++;
                 UpdatesImage();
                 i++;
            }
        
    }
    private void UpdatesImage()
    {
        foreach (var image in imagesFlowers)
        {
            
            image.sprite = targetSprites[iteration];
        }
       
    }
}
