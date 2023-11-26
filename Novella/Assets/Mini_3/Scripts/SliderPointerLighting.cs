using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderPointerLighting : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private ValuesController valuesController;
    private void Start()
    {
        valuesController = GetComponentInParent<ValuesController>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        valuesController.isChangeLighting = false;
        //valuesController.isChangeTemperature = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        valuesController.isChangeLighting = true;
        /*  if (valuesController.IsNeedLighting == valuesController.IsLighting && valuesController.IsLighting != 0)
          {
              valuesController.isChangeTemperature = true;
          }
          valuesController.isChangeTemperature = true;*/
    }
}
