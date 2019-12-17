using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject missile;
    public float ShootingCooldown = 0.6f;
    private float TimeFromLastShooting;
    public Vector2 direction;
    public float speed = 1;

    void Start()
    {
        TimeFromLastShooting = ShootingCooldown * 1.5f;
    }

    void FixedUpdate()
    {
        TimeFromLastShooting += Time.fixedDeltaTime;
        TimeFromLastShooting = Mathf.Min(TimeFromLastShooting, ShootingCooldown * 1.1f);

        if (TimeFromLastShooting > ShootingCooldown)
        {
            var obj = Instantiate(missile, transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().velocity = direction * speed;
            TimeFromLastShooting = 0;
        }

    }
}
    // Update is called once per frame
