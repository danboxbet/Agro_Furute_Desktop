using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocaterTarget : MonoBehaviour
{
    [SerializeField] private CoupleGens coupleGens;
    [SerializeField] private List<RectTransform> targets;
    private MoverGen currentGen;
    private RectTransform currentGenRectTransform;
    private RectTransform currentTarget;
    private float distance;
    private void Awake()
    {
        GenImages.ResetTargetList();
    }
    private void Start()
    {
        MoverGen.OnNeedTarget += SetTarget;
        GenImages.OnRemove += RemoveElementInCouple;
    }
    private void OnDestroy()
    {
        MoverGen.OnNeedTarget -= SetTarget;
        GenImages.OnRemove -= RemoveElementInCouple;
    }
    private void Update()
    {
       
        if (currentGenRectTransform != null)
        {
            
            for (int i = 0; i < targets.Count; i++)
            {
                var Distance = Vector2.Distance(currentGenRectTransform.position, targets[i].position);
                if (i==0)
                {
                    distance = Distance;
                    currentTarget = targets[i];
                }
                else if(Distance<distance)
                {
                    distance = Distance;
                    currentTarget = targets[i];
                }
            }
           
        }
       
    }
    public void InformateAboutNewGen(RectTransform usedGen)
    {
        
        currentGenRectTransform = usedGen;
    }
    public void AddElementInCouple(RectTransform usedGen)
    {
       
        for (int i = 0; i < coupleGens.IsCouple.Length; i++)
        {
            for (int j = 0; j < coupleGens.IsCouple[i].GroupGen.Length; j++)
            {
                
                if (Vector3.Distance(coupleGens.IsCouple[i].GroupGen[j].position, usedGen.position)<=0.5f )//coupleGens.IsCouple[i].GroupGen[j].position == usedGen.position )
                {
                    
                    coupleGens.AddElementInGroup(i, usedGen);
                }
            }
        }
    }
    public void RemoveElementInCouple(RectTransform usedGen)
    {
       
        for (int i = 0; i < coupleGens.IsCouple.Length; i++)
        {
            for (int j = 0; j < coupleGens.IsCouple[i].GroupGen.Length; j++)
            {
                if (Vector3.Distance(coupleGens.IsCouple[i].GroupGen[j].position, usedGen.position) <= 0.5f)
                {
                    coupleGens.RemoveElementInGroup(i, usedGen);
                }
            }
        }
    }
    private void SetTarget(RectTransform usedGenRectTransform)
    {
       
        if ((usedGenRectTransform.sizeDelta.x > Vector3.Distance(usedGenRectTransform.position, currentTarget.position) || usedGenRectTransform.sizeDelta.y > Vector3.Distance(usedGenRectTransform.position, currentTarget.position))
            && GenImages.CheckTarget(currentTarget))
        {
            usedGenRectTransform.position = currentTarget.position;
            GenImages.TargetsRect.Add(currentTarget);
            AddElementInCouple(usedGenRectTransform);
           
           
        }
    }
}
