using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenImages : MonoBehaviour
{
   public static event Action<RectTransform> OnRemove;
   
   public static List<RectTransform> TargetsRect=new List<RectTransform>();
   private static bool IsRightTarget;

   public static void ResetTargetList()
    {
        TargetsRect = new List<RectTransform>();
    }
    public static void CheckGen(RectTransform usedGen)
    {
        if (TargetsRect.Count != 0)
        {
            foreach (var gen in TargetsRect)
            {
                if (Vector3.Distance(usedGen.position,gen.position)<=0.5f)
                {
                    TargetsRect.Remove(gen);
                    OnRemove.Invoke(usedGen);

                    break;
                }
            }

        }

    }
    public static bool CheckTarget(RectTransform currentTarget)
    {
        IsRightTarget = true;
        foreach(var image in TargetsRect)
        {
            if (currentTarget == image)
            {
                IsRightTarget = false;
                
            }

        }
       
        return IsRightTarget;
    }
   
}
