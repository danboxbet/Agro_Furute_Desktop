using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMiniPlay : MonoBehaviour
{
    [SerializeField] private Sprite OnVolume;
    [SerializeField] private Sprite OffVolume;
    [SerializeField] private Image Sound;
    [SerializeField] private AudioInspector audioInspector;
    private void Awake()
    {

        AudioInspector.ChangeVolume += ChangeImageSound;
        
    }
    private void OnDestroy()
    {
        AudioInspector.ChangeVolume -= ChangeImageSound;
    }
    private void ChangeImageSound(int IsOn)
    {
       
        if (IsOn == 1 || IsOn==0) Sound.sprite = OffVolume;
        else Sound.sprite = OnVolume;
    }
}
