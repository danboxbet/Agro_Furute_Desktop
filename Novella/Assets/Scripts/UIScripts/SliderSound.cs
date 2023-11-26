using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSound : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;

    private Slider slider;

    private SettingAudioMixer settingAudio;

    private void Awake()
    {
        settingAudio = FindObjectOfType<SettingAudioMixer>();
    }
    private void Start()
    {
        SearchComponents();

        if (slider != null)
            slider.onValueChanged.AddListener(PlaySound);

    }

    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(PlaySound);
    }
    private void SearchComponents()
    {
        slider = GetComponent<Slider>();

        audioSource = settingAudio.GetComponent<AudioSource>();
    }

    private void PlaySound(float value)
    {
        StartCoroutine(CheckPosition(value));
    }
    IEnumerator CheckPosition(float value)
    {
        yield return new WaitForSeconds(0.3f);
        if(value==slider.value)
        {
            if (audioSource != null)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }
}
