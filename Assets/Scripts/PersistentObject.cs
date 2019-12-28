using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    private static PersistentObject s_Instance = null;

    void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Destroy()
    {
        s_Instance = null;
        Destroy(gameObject);
    }
}
