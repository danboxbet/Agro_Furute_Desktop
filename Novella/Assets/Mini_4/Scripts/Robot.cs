using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float maxSpeed;

    public static event Action<float> OnChangeAnimationSpeed;
    public static event Action OnReduceSpeed;
    public static event Action OnAddSpeed;

    private static float currentSpeed = 0;
    private Transform robot;
    private Vector3 directionMove;
    private float timer = 0;
    private bool IsStopReduce;

    private void Start()
    {
        robot = GetComponent<Transform>();
        InputController.OnResetSpeed += ResetSpeed;
        InputController.OnChangePosition += UpdatePosition;
    }
    private void OnDestroy()
    {
        InputController.OnResetSpeed -= ResetSpeed;
        InputController.OnChangePosition -= UpdatePosition;
    }
    private void ResetSpeed()
    {
        
        IsStopReduce = true;
        StartCoroutine(ReduceSpeed());
        
       

    }
    private void Update()
    {
        OnChangeAnimationSpeed.Invoke(currentSpeed);
       
    }
    
    IEnumerator ReduceSpeed()
    {
        float elapsedTime = 0;
        float startSpeed = currentSpeed;

        while (elapsedTime < 1f && IsStopReduce) 
        {
            OnReduceSpeed.Invoke();
            float t = elapsedTime / 1f; 
            currentSpeed = Mathf.Lerp(startSpeed, 0f, t);

            robot.transform.position += Time.deltaTime * currentSpeed * directionMove;

            
            elapsedTime += Time.deltaTime*0.5f;
           
            yield return null;
        }
        timer = 0;
        
      
    }
    private void UpdatePosition(Vector3 direction)
    {
        OnAddSpeed.Invoke();
        directionMove = direction;
        IsStopReduce = false;
        
       
        if (currentSpeed < maxSpeed)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, timer);
           
        }
      
        timer += Time.deltaTime *0.3f;

        robot.transform.position += Time.deltaTime *currentSpeed * direction;
       
       
    }


   

}
