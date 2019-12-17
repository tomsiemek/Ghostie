using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().EndTheGame();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
