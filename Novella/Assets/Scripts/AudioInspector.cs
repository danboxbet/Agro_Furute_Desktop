using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioInspector : MonoBehaviour
{

    public static event Action<int> ChangeVolume;
    public float VolumeOff;
    public float VolumeOn;
    private AudioSource audioSource;
    private int IsOn;
    
    void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
        IsOn = PlayerPrefs.GetInt("musicVolume");
        if (IsOn == 0) audioSource.volume = VolumeOff;
        if (IsOn == 1) audioSource.volume = VolumeOff;
        else if (IsOn == 2) audioSource.volume = VolumeOn;
        ChangeVolume.Invoke(IsOn);

    }
    public void ClickAudio()
    {
       

        if (IsOn==2)
        {
            IsOn = 1;
           
            audioSource.volume = VolumeOff;
            PlayerPrefs.SetInt("musicVolume", IsOn);
            ChangeVolume.Invoke(IsOn);
        }
        else if(IsOn==1 || IsOn == 0)
        {
            IsOn = 2;
           
            audioSource.volume=VolumeOn;
            PlayerPrefs.SetInt("musicVolume", IsOn);
            ChangeVolume.Invoke(IsOn);
        }
       
       
    }

}
