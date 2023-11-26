using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderPointerWet : MonoBehaviour, IPointerUpHandler,IPointerDownHandler
{
    private ValuesController valuesController;
    private void Start()
    {
        valuesController = GetComponentInParent<ValuesController>();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        valuesController.isChangeWet = true;
      /*  if(valuesController.IsNeedTemperature==valuesController.IsTemperature && valuesController.IsTemperature!=0)
        {
            valuesController.isChangeWet = true;
        }
        valuesController.isChangeSoilQuality = true;*/
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        valuesController.isChangeWet = false;
        /* valuesController.isChangeWet = false;
         valuesController.isChangeSoilQuality = false;*/
    }
}
