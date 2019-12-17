using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : MonoBehaviour
{
    public GameObject player;
    float hp;
    public int hitsToKill = 5;

    float ColorChangeDuration = 0.5f;
    float timeColorElapsed;
    bool gotHit;
    Color colorWhenHit = Color.green;
    Color colorNormal;
    SpriteRenderer spriteRenderer;
    public float acceleration = 0.1f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorNormal = spriteRenderer.color;
        hp = hitsToKill;
    }

    void TakeDmg()
    {
        hp -= 1;
        if(hp == 0)
        {
            Destroy(gameObject);
        }
        gotHit = true;
        spriteRenderer.color = colorWhenHit;
        timeColorElapsed = 0;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            player.GetComponent<Player>().Respawn();
        }
        if(collider.CompareTag("Missile"))
        {
            TakeDmg();
        }
    }
    void FixedUpdate()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 enemyPos = transform.position;
        Vector3 diff = playerPos - enemyPos;
        float enemyForce = Time.fixedDeltaTime * acceleration;
        diff.Scale(new Vector3(enemyForce, enemyForce, enemyForce));
        rb.AddForce(diff);
    }
    // Update is called once per frame
    void Update()
    {
        if(gotHit)
        {
            timeColorElapsed += Time.deltaTime;
            if(timeColorElapsed > ColorChangeDuration)
            {
                gotHit = false;
                spriteRenderer.color = colorNormal;
            }
        }
    }
}
