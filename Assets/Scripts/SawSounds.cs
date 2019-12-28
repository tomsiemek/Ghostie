using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSounds : MonoBehaviour
{
    [SerializeField] private float PlayDelay = 2;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Play();
    }

    void Play()
    {
        audioSource.Play();
        Invoke("Play", PlayDelay);
    }
}
