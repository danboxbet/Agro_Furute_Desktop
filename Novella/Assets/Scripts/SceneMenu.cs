using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour
{
    [SerializeField] private VisualSettings settings;
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadLastReplic()
    {
        if (!settings.IsLastPerson)
        {

            settings.StopCoroutine(settings.IsTypingCoroutine);
            var dialogCount = settings.IsSceneScriptableObject.IsDialog.Count;
            var personCount = settings.IsSceneScriptableObject.IsDialog[dialogCount - 1].person.Count;
            settings.SetDialogNum(dialogCount - 1, personCount - 1);
        }
    }
}
