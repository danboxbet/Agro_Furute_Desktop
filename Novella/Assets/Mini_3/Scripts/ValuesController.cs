using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValuesController : MonoBehaviour
{
    public static event Action<float,float,float,float> ChangeValue;

    public float speedChange;
    public float changeWet;
    public bool isChangeWet;
    public bool isChangeTemperature;
    public bool isChangeSoilQuality;
    public bool isChangeLighting;


    [SerializeField] private Slider sliderTemperature;
    [SerializeField] private Slider sliderWet;
    [SerializeField] private Slider sliderLighting;
    [SerializeField] private Slider sliderSoilQuality;
    private float temperature;
    public float IsTemperature => temperature;
    private float wet;
    public float IsWet => wet;
    private float lighting;
    public float IsLighting => lighting;
    private float soilQuality;

    private float needTemperature;
    public float IsNeedTemperature => needTemperature;

    private float needLighting;
    public float IsNeedLighting => needLighting;
    private float needWet;
    public float IsNeedWet => needWet;

    public float newWet = 50;
    public float newTemperature = 60;
    public float newSoilQuality=40;
    


    private void Start()
    {
        sliderTemperature.onValueChanged.AddListener(ChangeTemperature);
        sliderWet.onValueChanged.AddListener(ChangeWet);
        sliderLighting.onValueChanged.AddListener(ChangeLighting);
        sliderSoilQuality.onValueChanged.AddListener(ChangeSoilQuality);
        sliderTemperature.value = 0.5f;
        sliderWet.value = 0.5f;
        sliderLighting.value = 0.5f;
        sliderSoilQuality.value = 0.5f;
        temperature = 50f;
        wet = 50f;
        lighting = 50f;
        soilQuality = 50f;
        TimerControllerUI.Instance.InitialTimer();
        isChangeWet = true;
        isChangeTemperature = true;
        isChangeSoilQuality = true;
        isChangeLighting = true;
}

    private void Update()
    {
        /*ForcedChangeWet();
        ForcedChangeTemperature();
        ForcedChangeSoilQuality();*/
        ChangeValues();
        CompleteWin();
       
    }
    private void CompleteWin()
    {

       
        if ((temperature >= 20 && temperature <= 35) && (wet <= 80 && wet >= 70) && (soilQuality <= 100 && soilQuality >= 80) && (lighting <= 70 && lighting >= 60))
        {

            TimerControllerUI.Instance.ContinueTimer();
            TimerControllerUI.Instance.UpdateWinTimer();
        }
        else
        {
           
            TimerControllerUI.Instance.StopTimer();
        }
    }
    private void ChangeValues()
    {
        if(isChangeWet==true)
        {
            wet = Mathf.Lerp(wet, 0, speedChange * Time.deltaTime);
            sliderWet.value = wet / 100;
        }
        if(isChangeSoilQuality==true)
        {
            soilQuality = Mathf.Lerp(soilQuality, 0, speedChange * Time.deltaTime);
            sliderSoilQuality.value = soilQuality / 100;
        }
        if(isChangeTemperature==true)
        {
            temperature = Mathf.Lerp(temperature, 0, speedChange * Time.deltaTime);
            sliderTemperature.value = temperature / 100;
        }
        if(isChangeLighting==true)
        {
            lighting = Mathf.Lerp(lighting, 0, speedChange * Time.deltaTime);
            sliderLighting.value = lighting / 100;
        }
    }
    private void ForcedChangeWet()
    {
        if (isChangeWet == true)
        {
            wet = Mathf.Lerp(wet, 0, speedChange * Time.deltaTime);
            sliderWet.value = wet / 100;
            /*
            if (temperature == needTemperature && temperature != 0)
            {
                var newValue = newWet;
                wet = Mathf.Lerp(wet, newValue, speedChange * Time.deltaTime);
                sliderWet.value = wet / 100;
                if (Mathf.Round(wet) == newValue) isChangeWet = false;
            }
            else isChangeWet = false;*/
        }
    }
    private void ForcedChangeTemperature()
    {
        if (isChangeTemperature == true)
        {
            temperature = Mathf.Lerp(temperature, 0, speedChange * Time.deltaTime);
            sliderTemperature.value = temperature / 100;
            /*
            if (lighting == needLighting && lighting != 0)
            {

                var newValue = newTemperature;
                temperature = Mathf.Lerp(temperature, newValue, speedChange * Time.deltaTime);
                sliderTemperature.value = temperature / 100;
                if (Mathf.Round(temperature) == newValue) isChangeTemperature = false;
            }
            else isChangeTemperature = false;*/
        }
    }
    private void ForcedChangeSoilQuality()
    {
        if (isChangeSoilQuality == true)
        {
            soilQuality = Mathf.Lerp(soilQuality, 0, speedChange * Time.deltaTime);
            sliderSoilQuality.value = soilQuality / 100;
            /* if (wet == needWet && wet != 0)
             {
                 var newWalue = newSoilQuality;
                 soilQuality = Mathf.Lerp(soilQuality, newWalue, speedChange * Time.deltaTime);
                 sliderSoilQuality.value = soilQuality / 100;
                 if (Mathf.Round(soilQuality) == newWalue) isChangeSoilQuality = false;
             }
             else isChangeSoilQuality = false;*/
        }
    }
    private void ChangeTemperature(float value)
    {
        
        temperature = value * 100;
        needTemperature = Mathf.Clamp(temperature, 30, 100);
        ChangeValue.Invoke(temperature,wet,lighting,soilQuality);
      
    }
    private void ChangeWet(float value)
    {
        wet = value * 100;
        needWet= Mathf.Clamp(wet, 73, 100);
        ChangeValue.Invoke(temperature, wet, lighting, soilQuality);
    }
    private void ChangeLighting(float value)
    {
        lighting = value * 100;
        needLighting = Mathf.Clamp(lighting, 65, 70);
        ChangeValue.Invoke(temperature, wet, lighting, soilQuality);
    }
    private void ChangeSoilQuality(float value)
    {
        soilQuality = value * 100;
        ChangeValue.Invoke(temperature, wet, lighting, soilQuality);
    }

    private void OnDestroy()
    {
        sliderTemperature.onValueChanged.RemoveListener(ChangeTemperature);
        sliderWet.onValueChanged.RemoveListener(ChangeWet);
        sliderLighting.onValueChanged.RemoveListener(ChangeLighting);
        sliderSoilQuality.onValueChanged.RemoveListener(ChangeSoilQuality);
    }

}
