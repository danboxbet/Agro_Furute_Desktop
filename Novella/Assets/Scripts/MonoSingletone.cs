using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingletone <T> : MonoBehaviour where T:MonoBehaviour
{
    [Header("Singleton")]
    [SerializeField] private bool dontDestroy;

    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            if (dontDestroy)
                Destroy(gameObject);
            else
                Destroy(this.gameObject);
        }
        else
        {
            instance = this as T;
            if (dontDestroy)
                DontDestroyOnLoad(gameObject);
        }
    }
}
