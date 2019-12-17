using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private GameObject ToSwitch = null;
    private SpriteRenderer spriteRenderer;
    private Color colorOff;
    private Color colorOn;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!ColorUtility.TryParseHtmlString("#91A18E", out colorOn))
        {
            colorOn = Color.grey;            
        }
        if (!ColorUtility.TryParseHtmlString("#A28F8F", out colorOff))
        {
            colorOn = Color.black;
        }
    }

    void UpdateColor(Color c)
    {
        
        spriteRenderer.color = c;

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("SwitchCollider"))
        {
            Debug.Log("hellp");
            UpdateColor(colorOn);
            ToSwitch.SetActive(!ToSwitch.activeSelf);
        }
    }
    
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("SwitchCollider"))
        {
            Debug.Log("jebp");
            UpdateColor(colorOff);
            ToSwitch.SetActive(!ToSwitch.activeSelf);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
