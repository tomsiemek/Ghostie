using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private const float RESPAWN_DELAY = 1.5f;
    [SerializeField] private float BarrowAccelerationMultiplier = 1.5f;
    public Rigidbody2D Rb;
    //public float airFriction = 2.0f;
    public float acceleration = 7.8f;
    private Vector2 move = new Vector2(0, 0);
    private LevelManager levelManager;
    Vector3 portalPosition;
    private Camera camera;
    bool finished = false;
    float shrinkageScalePerSecond = 0.8f;
    float timeElapsedForMovementToPortal = 0;
    private float baseAcc;
    private AudioSource hurtSound;
    private AudioSource victorySound;
    private bool controable = true;

    private Vector3 baseScale;
    
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        camera = Camera.main;
        baseAcc = acceleration;
        hurtSound = transform.Find("HurtSound").GetComponent<AudioSource>();
        victorySound = transform.Find("VictorySound").GetComponent<AudioSource>();
        baseScale = transform.localScale;
    }
    void SetRotatin(bool val)
    {
        var childSprite = transform.GetChild(0).gameObject;
        childSprite.GetComponent<Rotate>().enabled = val;
    }
    void ResetRotation()
    {
        transform.Find("PlayerSprite").localRotation = Quaternion.identity;
    }
    public void Respawn()
    {
        SetRotatin(false);
        ResetRotation();  
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        Rb.velocity = Vector3.zero;
        controable = true;
        transform.localScale = baseScale;
        levelManager.Respawned();
    }

    void LevelFinished()
    {
        finished = true;
        controable = false;
        victorySound.Play();
        SetRotatin(true);
        FindObjectOfType<LevelManager>().EndTheGame();
        GameObject portal = GameObject.Find("Portal");
        portalPosition = portal.transform.position;
    }

    void DoHurtMedia(string funcToCall)
    {
        hurtSound.Play();
        controable = false;
        Rb.velocity = Vector3.zero;
        SetRotatin(true);
        Invoke(funcToCall, RESPAWN_DELAY);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Portal") && controable)
        {
            LevelFinished();
        }
        if (collider.CompareTag("Enemy") && controable)
        {
            DoHurtMedia("Respawn");
        }
    }

    void ReloadLevel()
    {
        levelManager.ReloadLevel();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Barrow") && controable)
        {
            acceleration = baseAcc * BarrowAccelerationMultiplier;
        }
        if (col.collider.CompareTag("Enemy") && controable)
        {
            Cannon.ShootingEnabled = false;
            DoHurtMedia("ReloadLevel");
            
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.CompareTag("Barrow") && controable)
        {
            acceleration = baseAcc;
        }
    }

    void Shrinkage()
    {
        transform.localScale = transform.localScale * (1f - shrinkageScalePerSecond * Time.fixedDeltaTime);
    }
    void MoveTowardsPortal()
    {
        timeElapsedForMovementToPortal += Time.fixedDeltaTime;
        transform.position = Vector2.Lerp(transform.position, portalPosition, timeElapsedForMovementToPortal / GameConstants.LEVEL_CHANGE_DELAY);
        Debug.Log(timeElapsedForMovementToPortal / GameConstants.LEVEL_CHANGE_DELAY);
    }

    void FixedUpdate()
    {
        
        if(finished)
        {
            MoveTowardsPortal();
        }
        if(!controable)
        {
            Shrinkage();
            return;
        }
        float delta = Time.fixedDeltaTime;
        Vector2 force = move * acceleration * delta;
        Rb.AddForce(force, ForceMode2D.Force);
        DirectionUpdate();
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);

    }

    void DirectionUpdate()
    {
        Vector2 moveDirection = move;
        if (moveDirection != Vector2.zero)
        {
            float angle = (Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg) - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    // Update is called once per frame
    void Update()
    {
        move.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(Input.GetButton("Fire1"))
        {
            
            Vector2 direction = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            direction = direction.normalized;
            move = direction;
        }
    }
}
