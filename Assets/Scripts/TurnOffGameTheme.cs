using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffGameTheme : MonoBehaviour
{
    void Start()
    {
        GameObject theme = GameObject.Find("Theme");
        if(theme)
        {
            theme.GetComponent<PersistentObject>().Destroy();
        }
    }
}
