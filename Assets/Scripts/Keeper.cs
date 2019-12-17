using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keeper : MonoBehaviour
{
    // Start is called before the first frame update
    enum KeeperMode { WAITING, READY, OPENED };
    KeeperMode Mode = KeeperMode.WAITING;
    public GameObject Gate;
    float timeElapsed = 0;
    float magnitude = 15;
    void Start()
    {
        
    }
    public void CoinsCollected()
    {
        Mode = KeeperMode.READY;
        
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void OpenGate()
    {
        Mode = KeeperMode.OPENED;
        Gate.GetComponent<SpriteRenderer>().color = Color.green;
        GetComponent<SpriteRenderer>().color = Color.gray;
        Gate.GetComponent<BoxCollider2D>().isTrigger = true;
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(Mode == KeeperMode.READY && collider.CompareTag("Player"))
        {
            OpenGate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(  Mathf.Abs(transform.rotation.z) > 0.05)
        {
            magnitude *= -1;
        }
        timeElapsed += Time.deltaTime;
        timeElapsed %= 2 * Mathf.PI;
        
        transform.Rotate(Vector3.forward * magnitude * Time.deltaTime);


    }
}
