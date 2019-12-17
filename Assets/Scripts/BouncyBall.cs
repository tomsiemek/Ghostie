using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    Rigidbody2D rb;
    float minimalSpeed = 6;
    public float ImpulsePower = 200;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    void FixedUpdate()
    {
        if(rb.velocity.magnitude < minimalSpeed)
        {
            rb.AddForce(new Vector2(Random.Range(-1,1), Random.Range(-1, 1)) * ImpulsePower, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
