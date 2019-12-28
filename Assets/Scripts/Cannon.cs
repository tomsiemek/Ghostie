using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject missile;
    public float ShootingCooldown = 0.6f;
    private float TimeFromLastShooting;
    private GameObject target;
    public float speed = 1000;
    private Vector2 moveDirection;
    private Collider2D colliderToIgnore;
    public static bool ShootingEnabled = false;

    private AudioSource shootSound;

    void Start()
    {
        ShootingEnabled = false;
        TimeFromLastShooting = 0;
        target = GameObject.Find("Player");
        colliderToIgnore = transform.parent.gameObject.GetComponent<Collider2D>();
        shootSound = GetComponent<AudioSource>();
    }

    void UpdateDirection()
    {
        moveDirection = target.transform.position - transform.position;
        if (moveDirection != Vector2.zero)
        {
            float angle = (Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg) + 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void FixedUpdate()
    {
        TimeFromLastShooting += Time.fixedDeltaTime;
        UpdateDirection();
        if (TimeFromLastShooting > ShootingCooldown && ShootingEnabled)
        {
            shootSound.Play();
            var obj = Instantiate(missile, transform.position, Quaternion.identity);
            Collider2D bulletCollider = obj.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(colliderToIgnore, bulletCollider);
            obj.GetComponent<Rigidbody2D>().velocity = moveDirection.normalized * speed;
            TimeFromLastShooting = 0;
        }

    }
}
