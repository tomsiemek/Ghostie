using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrainGenerator : MonoBehaviour
{
    [SerializeField] private GameObject grain;
    [SerializeField] private int NumberOfGrains = 100;
    [SerializeField] private float Radius = 3;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < NumberOfGrains; i++)
        {
            Generate();
        }
    }
    void Generate()
    {
        Vector3 randomizer = new Vector3(Random.value * Radius, Random.value * Radius, 0);
        Instantiate(grain, transform.position + randomizer, Quaternion.identity);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
