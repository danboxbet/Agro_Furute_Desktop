using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ElementPointer : MonoBehaviour, IDragHandler, IPointerDownHandler,IPointerUpHandler
{
    
    [SerializeField] private RectTransform targetTransform;
    [SerializeField] private LockerPoints lockerPoints;
    [SerializeField] private PointsController pointsController;
    private Image image;
    private RectTransform rectTransform;
    private static Image oldView;
    public bool IsRidePosition;
    public bool IsRideRotation;
    private UpdateRectTransform updateRectTransform;
    public RectTransform IsRectTransform => rectTransform;
    public RectTransform IsTargetTransform => targetTransform;
    
    private Vector2 offset;

    private void Awake()
    {
        IsRidePosition = false;
        IsRideRotation = false;
        updateRectTransform = FindObjectOfType<UpdateRectTransform>();
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
     
    }

    public void OnDrag(PointerEventData eventData)
    {
       
       
        Vector2 newPosition = eventData.position - offset;
        rectTransform.position = newPosition;
        rectTransform.SetAsLastSibling();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        
        foreach (var element in lockerPoints.rectTransforms)
        {
            if (rectTransform.position == element.position)
            {
                lockerPoints.rectTransforms.Remove(element);
                pointsController.points.Add(element);
                
                break;
            }
        }
        PointsController.element = rectTransform;
        Vector2 newPosition = eventData.position - offset;
        rectTransform.position = newPosition;
        rectTransform.SetAsLastSibling();

        rectTransform.SetAsLastSibling();
        updateRectTransform.UpdateRect(rectTransform);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        oldView = image;
       
        if (pointsController.IsDist <= rectTransform.sizeDelta.x && pointsController.IsDist <= rectTransform.sizeDelta.y)
        {
            rectTransform.position = PointsController.target.position;
            lockerPoints.rectTransforms.Add(PointsController.target);
            pointsController.points.Remove(PointsController.target);
        }
       
       
    }
    
}
