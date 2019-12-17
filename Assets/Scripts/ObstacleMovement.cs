using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 10;
    public float verticalMovement = 1;
    public float horizontalMovement = 0;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Terrain"))
        {
            speed *= -1;
        }
    }
    void FixedUpdate()
    {
        rb.transform.Translate(speed * Time.fixedDeltaTime * horizontalMovement, speed * Time.fixedDeltaTime * verticalMovement, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
