using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float ShootingForce = 2f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        Vector2 origin = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(origin.ToString()+ " -> " + destination.ToString());
        Vector2 move = destination - origin;
        move = move.normalized;
        rigidbody2D.AddForce(move * ShootingForce, ForceMode2D.Impulse);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
        if(col.collider.tag != "Terrain" && col.collider.name != "The Keeper")
        {
            Destroy(col.collider.gameObject);
        }
    }
    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
