using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour
{
    [SerializeField] private float Period = 1;
    [SerializeField] private float Radius = 1;
    [SerializeField] private Vector3 Axis;
    [SerializeField] private float Phase = 0;
    private float timeElapsed;
    private float pos0;
    // Start is called before the first frame update
    void Start()
    {
        pos0 = Vector3.Dot(Axis, transform.position);
    }
    // ex: (0,1,0) -> (1,0,1)
    Vector3 ReversedVector(Vector3 v)
    {
        return (v + new Vector3(-1, -1, -1)) * -1;
    }
    // (a1 * a2, b1 * b2, c1 * c2)
    Vector3 FilterVector(Vector3 val, Vector3 filter)
    {
        return new Vector3(val.x * filter.x, val.y * filter.y, val.z * filter.z);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
        timeElapsed = (timeElapsed > Period) ? (timeElapsed - Period) : (timeElapsed);
        var delta = Mathf.Abs(Mathf.Sin(timeElapsed / Period * 2 * Mathf.PI + Phase)) * Radius;
        var otherAxies = FilterVector(ReversedVector(Axis), transform.position);
        var updatedAxis = Axis * (pos0 + delta);
        transform.position = otherAxies + updatedAxis;
    }
}
