using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Pers
{
    Алиса,
    Денис,
    Макс,
    Марина,
    Элина,
    Артём
}
[CreateAssetMenu]
public class Params : ScriptableObject
{ 
    [SerializeField] private List<Dialogs> dialogs;
    public List<Dialogs> IsDialog => dialogs;

    [Serializable]
    public class Dialogs
    {
       
        public Sprite background;
        public List<Personaj> person;
        
    }
    [Serializable]
    public class Personaj
    {
        public Pers pers;
        public Sprite persImage;
        public string[] Replic;
    }
   
}
