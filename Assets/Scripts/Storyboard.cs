using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Storyboard : MonoBehaviour
{
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            End();
        }
    }

    void End()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
