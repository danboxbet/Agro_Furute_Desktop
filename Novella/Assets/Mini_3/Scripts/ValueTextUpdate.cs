using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueTextUpdate : MonoBehaviour
{
    [SerializeField] private Text textCurrentTemperature;
    [SerializeField] private Text textCurrentWet;
    [SerializeField] private Text textCurrentLighting;
    [SerializeField] private Text textCurrentSoilQuality;
   
    // Start is called before the first frame update
    private void Start()
    {
        ValuesController.ChangeValue += ChangeViewValues;
    }

    private void ChangeViewValues(float temperature, float wet, float lighting, float soilQuality)
    {
        textCurrentTemperature.text = Mathf.Round(temperature).ToString();
        textCurrentWet.text = Mathf.Round(wet).ToString();
        textCurrentLighting.text = Mathf.Round(lighting).ToString();
        textCurrentSoilQuality.text = Mathf.Round(soilQuality).ToString();
    }
    private void OnDestroy()
    {
        ValuesController.ChangeValue -= ChangeViewValues;
    }
}
