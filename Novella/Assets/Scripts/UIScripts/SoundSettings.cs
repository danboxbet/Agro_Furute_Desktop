using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    private const float minValue = -80;

    [SerializeField] private string branchAudioMixers;

    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider slider;

    [SerializeField] private Text text;

    private float reduceValue = 20;

    public void SettingAudioMixer() => SetStartSetting();
    void Start()
    {
        slider.onValueChanged.AddListener(UpdateText);
       
        SetStartSetting();
    }
    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(UpdateText);
    }

    private void SetStartSetting()
    {
        if (SettingsStorage.TryGetPrefs(branchAudioMixers + " branch"))
        reduceValue = SettingsStorage.LoadFloatSetting(branchAudioMixers + " branch");

        slider.value = (reduceValue - minValue) / 100;


        text.text = (Mathf.Round(slider.value * 100)).ToString();

        audioMixer.SetFloat(branchAudioMixers, reduceValue);
    }
    private void UpdateText(float value)
    {
        text.text = (Mathf.Round(value * 100)).ToString();
        UpdateMixerSetting(value);
    }
    private void UpdateMixerSetting(float value)
    {
        SetReduceValue(value);
        audioMixer.SetFloat(branchAudioMixers, reduceValue);
    }

    private void SetReduceValue(float value)
    {
        reduceValue = minValue + (value * 100);
        SettingsStorage.SaveFloatSetting(branchAudioMixers+" branch", reduceValue);
    }
}
