using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class RobotImpuls : MonoBehaviour
{
    [SerializeField] private CinemachineCollisionImpulseSource impulsSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        impulsSource.GenerateImpulse();
    }
  
}
