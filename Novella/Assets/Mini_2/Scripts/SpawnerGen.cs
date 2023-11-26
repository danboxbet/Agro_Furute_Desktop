using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnerGen : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IDragHandler
{
    [SerializeField] private GameObject prefabGen;
    [SerializeField] private RectTransform rectTransformGensConteiner;
    

    public event Action OnStartFirstMovingGen;
    

    private GensConteiner gensConteiner;
    private RectTransform currentGenRectTransform;
    private GameObject newGen;
    private PointerEventData eventData;
    private MoverGen newGenMover;
    private LocaterTarget locaterTarget;
  
   
    private void Start()
    {
        currentGenRectTransform = GetComponent<RectTransform>();
        
       
    }
  
    public void OnPointerDown(PointerEventData eventData)
    {
        this.eventData = eventData;
        CreateNewGen();
       
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        newGenMover.OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        newGenMover.OnPointerUp(eventData);
       
    }
    private void CreateNewGen()
    {
        newGen = Instantiate(prefabGen, currentGenRectTransform.position, Quaternion.identity);
        SettingRectTransformNewGen(newGen);
        SettingMoverNewGen();
        SendInfoAboutCreator();
        newGenMover.OnPointerDown(eventData);
        
        OnStartFirstMovingGen.Invoke();
    }
    private void SettingRectTransformNewGen(GameObject newGen)
    {
        var newGenRectTransform = newGen.GetComponent<RectTransform>();
        newGenRectTransform.SetParent(rectTransformGensConteiner);
        newGenRectTransform.SetAsLastSibling();
        newGenRectTransform.localScale = new Vector3(1, 1, 1);
    }
    private void SettingMoverNewGen()
    {
        newGenMover = newGen.GetComponent<MoverGen>();
        newGenMover.eventData = eventData;
        newGenMover.FirstStartClick();
    }
    private void SendInfoAboutCreator()
    {
        newGenMover.Initialized(this);
        
    }

   
}
