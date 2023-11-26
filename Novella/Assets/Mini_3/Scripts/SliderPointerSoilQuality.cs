using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderPointerSoilQuality : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private ValuesController valuesController;
    private void Start()
    {
        valuesController = GetComponentInParent<ValuesController>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        valuesController.isChangeSoilQuality = false;
        // valuesController.isChangeSoilQuality = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        valuesController.isChangeSoilQuality = true;
        // valuesController.isChangeSoilQuality = true;
    }
}
