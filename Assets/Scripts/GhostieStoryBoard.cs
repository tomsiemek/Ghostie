using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostieStoryBoard : MonoBehaviour
{
    private Vector3 target;
    private Rigidbody2D rb;
    [SerializeField] private float Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Portal").transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void DirectionUpdate(Vector2 direction)
    {
        Vector2 moveDirection = direction;
        if (moveDirection != Vector2.zero)
        {
            float angle = (Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg) - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = target - transform.position;
        rb.velocity = direction.normalized * Speed;
        DirectionUpdate(direction);
    }
}
