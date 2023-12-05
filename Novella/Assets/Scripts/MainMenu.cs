using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button buttonContinue;
    
    private string filename = "levelProgress";
    private int levelIndex;
    private void Awake()
    {
        buttonContinue.interactable = false;
        DataSave save = Saver.TryLoad(filename);
        levelIndex = save.levelProgress;
       
        if(save.levelProgress>0)
        {
            buttonContinue.interactable = true;
        }
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DataSave newData = new DataSave { levelProgress = SceneManager.GetActiveScene().buildIndex + 1 };
        Saver.Save(filename,newData);
    }
    public void Continue()
    {
        SceneManager.LoadScene((int)levelIndex);
    }
   public void ExitAtWindows()
    {
        Application.Quit();
    }
}
