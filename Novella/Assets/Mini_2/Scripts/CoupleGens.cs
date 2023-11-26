using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleGens : MonoBehaviour
{
    [SerializeField] private Couple[] couple;
    public Couple[] IsCouple=> couple; 

    [Serializable]
    public class Couple
    {
        public RectTransform[] GroupGen;
        public List<RectTransform> BusyGens= new List<RectTransform>();


    }

    public void AddElementInGroup(int indexGroup,RectTransform usedGen)
    {
        
        couple[indexGroup].BusyGens.Add(usedGen);
    }
    public void RemoveElementInGroup(int indexGroup, RectTransform usedGen)
    {
        foreach(var rect in couple[indexGroup].BusyGens)
        {
            if(rect==usedGen)
            {
                couple[indexGroup].BusyGens.Remove(rect);
                break;
            }
        }
        List<RectTransform> rectTransform = new List<RectTransform>();

        foreach(var rect in couple[indexGroup].BusyGens)
        {
            if(rect!=null)
            {
                rectTransform.Add(rect);
            }
        }

        couple[indexGroup].BusyGens.Clear();
        couple[indexGroup].BusyGens= rectTransform;



       // couple[indexGroup].BusyGens.Remove(usedGen);
    }
}
