using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualRobot : MonoBehaviour
{
    
    private Animator animator;
    private Transform robotView;

    private void Start()
    {
        
        animator = GetComponent<Animator>();
        robotView = GetComponent<Transform>();

        SubscribeOnEvents();

      //  animator.enabled = false;
    }
    private void OnDestroy()
    {
        InputController.OnChangeVisualModel -= UpdateVisualModel;
        InputController.OnResetSpeed -= ResetAnimation;
        InputController.OnChangePosition -= OnAnimation;
        Robot.OnChangeAnimationSpeed -= ChangeAnimationSpeed;
    }
    private void ChangeAnimationSpeed(float speed)
    {
        animator.speed = speed;
    }
    private void ResetAnimation()
    {
        //animator.enabled = false;
    }
    private void OnAnimation(Vector3 vector3)
    {
       // animator.enabled = true;
    }
    private void UpdateVisualModel(Vector3 direction)
    {
        robotView.transform.up = direction;
    }
    private void SubscribeOnEvents()
    {
        InputController.OnChangeVisualModel += UpdateVisualModel;
        InputController.OnResetSpeed += ResetAnimation;
        InputController.OnChangePosition += OnAnimation;
        Robot.OnChangeAnimationSpeed += ChangeAnimationSpeed;
    }
}
