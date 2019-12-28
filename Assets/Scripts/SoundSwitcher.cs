using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoundSwitcher : MonoBehaviour
{
    private TextMeshProUGUI textMesh; 
    private static bool on = true;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        if (on)
        {
            textMesh.text = "SOUND: ON";
        }
        else
        {
            textMesh.text = "SOUND: OFF";
        }
    }
    public void Switch()
    {
        if (on)
        {
            textMesh.text = "SOUND: OFF";
            AudioListener.volume = 0;
        }
        else
        {
            textMesh.text = "SOUND: ON";
            AudioListener.volume = 1;
        }
        on = !on;
    }
}
