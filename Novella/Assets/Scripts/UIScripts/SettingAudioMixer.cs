using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingAudioMixer : MonoSingletone<SettingAudioMixer>
{
    [SerializeField] private SoundSettings[] soundSettings;

    private void Start()
    {
        if (soundSettings != null)
        {
            foreach (var sound in soundSettings)
                sound.SettingAudioMixer();
        }
    }
}
