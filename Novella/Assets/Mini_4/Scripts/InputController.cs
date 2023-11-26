using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InputController : MonoBehaviour
{
   
    [SerializeField] private Transform robot;

    [SerializeField] private ButtonsEvents buttonLeft;
    [SerializeField] private ButtonsEvents buttonRight;
    [SerializeField] private ButtonsEvents buttonUp;
    [SerializeField] private ButtonsEvents buttonDown;

    [SerializeField] private ButtonsEvents pourButton;
    [SerializeField] private ButtonsEvents cleanButton;
    [SerializeField] private ButtonsEvents hillingButton;
 
    public static event Action OnResetSpeed;
    public static event Action<Vector3> OnChangePosition;
    public static event Action<Vector3> OnChangeVisualModel;

    public static event Action OnPourClick;
    public static event Action OnCleanClick;
    public static event Action OnHillingClick;
    private void Start()
    {
        buttonLeft.OnClick += MoveLeft;
        buttonRight.OnClick += MoveRight;
        buttonDown.OnClick += MoveDown;
        buttonUp.OnClick += MoveUp;
        

        buttonLeft.OnExitClick += CancelMove;
        buttonRight.OnExitClick += CancelMove;
        buttonDown.OnExitClick += CancelMove;
        buttonUp.OnExitClick += CancelMove;

        pourButton.OnSingleCLick += PourGardenBed;
        cleanButton.OnSingleCLick += CleanGardenBed;
        hillingButton.OnSingleCLick += HillingGardenBed;
    }

    private void CancelMove()
    {
        OnResetSpeed?.Invoke();
    }
   
    private void PourGardenBed()
    {
        OnPourClick?.Invoke();
    }
    private void CleanGardenBed()
    {
        OnCleanClick?.Invoke();
    }
    private void HillingGardenBed()
    {
        OnHillingClick?.Invoke();
    }

    private void MoveLeft()
    {
        OnChangePosition?.Invoke(-robot.transform.right);
        OnChangeVisualModel?.Invoke(-robot.transform.right);
        
    }
    private void MoveRight()
    {
        OnChangePosition?.Invoke(robot.transform.right);
        OnChangeVisualModel?.Invoke(robot.transform.right);
       
    }
    private void MoveDown()
    {
        OnChangePosition?.Invoke(-robot.transform.up);
        OnChangeVisualModel?.Invoke(-robot.transform.up);
        
    }
    private void MoveUp()
    {
        OnChangePosition?.Invoke(robot.transform.up);
        OnChangeVisualModel?.Invoke(robot.transform.up);
       
    }
    private void OnDestroy()
    {
        buttonLeft.OnClick -= MoveLeft;
        buttonRight.OnClick -= MoveRight;
        buttonDown.OnClick -= MoveDown;
        buttonUp.OnClick -= MoveUp;

        buttonLeft.OnExitClick -= CancelMove;
        buttonRight.OnExitClick -= CancelMove;
        buttonDown.OnExitClick -= CancelMove;
        buttonUp.OnExitClick -= CancelMove;

        pourButton.OnSingleCLick -= PourGardenBed;
        cleanButton.OnSingleCLick -= CleanGardenBed;
        hillingButton.OnSingleCLick -= HillingGardenBed;
    }

}
