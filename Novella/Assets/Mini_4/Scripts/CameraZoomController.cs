using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraZoomController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachine;
    [SerializeField] private float zoomValue;
   
    private float startValue;
   

    private void Start()
    {
        
        startValue = cinemachine.m_Lens.OrthographicSize;
        Robot.OnReduceSpeed +=ChangePlusZoom;
        Robot.OnAddSpeed += ChangeMinusZoom;


    }
    private void OnDestroy()
    {
        Robot.OnReduceSpeed -= ChangePlusZoom;
        Robot.OnAddSpeed -= ChangeMinusZoom;
    }
    private void ChangeMinusZoom()
    {
        if(cinemachine.m_Lens.OrthographicSize<startValue+1)
        {
            cinemachine.m_Lens.OrthographicSize += Time.deltaTime * 0.5f;
        }


    }
    private void ChangePlusZoom()
    {
        if (cinemachine.m_Lens.OrthographicSize > startValue)
        {
            cinemachine.m_Lens.OrthographicSize -= Time.deltaTime * 0.5f;
        }
    }
   
   
}
