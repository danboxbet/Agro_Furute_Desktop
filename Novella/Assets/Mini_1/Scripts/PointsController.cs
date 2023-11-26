using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField] private GameObject PanelWin;
    public List<RectTransform> points;
    [SerializeField] private LockerPoints lockerPoints;
    public List<ElementPointer> Elements;
    public static RectTransform element;
    public static RectTransform target;
    private float dist;
    private bool RotateIsNull;
    private bool NeedPlace;
    public float IsDist => dist;

    private void Start()
    {
        
        Elements = new List<ElementPointer>(FindObjectsOfType<ElementPointer>());
        lockerPoints.OnWin += CheckVictory;
    }

    private void Update()
    {
        SetTarget();
        
    }
    public void CheckVictory()
    {
        RotateIsNull = true;
        NeedPlace = true;
        foreach (var element in Elements)
        {
            float rotationTolerance = 1f;
            if (element.IsRectTransform.rotation.w ==1.0f || element.IsRectTransform.rotation.w == -1.0f) element.IsRideRotation = true;
            else
            {
                element.IsRideRotation = false;
                RotateIsNull = false;
            }
            float positionTolerance = 1f;
            if (Vector2.Distance(element.IsRectTransform.position, element.IsTargetTransform.position) <= positionTolerance) element.IsRidePosition = true;
            else
            {

                element.IsRidePosition = false;
                NeedPlace = false;
            }

        }
       
       
        Debug.Log(NeedPlace);
        Debug.Log(RotateIsNull);
        if (NeedPlace==true && RotateIsNull==true) VieWinPanel();
       

    }
    private void VieWinPanel()
    {
        var elements = FindObjectsOfType<ElementPointer>();
        foreach(var element in elements)
        {
            element.enabled = false;
        }
        PanelWin.SetActive(true);
    }
    private void SetTarget()
    {
        foreach (var point in points)
        {
            if (element != null)
            {
                Vector2 elementVector = new Vector2(element.position.x, element.position.y);
                Vector2 pointVector = new Vector2(point.position.x, point.position.y);
                float dist = Vector2.Distance(elementVector, pointVector);
                if (point == points[0])
                {
                    this.dist = dist;

                    target = point;
                }
                else if (dist < this.dist)
                {

                    this.dist = dist;

                    target = point;

                }
            }
        }
    }
    private void OnDestroy()
    {
        lockerPoints.OnWin -= CheckVictory;   
    }
}
