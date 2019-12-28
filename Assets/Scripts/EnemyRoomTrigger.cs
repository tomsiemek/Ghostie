using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyRoomTrigger : MonoBehaviour
{
    private const float SHOOTING_ENABLE_DELAY = 2;
    private float TimeElapsed = 2;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            TimeElapsed = 0;
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && TimeElapsed >= 2)
        {
            Cannon.ShootingEnabled = true;
        }
    }

    void ClearAllBullets()
    {
        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Bullet(Clone)");
        foreach(var obj in objects)
        {
            Destroy(obj);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Cannon.ShootingEnabled = false;
            ClearAllBullets();
        }
    }
    void FixedUpdate()
    {
        TimeElapsed += Time.fixedDeltaTime;
        TimeElapsed = (TimeElapsed > SHOOTING_ENABLE_DELAY) ? (SHOOTING_ENABLE_DELAY) : (TimeElapsed);
    }
}
