using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 4;
    List<GameObject> enemies;

    Vector3 max;
    Vector3 min;
    public float centerRadius = 0.7f;


    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        Bounds bounds = GetComponent<BoxCollider2D>().bounds;
        min = bounds.center - (bounds.extents * centerRadius);
        max = bounds.center + (bounds.extents * centerRadius);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(collider.CompareTag("Player"))
        {
            Debug.Log(min.ToString());
            Debug.Log(max.ToString());
            for (int i = 0; i < numberOfEnemies; i++)
            {
                enemies.Add(Instantiate(enemyPrefab, new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), 0), Quaternion.identity));
            }            
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Destroy(enemies[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
