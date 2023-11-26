using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SettingsStorage : MonoBehaviour
{
    public static void SaveIntSetting(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    public static void SaveFloatSetting(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public static int LoadIntSetting(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    public static float LoadFloatSetting(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }

    public static void RemoveSetting(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    public static bool TryGetPrefs(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
}
