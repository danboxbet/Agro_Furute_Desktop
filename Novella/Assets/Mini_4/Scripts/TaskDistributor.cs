
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TaskDistributor : MonoBehaviour
{
    public enum Duty
    {
        Pour=0,
        Clean=1,
        Hilling=2
    }

    [SerializeField] private Sprite pourImage;
    [SerializeField] private Sprite cleanImage;
    [SerializeField] private Sprite hillingImage;

    [SerializeField] private float timeToChangeImage;

    [SerializeField] private Robot robot;

    private AreaApplicationSkill[] allAreas;

    private Image selectImage;

    private Duty duty;

    public UnityEvent OnCompleteDuty;

    private void Start()
    {
        allAreas = FindObjectsOfType<AreaApplicationSkill>();

        InputController.OnPourClick += PourClick;
        InputController.OnCleanClick += CleanClick;
        InputController.OnHillingClick += HillingClick;

        StartCoroutine(SetTast(timeToChangeImage));
    }

    private void OnDestroy()
    {
        InputController.OnPourClick -= PourClick;
        InputController.OnCleanClick -= CleanClick;
        InputController.OnHillingClick -= HillingClick;
    }

    IEnumerator SetTast(float time)
    {
        while (true)
        {
            duty = (Duty)Random.Range(0, 3);
           
            var index = Random.Range(0, allAreas.Length - 1);

            selectImage = allAreas[index].GetComponentInChildren<Image>(true);

            if (!allAreas[index].hasTast) SetSeceltImage();

            yield return new WaitForSeconds(time);
        }
    }

    private void PourClick()
    {
        ResetSelectImage(pourImage);
    }
    private void CleanClick()
    {
        ResetSelectImage(cleanImage);
    }
    private void HillingClick()
    {
        ResetSelectImage(hillingImage);
    }

    private void SetSeceltImage()
    {
        if (!selectImage.enabled)
        {
            if (duty == Duty.Clean) selectImage.sprite = cleanImage;
            if (duty == Duty.Hilling) selectImage.sprite = hillingImage;
            if (duty == Duty.Pour) selectImage.sprite = pourImage;
        }
        selectImage.enabled = true;
    }
    private void ResetSelectImage(Sprite sprite)
    {
        foreach(var area in allAreas)
        {
            if(Vector2.Distance(area.transform.position,robot.transform.position)<=area.Radius)
            {
                if (area.image.sprite == sprite && area.image.enabled)
                {
                    area.image.enabled = false;
                    OnCompleteDuty.Invoke();
                }
            }
        }
    }
}
