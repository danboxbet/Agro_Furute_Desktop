using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderPointerTemperature : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private ValuesController valuesController;
    private void Start()
    {
        valuesController = GetComponentInParent<ValuesController>();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        valuesController.isChangeTemperature = true;
        /*  if (valuesController.IsNeedLighting == valuesController.IsLighting && valuesController.IsLighting != 0)
          {
              valuesController.isChangeTemperature = true;
          }
          valuesController.isChangeWet = true;*/

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        valuesController.isChangeTemperature = false;
    }
}
