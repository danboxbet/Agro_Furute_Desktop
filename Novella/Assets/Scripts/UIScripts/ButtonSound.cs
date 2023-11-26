using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    private AudioSource audioSource;

    private Button button;

    private SettingAudioMixer settingAudio;

    private void Awake()
    {
        settingAudio = FindObjectOfType<SettingAudioMixer>();
    }
    private void Start()
    {
        SearchComponents();

        if (button != null)
            button.onClick.AddListener(PlaySound);

    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(PlaySound);
    }
    private void SearchComponents()
    {
        button = GetComponent<Button>();

        audioSource = settingAudio.GetComponent<AudioSource>();
    }

    private void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
