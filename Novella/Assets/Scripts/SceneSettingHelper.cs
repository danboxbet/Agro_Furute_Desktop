using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSettingHelper : MonoBehaviour
{
    [ContextMenu("DeleteAllPrefs")]
    public void DeleteAllPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
