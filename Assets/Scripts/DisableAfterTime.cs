using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    [SerializeField] private float Delay = 2;
    void Awake()
    {
        Invoke("Disable", Delay);
    }
    void Disable()
    {
        gameObject.SetActive(false);
    }

}
