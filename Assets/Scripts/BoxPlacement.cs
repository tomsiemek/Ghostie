using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPlacement : MonoBehaviour
{
    [SerializeField] private Gates gates = null;
    [SerializeField] private float minDist = 0.5f;
    private AudioSource gateSqueek;
    // Start is called before the first frame update
    void Start()
    {
        if(!gates)
        {
            gates = FindObjectOfType<Gates>();
        }
        gateSqueek = transform.Find("GateSound").GetComponent<AudioSource>();
    }

    void UpdateColor()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        Color c = spriteRenderer.color;
        c.a = 0.3f;
        spriteRenderer.color = c;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Box") && Vector2.Distance(transform.position, collider.transform.position) < minDist)
        {
            Destroy(collider.gameObject);
            UpdateColor();
            gateSqueek.Play();
            gates.Open();
        }
    }
}
