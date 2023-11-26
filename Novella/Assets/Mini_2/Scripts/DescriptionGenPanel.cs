using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DescriptionGenPanel : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject panelGen;

   

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetActivePanel(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetActivePanel(false);
    }

    private void SetActivePanel(bool isActivePanel)
    {
        panelGen.SetActive(isActivePanel);
    }
  
}
