using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSaver : MonoSingletone<AutoSaver>
{
    private string filename = "levelProgress";
    private void Start()
    {
       
        SceneManager.activeSceneChanged += SaveCurrentScene;
        DataSave save = new DataSave { levelProgress = SceneManager.GetActiveScene().buildIndex };
        Saver.Save(filename, save);
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= SaveCurrentScene;
    }

    private void SaveCurrentScene(Scene current, Scene next)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex!= SceneManager.sceneCountInBuildSettings-1)
        {
            
            DataSave save = new DataSave { levelProgress = SceneManager.GetActiveScene().buildIndex };
            Saver.Save(filename, save);
        }
    }
}
