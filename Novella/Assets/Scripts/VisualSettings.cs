using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VisualSettings : MonoBehaviour
{
    [SerializeField] private Params SceneScriptableObject;
    [SerializeField] private Image Background;
    [SerializeField] private Image personImage;
    [SerializeField] private Text Replic;
    [SerializeField] private Text Name;
    [SerializeField] private Sprite OnVolume;
    [SerializeField] private Sprite OffVolume;
    [SerializeField] private Image Sound;
    [SerializeField] private AudioInspector audioInspector;
    private Coroutine typingCoroutine;
    public Coroutine IsTypingCoroutine => typingCoroutine;
    [SerializeField] private float typingSpeed = 0.05f;
    private string currentReplic;

    public Params IsSceneScriptableObject { get { return SceneScriptableObject; } }
    int dialog = 0;
    int person = 0;
    int replic = 0;

    private void Awake()
    {
        AudioInspector.ChangeVolume += ChangeImageSound;
    }
    private void Start()
    {
        
       
        Background.sprite = SceneScriptableObject.IsDialog[0].background;
        Name.text = SceneScriptableObject.IsDialog[0].person[0].pers.ToString()+":";
        // Replic.text= SceneScriptableObject.IsDialog[0].person[0].Replic[0];
   
        StartReplic(SceneScriptableObject.IsDialog[dialog].person[person].Replic[replic]);
      

    }

    private void Update()
    {
        
        Background.sprite = SceneScriptableObject.IsDialog[dialog].background;

        if(SceneScriptableObject.IsDialog[dialog].person[person].persImage!=null)
        personImage.sprite = SceneScriptableObject.IsDialog[dialog].person[person].persImage;

        Name.text = SceneScriptableObject.IsDialog[dialog].person[person].pers.ToString() + ":";
        // Replic.text = SceneScriptableObject.IsDialog[dialog].person[person].Replic[replic];
        
    }
    public void Next()
    {
        
        replic++;

        if(replic==SceneScriptableObject.IsDialog[dialog].person[person].Replic.Length)
        {
            person++;
            if(person==SceneScriptableObject.IsDialog[dialog].person.Count)
            {
                replic = 0;
                person = 0;
                dialog++;

                if(dialog==SceneScriptableObject.IsDialog.Count)
                {
                    dialog = 0;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else if(dialog<SceneScriptableObject.IsDialog.Count)
                {
                    EndReplic();
                    StartReplic(SceneScriptableObject.IsDialog[dialog].person[person].Replic[replic]);
                }
            }
            else if(person< SceneScriptableObject.IsDialog[dialog].person.Count)
            {
                replic = 0;
                EndReplic();
                StartReplic(SceneScriptableObject.IsDialog[dialog].person[person].Replic[replic]);
            }
        }
        else if(replic<SceneScriptableObject.IsDialog[dialog].person[person].Replic.Length)
        {
            EndReplic();
            StartReplic(SceneScriptableObject.IsDialog[dialog].person[person].Replic[replic]);
        }
       
    }
   
    public void SetDialogNum(int dialog, int person, int replic=0)
    {
        this.dialog = dialog;
        this.person = person;
        this.replic = replic;
        StartReplic(SceneScriptableObject.IsDialog[dialog].person[person].Replic[replic]);
    }
    private void ChangeImageSound(int IsOn)
    {
      
        if (IsOn == 1 || IsOn==0) Sound.sprite = OffVolume;
        else  Sound.sprite = OnVolume;
    }
    private void OnDestroy()
    {
        dialog = 0;
        replic = 0;
        person = 0;
        
        AudioInspector.ChangeVolume -= ChangeImageSound;
    }
    public void StartReplic(string replic)
    {
        typingCoroutine= StartCoroutine(TypeReplic(replic));
    }

    IEnumerator TypeReplic(string replic)
    {
        currentReplic = replic;
         Replic.text = "";

       foreach (char letter in currentReplic)
        {

          Replic.text += letter;
          yield return new WaitForSeconds(typingSpeed);
        }

        //yield return null;
    }
    public void EndReplic()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        Replic.text = "";
       // Replic.text = currentReplic;
    }
}
