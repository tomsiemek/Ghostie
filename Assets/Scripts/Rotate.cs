using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float timeForRotation;
    float timeElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        timeElapsed = (timeElapsed > timeForRotation) ? (timeElapsed - timeForRotation) : (timeElapsed);
        const float fullRotationInDegrees = 360;
        //float angle = fullRotationInDegrees * (timeElapsed/timeForRotation);
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Rotate(Vector3.forward * Time.deltaTime * fullRotationInDegrees);
    }
}
