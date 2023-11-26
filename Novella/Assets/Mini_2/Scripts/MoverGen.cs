using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public enum TypeGen
{
    Type1,
    Type2,
    Type3,
    Type4,
    Type5,
}
public class MoverGen : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public int addScore;
    public static event Action<RectTransform> OnNeedTarget;
    public static RectTransform usedGen;

    public TypeGen typeGen;
    public bool IsFirstClick;
    public PointerEventData eventData;
   
    
    private SpawnerGen spawnerCreator;
    public RectTransform currentGenRectTransform { get; private set; }
    private Vector2 offset;
    private LocaterTarget locaterTarget;

    public void Initialized(SpawnerGen spawnerGen)
    {
        spawnerCreator = spawnerGen;

    }
    private void Awake()
    {
        currentGenRectTransform = GetComponent<RectTransform>();
        locaterTarget = FindObjectOfType<LocaterTarget>();
        
       

    }
    private void Update()
    {
       // locaterTarget.InformateAboutNewGen(usedGen);
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        locaterTarget.InformateAboutNewGen(usedGen);
        MoveCurrentGen(eventData);
       
    }
   
    public void OnPointerDown(PointerEventData eventData)
    {
        CalculateOffset(eventData);
        usedGen = currentGenRectTransform;
        GenImages.CheckGen(usedGen);

    }
    public void OnPointerUp(PointerEventData eventData)
    {
     
        OnNeedTarget.Invoke(usedGen);
    }
    public void FirstStartClick()
    {
        OnPointerDown(eventData);
        CalculateOffset(eventData);
    }
    private void CalculateOffset(PointerEventData eventData)
    {
        offset.x = eventData.position.x - currentGenRectTransform.position.x;
        offset.y = eventData.position.y - currentGenRectTransform.position.y;
    }
    private void MoveCurrentGen(PointerEventData eventData)
    {
        Vector2 newPostionGen;
        newPostionGen.x = eventData.position.x - offset.x;
        newPostionGen.y = eventData.position.y - offset.y;
        currentGenRectTransform.position = newPostionGen;
    }
    
   

   
}