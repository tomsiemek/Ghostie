using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostieMenuMovement : MonoBehaviour
{
    private float timeElapsed = 0;
    [SerializeField] private float timeForRotation;
    [SerializeField]private float maxMovement = 250;
    private float pos0;
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        pos0 = rect.position.x;
    }
    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
        timeElapsed = (timeElapsed > timeForRotation) ? (timeElapsed - timeForRotation) : (timeElapsed);
        var pos = rect.transform.position;
        pos.x = pos0 + Mathf.Sin(timeElapsed / timeForRotation * 2 * Mathf.PI) * maxMovement;
        rect.position = pos;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
