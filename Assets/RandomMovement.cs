using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField] private float Radius = 3;
    [SerializeField] private float Speed = 1;
    private Vector3 destination;
    private float t = 0;
    [SerializeField]private float tMax = 21;
    private Vector3 pos0;
    private bool Pushed = false;
    [SerializeField] private GameObject PortalToActivate;

    private float MoveCD = 0;
    // Start is called before the first frame update
    void Start()
    {
        destination = new Vector3();
        pos0 = transform.position;
        NewDestination();
    }

    void NewDestination()
    {

        Vector3 Delta = Random.insideUnitCircle * Radius;
        destination = Delta + pos0;
        //tMax = Delta.magnitude * Speed;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Barrow"))
        {
            MoveCD = 5;
        }  
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Triple")
        {
            PortalToActivate.SetActive(true);
            Destroy(gameObject);
            Debug.Log("XD");
        }
    }
    void MoveTowards()
    {
        transform.position = Vector3.Lerp(transform.position, destination, t/tMax);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(MoveCD > 0)
        {
            MoveCD -= Time.fixedDeltaTime;
            return;
        }
        t += Time.fixedDeltaTime;
        t = (t > tMax) ? (tMax) : (t);
        MoveTowards();
        if (t == tMax || destination == transform.position)
        {
            t = 0;
            NewDestination();
        }
    }
}
